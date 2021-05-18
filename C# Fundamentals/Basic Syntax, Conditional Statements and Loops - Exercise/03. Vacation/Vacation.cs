using System;
 
namespace Vacation
{
    class Program
    {
        static void Main(string[] args)
        {
            int groupNum = int.Parse(Console.ReadLine());
            string typeGroup = Console.ReadLine();
            string day = Console.ReadLine();
            decimal price = 0;
           
            if (typeGroup == "Students")
            {
                if (day == "Friday")
                {
                    price = 8.45;
                }
                else if (day == "Saturday")
                {
                    price = 9.80;
                }
                else if (day == "Sunday")
                {
                    price = 10.46;
                }
 
            }
            else if (typeGroup == "Business")
            {
                if (day == "Friday")
                {
                    price = 10.90;
                }
                else if (day == "Saturday")
                {
                    price = 15.60;
                }
                else if (day == "Sunday")
                {
                    price = 16;
                }
 
            }
            else if (typeGroup == "Regular")
            {
                if (day == "Friday")
                {
                    price = 15;
                }
                else if (day == "Saturday")
                {
                    price = 20;
                }
                else if (day == "Sunday")
                {
                    price = 22.50;
                }
            }
 
            decimal totalPrice = groupNum * price;
            decimal discounted = 0;
 
            if (typeGroup == "Regular" && groupNum >= 10 && groupNum <= 20)
            {
                discounted = totalPrice * 0.05;
 
            }
            else if (typeGroup == "Business" && groupNum >= 100)
            {
                discounted = 10 * price;
 
            }
            else if (typeGroup == "Students" && groupNum >= 30)
            {
                discounted = totalPrice * 0.15;
 
            }
 
            Console.WriteLine($"Total price: {totalPrice - discounted:F2}");
        }
    }
}
