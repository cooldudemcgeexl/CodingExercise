namespace InvestmentPerformance.Models;

public enum InvestmentTerm
{
    Short,
    Long
}

public class Investment
{
    public long Id { get; set; }
    public string? Name { get; set; }
    public int NumShares { get; set; }
    public decimal CostBasisPerShare { get; set; }
    public decimal CurrentPrice { get; set; }
    public decimal CurrentValue => NumShares * CurrentPrice;

    public decimal TotalGainLoss => CurrentValue - (NumShares * CostBasisPerShare);

    private DateTime PurchaseDate { get; set; }
    public InvestmentTerm InvestmentTerm => DateTime.Now > PurchaseDate.AddYears(1) ? InvestmentTerm.Short : InvestmentTerm.Long;

    public User User { get; set; } = null!;
    public int UserId { get; set; }



}

public class InvestmentListItemModel
{
    public long Id { get; set; }
    public string? Name { get; set; }
    public InvestmentListItemModel(Investment investment)
    {
        Id = investment.Id;
        Name = investment.Name;
    }
}

public class InvestmentDetailsInputModel
{
    public long Id { get; set; }
    public int UserId { get; set; }
}