using CurrencyApi.Models;
using CurrencyApi.Services.ApiClients;

namespace CurrencyApi.Services
{
    public class NbrbService
    {
        private readonly NbrbApi _nbrbApi;

        public NbrbService()
        {
            _nbrbApi = new NbrbApi();
        }

        /// <summary>
        /// A complete list of foreign currencies in relation to which the National Bank
        /// sets the official exchange rate of the Belarusian ruble.
        /// (/currencies endpoint).
        /// </summary>
        /// <returns>Currency array</returns>
        public async Task<Currency[]> GetCompleteListOfCurrencies()
        {
            var currencies = await _nbrbApi.GetDataAsync<Currency[]>("/rates");
            return currencies;
        }

        /// <summary>
        /// Foreign currency in relation to which the National Bank sets the official exchange rate
        /// of the Belarusian ruble.
        /// (/currencies[/{cur_id}] endpoint)
        /// </summary>
        /// <param name="id">Currency ID</param>
        /// <returns>Currency by id</returns>
        public async Task<Currency> GetCurrency(int id)
        {
            var currency = await _nbrbApi.GetDataAsync<Currency>("/rates", id);
            return currency;
        }

        /// <summary>
        /// The official exchange rate of the Belarusian ruble against foreign currencies,
        /// established by the National Bank for a specific date.
        /// (/rates endpint)
        /// </summary>
        /// <param name="ondate">date for which the course is requested</param>
        /// <param name="periodicity">rate setting frequency (0 – daily, 1 – monthly)</param>
        /// <param name="parammode">cur_id argument format: 0 – internal currency code,
        /// 1 – three-digit digital currency code in accordance with the ISO 4217 standard,
        /// 2 – three-digit alphabetic currency code (ISO 4217)</param>
        /// <returns>Rate array</returns>
        public async Task<Rate[]> GetRates(DateTime ondate, int periodicity = 1, int parammode = 0)
        {
            string endpoint = "/rates";
            string[] parameters =
            {
                $"ondate={ondate.ToString()}",
                $"periodicity={periodicity.ToString()}",
                $"parammode={parammode.ToString()}"
            };

            var rates = await _nbrbApi.GetDataAsync<Rate[]>(endpoint, parameters);
            return rates;
        }

        /// <summary>
        /// The official exchange rate of the Belarusian ruble against foreign currency by id.
        /// (/rates[/{cur_id} endpoint)
        /// </summary>
        /// <param name="id">Currency id </param>
        /// <param name="ondate">date for which the course is requested</param>
        /// <param name="periodicity">rate setting frequency (0 – daily, 1 – monthly)</param>
        /// <param name="parammode">cur_id argument format: 0 – internal currency code,
        /// 1 – three-digit digital currency code in accordance with the ISO 4217 standard,
        /// 2 – three-digit alphabetic currency code (ISO 4217)</param>
        /// <returns></returns>
        public async Task<Rate> GetRate(string id, DateTime ondate, int periodicity = 1, int parammode = 0)
        {
            string endpoint = "/rates";
            string[] parameters =
            {
                $"ondate={ondate.ToString()}",
                $"periodicity={periodicity.ToString()}",
                $"parammode={parammode.ToString()}"
            };

            var rate = await _nbrbApi.GetDataAsync<Rate>(endpoint, id, parameters);
            return rate;
        }
    }

}
