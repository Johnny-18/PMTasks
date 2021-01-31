using System.Collections.Generic;
using System.Threading;
using HW_6_Library.Models;

namespace HW_6_Library.Services
{
    public static class ThreadService
    {
        public static void CreateThreads(List<Settings> settings, 
            PrimaryNumberService service, 
            ThreadSafeHashSet safeHashSet,
            CountdownEvent countObject) 
        {
            foreach (var setting in settings)
            {
                var thread = new Thread(() =>
                {
                    var result = service.GetPrimes(setting.PrimesFrom, setting.PrimesTo);

                    if (result != null)
                        safeHashSet.Add(result);

                    countObject.Signal();
                });

                thread.Start();
            }
        }
    }
}