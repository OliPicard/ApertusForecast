using System;
using System.Globalization;
using System.Windows.Data;

namespace Weather.Converters
{
    public class Beaufort : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            
            var valuing = (string) value;
            Double windstring;
            bool knock = Double.TryParse(valuing, out windstring);

            if (knock)
            {
                windstring = Math.Round(windstring / 1.852); //speed category
                if (windstring < 1)
                {
                    return "Calm";
                }
                else if (windstring < 4)
                {
                    return "Light air";
                }
                else if (windstring < 7)
                {
                    return "Light breeze";
                }
                else if (windstring < 11)
                {
                    return "Gentle breeze";
                }
                else if (windstring < 16)
                {
                    return "Moderate Breeze";
                }
                else if (windstring < 22)
                {
                    return "Fresh breeze";
                }
                else if (windstring < 28)
                {
                    return "Strong breeze";
                }
                else if (windstring < 34)
                {
                    return "Near gale";
                }
                else if (windstring < 41)
                {
                    return "Gale";
                }
                else if (windstring < 48)
                {
                    return "Strong gale";
                }
                else if (windstring < 56)
                {
                    return "Storm";
                }
                else if (windstring < 64)
                {
                    return "Violent Storm";
                }
                else return "Hurricane";
            
            }
            else return string.Empty; //default uri fallback.
   
        }
        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotSupportedException();
        }
    }
}
