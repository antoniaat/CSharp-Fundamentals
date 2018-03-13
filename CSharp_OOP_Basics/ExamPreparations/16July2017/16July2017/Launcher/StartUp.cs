using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Launcher
{
    public class StartUp
    {
        
        public static void Main()
        {

            var draftmanager = new DraftManager();

            string command;
            while ((command = Console.ReadLine()) != "Shutdown")
            {
                var tokens = command
                    .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                    .ToList();

                CheckCommand(tokens, draftmanager);
            }

            Console.WriteLine(draftmanager.ShutDown());
        }

        private static void CheckCommand(List<string> tokens, DraftManager draftmanager)
        {
            if (tokens[0] == "RegisterHarvester")
            {
                Console.WriteLine(draftmanager.RegisterHarvester(tokens));
            }

            else if (tokens[0] == "RegisterProvider")
            {
                Console.WriteLine(draftmanager.RegisterProvider(tokens));
            }

            else if (tokens[0] == "Day")
            {

            }
            else if (tokens[0] == "Mode")
            {
                Console.WriteLine(draftmanager.Mode(tokens));
            }
            else if (tokens[0] == "Check")
            {
                Console.WriteLine(draftmanager.Check(tokens));
            }
        }
    }
}
