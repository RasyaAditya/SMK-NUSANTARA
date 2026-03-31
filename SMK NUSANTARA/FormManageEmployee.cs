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
            getID();
            accessButtonAndField(true);
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
                x.Position,
                x.Password
            });

            dgvData.DataSource = query;
            dgvData.Columns["Password"].Visible = false;
        }

        private void enabeField(bool e)
        {
            tbName.Enabled = !e;
            tbEmail.Enabled = !e;
            tbHandphone.Enabled = !e;
            cbPosition.Enabled = !e;
        }

        private void enableButton(bool e)
        {

            btnInsert.Enabled = e;
            btnUpdate.Enabled = e;
            btnDelete.Enabled = e;
            btnSave.Enabled = !e;
            btnCancel.Enabled = !e;

        }

        private void visibleButton(bool e)
        {
            btnInsert.Visible = e;
            btnUpdate.Visible = e;
            btnDelete.Visible = e;
            btnSave.Visible = !e;
            btnCancel.Visible = !e;
        }

        private void accessButtonAndField(bool e)
        {
            enabeField(e);
            enableButton(e);
            visibleButton(e);
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

        private void btnInsert_Click(object sender, EventArgs e)
        {
            Support.clearFields(this);
            status = "insert";
            accessButtonAndField(false);
            getID();
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
                accessButtonAndField(false);
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (currentSelectedRow == -1)
            {
                Support.MSW("Click Row");
            }else
            {
                var dialog = MessageBox.Show("Are you sure want to delete this data?", "Question", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                try
                {
                    if(dialog == DialogResult.Yes)
                    {
                        var delete = db.Msemployees.FirstOrDefault(x => x.EmployeeID == tbEmployeeId.Text);
                        db.Msemployees.DeleteOnSubmit(delete);
                        db.SubmitChanges();
                        loadDgv();
                        Support.MSI("Delete Data Success");
                        Support.clearFields(this);
                        getID();
                    }
                }catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (status == "insert")
            {
                if (Validation())
                {
                    var a = new Msemployee();
                    a.EmployeeID = tbEmployeeId.Text;
                    a.Name = tbName.Text;
                    a.Email = tbEmail.Text;
                    a.Handphone = tbHandphone.Text;
                    a.Position = cbPosition.Text;
                    a.Password = "";

                    db.Msemployees.InsertOnSubmit(a);
                    db.SubmitChanges();
                    loadDgv();
                    Support.MSI("Insert Data Success");
                    Support.clearFields(this);
                    accessButtonAndField(true);
                    getID();
                }
            }


            if (status == "update")
            {
                if (Validation())
                {
                    try
                    {
                        var queryUpdate = db.Msemployees.FirstOrDefault(x => x.EmployeeID == tbEmployeeId.Text);
                        if(queryUpdate != null)
                        {
                            queryUpdate.Name = tbName.Text;
                            queryUpdate.Email = tbEmail.Text;
                            queryUpdate.Handphone = tbHandphone.Text;
                            queryUpdate.Position = cbPosition.Text;

                            db.SubmitChanges();
                            loadDgv();
                            Support.MSI("Update Data Success");
                            Support.clearFields(this);
                            accessButtonAndField(true);
                            getID();
                        }
                    }catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                }
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            status = "";
            accessButtonAndField(true);
        }
    }
}
