using Logger.Layouts;
using Logger.LogFiles;
using Logger.Enumerations;

namespace Logger.Appenders
{
    public class FileAppender : Appender, IAppender
    {
        public FileAppender(ILayout layout)
            :base(layout)
        {

        }

        public ILogFile File { get; set; }

        public override void Append(string date, Level level, string message)
        {
            if(level >= Level)
            {
                this.File.Write(string.Format(Layout.Format, date, level, message));
                this.Messages++;
            }
        }

        public override string ToString()
        {
            return base.ToString() + $", File size: {this.File.Size}";
        }
    }
}
