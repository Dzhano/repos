using System;
using System.Collections.Generic;
using System.Text;

namespace GenericBoxOfString
{
    public class Box<T>
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
