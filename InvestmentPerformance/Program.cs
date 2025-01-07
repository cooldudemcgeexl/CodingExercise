using Microsoft.EntityFrameworkCore;
using InvestmentPerformance.Models;
using InvestmentPerformance.Utils;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddDbContext<IPContext>(opt => opt.UseInMemoryDatabase("InvestmentPerformance").UseSeeding((context, _) =>
{

    context.Set<User>().AddRange(SeedData.Users);
    context.SaveChanges();

    context.Set<Investment>().AddRange(SeedData.Investments);
    context.SaveChanges();

}).UseAsyncSeeding(async (context, _, CancellationToken) =>
{

    context.Set<User>().AddRange(SeedData.Users);
    await context.SaveChangesAsync(CancellationToken);


    context.Set<Investment>().AddRange(SeedData.Investments);
    await context.SaveChangesAsync(CancellationToken);
}));

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();



// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();

    // Ensure the database schema exists. This will cause the seeding logic to be called.
    // We will only seed when running in development
    using var scope = app.Services.CreateScope();
    var context = scope.ServiceProvider.GetRequiredService<IPContext>();
    context.Database.EnsureCreated();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
