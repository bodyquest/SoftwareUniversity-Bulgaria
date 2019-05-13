using System;
using System.Collections.Generic;
using System.Linq;

namespace EXRC_Pokemon_Trainer
{
    public class Program
    {
        static void Main()
        {
            string input = Console.ReadLine();
            List<Trainer> trainers = new List<Trainer>();

            while (input!= "Tournament")
            {
                string[] splittedInput = input.Split();
                string trainerName = splittedInput[0];
                string pokemonName = splittedInput[1];
                string element = splittedInput[2];
                int health = int.Parse(splittedInput[3]);

                Pokemon pokemon = new Pokemon(pokemonName, element, health);
                Trainer trainer = trainers.FirstOrDefault(x => x.Name == trainerName);

                if (trainer == null)
                {
                    trainer = new Trainer(trainerName);
                    trainers.Add(trainer);
                }

                trainer.Pokemons.Add(pokemon);
                input = Console.ReadLine();
            }

            input = Console.ReadLine();
            while (input!= "End")
            {
                foreach (var trainer in trainers)
                {
                    if (trainer.Pokemons.Any(x => x.Element == input))
                    {
                        trainer.BadgesCount++;
                    }
                    else
                    {
                        ReduceHealth(trainer.Pokemons);
                    }
                }
                
                input = Console.ReadLine();
            }

            Console.WriteLine(
                string.Join(Environment.NewLine, trainers
                .OrderByDescending(x => x.BadgesCount)));
        }

        static void ReduceHealth(List<Pokemon> pokemons)
        {
            for (int i = 0; i < pokemons.Count; i++)
            {
                Pokemon pokemon = pokemons[i];

                pokemon.Health -= 10;
                if (isDead(pokemon.Health))
                {
                    pokemons.RemoveAt(i);
                    i--;
                }
            }
        }

        static bool isDead(int pokemonHealth)
        {
            return pokemonHealth <= 0;
        }
    }
}
