using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Acomes
{
    public partial class Homepage : Form
    {
        MySqlConnection conn = new MySqlConnection();
        public static Loginpage frm1;
        public static ScheduleHaventJoin baru;
        public static Schedule sched;
        public static Seting frmseting;
        public static Raport rapor;
        public static AllHomework allhome;
        public static Loginpage login;
        public Loginpage Parent;

        private string nis;

        public Homepage(Loginpage parent)
        {
            InitializeComponent();
            frm1 = Parent;
        }
        public Homepage()
        {
            InitializeComponent();
            panggilnama();
        }
        public Homepage(string nis)
        {
            InitializeComponent();
            panggilnama();
            this.nis = nis;
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
            String sql = "Select Name,Email,NIS from student ";
            //where Email='"+frm1.getemail()+"'"
            MySqlCommand cmd = new MySqlCommand(sql, conn);
            MySqlDataReader rdr = cmd.ExecuteReader();
            while (rdr.Read()) {
                if (frm1.getemail()==rdr.GetString(1))
                {
                    labeluser.Text = "Welcome, "+rdr.GetString(0);
                    this.nis = rdr.GetString(2);
                }
            }
                conn.Close();
        }
        private void pictureBox4_Click(object sender, EventArgs e)
        {
            koneksi();
            String sql = "SELECT username FROM student WHERE NIS = '" + nis + "'";
            MySqlCommand cmd = new MySqlCommand(sql, conn);
            Object result = cmd.ExecuteScalar();
            String username = (String)result;
            
            if (username == "")
            {
                baru = new ScheduleHaventJoin(nis);
                baru.Show();
                baru.BackColor = this.BackColor;
                this.Hide();
            }
            else {
            sched = new Schedule(nis);
            sched.Show();
            sched.BackColor = this.BackColor;
            this.Hide();
            }
            conn.Close();
        }

        private void pictureBox7_Click(object sender, EventArgs e)
        {
            frmseting = new Seting(nis);
            frmseting.BackColor = this.BackColor;
            frmseting.Show();
            this.Hide();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            login = new Loginpage();
            login.Show();
            this.Hide();
        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Coming Soon");
            //rapor = new Raport(nis);
            //rapor.Show();
            //rapor.BackColor = this.BackColor;
            //this.Hide();
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Coming Soon");
            //allhome = new AllHomework();
            //allhome.Show();
            //allhome.BackColor = this.BackColor;
            //this.Hide();
        }

        private void Homepage_Load(object sender, EventArgs e)
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
