using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Gmy
{
    public partial class Payment : Form
    {
        public Payment()
        {
            InitializeComponent();
        }

        private void label4_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-U3VPJFA;Initial Catalog=GymDb;Integrated Security=True");
        private void FillName()
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("select MName from  MemberTbl",con);
            SqlDataReader rdr;
            rdr = cmd.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Columns.Add("MName", typeof(string));
            dt.Load(rdr);
            NameCb.ValueMember = "MName";
            NameCb.DataSource = dt;


            con.Close();
        }
        private void fillterByName()
        {
            con.Open();

            string query = "select * from PaymentTbl where PMember='"+SearchName.Text+"'";
            SqlDataAdapter sda = new SqlDataAdapter(query, con);
            SqlCommandBuilder builder = new SqlCommandBuilder();
            var ds = new DataSet();
            sda.Fill(ds);
            PaymentDGV.DataSource = ds.Tables[0];


            con.Close();
        }
        private void populate()
        {
            con.Open();
            string query = "select * from PaymentTbl";
            SqlDataAdapter sda = new SqlDataAdapter(query, con);
            SqlCommandBuilder builder = new SqlCommandBuilder();
            var ds = new DataSet();
            sda.Fill(ds);
            PaymentDGV.DataSource = ds.Tables[0];


            con.Close();
        }
        private void button3_Click(object sender, EventArgs e)
        {
            //NameCb.Text = "";
            AmountTb.Text = "";

        }

        private void button4_Click(object sender, EventArgs e)
        {
            MainForm mainForm = new MainForm();
            mainForm.Show();
            this.Hide();

        }

        private void Payment_Load(object sender, EventArgs e)
        {
            FillName();
            populate();


        }
      
        private void button1_Click(object sender, EventArgs e)
        {
            if(NameCb.Text== "" || AmountTb.Text=="")
            {
                MessageBox.Show("Missing Information");

            }
            else
            {
                string payperiode = Periode.Value.Month.ToString() + Periode.Value.Year.ToString();
                con.Open();
                SqlDataAdapter sda = new SqlDataAdapter("select count(*) from PaymentTbl where PMember='" + NameCb.SelectedValue.ToString() + "'and PMonth='" +payperiode+ "'", con);
                DataTable dt = new DataTable();
                sda.Fill(dt);
                if (dt.Rows[0][0].ToString()=="1")
                {
                    MessageBox.Show("Already Paid For This Month");

                }
                else
                {
                    string query = "insert into PaymentTbl values ('" + payperiode + "','" + NameCb.SelectedValue.ToString() + "'," + AmountTb.Text + ")";
                    SqlCommand cmd = new SqlCommand(query,con);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Amount Paid Successfully");


                }

                con.Close();
                populate();


            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            fillterByName();
            SearchName.Text = "";
        }

        private void button5_Click(object sender, EventArgs e)
        {
            populate();
        }

        
    }
}
