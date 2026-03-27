using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SMK_NUSANTARA
{
    public partial class FormAdminNavigation : Form
    {
        public FormAdminNavigation()
        {
            InitializeComponent();
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            Form1 f = new Form1();
            f.Show();
            this.Close();
        }

        private void FormAdminNavigation_Load(object sender, EventArgs e)
        {
            lblName.Text = $"Welcome, " + DataStorage.userName;
        }

        private void btnManageEmployee_Click(object sender, EventArgs e)
        {
            FormManageEmployee f = new FormManageEmployee();
            f.Show();
            this.Hide();
        }
    }
}
