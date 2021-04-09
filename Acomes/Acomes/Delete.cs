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
    public partial class Delete : Form
    {
        MySqlConnection conn = new MySqlConnection();
        public static Loginpage login;
        public static Seting seting;
        private String nis;
        public Delete()
        {
            InitializeComponent();
        }
        public Delete(String nis)
        {
            InitializeComponent();
            this.nis = nis;
        }
        private void pictureBox1_Click(object sender, EventArgs e)
        {
            seting = new Seting();
            seting.BackColor = this.BackColor;
            seting.Show();
            this.Hide();
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

        private Boolean Deletestudent(String Email, String password)
        {
            koneksi();
            if(tbpass.Text == tbpass2.Text)
            {
                    String sql_hapus = "Delete from student where Email='" + Email +"'"+ "AND Password='" + password +"'";
                    MySqlCommand cmd_hapus = new MySqlCommand(sql_hapus, conn);
                    cmd_hapus.ExecuteNonQuery();
                    conn.Close();
                    return true;
             }
            if(tbpass.Text!=tbpass2.Text) {
                MessageBox.Show("Please Input Your Correct Password");
                conn.Close();
                return false;
            }
                    conn.Close();
                    return false;
        }
        
        private void button1_Click(object sender, EventArgs e)
        {
            if (Deletestudent(tbemail.Text, tbpass.Text)==true) {
                MessageBox.Show("Your Account is Deleted");
                login = new Loginpage();
                login.Show();
                this.Hide();
            }
        }

        private void Delete_Load(object sender, EventArgs e)
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
