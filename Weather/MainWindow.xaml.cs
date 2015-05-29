using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.TextFormatting;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Diagnostics;
using System.Net.Http;
using Newtonsoft.Json;
using System.ComponentModel;

namespace Weather
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window, INotifyPropertyChanged
    {
        public MainWindow()
        {
            InitializeComponent();
            Get();
            DataContext = this; //logic 
            
        }
        string _direction { get; set; }
        public string Direction  //this model is being bound at xaml level.
        {
            get
            {
                return _direction;
            }
            set
            {
                _direction = value; //sets condition for value convertmodels
                OnPropertyChanged("Direction"); //condition changed.
            }
        }
        string _code { get; set; }
        public string Code //this model is being bound at xaml level.
        {
            get
            {
                return _code;
            }
            set
            {
                _code = value; //sets condition for value convertmodels
                OnPropertyChanged("Code"); //condition changed.
            }
        }
        string _speed { get; set;}
        public string Speed //this model is being bound at xaml level.
        {
            get
            {
                return _speed;
            }
            set
            {
                _speed = value; //sets condition for value convertmodels
                OnPropertyChanged("Speed"); //condition changed.
            }
        }
        string _speedcheck { get; set; }
        static string link { get; set; }
        public string SpeedCheck
        {
            get
            {
                return _speedcheck;
            }
            set
            {
                _speedcheck = value;
                OnPropertyChanged("Speed");
            }
        }
        async private void Get()
        {

            using (HttpClient client = new HttpClient())
            {

                string a = textbox1.Text;
                string Query = ("select%20*%20from%20weather.forecast%20where%20woeid%20in%20%28select%20woeid%20from%20geo.places%281%29%20where%20text=%22%s%22%29%20and%20u=%27c%27&format=json");
                string Final = Query.Replace("%s", a);
                string Url = ("https://query.yahooapis.com/v1/public/yql?q=" + Final);
                var response = await client.GetAsync(new Uri(Url));
                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();
                    ErrorResult checker = JsonConvert.DeserializeObject<ErrorResult>(content);
                    string title = checker.title;
                    int code = checker.count;
                    if (code == 0)
                    {
                        textbox1.Text = "London";
                        MessageBox.Show("This isn't a vaild location.");
                        Get();
                    }
                    else if (title == "Yahoo! Weather - Error") //error checking.
                    {
                        textbox1.Text = "London"; //failback to london.
                        MessageBox.Show("This isn't a vaild location."); //tell the user the location is invaild.
                        Get(); //get request.
                    }
                    else
                    {
                        QueryResult Result = JsonConvert.DeserializeObject<QueryResult>(content);
                        string Name = Result.City;
                        string Forty = Result.Condition;
                        string Windy = Result.Direction;
                        link = Result.link;
                        string Speedy = Result.Speed;
                        string Temp = Result.Temperature.ToString(); //force that temp to string.
                        //List<Weather.Forecast> example = result.Forecasts;
                        string SunRising = Result.SunRise;
                        Code = Result.Code; //sets up the condition for convertmodels to use
                        Direction = Result.Direction;
                        Speed = Result.Speed;
                        HumDisplay.Content = Result.Humidity + "%";
                        SpeedCheck = Result.Speed;
                        string SunSetting = Result.SunSet;
                        var Example = Result.Forecasts; //populating forecast grid.
                        Grid1.ItemsSource = Example; //binding dat data
                        textyfresh.Content = Forty;
                        texty.Content = Name;
                        SRise.Content = SunRising;
                        SSet.Content = SunSetting;
                        int Jack = Convert.ToInt32(Temp); //converting the temp with meaning.
                        if (Jack > 30)
                        {
                            Sun.Content = "Very Hot\n" + Jack + "c";
                            Sun.Foreground = new System.Windows.Media.SolidColorBrush(Colors.OrangeRed);
                        }
                        else if (Jack > 21)
                        {
                            Sun.Content = "Warm!\n" + Jack + "c";
                            Sun.Foreground = new System.Windows.Media.SolidColorBrush(Colors.Crimson);
                        }
                        else if (Jack > 16)
                        {
                            Sun.Content = "Mild " + Jack + "c";
                            Sun.Foreground = new System.Windows.Media.SolidColorBrush(Colors.Gold);
                        }
                        else if (Jack > 9)
                        {
                            Sun.Content = "Cool " + Jack + "c";
                            Sun.Foreground = new System.Windows.Media.SolidColorBrush(Colors.Navy);
                        }
                        else if (Jack < 6)
                        {
                            Sun.Content = "Cold" + Jack + "c";
                            Sun.Foreground = new System.Windows.Media.SolidColorBrush(Colors.Azure);
                        }
                        else if (Jack < 1)
                        {
                            Sun.Content = "Ice Cold" + Jack + "c";
                            Sun.Foreground = new System.Windows.Media.SolidColorBrush(Colors.Gray);
                        }
                        else
                        {
                            Sun.Content = Jack + "c";
                        }

                     }
                    
                }
            }
        }
        private void go_Click(object sender, RoutedEventArgs e)
        {
            Get();
        }
        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged(string propertyName)
        {
            var handler = PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(propertyName));
            }
        }
        private void EnterKey(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Return)
            {
                Get();
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            System.Diagnostics.Process.Start("https://www.yahoo.com/?ilc=401");
        }

        private void url_Click(object sender, RoutedEventArgs e)
        {
            if (link != null)
            {
                System.Diagnostics.Process.Start(link);
            }
            else
            {
                System.Diagnostics.Process.Start("https://yahoo.com/?ilc=401");
            }
            
        }

    }
    
}