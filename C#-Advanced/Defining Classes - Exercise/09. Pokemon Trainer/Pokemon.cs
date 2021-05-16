using System;
using System.Collections.Generic;
using System.Text;

namespace PokemonTrainer
{
    public class Pokemon
    {
        private string name;
        private string elements;
        private int health;
        public Pokemon(string name, string elements,int health)
        {
            this.Name = name;
            this.Elements = elements;
            this.Health = health;
        }
        public string Name { get; set; }
        public string Elements { get; set; }
        public int Health { get; set; }
    }
}
