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

namespace WindowsFormsTestApplication1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        
        

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            dateTimePicker1.CustomFormat = "yyyy_MM_dd";
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            dateTimePicker1.Text = null;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            dateTimePicker1.Format = DateTimePickerFormat.Custom;
            dateTimePicker1.CustomFormat = " ";

            string sqlConn = "Data Source=.;database=YS_A;User Id=sa;Password=123";
            string sqlConn1 = "datasource=sunyelwcomputer;database=stock;intia"
            SqlConnection conn = new SqlConnection(sqlConn);
            string sql = "select * from 合同";

            SqlCommand cmd = new SqlCommand(sql,conn);
            conn.Open();
            label2.Text = Convert.ToString(cmd.ExecuteScalar());
            conn.Close();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
    }
}
