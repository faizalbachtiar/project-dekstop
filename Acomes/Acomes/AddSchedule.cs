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
    public partial class AddSchedule : Form
    {
        static String hour;
        static String minute;
        MySqlConnection conn = new MySqlConnection();
        public static ScheduleTeacher sched;

        private String NIP;
        public AddSchedule()
        {
            InitializeComponent();
        }

        public AddSchedule(String NIP)
        {
            InitializeComponent();
            this.NIP = NIP;
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

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            sched = new ScheduleTeacher(NIP);
            sched.Show();
            sched.BackColor = this.BackColor;
            this.Hide();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            koneksi();
            String s = "INSERT INTO course (Course_Name) values ('" + textBox1.Text + "')";
            MySqlCommand c = new MySqlCommand(s, conn);
            c.ExecuteNonQuery();

            String sq = "SELECT max(ID_Course) FROM course";
            MySqlCommand cm = new MySqlCommand(sq, conn);
            Object result = cm.ExecuteScalar();
            int id = (int)result;

            String sql = "INSERT INTO schedule (Day, Time, Room, Course, Teacher, NIK, ID_Course) values ('" + textBox2.Text + "','" + hour + ":" + minute + "','" + textBox7.Text + "','" + textBox1.Text + "','" + textBox4.Text + "','" + NIP + "'," + id + ")";
            MySqlCommand cmd = new MySqlCommand(sql, conn);
            cmd.ExecuteNonQuery();
            conn.Close();
            sched = new ScheduleTeacher(NIP);
            sched.Show();
            sched.BackColor = this.BackColor;
            this.Hide();
        }

        private void button11_Click(object sender, EventArgs e)
        {
            if(button11.Enabled == true)
            {
                update_boxes(1);
            }
            else
            {
                button11.Enabled = false;
            }
        }

        private void button12_Click(object sender, EventArgs e)
        {
            if (button12.Enabled == true)
            {
                update_boxes(2);
            }
            else
            {
                button12.Enabled = false;
            }
        }

        private void button13_Click(object sender, EventArgs e)
        {
            if (button13.Enabled == true)
            {
                update_boxes(3);
            }
            else
            {
                button13.Enabled = false;
            }

        }

        private void button14_Click(object sender, EventArgs e)
        {
            if (button14.Enabled == true)
            {
                update_boxes(4);
            }
            else
            {
                button14.Enabled = false;
            }
        }

        private void button15_Click(object sender, EventArgs e)
        {
            if (button15.Enabled == true)
            {
                update_boxes(5);
            }
            else
            {
                button15.Enabled = false;
            }
        }

        private void button16_Click(object sender, EventArgs e)
        {
            if (button16.Enabled == true)
            {
                update_boxes(6);
            }
            else
            {
                button16.Enabled = false;
            }
        }

        private void button17_Click(object sender, EventArgs e)
        {
            if (button17.Enabled == true)
            {
                update_boxes(7);
            }
            else
            {
                button17.Enabled = false;
            }
        }

        private void button18_Click(object sender, EventArgs e)
        {
            if (button18.Enabled == true)
            {
                update_boxes(8);
            }
            else
            {
                button18.Enabled = false;
            }
        }

        private void button19_Click(object sender, EventArgs e)
        {
            if (button19.Enabled == true)
            {
                update_boxes(9);
            }
            else
            {
                button19.Enabled = false;
            }
        }

        private void button20_Click(object sender, EventArgs e)
        {
            if (button20.Enabled == true)
            {
                update_boxes(10);
            }
            else
            {
                button20.Enabled = false;
            }
        }
        private void button4_Click(object sender, EventArgs e)
        {
            if (button4.Enabled == true)
            {
                update_minute(1);
            }
            else
            {
                button4.Enabled = false;
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (button3.Enabled == true)
            {
                update_minute(2);
            }
            else
            {
                button3.Enabled = false;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (button2.Enabled == true)
            {
                update_minute(3);
            }
            else
            {
                button2.Enabled = false;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (button1.Enabled == true)
            {
                update_minute(4);
            }
            else
            {
                button1.Enabled = false;
            }
        }

        private void button11_EnabledChanged(object sender, EventArgs e)
        {

        }

        void update_minute(int a)
        {
            if (a == 1)
            {
                button4.Enabled = false;
                button4.BackColor = Color.LightGray;
                minute = "00";
            }
            else
            {
                button4.Enabled = true;
                button4.BackColor = Color.Salmon;
            }

            if (a == 2)
            {
                button3.Enabled = false;
                button3.BackColor = Color.LightGray;
                minute = "15";
            }
            else
            {
                button3.Enabled = true;
                button3.BackColor = Color.Salmon;
            }
            if (a == 3)
            {
                button2.Enabled = false;
                button2.BackColor = Color.LightGray;
                minute = "30";
            }
            else
            {
                button2.Enabled = true;
                button2.BackColor = Color.Salmon;
            }
            if (a == 4)
            {
                button1.Enabled = false;
                button1.BackColor = Color.LightGray;
                minute = "45";
            }
            else
            {
                button1.Enabled = true;
                button1.BackColor = Color.Salmon;
            }
        }

            void update_boxes(int a)
        {
            if (a == 1)
            {
                button11.Enabled = false;
                button11.BackColor = Color.LightGray;
                hour = "07";
            }
            else
            {
                button11.Enabled = true;
                button11.BackColor = Color.Salmon;
            }

            if (a == 2)
            {
                button12.Enabled = false;
                button12.BackColor = Color.LightGray;
                hour = "08";
            }
            else
            {
                button12.Enabled = true;
                button12.BackColor = Color.Salmon;
            }
            if (a == 3)
            {
                button13.Enabled = false;
                button13.BackColor = Color.LightGray;
                hour = "09";
            }
            else
            {
                button13.Enabled = true;
                button13.BackColor = Color.Salmon;
            }
            if (a == 4)
            {
                button14.Enabled = false;
                button14.BackColor = Color.LightGray;
                hour = "10";
            }
            else
            {
                button14.Enabled = true;
                button14.BackColor = Color.Salmon;
            }
            if (a == 5)
            {
                button15.Enabled = false;
                button15.BackColor = Color.LightGray;
                hour = "11";
            }
            else
            {
                button15.Enabled = true;
                button15.BackColor = Color.Salmon;
            }
            if (a == 6)
            {
                button16.Enabled = false;
                button16.BackColor = Color.LightGray;
                hour = "12";
            }
            else
            {
                button16.Enabled = true;
                button16.BackColor = Color.Salmon;
            }
            if (a == 7)
            {
                button17.Enabled = false;
                button17.BackColor = Color.LightGray;
                hour = "13";
            }
            else
            {
                button17.Enabled = true;
                button17.BackColor = Color.Salmon;
            }
            if (a == 8)
            {
                button18.Enabled = false;
                button18.BackColor = Color.LightGray;
                hour = "14";
            }
            else
            {
                button18.Enabled = true;
                button18.BackColor = Color.Salmon;
            }
            if (a == 9)
            {
                button19.Enabled = false;
                button19.BackColor = Color.LightGray;
                hour = "15";
            }
            else
            {
                button19.Enabled = true;
                button19.BackColor = Color.Salmon;
            }
            if (a == 10)
            {
                button20.Enabled = false;
                button20.BackColor = Color.LightGray;
                hour = "16";
            }
            else
            {
                button20.Enabled = true;
                button20.BackColor = Color.Salmon;
            }
        }

        private void AddSchedule_Load(object sender, EventArgs e)
        {
            koneksi();
            String sql = "Select NIK, Theme from teacher";
            MySqlCommand cmd = new MySqlCommand(sql, conn);
            MySqlDataReader rdr = cmd.ExecuteReader();
            while (rdr.Read())
            {
                if (NIP == rdr.GetString(0))
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
            flowLayoutPanel1.BackColor = this.BackColor;
            flowLayoutPanel2.BackColor = this.BackColor;
            conn.Close();
        }
    }
}
