using System;
using System.Collections.Generic;
using System.Linq;

namespace Telephony
{
   public class StartUp
    {
        static void Main(string[] args)
        {
            var phoneNumbers = Console.ReadLine().Split(" ").ToArray();
            var webs = Console.ReadLine().Split(" ").ToArray();
            Smartphone smart = new Smartphone();
            StationaryPhone station= new StationaryPhone();
            foreach (var numbers in phoneNumbers)
            {
                if (numbers.Length==10)
                {
                    Console.WriteLine(smart.Call(numbers)); 
                }
                else
                {
                    Console.WriteLine(station.Dialing(numbers));
                }
            }
            foreach (var web in webs)
            {
                Console.WriteLine(smart.Brows(web));
            }
        }
    }
}
