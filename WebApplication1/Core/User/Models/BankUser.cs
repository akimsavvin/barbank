using System.Text.RegularExpressions;

namespace BarBank.Core.User.Models;

public class BankUser
{
    public Guid Id { get; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string MiddleName { get; set; }
    private string _phone;
    public string Password { get; }

    public BankUser(Guid id, string firstName, string lastName, string middleName, string phone, string password) 
    {
        Id = id;
        FirstName = firstName;
        LastName = lastName;
        MiddleName = middleName;
        _phone = phone;
        Password = password;
    }

    public string Phone 
    {
        get 
        {
            return _phone;
        }
        set 
        {
            var pattern = @"^\+?(\d{1,4})?[-. ]?\(?\d{1,4}\)?[-. ]?\d{1,10}$";
            var regex = new Regex(pattern);
            var isValid = regex.Match(value).Success;

            if (!isValid)
            {
                throw new ArgumentException("Invalid number"); 
            }

            _phone = value;
        }
    }
}
