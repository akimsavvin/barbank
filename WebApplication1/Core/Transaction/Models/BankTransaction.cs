using BarBank.Core.Account.Models;

namespace BarBank.Core.Transaction.Models;

public class BankTransaction
{
    public Guid Id { get; }
    public DateTime CreatedAt { get; }
    public int Amount { get; }
    public BankAccount? From { get; }
    public BankAccount? To { get; }

    public BankTransaction(Guid id, DateTime createdAt, int amount, BankAccount? from, BankAccount? to)
    {
        Id = id;
        CreatedAt = createdAt;
        Amount = amount;
        From  = from;
        To  = to;
    }
}
