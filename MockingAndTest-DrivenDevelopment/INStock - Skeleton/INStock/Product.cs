using INStock.Contracts;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text;

namespace INStock
{
    public class Product : IProduct
    {
        public string Label { get; }

        public decimal Price { get; }

        public int Quantity { get; }

        // Не знам какво да правя с това. Не пише нищо за него в условието.
        public int CompareTo([AllowNull] IProduct other)
        {
            throw new NotImplementedException();
        }
    }
}
