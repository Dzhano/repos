using System;
using System.Text;

namespace Digits_LettersAndOther
{
    class Program
    {
        static void Main(string[] args)
        {
            string text = Console.ReadLine();
            for (int i = 0; i < 3; i++)
            {
                StringBuilder result = new StringBuilder();
                foreach (char item in text)
                {
                    switch (i)
                    {
                        case 0:
                            if (char.IsDigit(item))
                                result.Append(item);
                            break;
                        case 1:
                            if (char.IsLetter(item))
                                result.Append(item);
                            break;
                        case 2:
                            if (!char.IsLetter(item) && !char.IsDigit(item))
                                result.Append(item);
                            break;
                    }
                }
                Console.WriteLine(result);
            }
        }
    }
}
