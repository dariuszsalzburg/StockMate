
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using StockMate.Domain.Models;
using StockMate.Domain.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockMate.EntityFramework.Services
{
    public class GenericDataService<T> : IDataService<T> where T : DomainObject              //GenericDataService to generyczna(pozwala na prace z dowolnym typem danych w ramach jedbej definicji klasy) implementacja interfejsu IDataService<T>, pozwalająca na uniwersalne operacje CRUD na dowolnym typie DomainObject.
    {
        private readonly StockMateDbContextFactory _contextFactory;

        public GenericDataService(StockMateDbContextFactory contextFactory)
        {
            _contextFactory = contextFactory;
        }

        public async Task<T> Create(T entity)
        {
            using (StockMateDbContext context = _contextFactory.CreateDbContext())
            {
                EntityEntry<T> newEntity = await context.Set<T>().AddAsync(entity);
                await context.SaveChangesAsync();
                return newEntity.Entity;
            }
        }

        public async Task<bool> Delete(int id)
        {
            using (StockMateDbContext context = _contextFactory.CreateDbContext())
            {
                T entity = await context.Set<T>().FirstOrDefaultAsync((e) => e.Id == id);
                context.Set<T>().Remove(entity);
                await context.SaveChangesAsync();
                return true;
            }
        }

 

        public async Task<IEnumerable<T>> GetAll()
        {
            using (StockMateDbContext context = _contextFactory.CreateDbContext())
            {
                IEnumerable<T> entities = await context.Set<T>().ToListAsync();

                return entities;
            }
        }



        public async Task<T> Get(int id)
        {
            using (StockMateDbContext context = _contextFactory.CreateDbContext())
            {
                T entity = await context.Set<T>().FirstOrDefaultAsync((e) => e.Id == id);

                return entity;
            }
        }

        public async Task<T> Update(int id, T entity)
        {
            using (StockMateDbContext context = _contextFactory.CreateDbContext())
            {
                entity.Id = id;
                context.Set<T>().Update(entity);

                return entity;
            }
        }
    }
}
