namespace ForumSystem.DataInitializer
{
    using ForumSystem.Models;
    using System;
    using System.Collections.Generic;

    internal class UserGenerator
    {
        internal IEnumerable<User> CreateUsers()
        {
            var usernames = new string[]
            {
                "NaydenVitanov",
                "DeyanTanev",
                "DesislavPetkov",
                "DyakonHristov",
                "MilenTodorov",
                "AleksanderKishishev",
                "IlianStoev",
                "MilenBalkanski",
                "KostadinNakov",
                "PetarStrashilov",
                "BozhidaraValova",
                "LyubinaKostova",
                "RadkaAntonova",
                "VladimiraBlagoeva",
                "BozhidaraRysinova",
                "BorislavaDimitrova",
                "AneliaVelichkova",
                "VioletaKochanova",
                "LyubovIvanova",
                "BlagorodnaDineva",
                "DesislavBachev",
                "MihaelBorisov",
                "VentsislavPetrova",
                "HristoKirilov",
                "PenkoDachev",
                "NikolaiZhelyaskov",
                "PetarTsvetanov",
                "SpasDimitrov",
                "StankoPopov",
                "MiroKochanov",
                "PeshoStamatov",
                "RogerPorter",
                "JeffreySnyder",
                "LouisColeman",
                "GeorgePowell",
                "JaneOrtiz",
                "RandyMorales",
                "LisaDavis",
            };

            var users = new List<User>();

            foreach (var username in usernames)
            {
                users.Add(new User()
                {
                    Username = username,
                    Password = Guid.NewGuid().ToString()
                });
            }

            return users;
        }
    }
}