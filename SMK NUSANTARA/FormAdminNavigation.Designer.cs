namespace SMK_NUSANTARA
{
    partial class FormAdminNavigation
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label3 = new System.Windows.Forms.Label();
            this.lblName = new System.Windows.Forms.Label();
            this.btnManageEmployee = new System.Windows.Forms.Button();
            this.btnManageMenu = new System.Windows.Forms.Button();
            this.btnManageMember = new System.Windows.Forms.Button();
            this.btnChangePassword = new System.Windows.Forms.Button();
            this.btnLogout = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI Semibold", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(78, 9);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(240, 37);
            this.label3.TabIndex = 5;
            this.label3.Text = "Admin Navigation";
            // 
            // lblName
            // 
            this.lblName.AutoSize = true;
            this.lblName.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblName.Location = new System.Drawing.Point(12, 68);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(0, 21);
            this.lblName.TabIndex = 6;
            // 
            // btnManageEmployee
            // 
            this.btnManageEmployee.Location = new System.Drawing.Point(128, 122);
            this.btnManageEmployee.Name = "btnManageEmployee";
            this.btnManageEmployee.Size = new System.Drawing.Size(136, 26);
            this.btnManageEmployee.TabIndex = 7;
            this.btnManageEmployee.Text = "Manage Employee";
            this.btnManageEmployee.UseVisualStyleBackColor = true;
            this.btnManageEmployee.Click += new System.EventHandler(this.btnManageEmployee_Click);
            // 
            // btnManageMenu
            // 
            this.btnManageMenu.Location = new System.Drawing.Point(128, 154);
            this.btnManageMenu.Name = "btnManageMenu";
            this.btnManageMenu.Size = new System.Drawing.Size(136, 26);
            this.btnManageMenu.TabIndex = 8;
            this.btnManageMenu.Text = "Manage Menu";
            this.btnManageMenu.UseVisualStyleBackColor = true;
            // 
            // btnManageMember
            // 
            this.btnManageMember.Location = new System.Drawing.Point(128, 186);
            this.btnManageMember.Name = "btnManageMember";
            this.btnManageMember.Size = new System.Drawing.Size(136, 26);
            this.btnManageMember.TabIndex = 9;
            this.btnManageMember.Text = "Manage Member";
            this.btnManageMember.UseVisualStyleBackColor = true;
            // 
            // btnChangePassword
            // 
            this.btnChangePassword.Location = new System.Drawing.Point(128, 218);
            this.btnChangePassword.Name = "btnChangePassword";
            this.btnChangePassword.Size = new System.Drawing.Size(136, 26);
            this.btnChangePassword.TabIndex = 10;
            this.btnChangePassword.Text = "Change Password";
            this.btnChangePassword.UseVisualStyleBackColor = true;
            // 
            // btnLogout
            // 
            this.btnLogout.Location = new System.Drawing.Point(128, 250);
            this.btnLogout.Name = "btnLogout";
            this.btnLogout.Size = new System.Drawing.Size(136, 26);
            this.btnLogout.TabIndex = 11;
            this.btnLogout.Text = "Logout";
            this.btnLogout.UseVisualStyleBackColor = true;
            this.btnLogout.Click += new System.EventHandler(this.btnLogout_Click);
            // 
            // FormAdminNavigation
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.ClientSize = new System.Drawing.Size(393, 365);
            this.Controls.Add(this.btnLogout);
            this.Controls.Add(this.btnChangePassword);
            this.Controls.Add(this.btnManageMember);
            this.Controls.Add(this.btnManageMenu);
            this.Controls.Add(this.btnManageEmployee);
            this.Controls.Add(this.lblName);
            this.Controls.Add(this.label3);
            this.Name = "FormAdminNavigation";
            this.Text = "FrmAdminNav";
            this.Load += new System.EventHandler(this.FormAdminNavigation_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.Button btnManageEmployee;
        private System.Windows.Forms.Button btnManageMenu;
        private System.Windows.Forms.Button btnManageMember;
        private System.Windows.Forms.Button btnChangePassword;
        private System.Windows.Forms.Button btnLogout;
    }
}