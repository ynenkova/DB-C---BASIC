using System;
using System.Linq;
using System.Collections.Generic;
namespace _2
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, int> result = new Dictionary<string, int>();
            List<string> name = new List<string>();
            int count = 0;
            while (true)
            {
                string text = Console.ReadLine();
                count++;
                if (text == "stop")
                {
                    break;
                }
                int num = int.Parse(Console.ReadLine());
                if (!result.ContainsKey(text))
                {
                    result.Add(text, 0);
                }
                
                    result[text] += num;

            }
            foreach (var item in result)
            {
                Console.WriteLine($"{item.Key} -> {item.Value}");
            }

        }
    }
}
