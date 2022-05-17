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
    public partial class Movie_Review : Form
    {
        public static string film_name;
        public static string photo_url;
        public static double film_rating;
        public static int number_of_ratings;
        OracleConnection con;
        string ordb = "data source = orcl; user id =scott; password=tiger;";
        public Movie_Review()
        {
            InitializeComponent();
        }
        private void Movie_Review_Load(object sender, EventArgs e)
        {
            con = new OracleConnection(ordb);
            con.Open();
            OracleCommand cmd = new OracleCommand() ;
            cmd.Connection = con;
            cmd.CommandText = "MOVIE_DETAILS_PROC";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("film_id" , Browse_Movie.selected_film_id);
            cmd.Parameters.Add("film_name",OracleDbType.Varchar2, ParameterDirection.Output);
            cmd.Parameters.Add("film_caregory", OracleDbType.Varchar2 , ParameterDirection.Output);
            cmd.Parameters.Add("photo_url", OracleDbType.Varchar2 , ParameterDirection.Output);
            cmd.Parameters.Add("film_rating", OracleDbType.Double, ParameterDirection.Output);
            cmd.Parameters.Add("number_of_ratings", OracleDbType.Int32, ParameterDirection.Output);
            cmd.Parameters["film_name"].Size = 400;
            cmd.Parameters["film_caregory"].Size = 400;
            cmd.Parameters["photo_url"].Size = 400;
            cmd.ExecuteNonQuery();
          
            try
            {
                label1.Text = cmd.Parameters["film_name"].Value.ToString();
                label2.Text =cmd.Parameters["film_rating"].Value.ToString();
                label3.Text = cmd.Parameters["film_caregory"].Value.ToString();
                Image img1 = Image.FromFile(@"Textures\movies\" + cmd.Parameters["photo_url"].Value.ToString());
                pictureBox1.BackgroundImage = img1;
                film_name = cmd.Parameters["film_name"].Value.ToString(); 
                photo_url = cmd.Parameters["photo_url"].Value.ToString();
                film_rating =double.Parse(cmd.Parameters["film_rating"].Value.ToString());
                number_of_ratings = int.Parse(cmd.Parameters["number_of_ratings"].Value.ToString());
            }
            catch
            {
                MessageBox.Show("error in loading movie");
            }
            listBox1.ScrollAlwaysVisible = true;
            
            OracleCommand cmd2= new OracleCommand();
            cmd2.Connection = con;
            cmd2.CommandText = "GET_MOVIE_REVIEW";
            cmd2.CommandType = CommandType.StoredProcedure;
            cmd2.Parameters.Add("film_id", Browse_Movie.selected_film_id);
            cmd2.Parameters.Add("review", OracleDbType.RefCursor, ParameterDirection.Output);
            OracleDataReader dr = cmd2.ExecuteReader();
            while (dr.Read())
            {
                listBox1.Items.Add(dr[0]);
                listBox1.Items.Add("____________________________________________________");
            }
            dr.Close();
            con.Close();


        }
        // add review button is clicked
        private void button1_Click(object sender, EventArgs e)
        {
            if (Login_Form.is_logged_in)
            {
                this.Hide();
                Add_Review_Form add_review = new Add_Review_Form();
                add_review.ShowDialog();
                this.Close();
            }
            else
            {
                MessageBox.Show("please log in first to add review");
            }
        }
        //back button is clicked 
        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            Browse_Movie search_form = new Browse_Movie();
            search_form.ShowDialog();
            this.Close();
        }
        private void Movie_Review_FormClosed(object sender, FormClosedEventArgs e)
        {
            Login_Form.is_logged_in = false;
        }
    }
}
