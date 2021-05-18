using System;
using System.Collections.Generic;
using System.Text;
using WildFarm.FoodCollection;

namespace WildFarm.Factory
{
   public static class FoodFactory
    {
        public static Food Creater(string[]input)
        {
            var quantity =int.Parse( input[1]);
            switch (input[0])
            {
                case nameof(Vegetable):
                    return new Vegetable(quantity);
                case nameof(Fruit):
                    return new Fruit(quantity);
                case nameof(Meat):
                    return new Meat(quantity);
                case nameof(Seeds):
                    return new Seeds(quantity);
                default:
                    throw new ArgumentException($"{input[0]} is not a valid Food");
            }
        }
    }
}
