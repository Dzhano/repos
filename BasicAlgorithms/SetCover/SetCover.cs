using System;
using System.Collections.Generic;
using System.Linq;

public class SetCover
{
    public static void Main(string[] args)
    {
        int[] universe = Console.ReadLine()
            .Split(new string[] { ", ", " " }, StringSplitOptions.RemoveEmptyEntries)
            .Skip(1).Select(int.Parse).ToArray();
        string[] numberOfSetsInput = Console.ReadLine().Split();
        int numberOfSets = int.Parse(numberOfSetsInput[3]);
        int[][] sets = new int[numberOfSets][];
        for (int i = 0; i < numberOfSets; i++)
        {
            int[] input = Console.ReadLine()
            .Split(new string[] { ", " }, StringSplitOptions.RemoveEmptyEntries)
            .Select(int.Parse).ToArray();
            sets[i] = input;
        }

        List<int[]> selectedSets = ChooseSets(sets.ToList(), universe.ToList());
        Console.WriteLine($"Sets to take ({selectedSets.Count}):");

        foreach (int[] set in selectedSets) 
            Console.WriteLine($"{{ {string.Join(", ", set)} }}");
    }

    public static List<int[]> ChooseSets(IList<int[]> sets, IList<int> universe)
    {
        List<int[]> selectedSets = new List<int[]>();
        while (universe.Count > 0)
        {
            int[] currentSet = sets.OrderByDescending(s => s.Count(universe.Contains)).First();
            selectedSets.Add(currentSet);
            sets.Remove(currentSet);
            foreach (int item in currentSet) if (universe.Contains(item)) universe.Remove(item);
        }
        return selectedSets;
    }
}
