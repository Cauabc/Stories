using Stories.Services.DTOs;

namespace Stories.Services.Services.Account;

public interface IAccountService
{
    IEnumerable<AccountDTO> GetAll();
    Guid Create(string name, string email);
}
