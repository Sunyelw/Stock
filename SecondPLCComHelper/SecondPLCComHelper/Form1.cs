using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using PLCComHelperProj;
using System.Net;
using System.IO;

namespace SecondPLCComhelper
{
    public partial class Form1 : Form
    {
        private ClientComHelper mPLCComHelper = new ClientComHelper();

        public Form1()
        {
            InitializeComponent();

            mPLCComHelper.TagConfigFile = Path.Combine(Application.StartupPath, "syscfg.xml");//设置配置文件
            mPLCComHelper.Init();//初始化，返回是否成功。


            //下面读取配置文件中的设备信息,并写入listViewNF1(表格)中,显示出来.

            Device s7 = mPLCComHelper.GetDevice();//获取设备信息,一个设备即一个PLC

            int count = 0;//节点个数

            foreach (KeyValuePair<string, TagGroup> ch in s7.TagGroups)
            {

                TagGroup c = ch.Value;


                foreach (KeyValuePair<string, Tag> tag in c.Tags)
                {
                    Tag ta = tag.Value;

                    string name = string.Format("{0}.{1}", c.Name, ta.Name);

                    ListViewItem item = new ListViewItem(name);


                    item.SubItems.Add(ta.Desc);

                    item.SubItems.Add(ta.DataType);

                    item.SubItems.Add(ta.GetAddressName());

                    item.SubItems.Add("");

                    listViewNF1.Items.Add(item);

                    count++;
                }

            }
            toolStripStatusLabel2.Text = count.ToString() + "个";
        }

        //private void listViewNF1_SelectedIndexChanged(object sender, EventArgs e)
        //{

        //}
       
        //连接 按钮
        private void button1_Click(object sender, EventArgs e)
        {
            mPLCComHelper.IP = txtIP.Text;
            bool res = mPLCComHelper.Start();

            if (!res)
            {
                MessageBox.Show("连接失败!");
            }
            else
            {
                button1.Enabled = false;
                button2.Enabled = true;
                timer1.Start();
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {

            timer1.Stop();

            mPLCComHelper.Stop();

            button1.Enabled = true;

            button2.Enabled = false;
        }


        //设置计时器,循环测试连接情况,显示在lable4(XXX).
        private void timer1_Tick(object sender, EventArgs e)
        {

            // 0：未连接，1：TCP连接成功，2：PLC握手成功，3：读取过程中
            switch (mPLCComHelper.CommStatus)
            {
                case 0:
                    label4.Text = "未连接";
                    break;

                case 1:
                    label4.Text = "正在进行TCP连接";
                    break;

                case 2:
                    label4.Text = "TCP连接成功";
                    break;

                case 3:
                    label4.Text = "PLC握手成功";
                    break;

                case 4:
                    label4.Text = "正常采集过程中...";
                    break;
                case 5:
                    label4.Text = "PLC握手错误";
                    break;

                case 6:
                    label4.Text = "通讯错误";
                    break;

                default:
                    break;
            }

            Device s7 = mPLCComHelper.GetDevice();

            foreach (KeyValuePair<string, TagGroup> ch in s7.TagGroups)
            {

                TagGroup c = ch.Value;
                foreach (KeyValuePair<string, Tag> tag in c.Tags)
                {

                    Tag ta = tag.Value;
                    string name = string.Format("{0}.{1}", c.Name, ta.Name);
                    ListViewItem item = listViewNF1.FindItemWithText(name);
                    switch (ta.CheckDataType())
                    {
                        case e_PLC_DATA_TYPE.TYPE_INT:

                            item.SubItems[4].Text = Convert.ToInt32(mPLCComHelper.GetValue(name)).ToString();

                            break;
                        case e_PLC_DATA_TYPE.TYPE_BYTE:

                            item.SubItems[4].Text = Convert.ToInt32(mPLCComHelper.GetValue(name)).ToString();

                            break;

                        case e_PLC_DATA_TYPE.TYPE_FLOAT:

                            item.SubItems[4].Text = mPLCComHelper.GetValue(name).ToString();

                            break;

                        case e_PLC_DATA_TYPE.TYPE_SHORT:

                            item.SubItems[4].Text = Convert.ToInt32(mPLCComHelper.GetValue(name)).ToString();

                            break;

                        case e_PLC_DATA_TYPE.TYPE_BOOL:

                            item.SubItems[4].Text = Convert.ToInt32(mPLCComHelper.GetValue(name)).ToString();

                            break;

                        default:
                            break;
                    }
                }

            }

        }
        

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            mPLCComHelper.Stop();
        }

        private void 修改数据ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string name = listViewNF1.SelectedItems[0].SubItems[0].Text;

            DataAdd frm = new DataAdd();

            frm.DataValue = Convert.ToDouble(listViewNF1.SelectedItems[0].SubItems[4].Text);

            if (frm.ShowDialog() == DialogResult.OK)
            {
                mPLCComHelper.WriteData(name, frm.DataValue);
            }
        }

        private void contextMenuStrip_Opening(object sender, CancelEventArgs e)
        {
            if (listViewNF1.SelectedItems.Count == 0)
            {
                e.Cancel = true;
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            button2.Enabled = false;
        }

        private void txtIP_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtIP_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((int)e.KeyChar == 13)
            { 
              
            }
        }
        

    }
}