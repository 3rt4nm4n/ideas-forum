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
using System.Windows.Shapes;
using Npgsql;
using System.IO;

namespace idea_management_system
{
    /// <summary>
    /// Interaction logic for Settings.xaml
    /// </summary>
    public partial class Settings : Window
    {
        public readonly string signed_user_path = "C:\\Users\\nigbu\\source\\repos\\idea-management-system\\signeduser.txt";
        public readonly string auth_id_path = "C:\\Users\\nigbu\\source\\repos\\idea-management-system\\auth_id.txt";
        public NpgsqlConnection conn;
        public string sql = null;
        public readonly string connstring = String.Format(@"Server=localhost;Port=5432;User Id=postgres;Password=password;Database=ideasdb");
        private NpgsqlCommand cmd;
        public string usrn;


        public Settings()
        {
            InitializeComponent();
            string[] cont = File.ReadAllLines(signed_user_path);
            foreach (var c in cont)
            {
                string[] t = c.Split(',');
                usrn = t[0];
            }
            conn = new NpgsqlConnection(connstring);
            conn.Open();
            
            try
            {
                sql = "SELECT * FROM usr WHERE username=\'" + usrn +"\'";
                cmd = new NpgsqlCommand(sql, conn);
                NpgsqlDataReader rdr = cmd.ExecuteReader();
                if (rdr.Read())
                {
                    UsrnLabel.Content = usrn;
                    FnLabel.Content = rdr.GetString(0);
                    LnLabel.Content = rdr.GetString(1);
                    EmailLabel.Content = rdr.GetString(2);
                    CountryLabel.Content = rdr.GetString(4);
                    DOBLabel.Content = rdr.GetString(5);
                    LanguageLabel.Content = rdr.GetString(6);
                    ScoreLabel.Content = rdr.GetInt32(9);
                    
                }
            }
            catch(Exception exc)
            {
                MessageBox.Show("Error:" + exc.Message, "Failed!", MessageBoxButton.OK, MessageBoxImage.Error);
                conn.Close();
            }
        }

        private void BackToHomePageButton_Click(object sender, RoutedEventArgs e)
        {
            HW hw = new HW();
            hw.Show();
            this.Close();
        }

        private void PersonalInfoButton_Click(object sender, RoutedEventArgs e) //Name, Surname, Age etc.
        {
            PersonInfo pi = new PersonInfo();
            pi.Show();
        }

        private void AccountDetailsButton_Click(object sender, RoutedEventArgs e) //Username, Password, Email etc.
        {
            AccDet ad = new AccDet();
            ad.Show();
        }

        private void DeleteAccButton_Click(object sender, RoutedEventArgs e) //Delete account from usr table.
        {

            MessageBoxResult Result = MessageBox.Show("Do you really want to delete your account?", "Confirmation", MessageBoxButton.YesNo, MessageBoxImage.Exclamation);
            if (Result == MessageBoxResult.Yes)
            {
                sql = "DELETE FROM usr WHERE username=\'" + usrn + "\'";
                conn = new NpgsqlConnection(connstring);
                conn.Open();
                cmd = new NpgsqlCommand(sql, conn);
                cmd.ExecuteScalar();
            }
            else if (Result == MessageBoxResult.No)
            {
                this.Close(); 
            }
        }
    }
}
