using System;
using System.Collections.Generic;
using System.Text;

namespace Telephony
{
    public class Smartphone : ICalling, IBrowsing
    {
        public void Calling(string phoneNumber)
        {
            Console.WriteLine($"Calling... {phoneNumber}");
        }

        public void Browsing(string url)
        {
            Console.WriteLine($"Browsing: {url}!");
        }
    }
}
