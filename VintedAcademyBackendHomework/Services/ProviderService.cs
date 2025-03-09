using VintedAcademyBackendHomework.Models;

namespace VintedAcademyBackendHomework.Services;

public class ProviderService(Provider[] providers) : IProviderService
{
    public bool ProviderExists(string providerName)
    {
        return providers.Any(pr => pr.GetName() == providerName);
    }

    public bool PackageSizeExists(string packageSize, string providerName)
    {
        var provider = providers.FirstOrDefault(pr => pr.GetName() == providerName);
        return provider?.PackageNameExists(packageSize) ?? false;
    }
    
    public Provider GetProvider(string providerName)
    {
        if (!ProviderExists(providerName)) throw new Exception("Provider not found");
        return providers.First(entry => entry.GetName() == providerName);
    }

    public int GetPackagePrice(Provider provider, string packageName)
    {
        return provider.GetPackagePrice(packageName);
    }

    public Provider GetCheapestPackageProvider(string packageName)
    {
        if (providers.Length == 0) throw new Exception("Error: No providers available");

        Provider? cheapestProvider = null;
        var minimumPackagePrice = int.MaxValue;

        foreach (var provider in providers)
        {
            var packagePrice = provider.GetPackagePrice(packageName);

            if (packagePrice == -1 || packagePrice >= minimumPackagePrice) continue;

            cheapestProvider = provider;
            minimumPackagePrice = packagePrice;
        }

        if (cheapestProvider == null) throw new Exception($"No provider offers the package '{packageName}'");

        return cheapestProvider;
    }
}