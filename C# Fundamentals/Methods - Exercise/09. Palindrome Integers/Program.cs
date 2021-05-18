using System;

namespace _9._Palindrome_Integers
{
    class Program
    {
        static void Main(string[] args)
        {
            string command = Console.ReadLine();
            int n = int.Parse(command);
            PrintPaindromeOrNot(command, n);
        }
        static void PrintPaindromeOrNot(string command, int n)
        {
            while (command != "END")
            {
                 n = int.Parse(command);
                for (int i = 0; i < command.Length; i++)
                {
                    for (int j = command.Length - 1; j >= 0; j++)
                    {
                        if (command[i] ==command[j])
                        {
                            Console.WriteLine("true");
                            break;
                        }
                        else
                        {
                            Console.WriteLine("false");
                            break;
                        }
                    }
                    break;
                }
                command = Console.ReadLine();
                if (command == "END")
                {
                    return;
                }
            }
        }
    }
}
