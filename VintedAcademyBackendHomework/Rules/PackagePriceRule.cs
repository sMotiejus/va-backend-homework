using VintedAcademyBackendHomework.Models;
using VintedAcademyBackendHomework.Services;

namespace VintedAcademyBackendHomework.Rules;

public class PackagePriceRule(ProviderService providerService, string packageSize) : IRuleService
{
    public bool Validate(Transaction transaction, RuleContext context, IOutputService outputService)
    {
        if (!transaction.GetPackageSize().Equals(packageSize))
            return false;

        var providersPackagePrice =
            providerService.GetPackagePrice(providerService.GetProvider(transaction.GetProvider()),
                packageSize);
        var lowestPrice = providerService.GetCheapestPackageProvider(packageSize)
            .GetPackagePrice(packageSize);

        var needToReduce = providersPackagePrice - lowestPrice;
        var reducedPrice = context.GetHowMuchReduced(needToReduce);

        transaction.SetPrice(providersPackagePrice - reducedPrice);
        transaction.SetDiscount(reducedPrice);

        outputService.WriteLine(transaction.ToString());

        return true;
    }
}