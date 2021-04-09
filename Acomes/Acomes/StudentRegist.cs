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
    public partial class StudentRegist : Form
    {
        MySqlConnection conn = new MySqlConnection();
        public static SignUpPick pick;
        public static Homepage Home;
        public static Loginpage login;
        public StudentRegist()
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

        private void button1_Click(object sender, EventArgs e)
        {
            pick = new SignUpPick();
            pick.Show();
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            koneksi();
            String s = "SELECT nis FROM student where nis = '" + tbnis.Text + "'";
            MySqlCommand c = new MySqlCommand(s, conn);
            Object r = c.ExecuteScalar();
            String nis = (String)r;

            String sq = "SELECT email FROM student where email = '" + tbemail.Text + "'";
            MySqlCommand cm = new MySqlCommand(sq, conn);
            Object re = cm.ExecuteScalar();
            String email = (String)re;

            if (nis == tbnis.Text)
            {
                MessageBox.Show("NIS ALREADY USED");
            }
            else if (email == tbemail.Text)
            {
                MessageBox.Show("Email ALREADY USED");
            }
            else if (tbpass.Text != tbpass1.Text)
            {
                MessageBox.Show("Your Password and Reapeat Password Doesn't Same");
            }
            else
            {
                String sql = "INSERT INTO student values ('" + tbnis.Text + "','" + tbname.Text + "','" + tbemail.Text + "','" + tbpass.Text + "','" + tbphone.Text + "')";
                MySqlCommand cmd1 = new MySqlCommand(sql, conn);
                cmd1.ExecuteNonQuery();
                //buat tabel forgot password jika akunnya student
                String sql2 = "INSERT INTO forgot_student values('" + tbnis.Text + "','" + tbquestion.Text + "','" + tbanswer.Text + "')";
                MySqlCommand cmd2 = new MySqlCommand(sql2, conn);
                cmd2.ExecuteNonQuery();
                MessageBox.Show("Your Account Save");
                login = new Loginpage();
                login.Show();
                this.Hide();
            }
            conn.Close();
        }
    }
}
