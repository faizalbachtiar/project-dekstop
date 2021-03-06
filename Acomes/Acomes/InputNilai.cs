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
    public partial class InputNilai : Form
    {
        MySqlConnection conn = new MySqlConnection();
        public static HomepageTeacher home;
        public static InputPerStudent inpt;
        private string NIK;
        public InputNilai()
        {
            InitializeComponent();
        }
        public InputNilai(String NIK)
        {
            InitializeComponent();
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

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            home = new HomepageTeacher();
            home.Show();
            home.BackColor = this.BackColor;
            this.Hide();
        }

        private void label2_Click(object sender, EventArgs e)
        {
            inpt = new InputPerStudent(NIK);
            inpt.Show();
            this.Hide();
        }

        private void InputNilai_Load(object sender, EventArgs e)
        {
            flowLayoutPanel2.BackColor = this.BackColor;
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
