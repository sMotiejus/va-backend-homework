using VintedAcademyBackendHomework.Models;
using VintedAcademyBackendHomework.Utils;

namespace Tests;

public class DateOnlyUtilsTests
{
    [Fact]
    public void GetDateOnlyString_DefaultDateFormat()
    {
        Assert.Equal("2025-03-08", DateOnlyUtils.DateOnlyToFormatedDate(DateOnly.Parse("2025-03-08")));
    }
    
    [Fact]
    public void GetDateOnlyString_GivenDateFormat()
    {
        Assert.Equal("2025/03/08", DateOnlyUtils.DateOnlyToFormatedDate(DateOnly.Parse("2025-03-08"), "yyyy/MM/dd"));
    }
}