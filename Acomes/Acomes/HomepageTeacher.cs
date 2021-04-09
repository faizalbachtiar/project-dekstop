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
    public partial class HomepageTeacher : Form
    {
        MySqlConnection conn = new MySqlConnection();
        public static Loginpage frm1;
        public static ScheduleTeacher sched;
        public static Raport rapor;
        public static AllHomework allhome;
        public static Loginpage login;
        public Loginpage Parent;

        public static Student student;
        public static InputNilai nilai;
        public static setingTeacher seting;
        
        private String NIK;

        public HomepageTeacher(Loginpage parent)
        {
            InitializeComponent();
            frm1 = Parent;

        }

        public HomepageTeacher()
        {
            InitializeComponent();
            panggilnama();
        }

        public HomepageTeacher(string nik)
        {
            InitializeComponent();
            panggilnama();
            this.NIK = nik;
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

        void panggilnama()
        {
            Loginpage frm1 = new Loginpage();
            koneksi();
            String sql = "Select Name,Email,jk,nik from teacher ";
            MySqlCommand cmd = new MySqlCommand(sql, conn);
            MySqlDataReader rdr = cmd.ExecuteReader();
            while (rdr.Read())
            {
                if (frm1.getemail() == rdr.GetString(1))
                {
                    String jk = "";
                    if (rdr.GetString(2) == "Male")
                    {
                        jk = "Mr.";
                    }
                    else if (rdr.GetString(2) == "Female") {
                        jk = "Mrs.";
                    }
                    label2.Text = "Welcome, "+jk+ rdr.GetString(0);
                    NIK = rdr.GetString(3);

                }
            }
            rdr.Close();
            conn.Close();
        }


        private void button1_Click(object sender, EventArgs e)
        {
            login = new Loginpage();
            login.Show();
            this.Hide();
        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {
            student = new Student(NIK);
            student.BackColor = this.BackColor;
            student.Show();
            this.Hide();
        }

        private void pictureBox7_Click(object sender, EventArgs e)
        {
            seting = new setingTeacher(NIK);
            seting.BackColor = this.BackColor;
            seting.Show();
            this.Hide();
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Coming Soon");
            //nilai = new InputNilai(NIK);
            //nilai.BackColor = this.BackColor;
            //nilai.Show();
            //this.Hide();
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            sched = new ScheduleTeacher(NIK);
            sched.BackColor = this.BackColor;
            sched.Show();
            this.Hide();
        }

        private void HomepageTeacher_Load(object sender, EventArgs e)
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
