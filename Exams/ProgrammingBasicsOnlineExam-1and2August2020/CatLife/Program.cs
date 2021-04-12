using System;

namespace CatLife
{
    class Program
    {
        static void Main(string[] args)
        {
            string breed = Console.ReadLine(); // "British Shorthair", "Siamese", "Persian", "Ragdoll", "American Shorthair" или "Siberian"
            char gender = char.Parse(Console.ReadLine()); // 'm' или 'f'

            double years = 0;
            switch (breed)
            {
                case "British Shorthair":
                    switch (gender)
                    {
                        case 'm':
                            years = 13;
                            break;
                        case 'f':
                            years = 14;
                            break;
                    }
                    break;
                case "Siamese":
                    switch (gender)
                    {
                        case 'm':
                            years = 15;
                            break;
                        case 'f':
                            years = 16;
                            break;
                    }
                    break;
                case "Persian":
                    switch (gender)
                    {
                        case 'm':
                            years = 14;
                            break;
                        case 'f':
                            years = 15;
                            break;
                    }
                    break;
                case "Ragdoll":
                    switch (gender)
                    {
                        case 'm':
                            years = 16;
                            break;
                        case 'f':
                            years = 17;
                            break;
                    }
                    break;
                case "American Shorthair":
                    switch (gender)
                    {
                        case 'm':
                            years = 12;
                            break;
                        case 'f':
                            years = 13;
                            break;
                    }
                    break;
                case "Siberian":
                    switch (gender)
                    {
                        case 'm':
                            years = 11;
                            break;
                        case 'f':
                            years = 12;
                            break;
                    }
                    break;
                default:
                    Console.WriteLine($"{breed} is invalid cat!");
                    return;
            }
            double months = Math.Floor((years * 12) / 6);
            Console.WriteLine($"{months} cat months");
        }
    }
}
