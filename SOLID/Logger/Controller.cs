using System;
using Logger.Appenders;
using Logger.Layouts;
using Logger.Enumerations;
using Logger.Logger;

namespace Logger
{
    public class Controller
    {
        public void Run(int count)
        {
            IAppender[] appenders = new IAppender[count];

            for (int i = 0; i < count; i++)
            {
                string[] token = Console.ReadLine().Split();

                ILayout layout = null;

                if (token[1] == nameof(SimpleLayout))
                {
                    layout = new SimpleLayout();
                }
                else if (token[1] == nameof(XmlLayout))
                {
                    layout = new XmlLayout();
                }

                IAppender appender = null;

                if (token[0] == nameof(ConsoleAppender))
                {
                    appender = new ConsoleAppender(layout);
                }
                else if (token[0] == nameof(FileAppender))
                {
                    appender = new FileAppender(layout);
                }

                if (token.Length == 3)
                {
                    Level level = (Level)Enum.Parse(typeof(Level), token[2]);
                    appender.Level = level;
                }

                appenders[i] = appender;
            }

            LoggerType logger = new LoggerType(appenders);

            string command = Console.ReadLine();

            while (command != "END")
            {
                string[] token = command.Split("|");

                Level level = (Level)Enum.Parse(typeof(Level), token[0]);

                switch (level)
                {
                    case Level.CRITICAL:
                        logger.Critical(token[1], token[2]);
                        break;
                    case Level.ERROR:
                        logger.Error(token[1], token[2]);
                        break;
                    case Level.FATAL:
                        logger.Fatal(token[1], token[2]);
                        break;
                    case Level.INFO:
                        logger.Info(token[1], token[2]);
                        break;
                    case Level.WARNING:
                        logger.Warning(token[1], token[2]);
                        break;
                }
            }

            Console.WriteLine(logger);
        }
    }
}
