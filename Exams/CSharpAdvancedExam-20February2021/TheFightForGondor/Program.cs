using System;
using System.Collections.Generic;
using System.Linq;

namespace TheFightForGondor
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            int[] platesInput = Console.ReadLine().Split()
                .Select(int.Parse).ToArray();
            Queue<int> plates = new Queue<int>(platesInput);

            Stack<int> orkWarriors = new Stack<int>();

            bool over = false;
            for (int i = 1; i <= n; i++)
            {
                int[] orksInput = Console.ReadLine().Split()
                    .Select(int.Parse).ToArray();
                foreach (int orkWarrior in orksInput) 
                    orkWarriors.Push(orkWarrior);

                if (i % 3 == 0)
                {
                    int[] newPlatesInput = Console.ReadLine().Split()
                        .Select(int.Parse).ToArray();
                    foreach (int newPlate in newPlatesInput)
                        plates.Enqueue(newPlate);
                }
                
                int plate = plates.Dequeue();
                while (orkWarriors.Count > 0)
                {
                    int ork = orkWarriors.Pop();
                    if (plate == ork)
                    {
                        if (plates.Count > 0) plate = plates.Dequeue();
                        else 
                        {
                            over = true;
                            break;
                        }
                        ork = 0;
                    }
                    else if (ork > plate)
                    {
                        ork -= plate;
                        orkWarriors.Push(ork);
                        if (plates.Count > 0) plate = plates.Dequeue();
                        else
                        {
                            over = true;
                            break;
                        }
                    }
                    else if (ork < plate)
                    {
                        plate -= ork;
                        ork = 0;
                    }
                }
                if (over) break;
                Queue<int> newplates = new Queue<int>();
                newplates.Enqueue(plate);
                foreach (int item in plates)
                    newplates.Enqueue(item);
                plates = newplates;
            }
            if (plates.Count <= 0) Console.WriteLine("The orcs successfully destroyed the Gondor's defense.");
            else if (orkWarriors.Count <= 0) Console.WriteLine("The people successfully repulsed the orc's attack.");
            if (orkWarriors.Count > 0) Console.WriteLine($"Orcs left: {string.Join(", ", orkWarriors)}");
            if (plates.Count > 0) Console.WriteLine($"Plates left: {string.Join(", ", plates)}");
        }
    }
}
