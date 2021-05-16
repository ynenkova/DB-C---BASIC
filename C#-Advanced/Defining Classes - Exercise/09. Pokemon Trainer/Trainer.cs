using System;
using System.Collections.Generic;
using System.Text;

namespace PokemonTrainer
{
    public class Trainer
    {
        private string name;
        private int banges;
        public List<Pokemon> pokemon;
        
       
        
        public Trainer(string name)
        {
            this.Name = name;
            this.Banges = 0;
            this.Pokemon = new List<Pokemon>();
        }
        
        public string Name { get; set; }
        public int? Banges { get; set; }
        public List<Pokemon> Pokemon { get; set; }

    }
}
