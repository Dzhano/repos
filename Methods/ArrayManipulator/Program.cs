using System;
using System.Linq;

namespace ArrayManipulator
{
    class Program
    {
        static void Main(string[] args)
        {
            // Според изчисленията ми, задачата трябва да работи добре, но в Judge показва 50/100. Според мен тя си е добре.
            int[] array = Console.ReadLine().
                Split().
                Select(int.Parse).
                ToArray();
            string command = string.Empty;
            while ((command = Console.ReadLine()) != "end")
            {
                string[] manipulation = command.Split();
                switch (manipulation[0])
                {
                    case "exchange":
                        int index = int.Parse(manipulation[1]);
                        array = Exchange(index, array);
                        break;
                    case "max":
                        string evenORodd = manipulation[1];
                        Max(array, evenORodd);
                        break;
                    case "min":
                        string oddOReven = manipulation[1];
                        Min(array, oddOReven);
                        break;
                    case "first":
                        int count = int.Parse(manipulation[1]);
                        string type = manipulation[2];
                        First(array, count, type);
                        break;
                    case "last":
                        int count2 = int.Parse(manipulation[1]);
                        string type1 = manipulation[2];
                        Last(array, count2, type1);
                        break;
                }
            }
            Console.WriteLine($"[{string.Join(", ", array)}]");
        }

        static int[] Exchange(int index, int[] array)
        {
            if (index < 0 || index >= array.Length)
            {
                Console.WriteLine("Invalid index");
                return array;
            }
            else
            {
                int[] arr = new int[array.Length];
                int count = 0;
                for (int i = index + 1; i < array.Length; i++)
                {
                    arr[count] = array[i];
                    count++;
                }
                for (int j = 0; j <= index; j++)
                {
                    arr[count] = array[j];
                    count++;
                }
                return arr;
            }
        }

        static void Max(int[] array, string type)
        {
            int maxEven = -99999;
            int maxOdd = -99999;
            int maxEvenInteger = -9;
            int maxOddInteger = -9;
            for (int i = 0; i < array.Length; i++)
            {
                if (array[i] % 2 == 0)
                {
                    if (array[i] > maxEven)
                    {
                        maxEven = array[i];
                        maxEvenInteger = i;
                    }
                }
                else
                {
                    if (array[i] > maxOdd)
                    {
                        maxOdd = array[i];
                        maxOddInteger = i;
                    }
                }
            }
            switch (type)
            {
                case "even":
                    if (maxEvenInteger > -1 && maxEvenInteger < array.Length) Console.WriteLine(maxEvenInteger);
                    else Console.WriteLine("No matches");
                    break;
                case "odd":
                    if (maxOddInteger > -1 && maxOddInteger < array.Length) Console.WriteLine(maxOddInteger);
                    else Console.WriteLine("No matches");
                    break;
            }
        }

        static void Min(int[] array, string type)
        {
            int minEven = 99999;
            int minOdd = 99999;
            int minEvenInteger = -9;
            int minOddInteger = -9;
            for (int i = 0; i < array.Length; i++)
            {
                if (array[i] % 2 == 0)
                {
                    if (array[i] < minEven)
                    {
                        minEven = array[i];
                        minEvenInteger = i;
                    }
                }
                else
                {
                    if (array[i] < minOdd)
                    {
                        minOdd = array[i];
                        minOddInteger = i;
                    }
                }
            }
            switch (type)
            {
                case "even":
                    if (minEvenInteger > -1 && minEvenInteger < array.Length) Console.WriteLine(minEvenInteger);
                    else Console.WriteLine("No matches");
                    break;
                case "odd":
                    if (minOddInteger > -1 && minOddInteger < array.Length) Console.WriteLine(minOddInteger);
                    else Console.WriteLine("No matches");
                    break;
            }
        }

        static void First(int[] array, int count, string type)
        {
            int[] arr = new int[count];
            int counter = 0;
            if (count > array.Length) Console.WriteLine("Invalid count");
            else
            {
                for (int i = 0; i < array.Length; i++)
                {
                    if (counter == count)
                    {
                        Console.WriteLine($"[{string.Join(", ", arr)}]");
                        return;
                    }
                    switch (type)
                    {
                        case "even":
                            if (array[i] % 2 == 0)
                            {
                                arr[counter] = array[i];
                                counter++;
                            }
                            break;
                        case "odd":
                            if (array[i] % 2 != 0)
                            {
                                arr[counter] = array[i];
                                counter++;
                            }
                            break;
                    }
                }
                if (counter == count)
                {
                    Console.WriteLine($"[{string.Join(", ", arr)}]");
                }
                else if (counter < count)
                {
                    Console.Write("[");
                    for (int i = 0; i < counter; i++)
                    {
                        if (i == counter - 1) Console.WriteLine($"{arr[i]}]");
                        else Console.Write($"{arr[i]}, ");
                    }
                    if (counter == 0) Console.WriteLine("]");
                }
            }
        }

        static void Last(int[] array, int count, string type)
        {
            int[] arr = new int[count];
            int counter = count - 1;
            if (count > array.Length) Console.WriteLine("Invalid count");
            else
            {
                for (int i = array.Length - 1; i >= 0; i--)
                {
                    if (counter == -1)
                    {
                        Console.WriteLine($"[{string.Join(", ", arr)}]");
                        return;
                    }
                    switch (type)
                    {
                        case "even":
                            if (array[i] % 2 == 0)
                            {
                                arr[counter] = array[i];
                                counter--;
                            }
                            break;
                        case "odd":
                            if (array[i] % 2 != 0)
                            {
                                arr[counter] = array[i];
                                counter--;
                            }
                            break;
                    }
                }
                if (counter == -1)
                {
                    Console.WriteLine($"[{string.Join(", ", arr)}]");
                }
                else if (counter >= 0)
                {
                    Console.Write("[");
                    for (int i = counter + 1; i <= count - 1; i++)
                    {
                        if (i == count - 1) Console.WriteLine($"{arr[i]}]");
                        else Console.Write($"{arr[i]}, ");
                    }
                    if (counter == count - 1) Console.WriteLine("]");
                }
            }
        }
    }
}
