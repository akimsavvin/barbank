namespace BarBank.Core.Auth.Exceptions;

public class InvalidPasswordException : Exception
{
    public InvalidPasswordException() : base("Неправильный пароль!")
    {
    }
}