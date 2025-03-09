using VintedAcademyBackendHomework.Models;
using VintedAcademyBackendHomework.Services;

namespace VintedAcademyBackendHomework.Rules;

public class NShipmentRule(
    ProviderService providerService,
    string packageSize,
    string providerName,
    int whichShipmentFreeOnceAMonth) : IRuleService
{
    public bool Validate(Transaction transaction, RuleContext context, IOutputService outputService)
    {
        if (!transaction.GetPackageSize().Equals(packageSize) &&
            transaction.GetProvider().Equals(providerName))
            return false;

        var transactionsByYearAndMonth =
            context.GetSpecificTransactions(transaction.GetDate().Year, transaction.GetDate().Month, null, "L", "LP");

        if (transactionsByYearAndMonth.Count != whichShipmentFreeOnceAMonth) return false;

        var provider = providerService.GetProvider(providerName);

        var packagePrice = provider.GetPackagePrice(packageSize);

        var reducedPrice = context.GetHowMuchReduced(packagePrice);

        transaction.SetPrice(packagePrice - reducedPrice);
        transaction.SetDiscount(reducedPrice);

        outputService.WriteLine(transaction.ToString());
        return true;
    }
}