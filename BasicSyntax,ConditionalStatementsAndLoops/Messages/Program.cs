using System;

namespace Messages
{
    class Program
    {
        static void Main(string[] args)
        {
            string text = string.Empty;
            int n = int.Parse(Console.ReadLine());
            for (int i = 1; i <= n; i++)
            {
                string number = Console.ReadLine();

                int length = number.Length;
                int digit = int.Parse(number[0].ToString());
                switch (digit)
                {
                    case 0:
                        text += " ";
                        break;
                    case 2:
                        switch (length)
                        {
                            case 1:
                                text += "a";
                                break;
                            case 2:
                                text += "b";
                                break;
                            case 3:
                                text += "c";
                                break;
                        }
                        break;
                    case 3:
                        switch (length)
                        {
                            case 1:
                                text += "d";
                                break;
                            case 2:
                                text += "e";
                                break;
                            case 3:
                                text += "f";
                                break;
                        }
                        break;
                    case 4:
                        switch (length)
                        {
                            case 1:
                                text += "g";
                                break;
                            case 2:
                                text += "h";
                                break;
                            case 3:
                                text += "i";
                                break;
                        }
                        break;
                    case 5:
                        switch (length)
                        {
                            case 1:
                                text += "j";
                                break;
                            case 2:
                                text += "k";
                                break;
                            case 3:
                                text += "l";
                                break;
                        }
                        break;
                    case 6:
                        switch (length)
                        {
                            case 1:
                                text += "m";
                                break;
                            case 2:
                                text += "n";
                                break;
                            case 3:
                                text += "o";
                                break;
                        }
                        break;
                    case 7:
                        switch (length)
                        {
                            case 1:
                                text += "p";
                                break;
                            case 2:
                                text += "q";
                                break;
                            case 3:
                                text += "r";
                                break;
                            case 4:
                                text += "s";
                                break;
                        }
                        break;
                    case 8:
                        switch (length)
                        {
                            case 1:
                                text += "t";
                                break;
                            case 2:
                                text += "u";
                                break;
                            case 3:
                                text += "v";
                                break;
                        }
                        break;
                    case 9:
                        switch (length)
                        {
                            case 1:
                                text += "w";
                                break;
                            case 2:
                                text += "x";
                                break;
                            case 3:
                                text += "y";
                                break;
                            case 4:
                                text += "z";
                                break;
                        }
                        break;
                }
            }
            Console.WriteLine(text);
        }
    }
}
