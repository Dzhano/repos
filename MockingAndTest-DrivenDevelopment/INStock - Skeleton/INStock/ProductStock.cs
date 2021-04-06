using INStock.Contracts;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace INStock
{
    /* Условието на задачата не беше написано добре.
       Липсват много неизвестни.
       Наложи ми се дори да променя някои от нещата, за да съответстват с условието.

       Оставям задачата така, понеже не знам как трябва да бъде направена изцяло.
       Не ми се занимава после да търкам половината код за да работи правилно.
       Същото се отнася и за тестовете.
        
       Условие на задачата: https://softuni.bg/trainings/resources/officedocument/55007/mocking-and-test-driven-development-lab-csharp-oop-february-2021/3214
    */
    public class ProductStock : IProductStock
    {
        private Dictionary<int, IProduct> stock;
        private int place;

        public ProductStock()
        {
            stock = new Dictionary<int, IProduct>();
        }

        public IProduct this[int index] { get => stock[index]; } // Не съм сигурен дали трябва да е така.
        IProduct IProductStock.this[int index] { get => stock[index]; set => throw new NotImplementedException(); } // Тук също.

        public int Count => stock.Count;

        public void Add(IProduct product)
        {
            stock.Add(place++, product);
        }

        public bool Contains(IProduct product)
        {
            return stock.Values.Any(p => p.Label == product.Label && p.Price == product.Price && p.Quantity == product.Quantity);
        }

        public IProduct Find(int index)
        {
            IProduct product = stock.FirstOrDefault(p => p.Key == index).Value;
            if (product == null) throw new IndexOutOfRangeException();
            return product;
        }

        public IEnumerable<IProduct> FindAllByPrice(decimal price)
        {
            return stock.Values.Where(p => p.Price == price);
        }

        public IEnumerable<IProduct> FindAllByQuantity(int quantity)
        {
            return stock.Values.Where(p => p.Quantity == quantity);
        }

        public IEnumerable<IProduct> FindAllInPriceRange(decimal lo, decimal hi)
        {
            return stock.Values.Where(p => p.Price >= lo && p.Price <= hi).OrderByDescending(p => p);
        }

        public IProduct FindByLabel(string label)
        {
            IProduct product = stock.FirstOrDefault(p => p.Value.Label == label).Value;
            if (product == null) throw new ArgumentException();
            return product;
        }

        public IProduct FindMostExpensiveProduct()
        {
            return stock.Values.OrderByDescending(p => p.Price).First();
        }

        public IEnumerator<IProduct> GetEnumerator()
        {
            foreach (IProduct product in stock.Values)
                yield return product;
        }

        public bool Remove(IProduct product)
        {
            if (stock.Values.Any(p => p.Label == product.Label
                && p.Price == product.Price && p.Quantity == product.Quantity))
            {
                int key = stock.Where(p => p.Value.Label == product.Label
                    && p.Value.Price == product.Price && p.Value.Quantity == product.Quantity).First().Key;
                stock.Remove(key);
                return true;
            }
            else return false;
        } // Нямаше нищо за това в условието.

        IEnumerator IEnumerable.GetEnumerator()
        {
            throw new NotImplementedException();
        }
    }
}
