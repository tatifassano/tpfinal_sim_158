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
    public partial class MenuPrincipal : Form
    {
        public MenuPrincipal()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form1 euler = new Form1();
            euler.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            RK runge = new RK();
            runge.Show();
        }
    }
}
