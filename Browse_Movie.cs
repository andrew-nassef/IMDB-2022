using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Oracle.DataAccess.Client;
using Oracle.DataAccess.Types;
using System.IO;

namespace IDMB_project
{
    public partial class Browse_Movie : Form
    {
        OracleConnection con;
        string ordb = "data source = orcl; user id =scott; password=tiger;";
        int right_film_id = 3;
        int left_film_id = 1;
        int mid_film_id = 2;
        int count =3;
        int iterator = 0;
        int pointer = 0;
        public static int selected_film_id;       
        Dictionary<int, string> url_dictionary = new Dictionary<int, string>();
        public Browse_Movie()
        {
            InitializeComponent();
        }
        private void Browse_Movie_Load(object sender, EventArgs e)
        {
            // add movie names in the combo box
            foreach(string i in Menu_Form.film_name_dictionary.Keys)
            {
                comboBox1.Items.Add(i);
            }

            con = new OracleConnection(ordb);
            con.Open();
            OracleCommand cmd = new OracleCommand();
            cmd.Connection = con;
            cmd.CommandText = "select filmid, photourl from films";
            cmd.CommandType = CommandType.Text;
            OracleDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                url_dictionary.Add(int.Parse(dr[0].ToString()), dr[1].ToString());
                
            }
            dr.Close();
            if (url_dictionary.Count >= 3)
            {
                Image img1 = Image.FromFile(@"Textures\movies\" + url_dictionary[1]);
                Image img2 = Image.FromFile(@"Textures\movies\" + url_dictionary[2]);
                Image img3 = Image.FromFile(@"Textures\movies\" + url_dictionary[3]);
                pictureBox1.BackgroundImage = img1;
                pictureBox2.BackgroundImage = img2;
                pictureBox3.BackgroundImage = img3;
            }
            else
            {
             // not implemented
            }
            con.Close();
        }
        // left arrow is clicked 
        private void button1_Click(object sender, EventArgs e)
        {
            if(count == 3) {
                count = url_dictionary.Count - 3;
            }
            else if (count == 2)
            {
                count = url_dictionary.Count - 4;
            }
            else if (count == 1)
            {
                count = url_dictionary.Count - 5;
            }
            else if(count == 4)
            {
                count = url_dictionary.Count -2;
            }
            else if (count == 5)
            {
                count = url_dictionary.Count -1 ;

            }
            else
            {
                count -= 6;
            }
            foreach (int id in url_dictionary.Keys)
            {
                if (count == pointer)
                {
                    if (iterator == 0)
                    {
                        left_film_id = id;
                    }
                    else if (iterator == 1)
                    {
                        mid_film_id = id;
                    }
                    else if (iterator == 2)
                    {
                        right_film_id = id;
                        pointer = 0;
                        iterator = 99;
                        count++; 
                        break;
                    }
                    iterator++;
                    count++;
                }
                pointer++;

            }

            if (iterator < 3)
            {
                count = 1;
                foreach (int id2 in url_dictionary.Keys)
                {
                    if (iterator == 0)
                    {
                        left_film_id = id2;
                    }
                    else if (iterator == 1)
                    {
                        mid_film_id = id2;
                    }
                    else if (iterator == 2)
                    {
                        right_film_id = id2;
                        iterator = 0;
                        pointer = 0;
                        break;
                    }
                    iterator++;
                    count++;
                }
            }
            else
            {
                iterator = 0;
            }
            Image img1 = Image.FromFile(@"Textures\movies\" + url_dictionary[left_film_id]);
            Image img2 = Image.FromFile(@"Textures\movies\" + url_dictionary[mid_film_id]);
            Image img3 = Image.FromFile(@"Textures\movies\" + url_dictionary[right_film_id]);
            pictureBox1.BackgroundImage = img1;
            pictureBox2.BackgroundImage = img2;
            pictureBox3.BackgroundImage = img3;

        }
        //right arrow is clicked
        private void button2_Click(object sender, EventArgs e)
        {
            foreach (int id in url_dictionary.Keys)
            {
                if (count == pointer) {                  
                    if (iterator == 0 )
                    {
                        left_film_id = id;
                    }
                    else if (iterator == 1)
                    {
                        mid_film_id = id;
                    }
                    else if (iterator == 2)
                    {
                        right_film_id = id;                      
                        pointer = 0;
                        iterator = 99;
                        count++;
                        break;
                    }
                    iterator++;
                    count++;
                }
                pointer++;

            }
            
            if(iterator <3)
            {
                count = 1;
                foreach (int id2 in url_dictionary.Keys)
                {
                    if (iterator == 0)
                    {
                        left_film_id = id2;
                    }
                    else if (iterator == 1)
                    {
                        mid_film_id = id2;
                    }
                    else if (iterator == 2)
                    {
                        right_film_id = id2;
                        iterator = 0 ;
                        pointer = 0;
                        break;
                    }
                    iterator++;
                    count++;
                }
            }
            else
            {
                iterator = 0;
            }
            Image img1 = Image.FromFile(@"Textures\movies\" + url_dictionary[left_film_id]);
            Image img2 = Image.FromFile(@"Textures\movies\" + url_dictionary[mid_film_id]);
            Image img3 = Image.FromFile(@"Textures\movies\" + url_dictionary[right_film_id]);
            pictureBox1.BackgroundImage = img1;
            pictureBox2.BackgroundImage = img2;
            pictureBox3.BackgroundImage = img3;




        }
        //search button is clicked
        private void button3_Click(object sender, EventArgs e)
        {
            string str = comboBox1.SelectedItem.ToString();
            selected_film_id = Menu_Form.film_name_dictionary[str];
            this.Hide();
            Movie_Review movie_review_form = new Movie_Review();
            movie_review_form.ShowDialog();
            this.Close();
        }
        private void pictureBox1_Click(object sender, EventArgs e)
        {
            selected_film_id = left_film_id;
            this.Hide();
            Movie_Review movie_review_form = new Movie_Review();
            movie_review_form.ShowDialog();
            this.Close();
        }
        private void pictureBox2_Click(object sender, EventArgs e)
        {
            selected_film_id = mid_film_id;
            this.Hide();
            Movie_Review movie_review_form = new Movie_Review();
            movie_review_form.ShowDialog();
            this.Close();
        }
        private void pictureBox3_Click(object sender, EventArgs e)
        {
            selected_film_id = right_film_id;
            this.Hide();
            Movie_Review movie_review_form = new Movie_Review();
            movie_review_form.ShowDialog();
            this.Close();
        }
        private void Browse_Movie_FormClosed(object sender, FormClosedEventArgs e)
        {
            Login_Form.is_logged_in = false;
        }
    }
}
