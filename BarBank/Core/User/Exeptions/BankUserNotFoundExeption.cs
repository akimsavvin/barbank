namespace BarBank.Core.User.Exeptions;

public class BankUserNotFoundExeption : Exception
{
    public BankUserNotFoundExeption() : base("Пользователь не найден сука")
    {

    }
}
