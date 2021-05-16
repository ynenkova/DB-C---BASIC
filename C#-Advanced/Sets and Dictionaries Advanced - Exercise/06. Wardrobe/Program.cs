using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
namespace _6
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            Dictionary<string, Dictionary<string, int>> wardrobe = new Dictionary<string, Dictionary<string, int>>();
            for (int i = 0; i < n; i++)
            {
                var input = Console.ReadLine()
                                   .Split(new[] { '-', '>', ',', ' ' }, StringSplitOptions.RemoveEmptyEntries)
                                   .ToArray();
                if (!wardrobe.ContainsKey(input[0]))
                {
                    wardrobe.Add(input[0], new Dictionary<string, int>());
                }
                for (int j = 1; j < input.Length; j++)
                {
                    if (!wardrobe[input[0]].ContainsKey(input[j]))
                    {
                        wardrobe[input[0]].Add(input[j], 0);
                    }
                    wardrobe[input[0]][input[j]] += 1;
                }
            }
            var check = Console.ReadLine().Split(' ').ToList();
            foreach (var item in wardrobe)
            {
                Console.WriteLine($"{item.Key} clothes:");
                foreach (var clothes in item.Value)
                {
                    if (item.Key == check[0] && clothes.Key == check[1])
                    {
                        Console.WriteLine($"* {clothes.Key} - {clothes.Value} (found!)");
                    }
                    else
                    {
                        Console.WriteLine($"* {clothes.Key} - {clothes.Value}");
                    }
                }
            }
        }
    }
}
