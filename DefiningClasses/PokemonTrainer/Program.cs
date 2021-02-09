using System;
using System.Collections.Generic;
using System.Linq;

namespace PokemonTrainer
{
    public class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, Trainer> trainers = new Dictionary<string, Trainer>();
            string line = string.Empty;
            while ((line = Console.ReadLine()) != "Tournament")
            {
                string[] trainerInfo = line.Split(" ", StringSplitOptions.RemoveEmptyEntries);
                if (!trainers.ContainsKey(trainerInfo[0]))
                    trainers.Add(trainerInfo[0], new Trainer(trainerInfo[0]));
                trainers[trainerInfo[0]].Pokemons
                    .Add(new Pokemon(trainerInfo[1], trainerInfo[2], int.Parse(trainerInfo[3])));
            }
            string command = string.Empty; // "Fire", "Water" or "Electricity"
            while ((command = Console.ReadLine()) != "End")
            {
                foreach (var trainer in trainers)
                {
                    if (trainer.Value.Pokemons.Any(p => p.Element == command))
                        trainer.Value.Badges++;
                    else
                    {
                        for (int i = 0; i < trainer.Value.Pokemons.Count; i++)
                        {
                            trainer.Value.Pokemons[i].Health -= 10;
                            if (trainer.Value.Pokemons[i].Health <= 0) 
                                trainer.Value.Pokemons.RemoveAt(i--);
                        }
                    }
                }
            }
            List<Trainer> sortedTrainers = trainers.Values.OrderByDescending(t => t.Badges).ToList();
            foreach (Trainer trainer in sortedTrainers)
                Console.WriteLine($"{trainer.Name} {trainer.Badges} {trainer.Pokemons.Count}");
        }
    }
}
