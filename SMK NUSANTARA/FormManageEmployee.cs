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
    public partial class FormManageEmployee : Form
    {
        private DatabaseDataContext db = new DatabaseDataContext();
        int currentSelectedRow = -1;
        string status = "";
        public FormManageEmployee()
        {
            InitializeComponent();
        }

        private void FormManageEmployee_Load(object sender, EventArgs e)
        {
            loadDgv();
            enableButton(true);
            cbPosition.Items.AddRange(new string[]
            {
                "Admin",
                "Chef",
                "Cashier"
            });
        }

        private void loadDgv()
        {
            dgvData.Rows.Clear();
            var query = db.Msemployees.Select(x => new
            {
                x.EmployeeID,
                x.Name,
                x.Email,
                x.Handphone,
                x.Position
            });

            dgvData.DataSource = query;
        }

        private void enableButton(bool e)
        {

            btnInsert.Enabled = e;
            btnUpdate.Enabled = !e;
            btnDelete.Enabled = !e;

        }

        

        private bool Validation()
        {
            if (tbEmployeeId.Text == string.Empty || tbName.Text == string.Empty || tbEmail.Text == string.Empty || tbHandphone.Text == string.Empty || cbPosition.Text == string.Empty)
            {
                Support.MSE("All field must be filled");
                return false;
            }
            return true;
        }

        private void btnInsert_Click(object sender, EventArgs e)
        {
            if (Validation())
            {
                var a = new Msemployee();
                a.EmployeeID = tbEmployeeId.Text;
                a.Name = tbName.Text;
                a.Email = tbEmail.Text;
                a.Handphone = tbHandphone.Text;
                a.Position = cbPosition.Text;

                db.Msemployees.InsertOnSubmit(a);
                db.SubmitChanges();
                Support.MSI("Insert Data Success");
                Support.clearFields(this);
            }
        }

        private void getID()
        {
            var lastID = db.Msemployees.OrderByDescending(x => x.EmployeeID).FirstOrDefault();
            int NewId = lastID != null ? (int.Parse(lastID.EmployeeID.Trim()) + 1) : 1;

            tbEmployeeId.Text = NewId.ToString();
        }

        private void dgvData_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                currentSelectedRow = e.RowIndex;
                tbEmployeeId.Text = dgvData.Rows[e.RowIndex].Cells["EmployeeID"].Value.ToString();
                tbName.Text = dgvData.Rows[e.RowIndex].Cells["Name"].Value.ToString();
                tbEmail.Text = dgvData.Rows[e.RowIndex].Cells["Email"].Value.ToString();
                tbHandphone.Text = dgvData.Rows[e.RowIndex].Cells["Handphone"].Value.ToString();
                cbPosition.Text = dgvData.Rows[e.RowIndex].Cells["Position"].Value.ToString();

                enableButton(true);

            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (currentSelectedRow == -1)
            {
                Support.MSW("Click Row");
            }
            else
            {
                status = "update";
                btnSave.Enabled = true;
                btnCancel.Enabled = true;
                btnSave.Visible = true;
                btnCancel.Visible = true;
            }
        }

        
    }
}
