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
    /// Interaction logic for AddConsumptionPage.xaml
    /// </summary>
    public partial class AddConsumptionPage : Page
    {
        private ProfileServiceClient profileClient;
        private ConsumptionServiceClient consumptionClient;

        private ProfileDto ProfileDto { get; set; }
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


        public AddConsumptionPage()
        {
            InitializeComponent();
        }

        private void newProfileButton_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new CreateProfilePage());
        }

        private void getProfileButton_Click(object sender, RoutedEventArgs e)
        {
            ProfileDto = ProfileClient.GetProfile(profileNameTextBox.Text);

            if (ProfileDto != null)
            {
                notFoundLabel.Visibility = Visibility.Hidden;
                profileNameTextBox.Text = ProfileDto.Name;

                distanceTextBox.IsEnabled = true;
                fuelVolumeTextBox.IsEnabled = true;
                priceTextBox.IsEnabled = true;
                date.IsEnabled = true;
                addConsumptionButton.IsEnabled = true;
            }
            else
            {
                notFoundLabel.Visibility = Visibility.Visible;
                distanceTextBox.IsEnabled = false;
                fuelVolumeTextBox.IsEnabled = false;
                priceTextBox.IsEnabled = false;
                date.IsEnabled = false;
                addConsumptionButton.IsEnabled = false;
            }
        }

        private void addConsumptionButton_Click(object sender, RoutedEventArgs e)
        {
            ConsumptionClient.Add(profileNameTextBox.Text, new ConsumptionDto()
            {
                Date = date.SelectedDate.GetValueOrDefault(),
                Distance = Double.Parse(distanceTextBox.Text),
                FuelVolume = Double.Parse(fuelVolumeTextBox.Text),
                PricePerLitre = Double.Parse(priceTextBox.Text),
            });

            this.NavigationService.Navigate(new AddConsumptionPage());
        }

        private void backButton_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new MainPage());
        }
    }
}
