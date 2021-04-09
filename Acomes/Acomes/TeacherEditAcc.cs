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
    public partial class TeacherEditAcc : Form
    {
        MySqlConnection conn = new MySqlConnection();
        public static Loginpage frm1;
        public Loginpage Parent;
        private static setingTeacher seting;
        private static HomepageTeacher home;

        private String NIK;

        public TeacherEditAcc()
        {
            InitializeComponent();
        }

        public TeacherEditAcc(String NIK)
        {
            InitializeComponent();
            this.NIK = NIK;
            panggilnama(NIK);
        }

        public TeacherEditAcc(Loginpage parent)
        {
            InitializeComponent();
            frm1 = Parent;
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
        private void TeacherEditAcc_Load(object sender, EventArgs e)
        {
            flowLayoutPanel1.BackColor = this.BackColor;
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

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            seting = new setingTeacher(NIK);
            seting.BackColor = this.BackColor;
            seting.Show();
            this.Hide();
        }
        
        private void button2_Click(object sender, EventArgs e)
        {
            Loginpage frm1 = new Loginpage();

            if (tbNewPass.Text == "" && tbRepeat.Text == "")
            {
                koneksi();
                String sql = "UPDATE teacher SET Name = '" + tbNama.Text + "', Password ='" + tbPass.Text + "', Phone ='" + tbPhone.Text + "' WHERE NIK = '" + NIK + "'";
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                cmd.ExecuteNonQuery();
                conn.Close();
                MessageBox.Show("Your account data has been successfully changed");
                home = new HomepageTeacher();
                home.Show();
                this.Hide();
            }
            else if (tbNewPass.Text == tbRepeat.Text)
            {
                koneksi();
                String sql = "UPDATE teacher SET Name = '" + tbNama.Text + "', Password ='" + tbRepeat.Text + "', Phone ='" + tbPhone.Text + "' WHERE NIK = '" + NIK + "'";
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                cmd.ExecuteNonQuery();
                conn.Close();
                MessageBox.Show("Your account data has been successfully changed");
                home = new HomepageTeacher();
                home.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Sorry your new password and repeat password doesn't same");
            }
        }

        void panggilnama(String nip)
        {
            Loginpage frm1 = new Loginpage();
            koneksi();
            String sql = "Select * from teacher";
            MySqlCommand cmd = new MySqlCommand(sql, conn);
            MySqlDataReader rdr = cmd.ExecuteReader();
            while (rdr.Read())
            {
                if (NIK == (String)rdr[0])
                {

                    tbNip.Text = rdr.GetString(0);
                    tbNama.Text = rdr.GetString(1);
                    tbUsername.Text = rdr.GetString(2);
                    tbEmail.Text = rdr.GetString(3);
                    tbPass.Text = rdr.GetString(4);
                    tbNewPass.Text = "";
                    tbRepeat.Text = "";
                    tbPhone.Text = rdr.GetString(5);

                }
            }
            rdr.Close();
            conn.Close();
        }
    }
}
