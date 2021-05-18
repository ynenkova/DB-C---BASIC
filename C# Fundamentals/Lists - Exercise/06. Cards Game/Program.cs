using System;
using System.Linq;
using System.Collections.Generic;
namespace _6._Cards_Game
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> firstHand = Console.ReadLine().Split().Select(int.Parse).ToList();
            List<int> secondHand = Console.ReadLine().Split().Select(int.Parse).ToList();
            for (int i = 0; i < firstHand.Count+1; i++)
            {
                i = 0;
                for (int j = 0; j < secondHand.Count; j++)
                {
                    if (firstHand[i] > secondHand[j])
                    {
                        firstHand.Add(firstHand[i]);
                        firstHand.Add(secondHand[j]);
                        firstHand.RemoveAt(0);
                        secondHand.RemoveAt(0);
                        break;
                    }
                    if (firstHand[i] < secondHand[j])
                    {
                        secondHand.Add(secondHand[j]);
                        secondHand.Add(firstHand[i]);
                        secondHand.RemoveAt(0);
                        firstHand.RemoveAt(0);
                        break;
                    }
                    if (firstHand[i] == secondHand[j])
                    {
                        secondHand.RemoveAt(j);
                        firstHand.RemoveAt(i);
                        break;
                    }
                }
                if (firstHand.Count == 0 || secondHand.Count == 0)
                {
                    break;
                }
            }
            if (firstHand.Count != 0)
            {
                Console.WriteLine($"First player wins! Sum: {firstHand.Sum()}");
            }
            else
            {
                Console.WriteLine($"Second player wins! Sum: {secondHand.Sum()}");
            }

        }
    }
}
