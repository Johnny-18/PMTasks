using System;
using System.Collections.Generic;
using System.Diagnostics;
using Library.Models;

namespace Library.Services
{
    public class PrimesNumberService
    {
        private readonly ResultService _resultService;
        
        private readonly SettingsService _settingsService;

        public PrimesNumberService()
        {
            _resultService = new ResultService();
            _settingsService = new SettingsService();
        }

        public void SearchPrimes()
        {
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            
            Settings settings;
            try
            {
                settings = _settingsService.GetSettings();
            }
            catch (Exception e)
            {
                stopwatch.Stop();
                _resultService.AddToFile(new Result(false, e.Message, stopwatch.Elapsed.ToString(), null));
                return;
            }

            if (settings == null)
            {
                stopwatch.Stop();
                _resultService.AddToFile(new Result(false, null, stopwatch.Elapsed.ToString(), null));
                
                return;
            }

            if (settings.PrimesFrom < 0 || settings.PrimesTo < 0 && settings.PrimesFrom > settings.PrimesTo)
            {
                stopwatch.Stop();
                _resultService.AddToFile(new Result(false, null, stopwatch.Elapsed.ToString(), new int[0]));
                
                return;
            }

            var list = new List<int>();
            for (int i = settings.PrimesFrom; i < settings.PrimesTo; i++)
            {
                if (IsPrime(i) && i >= 2)
                {
                    list.Add(i);
                }
            }
            
            stopwatch.Stop();
            _resultService.AddToFile(new Result(true, null, stopwatch.Elapsed.ToString(), list.ToArray()));
        }

        private bool IsPrime(int value)
        {
            for (int i = 2; i < Math.Sqrt(value) + 1; i++)
            {
                if (value % i == 0)
                {
                    return false;
                }
            }

            return true;
        }
    }
}