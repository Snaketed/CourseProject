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
using DTO;

namespace CompanyWF
{
    public partial class ProfileForm : Form
    {
        private readonly IUserInfoManager _manager;
        private readonly long _id = Program.Id;
        private UsersDTO user;
        private UserAddressDTO _userAddress;
        private UserCardInfoDTO _userCardInfo;
        public ProfileForm(IUserInfoManager manager)
        {
            InitializeComponent();
            _manager = manager;

            user = _manager.GetUserById(_id);

            InitialComp();
        }

        private void InitialComp()
        {
            lblFullName.Text = user.FirstName + "   " + user.LastName;
            lblEmail.Text = user.Email;
            lblContact.Text = user.PhoneNumber;
            

            cobCounty.Items.Clear();
            cobCounty.DataSource = _manager.GetAllCountry();
            cobCounty.DisplayMember = "Country1";
            cobCounty.ValueMember = "CountryId";
            cobCounty.SelectedValue = "";

            cobCity.Items.Clear();
            cobCity.DataSource = _manager.GetAllCity();
            cobCity.DisplayMember = "City1";
            cobCity.ValueMember = "CityId";
            cobCity.SelectedValue = "";

            if (_manager.GetUserAddressById(_id) != null)
            {
                ShowAddress();
            }
            else
                HideAddress();

            if (_manager.GetCardInfoById(_id) != null)
            {
                ShowCardInfo();
            }
            else
                HideCardInfo();
        }

        private void btnSaveAddress_Click(object sender, EventArgs e)
        {


          
            if (_manager.GetUserAddressById(_id) != null)
            {
                var m = _manager.GetUserAddressById(_id);
                m.UserId = _id;
                m.City = Convert.ToInt32(cobCity.SelectedValue.ToString());
                m.Country = Convert.ToInt32(cobCounty.SelectedValue.ToString());
                m.PostalCode = Convert.ToInt32(txtPostalCode.Text);
                _manager.UpdateUserAddress(m);
            }
            else
            {
                _userAddress = new UserAddressDTO
                {
                    UserId = _id,
                    City = Convert.ToInt32(cobCity.SelectedValue.ToString()),
                    Country = Convert.ToInt32(cobCounty.SelectedValue.ToString()),
                    PostalCode = Convert.ToInt32(txtPostalCode.Text)
                };

                _userAddress = _manager.CreateUserAddress(_userAddress);
            }

            ShowAddress();

        }

        private void ShowAddress()
        {
            _userAddress = _manager.GetUserAddressById(_id);
            cobCity.Hide();
            cobCounty.Hide();
            txtPostalCode.Hide();

            lblCountry.Text = _manager.GetCountryById(_userAddress.Country).Country1;
            lblCountry.Show();

            lblCity.Text = _manager.GetCityById(_userAddress.City).City1;
            lblCity.Show();

            lblPostalCode.Text = Convert.ToString(_userAddress.PostalCode);
            lblPostalCode.Show();
        }

        private void HideAddress()
        {
            lblCity.Hide();
            lblCountry.Hide();
            lblPostalCode.Hide();
            cobCity.Show();
            cobCounty.Show();
            txtPostalCode.Show();

        }
        private void HideCardInfo()
        {
            lblCVC.Hide();
            lblCardNumber.Hide();
            lblDate.Hide();
            txtCVC.Show();
            txtYear.Show();
            txtMonths.Show();
            txtCardNumber.Show();


        }

        private void ShowCardInfo()
        {
            _userCardInfo = _manager.GetCardInfoById(_id);
            txtMonths.Hide();
            txtYear.Hide();
            txtCardNumber.Hide();
            txtCVC.Hide();

            lblCardNumber.Text = Convert.ToString(_userCardInfo.CardNumber);
            lblCardNumber.Show();

           

            lblDate.Text = _userCardInfo.ValidMonth + '/' + _userCardInfo.ValidYear;
            lblDate.Show();

            lblCVC.Text = _userCardInfo.CVC;
            lblCVC.Show();
        }

        private void btnChangeAddress_Click(object sender, EventArgs e)
        {
            HideAddress();

        }

        private void label11_Click(object sender, EventArgs e)
        {

        }

        private void btnSaveCard_Click(object sender, EventArgs e)
        {
            if (_manager.GetCardInfoById(_id) != null)
            {
                var m = _manager.GetCardInfoById(_id);
                m.UserId = _id;
                m.CardNumber = txtCardNumber.Text;
                m.CVC = txtCVC.Text;
                m.ValidYear = txtYear.Text;
                m.ValidMonth = txtMonths.Text;
                _manager.UpdateUserCardInfo(m);
            }
            else
            {
                _userCardInfo = new UserCardInfoDTO
                {
                    UserId = _id,
                    CardNumber = txtCardNumber.Text,
                    CVC = txtCVC.Text,
                    ValidYear = txtYear.Text,
                    ValidMonth = txtMonths.Text,
            };

                _userCardInfo = _manager.CreateUserCardInfo(_userCardInfo);
            }

            ShowCardInfo();
        }

        private void btnChangeCard_Click(object sender, EventArgs e)
        {
            HideCardInfo();
        }

        private void txtMonths_TextChanged(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void panel4_Paint(object sender, PaintEventArgs e)
        {

        }

        private void lblContact_Click(object sender, EventArgs e)
        {

        }

        private void lblEmail_Click(object sender, EventArgs e)
        {

        }

        private void lblFullName_Click(object sender, EventArgs e)
        {

        }
    }
}
