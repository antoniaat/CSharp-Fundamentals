using System.Linq;
using System.Reflection;

namespace P02_BlackBoxInteger
{
    using System;

    public class BlackBoxIntegerTests
    {
        public static void Main()
        {
            ReadInputLines();
        }

        private static void ReadInputLines()
        {
            Type classType = typeof(BlackBoxInteger);
            FieldInfo innerValue = classType.GetField("innerValue", BindingFlags.Instance | BindingFlags.NonPublic);
            object instance = Activator.CreateInstance(classType, true);

            string inputLine;
            while ((inputLine = Console.ReadLine()) != "END")
            {
                var tokens = inputLine
                    ?.Split(new[] { ' ', '_' }, StringSplitOptions.RemoveEmptyEntries);

                int param = int.Parse(tokens[1]);
                MethodInfo method = instance
                    .GetType()
                    .GetMethods(BindingFlags.Instance | BindingFlags.NonPublic)
                    .First(m => m.Name == tokens[0]);

                method.Invoke(instance, new object[] { param });
                Console.WriteLine(innerValue.GetValue(instance));
            }
        }
    }
}
