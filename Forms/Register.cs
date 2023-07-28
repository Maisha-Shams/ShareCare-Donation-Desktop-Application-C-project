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
    public partial class Register : Form
    {
        string cs = ConfigurationManager.ConnectionStrings["dbcs"].ConnectionString;
        byte[] images1 = null;


        public Register()
        {
            InitializeComponent();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Hide();
            Login lg = new Login();
            lg.Show();
        }

        string profileImageLocation = "";


        private string openFileExplorer(PictureBox pictureBox, string imageLocation)
        {
            OpenFileDialog file = new OpenFileDialog();
            file.Filter = "png files (*.png)|*.png|jpg files (*.jpg)|*.jpg";

            if (file.ShowDialog() == DialogResult.OK)
            {


                imageLocation = file.FileName.ToString();
                pictureBox.ImageLocation = imageLocation;

            }
            return imageLocation;
        }



        private void saveProfilePhoto()
        {
            //byte[] images1 = null;
            FileStream stream1 = new FileStream(profileImageLocation, FileMode.Open, FileAccess.Read);
            BinaryReader brs1 = new BinaryReader(stream1);
            images1 = brs1.ReadBytes((int)stream1.Length);
        }


        private void button3_Click(object sender, EventArgs e)
        {




            if (fName.Text != "" && lName.Text != "" && uName.Text != "" && eMail.Text != "")
            {
                saveProfilePhoto();

                SqlConnection con = new SqlConnection(cs);
                string query = "INSERT INTO USERS (FIRSTNAME,LASTNAME,USERNAME,EMAIL,ORGANIZATION,PHONE,PASS,CPASS,PICTURE) values ('" + fName.Text + "','" + lName.Text + "','" + uName.Text + "','" + eMail.Text + "','" + org.Text + "','" + nId.Text + "','" + Pass.Text + "','" + cpass.Text + "','" + images1 + "')";
                SqlCommand cmd = new SqlCommand(query, con);

                con.Open();

                SqlDataReader sda = cmd.ExecuteReader();
                if (sda.HasRows != true)
                {
                    MessageBox.Show("Registration Successful", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    this.Hide();
                    Login login = new Login();
                    login.Show();
                }
                else
                    MessageBox.Show("Registration Failed", "Failed", MessageBoxButtons.OK, MessageBoxIcon.Information);


                con.Close();

            }
            else
            {
                MessageBox.Show("Fill the Field", "Failed", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {

            profileImageLocation = openFileExplorer(imageBox, profileImageLocation);

        }

        private void Register_Load(object sender, EventArgs e)
        {

        }
    }

}


