using System;
using System.Collections.Generic;
using System.Linq;
namespace _8
{
    class Program
    {
        static void Main(string[] args)
        {
            var company = new Dictionary<string, List<string>>();
            while (true)
            {
                string[] companyAndEmployee = Console.ReadLine().Split("->");
                if (companyAndEmployee[0] == "End")
                {
                    break;
                }
                
                if (!company.ContainsKey(companyAndEmployee[0]))
                {
                    company.Add(companyAndEmployee[0], new List<string>());
                    company[companyAndEmployee[0]].Add(companyAndEmployee[1]);
                }
                else
                {
                    if (!company[companyAndEmployee[0]].Contains(companyAndEmployee[1]))
                    {
                        company[companyAndEmployee[0]].Add(companyAndEmployee[1]);
                    }
                }
            }
            company = company.OrderBy(x => x.Key).ToDictionary(x => x.Key, x => x.Value);
            foreach (var item in company)
            {
                Console.WriteLine($"{item.Key}");
                foreach (var id in item.Value)
                {
                    Console.WriteLine($"--{id}");
                }
            }
        }
    }
}
