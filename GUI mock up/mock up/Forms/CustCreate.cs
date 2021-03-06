﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
/// <summary>
/// form used to create a new customer
/// </summary>
namespace mock_up
{
    public partial class CustCreate : Form
    {
        public CustCreate()
        {
            InitializeComponent();
        }

        //collects all info from textboxes then creates a new customer class
        //then opens a new Search form with new class
        private void Registerbutton_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(UserIDtextBox.Text) || string.IsNullOrEmpty(PasswordtextBox.Text) || string.IsNullOrEmpty(EmailtextBox.Text))
                MessageBox.Show("Please fill all boxes before registering.");
            else
            {
                string username = UserIDtextBox.Text;
                string pass = PasswordtextBox.Text;
                string email = EmailtextBox.Text;
                try
                {
                    Customer create = new Customer(username, pass, email);
                    MessageBox.Show("Your account has been created!");
                    Search start = new Search(create);
                    start.Show();
                    this.Close();
                }
                catch(System.InvalidOperationException)
                {
                    MessageBox.Show("this account already exists");
                }
            }
        }
    }
}
