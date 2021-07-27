using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TpFinal_SIM
{
    public partial class Form1 : Form
    {

        private Int32 fin;
        private double x1i;
        private double x2i;
        private double x1_0;
        private double x2_0;
        private double h;
        private double dx1;
        private double dx2;
        private double t0;
        private double t;
        private double u;
        private double ti;
        private double x1;
        private double x2;
        


        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            txt_h.Text = Convert.ToString(0.1);
            txt_t0.Text = Convert.ToString(0);
            txt_u.Text = Convert.ToString(2);
            txt_x1_0.Text = Convert.ToString(0.5);
            txt_x2_0.Text = Convert.ToString(0);
            txt_desde.Text = Convert.ToString(1);
            txt_hasta.Text = Convert.ToString(200);
            txt_fin.Text = Convert.ToString(200);
        }

        private void btn_simular_Click(object sender, EventArgs e)
        {
            dg_Euler.Rows.Clear();
            
            fin = Convert.ToInt32(txt_fin.Text);
            x1_0 = Convert.ToDouble(txt_x1_0.Text);
            x2_0 = Convert.ToDouble(txt_x2_0.Text);
            h = Convert.ToDouble(txt_h.Text);
            u = Convert.ToDouble(txt_u.Text);
            t0 = Convert.ToDouble(txt_t0.Text);

            for (int i = 0; i <= fin; i++)
            {

                if (i == 0)
                {
                    //t = 0;
                    //x1 = 0;
                    //x2 = 0;
                    //dx1 = 0;
                    //dx2 = 0;
                    ti = t0;
                    x1i = Math.Round(x1_0, 4);
                    x2i = Math.Round(x2_0, 4);

                }

                if (i >= 1)
                {
                    t = ti;
                    x1 = Math.Round(x1i, 4);
                    x2 = Math.Round(x2i, 4);
                    dx1 = Math.Round(x2, 4);
                    dx2 = Math.Round(((u * (1 - (x1 * x1))) * x2 - x1), 4);
                    ti = t + h;
                    x1i = Math.Round(x1 + (h * dx1), 4);
                    x2i = Math.Round(x2 + (h * dx2), 4);

                }


                if (i >= Convert.ToInt32(txt_desde.Text) && i <= Convert.ToInt32(txt_hasta.Text))
                {
                    dg_Euler.Rows.Add(i, t, x1, x2, dx1, dx2, ti, x1i, x2i);
                    //x1vsx2.Series["X1"].Points.AddXY(t, x1);
                    //x1vsx2.Series["X2"].Points.AddXY(t, x2);
                    //graf2.Series["X1"].Points.AddXY(x1, x2);
                    //graf2.Series["X2"].Points.AddXY(x1, x2);


                }

                if (i == Convert.ToInt32(txt_fin.Text))
                {
                    dg_Euler.Rows.Add(i, t, x1, x2, dx1, dx2, ti, x1i, x2i);
                    //x1vsx2.Series["X1"].Points.AddXY(t, x1);
                    //x1vsx2.Series["X2"].Points.AddXY(t, x2);
                    //graf2.Series["X1"].Points.AddXY(x1, x2);
                    //graf2.Series["X2"].Points.AddXY(x1, x2);
                }

                x1vsx2.Series["X1"].Points.AddXY(t, x1);
                x1vsx2.Series["X2"].Points.AddXY(t, x2);
                graf2.Series["X1"].Points.AddXY(x1, x2);
                graf2.Series["X2"].Points.AddXY(x1, x2);

            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
            
        }
    }
}
