using System;
using System.Text;

namespace TakeSkipRope
{
    class Program
    {
        static void Main(string[] args)
        {
            StringBuilder text = new StringBuilder();
            text.Append(Console.ReadLine());
            int length = 0;
            for (int i = 0; i < text.Length; i++)
            {
                switch (text[i])
                {
                    case '0':
                    case '1':
                    case '2':
                    case '3':
                    case '4':
                    case '5':
                    case '6':
                    case '7':
                    case '8':
                    case '9':
                        length++;
                        break;
                }
            }
            int[] numbers = new int[length];
            string[] nonNumbers = new string[text.Length - length];
            int counter = 0;
            int nonCounter = 0;
            for (int m = 0; m < text.Length; m++)
            {
                switch (text[m])
                {
                    case '0':
                    case '1':
                    case '2':
                    case '3':
                    case '4':
                    case '5':
                    case '6':
                    case '7':
                    case '8':
                    case '9':
                        numbers[counter] = int.Parse(text[m].ToString());
                        counter++;
                        break;
                    default:
                        nonNumbers[nonCounter] = text[m].ToString();
                        nonCounter++;
                        break;
                }
            }
            int[] skip = new int[numbers.Length / 2];
            int[] take = new int[numbers.Length - skip.Length];
            int takeCount = 0;
            int skipCount = 0;
            for (int l = 0; l < numbers.Length; l++)
            {
                if (l % 2 == 0)
                {
                    take[takeCount] = numbers[l];
                    takeCount++;
                }
                else
                {
                    skip[skipCount] = numbers[l];
                    skipCount++;
                }
            }
            int position = 0;
            StringBuilder message = new StringBuilder();
            for (int k = 0; k < take.Length; k++)
            {
                for (int p = 0; p < take[k]; p++)
                {
                    if (position >= nonNumbers.Length) break;
                    message.Append(nonNumbers[position]);
                    position++;
                }
                if (k < skipCount) position += skip[k];
            }
            Console.WriteLine(message);
        }
    }
}
