using System;
using System.Collections.Generic;
using P01.Logger.Models.Contracts;
using P01.Logger.Models.Factories;

namespace P01.Logger
{
    class StartUp
    {
        static void Main()
        {
            ILogger logger = InitializeLogger();
            ErrorFactory errorFactory = new ErrorFactory();
            Engine engine = new Engine(logger,errorFactory);
            engine.Run();

        }

        static ILogger InitializeLogger()
        {
            ICollection<IAppender> appenders = new List<IAppender>();
            LayoutFactory layoutFactory = new LayoutFactory();
            AppenderFactory appenderFactory = new AppenderFactory(layoutFactory);

            int numberOfAppenders = int.Parse(Console.ReadLine());
            for (int n = 0; n < numberOfAppenders; n++)
            {
                string[] args = Console.ReadLine()?.Split();
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

            ILogger logger = new Models.Logger(appenders);
            return logger;
        }
    }
}
