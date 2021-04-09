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
    public partial class ScheduleTeacher : Form
    {
        MySqlConnection conn = new MySqlConnection();
        public static HomepageTeacher home;
        public static AddSchedule add;

        private String NIK;

        public ScheduleTeacher()
        {
            InitializeComponent();
        }

        public ScheduleTeacher(String NIK)
        {
            InitializeComponent();
            baca();
            this.NIK = NIK;
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

        string getNIK()
        {
            Loginpage frm1 = new Loginpage();
            koneksi();
            String sql = "Select nik from teacher where email = '" + frm1.getemail() + "'";
            MySqlCommand cmd = new MySqlCommand(sql, conn);
            MySqlDataReader rdr = cmd.ExecuteReader();
            String n = "";
            while (rdr.Read())
            {
                n = rdr.GetString(0);
            }
            conn.Close();
            return n;
        }

        public DataTable baca()
        {
            String sql = "SELECT day, time, room, course, teacher FROM schedule WHERE nik = '" + getNIK() + "'";
            DataTable dt = new DataTable();
            try
            {
                koneksi();
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
            home = new HomepageTeacher();
            home.Show();
            home.BackColor = this.BackColor;
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            add = new AddSchedule(NIK);
            add.Show();
            add.BackColor = this.BackColor;
            this.Hide();
        }

        private void ScheduleTeacher_MouseClick(object sender, MouseEventArgs e)
        {

        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
        }

        private void dataGridView1_Click(object sender, EventArgs e)
        {
            
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            EditSchedule edit = new EditSchedule(dataGridView1.SelectedRows[0].Cells[0].Value.ToString(),
                dataGridView1.SelectedRows[0].Cells[1].Value.ToString(),
                dataGridView1.SelectedRows[0].Cells[2].Value.ToString(),
                dataGridView1.SelectedRows[0].Cells[3].Value.ToString(),
                dataGridView1.SelectedRows[0].Cells[4].Value.ToString());
            edit.Show();
            this.Hide();
        }

        private void ScheduleTeacher_Load(object sender, EventArgs e)
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
