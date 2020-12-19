using System.IO;
using System.Linq;

namespace Logger.LogFiles
{
    public class LogFile : ILogFile
    {
        private readonly string path = "../../../log.txt";

        public LogFile()
        {
            FileStream fileStream = new FileStream(path, FileMode.Create);
            fileStream.Close();
        }

        public int Size
        {
            get
            {
                using StreamReader streamReader = new StreamReader(path);
                {
                    return streamReader.ReadToEnd().ToCharArray().Where(char.IsLetter).Sum(x => x);
                }
            }
        }

        public void Write(string text)
        {
            using StreamWriter streamWriter = new StreamWriter(path, true);
            {
                streamWriter.WriteLine(text);
            }
        }
    }
}
