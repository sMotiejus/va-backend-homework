using VintedAcademyBackendHomework.Models;
using VintedAcademyBackendHomework.Rules;

namespace VintedAcademyBackendHomework.Services;

public class TransactionRuleService(RuleContext ruleContext) : ITransactionRuleService
{
    private readonly List<IRuleService> _rules = [];

    public void AddRule(IRuleService rule)
    {
        _rules.Add(rule);
    }

    public bool ApplyRules(Transaction transaction, IOutputService outputService)
    {
        ruleContext.AddTransaction(transaction);

        if (_rules.Any(rule => rule.Validate(transaction, ruleContext,outputService))) return true;

        outputService.WriteLine(transaction.ToString());
        return false;
    }
}