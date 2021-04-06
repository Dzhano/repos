namespace INStock.Contracts
{
    using System.Collections.Generic;

    public interface IProductStock : IEnumerable<IProduct>
    {
        int Count { get; }

        IProduct this[int index] { get; set; }

        bool Contains(IProduct product);

        void Add(IProduct product);

        bool Remove(IProduct product);

        IProduct Find(int index);

        IProduct FindByLabel(string label);

        IProduct FindMostExpensiveProduct();

        /* Наложи ми се дори да променя някои от нещата, които съм заградим с наклонени черти, за да съответстват с условието.
           Промених променливите в скобите от "double" на "decimal".
        */
        //
        IEnumerable<IProduct> FindAllInPriceRange(decimal lo, decimal hi);

        IEnumerable<IProduct> FindAllByPrice(decimal price);
        //
        IEnumerable<IProduct> FindAllByQuantity(int quantity);
    }
}
