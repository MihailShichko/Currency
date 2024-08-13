using CurrencyApi.Data;
using CurrencyApi.Models;
using Microsoft.EntityFrameworkCore;

namespace CurrencyApi.Services.Repository
{
    public class RateRepository : IRepository<Rate>
    {
        private readonly ApplicationDbContext _context;

        public RateRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public bool AddInstance(Rate instance)
        {
            _context.Rates.Add(instance);
            return Save();
        }

        public bool DeleteInstance(int id)
        {
            var oldRate = _context.Rates.FirstOrDefault(r => r.Cur_ID == id);
            _context.Rates.Remove(oldRate);
            return Save();
        }

        public async Task<IEnumerable<Rate>> GetAll()
        {
            return await _context.Rates.ToListAsync();
        }

        public async Task<Rate> GetByIdAsync(int id)
        {
            return await _context.Rates.FirstOrDefaultAsync(r => r.Cur_ID == id);

        }

        public bool Save()
        {
            return _context.SaveChanges() > 0;
        }

        public bool UpdateInstance(Rate instance)
        {
            throw new NotImplementedException();
        }
    }
}
