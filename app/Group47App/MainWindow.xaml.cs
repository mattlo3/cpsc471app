﻿using System;
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
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            SqlConnection testConnection = new SqlConnection("Server=tcp:471testserver.database.windows.net,1433;Initial Catalog=test;Persist Security Info=False;User ID=theboys;Password=allah123!;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");
            {
                SqlCommand insert = new SqlCommand("EXEC dbo.InsertFullname @Fullname", testConnection);
                insert.Parameters.AddWithValue("@Fullname", SearchBar.Text);
                testConnection.Open();
                insert.ExecuteNonQuery();
                testConnection.Close();

                SearchBar.Text = "";
            }
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
    }
}
