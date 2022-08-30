using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace WindowsFormGauss
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }




        //高斯编程代码
        void Gauss(int Bdegree,int Bminute,int Bsecond,int Ldegree,int Lminute,int Lsecond,out double xx,out double yy,out int nn)
        {
            double a=0, e2=0, e12=0, l=0, X, m0, m2, m4, m6, m8, a0, a2, a4, a6, a8;
            double d2r = 180 * 3600 / Math.PI;
            double n=0;
            double B, L, W, N, t2, n2,L0;
            nn = 0;
            int d1 = Bdegree;
            int f1 = Bminute;
            double m1 = (double)Bsecond;
            B = (d1 * 3600 + f1 * 60 + m1);
            d1 = Ldegree;
            f1 = Lminute;
            m1 = (double)Lsecond;
            L = (d1 * 3600 + f1 * 60 + m1);
            if (radioButton1.Checked)
            {
                a = 6378245.0;
                e2 = 0.006693421622966;
                e12 = 0.006738525414683;
            }
            else if (radioButton2.Checked)
            {
                a = 6378140.0;
                e2 = 0.006694384999588;
                e12 = 0.006739501819473;
            }
            else if (radioButton3.Checked)
            {
                a = 6378137.0;
                e2 = 0.0066943799013;
                e12 = 0.00673949674227;
            }
            else if (radioButton7.Checked)
            {
                a = 6378137.0;
                e2 = 0.00669438002290;
                e12 = 0.00673949677548;
            }
            if (radioButton4.Checked)
            {
                l = 0;
                nn = (int)((L / 3600) / 6+1);
                //nn = Math.Ceiling(n0);
                L0 = (6 * nn - 3) * 3600;
                l = L - L0;
            }
            else if (radioButton5.Checked)
            {
                l = 0;
                nn = (int)((L / 3600) / 3.0);
                L0 = 3 * nn * 3600;
                l = L - L0;
            }
            else if (radioButton6.Checked)
            {
                l = 0;
                nn = (int)((L / 3600) / 1.5);
                L0 = 1.5 * nn * 3600;
                l = L - L0;
            }
            //计算X；
            m0 = a * (1 - e2);
            m2 = 3 * e2 * m0 / 2;
            m4 = 5 * e2 * m2 / 4;
            m6 = 7 * e2 * m4 / 6;
            m8 = 9 * e2 * m6 / 8;
            a0 = m0 + m2 / 2 + 3 * m4 / 8 + 5 * m6 / 16 + 35 * m8 / 128;
            a2 = m2 / 2 + m4 / 2 + 15 * m6 / 32 + 7 * m8 / 16;
            a4 = m4 / 8 + 3 * m6 / 16 + 7 * m8 / 32;
            a6 = m6 / 32 + m8 / 16;
            a8 = m8 / 128;
            X = a0 * (B / d2r) - a2 * Math.Sin(2 * B / d2r) / 2 + a4 * Math.Sin(4 * B / d2r) / 4 - a6 * Math.Sin(6 * B / d2r) / 6 + a8 * Math.Sin(8 * B / d2r) / 8;

            //计算其他参数
            W = Math.Sqrt(1 - e2 * Math.Sin(B / d2r) * Math.Sin(B / d2r));
            N = a / W;
            t2 = Math.Tan(B / d2r) * Math.Tan(B / d2r);
            n2 = e12 * Math.Cos(B / d2r) * Math.Cos(B / d2r);
            xx = X + N * Math.Sin(B / d2r) * Math.Cos(B / d2r) * l * l / (2 * Math.Pow(d2r, 2)) + N * Math.Sin(B / d2r) * Math.Pow(Math.Cos(B / d2r), 3) * (5 - t2 + 9 * n2 + 4 * n2 * n2) * Math.Pow(l, 4) / (24 * Math.Pow(d2r, 4)) + N * Math.Sin(B / d2r) * Math.Pow(Math.Cos(B / d2r), 5) * (61 - 58 * t2 + t2 * t2) * Math.Pow(l, 6) / (720 * Math.Pow(d2r, 6));
            yy = N * Math.Cos(B / d2r) * l / d2r + N * Math.Pow(Math.Cos(B / d2r), 3) * (1 - t2 + n2) * Math.Pow(l, 3) / (6 * Math.Pow(d2r, 3)) + N * Math.Pow(Math.Cos(B / d2r), 5) * (5 - 18 * t2 + t2 * t2 + 14 * n2 - 58 * n2 * t2) * Math.Pow(l, 5) / (120 * Math.Pow(d2r, 5));
            xx = Math.Round(xx, 4);
            yy = Math.Round(yy, 4);
           // double y1 = 500000 + yy;//转化为通用值
            //textBox3.Text = x.ToString();
            //textBox4.Text = n.ToString() + y1.ToString(); 
        }
        //点击按钮计算
        private void button1_Click(object sender, EventArgs e)
        {
            int Bdegree=int.Parse(textBox1.Text);
            int Bminute=int.Parse(textBox5.Text);
            int Bsecond=int.Parse(textBox6.Text);
            int Ldegree=int.Parse(textBox8.Text);
            int Lminute=int.Parse(textBox7.Text);
            int Lsecond = int.Parse(textBox2.Text);
            double x, y;
            int n;
            Gauss( Bdegree, Bminute,Bsecond, Ldegree, Lminute, Lsecond,out x,out y,out n);
            double y1 = 500000 + y;//转化为通用值
            textBox3.Text = x.ToString();
            textBox4.Text = n.ToString() + y1.ToString();
        }


        private void button2_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.ShowDialog();
            string  path=openFileDialog.FileName;
            StreamReader Reader = new StreamReader(path);
            StreamWriter writer = new StreamWriter(@"E:\Gauss.txt",false);
            string str = Reader.ReadToEnd();
            string[] date = str.Split(' ', '\r');
            for (int i = 0; i <date.Length / 6; i++)
            {
                int Bdegree=int.Parse(date[i*6]);
                int Bminute=int.Parse(date[i*6+1]);
                int Bsecond=int.Parse(date[i*6+2]);
                int Ldegree=int.Parse(date[i*6+3]);
                int Lminute=int.Parse(date[i*6+4]);
                int Lsecond = int.Parse(date[i*6+5]);
                double x, y;
                int n;
                Gauss(Bdegree, Bminute, Bsecond, Ldegree, Lminute, Lsecond, out x, out y, out n);
                writer.WriteLine(x.ToString("G")+' '+y.ToString("G"));
                
            }
            Reader.Close();
            writer.Close();
               
        }

        private void openFileDialog1_FileOk(object sender, CancelEventArgs e)
        {
            ////string writerPath=openFileDialog.
            
        }

        private void button3_Click(object sender, EventArgs e)
        {
            SaveFileDialog save=new SaveFileDialog() ;
            save.ShowDialog();
            
        }
   
    }
  
}
