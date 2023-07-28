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
    public partial class Settings : Form
    {
        string cs = ConfigurationManager.ConnectionStrings["dbcs"].ConnectionString;
        public Settings()
        {
            InitializeComponent();

            username.Text= Login.username ;
            firstname.Text = Login.firstName ;
            lastname.Text = Login.lastName;
            organization.Text = Login.org;
            phone.Text = Login.phone;
            password.Text = Login.pass;
        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button7_Click(object sender, EventArgs e)
        {
            this.Hide();
            ChangePassword changePassword = new ChangePassword();
            changePassword.Show();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            this.Hide();
            Dashboard dashboard = new Dashboard();
            dashboard.Show();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(cs);
            string query = "DELETE FROM USERS WHERE EMAIL = '" + Login.accountName + "' ";
            SqlCommand cmd = new SqlCommand(query, con);
            cmd.Parameters.AddWithValue("@email", firstname.Text);
            cmd.Parameters.AddWithValue("@pass", lastname.Text);

            con.Open();

            SqlDataReader sda = cmd.ExecuteReader();
           
            if (sda.HasRows != true )
            {
                MessageBox.Show("User Deleted", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
                MessageBox.Show("Failed to delete", "Failed", MessageBoxButtons.OK, MessageBoxIcon.Information);

            this.Hide();
            Login login = new Login();
            login.Show();

            con.Close();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(cs);
            string query = "UPDATE USERS SET USERNAME = '"+ username.Text + "', FIRSTNAME= '"+firstname.Text+ "' , LASTNAME= '" + lastname.Text + "', ORGANIZATION= '" + organization.Text + "' , PHONE= '" + phone.Text + "' , PASS= '" + password.Text + "' WHERE EMAIL = '" + Login.accountName + "' ";
            Login.username = username.Text;
            Login.firstName = firstname.Text;
            Login.lastName = lastname.Text;
            Login.org = organization.Text;
            Login.phone = phone.Text;
            Login.pass = password.Text;

            SqlCommand cmd = new SqlCommand(query, con);

            con.Open();

            SqlDataReader sda = cmd.ExecuteReader();

            if (sda.HasRows == true)
            {
                MessageBox.Show("Failed to update", "Failed", MessageBoxButtons.OK, MessageBoxIcon.Information);
                
            }
            else
                MessageBox.Show("User info updated", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

            this.Hide();
            AcountCreated accountCreated = new AcountCreated();
            accountCreated.Show();


            con.Close();
        }

        private void Settings_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'sHARECAREDataSet2.USERS' table. You can move, or remove it, as needed.
            this.uSERSTableAdapter.Fill(this.sHARECAREDataSet2.USERS);

        }

        private void button7_Click_1(object sender, EventArgs e)
        {
            this.Hide();
            ChangePassword changePassword = new ChangePassword();
            changePassword.Show();
        }

        private void email_TextChanged(object sender, EventArgs e)
        {
            firstname.Text = Login.accountName;
        }

        private void label4_Click(object sender, EventArgs e)
        {
            firstname.Text = Login.accountName;
        }

        private void label9_Click(object sender, EventArgs e)
        {
            this.Hide();
            Dashboard dashboard = new Dashboard();
            dashboard.Show();
        }
    }
}
