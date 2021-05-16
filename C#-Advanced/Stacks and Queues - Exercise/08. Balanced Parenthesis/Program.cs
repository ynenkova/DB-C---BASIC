using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
namespace _8.__Balanced_Parentheses
{
    class Program
    {
        static void Main(string[] args)
        {
            var charecter = Console.ReadLine();
            var opashka = new Queue<char>();
            if (charecter.Length % 2 == 0)
            {
                for (int i = 0; i < charecter.Length; i++)
                {
                    if (charecter.Length/2==i)
                    {
                        break;
                    }
                    opashka.Enqueue(charecter[i]);//[(      ])
                }
                var stack = new Stack<char>();
                for (int j = charecter.Length/2; j < charecter.Length; j++)
                {
                    stack.Push(charecter[j]);
                }
                while (true)
                {
                    char first = opashka.Dequeue();
                    char second = stack.Pop();
                    if (first=='{'&&second!='}'|| first == '(' && second != ')'|| first == '[' && second != ']')
                    {
                        Console.WriteLine("NO");
                        return;
                    }
                    if (!stack.Any())
                    {
                        Console.WriteLine("YES");
                        return;
                    }
                }
            }
            else
            {
                Console.WriteLine("NO");
            }
            
        }
    }
}
