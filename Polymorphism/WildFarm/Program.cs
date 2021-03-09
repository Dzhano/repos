using System;
using System.Collections.Generic;
using WildFarm.Animals;
using WildFarm.Foods;
using WildFarm.Animals.Birds;
using WildFarm.Animals.Mammals;
using WildFarm.Animals.Mammals.Felines;

namespace WildFarm
{
    public class Program
    {
        static void Main(string[] args)
        {
            List<Animal> animals = new List<Animal>();

            string input = string.Empty;
            while ((input = Console.ReadLine()) != "End")
            {
                string[] animalData = input.Split(" ", StringSplitOptions.RemoveEmptyEntries);
                string animalName = animalData[1];
                double animalWeight = double.Parse(animalData[2]);
                string livingRegion = animalData[3];
                string[] foodData = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
                string foodType = foodData[0];
                int foodQuantity = int.Parse(foodData[1]);

                Animal newAnimal = null;
                switch (animalData[0])
                {
                    case "Hen":
                        double wingSizeHen = double.Parse(animalData[3]);
                        newAnimal = new Hen(animalName, animalWeight, wingSizeHen);
                        break;
                    case "Owl":
                        double wingSizeOwl = double.Parse(animalData[3]);
                        newAnimal = new Owl(animalName, animalWeight, wingSizeOwl);
                        break;
                    case "Cat":
                        string catBreed = animalData[4];
                        newAnimal = new Cat(animalName, animalWeight, livingRegion, catBreed);
                        break;
                    case "Tiger":
                        string tigerBreed = animalData[4];
                        newAnimal = new Tiger(animalName, animalWeight, livingRegion, tigerBreed);
                        break;
                    case "Mouse":
                        newAnimal = new Mouse(animalName, animalWeight, livingRegion);
                        break;
                    case "Dog":
                        newAnimal = new Dog(animalName, animalWeight, livingRegion);
                        break;
                }
                Console.WriteLine(newAnimal.ProduceSound());

                Food food = null;
                switch (foodType)
                {
                    case "Fruit":
                        food = new Fruit(foodQuantity);
                        break;
                    case "Meat":
                        food = new Meat(foodQuantity);
                        break;
                    case "Seeds":
                        food = new Seeds(foodQuantity);
                        break;
                    case "Vegetable":
                        food = new Vegetable(foodQuantity);
                        break;
                }
                newAnimal.Feed(food);

                animals.Add(newAnimal);
            }

            foreach (Animal animal in animals)
                Console.WriteLine(animal);
        }
    }
}
