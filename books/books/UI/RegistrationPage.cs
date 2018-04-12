using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using books.BLL;
using books.DAL;
using System.IO;
namespace books.UI
{
    public partial class RegistrationPage : Form
    {
        public RegistrationPage()
        {
            InitializeComponent();
        }
        string imgLocation = "";
        UsersBLL userbll = new UsersBLL();
        UsersDAL userdal = new UsersDAL();
        private void clear()
        {
            txtFirst.Text = "";
            txtLast.Text = "";
            txtEmail.Text = "";
            txtUser.Text = "";
            txtPassword.Text = "";
            txtContact.Text = "";
            cmbBatch.Text = "";
            cmbDept.Text = "";
            comboBox1.Text = "";
            cmbGender.Text = "";

        }
        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (txtFirst.Text == "" || txtLast.Text == "" || txtEmail.Text == "" || txtUser.Text == "" || txtPassword.Text == "" || txtContact.Text == "" || comboBox1.Text == "" || cmbDept.Text == "" || cmbGender.Text == "" || cmbBatch.Text == "")
            {
                MessageBox.Show("All Fields Are Mandatory", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                userbll.Firstname = txtFirst.Text;
                userbll.Lastname = txtLast.Text;
                userbll.Email = txtEmail.Text;
                userbll.Username = txtUser.Text;
                userbll.Password = txtPassword.Text;
                userbll.Contact = txtContact.Text;
                userbll.UserType = comboBox1.Text.ToString();
                userbll.img = imgLocation;
                userbll.Depart = cmbDept.Text;
                userbll.Gender = cmbGender.Text;
                userbll.Batch = cmbBatch.Text;
                userbll.Added_date = DateTime.Now;
                userbll.Added_by = 1;
                bool success = userdal.insertData(userbll);
                if (success == true)
                {
                    MessageBox.Show("Data Entered Successfully");
                    clear();
                    
                }
                else
                {
                    MessageBox.Show("Data Failed to enter");
                }
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Filter = "jpg files(*.jpg)|*.jpg|png files (*.png)|*.png|All files(*.*)|*.*";
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                imgLocation = dialog.FileName.ToString();
                pictureBox1.ImageLocation = imgLocation;
               
                
            }
           
        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void RegistrationPage_Load(object sender, EventArgs e)
        {

        }
    }
}
