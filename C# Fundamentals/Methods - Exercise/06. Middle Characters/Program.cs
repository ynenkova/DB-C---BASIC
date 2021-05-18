using System;

namespace _6
{
    class Program
    {
        static void Main(string[] args)
        {
            string name = Console.ReadLine();
            PrintMiddelChar(name);
        }
        static void PrintMiddelChar(string name)
        {
            if (name.Length % 2 == 0)
            {
                int lenght = name.Length;
                int halfLenght = (lenght/2)+1;

                for (int i = 0; i <=name.Length-halfLenght; i++)
                {
                    if (i == name.Length - halfLenght)
                    {
                        Console.Write((char)name[i]);
                        Console.Write((char)name[i+1]);
                    }
                }
            }
            else if(name.Length % 2 != 0)
            {
                int num = name.Length / 2;
                for (int i = 0; i < name.Length; i++)
                {
                    if (i==num)
                    {
                        Console.Write((char)name[i]);
                        return;
                    }
                }
            }
        }
    }
}
