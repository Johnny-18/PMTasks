using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Threading;
using HW_6_Library.Models.LoginTask;
using HW_6_Library.Models.SettingsTask;

namespace HW_6_Library.Services
{
    public static class ThreadService
    {
        public static int CountFail = 0;
        public static int CountSuc = 0;
        
        public static void CreateThreadsForPrimes(List<Setting> settings, 
            PrimaryNumberService service, 
            ThreadSafeHashSet safeHashSet) 
        {
            var countObject = new CountdownEvent(settings.Count);

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

            countObject.Wait();
        }

        public static void CreateThreadsForLogins(int threads, LoginClient client, ConcurrentQueue<Login> storage)
        {
            var countObject = new CountdownEvent(threads);

            for (int i = 0; i < threads; i++)
            {
                var thread = new Thread(() =>
                {
                    while (storage.TryDequeue(out var login))
                    {
                        if (client.Login(login.LoginValue, login.Password) != null)
                        {
                            Interlocked.Increment(ref CountSuc);
                        }
                        else
                        {
                            Interlocked.Increment(ref CountFail);
                        }
                    }

                    countObject.Signal();
                });
                
                thread.Start();
            }

            countObject.Wait();
        }
    }
}