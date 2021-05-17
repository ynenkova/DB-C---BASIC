using System;
using System.Collections.Generic;
using System.Linq;

namespace BorderControl
{
   public class StartUp
    {
        static void Main(string[] args)
        {
            List<Citizens> citizens=new List<Citizens>();
            List<Robots> robots=new List<Robots>();
            while (true)
            {
                var command = Console.ReadLine().Split(" ");
                if (command[0]=="End")
                {
                    break;
                }
                if (command.Length==3)
                {
                   
                    citizens.Add(new Citizens(command[0], int.Parse(command[1]), command[2]));
                }
                else
                {
                    var rob = new Robots(command[0], command[1]);
                    robots.Add(rob);
                }
            }
            var specifiedDigits = Console.ReadLine();
            citizens.Where(c => c.Id.EndsWith(specifiedDigits))
           .Select(c => c.Id)
           .ToList()
           .ForEach(Console.WriteLine);
            robots.Where(c => c.Id.EndsWith(specifiedDigits))
          .Select(c => c.Id)
          .ToList()
          .ForEach(Console.WriteLine);
        
        }
    }
}
