using Logger.Enumerations;
using Logger.Layouts;

namespace Logger.Appenders
{
    public abstract class Appender : IAppender
    {
        protected Appender(ILayout layout)
        {
            this.Layout = layout;
            this.Level = Level.INFO;
        }

        public int Messages { get; protected set; }

        public ILayout Layout { get; private set; }

        public Level Level { get; set; }

        public abstract void Append(string date, Level level, string message);

        public override string ToString()
        {
            return $"Appender type: {this.GetType().Name}, Layout type: {this.Layout.GetType().Name}, Report level: {this.Level}, Messages appended: {this.Messages}";
        }
    }
}
