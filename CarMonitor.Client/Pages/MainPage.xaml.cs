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
        private ProfileServiceClient profileClient;
        private ConsumptionServiceClient consumptionClient;

        #region Properties
        private ProfileDto ProfileDto { get; set; }

        private ConsumptionDto ConsumptionDto { get; set; }

        private ProfileServiceClient ProfileClient
        {
            get
            {
                if (profileClient == null)
                {
                    profileClient = new ProfileServiceClient();
                }

                return profileClient;
            }
        }

        private ConsumptionServiceClient ConsumptionClient
        {
            get
            {
                if (consumptionClient == null)
                {
                    consumptionClient = new ConsumptionServiceClient();
                }

                return consumptionClient;
            }
        }
        #endregion

        public MainPage()
        {
            InitializeComponent();
        }

        private void addConsumptionButton_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new AddConsumptionPage());
        }

        private void getProfileButton_Click(object sender, RoutedEventArgs e)
        {
            ProfileDto = ProfileClient.GetProfile(profileNameBox.Text);

            if (ProfileDto != null)
            {
                notFoundLabel.Visibility = Visibility.Hidden;

                var avgData = ConsumptionClient.CalculateAvgConsumption(profileNameBox.Text);
                avgConsumptionBox.Text = avgData.AvgConsumption.ToString("F2");
                avgPriceBox.Text = avgData.AvgPrice.ToString("F2");
                lastConsumptionBox.Text = avgData.LastConsumption.ToString("F2");
            }
            else
            {
                notFoundLabel.Visibility = Visibility.Visible;
            }
        }
    }
}
