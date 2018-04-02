using System;
using P01.Logger.Models.Contracts;
using P01.Logger.Models.Enums;

namespace P01.Logger.Models.Factories
{
    public class AppenderFactory
    {
        private const string DefaultFileName = "logFile{0}.txt";
        private LayoutFactory layoutFactory;
        private int fileNumber;

        public AppenderFactory(LayoutFactory layoutFactory)
        {
            this.layoutFactory = layoutFactory;
        }

        public IAppender CreateAppender(string appenderType, string levelString, string layoutType)
        {
            ILayout layout = this.layoutFactory.CreateLayout(layoutType);
            ErrorLevel errorLevel = this.ParseErrorLevel(levelString);

            IAppender appender = null;

            switch (appenderType)
            {
                case "ConsoleAppender":
                    appender = new ConsoleAppender(layout,errorLevel);
                    break;
                case "FileAppender":
                    ILogFile logFile = new LogFile(string.Format(DefaultFileName, this.fileNumber));
                    appender = new FileAppender(layout,errorLevel,logFile);
                    break;
                    default:
                        throw new ArgumentException("Invalid Appended Type!");
            }

            return appender;
        }

        private ErrorLevel ParseErrorLevel(string levelString)
        {
            try
            {
                object lvelObj = Enum.Parse(typeof(ErrorLevel), levelString);
                return (ErrorLevel) lvelObj;
            }
            catch (ArgumentException ae)
            {
                throw new ArgumentException("Invalid ErrorLevel Type!", ae);
            }
        }
    }
}
