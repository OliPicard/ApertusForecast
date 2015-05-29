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
            int condition;
            bool knock = Int32.TryParse(weatherString, out condition);

            if (knock)
            {
                switch (condition)
                {
                    case 0: //tornado
                        return "pack://application:,,,/Images/Icons/Tornado.png";
                    case 1: //tropical storm
                        return "pack://application:,,,/Images/Icons/lightningstorm.png";
                    case 2: //hurricane
                        return "pack://application:,,,/Images/Icons/hurricane.png";
                    case 3: //severe thunderstorms
                        return "pack://application:,,,/Images/Icons/lightningstorm.png";
                    case 4: //thunderstorms
                        return "pack://application:,,,/Images/Icons/lightningstorm.png";
                    case 5: //mixed rain and snow
                        return "pack://application:,,,/Images/cloudywithsunshineandsnow.png";
                    case 6: //mixed rain and sleet
                        return "pack://application:,,,/Images/cloudywithsunshineandsnow.png";
                    case 7: //mixed snow and sleet
                        return "pack://application:,,,/Images/cloudywithsunshineandsnow.png";
                    case 8: //freezing drizzle
                        return "pack://application:,,,/Images/compusnorth.png";
                    case 9: //drizzle
                        return "pack://application:,,,/Images/compusnorth.png";
                    case 10: //freezing rain
                        return "pack://application:,,,/Images/cloudywithsunshineandsnow.png";
                    case 11: //showers
                        return "pack://application:,,,/Images/Icons/amheavyshowers.png";
                    case 12: //showers
                        return "pack://application:,,,/Images/Icons/amheavyshowers.png";
                    case 13: //snow flurries
                        return "pack://application:,,,/Images/Icons/snow.png";
                    case 14: //light snow showers
                        return "pack://application:,,,/Images/Icons/snow.png";
                    case 15: //blowing snow
                        return "pack://application:,,,/Images/Icons/snow.png";
                    case 16: //snow
                        return "pack://application:,,,/Images/Icons/snow.png";
                    case 17: //hail
                        return "pack://application:,,,/Images/Icons/hail.png";
                    case 18: //sleet
                        return "pack://application:,,,/Images/compusnorth.png";
                    case 19: //dust
                        return "pack://application:,,,/Images/Icons/foggy.png";
                    case 20: //foggy
                        return "pack://application:,,,/Images/Icons/fog.png";
                    case 21: //haze
                        return "pack://application:,,,/Images/Icons/fog.png";
                    case 22: //smokey
                        return "pack://application:,,,/Images/Icons/fog.png";
                    case 23: //blustery
                        return "pack://application:,,,/Images/Icons/windy.png";
                    case 24: //windy
                        return "pack://application:,,,/Images/Icons/windy.png";
                    case 25: //cold
                        return "pack://application:,,,/Images/Icons/cold.png";
                    case 26: //cloudy
                        return "pack://application:,,,/Images/Icons/cloud.png";
                    case 27: //mostly cloudy (night)
                        return "pack://application:,,,/Images/Icons/cloudnight.png";
                    case 28: //mostly cloudy (day)
                        return "pack://application:,,,/Images/Icons/cloudywithsun.png";
                    case 29: //partly cloudy (night)
                        return "pack://application:,,,/Images/Icons/cloudnight.png";
                    case 30: //partly cloudy (day)
                        return "pack://application:,,,/Images/Icons/cloudywithsun.png";
                    case 31: //clear (night)
                        return "pack://application:,,,/Images/Icons/moon.png";
                    case 32: //sunny
                        return "pack://application:,,,/Images/Icons/sunny.png";
                    case 33: //fair (night)
                        return "pack://application:,,,/Images/Icons/moon.png";
                    case 34: //fair (day)
                        return "pack://application:,,,/Images/Icons/sunny.png";
                    case 35: //mixed rain and hail
                        return "pack://application:,,,/Images/Icons/hail.png";
                    case 36: //hot
                        return "pack://application:,,,/Images/Icons/sunglasses.png";
                    case 37: //isolated thunderstorms
                        return "pack://application:,,,/Images/Icons/lightningstorm.png";
                    case 38: //scattered thunderstorms
                        return "pack://application:,,,/Images/Icons/lightningstorm.png";
                    case 39: //scattered thunderstorms
                        return "pack://application:,,,/Images/Icons/lightningstorm.png";
                    case 40: //scattered showers
                        return "pack://application:,,,/Images/Icons/heavyrain.png";
                    case 41: //heavy snow
                        return "pack://application:,,,/Images/Icons/snowcloud.png";
                    case 42: //scattered snow showers
                        return "pack://application:,,,/Images/Icons/snow.png";
                    case 43: //heavy snow
                        return "pack://application:,,,/Images/Icons/snowcloud.png";
                    case 44: //partly cloudy
                        return "pack://application:,,,/Images/Icons/cloudywithsun.png";
                    case 45: //thundershowers
                        return "pack://application:,,,/Images/Icons/lightningstorm.png";
                    case 46: //snow showers
                        return "pack://application:,,,/Images/Icons/snow.png";
                    case 47: //isolated thundershowers
                        return "pack://application:,,,/Images/Icons/lightningstorm.png";
                    case 3200: //not available
                        return "pack://application:,,,/Images/compusnorth.png";
                }
                return string.Empty; //if no image is at hand. empty string!
            }
            return string.Empty; //if no image is at hand. empty string!
        }
        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotSupportedException();
        }
    }
}
