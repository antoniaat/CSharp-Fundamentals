using Logger.Interfaces;
using System;
using System.Globalization;

namespace Logger.Layouts
{
    public class XmlLayout : ILayout
    {
        private const string DateFormat = "HH:mm:ss dd-MM-yyyy";

        private string Format =
            "<log>" + Environment.NewLine +
            "\t<date>{0}</date>" + Environment.NewLine +
            "\t<level>{1}</level>" + Environment.NewLine +
            "\t<message>{2}</message>" + Environment.NewLine
            + "</log>";

        public string FormatError(IError error)
        {
            string dateString = error.DateTime.ToString(DateFormat, CultureInfo.InvariantCulture);
            string formattedError = string.Format(this.Format, dateString, error.Level.ToString(), error.Message);
            return formattedError;
        }
    }
}