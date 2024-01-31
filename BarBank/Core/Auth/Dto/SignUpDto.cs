namespace BarBank.Core.Auth.Dto;

public class SignUpDto
{
    public string Phone { get; }
    public string Password { get; }
    public string PasswordConfirm { get; }
    public string FirstName { get; }
    public string LastName { get; }
    public string MiddleName { get; }
}
