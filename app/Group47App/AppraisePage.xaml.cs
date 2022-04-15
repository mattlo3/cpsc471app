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
using System.Configuration;
using System.Data;

namespace Group47App
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class AppraisePage : Page
    {
        public AppraisePage()
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

            ModelSelect.Items.Clear();

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                for (int j = 0; j < dt.Columns.Count; j++)
                {
                    ModelSelect.Items.Add(dt.Rows[i][j].ToString());
                }
            }
        }

        private void ModelSelect_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            string Model = ModelSelect.SelectedItem.ToString();
            string mainconn = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
            SqlConnection sqlconn = new SqlConnection(mainconn);
            var cmmd = new SqlCommand(@"select distinct Type from [dbo].[carsOnMarket] where Model = @Model", sqlconn);
            cmmd.Parameters.Add("@Model", SqlDbType.VarChar);
            cmmd.Parameters["@Model"].Value = Model;
            SqlDataAdapter sda = new SqlDataAdapter(cmmd);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            sqlconn.Close();

            TypeSelect.Items.Clear();

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                for (int j = 0; j < dt.Columns.Count; j++)
                {
                    TypeSelect.Items.Add(dt.Rows[i][j].ToString());
                }
            }
        }

        private void TypeSelect_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            string Make = MakeSelect.SelectedItem.ToString();
            string Model = ModelSelect.SelectedItem.ToString();
            string Type = TypeSelect.SelectedItem.ToString();
            string mainconn = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
            SqlConnection sqlconn = new SqlConnection(mainconn);
            var cmmd = new SqlCommand(@"select distinct Engine from [dbo].[carsOnMarket] where Type = @Type and Make = @Make and Model = @Model", sqlconn);
            cmmd.Parameters.Add("@Type", SqlDbType.VarChar);
            cmmd.Parameters["@Type"].Value = Type;
            cmmd.Parameters.Add("@Make", SqlDbType.VarChar);
            cmmd.Parameters["@Make"].Value = Make;
            cmmd.Parameters.Add("@Model", SqlDbType.VarChar);
            cmmd.Parameters["@Model"].Value = Model;
            SqlDataAdapter sda = new SqlDataAdapter(cmmd);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            sqlconn.Close();

            EngineSelect.Items.Clear();

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                for (int j = 0; j < dt.Columns.Count; j++)
                {
                    EngineSelect.Items.Add(dt.Rows[i][j].ToString());
                }
            }
        }

        private void EngineSelect_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            string Make = MakeSelect.SelectedItem.ToString();
            string Model = ModelSelect.SelectedItem.ToString();
            string Type = TypeSelect.SelectedItem.ToString();
            string Engine = EngineSelect.SelectedItem.ToString();
            string mainconn = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
            SqlConnection sqlconn = new SqlConnection(mainconn);
            var cmmd = new SqlCommand(@"select distinct Transmission from [dbo].[carsOnMarket] where Type = @Type and Make = @Make and Model = @Model and Engine = @Engine", sqlconn);
            cmmd.Parameters.Add("@Type", SqlDbType.VarChar);
            cmmd.Parameters["@Type"].Value = Type;
            cmmd.Parameters.Add("@Make", SqlDbType.VarChar);
            cmmd.Parameters["@Make"].Value = Make;
            cmmd.Parameters.Add("@Model", SqlDbType.VarChar);
            cmmd.Parameters["@Model"].Value = Model;
            cmmd.Parameters.Add("@Engine", SqlDbType.VarChar);
            cmmd.Parameters["@Engine"].Value = Engine;
            SqlDataAdapter sda = new SqlDataAdapter(cmmd);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            sqlconn.Close();

            TransmissionSelect.Items.Clear();

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                for (int j = 0; j < dt.Columns.Count; j++)
                {
                    TransmissionSelect.Items.Add(dt.Rows[i][j].ToString());
                }
            }
        }

        private void TransmissionSelect_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            string Make = MakeSelect.SelectedItem.ToString();
            string Model = ModelSelect.SelectedItem.ToString();
            string Type = TypeSelect.SelectedItem.ToString();
            string Engine = EngineSelect.SelectedItem.ToString();
            string Transmission = TransmissionSelect.SelectedItem.ToString();
            string mainconn = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
            SqlConnection sqlconn = new SqlConnection(mainconn);
            var cmmd = new SqlCommand(@"select distinct Color from [dbo].[carsOnMarket] where Type = @Type and Make = @Make and Model = @Model and Engine = @Engine and Transmission = @Transmission", sqlconn);
            cmmd.Parameters.Add("@Type", SqlDbType.VarChar);
            cmmd.Parameters["@Type"].Value = Type;
            cmmd.Parameters.Add("@Make", SqlDbType.VarChar);
            cmmd.Parameters["@Make"].Value = Make;
            cmmd.Parameters.Add("@Model", SqlDbType.VarChar);
            cmmd.Parameters["@Model"].Value = Model;
            cmmd.Parameters.Add("@Engine", SqlDbType.VarChar);
            cmmd.Parameters["@Engine"].Value = Engine;
            cmmd.Parameters.Add("@Transmission", SqlDbType.VarChar);
            cmmd.Parameters["@Transmission"].Value = Transmission;
            SqlDataAdapter sda = new SqlDataAdapter(cmmd);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            sqlconn.Close();

            ColorSelect.Items.Clear();

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                for (int j = 0; j < dt.Columns.Count; j++)
                {
                    ColorSelect.Items.Add(dt.Rows[i][j].ToString());
                }
            }
        }

        private void ColorSelect_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            string Make = MakeSelect.SelectedItem.ToString();
            string Model = ModelSelect.SelectedItem.ToString();
            string Type = TypeSelect.SelectedItem.ToString();
            string Engine = EngineSelect.SelectedItem.ToString();
            string Transmission = TransmissionSelect.SelectedItem.ToString();
            string Color = ColorSelect.SelectedItem.ToString();
            string mainconn = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
            SqlConnection sqlconn = new SqlConnection(mainconn);
            var cmmd = new SqlCommand(@"select distinct Trim from [dbo].[carsOnMarket] where Type = @Type and Make = @Make and Model = @Model and Engine = @Engine and Transmission = @Transmission and Color = @Color", sqlconn);
            cmmd.Parameters.Add("@Type", SqlDbType.VarChar);
            cmmd.Parameters["@Type"].Value = Type;
            cmmd.Parameters.Add("@Make", SqlDbType.VarChar);
            cmmd.Parameters["@Make"].Value = Make;
            cmmd.Parameters.Add("@Model", SqlDbType.VarChar);
            cmmd.Parameters["@Model"].Value = Model;
            cmmd.Parameters.Add("@Engine", SqlDbType.VarChar);
            cmmd.Parameters["@Engine"].Value = Engine;
            cmmd.Parameters.Add("@Transmission", SqlDbType.VarChar);
            cmmd.Parameters["@Transmission"].Value = Transmission;
            cmmd.Parameters.Add("@Color", SqlDbType.VarChar);
            cmmd.Parameters["@Color"].Value = Color;
            SqlDataAdapter sda = new SqlDataAdapter(cmmd);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            sqlconn.Close();

            TrimSelect.Items.Clear();

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                for (int j = 0; j < dt.Columns.Count; j++)
                {
                    TrimSelect.Items.Add(dt.Rows[i][j].ToString());
                }
            }
        }

        private void TrimSelect_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            string Make = MakeSelect.SelectedItem.ToString();
            string Model = ModelSelect.SelectedItem.ToString();
            string Type = TypeSelect.SelectedItem.ToString();
            string Engine = EngineSelect.SelectedItem.ToString();
            string Transmission = TransmissionSelect.SelectedItem.ToString();
            string Color = ColorSelect.SelectedItem.ToString();
            string Trim = TrimSelect.SelectedItem.ToString();
            string mainconn = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
            SqlConnection sqlconn = new SqlConnection(mainconn);
            var cmmd = new SqlCommand(@"select distinct Engine_type from [dbo].[carsOnMarket] where Type = @Type and Make = @Make and Model = @Model and Engine = @Engine and Transmission = @Transmission and Color = @Color and Trim = @Trim", sqlconn);
            cmmd.Parameters.Add("@Type", SqlDbType.VarChar);
            cmmd.Parameters["@Type"].Value = Type;
            cmmd.Parameters.Add("@Make", SqlDbType.VarChar);
            cmmd.Parameters["@Make"].Value = Make;
            cmmd.Parameters.Add("@Model", SqlDbType.VarChar);
            cmmd.Parameters["@Model"].Value = Model;
            cmmd.Parameters.Add("@Engine", SqlDbType.VarChar);
            cmmd.Parameters["@Engine"].Value = Engine;
            cmmd.Parameters.Add("@Transmission", SqlDbType.VarChar);
            cmmd.Parameters["@Transmission"].Value = Transmission;
            cmmd.Parameters.Add("@Color", SqlDbType.VarChar);
            cmmd.Parameters["@Color"].Value = Color;
            cmmd.Parameters.Add("@Trim", SqlDbType.VarChar);
            cmmd.Parameters["@Trim"].Value = Trim;
            SqlDataAdapter sda = new SqlDataAdapter(cmmd);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            sqlconn.Close();

            EngineTypeSelect.Items.Clear();

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                for (int j = 0; j < dt.Columns.Count; j++)
                {
                    EngineTypeSelect.Items.Add(dt.Rows[i][j].ToString());
                }
            }
        }

        private void EngineTypeSelect_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            string Make = MakeSelect.SelectedItem.ToString();
            string Model = ModelSelect.SelectedItem.ToString();
            string Type = TypeSelect.SelectedItem.ToString();
            string Engine = EngineSelect.SelectedItem.ToString();
            string Transmission = TransmissionSelect.SelectedItem.ToString();
            string Color = ColorSelect.SelectedItem.ToString();
            string Trim = TrimSelect.SelectedItem.ToString();
            string EngineType = EngineTypeSelect.SelectedItem.ToString();
            string mainconn = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
            SqlConnection sqlconn = new SqlConnection(mainconn);
            var cmmd = new SqlCommand(@"select distinct Year from [dbo].[carsOnMarket] where Type = @Type and Make = @Make and Model = @Model and Engine = @Engine and Transmission = @Transmission and Color = @Color and Trim = @Trim and Engine_type = @EngineType", sqlconn);
            cmmd.Parameters.Add("@Type", SqlDbType.VarChar);
            cmmd.Parameters["@Type"].Value = Type;
            cmmd.Parameters.Add("@Make", SqlDbType.VarChar);
            cmmd.Parameters["@Make"].Value = Make;
            cmmd.Parameters.Add("@Model", SqlDbType.VarChar);
            cmmd.Parameters["@Model"].Value = Model;
            cmmd.Parameters.Add("@Engine", SqlDbType.VarChar);
            cmmd.Parameters["@Engine"].Value = Engine;
            cmmd.Parameters.Add("@Transmission", SqlDbType.VarChar);
            cmmd.Parameters["@Transmission"].Value = Transmission;
            cmmd.Parameters.Add("@Color", SqlDbType.VarChar);
            cmmd.Parameters["@Color"].Value = Color;
            cmmd.Parameters.Add("@Trim", SqlDbType.VarChar);
            cmmd.Parameters["@Trim"].Value = Trim;
            cmmd.Parameters.Add("@EngineType", SqlDbType.VarChar);
            cmmd.Parameters["@EngineType"].Value = EngineType;
            SqlDataAdapter sda = new SqlDataAdapter(cmmd);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            sqlconn.Close();

            YearSelect.Items.Clear();

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                for (int j = 0; j < dt.Columns.Count; j++)
                {
                    YearSelect.Items.Add(dt.Rows[i][j].ToString());
                }
            }
        }

        private void AppraiseCarButton_Click(object sender, RoutedEventArgs e)
        {
            string Make = MakeSelect.SelectedItem.ToString();
            string Model = ModelSelect.SelectedItem.ToString();
            string Type = TypeSelect.SelectedItem.ToString();
            string Engine = EngineSelect.SelectedItem.ToString();
            string Transmission = TransmissionSelect.SelectedItem.ToString();
            string Color = ColorSelect.SelectedItem.ToString();
            string Trim = TrimSelect.SelectedItem.ToString();
            string Engine_type = EngineTypeSelect.SelectedItem.ToString();
            int Year = Int32.Parse(YearSelect.SelectedItem.ToString());
            int Mileage = Int32.Parse(MileageTextbox.Text);
            int MileageUpper = Mileage + 25000;
            int MileageLower = Mileage - 25000;

            string mainconn = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
            SqlConnection sqlconn = new SqlConnection(mainconn);
            var cmmd = new SqlCommand(@"select avg(Price) Average_Cost from [dbo].[carsOnMarket] where Type = @Type and Make = @Make and Model = @Model and Engine = @Engine and Transmission = @Transmission and Color = @Color and Trim = @Trim and Engine_type = @Engine_type and Mileage >= @MileageLower and Mileage <= @MileageUpper and Year = @Year", sqlconn);
            cmmd.Parameters.Add("@Type", SqlDbType.VarChar);
            cmmd.Parameters["@Type"].Value = Type;
            cmmd.Parameters.Add("@Make", SqlDbType.VarChar);
            cmmd.Parameters["@Make"].Value = Make;
            cmmd.Parameters.Add("@Model", SqlDbType.VarChar);
            cmmd.Parameters["@Model"].Value = Model;
            cmmd.Parameters.Add("@Engine", SqlDbType.VarChar);
            cmmd.Parameters["@Engine"].Value = Engine;
            cmmd.Parameters.Add("@Transmission", SqlDbType.VarChar);
            cmmd.Parameters["@Transmission"].Value = Transmission;
            cmmd.Parameters.Add("@Color", SqlDbType.VarChar);
            cmmd.Parameters["@Color"].Value = Color;
            cmmd.Parameters.Add("@Trim", SqlDbType.VarChar);
            cmmd.Parameters["@Trim"].Value = Trim;
            cmmd.Parameters.Add("@Engine_type", SqlDbType.VarChar);
            cmmd.Parameters["@Engine_type"].Value = Engine_type;
            cmmd.Parameters.Add("@MileageUpper", SqlDbType.Int);
            cmmd.Parameters["@MileageUpper"].Value = MileageUpper;
            cmmd.Parameters.Add("@MileageLower", SqlDbType.Int);
            cmmd.Parameters["@MileageLower"].Value = MileageLower;
            cmmd.Parameters.Add("@Year", SqlDbType.Int);
            cmmd.Parameters["@Year"].Value = Year;
            SqlDataAdapter sda = new SqlDataAdapter(cmmd);
            DataTable dt = new DataTable();
            sda.Fill(dt);

            if (dt.Rows[0][0].ToString() != "")
            {
                sqlconn.Close();
                AppraiseResult.Text = "Your car is worth approx. $" +  dt.Rows[0][0].ToString();
            }
            else
            {
                cmmd = new SqlCommand(@"select max(Mileage) from [dbo].[carsOnMarket] where Type = @Type and Make = @Make and Model = @Model and Engine = @Engine and Transmission = @Transmission and Color = @Color and Trim = @Trim and Engine_type = @Engine_type and Year = @Year and Mileage <= @Mileage", sqlconn);
                cmmd.Parameters.Add("@Type", SqlDbType.VarChar);
                cmmd.Parameters["@Type"].Value = Type;
                cmmd.Parameters.Add("@Make", SqlDbType.VarChar);
                cmmd.Parameters["@Make"].Value = Make;
                cmmd.Parameters.Add("@Model", SqlDbType.VarChar);
                cmmd.Parameters["@Model"].Value = Model;
                cmmd.Parameters.Add("@Engine", SqlDbType.VarChar);
                cmmd.Parameters["@Engine"].Value = Engine;
                cmmd.Parameters.Add("@Transmission", SqlDbType.VarChar);
                cmmd.Parameters["@Transmission"].Value = Transmission;
                cmmd.Parameters.Add("@Color", SqlDbType.VarChar);
                cmmd.Parameters["@Color"].Value = Color;
                cmmd.Parameters.Add("@Trim", SqlDbType.VarChar);
                cmmd.Parameters["@Trim"].Value = Trim;
                cmmd.Parameters.Add("@Engine_type", SqlDbType.VarChar);
                cmmd.Parameters["@Engine_type"].Value = Engine_type;
                cmmd.Parameters.Add("@Mileage", SqlDbType.Int);
                cmmd.Parameters["@Mileage"].Value = Mileage;
                cmmd.Parameters.Add("@Year", SqlDbType.Int);
                cmmd.Parameters["@Year"].Value = Year;
                SqlDataAdapter sda1 = new SqlDataAdapter(cmmd);
                DataTable dt1 = new DataTable();
                sda1.Fill(dt1);
                if (dt1.Rows[0][0].ToString() != "")
                {
                    string maxMileage = dt1.Rows[0][0].ToString();
                    cmmd = new SqlCommand(@"select price from [dbo].[carsOnMarket] where Type = @Type and Make = @Make and Model = @Model and Engine = @Engine and Transmission = @Transmission and Color = @Color and Trim = @Trim and Engine_type = @Engine_type and Year = @Year and Mileage = @maxMileage", sqlconn);
                    cmmd.Parameters.Add("@Type", SqlDbType.VarChar);
                    cmmd.Parameters["@Type"].Value = Type;
                    cmmd.Parameters.Add("@Make", SqlDbType.VarChar);
                    cmmd.Parameters["@Make"].Value = Make;
                    cmmd.Parameters.Add("@Model", SqlDbType.VarChar);
                    cmmd.Parameters["@Model"].Value = Model;
                    cmmd.Parameters.Add("@Engine", SqlDbType.VarChar);
                    cmmd.Parameters["@Engine"].Value = Engine;
                    cmmd.Parameters.Add("@Transmission", SqlDbType.VarChar);
                    cmmd.Parameters["@Transmission"].Value = Transmission;
                    cmmd.Parameters.Add("@Color", SqlDbType.VarChar);
                    cmmd.Parameters["@Color"].Value = Color;
                    cmmd.Parameters.Add("@Trim", SqlDbType.VarChar);
                    cmmd.Parameters["@Trim"].Value = Trim;
                    cmmd.Parameters.Add("@Engine_type", SqlDbType.VarChar);
                    cmmd.Parameters["@Engine_type"].Value = Engine_type;
                    cmmd.Parameters.Add("@maxMileage", SqlDbType.Int);
                    cmmd.Parameters["@maxMileage"].Value = maxMileage;
                    cmmd.Parameters.Add("@Year", SqlDbType.Int);
                    cmmd.Parameters["@Year"].Value = Year;
                    SqlDataAdapter sda2 = new SqlDataAdapter(cmmd);
                    DataTable dt2 = new DataTable();
                    sda2.Fill(dt2);
                    int EstimatedPrice = Int32.Parse(dt2.Rows[0][0].ToString());
                    int NextBestMileage = Int32.Parse(maxMileage);
                    while (NextBestMileage < Mileage)
                    {
                        int TenPercent = EstimatedPrice / 10;
                        NextBestMileage += 25000;
                        EstimatedPrice -= TenPercent;
                    }
                    sqlconn.Close();
                    AppraiseResult.Text = "Your car is worth approx. $" + EstimatedPrice.ToString();
                }
                else
                {
                    cmmd = new SqlCommand(@"select min(Mileage) from [dbo].[carsOnMarket] where Type = @Type and Make = @Make and Model = @Model and Engine = @Engine and Transmission = @Transmission and Color = @Color and Trim = @Trim and Engine_type = @Engine_type and Year = @Year and Mileage >= @Mileage", sqlconn);
                    cmmd.Parameters.Add("@Type", SqlDbType.VarChar);
                    cmmd.Parameters["@Type"].Value = Type;
                    cmmd.Parameters.Add("@Make", SqlDbType.VarChar);
                    cmmd.Parameters["@Make"].Value = Make;
                    cmmd.Parameters.Add("@Model", SqlDbType.VarChar);
                    cmmd.Parameters["@Model"].Value = Model;
                    cmmd.Parameters.Add("@Engine", SqlDbType.VarChar);
                    cmmd.Parameters["@Engine"].Value = Engine;
                    cmmd.Parameters.Add("@Transmission", SqlDbType.VarChar);
                    cmmd.Parameters["@Transmission"].Value = Transmission;
                    cmmd.Parameters.Add("@Color", SqlDbType.VarChar);
                    cmmd.Parameters["@Color"].Value = Color;
                    cmmd.Parameters.Add("@Trim", SqlDbType.VarChar);
                    cmmd.Parameters["@Trim"].Value = Trim;
                    cmmd.Parameters.Add("@Engine_type", SqlDbType.VarChar);
                    cmmd.Parameters["@Engine_type"].Value = Engine_type;
                    cmmd.Parameters.Add("@Mileage", SqlDbType.Int);
                    cmmd.Parameters["@Mileage"].Value = Mileage;
                    cmmd.Parameters.Add("@Year", SqlDbType.Int);
                    cmmd.Parameters["@Year"].Value = Year;
                    SqlDataAdapter sda2 = new SqlDataAdapter(cmmd);
                    DataTable dt2 = new DataTable();
                    sda2.Fill(dt2);

                    string minMileage = dt2.Rows[0][0].ToString();
                    cmmd = new SqlCommand(@"select price from [dbo].[carsOnMarket] where Type = @Type and Make = @Make and Model = @Model and Engine = @Engine and Transmission = @Transmission and Color = @Color and Trim = @Trim and Engine_type = @Engine_type and Year = @Year and Mileage = @minMileage", sqlconn);
                    cmmd.Parameters.Add("@Type", SqlDbType.VarChar);
                    cmmd.Parameters["@Type"].Value = Type;
                    cmmd.Parameters.Add("@Make", SqlDbType.VarChar);
                    cmmd.Parameters["@Make"].Value = Make;
                    cmmd.Parameters.Add("@Model", SqlDbType.VarChar);
                    cmmd.Parameters["@Model"].Value = Model;
                    cmmd.Parameters.Add("@Engine", SqlDbType.VarChar);
                    cmmd.Parameters["@Engine"].Value = Engine;
                    cmmd.Parameters.Add("@Transmission", SqlDbType.VarChar);
                    cmmd.Parameters["@Transmission"].Value = Transmission;
                    cmmd.Parameters.Add("@Color", SqlDbType.VarChar);
                    cmmd.Parameters["@Color"].Value = Color;
                    cmmd.Parameters.Add("@Trim", SqlDbType.VarChar);
                    cmmd.Parameters["@Trim"].Value = Trim;
                    cmmd.Parameters.Add("@Engine_type", SqlDbType.VarChar);
                    cmmd.Parameters["@Engine_type"].Value = Engine_type;
                    cmmd.Parameters.Add("@minMileage", SqlDbType.Int);
                    cmmd.Parameters["@minMileage"].Value = minMileage;
                    cmmd.Parameters.Add("@Year", SqlDbType.Int);
                    cmmd.Parameters["@Year"].Value = Year;
                    SqlDataAdapter sda3 = new SqlDataAdapter(cmmd);
                    DataTable dt3 = new DataTable();
                    sda3.Fill(dt3);
                    int EstimatedPrice = Int32.Parse(dt3.Rows[0][0].ToString());
                    int NextBestMileage = Int32.Parse(minMileage);
                    while (NextBestMileage > Mileage)
                    {
                        int TenPercent = EstimatedPrice / 10;
                        NextBestMileage -= 25000;
                        EstimatedPrice += TenPercent;
                    }
                    sqlconn.Close();
                    AppraiseResult.Text = "Your car is worth approx. $" + EstimatedPrice.ToString();
                }
            }
        }
    }
}
