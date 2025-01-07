

using InvestmentPerformance.Controllers;
using InvestmentPerformance.Models;
using InvestmentPerformance.Utils;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Moq;
using Moq.EntityFrameworkCore;
using Xunit;

public class ControllerTests
{

    private InvestmentPerformanceController BuildControllerFromMocks()
    {

        var mockContext = new Mock<IPContext>();
        mockContext.Setup(x => x.Users).ReturnsDbSet(SeedData.Users);
        mockContext.Setup(x => x.Investments).ReturnsDbSet(SeedData.Investments);

        var mockLogger = new Mock<ILogger<InvestmentPerformanceController>>();
        return new InvestmentPerformanceController(mockContext.Object, mockLogger.Object);
    }

    [Fact]
    public async Task UserInvestmentsShouldReturnNotFoundOnEmpty()
    {
        var controller = BuildControllerFromMocks();

        var response = (await controller.GetUserInvestments(0)).Result;

        Assert.IsType<NotFoundResult>(response);
    }

    [Fact]
    public async Task UserInvestmentsReturnInvestmentList()
    {
        var controller = BuildControllerFromMocks();

        var response = (await controller.GetUserInvestments(1)).Result;

        Assert.IsType<OkObjectResult>(response);


        var investments = (response as OkObjectResult).Value;
        Assert.IsType<List<InvestmentListItem>>(investments);

        var investmentList = investments as List<InvestmentListItem>;
        Assert.NotEmpty(investmentList);
        Assert.Equal(4, investmentList.Count);


        Assert.Equal(1, investmentList[0].Id);
        Assert.Equal("Alan Smithee Productions", investmentList[0].Name);
    }

    [Fact]
    public async Task InvestmentDetailsShouldReturnNotFoundOnEmtpy()
    {
        var controller = BuildControllerFromMocks();

        var invalidUserResponse = (await controller.GetInvestmentDetails(new InvestmentDetailsInput { Id = 1, UserId = 0 })).Result;
        Assert.IsType<NotFoundResult>(invalidUserResponse);

        var invalidInvestmentResponse = (await controller.GetInvestmentDetails(new InvestmentDetailsInput { Id = 0, UserId = 1 })).Result;
        Assert.IsType<NotFoundResult>(invalidInvestmentResponse);

        var missingInvestmentDetailsResponse = (await controller.GetInvestmentDetails(new InvestmentDetailsInput { Id = 5, UserId = 1 })).Result;
        Assert.IsType<NotFoundResult>(missingInvestmentDetailsResponse);
    }

    [Fact]
    public async Task InvestmentDetailsShouldReturnInvestmentDetails()
    {
        var controller = BuildControllerFromMocks();

        var response = (await controller.GetInvestmentDetails(new InvestmentDetailsInput { Id = 1, UserId = 1 })).Result;
        Assert.IsType<OkObjectResult>(response);

        Assert.IsType<InvestmentDetails>((response as OkObjectResult).Value);
        var investmentDetails = (response as OkObjectResult).Value as InvestmentDetails;

        Assert.Equal("Alan Smithee Productions", investmentDetails.Name);
        Assert.Equal(45, investmentDetails.NumShares);
        Assert.Equal(102.57m, investmentDetails.CostBasisPerShare);
        Assert.Equal(100.00m, investmentDetails.CurrentPrice);
        Assert.Equal(4500.00m, investmentDetails.CurrentValue);
        Assert.Equal("Long", investmentDetails.InvestmentTerm);
        Assert.Equal(-115.65m, investmentDetails.TotalGainLoss);
    }
}