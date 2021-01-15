using System;
using System.Collections.Generic;
using System.Linq;
using Library.Models;

namespace Library.Services
{
    public class ConverterService
    {
        private readonly CacheService _cacheService;

        public ConverterService()
        {
            _cacheService = new CacheService("cache.json");
        }
        
        public void Convert(string fromCurrency, string toCurrency, decimal amount)
        {
            try
            {
                _cacheService.SetCaches("https://bank.gov.ua/NBUStatService/v1/statdirectory/exchange?json");
            }
            catch
            {
                Console.WriteLine("Update currency not possible now, come later!");
                return;
            }

            var caches = _cacheService.GetCaches();

            var toCurCache = caches.FirstOrDefault(x => x.Сc.ToLower() == fromCurrency.ToLower());
            var fromCurCache = caches.FirstOrDefault(x => x.Сc.ToLower() == toCurrency.ToLower());
            
            if (toCurCache != null && fromCurCache != null)
            {
                var rate = fromCurCache.Rate / toCurCache.Rate;
                var newAmount = Math.Round(amount * rate, 2);
                Console.WriteLine($"{Math.Round(amount, 2)} {fromCurrency} x {Math.Round(rate, 2)} = {newAmount} {toCurrency} (from {toCurCache.Exchangedate})");
            }

            Console.WriteLine("Our base don't have one of this currency!");
        }
    }
}