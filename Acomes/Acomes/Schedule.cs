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
    public partial class Schedule : Form
    {
        MySqlConnection conn = new MySqlConnection();
        public static Homepage home;
        public static HomeworkSched homework;
        private String nis;

        public Schedule(String nis)
        {
            InitializeComponent();
            baca();
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
        
        private void Schedule_Load(object sender, EventArgs e)
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

        public DataTable baca()
        {
            Loginpage frm1 = new Loginpage();
            koneksi();
            String s = "SELECT username FROM student WHERE email = '" + frm1.getemail() + "'";
            MySqlCommand c = new MySqlCommand(s, conn);
            Object result = c.ExecuteScalar();
            String username = (String)result;

            String sq = "SELECT nik FROM teacher WHERE username = '" + username + "'";
            MySqlCommand cm = new MySqlCommand(sq, conn);
            Object r = cm.ExecuteScalar();
            String nik = (String)r;

            String sql = "SELECT day, time, room, course, teacher FROM schedule WHERE nik = '" + nik + "'";
            DataTable dt = new DataTable();
            try
            {
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                MySqlDataAdapter data = new MySqlDataAdapter(cmd);
                cmd.ExecuteNonQuery();
                data.Fill(dt);
                dataGridView1.DataSource = dt;
                dataGridView1.Columns[0].Width = 60;
                dataGridView1.Columns[1].Width = 50;
                dataGridView1.Columns[2].Width = 60;
                dataGridView1.Columns[3].Width = 267;
                dataGridView1.Columns[4].Width = 100;
                dataGridView1.BackgroundColor = Color.White;
            }
            catch (Exception ali)
            {
                MessageBox.Show(ali.Message);
            }
            conn.Close();
            return (dt);
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            home = new Homepage();
            home.Show();
            home.BackColor = this.BackColor;
            this.Hide();
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            homework = new HomeworkSched();
            homework.Show();
            homework.BackColor = this.BackColor;
            this.Hide();
        }
    }
}
