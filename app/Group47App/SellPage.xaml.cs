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
using System.Data;
using System.Configuration;

namespace Group47App
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class SellPage : Page
    {
        public SellPage()
        {
            InitializeComponent();
            BindDropdown();
        }

        private void BindDropdown()
        {
            string mainconn = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
            SqlConnection sqlconn = new SqlConnection(mainconn);
            string sqlquery = "select distinct Make from [dbo].[carsOnMarket]";
            SqlDataAdapter sda = new SqlDataAdapter(sqlquery, sqlconn);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            sqlconn.Close();

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                for (int j = 0; j < dt.Columns.Count; j++)
                {
                    MakeSelect.Items.Add(dt.Rows[i][j].ToString());
                }
            }

            for(int i = 1987; i <= 2022; i++)
            {
                YearSelect.Items.Add(i.ToString());
            }

            TypeSelect.Items.Add("Sedan");
            TypeSelect.Items.Add("Hatchback");
            TypeSelect.Items.Add("Wagon");
            TypeSelect.Items.Add("SUV");
            TypeSelect.Items.Add("Crossover");
            TypeSelect.Items.Add("4x4");
            TypeSelect.Items.Add("Coupe");

            EngineSelect.Items.Add("I3");
            EngineSelect.Items.Add("I4");
            EngineSelect.Items.Add("I5");
            EngineSelect.Items.Add("I6");
            EngineSelect.Items.Add("Flat 4");
            EngineSelect.Items.Add("Flat 6");
            EngineSelect.Items.Add("V6");
            EngineSelect.Items.Add("V8");
            EngineSelect.Items.Add("V10");
            EngineSelect.Items.Add("V12");
            EngineSelect.Items.Add("W8");
            EngineSelect.Items.Add("W12");
            EngineSelect.Items.Add("W16");
            EngineSelect.Items.Add("Hybrid");
            EngineSelect.Items.Add("Rotary");

            TransmissionSelect.Items.Add("Automatic");
            TransmissionSelect.Items.Add("Sequential");
            TransmissionSelect.Items.Add("Manual");
            TransmissionSelect.Items.Add("Other");

            FuelSelect.Items.Add("Gasoline");
            FuelSelect.Items.Add("Diesel");
            FuelSelect.Items.Add("Hybrid");
            FuelSelect.Items.Add("Other");

            CountrySelect.Items.Add("England");
            CountrySelect.Items.Add("Germany");
            CountrySelect.Items.Add("Italy");
            CountrySelect.Items.Add("Japan");
            CountrySelect.Items.Add("Korea");
            CountrySelect.Items.Add("USA");
            CountrySelect.Items.Add("France");
            CountrySelect.Items.Add("Other");

            MakeSelect.SelectedIndex = 0;
            YearSelect.SelectedIndex = 0;
            TypeSelect.SelectedIndex = 0;
            EngineSelect.SelectedIndex = 0;
            TransmissionSelect.SelectedIndex = 0;
            FuelSelect.SelectedIndex = 0;
            CountrySelect.SelectedIndex = 0;
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

        private void ListCarButton_Click(object sender, RoutedEventArgs e)
        {
            string mainconn = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
            SqlConnection sqlconn = new SqlConnection(mainconn);
            SqlCommand insert = new SqlCommand("EXEC dbo.InsertCar @Make, @Model, @Year, @Mileage, @Type, @Engine, @Engine_type, @Transmission, @Color, @Trim, @Fuel_type, @Country_of_origin, @Price", sqlconn);

            if (ModelTextBox.Text != "" && MileageTextBox.Text != "" && EngineTextBox.Text != "" && ColorTextBox.Text != "" && TrimTextBox.Text != "" && PriceTextBox.Text != "")
            {
                insert.Parameters.AddWithValue("@Make", MakeSelect.Text);
                insert.Parameters.AddWithValue("@Model", ModelTextBox.Text);
                insert.Parameters.AddWithValue("@Year", YearSelect.Text);
                insert.Parameters.AddWithValue("@Mileage", MileageTextBox.Text);
                insert.Parameters.AddWithValue("@Type", TypeSelect.Text);
                insert.Parameters.AddWithValue("@Engine", EngineTextBox.Text);
                insert.Parameters.AddWithValue("@Engine_type", EngineSelect.Text);
                insert.Parameters.AddWithValue("@Transmission", TransmissionSelect.Text);
                insert.Parameters.AddWithValue("@Color", ColorTextBox.Text);
                insert.Parameters.AddWithValue("@Trim", TrimTextBox.Text);
                insert.Parameters.AddWithValue("@Fuel_type", FuelSelect.Text);
                insert.Parameters.AddWithValue("@Country_of_origin", CountrySelect.Text);
                insert.Parameters.AddWithValue("@Price", PriceTextBox.Text);

                sqlconn.Open();
                insert.ExecuteNonQuery();
                sqlconn.Close();

                errorText.Content = "Success!";
            }
            else
            {
                errorText.Content = "Please input all fields.";
            }
        }
    }
}
