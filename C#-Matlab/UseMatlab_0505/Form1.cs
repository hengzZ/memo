using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
// matlab support
using demo;
using MathWorks.MATLAB.NET.Arrays;
using MathWorks.MATLAB.NET.Utility;

namespace UseMatlab_0505
{
    public partial class Form1 : Form
    {
        private AccessExcel m_accessexcel;
        private string m_file_name;

        public Form1()
        {
            InitializeComponent();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            textBox2.Clear();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.ShowDialog();
            m_file_name = ofd.FileName;
            textBox1.Text = m_file_name;
            Application.DoEvents();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            m_accessexcel = AccessExcel.GetInstance();
            string retstr = m_accessexcel.OpenExcelFile(m_file_name);
            if (!string.IsNullOrEmpty(retstr)) {
                MessageBox.Show("Excel 打开失败");
            }
            //m_accessexcel.SetExcelVisible();
            string excel_data = "hello";
            //retstr = m_accessexcel.WriteData(3,2,excel_data);
            //if (!string.IsNullOrEmpty(retstr)) {
            //    MessageBox.Show("Excel 写入出错");
            //}
            retstr = m_accessexcel.ReadData(1,1,out excel_data);
            if (!string.IsNullOrEmpty(retstr)) {
                MessageBox.Show("Excel 读取出错");
            }
            textBox2.Text = excel_data.ToString();
            m_accessexcel.CloseExcelFile();
            Application.DoEvents();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            try {
                // 方式1: 创建一个C#画板
                PlayForm playform = new PlayForm();
                playform.Text = "Demo";
                playform.Show();
                // draw image
                Application.DoEvents();

                // 方式2: Call Matlab
                // create an operation object 
                Demo m_demo = new Demo();
                m_demo.demo();
                Application.DoEvents();
            }catch(System.Exception ex){
                MessageBox.Show("运行错误：\n"+ex.ToString());
            }
        }
    }
}
