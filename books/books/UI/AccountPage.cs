using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using books.DAL;
using System.IO;
using System.Configuration;
using System.Data.SqlClient;
namespace books.UI
{
    public partial class AccountPage : Form
    {
        public AccountPage()
        {
            InitializeComponent();
        }
        UsersDAL userdal = new UsersDAL();
        static String myconnection = ConfigurationManager.ConnectionStrings["connection"].ConnectionString;
        private void panel1_Paint(object sender, PaintEventArgs e)
        {
         
        }

        private void AccountPage_Load(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(myconnection);
            DataTable dt = new DataTable();
            try
            {
                String sql = "SELECT * FROM Users where Username = @username";
                SqlCommand cmd = new SqlCommand(sql, con);
                cmd.Parameters.AddWithValue("@username", Form1.user);
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                con.Open();
                adapter.Fill(dt);
                label4.Text = dt.Rows[0][1]+" "+dt.Rows[0][2].ToString();
                byte[] MyData = new byte[0];
                MyData = (byte[])dt.Rows[0][7];
                MemoryStream str = new MemoryStream(MyData);
                pictureBox2.Image = Image.FromStream(str);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            finally
            {
                con.Close();
            }
           
            pt.Hide();
            timer1.Start();
            if (DateTime.Now.ToString("tt") == "AM")
            {
                pictureBox1.Image = Image.FromFile(Environment.CurrentDirectory + "\\night.png");
                pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;

            }
            else if (DateTime.Now.ToString("tt") == "PM")
            {
                pictureBox1.Image = Image.FromFile(Environment.CurrentDirectory + "\\sun.png");
                pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            label1.Text = DateTime.Now.ToString("HH:mm:ss:tt");
            label2.Text = DateTime.Now.ToString("MMM-dd-yyyy");
           
        }

        private void button6_Click(object sender, EventArgs e)
        {
            this.Close();
            Form1 main = new Form1();
            main.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            pt.Show();
            pt.Top = button2.Top;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            pt.Show();
            pt.Top = button3.Top;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            pt.Show();
            pt.Top = button4.Top;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            pt.Show();
            pt.Top = button5.Top;
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }
    }
}
