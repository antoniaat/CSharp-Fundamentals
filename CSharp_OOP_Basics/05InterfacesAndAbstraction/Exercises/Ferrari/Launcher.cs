using System;

namespace Ferrari
{
    public class Launcher
    {
        public static void Main()
        {
            var name = Console.ReadLine();
            var car = new Ferrari(name);

            Console.Write(car.Model + '/');
            car.Brakes();
            car.Gas();
            Console.Write(car.Driver);
        }
    }
}
