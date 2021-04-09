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
    public partial class setingTeacher : Form
    {
        MySqlConnection conn = new MySqlConnection();
        public static HomepageTeacher frm2;
        public static Deleteteacher delete;
        public static TeacherEditAcc edit;
        public static themeteacher theme;
        public static textsizeteacher size;
        public static about_us_teacher about;
        public static Loginpage login;

        private String NIK;
        
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
        public setingTeacher(String NIK)
        {
            InitializeComponent();
            this.NIK = NIK;
        }

        public setingTeacher()
        {
            InitializeComponent();
      
        }

        private void button1_Click(object sender, EventArgs e)
        {
            frm2 = new HomepageTeacher();
            frm2.BackColor = this.BackColor;
            frm2.Show();
            this.Hide();
        }

        private void label5_Click(object sender, EventArgs e)
        {
            delete= new Deleteteacher(NIK);
            delete.BackColor = this.BackColor;
            delete.Show();
            this.Hide();
        }

        private void label2_Click(object sender, EventArgs e)
        {
            //edit = new edit_akun();
            //edit.BackColor = this.BackColor;
            //edit.Show();
            //this.Hide();
        }

        private void label3_Click(object sender, EventArgs e)
        {
            theme = new themeteacher(NIK);
            theme.BackColor = this.BackColor;
            theme.Show();
            this.Hide();
        }

        private void label4_Click(object sender, EventArgs e)
        {
            size = new textsizeteacher(NIK);
            size.BackColor = this.BackColor;
            size.Show();
            this.Hide();
        }

        private void label6_Click(object sender, EventArgs e)
        {
            about = new about_us_teacher(NIK);
            about.BackColor = this.BackColor;
            about.Show();
            this.Hide();
        }

        private void Seting_Load(object sender, EventArgs e)
        {

        }

        
        private void label7_Click(object sender, EventArgs e)
        {
            login = new Loginpage();
            login.Show();
            this.Hide();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            edit = new TeacherEditAcc(NIK);
            edit.BackColor = this.BackColor;
            edit.Show();
            this.Hide();
        }

        private void pictureBox10_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox8_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click_1(object sender, EventArgs e)
        {
            edit = new TeacherEditAcc(NIK);
            edit.BackColor = this.BackColor;
            edit.Show();
            this.Hide();
        }

        private void label5_Click_1(object sender, EventArgs e)
        {
            delete = new Deleteteacher(NIK);
            delete.BackColor = this.BackColor;
            delete.Show();
            this.Hide();
        }

        private void label6_Click_1(object sender, EventArgs e)
        {
            about = new about_us_teacher(NIK);
            about.BackColor = this.BackColor;
            about.Show();
            this.Hide();
        }

        private void label3_Click_1(object sender, EventArgs e)
        {
            theme = new themeteacher(NIK);
            theme.BackColor = this.BackColor;
            theme.Show();
            this.Hide();
        }

        private void label4_Click_1(object sender, EventArgs e)
        {
            size = new textsizeteacher(NIK);
            size.BackColor = this.BackColor;
            size.Show();
            this.Hide();
        }

        private void label7_Click_1(object sender, EventArgs e)
        {
            login = new Loginpage();
            login.Show();
            this.Hide();
        }

        private void pictureBox2_Click_2(object sender, EventArgs e)
        {
            frm2 = new HomepageTeacher(NIK);
            frm2.Show();
            this.Hide();

        }

        private void setingTeacher_Load(object sender, EventArgs e)
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
