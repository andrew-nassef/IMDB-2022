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
    public partial class Menu_Form : Form
    {
        public static Dictionary<string, int> film_name_dictionary = new Dictionary<string, int>();
        public static List<string> films_categories_list = new List<string>();
        public static Dictionary<string, string> users_name_password_dictionary = new Dictionary<string, string>();
        public static Dictionary<string, int> users_name_id_dictionary = new Dictionary<string, int>();
        public static Dictionary<int, string> users_id_name_dictionary = new Dictionary<int, string>();
        private static OracleConnection con;
        private static string ordb = "data source = orcl; user id =scott; password=tiger;";

        public Menu_Form()
        {
            InitializeComponent();
        }
        private void Menu_Form_Load(object sender, EventArgs e)
        {
            load_all_dictionaries();
        }

        //login button is clicked
        private void button1_Click(object sender, EventArgs e)
        {
            Login_Form login = new Login_Form();
            login.ShowDialog();
        }
        //register button is clicked
        private void button2_Click(object sender, EventArgs e)
        {
            Register_Form register = new Register_Form();
            register.ShowDialog();
        }
        // browse movie button is clicked
        private void button3_Click(object sender, EventArgs e)
        {
            Browse_Movie search = new Browse_Movie();
            search.ShowDialog();
        }
        public static void load_all_dictionaries()
        {
            film_name_dictionary.Clear();
            users_id_name_dictionary.Clear();
            users_name_id_dictionary.Clear();
            users_name_password_dictionary.Clear();
            con = new OracleConnection(ordb);
            con.Open();
            OracleCommand cmd = new OracleCommand();
            cmd.Connection = con;
            cmd.CommandText = "select filmid , filmname , filmcaregory from films";
            cmd.CommandType = CommandType.Text;
            OracleDataReader dr1 = cmd.ExecuteReader();
            while (dr1.Read())
            {
                film_name_dictionary.Add(dr1[1].ToString(), int.Parse(dr1[0].ToString()));
                if (!films_categories_list.Contains(dr1[2].ToString())){
                    films_categories_list.Add(dr1[2].ToString());
                }
            }
            dr1.Close();

            cmd.CommandText = "select userid, username , userpassword from users";
            cmd.CommandType = CommandType.Text;
            OracleDataReader dr2 = cmd.ExecuteReader();
            while (dr2.Read())
            {
                users_name_password_dictionary.Add(dr2[1].ToString(), dr2[2].ToString());
                users_name_id_dictionary.Add(dr2[1].ToString(), int.Parse(dr2[0].ToString()));
                users_id_name_dictionary.Add(int.Parse(dr2[0].ToString()), dr2[1].ToString());
            }
            dr2.Close();

        }

      
    }
}
