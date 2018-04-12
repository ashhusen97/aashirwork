using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using books.UI;
using books.BLL;
using books.DAL;
namespace books
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
       public static string user = "";
        UsersBLL usersbll = new UsersBLL();
        UsersDAL usersdal = new UsersDAL();
        static int counter = 2;
        private void button1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            progressBar1.Show();
            timer1.Enabled = true;
            user = txtUser.Text;
          
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {

            SentEmail em = new SentEmail();
            em.Show();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            progressBar1.Hide();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            
            progressBar1.Value = progressBar1.Value + 5;
            if (progressBar1.Value == 100)
            {
                
                timer1.Enabled = false;
                progressBar1.Hide();
                usersbll.Username = txtUser.Text;
                usersbll.Password = txtPassword.Text;
                usersbll.UserType = comboBox1.Text.ToString();
                bool success = usersdal.Login(usersbll);
                if (success == true)
                {
                    switch (usersbll.UserType)
                    {
                        case "Admin":
                            this.Hide();
                            AdminPanel ap = new AdminPanel();
                            ap.Show();
                            break;
                        case "Student":
                            this.Hide();
                    AccountPage ap1 = new AccountPage();
                    ap1.Show();
                    break;
                        default:
                    MessageBox.Show("--- Please Select one ---");
                    break;
                    }
                    
                }
                else
                {
                    MessageBox.Show("Wrong ID and Password", "Login Error",MessageBoxButtons.OK,MessageBoxIcon.Error);
                   
                    counter--;
                    if (counter < 0)
                    {
                        SentEmail se = new SentEmail();
                        se.Show();

                    }
                   
                    progressBar1.Value = 0;
                }
                
            }
        }
    }
}
