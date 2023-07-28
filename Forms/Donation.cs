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
    public partial class Donation : Form
    {
        SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-DAML4VN\SQLEXPRESS;Initial Catalog=SHARECARE;Integrated Security=True");
        public Donation()
        {
            InitializeComponent();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            this.Hide();
            PaymentOptions paymentOptions = new PaymentOptions();
            paymentOptions.Show();
        }

        public void button13_Click(object sender, EventArgs e)
        {
            con.Open();
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "insert into HISTORY (PHONE,AMOUNT ,DONATIONDATE) values ('" + phone.Text + "','" + amount.Text + "','" + date.Text + "')";
            cmd.ExecuteNonQuery();
            con.Close();
            
            //MessageBox.Show("Post successful");



            MessageBox.Show("Donation Successful", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

            this.Hide();
            DonationTracker donationTracker = new DonationTracker();
            donationTracker.Show();
        }



        private void label9_Click(object sender, EventArgs e)
        {
            this.Hide();
            Dashboard dashboard = new Dashboard();
            dashboard.Show();
        }

        private void Donation_Load(object sender, EventArgs e)
        {
          
        }
    }
}
