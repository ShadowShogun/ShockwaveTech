﻿
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Timers;
using Timer = System.Windows.Forms.Timer;
using mock_up.Classes;
using mock_up.Forms;

/// <summary>
/// home space for the Business letting it see their queue and business functions
/// </summary>
namespace mock_up
{
    public partial class BusHome : Form
    {
        //need the business name to get orders
        NotificationController notification = new NotificationController();
        string username;
        string email;
        string emailPassword;
        Business user;
        DBController dB = new DBController();

        public BusHome(Business n)
        {
            
            username = n.Username;
            email = n.Email;
            user = n;
            emailPassword = n.EmailPass;
            InitializeComponent();
        }

        private void ordersBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            this.Validate();
            this.ordersBindingSource.EndEdit();
            this.tableAdapterManager1.UpdateAll(this.userbaseDataSet);

        }

        //on form load uses this to get table
        private void BusHome_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'userbaseDataSet.Orders' table. You can move, or remove it, as needed.
            DataTable dt = dB.GetTable("SELECT * FROM Orders WHERE business='" + username + "'");
            ordersDataGridView.DataSource = dt;
            SetTimer(sender, e);
        }

        //just restarts program
        private void logOutBut_Click(object sender, EventArgs e)
        {
            Start restart = new Start();
            restart.Show();
            this.Close();
        }
        
        //sets timer to refresh every min
        private void SetTimer(object sender, EventArgs e)
        {
            Timer timer = new Timer();
            timer.Interval = (10 * 1000); // 10 secs
            timer.Tick += new EventHandler(timer_Tick);
            timer.Start();
        }

        //function called every min
        private void timer_Tick(object sender, EventArgs e)
        {
            DataTable dt = dB.GetTable("SELECT * FROM Orders WHERE business='" + username + "'");
            ordersDataGridView.DataSource = dt;
        }

        //sends email to customer
        private void notifyBut_Click(object sender, EventArgs e)
        {
            //grabs name from selected row then calls the controller to grab the email
            string custEmail = dB.CustEmail
                (ordersDataGridView.SelectedRows[0].Cells["Customer"].Value.ToString());
            notification.Notifiy(email, custEmail, emailPassword);
        }

        private void removeBut_Click(object sender, EventArgs e)
        {
            dB.RemoveOrder(ordersDataGridView.SelectedRows[0].Cells["Customer"].Value.ToString(), username);
            timer_Tick(sender, e);
        }

        private void accountBut_Click(object sender, EventArgs e)
        {
            BusinessPageForm change = new BusinessPageForm(user);
            change.Show();
        }
    }
}