using System;

namespace Farm
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            Dog kiki = new Dog();
            kiki.Eat();
            kiki.Bark();

            Cat cat = new Cat();
            cat.Eat();
            cat.Meow();
        }
    }
}
