using System;

namespace _5.Login
{
    class Program
    {
        static void Main(string[] args)
        {
            string name = Console.ReadLine();
            string passWord = "";
            int count = 0;
            for (int i = name.Length - 1; i >= 0; i--)
            {
                char pass = name[i];
                passWord += pass.ToString();

            }
            string login = Console.ReadLine();
            while (login != passWord)
            {
                count++;
                if (count == 4)
                {
                    Console.WriteLine($"User {name} blocked!");
                    return;
                }
                else
                {
                    Console.WriteLine("Incorrect password. Try again.");
                }
                login = Console.ReadLine();
            }

            if (login == passWord)
            {
                Console.WriteLine($"User {name} logged in.");
            }
            
        }
    }
}
