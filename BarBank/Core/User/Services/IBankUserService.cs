using BarBank.Core.User.Models;
using BarBank.Core.User.Dto;

namespace BarBank.Core.User.Services;

public interface IBankUserService
{
    public Task<BankUser> GetOneByIdAsync(Guid id);
    public Task<BankUser> GetOneByPhoneAsync(string phone);
    public Task<BankUser> CreateAsync(CreateBankUserDto createBankUserDto);
}