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
using System.Data.SqlClient;


namespace Group47App
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class BasePage : Page
    {
        public BasePage()
        {
            InitializeComponent();
        }

        private void Menu_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if(Menu.Height == 50)
            {
                Menu.Height += 300;
                Menu.Background = (SolidColorBrush)new BrushConverter().ConvertFromString("DarkGreen");
            }
            else
            {
                Menu.Height -= 300;
                Menu.Background = (SolidColorBrush)new BrushConverter().ConvertFromString("ForestGreen");
            }
        }

        private void Noti_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (Noti.Height == 50)
            {
                Noti.Height += 300;
                Noti.Background = (SolidColorBrush)new BrushConverter().ConvertFromString("DarkGreen");
            }
            else
            {
                Noti.Height -= 300;
                Noti.Background = (SolidColorBrush)new BrushConverter().ConvertFromString("ForestGreen");
            }
        }

        private void BuyButton_Click(object sender, RoutedEventArgs e)
        {

        }

        private void SellButton_Click(object sender, RoutedEventArgs e)
        {

        }

        private void AppraiseButton_Click(object sender, RoutedEventArgs e)
        {

        }

        private void TipsButton_Click(object sender, RoutedEventArgs e)
        {

        }

        private void FAQButton_Click(object sender, RoutedEventArgs e)
        {

        }

        private void ContactButton_Click(object sender, RoutedEventArgs e)
        {

        }

        private void SignInButton_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Logo_MouseDown(object sender, MouseButtonEventArgs e)
        {
            var nav = NavigationService.GetNavigationService(this);

            nav.Navigate(new MainPage());
        }
    }
}
