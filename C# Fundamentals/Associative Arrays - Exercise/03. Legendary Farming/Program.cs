using System;
using System.Collections.Generic;
using System.Linq;
namespace _3
{
    class Program
    {
        static void Main(string[] args)
        {

            var matirials = new Dictionary<string, int>();
            matirials["shards"] = 0;
            matirials["motes"] = 0;
            matirials["fragments"] = 0;
            bool outTrue = false;
            var jumkMaterials = new Dictionary<string, int>();
            while (true)
            {
                string[] items = Console.ReadLine().ToLower().Split(" ");
                for (int i = 0; i < items.Length; i += 2)
                {
                    string name = items[i + 1];
                    int num = int.Parse(items[i]);

                    if (name == "shards")
                    {
                        matirials[name] += num;
                        if (matirials[name] >= 250)
                        {
                            Console.WriteLine("Shadowmourne obtained!");
                            matirials[name] -= 250;
                            outTrue = true;
                            break;
                        }
                    }
                    else if (name == "fragments")
                    {
                        matirials[name] += num;
                        if (matirials[name] >= 250)
                        {

                            Console.WriteLine("Valanyr obtained!");
                            matirials[name] -= 250;
                            outTrue = true;
                            break;
                        }
                    }
                    else if (name == "motes")
                    {
                        matirials[name] += num;
                        if (matirials[name] >= 250)
                        {
                            Console.WriteLine("Dragonwrath obtained!");
                            matirials[name] -= 250;
                            outTrue = true;
                            break;
                        }
                    }
                    else
                    {
                        if (!jumkMaterials.ContainsKey(name))
                        {
                            jumkMaterials[name] = 0;
                        }
                        jumkMaterials[name] += num;
                    }
                }
                if (outTrue)
                {
                    break;
                }
            }

            matirials = matirials.OrderByDescending(x => x.Value).ThenBy(x => x.Key).ToDictionary(x => x.Key, x => x.Value);
            jumkMaterials = jumkMaterials.OrderBy(x => x.Key).ToDictionary(x => x.Key, x => x.Value);
            foreach (var kvp in matirials)
            {
                Console.WriteLine($"{kvp.Key}: {kvp.Value}");
            }
            foreach (var kvpj in jumkMaterials)
            {
                Console.WriteLine($"{kvpj.Key}: {kvpj.Value}");
            }
        }
    }
}
