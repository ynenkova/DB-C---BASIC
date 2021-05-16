using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
namespace _8
{
    class Program
    {
        static void Main(string[] args)
        {
            var ranks = new Dictionary<string, Dictionary<string, int>>();
            var contestAndPassword = new Dictionary<string, string>();

            AddContestAndPasword(contestAndPassword);

            FillRanks(ranks, contestAndPassword);
            var usersTotalPoint = ranks.OrderByDescending(x => x.Value.Values.Sum());
            foreach (var item in usersTotalPoint.Take(1))
            {
                Console.WriteLine($"Best candidate is {item.Key} with total {item.Value.Values.Sum()} points.");
            }
            Console.WriteLine("Ranking: ");
            ranks = ranks.OrderBy(x => x.Key).ToDictionary(x => x.Key, x => x.Value);
            foreach (var user in ranks)
            {
                Console.WriteLine(user.Key);
                foreach (var contest in user.Value.OrderByDescending(x=>x.Value))
                {
                    Console.WriteLine($"{contest.Key} -> {contest.Value}");
                }
            }
        }
        private static void FillRanks(Dictionary<string, Dictionary<string, int>> ranks, Dictionary<string, string> contestAndPassword)
        {
            while (true)
            {
                var text = Console.ReadLine();
                if (text == "end of submissions")
                {
                    break;
                }
                var input = text.Split(new char[] { '=', '>' }, StringSplitOptions.RemoveEmptyEntries);
                if (contestAndPassword.ContainsKey(input[0]))
                {
                    if (contestAndPassword.ContainsValue(input[1]))
                    {

                        if (!ranks.ContainsKey(input[2]))
                        {
                            ranks.Add(input[2], new Dictionary<string, int>());
                            ranks[input[2]].Add(input[0], int.Parse(input[3]));
                        }
                        else
                        {
                            if (!ranks[input[2]].ContainsKey(input[0]))
                            {
                                ranks[input[2]].Add(input[0], int.Parse(input[3]));

                            }
                            else if (ranks[input[2]][input[0]] < int.Parse(input[3]))
                            {
                                ranks[input[2]][input[0]] = int.Parse(input[3]);
                            }
                        }
                    }
                }
            }
        }
        private static void AddContestAndPasword(Dictionary<string, string> contestAndPassword)
        {
            while (true)
            {
                var text = Console.ReadLine();
                if (text == "end of contests")
                {
                    break;
                }
                var input = text.Split(':');
                contestAndPassword.Add(input[0], input[1]);
            }
        }

    }

}
