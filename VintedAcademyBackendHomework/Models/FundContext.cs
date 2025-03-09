namespace VintedAcademyBackendHomework.Models;

public class FundContext
{
    private readonly int _monthlyFund;

    public FundContext(int monthlyFund)
    {
        _monthlyFund = monthlyFund;
        Balance = monthlyFund;
    }

    private int Balance { get; set; }

    public int GetBalance()
    {
        return Balance;
    }
    
    public int GetHowMuchReduced(int discountPrice)
    {
        if (Balance >= discountPrice)
        {
            Balance -= discountPrice;
            return discountPrice;
        }

        var tempBalance = Balance;
        Balance = 0;
        return tempBalance;
    }

    public void MonthRestart()
    {
        Balance = _monthlyFund;
    }
}