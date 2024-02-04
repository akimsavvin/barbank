namespace BarBank.Core.Account.Exceptions;

public class NotEnoughMoneyException : Exception
{
    public NotEnoughMoneyException(string message) : base(message)
    {
    }
}