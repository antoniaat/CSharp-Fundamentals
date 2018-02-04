namespace _07_PredicateForNames
{
    using System;
    using System.Linq;

    public class PredicateForNames
    {
        public static void Main()
        {
            var lenght = int.Parse(Console.ReadLine());
            var names = Console.ReadLine().Split(new char[] {' '}, StringSplitOptions.RemoveEmptyEntries).ToList();
            names.Where(x=> x.Length <= lenght).ToList().ForEach(Console.WriteLine);
        }
    }
}
