namespace VintedAcademyBackendHomework.Models;

public class RuleContext(FundContext fundContext)
{
    private List<Transaction> Transactions { get; } = [];

    public void AddTransaction(Transaction transaction)
    {
        if (Transactions.Count > 0 && transaction.GetDate().Month != Transactions.Last().GetDate().Month)
            fundContext.MonthRestart();

        Transactions.Add(transaction);
    }

    public int GetHowMuchReduced(int packagePrice)
    {
        return fundContext.GetHowMuchReduced(packagePrice);
    }

    public List<Transaction> GetSpecificTransactions(int? year, int? month, int? day, string? packageSize,
        string? providerName)
    {
        return Transactions.FindAll(transaction =>
        {
            var date = transaction.GetDate();

            var matchesYear = !year.HasValue || date.Year == year.Value;
            var matchesMonth = !month.HasValue || date.Month == month.Value;
            var matchesDay = !day.HasValue || date.Day == day.Value;
            var matchesPackageSize = string.IsNullOrEmpty(packageSize) || packageSize == transaction.GetPackageSize();
            var matchesProviderName = string.IsNullOrEmpty(providerName) || providerName == transaction.GetProvider();

            return matchesYear && matchesMonth && matchesDay && matchesPackageSize && matchesProviderName;
        });
    }
}