using VintedAcademyBackendHomework.Models;

namespace VintedAcademyBackendHomework.Services;

public interface IProviderService
{
    bool ProviderExists(string providerName);
    bool PackageSizeExists(string packageSize, string providerName);

    Provider GetProvider(string providerName);
    int GetPackagePrice(Provider provider, string packageName);
    Provider GetCheapestPackageProvider(string packageName);
}