using System;

namespace DungeonsAndCodeWizards.Models.Characters
{
    public class Faction
    {
        private const string csharp = "CSharp";
        private const string java = "Java";

        private string name;

        public Faction(string name)
        {
            this.Name = name;
        }

        public string Name
        {
            get => this.name;
            set
            {
                if (value != csharp && value != java)
                {
                    throw new ArgumentException($"Invalid faction {value}");
                }

                this.name = value;
            }
        }
    }
}
