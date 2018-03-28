using System;
using System.Collections.Generic;
using System.Linq;
using DungeonsAndCodeWizards.Core;

namespace DungeonsAndCodeWizards
{
    public class StartUp
    {
        public static void Main()
        {
            var dungeon = new DungeonMaster();

            while (!dungeon.IsGameOver())
            {
                var inputLine = Console.ReadLine();

                if (string.IsNullOrEmpty(inputLine)) break;
                 
                var inputParams = inputLine.Split().ToArray();
                string command = inputParams[0];

                string result = null;

                try
                {
                    switch (command)
                    {
                        case "JoinParty":
                            result = dungeon.JoinParty(inputParams);
                            break;

                        case "AddItemToPool":
                            result = dungeon.AddItemToPool(inputParams);
                            break;
                        case "PickUpItem":
                            result = dungeon.PickUpItem(inputParams);
                            break;

                        case "UseItem":
                            result = dungeon.UseItem(inputParams);
                            break;

                        case "UseItemOn":
                            result = dungeon.UseItemOn(inputParams);
                            break;

                        case "GiveCharacterItem":
                            result = dungeon.GiveCharacterItem(inputParams);
                            break;

                        case "GetStats":
                            dungeon.GetStats();
                            break;

                        case "Attack":
                            result = dungeon.Attack(inputParams);
                            break;

                        case "Heal":
                            result = dungeon.Heal(inputParams);
                            break;

                        case "EndTurn":
                            result = dungeon.EndTurn(inputParams);
                            break;

                        case "IsGameOver":
                            dungeon.IsGameOver();
                            break;
                    }

                }
                catch (Exception ex)
                {
                    if (ex is ArgumentException)
                    {
                        Console.WriteLine("Parameter Error: " + ex.Message);
                    }

                    else if (ex is InvalidOperationException)
                    {
                        Console.WriteLine($"Invalid Operation: " + ex.Message);
                    }
                }
                
                Console.WriteLine(result);
            }

            Console.WriteLine("Final stats:");
            Console.Write(dungeon.GetStats());
        }

        //private static string DispatchCommand(string[] inputParams)
        //{

        //    //string result = null;

        //    //switch (command)
        //    //{
        //    //    case "JoinParty":
        //    //        result = .JoinParty(inputParams);
        //    //        break;

        //    //    //case "RegisterProvider":
        //    //    //    result = this.manager.RegisterProvider(inputParams);
        //    //    //    break;

        //    //    //case "Day":
        //    //    //    result = this.manager.Day();
        //    //    //    break;

        //    //    //case "Mode":
        //    //    //    result = this.manager.Mode(inputParams);
        //    //    //    break;

        //    //    //case "Check":
        //    //    //    result = this.manager.Check(inputParams);
        //    //    //    break;

        //    //    //case "Shutdown":
        //    //    //    result = this.manager.ShutDown();
        //    //    //    this.isRunning = false;
        //    //    //    break;
        //    //}

        //    //return result;
        //}
    }
}