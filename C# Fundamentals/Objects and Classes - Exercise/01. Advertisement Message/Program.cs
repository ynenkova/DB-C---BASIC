using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
namespace _1._Advertisement_Message
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            string[] phrasse = { "Excellent product.", "Such a great product.", "I always use that product.", "Best product of its category.", "Exceptional product.", "I can’t live without this product." };
            string[] events = { "Now I feel good.", "I have succeeded with this product.", "Makes miracles. I am happy of the results!", "I cannot believe but now I feel awesome.", "Try it yourself, I am very satisfied.", "I feel great!" };
            string[] name= { "Diana", "Petya", "Stella", "Elena", "Katya", "Iva", "Annie", "Eva"};
            string[] city = { "Burgas", "Sofia", "Plovdiv", "Varna", "Ruse" };
            Random random = new Random();
            for (int i = 0; i <n; i++)
            {
                string phrase = phrasse[random.Next(0,phrasse.Length)];
                string even = events[random.Next(0,events.Length)];
                string names = name[random.Next(0,name.Length)];
                string town = city[random.Next(0,city.Length)];
                Console.WriteLine($"{phrase} {even} {names} – {town}.");
            }
        }
    }
}
