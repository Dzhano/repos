using System;

namespace PasswordValidator
{
    class Program
    {
        static void Main(string[] args)
        {
            string password = Console.ReadLine();
            bool chr = Characters(password);
            bool cons = Consistation(password);
            bool digits = HavingDigits(password);
            if (!chr) Console.WriteLine("Password must be between 6 and 10 characters");
            if (!cons) Console.WriteLine("Password must consist only of letters and digits");
            if (!digits) Console.WriteLine("Password must have at least 2 digits");
            if (chr && cons && digits) Console.WriteLine("Password is valid");
        }

        static bool Characters(string password)
        {
            bool chr = false;
            if (password.Length >= 6 && password.Length <= 10) chr = true;
            return chr;
        }

        static bool Consistation(string password)
        {
            bool cons = true;
            foreach (char item in password)
            {
                if (!char.IsLetterOrDigit(item)) cons = false;
            }
            return cons;
        }

        static bool HavingDigits(string password)
        {
            bool digits = false;
            int counter = 0;
            for (int i = 0; i < password.Length; i++)
            {
                char a = password[i];
                switch (a)
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
                        counter++;
                        break;
                }
            }
            if (counter >= 2) digits = true;
            return digits;
        }
    }
}
