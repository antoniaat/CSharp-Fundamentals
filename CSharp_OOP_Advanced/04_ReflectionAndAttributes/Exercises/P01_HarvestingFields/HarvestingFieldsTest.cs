using System.Reflection;

namespace P01_HarvestingFields
{
    using System;

    public class HarvestingFieldsTest
    {
        public static void Main()
        {
            ReadInputLines();
        }

        private static void ReadInputLines()
        {
            var harvestingFields = new HarvestingFields();
            Type classType = harvestingFields.GetType();

            string inputLine;
            while ((inputLine = Console.ReadLine()) != "HARVEST")
            {
                switch (inputLine)
                {
                    case "private":
                        PrintPrivateFields(classType);
                        break;

                    case "protected":
                        PrintProtectedFields(classType);
                        break;

                    case "public":
                        PrintPublicFields(classType);
                        break;

                    case "all":
                        PrintAllFields(classType);
                        break;
                }
            }
        }

        private static void PrintAllFields(Type classType)
        {
            FieldInfo[] classPublicFields = classType.GetFields(
                BindingFlags.Instance | BindingFlags.Public | BindingFlags.GetField | BindingFlags.NonPublic);

            foreach (var fieldInfo in classPublicFields)
            {
                if (fieldInfo.IsPrivate)
                {
                    Console.WriteLine($"private {fieldInfo.FieldType.Name} {fieldInfo.Name}");
                }
                else if (fieldInfo.IsFamily)
                {
                    Console.WriteLine($"protected {fieldInfo.FieldType.Name} {fieldInfo.Name}");
                }
                else if (fieldInfo.IsPublic)
                {
                    Console.WriteLine($"public {fieldInfo.FieldType.Name} {fieldInfo.Name}");
                }
                else if (fieldInfo.IsAssembly)
                {
                    Console.WriteLine($"internal {fieldInfo.FieldType.Name} {fieldInfo.Name}");
                }
            }
        }

        private static void PrintPublicFields(Type classType)
        {
            FieldInfo[] classPublicFields = classType.GetFields(
                BindingFlags.Instance | BindingFlags.Public | BindingFlags.GetField);

            foreach (var fieldInfo in classPublicFields)
            {
                if (fieldInfo.IsPublic)
                {
                    Console.WriteLine($"public {fieldInfo.FieldType.Name} {fieldInfo.Name}");
                }
            }
        }

        private static void PrintProtectedFields(Type classType)
        {
            FieldInfo[] classProtectedFields = classType.GetFields(
                BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.GetField);

            foreach (var fieldInfo in classProtectedFields)
            {
                if (fieldInfo.IsFamily)
                {
                    Console.WriteLine($"protected {fieldInfo.FieldType.Name} {fieldInfo.Name}");
                }
            }
        }

        private static void PrintPrivateFields(Type classType)
        {
            FieldInfo[] classPrivateFields = classType.GetFields(
                   BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.GetField);

            foreach (var fieldInfo in classPrivateFields)
            {
                if (fieldInfo.IsPrivate)
                {
                    Console.WriteLine($"private {fieldInfo.FieldType.Name} {fieldInfo.Name}");
                }
            }
        }
    }
}