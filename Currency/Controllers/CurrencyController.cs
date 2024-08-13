using CurrencyApi.Data;
using CurrencyApi.DTOs;
using CurrencyApi.Models;
using CurrencyApi.Services.ApiClients;
using CurrencyApi.Services.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CurrencyApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CurrencyController : ControllerBase
    {
        private readonly CurrencyRepository _currencyRepository;

        private readonly RateRepository _rateRepository;

        public CurrencyController(IRepository<Currency> currencyRepository,
            IRepository<Rate> rateRepository)
        {
            _currencyRepository = (CurrencyRepository)currencyRepository;
            _rateRepository = (RateRepository)rateRepository;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Currency>>> GetAll()
        {
            var currencies = await _currencyRepository.GetAll();
            return currencies.ToList();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Rate>> GetExchageRate(DateTime date, int id) 
        {
            throw new NotImplementedException();
        }

        [HttpGet]
        [Route("IsCorrectDate")]
        public Task<ActionResult<CorretDateDTO>> IsCorrectDate(DateTime date) 
        {
            throw new NotImplementedException();
        }
    }
}
