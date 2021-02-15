using System;
using System.Collections.Generic;
using System.Text;

namespace GenericCountMethod
{
    public class Box<T>
        where T : IComparable
    {
        public Box(T value)
        {
            Value = value;
        }
        public T Value { get; private set; }
        public override string ToString()
        {
            Type valueType = Value.GetType();
            return $"{valueType.FullName}: {Value}";
        }
    }
}
