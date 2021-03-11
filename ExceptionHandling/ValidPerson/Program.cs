using System;

namespace ValidPerson
{
    class Program
    {
        static void Main(string[] args)
        {
            CatchPersonException("Dzhano", "Mihaylov", 17);
            CatchPersonException(string.Empty, "Trifonov", 16);
            CatchPersonException("Ivan", null, 20);
            CatchPersonException("Georgi", "Borisov", -20);
            CatchPersonException("Hristo", "Hubenov", 128);

            Console.WriteLine();

            CatchStudentException("Dzhano", "djano2003@gmail.com");
            CatchStudentException("Djan0", "djano@students.softuni.bg");
        }

        static void CatchPersonException(string firstname, string lastName, int age)
        {
            try
            {
                Person person = new Person(firstname, lastName, age);
            }
            catch (ArgumentNullException ex)
            {
                Console.WriteLine($"Exception thrown: {ex.Message}");
            }
            catch (ArgumentOutOfRangeException ex)
            {
                Console.WriteLine($"Exception thrown: {ex.Message}");
            }
        }

        static void CatchStudentException(string name, string email)
        {
            try
            {
                Student student = new Student(name, email);
            }
            catch (InvalidPersonNameException ex)
            {
                Console.WriteLine($"Exception thrown: {ex.Message}");
            }
        }
    }
}
