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
    public partial class MainPage : Page
    {
        public MainPage()
        {
            InitializeComponent();
            BindDropdown();
        }

        private void BindDropdown()
        {
            MakeSelect.Items.Add("Any");
            ModelSelect.Items.Add("Any");
            PriceSelect.Items.Add("Any");

            MakeSelect.SelectedIndex = 0;
            ModelSelect.SelectedIndex = 0;
            PriceSelect.SelectedIndex = 0;

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

            PriceSelect.Items.Add("< $1,000");
            PriceSelect.Items.Add("< $2,000");
            PriceSelect.Items.Add("< $3,000");
            PriceSelect.Items.Add("< $4,000");
            PriceSelect.Items.Add("< $5,000");
            PriceSelect.Items.Add("< $7,500");
            PriceSelect.Items.Add("< $10,000");
            PriceSelect.Items.Add("< $15,000");
            PriceSelect.Items.Add("< $20,000");
            PriceSelect.Items.Add("< $25,000");
            PriceSelect.Items.Add("< $50,000");
            PriceSelect.Items.Add("< $100,000");
            PriceSelect.Items.Add("< $200,000");
            PriceSelect.Items.Add("< $300,000");
            PriceSelect.Items.Add("< $400,000");
            PriceSelect.Items.Add("< $500,000");
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

        private void MakeSelect_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            string Make = MakeSelect.SelectedItem.ToString();

            string mainconn = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
            SqlConnection sqlconn = new SqlConnection(mainconn);
            var cmmd = new SqlCommand(@"select distinct Model from [dbo].[carsOnMarket] where Make = @Make", sqlconn);
            cmmd.Parameters.Add("@Make", SqlDbType.VarChar);
            cmmd.Parameters["@Make"].Value = Make;
            SqlDataAdapter sda = new SqlDataAdapter(cmmd);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            sqlconn.Close();

            // idk why i need this for loop but it doesnt compile unless i have it
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                for (int j = 0; j < dt.Columns.Count; j++)
                {
                    ModelSelect.Items.Clear();
                    ModelSelect.Items.Add("Any");
                    ModelSelect.SelectedIndex = 0;
                }
            }

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                for (int j = 0; j < dt.Columns.Count; j++)
                {
                    ModelSelect.Items.Add(dt.Rows[i][j].ToString());
                }
            }
        }

        private void FilterButton_Click(object sender, RoutedEventArgs e)
        {
            string Make = MakeSelect.SelectedItem.ToString();
            string Model = ModelSelect.SelectedItem.ToString();
            string price = PriceSelect.SelectedItem.ToString();
            int priceInt = 100000000;


            if (price == "< $1,000") priceInt = 1000;
            else if (price == "< $2,000") priceInt = 2000;
            else if (price == "< $3,000") priceInt = 3000;
            else if (price == "< $4,000") priceInt = 4000;
            else if (price == "< $5,000") priceInt = 5000;
            else if (price == "< $7,500") priceInt = 7500;
            else if (price == "< $10,000") priceInt = 10000;
            else if (price == "< $15,000") priceInt = 15000;
            else if (price == "< $20,000") priceInt = 20000;
            else if (price == "< $25,000") priceInt = 25000;
            else if (price == "< $50,000") priceInt = 50000;
            else if (price == "< $100,000") priceInt = 100000;
            else if (price == "< $200,000") priceInt = 200000;
            else if (price == "< $300,000") priceInt = 300000;
            else if (price == "< $400,000") priceInt = 400000;
            else if (price == "< $500,500") priceInt = 50000;

            if (Model == "Any" && Make != "Any")
            {
                Console.WriteLine(Make);
                Console.WriteLine(Model);
                Console.WriteLine(priceInt);
                Console.WriteLine(price);
                Console.WriteLine("1");

                string mainconn = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
                SqlConnection sqlconn = new SqlConnection(mainconn);
                var cmmd = new SqlCommand(@"select Make, Model, Year, Mileage, Price from [dbo].[carsOnMarket] where Make = @Make and Price < @priceInt", sqlconn);
                cmmd.Parameters.Add("@Make", SqlDbType.VarChar);
                cmmd.Parameters["@Make"].Value = Make;
                cmmd.Parameters.Add("@Model", SqlDbType.VarChar);
                cmmd.Parameters["@Model"].Value = Model;
                cmmd.Parameters.Add("@priceInt", SqlDbType.VarChar);
                cmmd.Parameters["@priceInt"].Value = priceInt;
                SqlDataAdapter sda = new SqlDataAdapter(cmmd);
                DataTable dt = new DataTable();
                sda.Fill(dt);
                sqlconn.Close();

                Console.WriteLine(dt.ToString());

                ResultsData.Rows.Clear();

                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    TableRow newRow = new TableRow();

                    for (int j = 0; j < dt.Columns.Count; j++)
                    {
                        Console.WriteLine(dt.Rows[i][j].ToString());
                        Console.WriteLine("");
                        Paragraph Content = new Paragraph(new Run(dt.Rows[i][j].ToString()));
                        Content.FontSize = 10;
                        TableCell tempCell = new TableCell(Content);
                        newRow.Cells.Add(tempCell);
                    }

                    ResultsData.Rows.Add(newRow);
                }
            }
            else if (Make == "Any")
            {
                Console.WriteLine(Make);
                Console.WriteLine(Model);
                Console.WriteLine(price);
                Console.WriteLine(priceInt);
                Console.WriteLine("2");

                string mainconn = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
                SqlConnection sqlconn = new SqlConnection(mainconn);
                var cmmd = new SqlCommand(@"select Make, Model, Year, Mileage, Price from [dbo].[carsOnMarket] where Price < @priceInt", sqlconn);
                cmmd.Parameters.Add("@Make", SqlDbType.VarChar);
                cmmd.Parameters["@Make"].Value = Make;
                cmmd.Parameters.Add("@Model", SqlDbType.VarChar);
                cmmd.Parameters["@Model"].Value = Model;
                cmmd.Parameters.Add("@priceInt", SqlDbType.VarChar);
                cmmd.Parameters["@priceInt"].Value = priceInt;
                SqlDataAdapter sda = new SqlDataAdapter(cmmd);
                DataTable dt = new DataTable();
                sda.Fill(dt);
                sqlconn.Close();

                Console.WriteLine(dt.ToString());

                ResultsData.Rows.Clear();

                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    TableRow newRow = new TableRow();

                    for (int j = 0; j < dt.Columns.Count; j++)
                    {
                        Console.WriteLine(dt.Rows[i][j].ToString());
                        Console.WriteLine("");
                        Paragraph Content = new Paragraph(new Run(dt.Rows[i][j].ToString()));
                        Content.FontSize = 10;
                        TableCell tempCell = new TableCell(Content);
                        newRow.Cells.Add(tempCell);
                    }

                    ResultsData.Rows.Add(newRow);
                }
            }
            else
            {
                Console.WriteLine(Make);
                Console.WriteLine(Model);
                Console.WriteLine(price);
                Console.WriteLine(priceInt);
                Console.WriteLine("3");

                string mainconn = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
                SqlConnection sqlconn = new SqlConnection(mainconn);
                var cmmd = new SqlCommand(@"select Make, Model, Year, Mileage, Price from [dbo].[carsOnMarket] where Make = @Make and Model = @Model and Price < @priceInt", sqlconn);
                cmmd.Parameters.Add("@Make", SqlDbType.VarChar);
                cmmd.Parameters["@Make"].Value = Make;
                cmmd.Parameters.Add("@Model", SqlDbType.VarChar);
                cmmd.Parameters["@Model"].Value = Model;

                cmmd.Parameters.Add("@priceInt", SqlDbType.Int);
                cmmd.Parameters["@priceInt"].Value = priceInt;
                SqlDataAdapter sda = new SqlDataAdapter(cmmd);
                DataTable dt = new DataTable();
                sda.Fill(dt);
                sqlconn.Close();

                Console.WriteLine(dt.ToString());

                ResultsData.Rows.Clear();

                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    TableRow newRow = new TableRow();

                    for (int j = 0; j < dt.Columns.Count; j++)
                    {
                        Console.WriteLine(dt.Rows[i][j].ToString());
                        Console.WriteLine("");
                        Paragraph Content = new Paragraph(new Run(dt.Rows[i][j].ToString()));
                        Content.FontSize = 10;
                        TableCell tempCell = new TableCell(Content);
                        newRow.Cells.Add(tempCell);
                    }

                    ResultsData.Rows.Add(newRow);
                }
            }
        }
    }
}
