/*============================================================================
	LogFile:		Exercises.sln

	Summary:	This document defines the exercises for "C# OOP Advanced" course at Software University.

				THIS SCRIPT IS PART OF LECTURE:
				SOLID PRINCIPLES - Exercises

	Date:		28.03.2018

	.NET Version: 2.1.4
------------------------------------------------------------------------------*/

using Logger.Factory;
using Logger.Interfaces;
using System;
using System.Collections.Generic;

namespace Logger
{
    public class Launcher
    {
        public static void Main()
        {
            ILogger logger = InitializeLogger();
            ErrorFactory errorFactory = new ErrorFactory();
            Engine engine = new Engine(logger, errorFactory);
            engine.Run();
        }

        private static ILogger InitializeLogger()
        {
            ICollection<IAppender> appenders = new List<IAppender>();
            LayoutFactory layoutFactory = new LayoutFactory();
            AppenderFactory appenderFactory = new AppenderFactory(layoutFactory);

            int appenderCount = int.Parse(Console.ReadLine());
            for (int i = 0; i < appenderCount; i++)
            {
                string[] args = Console.ReadLine().Split();
                string appenderType = args[0];
                string layoutType = args[1];
                string errorLevel = "INFO";

                if (args.Length == 3)
                {
                    errorLevel = args[2];
                }

                IAppender appender = appenderFactory.CreateAppender(appenderType, errorLevel, layoutType);
                appenders.Add(appender);
            }

            ILogger logger = new Loggers.Logger(appenders);
            return logger;
        }
    }
}