using System;
using System.Collections.Generic;
using System.IO;
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

namespace idea_management_system
{
    /// <summary>
    /// Interaction logic for ReportWindow.xaml
    /// </summary>
    public partial class ReportWindow : Window
    {
        public NpgsqlConnection conn;
        public string sql = null;
        public readonly string signed_user_path = "C:\\Users\\nigbu\\source\\repos\\idea-management-system\\signeduser.txt";
        public readonly string connstring = String.Format(@"Server=localhost;Port=5432;User Id=postgres;Password=password;Database=ideasdb");
        private NpgsqlCommand cmd;
        public string usrnameL = "";
        public ReportWindow()
        {
            InitializeComponent();
            string[] cont = File.ReadAllLines(signed_user_path);
            foreach (var c in cont)
            {
                string[] t = c.Split(',');
                usrnameL = t[0];   
            }
        }

        private void ReportButton_Click(object sender, RoutedEventArgs e)
        {
            
            sql = "INSERT INTO reports(report_title,report_content,report_date,report_author) VALUES(\'" + TitleTextBox.Text + "\',\'" + ReportTextBox.Text + "\',\'" + DateTime.UtcNow.Date.ToString() + "\',\'" + usrnameL+"\')";
            conn = new NpgsqlConnection(connstring);
            try
            {
                conn.Open();
                cmd = new NpgsqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("report_title", TitleTextBox.Text);
                cmd.Parameters.AddWithValue("report_content", ReportTextBox.Text);
                cmd.Parameters.AddWithValue("report_date", DateTime.UtcNow.Date);
                cmd.Parameters.AddWithValue("report_author", usrnameL);
                cmd.ExecuteScalar();
                cmd.CommandText = sql;
                conn.Close();
                this.Close();
            }
            catch(Exception exc)
            {
                MessageBox.Show("Error:" + exc.Message, "Failed", MessageBoxButton.OK, MessageBoxImage.Error);
                conn.Close();
            }
            
        }
    }
}
