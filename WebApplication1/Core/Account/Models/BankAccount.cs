using BarBank.Core.Account.Exceptions;
using BarBank.Core.Transaction.Models;

namespace BarBank.Core.Account.Models;

public class BankAccount
{
    public Guid Id { get; }
    public int Balance { get; private set; }

    public BankAccount(Guid id, int balance) 
    {
        Id = id;
        Balance = balance;            
    }

    public BankTransaction Withdraw(int amount) 
    {
        if (amount > Balance) 
        {
            throw new NotEnoughMoneyException("Недостаточно средств на балансе");
        }

        Balance -= amount;
        return new BankTransaction(Guid.NewGuid(), DateTime.Now, amount, this, null);
    }

    public BankTransaction Replenish(int amount)
    {
        Balance += amount;
        return new BankTransaction(Guid.NewGuid(), DateTime.Now, amount, null, this);
    }

    public BankTransaction Transfer(int amount, BankAccount toAccount) 
    {
        Withdraw(amount);
        toAccount.Replenish(amount);

        return new BankTransaction(Guid.NewGuid(), DateTime.Now, amount, this, toAccount);
    }
}
