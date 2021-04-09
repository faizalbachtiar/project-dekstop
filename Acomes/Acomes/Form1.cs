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
    public partial class Loginpage : Form
    {
        MySqlConnection conn = new MySqlConnection();
        public static SignUpPick frm2;
        public static Homepage frm3;
        public static HomepageTeacher frm4;
        public static TeacherEditAcc editteacher;
        public static ForgetPassword forgot;
        private static String Email = "";
        
        public Loginpage()
        {
            InitializeComponent();
            frm3 = new Homepage(this);
            frm3.MdiParent = this;
            editteacher = new TeacherEditAcc(this);
            editteacher.MdiParent = this;
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
        public void setemail(string email)
        {
            Email = email;
        }
        public string getemail()
        {
            return Email;
        }
        private Boolean loginstudent(String Email, String password)
        {
            koneksi();
            String Sql = "Select Email,Password,Name from student";
            MySqlCommand cmd = new MySqlCommand(Sql, conn);
            MySqlDataReader baca = cmd.ExecuteReader();
            while (baca.Read())
            {
                if ((Email.ToLower() == baca.GetString(0)) && password == baca.GetString(1))
                {
                    conn.Close();
                    return true;
                }
            }
            conn.Close();
            return false;
        }

        private Boolean loginTeacher(String Email, String password)
        {
            koneksi();
            String Sql = "Select Email,Password,Name from teacher";
            MySqlCommand cmd = new MySqlCommand(Sql, conn);
            MySqlDataReader baca = cmd.ExecuteReader();
            while (baca.Read())
            {
                if ((Email.ToLower() == baca.GetString(0)) && password == baca.GetString(1))
                {
                    conn.Close();
                    return true;
                }
            }
            conn.Close();
            return false;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            frm2 = new SignUpPick();
            frm2.Show();
            this.Hide();
        }

        private void Loginpage_Load(object sender, EventArgs e)
        {
            foreach(Control ctrl in this.Controls)
            {
                if (ctrl is MdiClient) {
                    ctrl.BackColor = Color.FromArgb(238, 142, 160);
                }
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            if (loginstudent(tbemail.Text, tbpass.Text)== true)
            {
                String isiemail = tbemail.Text.ToLower();
                this.setemail(isiemail);
                MessageBox.Show("Login Success");
                frm3 = new Homepage();
                frm3.Show();
                this.Hide();
            }
            else if (loginTeacher(tbemail.Text, tbpass.Text) == true)
            {
                String isiemail = tbemail.Text.ToLower();
                this.setemail(isiemail);
                MessageBox.Show("Login Success");
                frm4 = new HomepageTeacher();
                frm4.Show();
                this.Hide();
            }

            else
            {
                MessageBox.Show("Sorry your Email and Password Not Found");
            }
            conn.Close();

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void teacherToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
        }

        private void studentToolStripMenuItem_Click(object sender, EventArgs e)
        {

            if (loginstudent(tbemail.Text, tbpass.Text))
            {
                String isiemail = tbemail.Text;
                this.setemail(isiemail);
                MessageBox.Show("Login Success");
                frm3 = new Homepage();
                frm3.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Sorry your Email and Password Not Found");
            }
            conn.Close();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            forgot = new ForgetPassword();
            forgot.Show();
            this.Hide();
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {

        }
    }
}
