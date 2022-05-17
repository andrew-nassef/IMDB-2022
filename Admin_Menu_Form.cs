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
using CrystalDecisions.Shared;

namespace IDMB_project
{
    public partial class Admin_Menu_Form : Form
    {
        OracleDataAdapter adapter;
        OracleCommandBuilder builder;
        DataSet ds;
        string ordb = "data source = orcl; user id =scott; password=tiger;";
        public static Movies_by_category movies_category_cr;
        public static Movie_reviews_report movies_reviews_cr;
        public static Users_report users_cr;
        public static int opened_report;
        public Admin_Menu_Form()
        {
            InitializeComponent();
        }
        private void Admin_Menu_Form_Load(object sender, EventArgs e)
        {
            movies_category_cr = new Movies_by_category();
            movies_reviews_cr = new Movie_reviews_report();
            users_cr = new Users_report();
           // foreach(ParameterDiscreteValue v in movies_category_cr.ParameterFields[0].DefaultValues)
           // {
             //   comboBox2.Items.Add(v.Value);
            //}
            foreach (string i in Menu_Form.films_categories_list)
            {
                comboBox2.Items.Add(i);
            }
            comboBox2.Text = comboBox2.Items[0].ToString();

       
            foreach(string i in Menu_Form.film_name_dictionary.Keys)
            {
                comboBox3.Items.Add(i.ToString());
                comboBox1.Items.Add(i.ToString());
            }
            comboBox3.Text = comboBox3.Items[0].ToString();
            comboBox1.Text = comboBox1.Items[0].ToString();


        }
        //show movies button is clicked
        private void button1_Click(object sender, EventArgs e)
        {

            string cmds = "select * from films  ";
            adapter = new OracleDataAdapter(cmds, ordb);
            ds = new DataSet();
            adapter.Fill(ds);
            dataGridView1.DataSource = ds.Tables[0];
        }
        //show reviews button is clicked
        private void button2_Click(object sender, EventArgs e)
        {
            if (Menu_Form.film_name_dictionary.ContainsKey(comboBox3.Text)) {
                int film_id = Menu_Form.film_name_dictionary[comboBox3.Text];
                string cmds = "select * from filmreviews where filmid =:film_id";
                adapter = new OracleDataAdapter(cmds, ordb);
                adapter.SelectCommand.Parameters.Add("film_id", film_id);
                ds = new DataSet();
                adapter.Fill(ds);
                dataGridView1.DataSource = ds.Tables[0];
            }
            else
            {
                MessageBox.Show("film name is not found!");
            }
        }
        //show users button is clicked
        private void button3_Click(object sender, EventArgs e)
        {

            string cmds = "select * from users  ";
            adapter = new OracleDataAdapter(cmds, ordb);
            ds = new DataSet();
            adapter.Fill(ds);
            dataGridView1.DataSource = ds.Tables[0];
        }       
        //update button is clicked
        private void button4_Click(object sender, EventArgs e)
        {
            builder = new OracleCommandBuilder(adapter);
            adapter.Update(ds.Tables[0]);
            MessageBox.Show("table is updated");
            dataGridView1.ClearSelection();
            Menu_Form.load_all_dictionaries();
            Admin_Menu_Form_Load (sender,  e);
        }
        // movie_reviews_report button is pressed
        private void button5_Click(object sender, EventArgs e)
        {
            opened_report = 1;
            movies_reviews_cr.SetParameterValue("film_name_parameter", comboBox1.Text);
            Reports_form reports_form = new Reports_form();
            reports_form.ShowDialog();
        }

        // films_report button is pressed
        private void button6_Click(object sender, EventArgs e)
        {
            opened_report = 2;
            movies_category_cr.SetParameterValue(0, comboBox2.Text);
            Reports_form reports_form = new Reports_form();
            reports_form.ShowDialog();
        }
        //show users report button is clicked
        private void button7_Click(object sender, EventArgs e)
        {
            opened_report = 3;
            Reports_form reports_Form = new Reports_form();
            reports_Form.ShowDialog();
        }

   
    }
}
