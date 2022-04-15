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

using System.Web;
using System.Configuration;
using System.Drawing;


namespace Group47App
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class ContactPage : Page
    {
        public ContactPage()
        {
            InitializeComponent();
        }

        private void Menu_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if(Menu.Height == 50)
            {
                Menu.Height += 300;
                Menu.Background = (SolidColorBrush)new BrushConverter().ConvertFromString("#333");
            }
            else
            {
                Menu.Height -= 300;
                Menu.Background = (SolidColorBrush)new BrushConverter().ConvertFromString("Black");
            }
        }

        private void Noti_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (Noti.Height == 50)
            {
                Noti.Height += 300;
                Noti.Background = (SolidColorBrush)new BrushConverter().ConvertFromString("#333");
            }
            else
            {
                Noti.Height -= 300;
                Noti.Background = (SolidColorBrush)new BrushConverter().ConvertFromString("Black");
            }
        }

        private void BuyButton_Click(object sender, RoutedEventArgs e)
        {
            var nav = NavigationService.GetNavigationService(this);

            nav.Navigate(new BuyPage());
        }

        private void SellButton_Click(object sender, RoutedEventArgs e)
        {
            var nav = NavigationService.GetNavigationService(this);

            nav.Navigate(new SellPage());
        }

        private void AppraiseButton_Click(object sender, RoutedEventArgs e)
        {
            var nav = NavigationService.GetNavigationService(this);

            nav.Navigate(new AppraisePage());
        }

        private void TipsButton_Click(object sender, RoutedEventArgs e)
        {
            var nav = NavigationService.GetNavigationService(this);

            nav.Navigate(new TipsPage());
        }

        private void FAQButton_Click(object sender, RoutedEventArgs e)
        {
            var nav = NavigationService.GetNavigationService(this);

            nav.Navigate(new FAQPage());
        }

        private void ContactButton_Click(object sender, RoutedEventArgs e)
        {
            var nav = NavigationService.GetNavigationService(this);

            nav.Navigate(new ContactPage());
        }

        private void SignInButton_Click(object sender, RoutedEventArgs e)
        {
            var nav = NavigationService.GetNavigationService(this);

            nav.Navigate(new SignInPage());
        }

        private void Logo_MouseDown(object sender, MouseButtonEventArgs e)
        {
            var nav = NavigationService.GetNavigationService(this);

            nav.Navigate(new MainPage());
        }

        private void sendQuestionButton_Click(object sender, RoutedEventArgs e)
        {
            string mainconn = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
            SqlConnection sqlconn = new SqlConnection(mainconn);
            SqlCommand insert = new SqlCommand("EXEC dbo.PushContactInfo @Name, @Email, @Phone_number, @Question", sqlconn);

            if (nameTextBox.Text != "" && emailTextBox.Text != "" && phoneTextBox.Text != "" && questionTextBox.Text != "")
            {
                insert.Parameters.AddWithValue("@Name", nameTextBox.Text);
                insert.Parameters.AddWithValue("@Email", emailTextBox.Text);
                insert.Parameters.AddWithValue("@Phone_number", phoneTextBox.Text);
                insert.Parameters.AddWithValue("@Question", questionTextBox.Text);

                sqlconn.Open();
                insert.ExecuteNonQuery();
                sqlconn.Close();

                errorText.Content = "Your question has been sent to our team!";
                nameTextBox.Text = "";
                emailTextBox.Text = "";
                phoneTextBox.Text = "";
                questionTextBox.Text = "";
            }
            else
            {
                errorText.Content = "Boxes marked with a * are required fields!";
            }

        }
    }
}
