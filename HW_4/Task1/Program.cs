using System;
using System.Diagnostics;
using System.IO;
using System.Threading;
using Library.Services;

namespace Task1
{
    class Program
    {
        static void Main(string[] args)
        {
            PrimesNumberService service = new PrimesNumberService();
            service.SearchPrimes();
        }
    }
}