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
using System.IO;

namespace IDMB_project
{
    public partial class Add_Rating : Form
    {
        Image golden_star; 
        Image white_star;
        OracleConnection con;
        string ordb = "data source = orcl; user id =scott; password=tiger;";
        private void Add_Rating_Load(object sender, EventArgs e)
        {
          golden_star = Image.FromFile(@"Textures\golden star.png");
          white_star= Image.FromFile(@"Textures\white star.png");
          con = new OracleConnection(ordb);
          con.Open();
        }
        public Add_Rating()
        {
            InitializeComponent();
        }
        #region mouse_leave_enter_functions
        private void button1_MouseLeave(object sender, EventArgs e)
        {
            button1.BackgroundImage = white_star;      
        }

        private void button1_MouseEnter(object sender, EventArgs e)
        {
            button1.BackgroundImage = golden_star;
        }
        private void button2_MouseLeave(object sender, EventArgs e)
        {
            button1.BackgroundImage = white_star;
            button2.BackgroundImage = white_star;

        }

        private void button2_MouseEnter(object sender, EventArgs e)
        {
            button1.BackgroundImage = golden_star;
            button2.BackgroundImage = golden_star;

        }
        private void button3_MouseLeave(object sender, EventArgs e)
        {
            button1.BackgroundImage = white_star;
            button2.BackgroundImage = white_star;
            button3.BackgroundImage = white_star;
        }

        private void button3_MouseEnter(object sender, EventArgs e)
        {
            button1.BackgroundImage = golden_star;
            button2.BackgroundImage = golden_star;
            button3.BackgroundImage = golden_star;
        }
        private void button4_MouseLeave(object sender, EventArgs e)
        {
            button1.BackgroundImage = white_star;
            button2.BackgroundImage = white_star;
            button3.BackgroundImage = white_star;
            button4.BackgroundImage = white_star;
        }

        private void button4_MouseEnter(object sender, EventArgs e)
        {
            button1.BackgroundImage = golden_star;
            button2.BackgroundImage = golden_star;
            button3.BackgroundImage = golden_star;
            button4.BackgroundImage = golden_star;
        }
        private void button5_MouseLeave(object sender, EventArgs e)
        {
            button1.BackgroundImage = white_star;
            button2.BackgroundImage = white_star;
            button3.BackgroundImage = white_star;
            button4.BackgroundImage = white_star;
            button5.BackgroundImage = white_star;
        }

        private void button5_MouseEnter(object sender, EventArgs e)
        {
            button1.BackgroundImage = golden_star;
            button2.BackgroundImage = golden_star;
            button3.BackgroundImage = golden_star;
            button4.BackgroundImage = golden_star;
            button5.BackgroundImage = golden_star;
        }
        private void button6_MouseLeave(object sender, EventArgs e)
        {
            button1.BackgroundImage = white_star;
            button2.BackgroundImage = white_star;
            button3.BackgroundImage = white_star;
            button4.BackgroundImage = white_star;
            button5.BackgroundImage = white_star;
            button6.BackgroundImage = white_star;
        }

        private void button6_MouseEnter(object sender, EventArgs e)
        {
            button1.BackgroundImage = golden_star;
            button2.BackgroundImage = golden_star;
            button3.BackgroundImage = golden_star;
            button4.BackgroundImage = golden_star;
            button5.BackgroundImage = golden_star;
            button6.BackgroundImage = golden_star;
        }
        private void button7_MouseLeave(object sender, EventArgs e)
        {
            button1.BackgroundImage = white_star;
            button2.BackgroundImage = white_star;
            button3.BackgroundImage = white_star;
            button4.BackgroundImage = white_star;
            button5.BackgroundImage = white_star;
            button6.BackgroundImage = white_star;
            button7.BackgroundImage = white_star;
        }

        private void button7_MouseEnter(object sender, EventArgs e)
        {

            button1.BackgroundImage = golden_star;
            button2.BackgroundImage = golden_star;
            button3.BackgroundImage = golden_star;
            button4.BackgroundImage = golden_star;
            button5.BackgroundImage = golden_star;
            button6.BackgroundImage = golden_star;
            button7.BackgroundImage = golden_star;
        }
        private void button8_MouseLeave(object sender, EventArgs e)
        {
            button1.BackgroundImage = white_star;
            button2.BackgroundImage = white_star;
            button3.BackgroundImage = white_star;
            button4.BackgroundImage = white_star;
            button5.BackgroundImage = white_star;
            button6.BackgroundImage = white_star;
            button7.BackgroundImage = white_star;
            button8.BackgroundImage = white_star;
        }

