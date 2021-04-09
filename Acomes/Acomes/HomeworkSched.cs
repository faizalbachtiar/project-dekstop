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
    public partial class HomeworkSched : Form
    {
        MySqlConnection conn = new MySqlConnection();
        public static Schedule sched;
        public static AddHomework add;
        public static UpdateHomework update;
        private string nis;

        public HomeworkSched()
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
            add = new AddHomework();
            add.Show();
            add.BackColor = this.BackColor;
            this.Hide();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            sched = new Schedule(nis);
            sched.Show();
            sched.BackColor = this.BackColor;
            this.Hide();
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            update = new UpdateHomework();
            update.Show();
            this.Hide();
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void HomeworkSched_Load(object sender, EventArgs e)
        {
            koneksi();
            String sql = "Select Theme from student";
            MySqlCommand cmd = new MySqlCommand(sql, conn);
            MySqlDataReader rdr = cmd.ExecuteReader();
            while (rdr.Read())
            {
                if (rdr.GetInt16(0) == 1)
                {
                    BackColor = Color.FromArgb(66, 128, 148);
                }
                else if (rdr.GetInt16(0) == 2)
                {
                    BackColor = Color.FromArgb(249, 157, 42);
                }
                else if (rdr.GetInt16(0) == 3)
                {
                    BackColor = Color.FromArgb(224, 43, 48);
                }
                else if (rdr.GetInt16(0) == 4)
                {
                    BackColor = Color.FromArgb(95, 189, 102);
                }
                else if (rdr.GetInt16(0) == 5)
                {
                    BackColor = Color.FromArgb(0, 192, 192);
                }
            }
        }
    }
}
