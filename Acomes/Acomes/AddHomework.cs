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
    public partial class AddHomework : Form
    {
        MySqlConnection conn = new MySqlConnection();
        public static HomeworkSched homeworkSched;
        public AddHomework()
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

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            homeworkSched = new HomeworkSched();
            homeworkSched.Show();
            homeworkSched.BackColor = this.BackColor;
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            homeworkSched = new HomeworkSched();
            homeworkSched.Show();
            homeworkSched.BackColor = this.BackColor;
            this.Hide();
        }

        private void AddHomework_Load(object sender, EventArgs e)
        {
            koneksi();
            String sql = "Select Theme from student";
            MySqlCommand cmd = new MySqlCommand(sql, conn);
            MySqlDataReader rdr = cmd.ExecuteReader();
            while (rdr.Read())
            {
                if (rdr.GetInt16(0) == 1)
                {
                    BackColor = Color.FromArgb(238, 142, 160);
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
            conn.Close();
        }
    }
}
