namespace VintedAcademyBackendHomework.Utils;

public static class DateOnlyUtils
{
    public static string DateOnlyToFormatedDate(DateOnly date, string format = "yyyy-MM-dd")
    {
        return date.ToString(format);
    }
}