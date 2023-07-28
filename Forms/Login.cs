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

    public partial class Login : Form
    {
        public static string accountName;
        public static string username;
        public static string firstName;
        public static string lastName;
        public static string phone;
        public static string org;
        public static string pass;

        string cs = ConfigurationManager.ConnectionStrings["dbcs"].ConnectionString;
        public Login()
        {
            InitializeComponent();
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            bool status = checkBox1.Checked;

            switch (status)
            {
                case true:
                    textBox2.UseSystemPasswordChar = false;
                    break;
                default:
                    textBox2.UseSystemPasswordChar = true;
                    break;
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(textBox1.Text=="adminMaisha" && textBox2.Text == "123")
            {
                this.Hide();
                AdminPanel r = new AdminPanel();
                r.Show();
            }

            else if (textBox1.Text != "" && textBox2.Text != "")
            {
                SqlConnection con = new SqlConnection(cs);
                string query = "select * from USERS where EMAIL = @email and PASS = @pass";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@email", textBox1.Text);
                cmd.Parameters.AddWithValue("@pass", textBox2.Text);
                accountName = textBox1.Text;

                con.Open();

                SqlDataReader sda = cmd.ExecuteReader();


                if (sda.HasRows == true)
                {
                    MessageBox.Show("Login Successful", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    this.Hide();
                    Dashboard dboard = new Dashboard();
                    dboard.Show();
                }
                else
                    MessageBox.Show("Login Failed", "Failed", MessageBoxButtons.OK, MessageBoxIcon.Information);
                con.Close();
            }

            /*else
            {
                MessageBox.Show("Fill the Field", "Failed", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }*/

            //reading data


            SqlConnection con2 = new SqlConnection(cs);
            string query2 = "select username,firstname,lastname,phone,ORGANIZATION,PASS from USERS where EMAIL = '" + textBox1.Text + "'";
            SqlCommand cmd2 = new SqlCommand(query2, con2);

            accountName = textBox1.Text;

            con2.Open();

            SqlDataReader da = cmd2.ExecuteReader();
            while (da.Read())
            {
                username = da["USERNAME"].ToString();
                firstName = da["FIRSTNAME"].ToString();
                lastName = da["LASTNAME"].ToString();
                phone = da["PHONE"].ToString();
                org = da["ORGANIZATION"].ToString();
                pass = da["PASS"].ToString();

            }
            con2.Close();

        }

        private void textBox1_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBox1.Text))
            {
                textBox1.Focus();
                errorProvider1.Icon = Properties.Resources.Hopstarter_Sleek_Xp_Basic_Close_2;
                errorProvider1.SetError(this.textBox1, "Fill the Field");
            }
            else
            {
                errorProvider1.Icon = Properties.Resources.Oxygen_Icons_org_Oxygen_Actions_dialog_ok_apply;
                //errorProvider1.Clear();

            }
        }

        private void textBox2_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBox2.Text))
            {
                textBox2.Focus();
                errorProvider2.Icon = Properties.Resources.Hopstarter_Sleek_Xp_Basic_Close_2;
                errorProvider2.SetError(this.textBox2, "Fill the Field");
            }
            else
            {
                errorProvider2.Icon = Properties.Resources.Oxygen_Icons_org_Oxygen_Actions_dialog_ok_apply;
                //errorProvider2.Clear();

            }
        }

        private void label5_Click(object sender, EventArgs e)
        {
            this.Hide();
            Register r = new Register();
            r.Show();

        }

        private void Login_Load(object sender, EventArgs e)
        {
            textBox2.UseSystemPasswordChar = true;
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
    }
}
