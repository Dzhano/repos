using System;

namespace ValidUsernames
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] usernames = Console.ReadLine().Split(", ");
            foreach (string username in usernames) 
                if (username.Length >= 3 && username.Length <= 16)
                {
                    bool right = true;
                    foreach (char item in username)
                    {
                        if (char.IsDigit(item) || char.IsLetter(item)
                            || item == '_' || item == '-')
                            continue;
                        else right = false;
                    }
                    if (right) Console.WriteLine(username);
                }
        }
    }
}
