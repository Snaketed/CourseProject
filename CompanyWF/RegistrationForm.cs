using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using BusinessLogic.Interfaces;

namespace CompanyWF
{
    public partial class RegistrationForm : Form
    {
        protected readonly IRegistManager _manager;
        public string result="Registration Successful";
        public RegistrationForm(IRegistManager manager)
        {
            InitializeComponent();
            _manager = manager;

        }
        private void btnOK_Click(object sender, EventArgs e)
        {
            doCreateAccount();
        }

        private void doCreateAccount()

        {
            Regex rEmail = new Regex(@"^[a-zA-Z][\w\.-]*[a-zA-Z0-9]@[a-zA-Z0-9][\w\.-]*[a-zA-Z0-9]\.[a-zA-Z][a-zA-Z\.]*[a-zA-Z]$");
            if (txtPassword.Text != txtConfirmPassword.Text)
            {
                 MessageBox.Show("Passwords do not match");
            }
            else if (!rEmail.IsMatch(txtEmail.Text.Trim()) ||
                txtFistName.Text.Trim() == "" ||
                txtPassword.Text.Trim() == "" ||
                txtLastName.Text.Trim() == "" ||
                txtPhoneNum.Text.Trim() == "" ||
                txtGender.Text.Trim() == "" )
            {
                MessageBox.Show("Fill all the information or Check Email address");
            }
            else
            {
                
                try
                {
                    _manager.CreateUser(txtFistName.Text, txtLastName.Text, txtEmail.Text, txtPhoneNum.Text, txtPassword.Text,
                        txtGender.Text, txtKeyword.Text);

                    MessageBox.Show(result, "Information",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information,
                        MessageBoxDefaultButton.Button1,
                        MessageBoxOptions.RightAlign);
                    this.Close();
                }
                catch (Exception ex)
                {

                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
