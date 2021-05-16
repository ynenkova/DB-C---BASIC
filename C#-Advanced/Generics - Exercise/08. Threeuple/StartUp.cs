using System;
using System.Linq;

namespace Threeuple
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            var first = Console.ReadLine().Split();
            var firstName =$"{first[0]} {first[1]}";
            var address = first[2];
            var town = first[4].Length==0 ?$"{first[3]}":$"{first[3]} {first[4]}";

            var second = Console.ReadLine().Split();
            var nameDrunk = second[0];
            var liters = int.Parse(second[1]);
            var drunkResult = !second[2].Equals("drunk") ? "False" : "True";

            var thirth = Console.ReadLine().Split();
            var name = thirth[0];
            var accountBalance = double.Parse(thirth[1]);
            var bankName = thirth[2];

            var firstTuple = new Tuple<string,string,string>(firstName, address, town);
            var secondTuple = new Tuple<string, int, string>(nameDrunk, liters, drunkResult);
            var thirthTuple = new Tuple<string, double, string>(name, accountBalance, bankName);

            Console.WriteLine(firstTuple);
            Console.WriteLine(secondTuple);
            Console.WriteLine(thirthTuple);
        }
    }
}
