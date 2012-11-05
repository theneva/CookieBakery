using System;
using System.Diagnostics;
using System.Threading;

/*
 * "The Cookie Bakery" er et lite bakeri med tre faste stamkunder: De glupske herrene Fred, Ted og Greg.
 * 
 * The Cookie Bakery lager kun cookies (of course), og selv om produksjonen kan være nokså lav
 * (minimum et dusin cookies om dagen, utover det velger dere selv) hindrer ikke det Fred,
 * Ted og Greg fra å storme mot disken javnt og trutt, i håp om å være førstemann til å stå der
 * akkurat i det en ny, fersk kake kommer ut av ovnen! Men uansett hvor samtidig herrene kaster
 * seg mot disken, er det jo bare én som kan få tak i hver kake! Ikke sant?
 */

namespace CookieBakery
{
    class Program
    {
        // As defined by the assignment
        public static int BakingTimeMilliseconds = 667;
        public static int BuyingTimeMilliseconds = 1000;

        static void Main(string[] args)
        {
            // Begin the day; Not going to use these for anything.
            new Thread(BakeCookies).Start();
            new Thread(GrabFred).Start();
            new Thread(GrabTed).Start();
            new Thread(GrabGreg).Start();

            // Prevent the console from closing using main thread
            while (true)
            {
                if (CookieBakery.DailyQuotaNotSold) continue;
                
                Console.ReadKey();
                break;
            }
        }
        
        private static void BakeCookies()
        {
            var stopwatch = new Stopwatch();
            stopwatch.Start();

            while (CookieBakery.DailyQuotaNotBaked)
            {
                if (stopwatch.ElapsedMilliseconds < BakingTimeMilliseconds) continue;

                CookieBakery.AddCookie();
                stopwatch.Restart();
            }
        }

        private static void GrabFred()
        {
            var fred = new Person("Fred");
            var stopwatch = new Stopwatch();
            stopwatch.Start();

            while (CookieBakery.DailyQuotaNotSold)
            {
                if (stopwatch.ElapsedMilliseconds < BuyingTimeMilliseconds) continue;

                CookieBakery.SellCookieTo(fred);
                stopwatch.Restart();
            }
        }

        private static void GrabTed()
        {
            var ted = new Person("Ted");
            var stopwatch = new Stopwatch();
            stopwatch.Start();

            while (CookieBakery.DailyQuotaNotSold)
            {
                if (stopwatch.ElapsedMilliseconds < BuyingTimeMilliseconds) continue;

                CookieBakery.SellCookieTo(ted);
                stopwatch.Restart();
            }
        }

        private static void GrabGreg()
        {
            var greg = new Person("Greg");

            var stopwatch = new Stopwatch();
            stopwatch.Start();

            while (CookieBakery.DailyQuotaNotSold)
            {
                if (stopwatch.ElapsedMilliseconds < BuyingTimeMilliseconds) continue;

                CookieBakery.SellCookieTo(greg);
                stopwatch.Restart();
            }
        }
    }
}
