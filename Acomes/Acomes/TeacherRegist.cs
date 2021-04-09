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
    public partial class TeacherRegist : Form
    {
        MySqlConnection conn = new MySqlConnection();
        public static SignUpPick pick;
        public static Loginpage login;
        public TeacherRegist()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            pick = new SignUpPick();
            pick.Show();
            this.Hide();
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
        
        private void button1_Click_1(object sender, EventArgs e)
        {
            login = new Loginpage();
            login.Show();
            this.Hide();
        }

        private void btnsignup_Click(object sender, EventArgs e)
        {
            String jeniskelamin = "";
            if (rdlaki.Checked)
            {
                jeniskelamin = "Male";
            }
            else if (rdperempuan.Checked)
            {
                jeniskelamin = "Female";
            }

            koneksi();
            String s = "SELECT nik FROM teacher where nik = '" + tbnik.Text + "'";
            MySqlCommand c = new MySqlCommand(s, conn);
            Object r = c.ExecuteScalar();
            String nis = (String)r;

            String sq = "SELECT email FROM teacher where email = '" + tbemail.Text + "'";
            MySqlCommand cm = new MySqlCommand(sq, conn);
            Object re = cm.ExecuteScalar();
            String email = (String)re;

            String user = "SELECT username FROM teacher where username = '" + tbUser.Text + "'";
            MySqlCommand cmd = new MySqlCommand(user, conn);
            Object user1 = cmd.ExecuteScalar();
            String username = (String)user1;
            
            if (nis == tbnik.Text)
            {
                MessageBox.Show("NIK ALREADY USED");
            }
            else if (email == tbemail.Text)
            {
                MessageBox.Show("Email ALREADY USED");
            }

            else if (tbpass.Text != tbpass1.Text)
            {
                MessageBox.Show("Your Password and Reapeat Password Doesn't Same");
            }
            else if (username == tbUser.Text)
            {
                MessageBox.Show("Username Already Used");
            }
            else
            {
                String sql = "INSERT INTO teacher values ('" + tbnik.Text + "','" + tbName.Text + "','" + tbUser.Text + "','" + tbemail.Text + "','" + tbpass.Text + "','" + tbphone.Text + "','" + jeniskelamin + "')";
                MySqlCommand cmd1 = new MySqlCommand(sql, conn);
                cmd1.ExecuteNonQuery();
                //buat tabel forgot password jika akunnya teacher
                String sql2 = "INSERT INTO forgot_teacher values('" + tbnik.Text + "','" + question.Text + "','" + tbanswer.Text + "')";
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
