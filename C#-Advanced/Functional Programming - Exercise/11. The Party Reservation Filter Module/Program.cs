using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
namespace Problem_11.___Party_Reservation_Filter_Module
{
    class Program
    {
        static void Main(string[] args)
        {
            var listInvitations = Console.ReadLine().Split(" ").ToList();
            var listFilter = new List<string>();
            while (true)
            {
                var command = Console.ReadLine().Split(";").ToArray();
                if (command[0] == "Print")
                {
                    break;
                }
                var firstCommand = command[0];

                if (command[0] == "Add filter")
                {
                    listFilter.Add(command[1] + ";" + command[2]);
                }
                else if (command[0] == "Remove filter")
                {
                    listFilter.Remove(command[1] + ";" + command[2]);
                }
            }
            Func<string, string, bool> remSt = (x, y) => x.StartsWith(y);
            Func<string, string, bool> remEnd = (x, y) => x.EndsWith(y);
            Func<string, string, bool> remCon = (x, y) => x.Contains(y);
            Func<string, int, bool> remLen = (x, y) => x.Length == y;
            foreach (var item in listFilter)
            {
                var splitFilter = item.Split(";").ToArray();
                if (splitFilter[0] == "Starts with")
                {
                    listInvitations.RemoveAll(x=>remSt(x,splitFilter[1]));
                }
                else if (splitFilter[0] == "Ends with")
                {
                    listInvitations.RemoveAll(x => remEnd(x, splitFilter[1]));
                }
                else if (splitFilter[0] == "Length")
                {
                    listInvitations.RemoveAll(x => remLen(x, int.Parse(splitFilter[1])));
                }
                else if (splitFilter[0] == "Contains")
                {
                    listInvitations.RemoveAll(x => remCon(x, splitFilter[1]));
                }
            }
                Console.WriteLine(string.Join(" ", listInvitations));
        }
    }
}
