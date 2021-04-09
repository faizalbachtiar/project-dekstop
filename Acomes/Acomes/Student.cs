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
    public partial class Student : Form
    {
        MySqlConnection conn = new MySqlConnection();
        public static HomepageTeacher home;
        public static ViewStudent view;
        private string NIK;
        public Student()
        {
            InitializeComponent();
        }
        public Student(String NIK)
        {
            InitializeComponent();
            this.NIK = NIK;
            baca();
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

        public DataTable baca()
        {
            Loginpage frm1 = new Loginpage();
            koneksi();
            String s = "SELECT username FROM teacher WHERE email = '" + frm1.getemail() + "'";
            MySqlCommand c = new MySqlCommand(s, conn);
            Object result = c.ExecuteScalar();
            String username = (String)result;

            String sql = "SELECT name, nis FROM student WHERE username = '" + username + "'";

            DataColumn column = new DataColumn();
            column.ColumnName = "no.";
            column.DataType = System.Type.GetType("System.Int32");
            column.AutoIncrement = true;
            column.AutoIncrementSeed = 1;
            column.AutoIncrementStep = 1;
            DataTable dt = new DataTable();
            try
            {
                dt.Columns.Add(column);
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                MySqlDataAdapter data = new MySqlDataAdapter(cmd);
                cmd.ExecuteNonQuery();
                data.Fill(dt);
                dataGridView1.DataSource = dt;
                dataGridView1.Columns[0].Width = 30;
                dataGridView1.Columns[1].Width = 240;
                dataGridView1.Columns[2].Width = 230;
                dataGridView1.BackgroundColor = Color.White;
            }
            catch (Exception ali)
            {
                MessageBox.Show(ali.Message);
            }
            conn.Close();
            return (dt);
        }

        private void Student_Load(object sender, EventArgs e)
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
