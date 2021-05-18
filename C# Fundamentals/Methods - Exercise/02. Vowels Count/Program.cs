using System;

namespace _2
{
    class Program
    {
        static void Main(string[] args)
        {
            string name = Console.ReadLine();
            int count = 0;
            CountVowels(name, count);
        }
        static void CountVowels(string name, int count)
        {
            for (int i = 0; i < name.Length; i++)
            {
                if (name[i] == 'a' || name[i] == 'e' || name[i] == 'i' || name[i] == 'o' || name[i] == 'u'||name[i] == 'A' || name[i] == 'E' || name[i] == 'I' || name[i] == 'O' || name[i] == 'U')
                {
                    count++;
                }

            }
            Console.WriteLine(count);
        }
    }
}
