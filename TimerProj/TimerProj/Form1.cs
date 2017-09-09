using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TimerProj
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            //string cesuotime=DateTime.Now.DateTime.Now.ToShortTimeString();//得到现在的时间

            timer1.Enabled = false;
            MessageBox.Show("已经工作两小时了，请注意休息。");
            timer1.Enabled = true;
        }
    }
}
