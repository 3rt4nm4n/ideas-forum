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
    /// Interaction logic for PersonInfo.xaml
    /// </summary>

    public partial class PersonInfo : Window
    {
        public readonly string signed_user_path = "C:\\Users\\nigbu\\source\\repos\\idea-management-system\\signeduser.txt";
        public readonly string countries_path = "C:\\Users\\nigbu\\source\\repos\\idea-management-system\\countries.txt";
        public string sql = null;
        public NpgsqlConnection conn;
        public string usrn;
        public readonly string connstring = String.Format(@"Server=localhost;Port=5432;User Id=postgres;Password=password;Database=ideasdb");
        public NpgsqlCommand cmd;
        public string a = "\'";
        public string c = ",";
        public string fname;
        public string lname;
        public string country;
        public string dob;
        public PersonInfo()
        {
            InitializeComponent();
            string[] cont = File.ReadAllLines(countries_path);
            foreach (var c in cont)
            {
                string[] t = c.Split(',');
                CountriesComboBox.Items.Add(t[0]);
            }
            string[] contr = File.ReadAllLines(signed_user_path);
            foreach(var c in contr)
            {
                string[] t = c.Split(',');
                usrn = t[0];
            }
            conn = new NpgsqlConnection(connstring);
            sql = "SELECT fname,lname,country,dob FROM usr WHERE username=\'" + usrn + "\'";
            cmd = new NpgsqlCommand(sql, conn);
            NpgsqlDataReader rdr = cmd.ExecuteReader();
            if (rdr.Read())
            {
                NameTextBox.Text = rdr.GetString(0);
                SurnameTextBox.Text = rdr.GetString(1);
                CountriesComboBox.SelectedItem = rdr.GetString(4);
                DOBDP.SelectedDate = new DateTime(Convert.ToInt64(rdr.GetString(5)));
            }
        }

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            conn = new NpgsqlConnection(connstring);
            fname = NameTextBox.Text;
            lname = SurnameTextBox.Text;
            country = CountriesComboBox.SelectedItem.ToString();
            dob = DOBDP.SelectedDate.Value.ToShortDateString();
            sql = "UPDATE usr SET fname="+a+fname+a+c+"lname="+lname+a+c+"country="+a+country+a+c+"dob="+a+dob+a+ "WHERE username=\'" + usrn + "\'";
            cmd = new NpgsqlCommand(sql, conn);
            cmd.ExecuteScalar();
            cmd.Parameters.AddWithValue("fname", fname);
            cmd.Parameters.AddWithValue("lname", lname);
            cmd.Parameters.AddWithValue("country", country);
            cmd.Parameters.AddWithValue("dob", dob);
            MessageBox.Show("Your personal information has been updated!", "Information", MessageBoxButton.OK, MessageBoxImage.Information);
        }
    }
}
