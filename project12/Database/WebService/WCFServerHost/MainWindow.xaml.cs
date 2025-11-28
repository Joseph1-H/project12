using System.ServiceModel;
using System.Windows;

namespace WCFServerHost
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        ServiceHost service;
        public MainWindow()
        {
            InitializeComponent();
            service = new ServiceHost(typeof(WCFServer.Service1));
            service.Open();
        }

        private void cmdEnd_Click(object sender, RoutedEventArgs e)
        {
            service.Close();
            Application.Current.Shutdown();
        }
    }
}
