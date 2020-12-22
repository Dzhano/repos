using System;

namespace ChangeBureau
{
    class Program
    {
        static void Main(string[] args)
        {
            int bitcoins = int.Parse(Console.ReadLine());
            double uan = double.Parse(Console.ReadLine());
            double commision = double.Parse(Console.ReadLine());

            double bitcoinMoney = (bitcoins * 1.0) * 1168;
            double uanMoney = (uan * 0.15) * 1.76;
            double euro = (bitcoinMoney + uanMoney) / 1.95;
            euro -= (euro * commision) / 100;
            Console.WriteLine($"{euro:F2}");
        }
    }
}
