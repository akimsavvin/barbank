namespace BarBank.Core.Auth.Exceptions;

public class PasswordsMismatchException : Exception
{
    public PasswordsMismatchException() : base("Пароли не совпадают")
    {
    }
}