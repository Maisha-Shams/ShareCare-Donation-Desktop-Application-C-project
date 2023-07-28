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
    public partial class AdminPanel : Form
    {
        SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-DAML4VN\SQLEXPRESS;Initial Catalog=SHARECARE;Integrated Security=True");
        public AdminPanel()
        {
            InitializeComponent();
            loadUsers();
            loadPosts();
            loadDonation();
        }

        public void loadUsers()
        {
            con.Open();

            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "select USERNAME,EMAIL from USERS";
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

        public void loadPosts()
        {
            con.Open();

            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "select * from POST_TBL";
            cmd.ExecuteNonQuery();
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            dataGridView2.DataSource = dt;

            dataGridView2.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView2.RowTemplate.Height = 30;
            this.dataGridView2.DefaultCellStyle.WrapMode = DataGridViewTriState.True;

            con.Close();

        }

        public void loadDonation()
        {
            con.Open();

            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "select * FROM HISTORY";
            cmd.ExecuteNonQuery();
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            dataGridView3.DataSource = dt;

            dataGridView3.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView3.RowTemplate.Height = 30;
            this.dataGridView3.DefaultCellStyle.WrapMode = DataGridViewTriState.True;

            con.Close();

        }

        private void label11_Click(object sender, EventArgs e)
        {

        }

        private void AdminPanel_Load(object sender, EventArgs e)
        {

        }

        private void deleteUserBtn_Click(object sender, EventArgs e)
        {

            con.Open();
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "DELETE FROM USERS WHERE EMAIL = '" +textBox1.Text + "' ";
            cmd.ExecuteNonQuery();

            SqlDataReader sda = cmd.ExecuteReader();

            if (sda.HasRows != true)
            {
                MessageBox.Show("User Deleted", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                
            }
            else
                MessageBox.Show("Failed to delete User", "Failed", MessageBoxButtons.OK, MessageBoxIcon.Information);


            con.Close();

            loadUsers();
            textBox1.Clear();
        }

        private void deletePostBtn_Click(object sender, EventArgs e)
        {
            con.Open();
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "DELETE FROM POST_TBL WHERE ID = '" + textBox2.Text + "' ";
            cmd.ExecuteNonQuery();

            SqlDataReader sda = cmd.ExecuteReader();

            if (sda.HasRows != true)
            {
                MessageBox.Show("Post Deleted", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                
            }
            else
                MessageBox.Show("Failed to delete Post", "Failed", MessageBoxButtons.OK, MessageBoxIcon.Information);

            con.Close();

            loadPosts();
            textBox2.Clear();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            Login lg = new Login();
            lg.Show();
        }
    }
}
