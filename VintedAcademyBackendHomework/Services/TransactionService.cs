using VintedAcademyBackendHomework.Models;

namespace VintedAcademyBackendHomework.Services;

public class TransactionService(IProviderService providerService) : ITransactionService
{
    public Transaction CreateTransaction(string dataLine)
    {
        var data = dataLine.Split(' ');
        if (data.Length < 3) return new Transaction(true);

        var isInvalidFormat = !DateOnly.TryParse(data[0], out var transactionDate);
        var provider = providerService.ProviderExists(data[2]) ? data[2] : string.Empty;
        var packageSize = providerService.PackageSizeExists(data[1], provider) ? data[1] : string.Empty;

        var price = !string.IsNullOrEmpty(provider) ?providerService.GetPackagePrice(providerService.GetProvider(provider), packageSize):0;

        var hasInvalidData = string.IsNullOrEmpty(provider) || string.IsNullOrEmpty(packageSize);

        return new Transaction(transactionDate, packageSize, provider, price, 0, isInvalidFormat || hasInvalidData);
    }
}