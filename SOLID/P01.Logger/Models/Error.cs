using System;
using P01.Logger.Models.Contracts;
using P01.Logger.Models.Enums;

namespace P01.Logger.Models
{
    public class Error : IError
    {
        public Error(DateTime dateTime, ErrorLevel level, string message)
        {
            this.DateTime = dateTime;
            this.Level = level;
            this.Message = message;
        }

        public ErrorLevel Level { get; }
        public DateTime DateTime { get; }
        public string Message { get; }
    }
}
