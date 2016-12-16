using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using OmronFinsTCP.Net;

namespace FinsDebuger
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        EtherNetPLC ENT;
        
        private void Form1_Load(object sender, EventArgs e)
        {
            //byte[] byteTest = new byte[2];
            //short s = -30;
            //byteTest = BitConverter.GetBytes(s);
            //byte[] test = new byte[] { byteTest[1], byteTest[0] };

            //MessageBox.Show(test.ToString());

            //s = BitConverter.ToInt16(byteTest, 0);
            //MessageBox.Show(s.ToString());

            //s = (short)((byteTest[1] << 8) | byteTest[0]);
            //MessageBox.Show(s.ToString());
            //try
            //{
            //    string s = Convert.ToByte((short)-1).ToString();
            //}
            //catch (Exception)
            //{
                
            //    throw;
            //}
        }

        private void btnCon_Click(object sender, EventArgs e)
        {
            string s = btnCon.Text.Trim();
            if (s == "连接")
            {
                string plcip = txtPlcip.Text.Trim();
                string plcport = txtPlcport.Text.Trim();
                ENT = new EtherNetPLC();
                short re = ENT.Link(plcip, short.Parse(plcport),500);
                if (re == 0)
                {
                    btnCon.Text = "断开";
                    txtPCNode.Text = ENT.PCNode.ToString();
                }
                else
                {
                    MessageBox.Show("连接出错！");
                }
            }
            else
            {
                short re = ENT.Close();
                if (re == 0)
                {
                    btnCon.Text = "连接";
                    txtPCNode.Text = "pcNode";
                }
                else
                {
                    MessageBox.Show("断开出错！");
                }
            }
        }

        private void btnRead_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Stopwatch sp = new System.Diagnostics.Stopwatch();
            sp.Start();
            txtValues.Text = "";
            short[] rd;
            string address = txtAddress.Text.Trim();
            string count = txtCount.Text.Trim();
            short re = ENT.ReadWords(PlcMemory.DM, short.Parse(address), short.Parse(count), out rd);
            if (re != 0)
            {
                //写入数据出错
                txtValues.Text = "数据读取出错！";
            }
            else
            {
                for (int i = 0; i < rd.Length; i++)
                {
                    txtValues.Text += rd[i].ToString() + ",";
                }
            }

            //单个读取速度测试
            //txtValues.Text = "";
            //short rd = 0;
            //short address = short.Parse(txtAddress.Text.Trim());
            //short count = short.Parse(txtCount.Text.Trim());
            //for (int i = 0; i < count; i++)
            //{
            //    short add = (short)(address + i);
            //    short re = ENT.ReadWord(EtherNetPLC.PlcMemory.DM_Word, add, out rd);
            //    if (re != 0)
            //    {
            //        //写入数据出错
            //        txtValues.Text = "数据读取出错,已停止！";
            //        break;
            //    }
            //    else
            //    {
            //        txtValues.Text += rd.ToString() + ",";
            //    }
            //    //txtValues.Text += ",数据读取成功！";
            //}
            sp.Stop();
            txtUseTime.Text = sp.Elapsed.TotalMilliseconds.ToString() + "ms";
        }

        private void btnWrite_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Stopwatch sp = new System.Diagnostics.Stopwatch();
            sp.Start();
            string s = txtValuesW.Text.Trim(',');
            string[] ss = s.Split(',');
            short[] wt = new short[ss.Length];
            for (int i = 0; i < ss.Length; i++)
            {
                wt[i] = short.Parse(ss[i]);
            }
            //short[] wt = new short[] { short.Parse(s) };
            string address = txtAddressW.Text.Trim();
            string count = txtCountW.Text.Trim();
            short re = ENT.WriteWords(PlcMemory.DM, short.Parse(address), short.Parse(count), wt);
            sp.Stop();
            txtUseTimeW.Text = sp.Elapsed.TotalMilliseconds.ToString() + "ms";
            if (re != 0)
            {
                //写入数据出错
                txtUseTimeW.Text += ",写入数据出错！";
            }
            else
            {
                txtUseTimeW.Text += ",写入数据成功！";
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Stopwatch sp = new System.Diagnostics.Stopwatch();
            sp.Start();
            string bitAdd = txtBitAdd.Text.Trim();
            short re = ENT.SetBitState(PlcMemory.DM, bitAdd, BitState.ON);
            sp.Stop();
            txtUseTimeB.Text = sp.Elapsed.TotalMilliseconds.ToString() + "ms";
            if (re != 0)
            {
                //写入数据出错
                MessageBox.Show("打开指定位失败！");
            }
            else
            {
                MessageBox.Show("打开指定位成功！");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Stopwatch sp = new System.Diagnostics.Stopwatch();
            sp.Start();
            string bitAdd = txtBitAdd.Text.Trim();
            short re = ENT.SetBitState(PlcMemory.DM, bitAdd, BitState.OFF);
            sp.Stop();
            txtUseTimeB.Text = sp.Elapsed.TotalMilliseconds.ToString() + "ms";
            if (re != 0)
            {
                //写入数据出错
                MessageBox.Show("关闭指定位失败！");
            }
            else
            {
                MessageBox.Show("关闭指定位成功！");
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Stopwatch sp = new System.Diagnostics.Stopwatch();
            sp.Start();
            string bitAdd = txtBitAdd.Text.Trim();
            short bs;
            short re = ENT.GetBitState(PlcMemory.DM, bitAdd, out bs);
            sp.Stop();
            txtUseTimeB.Text = sp.Elapsed.TotalMilliseconds.ToString() + "ms";
            if (re != 0)
            {
                //写入数据出错
                MessageBox.Show("获取指定位状态失败！");
            }
            else
            {
                if (bs == 1)
                    MessageBox.Show("获取指定位状态成功：当前开打（1）！");
                else
                    MessageBox.Show("获取指定位状态成功：当前关闭（0）！");
            }
        }

        private void btnReadF_Click(object sender, EventArgs e)
        {
            txtValueF.Text = "";
            float rd;
            string address = txtAddress.Text.Trim();
            short re = ENT.ReadReal(PlcMemory.DM, short.Parse(address), out rd);
            if (re != 0)
            {
                //写入数据出错
                txtValueF.Text = "数据读取出错！";
            }
            else
            {
                txtValueF.Text = rd.ToString();
            }
        }
    }
}
