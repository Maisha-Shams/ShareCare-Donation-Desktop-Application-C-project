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
using System.IO;

namespace ShareCare
{
    public partial class AcountCreated : Form
    {

        SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-DAML4VN\SQLEXPRESS;Initial Catalog=SHARECARE;Integrated Security=True");
        public AcountCreated()
        {
            InitializeComponent();
            //getProfilePicUser();
            show();
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            this.Hide();
            Dashboard dashboard = new Dashboard();
            dashboard.Show();
        }

        public void show()
        {
            con.Open();

            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "select * from POST_TBL where EMAIL = '"+Login.accountName+"'";
            cmd.ExecuteNonQuery();
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            dataGridView1.DataSource = dt;

            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView1.RowTemplate.Height = 30;
            this.dataGridView1.DefaultCellStyle.WrapMode = DataGridViewTriState.True;

            con.Close();

        }


        private void AcountCreated_Load(object sender, EventArgs e)
        {


            profileUsername.Text = Login.username;
            profileFirstname.Text = Login.firstName;
            profileLastname.Text = Login.lastName;

        }

        public void getProfilePicUser()
        {


            con.Open();

            SqlCommand cmd = new SqlCommand("select Picture from USERS where EMAIL='" + Login.accountName + "'", con);

            SqlDataReader reader;
            reader = cmd.ExecuteReader();

            while (reader.Read())
            {

                SqlConnection con1 = new SqlConnection(@"Data Source=DESKTOP-DAML4VN\SQLEXPRESS;Initial Catalog=SHARECARE;Integrated Security=True");
                SqlCommand cmd1 = new SqlCommand("select Picture from USERS where EMAIL='" + Login.accountName + "'", con1);
                SqlDataAdapter da = new SqlDataAdapter(cmd1);
                DataSet ds = new DataSet();
                da.Fill(ds);

                if (ds.Tables[0].Rows.Count > 0)

                {

                    MemoryStream ms = new MemoryStream((byte[])ds.Tables[0].Rows[0]["Picture"]);

                    pictureBox1.Image = new Bitmap(ms);


                }

            }
            con.Close();
        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            con.Open();
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "insert into POST_TBL (email,post) values ('" + Login.accountName + "','" + textBox1.Text + "')";
            cmd.ExecuteNonQuery();
            con.Close();
            show();
            MessageBox.Show("Post successfull");
        }

        private void pictureBox7_Click(object sender, EventArgs e)
        {
            this.Hide();
            Dashboard dashboard = new Dashboard();
            dashboard.Show();
        }
    }
}
