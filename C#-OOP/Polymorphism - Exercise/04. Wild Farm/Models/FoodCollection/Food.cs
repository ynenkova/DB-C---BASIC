using System;
using System.Collections.Generic;
using System.Text;

namespace WildFarm.FoodCollection
{
   public abstract class Food
    {
        protected Food(int quantity)
        {
            this.Quantity = quantity;
        }

        public int Quantity { get; set; }
    }
}
