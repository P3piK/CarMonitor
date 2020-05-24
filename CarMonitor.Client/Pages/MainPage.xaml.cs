using CarMonitor.Client.ConsumptionServiceReference;
using CarMonitor.Client.ProfileServiceReference;
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

namespace CarMonitor.Client.Pages
{
    /// <summary>
    /// Interaction logic for MainPage.xaml
    /// </summary>
    public partial class MainPage : Page
    {
        private ProfileDto ProfileDto { get; set; }
        private ConsumptionDto ConsumptionDto { get; set; }

        public MainPage()
        {
            InitializeComponent();
        }

        private void profileNameBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            var client = new ProfileServiceClient();
            ProfileDto = client.GetProfile(profileNameBox.Text);

            if (ProfileDto != null)
            {
                avgConsumptionBox.Text = "129";
            }
        }

        private void addConsumptionButton_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new AddConsumptionPage());
        }
    }
}
