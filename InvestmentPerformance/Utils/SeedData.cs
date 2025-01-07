
using InvestmentPerformance.Models;

namespace InvestmentPerformance.Utils;
public static class SeedData
{
    public static List<User> Users = [
        new User {Id = 1, FirstName = "Nick", LastName = "Lay"},
        new User {Id = 2, FirstName = "John", LastName = "Doe"},
        new User {Id = 3, FirstName = "Bill", LastName = "Wilson"}
    ];

    // Disclaimer: These decimal literals were generated with ChatGPT
    private static readonly List<decimal> Prices = [
        100.00m,
        86.89m,
        283.42m,
        59.08m,
        53.64m,
        225.79m
    ];

    // Disclaimer: All but the first name here were generated with ChatGPT
    private static readonly List<string> Companies = [
        "Alan Smithee Productions",
        "Novatera Dynamics",
        "Stratos Edge Technologies",
        "Lumora Ventures Inc.",
        "Aegis NexGen Solutions",
        "Vertexion Industries",
    ];

    public static List<Investment> Investments = [
        new Investment {Id = 1, UserId=1, Name = Companies[0], NumShares = 45, CostBasisPerShare = 102.57m, CurrentPrice  = Prices[0], PurchaseDate= new DateTime(2022,11,18)},
        new Investment {Id = 2, UserId=1, Name = Companies[1], NumShares = 100, CostBasisPerShare = 50.00m, CurrentPrice  = Prices[1], PurchaseDate= new DateTime(2022,11,17)},
        new Investment {Id = 3, UserId=1, Name = Companies[3], NumShares = 18, CostBasisPerShare = 102.57m, CurrentPrice  = Prices[3], PurchaseDate= new DateTime(2024,10,19)},
        new Investment {Id = 4, UserId=1, Name = Companies[0], NumShares = 28, CostBasisPerShare = 85.70m, CurrentPrice  = Prices[0], PurchaseDate= new DateTime(2025,1,1)},
    ];
};