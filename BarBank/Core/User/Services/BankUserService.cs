using BarBank.Core.User.Dto;
using BarBank.Core.User.Models;
using BarBank.Core.User.Storage;

namespace BarBank.Core.User.Services;

public class BankUserService : IBankUserService
{
    private readonly IBankUserRepository _bankUserRepository;

    public BankUserService(IBankUserRepository bankUserRepository)
    {
        _bankUserRepository = bankUserRepository;
    }

    public async Task<BankUser> GetOneByIdAsync(Guid id) 
    {        
        return await _bankUserRepository.GetOneByIdAsync(id);
    }

    public async Task<BankUser> GetOneByPhoneAsync(string phone)
    {
        return await _bankUserRepository.GetOneByPhoneAsync(phone);
    }

    public async Task<BankUser> CreateAsync(CreateBankUserDto createBankUserDto)
    {
        var bankUser = new BankUser(Guid.NewGuid(), 
            createBankUserDto.FirstName, 
            createBankUserDto.LastName, 
            createBankUserDto.MiddleName, 
            createBankUserDto.Phone, 
            createBankUserDto.Password);
        await _bankUserRepository.InsertAsync(bankUser);
        return bankUser;
    }
}