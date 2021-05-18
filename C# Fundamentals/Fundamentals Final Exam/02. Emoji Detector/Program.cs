--80 score
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Text.RegularExpressions;
namespace Second
{
    class Program
    {
        static void Main(string[] args)
        {
            var text = Console.ReadLine();
            var regexEmoji = new Regex(@"(\*{2}|:{2})([A-Z][a-z]{2,})\1");
            var regexSum=new Regex(@"\d");
            var coolThreshold = 1;
            var numbers = regexSum.Matches(text);
            var names = new List<string>();
            foreach (var number in numbers)
            {
                var num = int.Parse(number.ToString());
                coolThreshold *= num;
            }
            var countEmoji = regexEmoji.Matches(text);
            var count = countEmoji.Count();
            foreach (var name in countEmoji)
            {
                names.Add(name.ToString());
            }
            for (int i = 0; i < names.Count; i++)
            {
                var someName = names[i].ToString();
                int sum= 0;
                for (int w = 2; w < someName.Length-2; w++)
                {
                   int n =someName[w];
                    sum += n;
                }
                if (sum<coolThreshold)
                {
                    names.Remove(names[i]);
                }
            }
            if (names.Count==0)
            {
                Console.WriteLine($"Cool threshold: {coolThreshold}");
                Console.WriteLine($"{count} emojis found in the text. The cool ones are:");
            }
            else
            {
                Console.WriteLine($"Cool threshold: {coolThreshold}");
                Console.WriteLine($"{count} emojis found in the text. The cool ones are:");
                Console.WriteLine(string.Join(Environment.NewLine,names));
            }
        }
    }
}
