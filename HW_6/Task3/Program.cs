using System;
using System.IO;
using System.Threading.Tasks;
using HW_6_Library.Models.LoginTask;
using HW_6_Library.Services;

namespace Task3
{
    public static class Program
    {
        private static readonly string _loginsPath = "logins.csv";
        private static readonly string _resultPath = "result.json";

        private static void Main()
        {
            Console.WriteLine("Service for gets unique logins.");
            Console.WriteLine("Program created by Ivan Zherybor.");
            
            var fileWorker = new FileWorker();
            int threads;

            while (true)
            {
                Console.WriteLine("Enter how many thread will be work:");
                var input = Console.ReadLine();

                if (int.TryParse(input, out threads))
                {
                    break;
                }

                Console.WriteLine("Enter correct number!");
            }

            try
            {
                var storage = fileWorker.CsvParser(_loginsPath);

                // created threads and do some work
                ThreadService.CreateThreadsForLogins(threads, new LoginClient(), storage);

                //successful logins
                var countSuc = ThreadService.CountSuc;

                //failed logins
                var countFail = ThreadService.CountFail;

                var result = new Result
                {
                    Failed = countFail,
                    Successful = countSuc
                };
                
                fileWorker.Serialize(_resultPath, result);

                Console.WriteLine($"Successful login: {countSuc}, failed: {countFail}.");
            }
            catch (FileNotFoundException)
            {
                Console.WriteLine("File not found!");
            }
            catch (Exception)
            {
                Console.WriteLine("Something going wrong!");
            }
        }
    }
}