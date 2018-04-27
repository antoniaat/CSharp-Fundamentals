using System;
using System.Text;
using Last_Army.Core;
using Last_Army.IO;

namespace Last_Army
{
    class LastArmyMain
    {
        static void Main()
        {
            var input = ConsoleReader.ReadLine();
            var gameController = new GameController();
            var result = new StringBuilder();

            while (!input.Equals("Enough! Pull back!"))
            {
                try
                {
                    gameController.GiveInputToGameController(input);
                }
                catch (ArgumentException arg)
                {
                    result.AppendLine(arg.Message);
                }
                input = ConsoleReader.ReadLine();
            }

            gameController.RequestResult(result);
            ConsoleWriter.WriteLine(result.ToString());
        }
    }
}