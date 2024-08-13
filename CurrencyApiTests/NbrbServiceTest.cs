using CurrencyApi.Models;
using CurrencyApi.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CurrencyApiTests
{
    public class NbrbServiceTest
    {
        [Fact]
        public async Task GetCompleteListOfCurrencies_ReturnCurrencyArray()
        {
            //Arrange
            var nbrbService = new NbrbService();
            
            //Act
            var currencies = await nbrbService.GetCompleteListOfCurrencies();

            //Assert
            Assert.NotNull(currencies);
            Assert.IsAssignableFrom<Currency[]>(currencies);
            Assert.True(currencies.Length > 0);
        }

        [Fact]
        public async Task GetCurrency_ShouldReturnCurrencyById()
        {
            // Arrange
            var nbrbService = new NbrbService();
            int currencyId = 145; 

            // Act
            var currency = await nbrbService.GetCurrency(currencyId);

            // Assert
            Assert.NotNull(currency);
            Assert.Equal(currencyId, currency.Cur_ID);
        }

        [Fact]
        public async Task GetRates_ShouldReturnRateArray()
        {
            // Arrange
            var nbrbService = new NbrbService();
            DateTime ondate = new DateTime(2023, 8, 1);
            int periodicity = 0;
            int parammode = 0;

            // Act
            var rates = await nbrbService.GetRates(ondate, periodicity, parammode);

            // Assert
            Assert.NotNull(rates);
            Assert.IsAssignableFrom<Rate[]>(rates);
            Assert.True(rates.Length > 0);
        }

        [Fact]
        public async Task GetRate_ShouldReturnRateById()
        {
            // Arrange
            var nbrbService = new NbrbService();
            string currencyId = "USD";
            DateTime ondate = new DateTime(2023, 8, 1);
            int periodicity = 0;
            int parammode = 2;

            // Act
            var rate = await nbrbService.GetRate(currencyId, ondate, periodicity, parammode);

            // Assert
            Assert.NotNull(rate);
            Assert.Equal(currencyId, rate.Cur_Abbreviation);
        }
    }
}
