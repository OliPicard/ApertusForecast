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
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Net.Http;
using Newtonsoft.Json;

namespace Weather
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            get();
        }
        async private void get()
        {

            using (HttpClient client = new HttpClient())
            {
                var response = await client.GetAsync(new Uri("https://query.yahooapis.com/v1/public/yql?q=select%20*%20from%20weather.forecast%20where%20woeid%20in%20%28select%20woeid%20from%20geo.places%281%29%20where%20text%3D%22London%20UK%22%29&format=json&env=store%3A%2F%2Fdatatables.org%2Falltableswithkeys"));
                if (response.IsSuccessStatusCode)
                {
                  var content = await response.Content.ReadAsStringAsync();
                  schema m = JsonConvert.DeserializeObject<schema>(content);
                  
                  string name = m.Name;
                  string forty = m.SeverityDescription;
                  string temp = m.Reason;
                  string web = m.Html;
                  string formatforecast = m.forecast;
                  
                  textyfresh.Content = forty;
                  texty.Content = name;
                  tempy.Content = temp;
                  webby.NavigateToString(web);
                  
                  int apple = Convert.ToInt32(temp);
                  int jack = (apple - 32) * 5 / 9;
                  if (jack > 40)
                  {
                      sun.Content = "Very Hot" + jack + "c";
                  }
                  else if (jack > 25)
                  {
                      sun.Content = ("VWarm! " + jack + "c");
                  }
                  else if (jack > 10)
                  {
                      sun.Content = ("Mild " + jack + "c");
                  }
                  else
                  {
                      sun.Content = (jack + "c");
                  }
                }
                else
                {
                    tempy.Content = "Error";
                }
            }

        }
    }
}
