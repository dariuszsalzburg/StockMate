using Microsoft.EntityFrameworkCore;
using StockMate.Domain.Models;
using StockMate.Domain.Services;
using StockMate.EntityFramework.Services.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockMate.EntityFramework.Services
{
    public class AccountDataService : IAccountService     //AccountDataService to specjalna usługa dla obiektów Account. Dziedziczy po IAccountService i dostarcza dodatkowe metody pozwalające wyszukiwać konta po nazwie użytkownika lub adresie e-mail.
    {
        private readonly StockMateDbContextFactory _contextFactory;
        private readonly NonQueryDataService<Account> _nonQueryDataService;

        public AccountDataService(StockMateDbContextFactory contextFactory)
        {
            _contextFactory = contextFactory;
            _nonQueryDataService = new NonQueryDataService<Account>(contextFactory);
        }

        public async Task<Account> Create(Account entity)
        {
            return await _nonQueryDataService.Create(entity);
        }

        public async Task<bool> Delete(int id)
        {
            return await _nonQueryDataService.Delete(id);
        }

        public async Task<Account> Get(int id)
        {
            using (StockMateDbContext context = _contextFactory.CreateDbContext())
            {
                Account entity = await context.Accounts
                    .Include(a => a.AccountHolder)
                    .Include(a => a.AssetTransactions)
                    .FirstOrDefaultAsync((e) => e.Id == id);
                return entity;
            }
        }

        public async Task<IEnumerable<Account>> GetAll()
        {
            using (StockMateDbContext context = _contextFactory.CreateDbContext())
            {
                IEnumerable<Account> entities = await context.Accounts
                    .Include(a => a.AccountHolder)
                    .Include(a => a.AssetTransactions)
                    .ToListAsync();
                return entities;
            }
        }

        public async Task<Account> GetByEmail(string email)
        {
            using (StockMateDbContext context = _contextFactory.CreateDbContext())
            {
                return await context.Accounts
                    .Include(a => a.AccountHolder)
                    .Include(a => a.AssetTransactions)
                    .FirstOrDefaultAsync(a => a.AccountHolder.Email == email);
            }
        }

        public async Task<Account> GetByUsername(string username)
        {
            using (StockMateDbContext context = _contextFactory.CreateDbContext())
            {
                return await context.Accounts
                    .Include(a => a.AccountHolder)
                    .Include(a => a.AssetTransactions)
                    .FirstOrDefaultAsync(a => a.AccountHolder.Username == username);
            }
        }

        public async Task<Account> Update(int id, Account entity)
        {
            return await _nonQueryDataService.Update(id, entity);
        }
    }
}
