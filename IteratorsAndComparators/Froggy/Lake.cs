using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace Froggy
{
    class Lake : IEnumerable<int>
    {
        private List<int> stones;
        public Lake(List<int> elements) => this.stones = elements;

        public IEnumerator<int> GetEnumerator()
        {
            for (int i = 0; i < stones.Count; i += 2)
                yield return stones[i];
            int index = stones.Count - 1;
            if (index % 2 == 0) index--;
            for (int j = index; j >= 0; j -= 2) 
                yield return stones[j];
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
