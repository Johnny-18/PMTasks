using System;
using System.Threading;

namespace HW_6_Library.Services
{
    public class LoginClient
    {
        public string Login(string login, string password)
        {
            var randomIsLogin = new Random();
            var randomSleepTime = new Random();
            var isLogin = false;

            //this value make decision user login is valid or no
            double rdDouble = randomIsLogin.NextDouble();
            
            if (rdDouble < 0.5)
            {
                isLogin = true;
            }
            
            Thread.Sleep(randomSleepTime.Next(1000));

            return isLogin ? Guid.NewGuid().ToString() : null;
        }
    }
}