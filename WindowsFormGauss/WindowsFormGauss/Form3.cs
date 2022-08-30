using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace WindowsFormGauss
{
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
        }

        double a, e2, e12, l, m0, m2, m4, m6, m8, a0, a2, a4, a6, a8;
//        double d2r = 180 * 3600 / Math.PI;
        double pi = Math.PI;
  

        private void button1_Click(object sender, EventArgs e)
        {
            double Mf, Nf,Bf,W,tf,nf2,B,L;
            int Bdu,Bfen,Bmiao,Ldu,Lfen,Lmiao;
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
            else if (radioButton4.Checked)
            {
                a = 6378137.0;
                e2 = 0.00669438002290;
                e12 = 0.00673949677548;
            }
            double x=double.Parse (textBox1.Text);
            double y=double.Parse (textBox2.Text);
            int LO=int.Parse (textBox3.Text);
            Bf = sort(a,e2);

            W = Math.Sqrt(1 - e2 * Math.Sin(Bf) * Math.Sin(Bf));
            Nf = a / W;
            Mf = a * (1 - e2) / W;
            tf = Math.Tan(Bf);
            nf2 = e12 * Math.Cos(Bf) * Math.Cos(Bf);


            l = 1 / (Nf * Math.Cos(Bf)) * y - 1 / (6 * Math.Pow(Nf, 3) * Math.Cos(Bf)) * (1 + 2 * tf * tf + nf2) * Math.Pow(y, 3) + 1 / (120 * Math.Pow(Nf, 5) * Math.Cos(Bf)) * (5 + 28 * tf * tf + 24 * Math.Pow(tf, 4) + 6 * nf2 + 8 * nf2 * tf * tf) * Math.Pow(y, 5);
            B = Bf - tf / (2 * Mf * Nf) * y * y + tf / (24 * Mf * Math.Pow(Nf, 3)) * (5 + 3 * tf * tf + nf2 - 9 * nf2 * tf * tf) * Math.Pow(y, 4) - tf / (720 * Mf * Math.Pow(Nf, 5)) * (61 + 90 * tf * tf + 45 * Math.Pow(tf, 4)) * Math.Pow(y, 6);
            L=l+LO*pi/180;

            Ldu=(int)(L/pi*180);
            Lfen=(int)((L/pi*180)*60-Ldu*60);
            Lmiao=(int)(L/pi*180*3600-Ldu*3600-Lfen*60);
            Bdu=(int)(B/pi*180);
            Bfen=(int)((B/pi*180)*60-Bdu*60);
            Bmiao=(int)(B/pi*180*3600-Bdu*3600-Bfen*60);
            textBox4.Text = Bdu.ToString();
            textBox5.Text = Bfen.ToString();
            textBox6.Text = Bmiao.ToString();
            textBox7.Text = Ldu.ToString();
            textBox8.Text = Lfen.ToString();
            textBox9.Text = Lmiao.ToString();

        }

        double sort(double a,double e2)
        {
      
            double B3,B2,B1,F;
          
 //           double m0, m2, m4, m6, m8;
 //           double a0, a2, a4, a6, a8;
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
            double x=double.Parse (textBox1.Text);
            B1 = x / a0;
            do
            {
                F = -a2 * Math .Sin (2 * B1) / 2 + a4 * Math .Sin (4 * B1) / 4 - a6 * Math .Sin (6 * B1) / 6 + a8 * Math .Sin(8 * B1) / 8;
                B2 = (x - F) / a0;
                B3 = B1;
                B1 = B2;
            } while (Math .Abs(B3 - B2) > 10e-10);//利用迭代算法求解底点纬度//
            return B2;
        }


    }
}
