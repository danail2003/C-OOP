using Logger.Enumerations;
using System;
using Logger.Layouts;

namespace Logger.Appenders
{
    public class ConsoleAppender : Appender, IAppender
    {
        public ConsoleAppender(ILayout layout)
            :base(layout)
        {

        }

        public override void Append(string date, Level level, string message)
        {
            if(level >= Level)
            {
                Console.WriteLine(string.Format(Layout.Format, date, level, message));
                this.Messages++;
            }
        }
    }
}
