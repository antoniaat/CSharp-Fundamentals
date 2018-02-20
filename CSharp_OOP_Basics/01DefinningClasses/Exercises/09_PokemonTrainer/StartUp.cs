using System;
using System.Collections.Generic;
using System.Linq;

public class StartUp
{
    private const int StartingBadges = 0;

    public static void Main()
    {
        var trainers = new List<Trainer>();

        AddTrainersAndPokemons(trainers);
        ReadCommands(trainers);
        PrintTrainers(trainers);
    }

    private static void PrintTrainers(List<Trainer> trainers)
    {
        foreach (var trainer in trainers.OrderByDescending(x => x.Badges))
        {
            Console.WriteLine($"{trainer.Name} {trainer.Badges} {trainer.Pokemons.Count}");
        }
    }

    private static void ReadCommands(List<Trainer> trainers)
    {
        string command;
        while ((command = Console.ReadLine()) != "End")
        {
            if (command == "Fire")
            {
                foreach (var trainer in trainers)
                {
                    trainer.Pokemons.RemoveAll(x => x.Health <= 0);

                    if (trainer.Pokemons.Any(x => x.Element == command))
                    {
                        trainer.Badges++;
                    }

                    LoseHealth(trainer);
                }
            }
            else if (command == "Water")
            {
                foreach (var trainer in trainers)
                {
                    trainer.Pokemons.RemoveAll(x => x.Health <= 0);

                    if (trainer.Pokemons.Any(x => x.Element == command))
                    {
                        trainer.Badges++;
                    }

                    LoseHealth(trainer);
                }
            }
            else if (command == "Electricity")
            {
                foreach (var trainer in trainers)
                {
                    trainer.Pokemons.RemoveAll(x => x.Health <= 0);

                    if (trainer.Pokemons.Any(x => x.Element == command))
                    {
                        trainer.Badges++;
                    }

                    LoseHealth(trainer);
                }
            }
        }
    }

    private static void LoseHealth(Trainer trainer)
    {
        if (trainer.Badges == 0)
        {
            trainer.Pokemons.ForEach(x => x.Health -= 10);
        }
    }

    private static void AddTrainersAndPokemons(List<Trainer> trainers)
    {
        string inputLine;
        while ((inputLine = Console.ReadLine()) != "Tournament")
        {
            var tokens = inputLine.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

            var trainerName = tokens[0];
            var pokemonName = tokens[1];
            var pokemonElement = tokens[2];
            var pokemonHealth = int.Parse(tokens[3]);

            var pokemon = new Pokemon(pokemonName, pokemonElement, pokemonHealth);
            var trainer = trainers.FirstOrDefault(t => t.Name == trainerName);

            if (trainer == null)
            {
                trainer = new Trainer(trainerName, StartingBadges);
                trainers.Add(trainer);
            }

            trainer.Pokemons.Add(pokemon);
        }
    }
}