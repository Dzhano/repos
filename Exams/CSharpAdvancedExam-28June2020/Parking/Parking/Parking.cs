using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Parking
{
    public class Parking
    {
        public Parking(string type, int capacity)
        {
            Type = type;
            Capacity = capacity;
            cars = new List<Car>(Capacity);
        }

        public string Type { get; private set; }
        public int Capacity { get; private set; }
        private List<Car> cars;

        public int Count => cars.Count;

        public void Add(Car car)
        {
            if (cars.Count < Capacity)
                cars.Add(car);
        }

        public bool Remove(string manufacturer, string model)
        {
            Car car = cars.FirstOrDefault(c => c.Manufacturer == manufacturer && c.Model == model);
            return cars.Remove(car);
        }

        public Car GetLatestCar()
        {
            if (cars.Count == 0) return null;
            return cars.OrderByDescending(c => c.Year).FirstOrDefault();
        }

        public Car GetCar(string manufacturer, string model)
            => cars.FirstOrDefault(c => c.Manufacturer == manufacturer && c.Model == model);

        public string GetStatistics()
        {
            StringBuilder builder = new StringBuilder();
            builder.AppendLine($"The cars are parked in {Type}:");
            foreach (Car car in cars)
                builder.AppendLine(car.ToString());
            return builder.ToString().TrimEnd();
        }
    }
}
