
using InvestmentPerformance.Models;

namespace InvestmentPerformance.Utils;
public static class SeedData
{
    public static List<User> Users = [
        new User {Id = 1, FirstName = "Nick", LastName = "Lay"}
    ];


    public static List<Investment> Investments = [
        new Investment {Id = 1, UserId=1, Name = "Alan Smithee Productions", NumShares = 45, CostBasisPerShare = 102.57M, CurrentPrice= 100.00M, PurchaseDate= new DateTime(2022,11,18)}
    ];
};