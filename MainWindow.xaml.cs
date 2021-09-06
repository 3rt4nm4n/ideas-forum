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
using Npgsql;
using System.Security.Cryptography;
using System.IO;
using System.Collections;
using System.Collections.ObjectModel;

namespace idea_management_system
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        
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
        public readonly string signed_user_path = "C:\\Users\\nigbu\\source\\repos\\idea-management-system\\signeduser.txt";
        public NpgsqlConnection conn;
        public string sql = null;
        public readonly string connstring = String.Format(@"Server=localhost;Port=5432;User Id=postgres;Password=password;Database=ideasdb");
        private NpgsqlCommand cmd;
       
        public MainWindow()
        {
            InitializeComponent();
            UsernameTextBox.Focus();
            //public readonly string signed_user_path = "C:\\Users\\nigbu\\source\\repos\\idea-management-system\\signeduser.txt";
            File.WriteAllText(signed_user_path, String.Empty);
            

        }

        private void SignUpHyperLink_Click(object sender, RoutedEventArgs e)
        {
            signup s = new signup();
            s.Show();
            this.Close();
        }

        private void LoginButton_Click(object sender, RoutedEventArgs e)
        {
            
            string convertedpass = CreateMD5(PasswordBox.Password);
            conn = new NpgsqlConnection(connstring);
            conn.Open();
            sql = "SELECT CASE WHEN EXISTS (SELECT * FROM usr WHERE username=\'"+UsernameTextBox.Text+ "\' AND pass=\'" +convertedpass + "\') THEN CAST (1 AS BIT) ELSE CAST (0 AS BIT) END";
            cmd = new NpgsqlCommand(sql, conn);
            if (Convert.ToBoolean(cmd.ExecuteScalar()) == true)
            {
                    File.WriteAllText(signed_user_path, UsernameTextBox.Text);
                    conn.Close();
                    HW hw = new HW();
                    hw.Show();
                    this.Close();
   
            }
            else
            {
                MessageBox.Show("User not found or details don't match!\nPlease check details or sign up to create an account.", "Warning", MessageBoxButton.OK, MessageBoxImage.Warning);
                conn.Close();
            }
        }

        private void PasswordBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                LoginButton_Click(sender,e);
            }
        }
    }
}
