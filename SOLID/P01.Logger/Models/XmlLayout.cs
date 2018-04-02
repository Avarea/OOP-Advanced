﻿using System;
using System.Globalization;
using P01.Logger.Models.Contracts;

namespace P01.Logger.Models
{
    public class XmlLayout : ILayout
    {
        const string DateFormat = "HH:mm:ss dd-MMM-yyyy";

        private string Format = "<log>" + Environment.NewLine +
                                "\t<date>{0}</date>" + Environment.NewLine +
                                "\t<level>{1}</level>" + Environment.NewLine +
                                "\t<message>{2}</message>" + Environment.NewLine +
                                "</log>";

        public string FormatError(IError error)
        {
            string dateString = error.DateTime.ToString(DateFormat, CultureInfo.InvariantCulture);
            string formattedError = string.Format(Format, dateString, error.Level.ToString(), error.Message);
            return formattedError;
        }
    }
}