using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
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

namespace DomainPractice
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private string _url;

        public MainWindow()
        {
            InitializeComponent();
            progressBar.IsIndeterminate = false;

            _url = "https://earthquake.usgs.gov/fdsnws/event/1/query?format=geojson&orderby=time";
        }

        private void DownloadButtonClick(object sender, RoutedEventArgs e)
        {
            progressBar.IsIndeterminate = true;
            WebClient webClient = new WebClient();
            
            string link = @"ftp://speedtest:speedtest@ftp.otenet.gr/test100Mb.db";
            string downloadFileName = System.IO.Path.GetFileName("1.db");
            webClient.DownloadFileAsync(new Uri(link), @"C:\Users\гороховв.CORP\Desktop\" + downloadFileName);
            progressBar.IsIndeterminate = false;
        }

    
        private async void CountButtonClick(object sender, RoutedEventArgs e)
        {
            progressBar.Value = 10;

            string json = "";

            WebClient webClient = new WebClient();

            Stream stream = await webClient.OpenReadTaskAsync(new Uri(_url));
            using (var reader = new StreamReader(stream))
            {
                string line = "";
                while ((line = reader.ReadLine()) != null)
                {
                    json += line;
                }
            }
            progressBar.Value = 40;

            EarthquakeService earthquakeService = JsonConvert.DeserializeObject<EarthquakeService>(json);

            progressBar.Value = 80;

            int amount = 0;

            foreach (var earthquake in earthquakeService.Features)
            {
                if (earthquake.Information.Magnitude >= 1)
                {
                    amount++;
                }
            }

            progressBar.Value = 100;

            MessageBox.Show(amount.ToString());

            progressBar.Value = 0;
        }

    }
}
