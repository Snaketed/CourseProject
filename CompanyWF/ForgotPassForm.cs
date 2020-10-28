using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BusinessLogic.Interfaces;

namespace CompanyWF
{
    public partial class ForgotPassForm : Form
    {
        protected readonly IAuthManager _manager;
        public ForgotPassForm(IAuthManager manager)
        {
            InitializeComponent();
            _manager = manager;
        }

        private void btnConfirm_Click(object sender, EventArgs e)
        {
            try
            {
                _manager.ForgotPass(txtKeyword.Text, txtNewPassword.Text, txtEmail.Text);
                this.Close();
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
            }
           
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
