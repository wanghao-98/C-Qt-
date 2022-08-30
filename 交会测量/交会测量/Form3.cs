using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace 交会测量
{
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //输入数据
            double XA, YA, XB, YB, XC, YC;
            int du1, fen1, miao1, du2, fen2, miao2, du3, fen3, miao3;
            XA = double.Parse(txt_XA.Text);
            YA = double.Parse(txt_YA.Text);
            XB = double.Parse(txt_XB.Text);
            YB = double.Parse(txt_YB.Text);
            XC = double.Parse(txt_XC.Text);
            YC = double.Parse(txt_YC.Text);
            du1 = int.Parse(txt_du1.Text);
            fen1 = int.Parse(txt_fen1.Text);
            miao1 = int.Parse(txt_miao1.Text);
            du2 = int.Parse(txt_du2.Text);
            fen2 = int.Parse(txt_fen2.Text);
            miao2 = int.Parse(txt_miao2.Text);
            du3 = int.Parse(txt_du3.Text);
            fen3 = int.Parse(txt_fen3.Text);
            miao3 = int.Parse(txt_miao3.Text);

            //角度转弧度
            double Alphard = DegreeToRad(du1,fen1,miao1);
            double Beta = DegreeToRad(du2, fen2, miao2);
            double Gamma = DegreeToRad(du3, fen3, miao3);


            double CotA = ((XB - XA) * (XC - XA) + (YB - YA) * (YC - YA)) / ((XB - XA) * (YC - YA) - (YB - YA) * (XC - XA));
            double CotB = ((XC - XB) * (XA - XB) + (YC - YB) * (YA - YB)) / ((XC - XB) * (YA - YB) - (YC - YB) * (XA - XB));
            double CotC = ((XA - XC) * (XB - XC) + (YA - YC) * (YB - YC)) / ((XA - XC) * (YB - YC) - (YA - YC) * (XB - XC));

            double PA = 1 / (CotA - 1 / Math.Tan(Alphard));
            double PB = 1 / (CotB - 1 / Math.Tan(Beta));
            double PC = 1 / (CotC - 1 / Math.Tan(Gamma));

            double XP = (PA * XA + PB * XB + PC * XC) / (PA + PB + PC);
            double YP = (PA * YA + PB * YB + PC * YC) / (PA + PB + PC);

            txt_XP.Text = XP.ToString();
            txt_YP.Text = YP.ToString();


        }

        //角度转弧度函数
        public double DegreeToRad(int Degree, int Point, int Second)
        {
            int D = Degree;
            int P = Point;
            int S = Second;
            double Rad = (Degree * 3600 + Point * 60 + Second) / (3600 * 180.0) * Math.PI;
            return Rad;
        }




    }
}
