using Stories.Infrastructure.Data;
using Stories.Services.DTOs;
using AccountEntity = Stories.Infrastructure.Models.Account;

namespace Stories.Services.Services.Account;

public class AccountService(ApplicationDataContext context) : IAccountService
{
    private readonly ApplicationDataContext _context = context;

    public Guid Create(string name, string email)
    {
        var result = new AccountEntity { Name = name, Email = email };

        _context.Accounts.Add(result);

        if (_context.SaveChanges() == 0)
            return Guid.Empty;

        _context.SaveChanges();

        return result.Id;
    }

    public IEnumerable<AccountDTO> GetAll()
    {
        return _context.Accounts.Select(a => new AccountDTO { Id = a.Id, Name = a.Name, Email = a.Email }).ToList();
    }
}
