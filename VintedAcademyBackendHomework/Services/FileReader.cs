using VintedAcademyBackendHomework.Utils;

namespace VintedAcademyBackendHomework.Services;

public static class FileReader
{
    private static bool CheckIfFileExists(string filePath)
    {
        return File.Exists(filePath);
    }

    public static void ReadFile(ITransactionService transactionService, string filePath, ITransactionRuleService ruleService, IOutputService outputService)
    {
        if (!CheckIfFileExists(filePath))
            throw new FileNotFoundException("File not found");

        try
        {
            using var reader = new StreamReader(filePath);
            ProcessLines(reader, transactionService, ruleService,outputService);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }

    private static void ProcessLines(StreamReader reader, ITransactionService transactionService, ITransactionRuleService ruleService, IOutputService outputService)
    {
        while (reader.ReadLine() is { } line)
        {
            var tempTransaction = transactionService.CreateTransaction(line);

            if (tempTransaction.IsFormatWrong())
                outputService.WriteLine($"{line} Ignored");
            else
                ruleService.ApplyRules(tempTransaction,outputService);
        }
    }

}