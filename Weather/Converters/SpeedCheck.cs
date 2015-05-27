using System;
using System.Globalization;
using System.Windows.Data;

namespace Weather.Converters
{
    public class SpeedCheck : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var valuing = (string)value;
            Double windstring;
            bool knock = Double.TryParse(valuing, out windstring);
            if (knock)
            {
                windstring = Math.Round(windstring / 3.6, 1);
                string convert = windstring.ToString();
                return convert + " m/s";
            }
            else return string.Empty; //default uri fallback.
        }
        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotSupportedException();
        }
    }
}
