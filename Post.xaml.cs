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

namespace idea_management_system
{
    /// <summary>
    /// Interaction logic for Post.xaml
    /// </summary>
    public partial class Post : Window
    {
        public readonly string signed_user_path = "C:\\Users\\nigbu\\source\\repos\\idea-management-system\\signeduser.txt";
        public string usrn = "";
        public NpgsqlConnection conn;
        public string sql = null;
        public readonly string connstring = String.Format(@"Server=localhost;Port=5432;User Id=postgres;Password=password;Database=ideasdb");
        private NpgsqlCommand cmd;
        public Post()
        {
            InitializeComponent();
            TitleLabel.Content = HW.poststitle;
            PostTextBox.Text = HW.postscontent;
            AuthLabel.Content = ""+HW.postsauth+":";
        }

        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            HW hw = new HW();
            hw.Show();
            this.Close();
        }

        private void ReportButton_Click(object sender, RoutedEventArgs e)
        {
            ReportWindow re = new ReportWindow();
            re.Show();
        }

        private void CommentButton_Click(object sender, RoutedEventArgs e)
        {

        }

    
    }
}
