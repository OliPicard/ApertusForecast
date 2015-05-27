using System;
using System.Globalization;
using System.Windows.Data;

namespace Weather.Converters
{
    public class ConvertModels : IValueConverter
    {

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            //throw new NotImplementedException();
            var weatherString = (string) value;

            switch (weatherString)
            {
                case "Rain":
                    return "pack://application:,,,/Images/rain.png";
                case "Mostly Cloudy":
                    return "pack://application:,,,/Images/cloud.png";
                case "Partly Cloudy":
                    return "pack://application:,,,/Images/cloud.png";
                case "Fair":
                    return "pack://application:,,,/Images/rain.png";
                case "Cloudy":
                    return "pack://application:,,,/Images/cloud.png";
                case "Light Rain":
                    return "pack://application:,,,/Images/cloud.png";
                case "Light Drizzle":
                    return "pack://application:,,,/Images/cloud.png";
            }
            return string.Empty; //if no image is at hand. empty string!
        }
        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotSupportedException();
        }
    }
}
