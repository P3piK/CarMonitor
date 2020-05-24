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
            var profile = new ProfileDto() 
            { 
                Name = nameBox.Text
            };

            var client = new ProfileServiceClient();
            client.CreateProfile(profile);

            textBox.Text = client.GetProfile(nameBox.Text).Name;
        }
    }
}
