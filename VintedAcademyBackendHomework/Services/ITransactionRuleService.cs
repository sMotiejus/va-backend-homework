using VintedAcademyBackendHomework.Models;
using VintedAcademyBackendHomework.Rules;

namespace VintedAcademyBackendHomework.Services;

public interface ITransactionRuleService
{
    void AddRule(IRuleService rule);
    bool ApplyRules(Transaction transaction, IOutputService outputService);
}