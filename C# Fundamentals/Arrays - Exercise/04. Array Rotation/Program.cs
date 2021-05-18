using System;
using System.Linq;
namespace _4._Array_Rotation
{
    class Program
    {
        static void Main(string[] args)
        {


            int[] line = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int n = int.Parse(Console.ReadLine());
            for (int i = 0; i < n; i++)
            {
                int firstNum = line[0];
                for (int a = 0; a < line.Length - 1; a++)
                {
                    line[a] = line[a + 1];

                }
                line[line.Length - 1] = firstNum;
            }
            Console.WriteLine(string.Join(" ", line));
        }
    }
}
