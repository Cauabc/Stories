using Stories.Services.DTOs;

namespace Stories.Services.Services.Account;

public interface IAccountService
{
    IEnumerable<AccountDTO> GetAll();
}
