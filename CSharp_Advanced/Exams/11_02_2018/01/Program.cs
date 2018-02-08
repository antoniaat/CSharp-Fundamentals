namespace _01
{
    using System;
    using System.Linq;

    public class Program
    {
        public static void Main()
        {
            var priceForEachBullet = int.Parse(Console.ReadLine());
            var sizeOfTheGunBarrel = int.Parse(Console.ReadLine());
            var bullets = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToList();
            var locks = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToList();
            var intelligence = int.Parse(Console.ReadLine());
            var sum = 0;
            var counter = 0;

            while (true)
            {
                if (bullets.Count == 0 && locks.Count > 0)
                {
                    Console.WriteLine($"Couldn't get through. Locks left: {locks.Count}"); return;
                }
                if (locks.Count == 0)
                {
                    Console.WriteLine($"{bullets.Count} bullets left. Earned ${intelligence - sum}"); return;
                }

                counter++;

                if (bullets[bullets.Count - 1] <= locks[0])
                {
                    Console.WriteLine("Bang!");
                    locks.RemoveAt(0);
                    bullets.RemoveAt(bullets.Count - 1);
                }
                else
                {
                    Console.WriteLine($"Ping!");
                    bullets.RemoveAt(bullets.Count - 1);
                }

                sum += priceForEachBullet;

                if (bullets.Count == 0 || counter != sizeOfTheGunBarrel) continue;
                Console.WriteLine($"Reloading!");
                counter = 0;
            }
        }
    }
}
