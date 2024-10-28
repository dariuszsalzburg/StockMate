
using Microsoft.EntityFrameworkCore;
using StockMate.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockMate.EntityFramework
{
    public class StockMateDbContext : DbContext
    {
        public StockMateDbContext(DbContextOptions options) : base(options)
        {



        }

        public DbSet<User> Users { get; set; }

        public DbSet<Account> Accounts { get; set; }

        public DbSet<AssetTransaction> AssetTransactions { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AssetTransaction>().OwnsOne(a => a.Stock);





            base.OnModelCreating(modelBuilder);
        }
    }



}
