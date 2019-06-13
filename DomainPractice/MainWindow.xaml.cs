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
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            progressBar.IsIndeterminate = false;
        }

        private void DownloadButtonClick(object sender, RoutedEventArgs e)
        {
            progressBar.IsIndeterminate = true;

            var downloadAppDomain = AppDomain.CreateDomain("DownloadApp");
            var downloadAppPath = AppDomain.CurrentDomain.BaseDirectory + @"Download\DownloadingFilesApp.exe";
            downloadAppDomain.ExecuteAssembly(downloadAppPath);
            AppDomain.Unload(downloadAppDomain);

            progressBar.IsIndeterminate = false;
        }

        private void CountButtonClick(object sender, RoutedEventArgs e)
        {
            progressBar.IsIndeterminate = true;

            var countAppDomain = AppDomain.CreateDomain("HardCountApp");
            var countAppPath = AppDomain.CurrentDomain.BaseDirectory + @"Count\HardCountApp.exe";
            countAppDomain.ExecuteAssembly(countAppPath);
            AppDomain.Unload(countAppDomain);

            progressBar.IsIndeterminate = false;
        }
    }
}
