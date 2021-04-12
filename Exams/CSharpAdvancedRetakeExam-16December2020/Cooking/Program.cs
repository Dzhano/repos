using System;
using System.Collections.Generic;
using System.Linq;

namespace Cooking
{
    class Program
    {
        static void Main(string[] args)
        {
            int breads = 0;
            int cakes = 0;
            int fruitPies = 0;
            int pastries = 0;

            int[] liquidsInput = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse).ToArray();
            Queue<int> liquids = new Queue<int>(liquidsInput);

            int[] ingredientsInput = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse).ToArray();
            Stack<int> ingredients = new Stack<int>(ingredientsInput);

            while(liquids.Count > 0 && ingredients.Count > 0)
            {
                int liquid = liquids.Dequeue();
                int ingredient = ingredients.Pop();

                if (liquid + ingredient == 25) breads++;
                else if (liquid + ingredient == 50) cakes++;
                else if (liquid + ingredient == 75) pastries++;
                else if (liquid + ingredient == 100) fruitPies++;

                else ingredients.Push(ingredient + 3);
            }

            if (breads > 0 && cakes > 0 && fruitPies > 0 && pastries > 0)
                Console.WriteLine("Wohoo! You succeeded in cooking all the food!");
            else Console.WriteLine("Ugh, what a pity! You didn't have enough materials to cook everything.");

            if (liquids.Count == 0) Console.WriteLine("Liquids left: none");
            else Console.WriteLine($"Liquids left: {string.Join(", ", liquids)}");
            
            if (ingredients.Count == 0) Console.WriteLine("Ingredients left: none");
            else Console.WriteLine($"Ingredients left: {string.Join(", ", ingredients)}");

            Console.WriteLine($"Bread: {breads}");
            Console.WriteLine($"Cake: {cakes}");
            Console.WriteLine($"Fruit Pie: {fruitPies}");
            Console.WriteLine($"Pastry: {pastries}");
        }
    }
}
