using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Gmy
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            UidTb.Text = "";
            passTb.Text = "";

        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (UidTb.Text=="" || passTb.Text=="")
            {
                MessageBox.Show("Missing Information");
            }
            else if (UidTb.Text=="Admin" && passTb.Text=="Admin")
            {
                MainForm mainform = new MainForm();
                mainform.Show();
                this.Hide();

            }
            else
            {
                MessageBox.Show("Wrong Id or Password");
            }
        }
    }
}
