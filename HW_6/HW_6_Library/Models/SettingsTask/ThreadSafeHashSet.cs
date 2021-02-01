using System;
using System.Collections.Generic;
using System.Linq;

namespace HW_6_Library.Models.SettingsTask
{
    public class ThreadSafeHashSet
    {
        private readonly HashSet<int> _primeValues;
        private readonly Object _marker;

        public ThreadSafeHashSet()
        {
            _marker = new Object();
            _primeValues = new HashSet<int>();
        }

        public void Add(HashSet<int> primes)
        {
            lock (_marker)
            {
                foreach (var prime in primes)
                {
                    if (!_primeValues.Contains(prime))
                    {
                        _primeValues.Add(prime);
                    }
                }
            }
        }

        public int[] GetPrimesArr()
        {
            lock (_marker)
            {
                if (_primeValues.Count == 0)
                    return null;
                
                return _primeValues?.ToArray();
            }
        }
    }
}