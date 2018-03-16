using System;
using System.Collections.Generic;
using System.Linq;

public class Engine
{
    private NationsBuilder nation;

    public Engine(NationsBuilder nation)
    {
        this.nation = nation;
    }

    public void Run()
    {
        string inputLine;
        while ((inputLine = Console.ReadLine()) != "Quit")
        {
            var inputParams = inputLine
                .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .ToList();

            var commandResult = this.DispatchCommand(inputParams);
            if (commandResult != null) Console.WriteLine(commandResult);
        }
    }

    private string DispatchCommand(List<string> inputParams)
    {
        string command = inputParams[0];
        inputParams.RemoveAt(0);

        string result = null;

        switch (command)
        {
            case "Bender":
                this.nation.AssignBender(inputParams);
                break;

            case "Monument":
                this.nation.AssignMonument(inputParams);
                break;

            case "Status":
                //   result = this.nation.Day();
                break;

            case "War":
                // result = this.nation.Mode(inputParams);
                break;
        }

        return result;
    }
}
