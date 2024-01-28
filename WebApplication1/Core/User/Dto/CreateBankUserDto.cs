namespace BarBank.Core.User.Dto;

public class CreateBankUserDto
{
    public string FirstName { get; }
    public string LastName { get; }
    public string MiddleName { get; }
    public string Phone { get; }
    public string Password { get; }

    public CreateBankUserDto(string firstName, string lastName, string middleName, string phone, string password)
    {
        FirstName = firstName;
        LastName = lastName;
        MiddleName = middleName;
        Phone = phone;
        Password = password;
    }
}
