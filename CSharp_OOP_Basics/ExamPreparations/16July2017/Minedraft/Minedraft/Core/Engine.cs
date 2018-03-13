using System;
using System.Collections.Generic;
using System.Linq;

public class Engine
{
    private bool isRunning;
    private readonly DraftManager manager;

    public Engine(DraftManager manager)
    {
        this.manager = manager;
    }

    public void Run()
    {
        this.isRunning = true;

        while (this.isRunning)
        {
            string inputLine = Console.ReadLine();
            List<string> inputParams = inputLine.Split().ToList();
            string commandResult = this.DispatchCommand(inputParams);
            Console.WriteLine(commandResult);
        }
    }

    private string DispatchCommand(List<string> inputParams)
    {
        string command = inputParams[0];
        inputParams.RemoveAt(0);

        string result = null;

        switch (command)
        {
            case "RegisterHarvester":
                result = this.manager.RegisterHarvester(inputParams);
                break;
            case "RegisterProvider":
                result = this.manager.RegisterProvider(inputParams);
                break;
            case "Day":
                result = this.manager.Day();
                break;
            case "Mode":
                result = this.manager.Mode(inputParams);
                break;
            case "Check":
                result = this.manager.Check(inputParams);
                break;
            case "Shutdown":
                result = this.manager.ShutDown();
                this.isRunning = false;
                break;
        }

        return result;
    }
}