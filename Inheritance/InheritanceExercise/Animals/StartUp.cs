using System;

namespace Animals
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            string command = string.Empty;
            while ((command = Console.ReadLine()) != "Beast!")
            {
                string[] input = Console.ReadLine().Split();
                string name = input[0];
                int age = int.Parse(input[1]);
                string gender = input[2];
                if (string.IsNullOrEmpty(name)
                    || age < 0 
                    || (gender != "Male" && gender != "Female") 
                    || string.IsNullOrEmpty(gender))
                {
                    Console.WriteLine("Invalid input!");
                    continue;
                }
                switch (command)
                {
                    case "Dog":
                        Dog dog = new Dog(name, age, gender);

                        Console.WriteLine(dog);
                        Console.WriteLine(dog.ProduceSound());
                        break;
                    case "Cat":
                        Cat cat = new Cat(name, age, gender);

                        Console.WriteLine(cat);
                        Console.WriteLine(cat.ProduceSound());
                        break;
                    case "Frog":
                        Frog frog = new Frog(name, age, gender);

                        Console.WriteLine(frog);
                        Console.WriteLine(frog.ProduceSound());
                        break;
                    case "Kitten":
                        Kitten kitten = new Kitten(name, age);

                        Console.WriteLine(kitten);
                        Console.WriteLine(kitten.ProduceSound());
                        break;
                    case "Tomcat":
                        Tomcat tomcat = new Tomcat(name, age);

                        Console.WriteLine(tomcat);
                        Console.WriteLine(tomcat.ProduceSound());
                        break;
                }
            }
        }
    }
}
