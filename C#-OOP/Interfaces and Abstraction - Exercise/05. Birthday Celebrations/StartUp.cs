using System;
using System.Collections.Generic;
using System.Linq;

namespace BirthdayCelebrations
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            List<IInformation> birthday = new List<IInformation>();
            string command;
            while ((command = Console.ReadLine()) != "End")
            {
                var info = command.Split(" ");
                if (info.Length == 5)
                {
                    var citizen = new Citizen(info[1], int.Parse(info[2]), info[3], info[4]);
                    birthday.Add(citizen);
                }
                else if (info[0] == "Pet")
                {
                    var pet = new Pet(info[1],info[2]);
                    birthday.Add(pet);
                }
                
            }
            var year = Console.ReadLine();
            birthday.Where(x => x.BirthDay.EndsWith(year)).Select(x => x.BirthDay).ToList().ForEach(Console.WriteLine);
        }
    }
}
