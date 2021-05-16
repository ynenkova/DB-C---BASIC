using System;
using System.Linq;

namespace Froggy
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            var list = Console.ReadLine()
                            .Split(new char[] { ' ', ',' }, StringSplitOptions.RemoveEmptyEntries)
                            .Select(int.Parse).ToArray();
            var lakes = new Lake(list);
            Console.WriteLine(string.Join(", ",lakes));
        }
    }
}
