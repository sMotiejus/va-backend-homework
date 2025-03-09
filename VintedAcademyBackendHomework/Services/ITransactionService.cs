using VintedAcademyBackendHomework.Models;

namespace VintedAcademyBackendHomework.Services;

public interface ITransactionService
{
    public Transaction CreateTransaction(string dataLine);
}