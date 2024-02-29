using Microsoft.EntityFrameworkCore;
using Stories.Infrastructure.Data;
using Stories.Services.DTOs;
using AccountEntity = Stories.Infrastructure.Models.Account;

namespace Stories.Services.Services.Account;

public class AccountService(ApplicationDataContext context) : IAccountService
{
    private readonly ApplicationDataContext _context = context;

    public async Task<Guid> Create(string name, string email)
    {
        if (string.IsNullOrEmpty(name) || string.IsNullOrEmpty(email))
            return Guid.Empty;

        var result = new AccountEntity { Name = name, Email = email };

        _context.Accounts.Add(result);

        if (await _context.SaveChangesAsync() == 0)
            return Guid.Empty;

        _context.SaveChanges();

        return result.Id;
    }

    public async Task<IEnumerable<AccountDTO>> GetAll()
    {
        return await _context.Accounts.Select(a => new AccountDTO { Id = a.Id, Name = a.Name, Email = a.Email }).ToListAsync();
    }
}
