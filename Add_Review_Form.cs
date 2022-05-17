using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Oracle.DataAccess.Client;
using Oracle.DataAccess.Types;

namespace IDMB_project
{
    public partial class Add_Review_Form : Form
    {
        public static Dictionary<int, List<int>> users_ratings_dictionary = new Dictionary<int, List<int>>();
        OracleConnection con;
        string ordb = "data source = orcl; user id =scott; password=tiger;";
        public Add_Review_Form()
        {
            InitializeComponent();
        }
        private void Add_Review_Form_Load(object sender, EventArgs e)
        {
            con = new OracleConnection(ordb);
            con.Open();
            users_ratings_dictionary.Clear();
            OracleCommand cmd = new OracleCommand();
            cmd.Connection = con;
            cmd.CommandText = "select filmid , userid from usersratings";
            cmd.CommandType = CommandType.Text;
            OracleDataReader dr1 = cmd.ExecuteReader();
            while (dr1.Read())
            {
                if (users_ratings_dictionary.ContainsKey(int.Parse(dr1[0].ToString())))
                {
                    users_ratings_dictionary[int.Parse(dr1[0].ToString())].Add(int.Parse(dr1[1].ToString()));
                }
                else
                {
                    users_ratings_dictionary.Add(int.Parse(dr1[0].ToString()), new List<int>());
                    users_ratings_dictionary[int.Parse(dr1[0].ToString())].Add(int.Parse(dr1[1].ToString()));
                }
            }
            dr1.Close();
            label1.Text = Movie_Review.film_name;
            label2.Text = Movie_Review.film_rating.ToString();
            Image img = Image.FromFile(@"Textures\movies\" + Movie_Review.photo_url);
            pictureBox1.BackgroundImage = img;
        }
        // add review button is clicked
        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox3.Text == "")
            {
                MessageBox.Show("please add your review ");
            }
            else
            { 
                OracleCommand cmd2 = new OracleCommand();
                cmd2.Connection = con;
                cmd2.CommandText = "insert into filmreviews values (:userid , :filmid , :filmreview) ";
                cmd2.Parameters.Add("userid", Login_Form.logged_in_user_id);
                cmd2.Parameters.Add("filmid", Browse_Movie.selected_film_id);
                cmd2.Parameters.Add("filmreview", textBox3.Text);
                int r = cmd2.ExecuteNonQuery();
                if (r != -1)
                {
                    MessageBox.Show("your review is succesfully added");
                    textBox3.Text = "";

                }
            }

        }
        // add rating button is pressed
        private void button2_Click(object sender, EventArgs e)
        {
            bool is_already_rated = false;
            if (users_ratings_dictionary.ContainsKey(Browse_Movie.selected_film_id))
            {
                List<int> curr_list = users_ratings_dictionary[Browse_Movie.selected_film_id];
                if (curr_list.Contains(Login_Form.logged_in_user_id))
                {
                    is_already_rated = true;
                }
            }
            if (is_already_rated)
            {
                MessageBox.Show("sorry you already rated this movie before");
            }
            else
            {
                Add_Rating add_rating_form = new Add_Rating();
                add_rating_form.ShowDialog();
            }
        }
        // back button is pressed
        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide();
            Movie_Review movie_review_form = new Movie_Review();
            movie_review_form.ShowDialog();
            this.Close();
        }
        private void Add_Review_Form_FormClosed(object sender, FormClosedEventArgs e)
        {
            Login_Form.is_logged_in = false;

        }
    }
}
