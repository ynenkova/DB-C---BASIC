﻿using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
namespace _4
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            Dictionary<int, int> numbers = new Dictionary<int, int>();
            for (int i = 0; i < n; i++)
            {
                int num = int.Parse(Console.ReadLine());
                if (!numbers.ContainsKey(num))
                {
                    numbers.Add(num, 0);
                }
                numbers[num] += 1;
            }
            
            foreach (var item in numbers.OrderByDescending(x=>x.Value))
            {
                Console.WriteLine(item.Key);
                return;
            }
        }
    }
}
