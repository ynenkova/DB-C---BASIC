using System;
using System.Collections.Generic;
using System.Text;

namespace PlayersAndMonsters
{
   public abstract class Hero
    {
        private string username;
        private int level;

        protected Hero(string username, int level)
        {
            this.Username = username;
            this.Level = level;
        }

        public string Username { get => username;protected set => username = value; }
        public int Level { get => level;protected set => level = value; }
        public override string ToString()
        {
            return $"Type: {this.GetType().Name} Username: {this.Username} Level: {this.Level}";
        }

    }
}
