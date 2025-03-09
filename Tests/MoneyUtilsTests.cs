using VintedAcademyBackendHomework.Utils;

namespace Tests;

public class MoneyUtilsTests
{
    [Fact]
    public void IntCentsToEurString_WhenSumIsNormal()
    {
        Assert.Equal("1.50", MoneyUtils.IntCentsToEurString(150));
    }
    
    [Fact]
    public void IntCentsToEurString_WhenSumIsZero()
    {
        Assert.Equal("0.00", MoneyUtils.IntCentsToEurString(0));
    }
}