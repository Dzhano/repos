using System;
using System.Collections.Generic;

namespace SoftUniParty
{
    class Program
    {
        static void Main(string[] args)
        {
            HashSet<string> guests = new HashSet<string>();
            HashSet<string> VIPguests = new HashSet<string>();
            string input = string.Empty;
            while ((input = Console.ReadLine()) != "PARTY")
            {
                switch (input[0])
                {
                    case '0':
                    case '1':
                    case '5':
                    case '2':
                    case '3':
                    case '4':
                    case '6':
                    case '7':
                    case '8':
                    case '9':
                        VIPguests.Add(input);
                        break;
                    default:
                        guests.Add(input);
                        break;
                }
            }
            string person = string.Empty;
            while ((person = Console.ReadLine()) != "END")
            {
                guests.Remove(person);
                VIPguests.Remove(person);
            }
            Console.WriteLine(VIPguests.Count + guests.Count);
            if (VIPguests.Count > 0) Console.WriteLine(string.Join(Environment.NewLine, VIPguests));
            if (guests.Count > 0) Console.WriteLine(string.Join(Environment.NewLine, guests));
        }
    }
}
