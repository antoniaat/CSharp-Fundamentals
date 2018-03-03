using System;
using System.Text;

namespace Animals
{
    internal class Animal : ISoundProducable
    {
        public const string ErrorMessage = "Invalid input!";

        private string name;
        private int age;
        private string gender;

        public Animal(string name, int age, string gender)
        {
            this.Name = name;
            this.Age = age;
            this.Gender = gender;
        }

        public string Name
        {
            get => this.name;
            set
            {
                NotEmptyValidation(value);
                this.name = value;
            }
        }

        public int Age
        {
            get => this.age;
            set
            {
                if (value <= 0)
                {
                    throw new ArgumentException(ErrorMessage);
                }
                this.age = value;
            }
        }

        public string Gender
        {
            get => gender;
            set
            {
                NotEmptyValidation(value);
                if (value != "Male" && value != "Female")
                {
                    throw new ArgumentException("Invalid input!");
                }
                gender = value;
            }
        }

        private static void NotEmptyValidation(string value)
        {
            if (value == null) throw new ArgumentNullException(ErrorMessage);
            if (string.IsNullOrWhiteSpace(value)) throw new ArgumentException(ErrorMessage);
        }

        public virtual string ProduceSound()
        {
            return "Some noise..";
        }

        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.AppendLine($"{this.GetType().Name}");
            sb.AppendLine($"{this.Name} {this.Age} {this.Gender}");
            sb.AppendLine($"{this.ProduceSound()}");

            var result = sb.ToString().TrimEnd();
            return result;
        }
    }
}