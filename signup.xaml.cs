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
using System.IO;
using System.Data;
using Npgsql;
using System.Security.Cryptography;


namespace idea_management_system
{
    /// <summary>
    /// Interaction logic for signup.xaml
    /// </summary>
    public partial class signup : Window
    {
        public NpgsqlConnection conn;
        public string sql = null;
        public readonly string connstring = String.Format(@"Server=localhost;Port=5432;User Id=postgres;Password=password;Database=ideasdb");
        private NpgsqlCommand cmd;
        public string fname = "";
        public string lname = "";
        public string email = "";
        public string pass = "";
        public string country = "";
        public static string dob = "";
        public string lang = "";
        public string usrname = "";
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

        private void ConfirmCheckBox_Checked(object sender, RoutedEventArgs e)
        {
            if (ConfirmCheckBox.IsChecked == true)
            {
                SignupButton.IsEnabled = true;
            }

        }

        public signup()
        {
            InitializeComponent();
            string[] cont = File.ReadAllLines("C:\\Users\\nigbu\\source\\repos\\idea-management-system\\countries.txt");
            foreach(var c in cont)
            {
                string[] t = c.Split(',');
                CountryComboBox.Items.Add(t[0]);
            }
            TermsTextBox.Text = File.ReadAllText("C:\\Users\\nigbu\\source\\repos\\idea-management-system\\termsandconditions.txt");
            string[] langarr = File.ReadAllLines("C:\\Users\\nigbu\\source\\repos\\idea-management-system\\languages.txt");
            foreach(var lg in langarr)
            {
                string[] l = lg.Split(',');
                LanguagesComboBox.Items.Add(l[0]);
            }
            
        }
        
       
        private void SignupButton_Click(object sender, RoutedEventArgs e)
        {

            conn = new NpgsqlConnection(connstring);
            try
            {
                conn.Open();
                fname = FnameTextBox.Text;
                lname = LnameTextBox.Text;
                email = EmailTextBox.Text;
                pass = PasswordTextBox.Password;
                country = CountryComboBox.SelectedItem.ToString();
                dob = DOBDatePicker.SelectedDate.Value.ToShortDateString();
                lang = LanguagesComboBox.SelectedItem.ToString();
                usrname = UsrnameTextBox.Text;


               
                    sql = "INSERT INTO usr(fname,lname,email,pass,country,dob,lang,username) VALUES(\'" + fname + "\',\'" + lname + "\',\'" + email + "\',\'" + pass + "\',\'" + country + "\',\'" + dob + "\',\'" + lang + "\',\'"+usrname+"\')";
                    cmd = new NpgsqlCommand(sql, conn);
                string convertedpass = CreateMD5(pass);
             
                    cmd.Parameters.AddWithValue("fname", fname);
                    cmd.Parameters.AddWithValue("lname", lname);
                    cmd.Parameters.AddWithValue("email", email);
                    cmd.Parameters.AddWithValue("pass", convertedpass);
                    cmd.Parameters.AddWithValue("country", country);
                    cmd.Parameters.AddWithValue("dob", dob);
                    cmd.Parameters.AddWithValue("lang", lang);
                    cmd.Parameters.AddWithValue("username", usrname);
                    cmd.ExecuteScalar();
                    cmd.CommandText = sql;
                    MessageBox.Show("You have successfully signed up!", "Information", MessageBoxButton.OK, MessageBoxImage.Information);
                    conn.Close();
                    MainWindow mw = new MainWindow();
                    mw.Show();
                    this.Close();
               

                
            }
            catch(Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Failed!", MessageBoxButton.OK, MessageBoxImage.Error);
                conn.Close();
            }
        }

        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mw = new MainWindow();
            mw.Show();
            this.Close();
        }
    }
}
