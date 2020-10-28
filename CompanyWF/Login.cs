using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BusinessLogic.Concrete;
using BusinessLogic.Interfaces;
using Unity;

namespace CompanyWF
{
    public partial class Login : Form
    {

        protected readonly IAuthManager _manager;
       

        public Login(IAuthManager manager)
        {
            InitializeComponent();
            _manager = manager;
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            doLogin();
        }

        public long GetId()
        {
            return _manager.GetId(txtUsername.Text);
        }
        private void doLogin()
        {
            if (_manager.Login(txtUsername.Text, txtPassword.Text))
            {
                DialogResult = DialogResult.OK;
                this.Close();
            }
            else
            {
                MessageBox.Show("Invalid credentials");
            }
        }
        private void txtPassword_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                doLogin();
            }
        }

        private void btnCreateAcc_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Yes;
        }

        private void txtPassword_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnForgotPass_Click(object sender, EventArgs e)
        {
            ForgotPassForm pf = new ForgotPassForm(_manager);
            pf.Show();
        }
    }
}
