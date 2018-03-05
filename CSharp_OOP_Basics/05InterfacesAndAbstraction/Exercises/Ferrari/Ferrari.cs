using System;

namespace Ferrari
{
    internal class Ferrari : Icar
    {
        public Ferrari(string driver)
        {
            this.Model = "488-Spider";
            this.Driver = driver;
        }

        public string Model { get; set; }
        public string Driver { get; set; }

        public void Brakes()
        {
            Console.Write("Brakes!/");
        }

        public void Gas()
        {
            Console.Write("Go go!/");
        }
    }
}