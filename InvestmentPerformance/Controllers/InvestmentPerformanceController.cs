using InvestmentPerformance.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
namespace InvestmentPerformance.Controllers;



[ApiController]
[Route("api/[controller]")]
public class InvestmentPerformanceController : ControllerBase
{
    private readonly IPContext _context;

    public InvestmentPerformanceController(IPContext context)
    {
        _context = context;
    }


    [HttpGet("{userId}", Name = "GetInvestmentsForUser")]
    public async Task<ActionResult<IEnumerable<InvestmentListItemModel>>> Get(int userId)
    {
        var investments = await _context.Investments.Where(x => x.UserId == userId)
                                                    .Select(x => new InvestmentListItemModel(x))
                                                    .ToListAsync();

        if (investments == null)
        {
            return NotFound();
        }
        return investments;
    }

    [HttpPost(Name = "GetInvestmentDetailsForUser")]
    public async Task<ActionResult<Investment>> GetInvestmentDetails(InvestmentDetailsInputModel input)
    {
        var investment = await _context.Investments.Where(x => x.UserId == input.UserId && x.Id == input.Id).FirstOrDefaultAsync();

        if (investment == null)
        {
            return NotFound();
        }
        return investment;
    }
}