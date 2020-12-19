using Logger.Layouts;
using Logger.Enumerations;

namespace Logger.Appenders
{
    public interface IAppender
    {
        ILayout Layout { get; }

        void Append(string date, Level level, string message);

        Level Level { get; set; }
    }
}
