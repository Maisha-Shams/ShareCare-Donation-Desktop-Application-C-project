using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Configuration;
using System.Data.SqlClient;

namespace ShareCare
{
    public partial class Dashboard : Form
    {
        SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-DAML4VN\SQLEXPRESS;Initial Catalog=SHARECARE;Integrated Security=True");
        public Dashboard()
        {
            InitializeComponent();
            show();
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        public void show()
        {
            con.Open();

            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "SELECT USERS.username,USERS.phone, POST_TBL.Post FROM USERS INNER JOIN POST_TBL ON USERS.email = POST_TBL.email; ";

            cmd.ExecuteNonQuery();
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            dataGridView1.DataSource = dt;

            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView1.RowTemplate.Height = 40;
            this.dataGridView1.DefaultCellStyle.WrapMode = DataGridViewTriState.True;

            con.Close();

        }

        private void button7_Click(object sender, EventArgs e)
        {
            this.Hide();
            Login login = new Login();
            login.Show();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            this.Hide();
            AcountCreated acountCreated = new AcountCreated();
            acountCreated.Show();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            this.Hide();
            Help help = new Help();
            help.Show();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            this.Hide();
            PaymentOptions Po = new PaymentOptions();
            Po.Show();
        }

        private void button10_Click(object sender, EventArgs e)
        {
            this.Hide();
            Settings settings = new Settings();
            settings.Show();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            this.Hide();
            Faq faq = new Faq();
            faq.Show();
        }


        private void Dashboard_Load(object sender, EventArgs e)
        {


        }

        private void user_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        public void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            DonationTracker donationTracker = new DonationTracker();
            donationTracker.Show();



        }

        private void button5_Click(object sender, EventArgs e)
        {
            con.Open();
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "insert into POST_TBL (email,post) values ('" + Login.accountName + "','" + Dpost.Text + "')";
            cmd.ExecuteNonQuery();
            con.Close();
            show();
            MessageBox.Show("Post successful");

            Dpost.Clear();

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
    }

















