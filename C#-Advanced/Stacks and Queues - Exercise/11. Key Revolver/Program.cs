using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
namespace _11._Key_Revolver
{
    class Program
    {
        static void Main(string[] args)
        {
            int priceBullet = int.Parse(Console.ReadLine());
            int sizeBarrel = int.Parse(Console.ReadLine());

            var allbullets = Console.ReadLine().Split(" ").Select(int.Parse).ToArray();
            var bullets = new Stack<int>(allbullets);

            var alllocks = Console.ReadLine().Split(" ").Select(int.Parse).ToArray();
            var locks = new Queue<int>(alllocks);

            int value = int.Parse(Console.ReadLine());
            int bulletOut = bullets.Count();
            int countBullet = 0;
            int countIsBarrelEmpty = sizeBarrel;

            while (sizeBarrel != 0)
            {
                sizeBarrel--;

                for (int i = 1; i <= bulletOut; i++)
                {
                    if (!locks.Any())
                    {
                        break;
                    }
                    int first = bullets.Pop();
                    int second = locks.Peek();
                    countBullet++;
                    if (first <= second)
                    {
                        locks.Dequeue();
                        Console.WriteLine("Bang!");
                    }
                    else
                    {
                        Console.WriteLine("Ping!");

                    }
                }

                if (!locks.Any())
                {
                    break;
                }
                if (sizeBarrel == 0)
                {
                    break;
                }
                if (bulletOut == countBullet)
                {
                    break;
                }
                Console.WriteLine("Reloading!");
            }
            int price = value - (countBullet * priceBullet);
            if (locks.Any())
            {
                Console.WriteLine($"“Couldn't get through. Locks left: {locks.Count}”");
            }
            else
            {
                Console.WriteLine($"{bullets.Count} bullets left. Earned ${price}");
            }
        }
    }
}
