using VintedAcademyBackendHomework.Models;

namespace Tests;

public class FundContextTests
{
    [Fact]
    public void GetHowMuchReduced_WhenSufficientFunds()
    {
        var fundContext = new FundContext(40);
        var reducedAmount = fundContext.GetHowMuchReduced(40);
        Assert.Equal(40, reducedAmount);
    }

    [Fact]
    public void GetHowMuchReduced_WhenNotEnoughFunds()
    {
        var fundContext = new FundContext(30);
        var reducedAmount = fundContext.GetHowMuchReduced(31);
        Assert.Equal(30, reducedAmount);
    }

    [Fact]
    public void MonthRestart_ToMonthlyFund()
    {
        var fundContext = new FundContext(100);
        
        // Discount random sum from fund
        fundContext.GetHowMuchReduced(23);

        fundContext.MonthRestart();
        Assert.Equal(100, fundContext.GetBalance());
    }
}