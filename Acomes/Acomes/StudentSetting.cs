using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Acomes
{
    public partial class Seting : Form
    {
        public static Homepage frm2;
        public static Delete delete;
        public static edit_akun edit;
        public static theme theme;
        public static Textsize size;
        public static about about;
        public static Loginpage login;
        public Seting()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            frm2 = new Homepage();
            frm2.BackColor = this.BackColor;
            frm2.Show();
            this.Hide();
        }

        private void label5_Click(object sender, EventArgs e)
        {
            delete = new Delete();
            delete.BackColor = this.BackColor;
            delete.Show();
            this.Hide();
        }

        private void label2_Click(object sender, EventArgs e)
        {
            edit = new edit_akun();
            edit.BackColor = this.BackColor;
            edit.Show();
            this.Hide();
        }

        private void label3_Click(object sender, EventArgs e)
        {
            theme = new theme();
            theme.BackColor = this.BackColor;
            theme.Show();
            this.Hide();
        }

        private void label4_Click(object sender, EventArgs e)
        {
            size = new Textsize();
            size.BackColor = this.BackColor;
            size.Show();
            this.Hide();
        }

        private void label6_Click(object sender, EventArgs e)
        {
            about = new about();
            about.BackColor = this.BackColor;
            about.Show();
            this.Hide();
        }

        private void Seting_Load(object sender, EventArgs e)
        {

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            frm2 = new Homepage();
            frm2.BackColor = this.BackColor;
            frm2.Show();
            this.Hide();
        }

        private void label7_Click(object sender, EventArgs e)
        {
            login = new Loginpage();
            login.Show();
            this.Hide();
        }
    }
}
