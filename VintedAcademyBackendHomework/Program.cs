using VintedAcademyBackendHomework.Data;
using VintedAcademyBackendHomework.Models;
using VintedAcademyBackendHomework.Rules;
using VintedAcademyBackendHomework.Services;

namespace VintedAcademyBackendHomework;

internal abstract class Program
{
    // Print everything to file or console
    private const bool SaveInFile = false;
    
    private static void Main(string[] args)
    {
        var providerService = new ProviderService(ProvidedData.Providers);
        var transactionService = new TransactionService(providerService);

        IOutputService outputService = SaveInFile? new FileOutputService("output.txt") : new ConsoleOutputService();
        
        if (args.Length == 0) throw new Exception("Error: no file name provided");
        
        var fundContext = new FundContext(1000);
        var ruleContext = new RuleContext(fundContext);
        var ruleService = new TransactionRuleService(ruleContext);

        ruleService.AddRule(new PackagePriceRule(providerService, "S"));
        ruleService.AddRule(new NShipmentRule(providerService, "L", "LP", 3));

        FileReader.ReadFile(transactionService, args[0], ruleService,outputService);
    }
}