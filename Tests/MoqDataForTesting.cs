using VintedAcademyBackendHomework.Models;
using VintedAcademyBackendHomework.Services;

namespace Tests;

public class MoqDataForTesting
{
    public MoqDataForTesting()
    {
        var mockProvider1 = new Provider(name:"MR", new Dictionary<string, int>{{"S", 200}, {"M", 300}, {"L", 400}});
        var mockProvider2 = new Provider(name:"LP", new Dictionary<string, int>{{"S", 150}, {"M", 490}, {"L", 690}});

        ProviderService = new ProviderService([mockProvider1, mockProvider2]);
    }
    
    public ProviderService ProviderService { get; set; }
}