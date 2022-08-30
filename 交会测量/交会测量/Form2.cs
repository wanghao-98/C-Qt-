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
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //读入数据
            double XA, YA, XB, YB, XP, YP, Agree1, Agree2;
            int du1, fen1, miao1, du2, fen2, miao2;
            XA = double.Parse(txt_XA.Text);
            YA = double.Parse(txt_YA.Text);
            XB = double.Parse(txt_XB.Text);
            YB = double.Parse(txt_YB.Text);
            //XP = double.Parse(txt_XP.Text);
            //YP = double.Parse(txt_YP.Text);
            du1 = int.Parse(txt_1du.Text);
            fen1 = int.Parse(txt_1fen.Text);
            miao1 = int.Parse(txt_1miao.Text);
            du2 = int.Parse(txt_2du.Text);
            fen2 = int.Parse(txt_2fen.Text);
            miao2 = int.Parse(txt_2miao.Text);

            //角度转弧度
            Agree1 = DegreeToRad(du1,fen1,miao1);
            Agree2 = DegreeToRad(du2,fen2,miao2);
            //计算AB,BA方位角
          //  double Alphard_AB = Alphard(XA,YA,XB,YB);
          //  double Alphard_BA=Alphard(XB,YB,XA,YA);
            //AB距离
           // double Delta_XAB=XB - XA;
          //  double Delta_YAB=YB - YA;           
          //  double Distant_AB = Math.Sqrt(Delta_XAB*Delta_XAB+Delta_YAB*Delta_YAB);
            //AP,BP
           // double Alphard_AP = Alphard_AB - Agree1;
           // double Alphard_BP = Alphard_BA + Agree2;
           // double Distant_AP = Distant_AB * Math.Sin(Agree2) / Math.Sin(Math.PI - (Agree1 + Agree2));
           // double Distant_BP = Distant_AB * Math.Sin(Agree1) / Math.Sin(Math.PI - (Agree1 + Agree2));

            //计算P点坐标
            XP = (XA / Math.Tan(Agree2) + XB / Math.Tan(Agree1) + (YB - YA)) / (1 / Math.Tan(Agree1) + 1 / Math.Tan(Agree2));
            YP = (YA / Math.Tan(Agree2) + YB / Math.Tan(Agree1) + (XB - XA)) / (1 / Math.Tan(Agree1) + 1 / Math.Tan(Agree2));

            txt_XP.Text = XP.ToString();
            txt_YP.Text = YP.ToString();



            

        }






        //角度转弧度函数
        public double DegreeToRad(int Degree,int Point,int Second)
            {
            int D = Degree;
            int P = Point;
            int S = Second;
            double Rad = (Degree * 3600 + Point * 60 + Second) / (3600 * 180.0) * Math.PI;
            return   Rad;
            }

        //方位角计算
        public double Alphard(double XA,double YA,double XB,double YB)
        {
            double pi = Math.PI;
            double Alpha = 0;
            double xa = XA;
            double ya = YA;
            double xb = XB;
            double yb = YB;
            double DeltaY = yb - ya;
            double DeltaX = xb - xa;
            double Alpha0 = Math.Atan(Math.Abs(DeltaY / DeltaX));



            if (DeltaX > 0 && DeltaY > 0)
            {
                Alpha = Alpha0;
            }
            else
                if (DeltaX < 0 && DeltaY >= 0)
                {
                    Alpha = pi - Alpha0;
                }
                else
                    if (DeltaX < 0 && DeltaY < 0)
                    {
                        Alpha = Alpha0 + pi;
                    }
                    else
                    {
                        Alpha = 2 * pi - Alpha0;
                    }
            return Alpha;
        }



    }
}
