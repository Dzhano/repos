using System;
using Wintellect.PowerCollections;

namespace _04.CookiesProblem
{
    public class CookiesProblem
    {
        public int Solve(int k, int[] cookies)
        {
            OrderedBag<int> bag = new OrderedBag<int>(cookies);

            int smallestElement = bag.GetFirst();
            int steps = 0;

            while (smallestElement < k && bag.Count > 1)
            {
                steps++;

                int smallestCokkie = bag.RemoveFirst();
                int secondSmallestCokkie = bag.RemoveFirst();

                bag.Add(smallestCokkie + (2 * secondSmallestCokkie));
                smallestElement = bag.GetFirst();
            }

            return smallestElement >= k ? steps : -1;
        }
    }
}
