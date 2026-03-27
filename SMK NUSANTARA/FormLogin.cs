using System;
using System.Linq;
using System.Windows.Forms;

namespace SMK_NUSANTARA
{
    public partial class Form1 : Form
    {
        private DatabaseDataContext db = new DatabaseDataContext();
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private bool Validation()
        {
            if (tbEmail.Text == string.Empty || tbPassword.Text == string.Empty)
            {
                Support.MSE("All field must be filled");
                return false; 
            }
            return true;
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            if (Validation())
            {
                Msemployee msemployee = db.Msemployees.Where(x => x.Email.Equals(tbEmail.Text) && x.Password.Equals(tbPassword.Text)).FirstOrDefault();

                if (msemployee != null)
                {
                    DataStorage.userId = msemployee.EmployeeID;
                    DataStorage.userName = msemployee.Name;
                    DataStorage.Position = msemployee.Position;

                    if (DataStorage.Position == "Admin")
                    {
                        FormAdminNavigation ad = new FormAdminNavigation();
                        ad.Show();
                        this.Hide();

                    }
                }
            }
        }
    }
}
