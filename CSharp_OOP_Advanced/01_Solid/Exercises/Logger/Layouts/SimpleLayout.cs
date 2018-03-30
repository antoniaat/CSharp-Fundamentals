using System.Globalization;
using System.Runtime.Remoting.Messaging;
using Logger.Interfaces;

namespace Logger.Layouts
{
    public class SimpleLayout : ILayout
    {
        // error.DateTime - error.Level - error.Message
        private const string DateFormat = "M/d/yyyy h:mm:ss tt";
        private const string Format = "{0} - {1} - {2}";

        public string FormatError(IError error)
        {
            string dateString = error.DateTime.ToString(DateFormat, CultureInfo.InvariantCulture);
            string formattedError = string.Format(Format, dateString, error.Level.ToString(),error.Message);

            return formattedError;
        }
    }
}