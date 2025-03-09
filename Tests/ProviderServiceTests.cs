using VintedAcademyBackendHomework.Services;

namespace Tests;

public class ProviderServiceTests
{
    private readonly ProviderService _providerService;

    public ProviderServiceTests()
    {
        var moqDataForTesting = new MoqDataForTesting();
        _providerService = moqDataForTesting.ProviderService;
    }

    [Fact]
    public void ProviderExists_ShouldReturnTrue_WhenProviderExists()
    {
        Assert.True(_providerService.ProviderExists("MR"));
        Assert.True(_providerService.ProviderExists("LP"));
    }

    [Fact]
    public void ProviderExists_ShouldReturnFalse_WhenProviderDoesNotExist()
    {
        Assert.False(_providerService.ProviderExists("Unknown"));
    }

    [Fact]
    public void PackageSizeExists_ShouldReturnTrue_WhenPackageExistsForProvider()
    {
        Assert.True(_providerService.PackageSizeExists("S", "MR"));
        Assert.True(_providerService.PackageSizeExists("M", "LP"));
    }

    [Fact]
    public void PackageSizeExists_ShouldReturnFalse_WhenPackageDoesNotExistForProvider()
    {
        Assert.False(_providerService.PackageSizeExists("XL", "MR"));
        Assert.False(_providerService.PackageSizeExists("XS", "LP"));
        Assert.False(_providerService.PackageSizeExists("S", "Unknown"));
    }

    [Fact]
    public void GetProvider_ShouldReturnProvider_WhenExists()
    {
        var provider = _providerService.GetProvider("LP");
        Assert.Equal("LP", provider.GetName());
    }

    [Fact]
    public void GetProvider_ShouldThrowException_WhenProviderDoesNotExist()
    {
        Assert.Throws<Exception>(() => _providerService.GetProvider("Unknown"));
    }

    [Fact]
    public void GetPackagePrice_ShouldReturnCorrectPrice_WhenPackageExists()
    {
        var provider = _providerService.GetProvider("LP");
        Assert.Equal(150, _providerService.GetPackagePrice(provider, "S"));
        Assert.Equal(490, _providerService.GetPackagePrice(provider, "M"));      
        Assert.Equal(690, _providerService.GetPackagePrice(provider, "L"));
    }

    [Fact]
    public void GetCheapestPackageProvider_ShouldReturnCheapestProvider_WhenMultipleExist()
    {
        var cheapestProvider = _providerService.GetCheapestPackageProvider("M");
        Assert.Equal("MR", cheapestProvider.GetName());
    }

    [Fact]
    public void GetCheapestPackageProvider_ShouldThrowException_WhenNoProvidersOfferPackage()
    {
        Assert.Throws<Exception>(() => _providerService.GetCheapestPackageProvider("XL"));
    }
}