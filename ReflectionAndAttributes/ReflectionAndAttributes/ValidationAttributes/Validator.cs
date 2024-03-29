﻿using System.Linq;
using System.Reflection;
using ValidationAttributes.Attributes;

namespace ValidationAttributes
{
    public static class Validator
    {
        public static bool IsValid(object obj)
        {
            PropertyInfo[] properties = obj.GetType().GetProperties();

            foreach (PropertyInfo property in properties)
            {
                MyValidationAttribute[] attributes = property.GetCustomAttributes()
                    .Where(x => x is MyValidationAttribute)
                    .Cast<MyValidationAttribute>().ToArray();

                object value = property.GetValue(obj);

                foreach (MyValidationAttribute attribute in attributes)
                {
                    bool isValid = attribute.IsValid(value);
                    if (!isValid) return false;
                }
            }

            return true;
        }
    }
}
