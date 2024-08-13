using CurrencyApi.Models;
using CurrencyApi.Services.ApiClients;
using Microsoft.EntityFrameworkCore;

namespace CurrencyApi.Data
{
    public class ApplicationDbContext: DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> dbContextOptions) : base(dbContextOptions) { }

        public DbSet<Currency> Currencies { get; set; }
        public DbSet<Rate> Rates { get; set; }
        public DbSet<RateShort> RateShorts { get; set; }

    }
}
