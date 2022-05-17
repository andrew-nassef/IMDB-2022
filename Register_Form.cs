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
    public partial class Register_Form : Form
    {
        OracleConnection con;
        string ordb = "data source = orcl; user id =scott; password=tiger;";
        public Register_Form()
        {
            InitializeComponent();
        }
        private void Register_Form_Load(object sender, EventArgs e)
        {
            con = new OracleConnection(ordb);
            con.Open();
        }
        //register button is clicked 
        private void button1_Click(object sender, EventArgs e)
        {
            bool is_username_unique = true;
                foreach (int i in Menu_Form.users_id_name_dictionary.Keys)
                {
                    if (textBox1.Text.ToString() == Menu_Form.users_id_name_dictionary[i])
                    {
                        is_username_unique = false;
                        break;
                    }
                }

                if (!is_username_unique)
                {
                    MessageBox.Show("username is already taken");
                }
                else if (textBox2.Text == "")
                {
                    MessageBox.Show("password field cannot be empty");

                }
                else
                {
                    Random rand = new Random();
                    int new_unique_id;
                    while (true)
                    {
                        new_unique_id = rand.Next(999);
                        if (!(Menu_Form.users_id_name_dictionary.ContainsKey(new_unique_id)))
                        {
                            break;
                        }
                    }
                    OracleCommand cmd2 = new OracleCommand();
                    cmd2.Connection = con;
                    cmd2.CommandText = "insert into users values (:userid , :username , :userpassword) ";
                    cmd2.Parameters.Add("userid", new_unique_id);
                    cmd2.Parameters.Add("username", textBox1.Text);
                    cmd2.Parameters.Add("userpassword", textBox2.Text);
                    int r = cmd2.ExecuteNonQuery();
                    if (r != -1)
                    {
                        Login_Form.logged_in_user_id = new_unique_id;
                        Menu_Form.users_name_password_dictionary.Add(textBox1.Text, textBox2.Text);
                        Menu_Form.users_name_id_dictionary.Add(textBox1.Text, new_unique_id);
                        Menu_Form.users_id_name_dictionary.Add(new_unique_id, textBox1.Text);
                        MessageBox.Show("user is succesfully added");
                        Login_Form.is_logged_in = true;
                        con.Close();
                        this.Hide();
                        Browse_Movie search_form = new Browse_Movie();
                        search_form.ShowDialog();
                        this.Close();

                    }
                }
            }
        }
    }

