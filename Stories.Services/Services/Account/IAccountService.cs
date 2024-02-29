using Stories.Services.DTOs;

namespace Stories.Services.Services.Account;

public interface IAccountService
{
    Task<IEnumerable<AccountDTO>> GetAll();
    Task<Guid> Create(string name, string email);
}
