using System;

public class StartUp
{
    public static void Main()
    {
        var mainPersonInput = Console.ReadLine();
        var familyTreeBuilder = new FamilyTreeBuilder(mainPersonInput);

        string input;
        while ((input = Console.ReadLine()) != "End")
        {
            ParseInput(input, familyTreeBuilder);
        }

        string familyTree = familyTreeBuilder.Build();
        Console.WriteLine(familyTree);
    }

    private static void ParseInput(string input, FamilyTreeBuilder familyTreeBuilder)
    {
        var tokens = input.Split(" - ");
        if (tokens.Length > 1)
        {
            ParentChild(familyTreeBuilder, tokens);
        }
        else
        {
            FullInfo(familyTreeBuilder, tokens);
        }
    }

    private static void FullInfo(FamilyTreeBuilder familyTreeBuilder, string[] tokens)
    {
        tokens = tokens[0].Split();
        var name = $"{tokens[0]} {tokens[1]}";
        var birthday = tokens[2];

        familyTreeBuilder.SetFullInfo(name, birthday);
    }

    private static void ParentChild(FamilyTreeBuilder familyTreeBuilder, string[] tokens)
    {
        var parentInput = tokens[0];
        var childInput = tokens[1];
        familyTreeBuilder.SetParentChildRelation(parentInput, childInput);
    }
}
