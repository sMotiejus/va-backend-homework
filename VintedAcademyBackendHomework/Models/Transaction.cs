using VintedAcademyBackendHomework.Utils;

namespace VintedAcademyBackendHomework.Models;

public class Transaction
{
    public Transaction(DateOnly date, string packageSize, string provider, int price, int discount,
        bool? wrongFormat = false)
    {
        Date = date;
        PackageSize = packageSize;
        Provider = provider;
        Price = price;
        Discount = discount;
        WrongFormat = wrongFormat.GetValueOrDefault(false);
    }

    public Transaction(bool wrongFormat = false)
    {
        Date = DateOnly.MinValue;
        PackageSize = "";
        Provider = "";
        Price = -1;
        Discount = -1;
        WrongFormat = wrongFormat;
    }

    private DateOnly Date { get; set; }
    private string PackageSize { get; }
    private string Provider { get; }
    private int Price { get; set; }
    private int Discount { get; set; }
    private bool WrongFormat { get; }

    public DateOnly GetDate()
    {
        return Date;
    }

    public string GetProvider()
    {
        return Provider;
    }

    public string GetPackageSize()
    {
        return PackageSize;
    }

    public int GetPrice()
    {
        return Price;
    }

    public int GetDiscount()
    {
        return Discount;
    }
    
    public void SetDate(DateOnly date)
    {
        Date = date;
    }
    
    public void SetPrice(int price)
    {
        Price = price;
    }

    public void SetDiscount(int discount)
    {
        Discount = discount;
    }

    public bool IsFormatWrong()
    {
        return WrongFormat;
    }


    public override string ToString()
    {
        return
            $"{DateOnlyUtils.DateOnlyToFormatedDate(Date)} " +
            $"{PackageSize} " +
            $"{Provider} " +
            $"{MoneyUtils.IntCentsToEurString(Price)} " +
            $"{(Discount == 0 ? "-" : MoneyUtils.IntCentsToEurString(Discount))}";
    }
}