using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace 弹压式开关
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            //System.Drawing.Drawing2D.GraphicsPath path1 = new System.Drawing.Drawing2D.GraphicsPath();
            //path1.AddEllipse(this.button1.ClientRectangle);
            //this.button1.Region = new Region(path1);
        }
            private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
           {
            textBox2.Text = "";
            if((int)e.KeyChar == '2')
                label2.ForeColor = Color.Green;
            if((int)e.KeyChar == '1')
                label2.ForeColor = Color.Red;
            if (e.KeyChar==48)
                label2.ForeColor = Color.Yellow;
            }

            

            private void textBox2_KeyDown(object sender, KeyEventArgs e)
            {
                if (e.KeyValue == 13)
                {
                    label2.ForeColor = Color.Red;
                }
            }
     


    }
}
