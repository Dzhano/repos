using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace _4.MergeFiles
{
    class Program
    {
        static void Main(string[] args)
        {
            using (StreamReader reader = new StreamReader(@"../../../FileOne.txt"))
            {
                List<string> data = new List<string>();
                string line = string.Empty;
                while ((line = reader.ReadLine()) != null)
                    data.Add(line);
                using (StreamReader reader2 = new StreamReader(@"../../../FileTwo.txt"))
                {
                    while ((line = reader2.ReadLine()) != null)
                        data.Add(line);
                    data = data.OrderBy(x => x).ToList();
                    using (StreamWriter writer = new StreamWriter(@"../../../Merge.txt"))
                    {
                        foreach (string item in data)
                            writer.WriteLine(item);
                    }
                }
            }
        }
    }
}
