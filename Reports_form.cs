using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace IDMB_project
{
    public partial class Reports_form : Form
    {      
        public Reports_form()
        {
            InitializeComponent();
        }
        private void Reports_form_Load(object sender, EventArgs e)
        {
            if (Admin_Menu_Form.opened_report == 2)
                crystalReportViewer1.ReportSource = Admin_Menu_Form.movies_category_cr;
            else if (Admin_Menu_Form.opened_report == 1)
                crystalReportViewer1.ReportSource = Admin_Menu_Form.movies_reviews_cr;
            else if (Admin_Menu_Form.opened_report == 3)
                crystalReportViewer1.ReportSource = Admin_Menu_Form.users_cr;
        }
    }
}
