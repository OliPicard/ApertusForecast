using System;
using System.Globalization;
using System.Windows.Data;

namespace Weather.Converters
{
    public class WindConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            
            var valuing = (string) value;
            int windstring;
            bool knock = Int32.TryParse(valuing, out windstring);
            if (knock)
            {
                if (windstring <= 22.5 || windstring > 337.5)
                {
                    return "pack://application:,,,/Images/compusnorth.png";
                }
                else if (windstring > 22.5 && windstring <= 67.5)
                {
                    return "pack://application:,,,/Images/compusnortheast.png";
                }
                else if (windstring > 67.5 && windstring <= 112.5)
                {
                    return "pack://application:,,,/Images/compuseast.png";
                }
                else if (windstring > 112.5 && windstring <= 157.5)
                {
                    return "pack://application:,,,/Images/compussoutheast.png";
                }
                else if (windstring > 157.5 && windstring <= 202.5)
                {
                    return "pack://application:,,,/Images/compussouth.png";
                }
                else if (windstring > 202.5 && windstring <= 247.5)
                {
                    return "pack://application:,,,/Images/compussouthwest.png";
                }
                else if (windstring > 247.5 && windstring <= 292.5)
                {
                    return "pack://application:,,,/Images/compuswest.png";
                }
                else if (windstring > 292.5 && windstring <= 337.5)
                {
                    return "pack://application:,,,/Images/compusnorthwest.png";
                }

            }
            return "pack://application:,,,/Images/compusinit.png"; //default uri fallback.
   
        }
        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotSupportedException();
        }
    }
}
