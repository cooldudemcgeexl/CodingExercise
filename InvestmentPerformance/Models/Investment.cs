namespace InvestmentPerformance.Models;


public class Investment
{
    public int Id { get; set; }
    public string? Name { get; set; }
    public int NumShares { get; set; }
    public decimal CostBasisPerShare { get; set; }
    public decimal CurrentPrice { get; set; }
    public decimal CurrentValue => NumShares * CurrentPrice;

    public decimal TotalGainLoss => CurrentValue - (NumShares * CostBasisPerShare);

    public DateTime PurchaseDate { get; set; }
    public string InvestmentTerm => DateTime.Now > PurchaseDate.AddYears(1) ? "Long" : "Short";

    public int UserId { get; set; }
    public User User { get; set; } = null!;



}

public class InvestmentDetails
{
    public string? Name { get; set; }
    public int NumShares { get; set; }
    public decimal CostBasisPerShare { get; set; }
    public decimal CurrentValue { get; set; }
    public decimal CurrentPrice { get; set; }
    public string InvestmentTerm { get; set; }
    public decimal TotalGainLoss { get; set; }

    public InvestmentDetails(Investment investment)
    {
        Name = investment.Name;
        NumShares = investment.NumShares;
        CostBasisPerShare = investment.CostBasisPerShare;
        CurrentValue = investment.CurrentValue;
        CurrentPrice = investment.CurrentPrice;
        InvestmentTerm = investment.InvestmentTerm;
        TotalGainLoss = investment.TotalGainLoss;
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