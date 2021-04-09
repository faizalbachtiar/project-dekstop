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
    public partial class edit_akun : Form
    {
        MySqlConnection conn = new MySqlConnection();
        public static Loginpage frm1;
        public Loginpage Parent;
        public static Seting seting;
        public static Homepage home;

        private string nis;

        public edit_akun()
        {
            InitializeComponent();
        }

        public edit_akun(string nis)
        {
            InitializeComponent();
            this.nis = nis;
            panggilnama(nis);
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

        void panggilnama(String nis)
        {
            Loginpage frm1 = new Loginpage();
            koneksi();
            String sql = "Select * from student";
            MySqlCommand cmd = new MySqlCommand(sql, conn);
            MySqlDataReader rdr = cmd.ExecuteReader();
            while (rdr.Read())
            {
                if (nis == (String)rdr[0])
                {
                    textBox1.Text = rdr.GetString(1);
                    textBox2.Text = rdr.GetString(2);
                    textBox3.Text = rdr.GetString(3);
                    textBox4.Text = "";
                    textBox5.Text = "";
                    textBox6.Text = rdr.GetString(4);
                    textBox7.Text = rdr.GetString(0);
                }
            }
            rdr.Close();
            conn.Close();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            seting = new Seting(nis);
            seting.BackColor = this.BackColor;
            seting.Show();
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (textBox4.Text == "" && textBox5.Text == "")
            {
                koneksi();
                String sql = "UPDATE student SET Name = '" + textBox1.Text + "', Password ='" + textBox3.Text + "', Phone ='" + textBox6.Text + "' WHERE NIS = '" + nis + "'";
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                cmd.ExecuteNonQuery();
                conn.Close();
                MessageBox.Show("Your account data has been successfully changed");
                home = new Homepage();
                home.Show();
                this.Hide();
            }
            else if (textBox4.Text == textBox5.Text)
            {
                koneksi();
                String sql = "UPDATE student SET Name = '" + textBox1.Text + "', Password ='" + textBox4.Text + "', Phone ='" + textBox6.Text + "' WHERE NIS = '" + nis + "'";
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                cmd.ExecuteNonQuery();
                conn.Close();
                MessageBox.Show("Your account data has been successfully changed");
                home = new Homepage();
                home.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Sorry your new password and repeat password doesn't same");
            }
        }

        private void edit_akun_Load(object sender, EventArgs e)
        {
            koneksi();
            String sql = "Select NIS, Theme from student";
            MySqlCommand cmd = new MySqlCommand(sql, conn);
            MySqlDataReader rdr = cmd.ExecuteReader();
            while (rdr.Read())
            {
                if (nis == rdr.GetString(0))
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
