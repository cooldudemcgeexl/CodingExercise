using Microsoft.EntityFrameworkCore;

namespace InvestmentPerformance.Models;

public class IPContext : DbContext
{
    public IPContext(DbContextOptions<IPContext> options) : base(options)
    {

    }
    public IPContext() : base()
    {

    }

    public virtual DbSet<User> Users { get; set; } = null!;
    public virtual DbSet<Investment> Investments { get; set; } = null!;
}