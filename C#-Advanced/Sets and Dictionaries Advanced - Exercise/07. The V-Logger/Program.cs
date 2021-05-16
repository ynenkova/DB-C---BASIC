using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
namespace _7
{
    class Program
    {
        static void Main(string[] args)
        {
            var vLonger = new Dictionary<string, Proba>();
            while (true)
            {
                string text = Console.ReadLine();
                if (text == "Statistics")
                {
                    break;
                }
                var split = text.Split(' ', StringSplitOptions.RemoveEmptyEntries).ToArray();

                if (split[1] == "joined")
                {
                    if (!vLonger.ContainsKey(split[0]))
                    {
                        vLonger.Add(split[0], new Proba());
                        vLonger[split[0]].Follower = new HashSet<string>();
                        vLonger[split[0]].Folling = new HashSet<string>();
                    }
                }
                else if (split[1] == "followed")
                {
                    var follwer = split[0];
                    var folling = split[2];
                    if (folling != follwer)
                    {
                        if (vLonger.ContainsKey(follwer) && vLonger.ContainsKey(folling))
                        {
                            vLonger[split[2]].Follower.Add(split[0]);
                            vLonger[split[0]].Folling.Add(split[2]);
                        }
                    }
                }
            }
            Console.WriteLine($"The V-Logger has a total of {vLonger.Keys.Count()} vloggers in its logs.");
            vLonger = vLonger.OrderByDescending(x => x.Value.Follower.Count()).
                ThenBy(x => x.Value.Folling.Count()).
                ToDictionary(x => x.Key, x => x.Value);
            var mostPopular = vLonger.First();
            int num = 1;
            Console.WriteLine($"{num}. { mostPopular.Key} : { mostPopular.Value.Follower.Count()} followers, {mostPopular.Value.Folling.Count()} following");
            foreach (var follower in mostPopular.Value.Follower.OrderBy(x => x))
            {
                Console.WriteLine($"* {follower}");
            }
            foreach (var item in vLonger.Skip(1).OrderByDescending(x => x.Value.Follower.Count()))
            {
                num++;
                Console.WriteLine($"{num}. {item.Key} : {item.Value.Follower.Count()} followers, {item.Value.Folling.Count()} following");
            }
        }
    }
    class Proba
    {
        public HashSet<string> Follower { get; set; }
        public HashSet<string> Folling { get; set; }
    }
}

