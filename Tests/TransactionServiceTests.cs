using VintedAcademyBackendHomework.Models;
using VintedAcademyBackendHomework.Services;

namespace Tests;

using Moq;

public class TransactionServiceTests
{
    private readonly TransactionService _transactionService;
    private readonly Mock<IProviderService> _mockProviderService;

    public TransactionServiceTests()
    {
        _mockProviderService = new Mock<IProviderService>();
        _transactionService = new TransactionService(_mockProviderService.Object);
    }

    [Theory]
    [InlineData("2025-03-09 SIZE PROVIDER", "2025-03-09", "SIZE", "PROVIDER", 0, false)]  
    [InlineData("InvalidDate SIZE PROVIDER", "0001-1-1", "SIZE", "PROVIDER", 0, true)]
    [InlineData("2025-03-09 InvalidSize PROVIDER", "2025-03-09", "", "PROVIDER", 0, true)]
    [InlineData("2025-03-09 SizeDoesntMatter InvalidProvider", "2025-03-09", "", "", 0, true)]  
    public void CreateTransaction_ShouldReturnExpectedResult(string dataLine, string expectedDate, string expectedSize, string expectedProvider, double expectedPrice, bool expectedInvalid)
    {
        _mockProviderService.Setup(p =>
            p.ProviderExists(It.IsAny<string>())).Returns((string provider) => provider is "PROVIDER");
        
        _mockProviderService.Setup(p =>
            p.PackageSizeExists(It.IsAny<string>(), It.IsAny<string>()))
            .Returns((string size, string provider) => provider == "PROVIDER" && size is "SIZE");
        
        var transaction = _transactionService.CreateTransaction(dataLine);

        if (DateOnly.TryParse(expectedDate, out var parsedDate))
        {
            Assert.Equal(parsedDate, transaction.GetDate());
        }
        Assert.Equal(expectedSize, transaction.GetPackageSize());
        Assert.Equal(expectedProvider, transaction.GetProvider());
        Assert.Equal(expectedPrice, transaction.GetPrice());
        Assert.Equal(expectedInvalid, transaction.IsFormatWrong());
    }
}
