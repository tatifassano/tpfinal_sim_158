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
    public partial class RK : Form
    {
        private Int32 fin;
        private double x1i;
        private double x2i;
        private double x1_0;
        private double x2_0;
        private double k1_x1;
        private double k1_x2;
        private double k2_x1;
        private double k2_x2;
        private double k3_x1;
        private double k3_x2;
        private double k4_x1;
        private double k4_x2;
        private double h;
        private double t0;
        private double t;
        private double u;
        private double ti;
        private double x1;
        private double x2;
        private int desde;
        private int hasta;
        private double a;
        private double b;
        private double c = (double)1 / 6;


        public RK()
        {
            InitializeComponent();
        }

        private void RK_Load(object sender, EventArgs e)
        {
            txt_h.Text = Convert.ToString(0.1);
            txt_t0.Text = Convert.ToString(0);
            txt_u.Text = Convert.ToString(2);
            txt_x1_0.Text = Convert.ToString(0.5);
            txt_x2_0.Text = Convert.ToString(0);
            txt_desde.Text = Convert.ToString(1);
            txt_hasta.Text = Convert.ToString(20);
            txt_fin.Text = Convert.ToString(200);
        }

        private void btn_simular_Click(object sender, EventArgs e)
        {
            //dg_Euler.Rows.Clear();
            dg_runge.Rows.Clear();

            fin = Convert.ToInt32(txt_fin.Text);
            x1_0 = Convert.ToDouble(txt_x1_0.Text);
            x2_0 = Convert.ToDouble(txt_x2_0.Text);
            h = Convert.ToDouble(txt_h.Text);
            u = Convert.ToDouble(txt_u.Text);
            t0 = Convert.ToDouble(txt_t0.Text);
            desde = Convert.ToInt32(txt_desde.Text);
            hasta = Convert.ToInt32(txt_hasta.Text);


            for (int i = 0; i <= fin; i++)
            {

                if (i == 0)
                {
                    //t = 0;
                    //x1 = 0;
                    //x2 = 0;
                    //dx1 = 0;
                    //dx2 = 0;
                    ti = Math.Round(t0, 2);
                    x1i = Math.Round(x1_0, 4);
                    x2i = Math.Round(x2_0, 4);

                }

                if (i >= 1)
                {
                    t = ti;
                    x1 = Math.Round(x1i, 4);
                    x2 = Math.Round(x2i, 4);
                    k1_x1 = Math.Round(h * x2, 4);
                    k1_x2 = Math.Round(h * u * (1 - x1 * x1) * x2 - x1, 4);
                    k2_x1 = Math.Round(h * (x2 + k1_x2 / 2), 4);
                    k2_x2 = Math.Round(h * u * (1 - x1 * x1 + k1_x1 / 2) * (x2 + k1_x2 / 2) - (x1 + k1_x1 / 2), 4);
                    k3_x1 = Math.Round(h * (x2 + k2_x2 / 2), 4);
                    k3_x2 = Math.Round(h * u * (1 - x1 * x1 + k2_x1 / 2) * (x2 + k2_x2 / 2) - (x1 + k2_x1 / 2), 4);
                    k4_x1 = Math.Round(h * (x2 + k3_x2), 4);
                    k4_x2 = Math.Round(h * u * (1 - x1 * x1 + k3_x1) * (x2 + k3_x2) - (x1 + k3_x1), 4);
                    ti = t + h;
                    a = (k1_x1 + 2 * k2_x1 + 2 * k3_x1 + k4_x1);
                    b = (k1_x2 + 2 * k2_x2 + 2 * k3_x2 + k4_x2);
                    x1i = Math.Round(x1 + c * a, 4);
                    x2i = Math.Round(x2 + c * b, 4);
                    //x2i = Math.Round(x1 + (1 / 6 * k3_x2), 4);
                    //x2i = Math.Round(x2 + (h * k2_x2), 4);

                }

                //problema cuando u es decimal
                //rta, es porque en la aplicacion se usa, y no .

                if (i >= desde && i <= hasta)
                {
                    dg_runge.Rows.Add(i, t, x1, x2, k1_x1, k1_x2, k2_x1, k2_x2, k3_x1, k3_x2, k4_x1, k4_x2, ti, x1i, x2i);
                    //dg_Euler.Rows.Add(i, t, x1, x2, k1_x1, k1_x2, k2_x1, k2_x2, k3_x1, k3_x2, k4_x1, k4_x2, ti, x1i, x2i);
                }
                if (i == fin)
                {
                    dg_runge.Rows.Add(i, t, x1, x2, k1_x1, k1_x2, k2_x1, k2_x2, k3_x1, k3_x2, k4_x1, k4_x2, ti, x1i, x2i);
                }

                x1vsx2.Series["X1"].Points.AddXY(t, x1);
                x1vsx2.Series["X2"].Points.AddXY(t, x2);
                grafDispersion.Series["X1"].Points.AddXY(x1, x2);
                grafDispersion.Series["X2"].Points.AddXY(x1, x2);

            }
        }
    }
}
