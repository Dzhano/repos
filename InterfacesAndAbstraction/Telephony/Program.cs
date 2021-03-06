using System;

namespace Telephony
{
    class Program
    {
        static void Main(string[] args)
        {
            Smartphone smartphone = new Smartphone();
            StationaryPhone stationaryPhone = new StationaryPhone();

            string[] phoneNumbers = Console.ReadLine().Split();
            string[] urls = Console.ReadLine().Split();

            foreach (string phoneNumber in phoneNumbers)
            {
                bool invalid = false;
                foreach (char digit in phoneNumber)
                    if (char.IsLetter(digit))
                    {
                        Console.WriteLine("Invalid number!");
                        invalid = true;
                        break;
                    }
                if (invalid) continue;
                if (phoneNumber.Length == 7) stationaryPhone.Calling(phoneNumber);
                else if (phoneNumber.Length == 10) smartphone.Calling(phoneNumber);
            }
            foreach (string url in urls)
            {
                bool invalid = false;
                foreach (char item in url)
                    if (char.IsDigit(item))
                    {
                        Console.WriteLine("Invalid URL!");
                        invalid = true;
                        break;
                    }
                if (invalid) continue;
                smartphone.Browsing(url);
            }
        }
    }
}
