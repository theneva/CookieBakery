using System;
using System.Collections.Generic;
using CookieBakery;

namespace CookieBakery
{
    static class CookieBakery
    {
        // Fields
        private const int DailyQuota = 10;
        
        private static readonly List<Cookie> Cookies = new List<Cookie>();

        private static int cookiesSold;

        // Properties
        public static bool DailyQuotaNotBaked {
            get { return Cookies.Count < DailyQuota; }
        }

        public static bool DailyQuotaNotSold
        {
            get { return cookiesSold < DailyQuota; }
        }

        // Functions
        public static void AddCookie()
        {
            if (Cookies.Count >= DailyQuota) return;

            Cookies.Add(new Cookie());
            Console.WriteLine("Bakery made cookie #" + Cookies.Count);
        }

        public static void SellCookieTo(Person customer)
        {
            if (Cookies.Count <= cookiesSold) return;

            // Nuh-uh
            lock (Cookies[cookiesSold++])
            {
                Console.WriteLine("\t\t\t\t" + customer.Name + " received cookie #" + cookiesSold);
            }
        }

        // Most useless class ever
        class Cookie { }
    }
}
