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
                 
                var inputParams = inputLine.Split().ToList();
                string command = inputParams[0];
                inputParams.RemoveAt(0);

                string result = null;

                try
                {
                    switch (command)
                    {
                        case "JoinParty":
                            result = dungeon.JoinParty(inputParams.ToArray());
                            break;

                        case "AddItemToPool":
                            result = dungeon.AddItemToPool(inputParams.ToArray());
                            break;
                        case "PickUpItem":
                            result = dungeon.PickUpItem(inputParams.ToArray());
                            break;

                        case "UseItem":
                            result = dungeon.UseItem(inputParams.ToArray());
                            break;

                        case "UseItemOn":
                            result = dungeon.UseItemOn(inputParams.ToArray());
                            break;

                        case "GiveCharacterItem":
                            result = dungeon.GiveCharacterItem(inputParams.ToArray());
                            break;

                        case "GetStats":
                            dungeon.GetStats();
                            break;

                        case "Attack":
                            result = dungeon.Attack(inputParams.ToArray());
                            break;

                        case "Heal":
                            result = dungeon.Heal(inputParams.ToArray());
                            break;

                        case "EndTurn":
                            result = dungeon.EndTurn(inputParams.ToArray());
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