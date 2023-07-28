using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ShareCare
{
    public partial class Help : Form
    {
        public Help()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            Feedback feedback = new Feedback();
            feedback.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            Faq faq= new Faq();
            faq.Show();
        }

        private void label8_Click(object sender, EventArgs e)
        {
            this.Hide();
            Dashboard dashboard = new Dashboard();
            dashboard.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide();
            ContactInfo contactInfo = new ContactInfo();
            contactInfo.Show();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            this.Hide();
            Dashboard dashboard = new Dashboard();
            dashboard.Show();
        }
    }
}
