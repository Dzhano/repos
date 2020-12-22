using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AnonymousThreat
{
    class Program
    {
        static void Main(string[] args)
        {
            // Не знам къде ми е грешката. Дава 60/100
            List<string> data = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .ToList();
            string command = string.Empty;
            while ((command = Console.ReadLine()) != "3:1")
            {
                string[] com = command.Split();
                StringBuilder element = new StringBuilder();
                switch (com[0])
                {
                    case "merge":
                        int range = data.Count - 1;
                        int counter = 0;
                        for (int i = int.Parse(com[1]); i <= int.Parse(com[2]); i++)
                        {
                            if (i <= range && i > -1)
                            {
                                element.Append(data[i]);
                                counter++;
                            }
                        }
                        for (int i = 1; i <= counter; i++) data.RemoveAt(int.Parse(com[1]));
                        if (element.Length != 0) data.Insert(int.Parse(com[1]), element.ToString());
                        break;
                    case "divide":
                        int originalLength = data[int.Parse(com[1])].Length / int.Parse(com[2]);
                        element.Append(data[int.Parse(com[1])]);
                        int ie = 0;
                        StringBuilder el = new StringBuilder();
                        for (int i = 0; i < int.Parse(com[2]); i++)
                        {
                            for (int k = 0; k < originalLength; k++) el.Append(element[k]);
                            if (i == 0) data[int.Parse(com[1])] = el.ToString();
                            else data.Insert(int.Parse(com[1]) + ie, el.ToString());
                            ie++;
                            element.Remove(0, originalLength);
                            el.Remove(0, originalLength);
                        }
                        if (element.Length != 0)
                        {
                            StringBuilder il = new StringBuilder();
                            il.Append(data[int.Parse(com[1]) + ie - 1]);
                            il.Append(element);
                            data[int.Parse(com[1]) + ie - 1] = il.ToString();
                        }
                        break;
                }
            }
            Console.WriteLine(string.Join(" ", data));
        }
    }
}
