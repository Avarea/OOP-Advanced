using P01.Logger.Models.Contracts;
using P01.Logger.Models.Enums;

namespace P01.Logger.Models
{
    public class FileAppender : IAppender
    {
        private ILogFile logFile;

        public FileAppender(ILayout layout, ErrorLevel errorLevel, ILogFile logFile)
        {
            this.Layout = layout;
            this.Level = errorLevel;
            this.logFile = logFile;
            this.MessagesAppended = 0;
        }


        public ErrorLevel Level { get; }
        public ILayout Layout { get; }
        public int MessagesAppended { get; private set; }
        public void Append(IError error)
        {
            string formattedError = this.Layout.FormatError(error);
            this.logFile.WriteToFile(formattedError);
            this.MessagesAppended++;
        }

        public override string ToString()
        {
            string result = $"Appender type: {this.GetType().Name}, Layout type: {this.Layout.GetType().Name}, Report level: {this.Level}, Messages appended: {this.MessagesAppended}, File size: {this.logFile.Size}";
            return result;
        }
    }
}
