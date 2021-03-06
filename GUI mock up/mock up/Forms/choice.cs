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
/// decides what kind of user is using the system
/// </summary>
namespace mock_up
{
    public partial class choice : Form
    {
        public choice()
        {
            InitializeComponent();
        }

        //creates a new window and sends what button they pressed
        private void busBut_Click(object sender, EventArgs e)
        {
            Login login = new Login('B');
            login.Show();
            this.Close();
        }

        private void userBut_Click(object sender, EventArgs e)
        {
            Login login = new Login('C');
            login.Show();
            this.Close();
        }

        private void backButton_Click(object sender, EventArgs e)
        {
            Start reset = new Start();
            reset.Show();
            this.Close();
        }
    }
}
