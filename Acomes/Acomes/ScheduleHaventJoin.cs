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
    public partial class ScheduleHaventJoin : Form
    {
        MySqlConnection conn = new MySqlConnection();
        private static Schedule sched;
        private String nis;

        public ScheduleHaventJoin(String nis)
        {
            InitializeComponent();
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

        private void ScheduleHaventJoin_Load(object sender, EventArgs e)
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

        private void button1_Click(object sender, EventArgs e)
        {
            koneksi();

            String sq = "SELECT username FROM teacher";
            MySqlCommand cm = new MySqlCommand(sq, conn);
            Object result = cm.ExecuteScalar();
            String username = (String)result;

            if (username == textBox1.Text)
            {
                String s = "UPDATE student SET Username = '" + textBox1.Text + "' WHERE NIS = '" + nis + "'";
                MySqlCommand c = new MySqlCommand(s, conn);
                c.ExecuteNonQuery();
                sched = new Schedule(nis);
                sched.Show();
                sched.BackColor = this.BackColor;
                this.Hide();
            }
            else
            {
                MessageBox.Show("Username is invalid", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            conn.Close();
        }
    }
}
