using MySql.Data.MySqlClient;
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
        MySqlConnection conn = new MySqlConnection();
        public static Homepage frm2;
        public static Delete delete;
        public static theme theme;
        public static Textsize size;
        public static about about;
        public static Loginpage login;
        public static edit_akun editstudent;

        private string nis;

        public Seting()
        {
            InitializeComponent();
        }
        void koneksi()
        {
            String connString;
            connString = "server=127.0.0.1;uid=root;pwd=;database=acomes;SslMode=none";
            try
            {
                conn.ConnectionString = connString;
                conn.Open();
            }
            catch (MySqlException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        public Seting(string nis)
        {
            InitializeComponent();
            this.nis = nis;
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
            delete = new Delete(nis);
            delete.BackColor = this.BackColor;
            delete.Show();
            this.Hide();
        }

        private void label2_Click(object sender, EventArgs e)
        {
            editstudent = new edit_akun(nis);
            editstudent.Show();
            editstudent.BackColor = this.BackColor;
            this.Hide();
        }

        private void label3_Click(object sender, EventArgs e)
        {
            theme = new theme(nis);
            theme.BackColor = this.BackColor;
            theme.Show();
            this.Hide();
        }

        private void label4_Click(object sender, EventArgs e)
        {
            size = new Textsize(nis);
            size.BackColor = this.BackColor;
            size.Show();
            this.Hide();
        }

        private void label6_Click(object sender, EventArgs e)
        {
            about = new about(nis);
            about.BackColor = this.BackColor;
            about.Show();
            this.Hide();
        }

        private void Seting_Load(object sender, EventArgs e)
        {
            koneksi();
            Loginpage frm1 = new Loginpage();
            String sql = "SELECT Theme FROM student WHERE email = '" + frm1.getemail() + "'";
            MySqlCommand cmd = new MySqlCommand(sql, conn);
            MySqlDataReader rdr = cmd.ExecuteReader();
            while (rdr.Read())
            {
                //if (nis == rdr.GetString(0))
                //{
                    if (rdr.GetInt16(0) == 1)
                    {
                        this.BackColor = Color.FromArgb(238, 142, 160);
                    }
                    else if (rdr.GetInt16(0) == 2)
                    {
                        this.BackColor = Color.FromArgb(249, 157, 42);
                    }
                    else if (rdr.GetInt16(0) == 3)
                    {
                        this.BackColor = Color.FromArgb(224, 43, 48);
                    }
                    else if (rdr.GetInt16(0) == 4)
                    {
                        this.BackColor = Color.FromArgb(95, 189, 102);
                    }
                    else if (rdr.GetInt16(0) == 5)
                    {
                        this.BackColor = Color.FromArgb(0, 192, 192);
                    }
                //}
            }
            conn.Close();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            frm2 = new Homepage(nis);
            frm2.Show();
            this.Hide();
        }

        private void label7_Click(object sender, EventArgs e)
        {
            login = new Loginpage();
            login.Show();
            this.Hide();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            editstudent = new edit_akun(nis);
            editstudent.Show();
            editstudent.BackColor = this.BackColor;
            this.Hide();
        }
    }
}
