using System;
using System.Linq;

namespace Library.Services
{
    public class ServiceForArray
    {
        public int MinElement(int[] arr)
        {
            return arr.Min();
        }
        
        public int MaxElement(int[] arr)
        {
            return arr.Max();
        }

        public int SumElements(int[] arr)
        {
            return arr.Sum();
        }

        public double AvgElement(int[] arr)
        {
            return Math.Round(arr.Average(), 2);
        }

        public double StandardDeviation(int[] arr)
        {
            var avg = AvgElement(arr);
            double res = 0;
            foreach (var number in arr)
            {
                res += Math.Pow((number - avg), 2);
            }
            
            return Math.Round(res/arr.Length);
        }

        public void SortElements(ref int[] arr)
        {
            Array.Sort(arr);
        }
    }
}