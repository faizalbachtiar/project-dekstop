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
    public partial class themeteacher : Form
    {
        MySqlConnection conn = new MySqlConnection();
        public static setingTeacher seting;
        public static HomepageTeacher homepage;
        public static about about;
        public static Delete delete;
        public static edit_akun edit;
        public static Textsize text;

        private string NIK;

        public themeteacher()
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
        public themeteacher(String NIK)
        {
            InitializeComponent();
            this.NIK = NIK;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            BackColor = Color.FromArgb(249, 157, 42);
        }

        private void btnRed_Click(object sender, EventArgs e)
        {
            BackColor = Color.FromArgb(224, 43, 48);
        }

        private void btnGreen_Click(object sender, EventArgs e)
        {
            BackColor = Color.FromArgb(95, 189, 102);
        }

        private void btnNavy_Click(object sender, EventArgs e)
        {
            BackColor = Color.FromArgb(0, 192, 192);
        }

        private void btndefault_Click(object sender, EventArgs e)
        {
            BackColor = Color.FromArgb(238, 142, 160);

        }

        private void button2_Click(object sender, EventArgs e)
        {
            seting = new setingTeacher();
            Loginpage frm1 = new Loginpage();
            //ganti back Color seting
            seting.BackColor = this.BackColor;
            seting.Show();
            this.Hide();
            koneksi();

            String s = "SELECT nik FROM teacher WHERE email = '" + frm1.getemail() + "'";
            MySqlCommand c = new MySqlCommand(s, conn);
            Object result = c.ExecuteScalar();
            String nik = (String)result;

            String sql = "";
            if (BackColor == Color.FromArgb(238, 142, 160))
            {
                sql = "UPDATE teacher SET Theme = 1 WHERE NIK = '" + nik + "'";
            }
            else if (BackColor == Color.FromArgb(249, 157, 42))
            {
                sql = "UPDATE teacher SET Theme = 2 WHERE NIK = '" + nik + "'";
            }
            else if (BackColor == Color.FromArgb(224, 43, 48))
            {
                sql = "UPDATE teacher SET Theme = 3 WHERE NIK = '" + nik + "'";
            }
            else if (BackColor == Color.FromArgb(95, 189, 102))
            {
                sql = "UPDATE teacher SET Theme = 4 WHERE NIK = '" + nik + "'";
            }
            else if (BackColor == Color.FromArgb(0, 192, 192))
            {
                sql = "UPDATE teacher SET Theme = 5 WHERE NIK = '" + nik + "'";
            }
            MySqlCommand cmd = new MySqlCommand(sql, conn);
            cmd.ExecuteNonQuery();
            conn.Close();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            seting = new setingTeacher(NIK);
            seting.Show();
            this.Hide();
        }
        
        private void themeteacher_Load(object sender, EventArgs e)
        {
            koneksi();
            String sql = "Select NIK, Theme from teacher";
            MySqlCommand cmd = new MySqlCommand(sql, conn);
            MySqlDataReader rdr = cmd.ExecuteReader();
            while (rdr.Read())
            {
                if (NIK == rdr.GetString(0))
                {
                    if (rdr.GetInt16(1) == 1)
                    {
                        this.BackColor = Color.FromArgb(238, 142, 160);
                    }
                    else if (rdr.GetInt16(1) == 2)
                    {
                        this.BackColor = Color.FromArgb(249, 157, 42);
                    }
                    else if (rdr.GetInt16(1) == 3)
                    {
                        this.BackColor = Color.FromArgb(224, 43, 48);
                    }
                    else if (rdr.GetInt16(1) == 4)
                    {
                        this.BackColor = Color.FromArgb(95, 189, 102);
                    }
                    else if (rdr.GetInt16(1) == 5)
                    {
                        this.BackColor = Color.FromArgb(0, 192, 192);
                    }
                }
            }
            conn.Close();
        }
    }
}
