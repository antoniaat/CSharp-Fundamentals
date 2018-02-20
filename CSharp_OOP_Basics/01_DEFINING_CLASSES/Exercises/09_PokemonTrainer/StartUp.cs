using System;
using System.Collections.Generic;

public class StartUp
{
    public static void Main()
    {
        var trainers = new List<Trainer>();

        string inputLine;
        while ((inputLine = Console.ReadLine()) != "Tournament")
        {
            var tokens = inputLine.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

            var trainerName = tokens[0];
            var pokemonName = tokens[1];
            var pokemonElement = tokens[2];
            var pokemonHealth = int.Parse(tokens[3]);

            var pokemon = new Pokemon(pokemonName, pokemonElement, pokemonHealth);
            var trainer = new Trainer(trainerName, 0, new List<Pokemon>());

            if (trainers.Contains(trainer))
            {
                
            }
            else
            {
                trainers.Add(new Trainer(trainerName, 0, new List<Pokemon>()));
            }
        }

        string command;
        while ((command = Console.ReadLine()) != "End")
        {
            if (command == "Fire")
            {

            }
            else if (command == "Water")
            {

            }
            else if (command == "Electricity")
            {

            }
        }
    }
}
