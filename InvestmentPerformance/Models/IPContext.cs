using Microsoft.EntityFrameworkCore;

namespace InvestmentPerformance.Models;

public class IPContext : DbContext
{
    public IPContext(DbContextOptions<IPContext> options) : base(options)
    {

    }

    public DbSet<User> Users { get; set; } = null!;
    public DbSet<Investment> Investments { get; set; } = null!;
}