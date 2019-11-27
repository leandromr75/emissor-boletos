using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace novo_zenite
{
    public partial class Hello : Form
    {
        public Hello()
        {
            InitializeComponent();
        }

        private void Hello_Load(object sender, EventArgs e)
        {
            timer1.Enabled = true;
        }
        int cont2 = 0;
        private void timer1_Tick(object sender, EventArgs e)
        {
            if (DateTime.Now.Hour >= 5 && DateTime.Now.Hour <= 12)
            {
                label1.Text = "Bom dia Sr. Edson";
            }
            if (DateTime.Now.Hour >= 13 && DateTime.Now.Hour <= 18)
            {
                label1.Text = "Boa Tarde Sr. Edson";
            }
            if (DateTime.Now.Hour >= 19 && DateTime.Now.Hour <= 23)
            {
                label1.Text = "Boa Noite Sr. Edson";
            }
           
            cont2++;
            if (cont2 >= 9)
            {
                timer1.Enabled = false;
                this.Close();
            }
        }
    }
}
