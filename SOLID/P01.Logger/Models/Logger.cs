using System;
using System.Collections.Generic;
using System.Linq;
using P01.Logger.Models.Contracts;

namespace P01.Logger.Models
{
    public class Logger : ILogger
    {
        private IEnumerable<IAppender> appenders;
        public IReadOnlyCollection<IAppender> Appenders => (IReadOnlyCollection<IAppender>)this.appenders;

        public Logger(IEnumerable<IAppender> appenders)
        {
            this.appenders = appenders;
        }



        public void Log(IError error)
        {
            foreach (var appender in this.appenders)
            {
                if (appender.Level <=error.Level)
                {
                    appender.Append(error);
                }
            }
        }
    }
}
