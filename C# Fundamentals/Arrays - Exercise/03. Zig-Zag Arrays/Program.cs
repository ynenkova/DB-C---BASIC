using System;
using System.Linq;
namespace _3._Zig_Zag_Arrays
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int[] first = new int[n];
            int[] second = new int[n];
            for (int i = 0; i < n; i++)
            {
                int[] line = Console.ReadLine().Split().Select(int.Parse).ToArray();

                if (i % 2 != 0)
                {
                    second[i] = line[0];
                    first[i] = line[1];
                }
                else
                {
                    first[i] = line[0];
                    second[i] = line[1];
                }
                
            }
            Console.WriteLine(string.Join(" ", first));
            Console.WriteLine(string.Join(" ", second));
        }
    }
}
