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

        protected override async void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            var client = new NbrbApi();

            Currency[] currencyArray = await client.GetDataAsync<Currency[]>("currencies");
            modelBuilder.Entity<Currency>().HasData(currencyArray);

            Rate[] rateArray = await client.GetDataAsync<Rate[]>("rates");
            modelBuilder.Entity<Rate>().HasData(rateArray);

            RateShort[] rateShortArray = await client.GetDataAsync<RateShort[]>("rates/dynamics");
            modelBuilder.Entity<RateShort>().HasData(rateShortArray);
        }
    }
}
