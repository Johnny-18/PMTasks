using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using HW_6_Library.Models;
using HW_6_Library.Models.SettingsTask;
using HW_6_Library.Services;

namespace Task2
{
    public static class Program
    {
        private static string _settingsPath = "settings.json";
        private static string _resultPath = "result.json";
        
        public static async Task Main(string[] args)
        {
            var fileWorker = new FileWorker();
            var service = new PrimaryNumberService();
            var safeHashSet = new ThreadSafeHashSet();

            // values for file result.json
            string error = null;
            bool success = false;
            Stopwatch stopwatch = new Stopwatch();
            int[] primes = null;

            try
            {
                stopwatch.Start();

                var settings = await fileWorker.Deserialize<List<Setting>>(_settingsPath);
                if (settings == null || settings.Count == 0)
                {
                    success = true;
                    error = "";
                    primes = new int[0];
                }
                else
                {
                    // get values without null objects
                    settings = settings.Where(x => x != null).ToList();

                    //method create and start threads for work with settings
                    ThreadService.CreateThreadsForPrimes(settings, service, safeHashSet);
                    
                    primes = safeHashSet.GetPrimesArr();
                    success = true;
                }
            }
            catch (FileNotFoundException)
            {
                error = "File settings.json not found!";
                success = false;
            }
            catch (JsonException)
            {
                error = "Json file have incorrect data!";
                success = false;
            }
            catch (Exception e )
            {
                error = e.Message;
                success = false;
                primes = null;
            }
            finally
            {
                stopwatch.Stop();
            }
            
            var resultToFile = new Result()
            {
                Error = error,
                Duration = stopwatch.Elapsed.ToString(),
                Success = success,
                Primes = primes
            };

            fileWorker.Serialize(_resultPath, resultToFile);
        }
    }
}