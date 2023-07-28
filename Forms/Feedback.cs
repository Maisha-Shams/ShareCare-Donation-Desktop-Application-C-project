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
    public partial class Feedback : Form
    {
        public Feedback()
        {
            InitializeComponent();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            this.Hide();
            Help help = new Help();
            help.Show();
        }

        private void label8_Click(object sender, EventArgs e)
        {
            this.Hide();
            Dashboard dashboard = new Dashboard();
            dashboard.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            MessageBox.Show("We Will Get Back To You Shortly", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
