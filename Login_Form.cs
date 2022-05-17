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


namespace IDMB_project
{
    public partial class Login_Form : Form
    {
        public static bool is_logged_in = false;
        public static int logged_in_user_id;
        public Login_Form()
        {
            InitializeComponent();
        }
        //login button is pressed
        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "admin" && textBox2.Text == "admin")
            {
                this.Hide();
                Admin_Menu_Form admin_form = new Admin_Menu_Form();
                admin_form.ShowDialog();
                this.Close();
            }
            else
            {
                bool user_is_valid = false;
                foreach(string i in Menu_Form.users_name_password_dictionary.Keys)
                {
                    if(i == textBox1.Text && Menu_Form.users_name_password_dictionary[i] == textBox2.Text)
                    {
                        user_is_valid = true;
                        logged_in_user_id = Menu_Form.users_name_id_dictionary[i];
                        break;
                    }
                }
                if (!user_is_valid)
                {
                    MessageBox.Show("username or password is incorrect");
                }
                else
                {
                    is_logged_in = true;
                    this.Hide();
                    Browse_Movie choose_form = new Browse_Movie();
                    choose_form.ShowDialog();
                    this.Close();
                }
            }
        }
    }
    }
