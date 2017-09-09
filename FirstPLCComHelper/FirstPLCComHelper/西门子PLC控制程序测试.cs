using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FirstPLCComHelper
{
    public partial class 西门子PLC控制程序测试 : Form
    {
        public 西门子PLC控制程序测试()
        {
            InitializeComponent();
        }

        //private void buttom1_Click(object sender, EventArgs e) { }
        private void button1_Click(object sender, EventArgs e)
        {
            //this.Hide();
            //DataAdd dad = new DataAdd();
            //dad.Show();


            if (textBox1.Text == "")
                MessageBox.Show("请输入信息！");
            else
                listView1.Items.Add(textBox1.Text.Trim());

            textBox1.Text = "";

        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                //for (int i = 0; ;i++ )
                listView1.Items.RemoveAt(listView1.SelectedItems[0].Index);
                listView1.SelectedItems.Clear();  
            }
            catch(Exception a)
            {
                //a.GetBaseException();

                MessageBox.Show("捕获异常："+ a);
            } 
            
        }

        private void button1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((int)e.KeyChar == 13)
            {
                if (textBox1.Text == "")
                    MessageBox.Show("请输入信息！");
                else
                    listView1.Items.Add(textBox1.Text.Trim());
            }
            textBox1.Text = "";
        }


    }
}
