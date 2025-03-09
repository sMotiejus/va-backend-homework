namespace VintedAcademyBackendHomework.Utils;

public static class MoneyUtils
{
    public static string IntCentsToEurString(int value)
    {
        //https://learn.microsoft.com/en-us/dotnet/csharp/tour-of-csharp/tutorials/numbers-in-csharp-local (m-for money)
        var result = value / 100m;
        return result.ToString("0.00");
    }
}