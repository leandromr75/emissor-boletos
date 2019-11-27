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
    public partial class Leitura : Form
    {
        public Leitura()
        {
            InitializeComponent();
        }
        DataTable lista = DAL.Lista_Nome();
        int cont = 0;
        private void Leitura_Load(object sender, EventArgs e)
        {

            
            
                label4.Text = lista.Rows[cont]["Id"].ToString();
                textBox1.Text = lista.Rows[cont]["Nome"].ToString();
                textBox2.Text = lista.Rows[cont]["Anterior"].ToString();
                textBox3.Focus();
           
            
        }

        private void button17_Click(object sender, EventArgs e)
        {

            if (cont == lista.Rows.Count)
            {
                MessageBox.Show("Lançado todas as medições");
                return;


            }
            Int64 qtde2;
            if (Int64.TryParse(textBox3.Text.Trim(), out qtde2) == false)
            {
                MessageBox.Show("O campo consumo só aceita valores numéricos");
                textBox3.Text = "";
                textBox3.Focus();
                return;

            }
            if (String.IsNullOrEmpty(textBox3.Text) == false )
            {
                if (Convert.ToInt32(textBox3.Text) < Convert.ToInt32(textBox2.Text))
                {
                    MessageBox.Show("Consumo atual fornecido é menor que anterior");
                    return;
                }
                timer1.Enabled = true;
                DAL.Insere_Leitura(Convert.ToInt32(label4.Text), textBox3.Text);

               
                
                textBox3.Focus();
            }
                
               
           
            
        }
        int ampu = 0;
        private void timer1_Tick(object sender, EventArgs e)
        {
            pictureBox21.Visible = true;
            
            ampu++;
            if (ampu == 10)
            {
                ampu = 0;
                
                pictureBox21.Visible = false;
                
                Cursor = Cursors.Default;
                timer1.Enabled = false;
                MessageBox.Show("Incluído com sucesso\nConsumo: " + Convert.ToString(Convert.ToInt32(textBox3.Text) - Convert.ToInt32(textBox2.Text)) + " Metros Cúbicos");
                textBox3.Text = "0";
                cont++;
                if (cont == lista.Rows.Count)
                {
                    MessageBox.Show("Lançado todas as medições");
                    return;


                }
                textBox1.Text = lista.Rows[cont]["Nome"].ToString();
                textBox2.Text = lista.Rows[cont]["Anterior"].ToString();
                label4.Text = lista.Rows[cont]["Id"].ToString();
            }
        }
    }
}
