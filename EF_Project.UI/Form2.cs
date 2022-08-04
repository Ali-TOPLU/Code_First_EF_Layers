using EF_Project.BLL.Service;
using EF_Project.DATA;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EF_Project.UI
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        bool PhoneNumberIsDigit = false, fieldError = false, PasswordDifficulty = false;


        private void Form2_Load(object sender, EventArgs e)
        {
            GetCity();
        }

        private void GetCity()
        {
            CityService cityService = new CityService();
            cmbCity.DataSource = cityService.GetCity();
            cmbCity.DisplayMember = "CityName";
            cmbCity.ValueMember = "ID";
        }

        private void Form2_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void btnSignUp_Click(object sender, EventArgs e)
        {
            FieldControl();
            if (fieldError)
            {
                PasswordCheck();

                if (PasswordDifficulty)
                {
                    IsDigit();
                    if (PhoneNumberIsDigit)
                    {
                        UserService userService = new UserService();
                        User user = new User();
                        user.UserName = txtUserName.Text;
                        user.Password = txtPassword.Text;
                        user.Email = txtEmail.Text;
                        
                        user.UserOfDetail = new UserDetail()
                        {
                            PhoneNumber = txtPhoneNumber.Text,
                            CityID = (int)cmbCity.SelectedValue,
                            FirstName = txtFirstName.Text,
                            LastName = txtLastName.Text,
                            Birthday=dtpBirthday.Value
                            
                        };
                        userService.AddUser(user);
                       
                        MessageBox.Show("Registration Completed Successfully");
                        PasswordDifficulty = false;
                        PhoneNumberIsDigit = false;


                    }

                }
                else
                {
                    MessageBox.Show("Incorrect password setting. \n Min 8 Max 12 Characters \n Uppercase and Lowercase, \n Must Contain Numbers.");
                }


            }


        }

        private void PasswordCheck()
        {
            bool HasSmallChar = false, HasBigChar = false, HasDigit = false;
            if (txtPassword.Text.Length > 8 && txtPassword.Text.Length < 12)
            {

                foreach (char c in txtPassword.Text)
                {
                    if (char.IsUpper(c)) HasBigChar = true;
                    else if (char.IsLower(c)) HasSmallChar = true;
                    else if (char.IsDigit(c)) HasDigit = true;
                }


            }
            if (HasBigChar)
            {
                if (HasSmallChar)
                {
                    if (HasDigit)
                    {
                        PasswordDifficulty = true;

                    }
                    else
                    {
                        PasswordDifficulty = false;
                    }

                }
                else
                {
                    PasswordDifficulty = false;
                }
            }
            else
            {
                PasswordDifficulty = false;
            }
        }

        private void IsDigit()
        {
            foreach (char c in txtPhoneNumber.Text)
            {
                if (char.IsDigit(c))
                {
                    PhoneNumberIsDigit = true;
                }
                else
                {
                    MessageBox.Show("Phone Number Must be Number Only!...");
                    PhoneNumberIsDigit = false;
                    break;
                }

            }
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            Form1 form1 = new Form1();
            form1.Show();
            this.Hide();
        }

        private void FieldControl()
        {
            foreach (Control item in this.Controls)
            {
                if (item is TextBox)
                {
                    if (((TextBox)item).Text.Trim() == "")
                    {
                        MessageBox.Show("Please fill in all the information");
                        fieldError = false;
                        break;
                    }

                }
                else if (item is DateTimePicker)
                {
                    if (((DateTimePicker)item).Value.Date == DateTime.Now.Date)
                    {
                        MessageBox.Show("Please Select Your Birthday Date");
                        fieldError = false;
                        break;
                    }

                }
                fieldError = true;
            }
        }
    }
}
