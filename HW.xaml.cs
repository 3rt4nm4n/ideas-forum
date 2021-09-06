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
using System.Collections;
using System.Collections.ObjectModel;
using Npgsql;
using System.Data;
using System.Security.Cryptography;

namespace idea_management_system
{
    /// <summary>
    /// Interaction logic for HomeWindow.xaml
    /// </summary>
    public partial class HW : Window
    {
        public readonly string signed_user_path = "C:\\Users\\nigbu\\source\\repos\\idea-management-system\\signeduser.txt";
        public readonly string auth_id_path = "C:\\Users\\nigbu\\source\\repos\\idea-management-system\\auth_id.txt";
        public NpgsqlConnection conn;
        public string sql = null;
        public readonly string connstring = String.Format(@"Server=localhost;Port=5432;User Id=postgres;Password=password;Database=ideasdb");
        private NpgsqlCommand cmd;
        private readonly DataTable dt;
        public string usrn = "";
        
        
        public HW()
        {
            InitializeComponent();
            string[] cat = File.ReadAllLines("C:\\Users\\nigbu\\source\\repos\\idea-management-system\\categories.txt");
            foreach (var c in cat)
            {
                string[] ct = c.Split(',');
                CategoriesComboBox.Items.Add(ct[0]);
            }
            string[] cont = File.ReadAllLines(signed_user_path);
            foreach (var c in cont)
            {
                string[] t = c.Split(',');
                usrn = t[0];
            }
            UsernameLabel.Content = usrn;
            conn = new NpgsqlConnection(connstring);
            try
            {
                conn.Open();
                sql = "SELECT post_title,post_author,post_cat,post_content,post_date,post_score FROM posts ORDER BY post_date";
                cmd = new NpgsqlCommand(sql, conn);
                dt = new DataTable();
                dt.Load(cmd.ExecuteReader());
                ArticlesDataGrid.DataContext = dt.DefaultView;

                conn.Close();
            }
            catch (Exception exc)
            {
                MessageBox.Show("Error: " + exc.Message, "Failed", MessageBoxButton.OK, MessageBoxImage.Error);
                conn.Close();
            }
            
            
        }
        

        private void SettingsButton_Click(object sender, RoutedEventArgs e)
        {
            
            Settings s = new Settings();
            s.Show();
            this.Close();
        }

        private void SearchButton_Click(object sender, RoutedEventArgs e)
        {
           
            conn = new NpgsqlConnection(connstring);

            try
            {
                conn.Open();
                DataTable dt;
                sql = "SELECT post_title,post_author,post_cat,post_content,post_date,post_score FROM posts WHERE * LIKE \'%" + SearchTextBox.Text + "%\'";
                cmd = new NpgsqlCommand(sql, conn);
                dt = new DataTable();
                dt.Load(cmd.ExecuteReader());
                ArticlesDataGrid.DataContext = dt.DefaultView;
                DataContext = this;

                conn.Close();
            }
            catch //(Exception ex)
            {
                //MessageBox.Show("Error: " + ex.Message, " Failed!", MessageBoxButton.OK, MessageBoxImage.Error);
                //conn.Close();
            }
        }

        private void CreateNewPostButton_Click(object sender, RoutedEventArgs e)
        {
            CreatePost cp = new CreatePost();
            cp.Show();
            this.Close();
        }

        private void LogOutButton_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mw = new MainWindow();
            mw.Show();
            this.Close();
        }

        private void ReportButton_Click(object sender, RoutedEventArgs e)
        {
            ReportWindow rw = new ReportWindow();
            rw.Show();
        }

        private void CategoriesComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            conn = new NpgsqlConnection(connstring);

            try
            {
                conn.Open();
                DataTable dt;
                sql = "SELECT post_title,post_author,post_cat,post_content,post_date,post_score FROM posts WHERE post_cat=\'" + CategoriesComboBox.SelectedItem.ToString() + "\'";
                cmd = new NpgsqlCommand(sql, conn);
                dt = new DataTable();
                dt.Load(cmd.ExecuteReader());
                ArticlesDataGrid.DataContext = dt.DefaultView;
                DataContext = this;

                conn.Close();
            }
            catch //(Exception ex)
            {
                //MessageBox.Show("Error: " + ex.Message, " Failed!", MessageBoxButton.OK, MessageBoxImage.Error);
                //conn.Close();
            }
        }
        
        private void MyPostsButton_Click(object sender, RoutedEventArgs e)
        {
            conn = new NpgsqlConnection(connstring);

            try
            {
                conn.Open();
                DataTable dt;
                sql = "SELECT post_title,post_author,post_cat,post_content,post_date,post_score FROM posts WHERE post_author=\'" + usrn + "\'";
                cmd = new NpgsqlCommand(sql, conn);
                dt = new DataTable();
                dt.Load(cmd.ExecuteReader());
                ArticlesDataGrid.DataContext = dt.DefaultView;
                DataContext = this;

                conn.Close();
            }
            catch //(Exception ex)
            {
                //MessageBox.Show("Error: " + ex.Message, " Failed!", MessageBoxButton.OK, MessageBoxImage.Error);
                //conn.Close();
            }
        }

        private void AllPostsButton_Click(object sender, RoutedEventArgs e)
        {
            conn = new NpgsqlConnection(connstring);

            try
            {
                conn.Open();
                DataTable dt;
                sql = "SELECT post_title,post_author,post_cat,post_content,post_date,post_score FROM posts";
                cmd = new NpgsqlCommand(sql, conn);
                dt = new DataTable();
                dt.Load(cmd.ExecuteReader());
                ArticlesDataGrid.DataContext = dt.DefaultView;
                DataContext = this;

                conn.Close();
            }
            catch //(Exception ex)
            {
                //MessageBox.Show("Error: " + ex.Message, " Failed!", MessageBoxButton.OK, MessageBoxImage.Error);
                //conn.Close();
            }
        }

        public static DataRowView row;

        public static string postscontent;
        public static string poststitle;
        public static string postsauth;

        private void DataGridRow_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            row = (DataRowView)ArticlesDataGrid.SelectedItems[0];
            poststitle = row.Row[0].ToString();
            postscontent = row.Row[3].ToString();
            postsauth = row.Row[1].ToString();
            Post post = new Post();
            post.Show();
            this.Close();
        }
    }
}
