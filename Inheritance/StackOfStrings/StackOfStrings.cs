using System;
using System.Collections.Generic;
using System.Text;

namespace CustomStack
{
    class StackOfStrings : Stack<string>
    {        
        public bool IsEmpty()
        {
            return this.Count == 0;
        }

        public Stack<string> AddRange(IEnumerable<string> input)
        {
            foreach (string item in input)
                this.Push(item);
            return this;
        }
    }
}
