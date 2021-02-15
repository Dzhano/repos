using System;
using System.Collections.Generic;
using System.Text;

namespace BoxOfT
{
    public class Box<T>
    {
        public Box()
        {
            data = new Stack<T>();
        }
        
        private Stack<T> data;
        public void Add(T element)
        {
            data.Push(element);
        }
        public T Remove()
        {
            return data.Pop();
        }
        public int Count { get { return data.Count; } }
    }
}
