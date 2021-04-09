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
    public partial class ForgetPassword : Form
    {
        public static Loginpage login;
        public ForgetPassword()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Please check your E-mail!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            login = new Loginpage();
            login.Show();
            this.Hide();
        }

        private void ForgetPassword_Load(object sender, EventArgs e)
        {

        }
    }
}
