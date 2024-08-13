using CurrencyApi.Data;
using CurrencyApi.Models;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics.Metrics;

namespace CurrencyApi.Services.Repository
{
    public class CurrencyRepository : IRepository<Currency>
    {
        private readonly ApplicationDbContext _context;

        public CurrencyRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public bool AddInstance(Currency instance)
        {
            _context.Currencies.Add(instance);
            return Save();
        }

        public bool DeleteInstance(int id)
        {
            var oldCurrency = _context.Currencies.FirstOrDefault(c => c.Cur_ID == id);
            _context.Currencies.Remove(oldCurrency);
            return Save();
        }

        public async Task<IEnumerable<Currency>> GetAll()
        {
            return await _context.Currencies.ToListAsync();
        }

        public async Task<Currency> GetByIdAsync(int id)
        {
            return await _context.Currencies.FirstOrDefaultAsync(c => c.Cur_ID == id);
        }

        public bool Save()
        {
            return _context.SaveChanges() > 0;
        }

        public bool UpdateInstance(Currency instance)
        {
            throw new NotImplementedException();
        }
    }
}
