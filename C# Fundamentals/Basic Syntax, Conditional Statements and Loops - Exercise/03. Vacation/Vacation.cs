using System;

namespace _5._Bomb_Numbers
{
    class Program
    {
        static void Main(string[] args)
        {
            int people = int.Parse(Console.ReadLine());
            string type = Console.ReadLine();
            string days = Console.ReadLine();
            decimal pricePerson=0;
            switch (type)
            {
                case "Students":
                    switch (days)
                    {
                        case "Friday":
                            pricePerson = 8.45M;
                            break;
                        case "Saturday":
                            pricePerson = 9.8M;
                            break;
                        case "Sunday":
                            pricePerson = 10.46M;
                            break;
                    }
                    break;
                case "Business":
                    switch (days)
                    {
                        case "Friday":
                            pricePerson = 10.90M;
                            break;
                        case "Saturday":
                            pricePerson = 15.60M;
                            break;
                        case "Sunday":
                            pricePerson = 16;
                            break;
                    }
                    break;
                case "Regular":
                    switch (days)
                    {
                        case "Friday":
                            pricePerson = 15;
                            break;
                        case "Saturday":
                            pricePerson = 20;
                            break;
                        case "Sunday":
                            pricePerson = 22.5M;
                            break;
                    }
                    break;
            }
            decimal total = pricePerson * people;
            if (type=="Students"&&people>=30)
            {
                total = total * 0.85M;
            }
            if (type == "Business" && people >= 100)
            {
                total -= pricePerson * 10;
            }
            if (type == "Regular" && people >= 10&&people<=20)
            {
                total=total*0.95M;
            }
            Console.WriteLine($"Total price: {total:f2}");
        }
    }
}
