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
        while (true)
        {
            var inputLine = Console.ReadLine();

            var inputParams = inputLine
                .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .ToList();

            var commandResult = this.DispatchCommand(inputParams);
            if (commandResult != null) Console.Write(commandResult);

            if (inputLine == "Quit")
            {
                Console.Write(this.nation.WarsResult.ToString());
                return;
            }
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
                result = this.nation.GetStatus(inputParams[0]);
                break;

            case "War":
                this.nation.IssueWar(inputParams[0]);
                break;
        }

        return result;
    }
}