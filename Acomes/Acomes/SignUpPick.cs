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
    public partial class SignUpPick : Form
    {
        public static Loginpage login;
        public static TeacherRegist frm2;
        public static StudentRegist frm3;
        public SignUpPick()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            frm2 = new TeacherRegist();
            frm2.Show();
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            frm3 = new StudentRegist();
            frm3.Show();
            this.Hide();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            login = new Loginpage();
            login.Show();
            this.Hide();
        }
    }
}
