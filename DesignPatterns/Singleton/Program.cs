using System;

namespace Singleton
{
    class Program
    {
        // Не знам точно как да оправя кода за да използва и закоментираните части.
        // Иначе си работи по този начин.
        public static void Main(string[] args)
        {
            SingletonDataContainer db = SingletonDataContainer.Instance;
            //Console.WriteLine(db.GetPopulation("Washington, D.C."));

            SingletonDataContainer db2 = SingletonDataContainer.Instance;
            //Console.WriteLine(db2.GetPopulation("London"));

            SingletonDataContainer db3 = SingletonDataContainer.Instance;
            //Console.WriteLine(db3.GetPopulation("Harmanli"));

            SingletonDataContainer db4 = SingletonDataContainer.Instance;
            //Console.WriteLine(db4.GetPopulation("Sofia"));
        }
    }
}
