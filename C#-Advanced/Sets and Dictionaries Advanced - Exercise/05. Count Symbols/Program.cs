using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
namespace _5
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            Dictionary<char, int> charecters = new Dictionary<char, int>();
            for (int i = 0; i < input.Length; i++)
            {
                if (!charecters.ContainsKey((char)input[i]))
                {
                    charecters.Add(input[i], 0);
                }
                charecters[input[i]] += 1;
            }
            foreach (var item in charecters.OrderBy(x=>x.Key))
            {
                Console.WriteLine($"{item.Key}: {item.Value} time/s");
            }
        }
    }
}
