using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using books.DAL;
using books.BLL;

namespace books.UI
{
    public partial class Update : Form
    {
        public Update()
        {
            InitializeComponent();
        }
        UsersDAL userdal = new UsersDAL();
        UsersBLL userbll = new UsersBLL();
        private void Update_Load(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            dt = userdal.show();
            dataGridView1.DataSource = dt;
        }
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
            cmbUsertype.Text = "";
            cmbGender.Text = "";

        }
        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dataGridView1_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            int rowIndex = e.RowIndex;
            txtID.Text = dataGridView1.Rows[rowIndex].Cells[0].Value.ToString();
            txtFirst.Text = dataGridView1.Rows[rowIndex].Cells[1].Value.ToString();
            txtLast.Text = dataGridView1.Rows[rowIndex].Cells[2].Value.ToString();
            txtEmail.Text = dataGridView1.Rows[rowIndex].Cells[3].Value.ToString();
            txtUser.Text = dataGridView1.Rows[rowIndex].Cells[4].Value.ToString();
            txtPassword.Text = dataGridView1.Rows[rowIndex].Cells[5].Value.ToString();
            txtContact.Text = dataGridView1.Rows[rowIndex].Cells[6].Value.ToString();
            cmbDept.Text = dataGridView1.Rows[rowIndex].Cells[11].Value.ToString();
            cmbGender.Text = dataGridView1.Rows[rowIndex].Cells[13].Value.ToString();
            cmbBatch.Text = dataGridView1.Rows[rowIndex].Cells[12].Value.ToString();
            cmbUsertype.Text = dataGridView1.Rows[rowIndex].Cells[8].Value.ToString();
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            string keyword = textBox2.Text;
            if (keyword != null)
            {
                DataTable dt = new DataTable();
                dt = userdal.search(keyword);
                dataGridView1.DataSource = dt;
            }
            else
            {
                DataTable dt = userdal.show();
                dataGridView1.DataSource = dt;
                
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            userbll.Id = int.Parse(txtID.Text);
            userbll.Firstname = txtFirst.Text;
            userbll.Lastname = txtLast.Text;
            userbll.Email = txtEmail.Text;
            userbll.Username = txtUser.Text;
            userbll.Password = txtPassword.Text;
            userbll.Contact = txtContact.Text;
            userbll.UserType = cmbUsertype.Text;
            userbll.Depart = cmbDept.Text;
            userbll.Gender = cmbGender.Text;
            userbll.Batch = cmbBatch.Text;
            userbll.Added_date = DateTime.Now;
            userbll.Added_by = 1;
            bool success = userdal.update(userbll);
            if (success == true)
            {
                MessageBox.Show("Data Updated Successfully","Successfull",MessageBoxButtons.OK,MessageBoxIcon.Information);
                clear();

            }
            else
            {
                MessageBox.Show("Failed to update Data");
            }
        }
    }
}
