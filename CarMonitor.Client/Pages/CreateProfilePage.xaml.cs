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
    /// Interaction logic for CreateProfilePage.xaml
    /// </summary>
    public partial class CreateProfilePage : Page
    {
        public CreateProfilePage()
        {
            InitializeComponent();
        }

        private void createButton_Click(object sender, RoutedEventArgs e)
        {
            var client = new ProfileServiceClient();
            var profileDto = new ProfileDto() 
            { 
                Name = nameBox.Text
            };

            var profile = client.GetProfile(profileDto.Name);
            if (profile == null)
            {
                client.CreateProfile(profileDto);
                this.NavigationService.Navigate(new CreateProfilePage());
            }
            else
            {
                incorrectNameLabel.Visibility = Visibility.Visible;
            }
        }

        private void backButton_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new AddConsumptionPage());
        }

        private void fuelTypeComboBox_Loaded(object sender, RoutedEventArgs e)
        {
            fuelTypeComboBox.ItemsSource = Enum.GetValues(typeof(FuelType)).Cast<FuelType>();
        }
    }
}
