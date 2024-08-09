using CurrencyApi.DTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CurrencyApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CurrencyController : ControllerBase
    {
        [HttpGet("{id}")]
        public Task<ActionResult<CurrencyDTO>> GetExchageRate(DateTime date) 
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
