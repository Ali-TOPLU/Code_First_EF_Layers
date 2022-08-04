using System;

using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using EF_Project.BLL.Service;

namespace EF_Project.UI
{
   public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        bool fieldError;
        Form2 form2 = new Form2();



        private void btnLogin_Click(object sender, EventArgs e)
        {
            FieldControl();
            if (fieldError)
            {
                Connection();
                Clear();
            }
            
        }

        private void Clear()
        {
            foreach (Control item in this.Controls)
            {
                if (item is TextBox)
                {
                    ((TextBox)item).Text = string.Empty;
                }
            }
        }

        public void Connection()
        {
            UserService userService = new UserService();
            
            if (userService.FindUser(txtUserName.Text, txtPassword.Text)==1)
            {
                MessageBox.Show("YES");
            }
            else
            {
                MessageBox.Show("NO");
            }
            


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
                    fieldError = true;
                }
            }
        }

        private void chkShowPassword_CheckedChanged(object sender, EventArgs e)
        {
            if (chkShowPassword.Checked)
            {
                txtPassword.PasswordChar = '\0';

            }
            else
            {
                txtPassword.PasswordChar = '*';
            }
        }

        private void lblCreateNewAccount_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {

            form2.Show();
            this.Hide();
        }
        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }
    }
}
