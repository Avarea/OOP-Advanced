using System;
using System.Globalization;
using P01.Logger.Models.Contracts;
using P01.Logger.Models.Enums;

namespace P01.Logger.Models.Factories
{
    public class ErrorFactory
    {
        private const string DateFormat = "M/d/yyyy h:mm:ss tt";

        public IError CreateError(string dateTimeString, string errorLevelString, string message)
        {
            DateTime dateTime = DateTime.ParseExact(dateTimeString, DateFormat, CultureInfo.InvariantCulture);

            ErrorLevel errorLevel = ParseErrorLevel(errorLevelString);
            IError error = new Error(dateTime, errorLevel, message);

            return error;
        }

        private ErrorLevel ParseErrorLevel(string levelString)
        {
            try
            {
                object lvelObj = Enum.Parse(typeof(ErrorLevel), levelString);
                return (ErrorLevel)lvelObj;
            }
            catch (ArgumentException ae)
            {
                throw new ArgumentException("Invalid ErrorLevel Type!", ae);
            }
        }
    }
}
