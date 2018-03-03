using Animals.Animals;
using System;
using System.Collections.Generic;

namespace Animals
{
    public class Launcher
    {
        public static void Main()
        {
            var animals = new List<Animal>();

            string type;
            while ((type = Console.ReadLine()) != "Beast!")
            {
                try
                {
                    CreateAndAddAnimals(animals, type);
                }
                catch (ArgumentException ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }

            PrintAnimals(animals);
        }

        private static void CreateAndAddAnimals(List<Animal> animals, string type)
        {
            var tokens = Console.ReadLine()
                ?.Split();
            if (tokens == null) return;

            var name = tokens[0];
            var age = int.Parse(tokens[1]);

            string gender = null;
            if (tokens.Length == 3)
            {
                gender = tokens[2];
            }

            switch (type)
            {
                case "Cat":
                    var cat = new Cat(name, age, gender);
                    animals.Add(cat);
                    break;

                case "Dog":
                    var dog = new Dog(name, age, gender);
                    animals.Add(dog);
                    break;

                case "Frog":
                    var frog = new Frog(name, age, gender);
                    animals.Add(frog);
                    break;

                case "Kitten":
                    var kitten = new Kitten(name, age);
                    animals.Add(kitten);
                    break;

                case "Tomcat":
                    var tomcat = new Tomcat(name, age);
                    animals.Add(tomcat);
                    break;

                default:
                    throw new ArgumentException("Invalid input!");
            }
        }

        private static void PrintAnimals(List<Animal> animals)
        {
            foreach (var animal in animals)
            {
                Console.WriteLine(animal);
            }
        }
    }
}