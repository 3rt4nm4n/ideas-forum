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
using Npgsql;
using System.Collections;
using System.Collections.ObjectModel;

namespace idea_management_system
{
    /// <summary>
    /// Interaction logic for CreatePost.xaml
    /// </summary>
    public partial class CreatePost : Window
    {
        public readonly string signed_user_path = "C:\\Users\\nigbu\\source\\repos\\idea-management-system\\signeduser.txt";
        public readonly string auth_id_path = "C:\\Users\\nigbu\\source\\repos\\idea-management-system\\auth_id.txt";
        public NpgsqlConnection conn;
        public string sql = null;
        public readonly string connstring = String.Format(@"Server=localhost;Port=5432;User Id=postgres;Password=password;Database=ideasdb");
        private NpgsqlCommand cmd;
        public string usrn = "";
        public bool click_counter_T = false;
        public bool click_counter_B = false;
        public string font_style;
        public string font_weight;
        public int font_size;
        public readonly string previewtext_path = "C:\\Users\\nigbu\\source\\repos\\idea-management-system\\previewtext.txt";
        public readonly string previewtitle_path = "C:\\Users\\nigbu\\source\\repos\\idea-management-system\\previewtitle.txt";
        
      

        public CreatePost()
        {
            InitializeComponent();
            
            string[] cat = File.ReadAllLines("C:\\Users\\nigbu\\source\\repos\\idea-management-system\\categories.txt");
            foreach (var c in cat)
            {
                string[] ct = c.Split(',');
                CategoriesComboBox.Items.Add(ct[0]);
            }
            DateLabel.Content = DateTime.Today.ToShortDateString();
            string[] cont = File.ReadAllLines(signed_user_path);
            foreach (var c in cont)
            {
                string[] t = c.Split(',');
                usrn = t[0];
            }
            File.WriteAllText(previewtext_path, String.Empty);
            File.WriteAllText(previewtitle_path, String.Empty);
            
        }

        private void DiscardButton_Click(object sender, RoutedEventArgs e)
        {
            HW hw = new HW();
            hw.Show();
            this.Close();
        }
        public int GetAuthId(string un)
        {
            string sq = "SELECT usr_id FROM usr WHERE username=\'" + un + "\'";
            int aid;
            conn = new NpgsqlConnection(connstring);
            conn.Open();
            cmd = new NpgsqlCommand(sq, conn);
            
            StreamWriter writer2 = new StreamWriter(auth_id_path);
            using (NpgsqlDataReader rdr = cmd.ExecuteReader())
            {
                while (rdr.Read())
                {
                    for (int i = 0; i < rdr.FieldCount; i++)
                        writer2.WriteLine(rdr.GetInt32(i));
                }
                writer2.Close();
                StreamReader reader2 = new StreamReader(auth_id_path);
                aid = Convert.ToInt32(reader2.ReadToEnd());
            }
            conn.Close();
            return aid;
        }
        

        private void EraseButton_Click(object sender, RoutedEventArgs e)
        {
            NewPostText.Text = String.Empty;
        }

        private void UpFontSizeButton_Click(object sender, RoutedEventArgs e)
        {
            NewPostText.FontSize += 2;
            font_size += 2;
        }

        private void DownFontSizeButton_Click(object sender, RoutedEventArgs e)
        {
            NewPostText.FontSize -= 2;
            if (font_size != 0)
                font_size -= 2;
        }

        private void ItalicButton_Click(object sender, RoutedEventArgs e)
        {
            
            if (click_counter_T == false)
            {
                NewPostText.FontStyle = FontStyles.Italic;
                click_counter_T = true;
                font_style = "Italic";
            }
            else if (click_counter_T == true)
            {
                NewPostText.FontStyle = FontStyles.Normal;
                click_counter_T = false;
                font_style = "";
            }
        }

        private void BoldButton_Click(object sender, RoutedEventArgs e)
        {
            if (click_counter_B == false)
            {
                NewPostText.FontWeight = FontWeights.Bold;
                click_counter_B = true;
                font_weight = "Bold";
                
            }
            else if (click_counter_B == true)
            {
                NewPostText.FontWeight = FontWeights.Normal;
                click_counter_B = false;
                font_weight = "";
            }
        }

        

        private void CreatePostButton_Click(object sender, RoutedEventArgs e)
        {
            conn = new NpgsqlConnection(connstring);
            string a = "\'";
            string c = ",";
            string date = DateTime.UtcNow.Date.ToString();
            string cat = CategoriesComboBox.SelectedItem.ToString();
            int postscore = 0;
            string postcontent = NewPostText.Text;
            string title = TitleTextBox.Text;
            int auth_id = Convert.ToInt32(GetAuthId(usrn));
            sql = "INSERT INTO posts(post_author,post_date,post_cat,post_score,post_content,post_title,auth_id,font_size,font_style,font_weight) VALUES(" + a + usrn + a + c + a + date + a + c + a + cat + a + c + postscore + c + a + postcontent + a + c + a + title + a + c + a + auth_id + a + c + font_size + c + a + font_style + a + c + a + font_weight + a + ")";
            try
            {
                conn.Open();
                cmd = new NpgsqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("post_author", usrn);
                cmd.Parameters.AddWithValue("post_date", date);
                cmd.Parameters.AddWithValue("post_cat", cat);
                cmd.Parameters.AddWithValue("post_score", postscore);
                cmd.Parameters.AddWithValue("post_content", postcontent);
                cmd.Parameters.AddWithValue("post_title", title);
                cmd.Parameters.AddWithValue("auth_id", auth_id);
                cmd.Parameters.AddWithValue("font_size", font_size);
                cmd.Parameters.AddWithValue("font_style", font_style);
                cmd.Parameters.AddWithValue("font_weight", font_weight);
                cmd.ExecuteScalar();
                cmd.CommandText = sql;
                conn.Close();
                MessageBox.Show("Your post has been successfully created", "Information", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            catch (Exception exc)
            {
                MessageBox.Show("Error: " + exc.Message, "Failed", MessageBoxButton.OK, MessageBoxImage.Error);
                conn.Close();
            }
        }
        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            HW hw = new HW();
            hw.Show();
            this.Close();
        }

        
    }
}
