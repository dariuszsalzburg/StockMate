using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Options;
using System;

namespace StockMate.EntityFramework
{
    public class StockMateDbContextFactory : IDesignTimeDbContextFactory<StockMateDbContext>     //Klasa StockMateDbContextFactory jest odpowiedzialna za tworzenie instancji StockMateDbContext.
    {
        public StockMateDbContext CreateDbContext(string[] args = null)
        {
            var optionsBuilder = new DbContextOptionsBuilder<StockMateDbContext>();
            optionsBuilder.UseSqlServer("Server=DariuszSalzburg\\SQLEXPRESS; Database=StockMate;TrustServerCertificate=True; Integrated Security=True;");
            return new StockMateDbContext(optionsBuilder.Options);
        }


    }
}