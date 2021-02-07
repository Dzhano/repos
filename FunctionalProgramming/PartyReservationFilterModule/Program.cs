using System;
using System.Collections.Generic;
using System.Linq;

namespace PartyReservationFilterModule
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> guests = Console.ReadLine().Split().ToList();
            HashSet<Predicate<string>> filters 
                = new HashSet<Predicate<string>>();
            /*  The following PRFM commands are: 
                •   "Add filter"
                •	"Remove filter"
                •	"Print" 
                The possible PRFM filter types are: 
                •	"Starts with"
                •	"Ends with"
                •	"Length"
                •	"Contains" */
            string command = string.Empty;
            while ((command = Console.ReadLine()) != "Print")
            {
                string[] data = command.Split(";");
                Predicate<string> filter = Filter(data[1], data[2]);
                switch (data[0])
                {
                    case "Add filter":
                        filters.Add(filter);
                        break;
                    case "Remove filter":       // Не може да изтрия филтъра.
                        filters.Remove(filter);
                        break;
                }
            }
            foreach (string invitation in guests)
            {
                bool passed = true;
                foreach (var filter in filters)
                {
                    if (filter(invitation)) passed = false;
                }
                if (passed) Console.Write(invitation + " ");
            }
        }

        static Predicate<string> Filter(string filterType, string parameter)
        {
            switch (filterType)
            {
                case "Starts with":
                    return str => str.StartsWith(parameter);
                case "Ends with":
                    return str => str.EndsWith(parameter);
                case "Length":
                    return str => str.Length == int.Parse(parameter);
                case "Contains":
                    return str => str.Contains(parameter);
                default:
                    return null;
            }
        }
    }
}
