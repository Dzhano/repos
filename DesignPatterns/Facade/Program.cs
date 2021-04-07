using System;

namespace Facade
{
    class Program
    {
        static void Main(string[] args)
        {
            Car car = new CarBuilderFacade()
                .Info
                    .WithType("Ford")
                    .WithColor("Blue")
                    .WithNumberOfDoors(4)
                .Built
                    .InCity("Haskovo")
                    .AtAddress("Some address")
                .Build();
            Console.WriteLine(car);
        }
    }
}
