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
using System.Security.Cryptography;

namespace idea_management_system
{
    /// <summary>
    /// Interaction logic for AccDet.xaml
    /// </summary>
    public partial class AccDet : Window
    {
        public readonly string signed_user_path = "C:\\Users\\nigbu\\source\\repos\\idea-management-system\\signeduser.txt";
        public string usrn;
        public readonly string connstring = String.Format(@"Server=localhost;Port=5432;User Id=postgres;Password=password;Database=ideasdb");
        public NpgsqlConnection conn;
        public NpgsqlCommand cmd;
        public string sql=null;
        public static string CreateMD5(string input)
        {
            // Use input string to calculate MD5 hash
            using (System.Security.Cryptography.MD5 md5 = System.Security.Cryptography.MD5.Create())
            {
                byte[] inputBytes = System.Text.Encoding.UTF8.GetBytes(input);
                byte[] hashBytes = md5.ComputeHash(inputBytes);

                // Convert the byte array to hexadecimal string
                StringBuilder sb = new StringBuilder();
                for (int i = 0; i < hashBytes.Length; i++)
                {
                    sb.Append(hashBytes[i].ToString("x2"));
                }
                return sb.ToString();
            }
        }
        public AccDet()
        {
            InitializeComponent();
            string[] cont = File.ReadAllLines(signed_user_path);
            foreach (var c in cont)
            {
                string[] t = c.Split(',');
                usrn = t[0];
            }
            UserNameTextBox.Text = usrn;
        }

        private void ChangeUsrnChkBox_Checked(object sender, RoutedEventArgs e)
        {  
                UserNameTextBox.IsEnabled = true;
        }

        private void ChangePassChkBox_Checked(object sender, RoutedEventArgs e)
        {
                NewPasswordTextBox.IsEnabled = true;
        }
        
        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            conn = new NpgsqlConnection(connstring);
            if (ChangeUsrnChkBox.IsChecked == true)
            {
                
                if (ChangePassChkBox.IsChecked == true && UserNameTextBox.Text!=usrn && UserNameTextBox.Text!="")
                {
                    conn.Open();
                    sql = "UPDATE usr SET username=\'"+UserNameTextBox.Text+"\',pass=\'" + CreateMD5(NewPasswordTextBox.Password) + "\' WHERE username=\'" + usrn + "\'";
                    cmd = new NpgsqlCommand(sql, conn);
                    cmd.ExecuteScalar();
                    cmd.Parameters.AddWithValue("pass", CreateMD5(NewPasswordTextBox.Password));
                    cmd.Parameters.AddWithValue("username", UserNameTextBox.Text);
                    MessageBox.Show("Your username and password has been changed", "Information", MessageBoxButton.OK, MessageBoxImage.Information);
                    conn.Close();
                }
                conn.Open();
                
                sql ="UPDATE usr SET username=\'"+UserNameTextBox.Text+ "\' WHERE username=\'" + usrn + "\'";
                cmd = new NpgsqlCommand(sql, conn);
                cmd.ExecuteScalar();
                cmd.Parameters.AddWithValue("username", UserNameTextBox.Text);
                MessageBox.Show("Your username has been changed", "Information", MessageBoxButton.OK, MessageBoxImage.Information);
                conn.Close();
            }

            else if (ChangePassChkBox.IsChecked == true)
            {
                conn.Open();
                
                sql = "UPDATE usr SET pass=\'" + CreateMD5(NewPasswordTextBox.Password)+"\' WHERE username=\'"+usrn+"\'";
                cmd = new NpgsqlCommand(sql, conn);
                cmd.ExecuteScalar();
                cmd.Parameters.AddWithValue("pass", NewPasswordTextBox.Password);
                MessageBox.Show("Your password has been changed", "Information", MessageBoxButton.OK, MessageBoxImage.Information);
                conn.Close();

            }
            else if(ChangePassChkBox.IsChecked==false && ChangeUsrnChkBox.IsChecked==false)
            { 
                MessageBoxResult result = MessageBox.Show("Nothing is changed!", "Information", MessageBoxButton.OKCancel, MessageBoxImage.Information);
                if (result==MessageBoxResult.OK)
                {
                    this.Close();
                }
                else if (result == MessageBoxResult.Cancel)
                {

                }
            }

        }

        private void ChangeUsrnChkBox_Unchecked(object sender, RoutedEventArgs e)
        {
            UserNameTextBox.IsEnabled = false;
        }

        private void ChangePassChkBox_Unchecked(object sender, RoutedEventArgs e)
        {
            NewPasswordTextBox.IsEnabled = false;
        }
    }
}
