using Microsoft.EntityFrameworkCore;
using Stories.Infrastructure.Data;
using Stories.Services.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stories.Services.Services.Account
{
    public class AccountService(ApplicationDataContext context) : IAccountService
    {
        private readonly ApplicationDataContext _context = context;

        public IEnumerable<AccountDTO> GetAll()
        {
            return _context.Accounts.Select(a => new AccountDTO { Id = a.Id, Name = a.Name, Email = a.Email }).ToList();
        }
    }
}
