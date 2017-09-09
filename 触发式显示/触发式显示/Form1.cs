using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace 触发式显示
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void textBox1_KeyDown(object sender, KeyPressEventArgs e)
        {
            //textBox1.Text = "";
          if((int)e.KeyChar == 13)
          {
              //label1.ForeColor = new ForeColor();
              label2.ForeColor = Color.Red;
              MessageBox.Show("helloworld");
          }
          if ((int)e.KeyChar == 0) 
          {
              label1.ForeColor = Color.Green;
          }
         
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button2_Click(object sender, EventArgs e) 
        {
            MessageBox.Show(textBox1.Text);
        }

        private void button2_MouseDown(object sender, MouseEventArgs e)
        {
            label3.ForeColor = Color.Red;
        }
        private void button2_MouseUp(object sender, MouseEventArgs e)
        {
            label3.ForeColor = Color.Black;
        }

        private void button3_KeyDown(object sender, KeyEventArgs e)
        {

        }

        private void textBox2_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyValue == '1')
            label4.ForeColor = Color.Red;
        }

        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if(e.KeyChar ==13)
            label4.ForeColor = Color.Yellow;
        }
       
   
    




    }
}
