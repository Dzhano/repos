using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SoftUniParking
{
    public class Parking
    {
        private List<Car> cars;
        private int capacity;
        public Parking(int capacity)
        {
            this.cars = new List<Car>();
            this.capacity = capacity;
        }

        public int Count => this.cars.Count;

        public string AddCar(Car car)
        {
            if (this.cars.Any(c => c.RegistrationNumber == car.RegistrationNumber))
                return "Car with that registration number, already exists!";
            if (this.cars.Count == capacity) return "Parking is full!";
            this.cars.Add(car);
            return $"Successfully added new car {car.Make} {car.RegistrationNumber}";
        }

        public string RemoveCar (string registrationNumber)
        {
            Car removedCar = this.cars.FirstOrDefault(c => c.RegistrationNumber == registrationNumber);
            if (removedCar == null)
            {
                return "Car with that registration number, doesn't exist!";
            }
            this.cars.Remove(removedCar);
            return $"Successfully removed {registrationNumber}";
        }

        public Car GetCar(string registrationNumber) => this.cars.FirstOrDefault(c => c.RegistrationNumber == registrationNumber);

        public void RemoveSetOfRegistrationNumber(List<string> registrationNumbers)
        {
            this.cars = this.cars.Where(c => !registrationNumbers.Contains(c.RegistrationNumber)).ToList();
        }
    }
}
