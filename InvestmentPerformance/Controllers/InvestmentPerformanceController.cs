using InvestmentPerformance.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
namespace InvestmentPerformance.Controllers;



[ApiController]
[Route("api/[controller]")]
public class InvestmentPerformanceController : ControllerBase
{
    private readonly IPContext _context;
    private readonly ILogger<InvestmentPerformanceController> _logger;
    public InvestmentPerformanceController(IPContext context, ILogger<InvestmentPerformanceController> logger)
    {
        _context = context;
        _logger = logger;
    }


    [HttpGet("{userId}", Name = "GetInvestmentsForUser")]
    public async Task<ActionResult<IEnumerable<InvestmentListItem>>> Get(int userId)
    {
        var investments = await _context.Investments.Where(x => x.UserId == userId)
                                                    .Select(x => new InvestmentListItem(x))
                                                    .ToListAsync();

        if (investments == null || investments.Count == 0)
        {
            return NotFound();
        }
        return investments.OrderBy(x => x.Id).ToList();
    }

    [HttpPost(Name = "GetInvestmentDetailsForUser")]
    public async Task<ActionResult<InvestmentDetails>> GetInvestmentDetails(InvestmentDetailsInput input)
    {
        var investment = await _context.Investments.Where(x => x.UserId == input.UserId && x.Id == input.Id).FirstOrDefaultAsync();

        if (investment == null)
        {
            return NotFound();
        }
        return new InvestmentDetails(investment);
    }
}