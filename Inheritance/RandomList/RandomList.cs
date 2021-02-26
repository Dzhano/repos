using System;
using System.Collections.Generic;
using System.Text;

namespace CustomRandomList
{
    class RandomList : List<string>
    {
        private Random random;
        
        public RandomList()
        {
            random = new Random();
        }

        public void Add(string input)
        {
            base.Add(input);
        }

        public string RandomString()
        {
            return this[random.Next(0, this.Count - 1)];
        }
    }
}
