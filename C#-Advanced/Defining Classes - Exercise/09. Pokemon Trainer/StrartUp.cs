using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;

namespace PokemonTrainer
{
    public class StrartUp
    {
        static void Main(string[] args)
        {
            Dictionary<string, Trainer> allTr = new Dictionary<string, Trainer>();
            string[] argsInfo = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).ToArray();
            while (argsInfo[0] != "Tournament")
            {
                var trainerName = argsInfo[0];
                var pokemonName = argsInfo[1];
                var pokemonElements = argsInfo[2];
                var pokemonHealth = int.Parse(argsInfo[3]);
                if (!allTr.ContainsKey(trainerName))
                {
                    allTr.Add(trainerName, new Trainer(trainerName));
                }
                Trainer currtrainer = allTr[trainerName];
                Pokemon pokemon = new Pokemon(pokemonName, pokemonElements, pokemonHealth);
                currtrainer.Pokemon.Add(pokemon);
               
                argsInfo = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).ToArray();
            }
            var command = Console.ReadLine();
            while (command != "End")
            {
                foreach (var item in allTr)
                {
                    if (item.Value.Pokemon.Any(p=>p.Elements==command))
                    {
                        item.Value.Banges++;
                    }
                    else
                    {
                        foreach (var pok in item.Value.Pokemon)
                        {
                            pok.Health -= 10;
                        }
                        item.Value.Pokemon.RemoveAll(x => x.Health <=0);
                    }
                }
                command = Console.ReadLine();
            }
            var result = allTr.OrderByDescending(x => x.Value.Banges).ToDictionary(x=>x.Key,v=>v.Value);
            foreach (var item in result)
            {
                Console.WriteLine($"{item.Key} {item.Value.Banges} {item.Value.Pokemon.Count}");
            }
           
        }
    }
}
