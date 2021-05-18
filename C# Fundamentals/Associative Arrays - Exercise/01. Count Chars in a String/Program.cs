using System;
using System.Collections.Generic;
using System.Linq;
namespace _1
{
    class Program
    {
        static void Main(string[] args)
        {
            var text = Console.ReadLine();
            var name = new Dictionary<char, int>();
            for (int i = 0; i < text.Length; i++)
            {
                int count = 0;
                if (text[i] != ' ')
                {
                    if (!name.ContainsKey(text[i]))
                    {
                        for (int a = 0; a < text.Length; a++)
                        {

                            if (text[i] == text[a])
                            {
                                count++;
                            }
                        }
                        name.Add(text[i], count);
                    }
                }

            }
            foreach (var item in name)
            {
                Console.WriteLine($"{item.Key} -> {item.Value}");
            }
        }
    }
}
