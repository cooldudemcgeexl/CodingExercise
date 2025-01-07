

using InvestmentPerformance.Controllers;
using InvestmentPerformance.Models;
using InvestmentPerformance.Utils;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Moq;
using Moq.EntityFrameworkCore;
using Xunit;

public class ControllerTests
{

    [Fact]
    public async Task UserInvestmentsShould404OnError()
    {
        var mockContext = new Mock<IPContext>();
        mockContext.Setup(x => x.Users).ReturnsDbSet(SeedData.Users);
        mockContext.Setup(x => x.Investments).ReturnsDbSet(SeedData.Investments);

        var mockLogger = new Mock<ILogger<InvestmentPerformanceController>>();

        var controller = new InvestmentPerformanceController(mockContext.Object, mockLogger.Object);
        var response = (await controller.GetUserInvestments(0)).Result;

        Assert.IsType<NotFoundResult>(response);
    }
}