        private void button8_MouseEnter(object sender, EventArgs e)
        {
            button1.BackgroundImage = golden_star;
            button2.BackgroundImage = golden_star;
            button3.BackgroundImage = golden_star;
            button4.BackgroundImage = golden_star;
            button5.BackgroundImage = golden_star;
            button6.BackgroundImage = golden_star;
            button7.BackgroundImage = golden_star;
            button8.BackgroundImage = golden_star;
        }
        private void button9_MouseLeave(object sender, EventArgs e)
        {
            button1.BackgroundImage = white_star;
            button2.BackgroundImage = white_star;
            button3.BackgroundImage = white_star;
            button4.BackgroundImage = white_star;
            button5.BackgroundImage = white_star;
            button6.BackgroundImage = white_star;
            button7.BackgroundImage = white_star;
            button8.BackgroundImage = white_star;
            button9.BackgroundImage = white_star;
        }

        private void button9_MouseEnter(object sender, EventArgs e)
        {
            button1.BackgroundImage = golden_star;
            button2.BackgroundImage = golden_star;
            button3.BackgroundImage = golden_star;
            button4.BackgroundImage = golden_star;
            button5.BackgroundImage = golden_star;
            button6.BackgroundImage = golden_star;
            button7.BackgroundImage = golden_star;
            button8.BackgroundImage = golden_star;
            button9.BackgroundImage = golden_star;
        }
        private void button10_MouseLeave(object sender, EventArgs e)
        {
            button1.BackgroundImage = white_star;
            button2.BackgroundImage = white_star;
            button3.BackgroundImage = white_star;
            button4.BackgroundImage = white_star;
            button5.BackgroundImage = white_star;
            button6.BackgroundImage = white_star;
            button7.BackgroundImage = white_star;
            button8.BackgroundImage = white_star;
            button9.BackgroundImage = white_star;
            button10.BackgroundImage = white_star;
        }

        private void button10_MouseEnter(object sender, EventArgs e)
        {

            button1.BackgroundImage = golden_star;
            button2.BackgroundImage = golden_star;
            button3.BackgroundImage = golden_star;
            button4.BackgroundImage = golden_star;
            button5.BackgroundImage = golden_star;
            button6.BackgroundImage = golden_star;
            button7.BackgroundImage = golden_star;
            button8.BackgroundImage = golden_star;
            button9.BackgroundImage = golden_star;
            button10.BackgroundImage = golden_star;
        }


        #endregion
        #region buttons_click
        private void button1_Click(object sender, EventArgs e)
        {
            star_clicked(1);
        }
        private void button2_Click(object sender, EventArgs e)
        {
            star_clicked(2);
        }
        private void button3_Click(object sender, EventArgs e)
        {
            star_clicked(3);
        }
        private void button4_Click(object sender, EventArgs e)
        {
            star_clicked(4);
        }
        private void button5_Click(object sender, EventArgs e)
        {
            star_clicked(5);
        }
        private void button6_Click(object sender, EventArgs e)
        {
            star_clicked(6);
        }
        private void button7_Click(object sender, EventArgs e)
        {
            star_clicked(7);
        }
        private void button8_Click(object sender, EventArgs e)
        {
            star_clicked(8);
        }
        private void button9_Click(object sender, EventArgs e)
        {
            star_clicked(9);
        }
        private void button10_Click(object sender, EventArgs e)
        {
            star_clicked(10);
        }
        #endregion
        private void star_clicked(double rating)
        {
            rating = (Movie_Review.film_rating * Movie_Review.number_of_ratings) + rating;
            rating = rating / (Movie_Review.number_of_ratings + 1);
            rating = Math.Round(rating, 2);
            Movie_Review.number_of_ratings++;
            OracleCommand cmd = new OracleCommand();
            cmd.Connection = con;
            cmd.CommandText = "update films set filmrating =:film_rating , numberofratings =:no_of_ratings where filmid =:film_id";
            cmd.CommandType = CommandType.Text;
            cmd.Parameters.Add("film_rating", rating);
            cmd.Parameters.Add("no_of_ratings", Movie_Review.number_of_ratings);
            cmd.Parameters.Add("film_id", Browse_Movie.selected_film_id);
            cmd.ExecuteNonQuery();

            OracleCommand cmd2 = new OracleCommand();
            cmd2.Connection = con;
            cmd2.CommandType = CommandType.Text;
            cmd2.CommandText = "insert into usersratings values (:film_id , :user_id)";
            cmd2.Parameters.Add("film_id" , Browse_Movie.selected_film_id);
            cmd2.Parameters.Add("user_id", Login_Form.logged_in_user_id);
            cmd2.ExecuteNonQuery();

            con.Close();

            Add_Review_Form.users_ratings_dictionary[Browse_Movie.selected_film_id].Add(Login_Form.logged_in_user_id);
            MessageBox.Show("Movie rating is added");
            this.Close();
        }
       
    }
}
