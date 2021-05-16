using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Scheduling
{
    class Program
    {
        static void Main(string[] args)
        {
            var tasks =new Stack<int>( Console.ReadLine().Split(", ").Select(int.Parse));
            var threads =new Queue<int>( Console.ReadLine().Split(" ").Select(int.Parse));
            var toKill = int.Parse(Console.ReadLine());
            var first = 0;
            var second = 0;
            while (true)
            {
                 first = tasks.Peek();
                 second = threads.Peek();
                if (toKill==first)
                {
                    Console.WriteLine($"Thread with value {second} killed task {toKill}");
                    Console.WriteLine($"{string.Join(" ",threads)}");
                    return;
                }
               
                if (second>=first)
                {
                    tasks.Pop();
                    threads.Dequeue();
                }
                if (second<first)
                {
                    threads.Dequeue();
                }
            }
        }
    }
}
