namespace InvestmentPerformance.Models;


public class Investment
{
    public int Id { get; set; }
    public string? Name { get; set; }
    public int NumShares { get; set; }
    public decimal CostBasisPerShare { get; set; }
    public decimal CurrentPrice { get; set; }


    public DateTime PurchaseDate { get; set; }

    public int UserId { get; set; }
    public User User { get; set; } = null!;



}

public class InvestmentDetails
{
    public string? Name { get; set; }
    public int NumShares { get; set; }
    public decimal CostBasisPerShare { get; set; }
    public decimal CurrentValue => NumShares * CurrentPrice;
    public decimal CurrentPrice { get; set; }
    public string InvestmentTerm { get; set; }
    public decimal TotalGainLoss => CurrentValue - (NumShares * CostBasisPerShare);

    public InvestmentDetails(Investment investment)
    {
        Name = investment.Name;
        NumShares = investment.NumShares;
        CostBasisPerShare = investment.CostBasisPerShare;
        CurrentPrice = investment.CurrentPrice;
        InvestmentTerm = DateTime.Now > investment.PurchaseDate.AddYears(1) ? "Long" : "Short";
    }
}

public class InvestmentListItem
{
    public int Id { get; set; }
    public string? Name { get; set; }
    public InvestmentListItem(Investment investment)
    {
        Id = investment.Id;
        Name = investment.Name;
    }
}

public class InvestmentDetailsInput
{
    public int Id { get; set; }
    public int UserId { get; set; }
}