using VintedAcademyBackendHomework.Models;
using VintedAcademyBackendHomework.Services;

namespace VintedAcademyBackendHomework.Rules;

public interface IRuleService
{
    bool Validate(Transaction transaction, RuleContext context, IOutputService outputService);
}