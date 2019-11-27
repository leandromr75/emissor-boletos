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
    public partial class Print : Form
    {
        public Print(string texto)
        {
            InitializeComponent();
            label1.Text = texto;
           
        }
        
        int cont = 0;
        private void timer1_Tick(object sender, EventArgs e)
        {
            cont++;
            if (cont == 20)
            {
                timer1.Enabled = false;
                this.Close();
            }
        }

        private void Print_Load(object sender, EventArgs e)
        {
            timer1.Enabled = true;
            
        }
    }
}
