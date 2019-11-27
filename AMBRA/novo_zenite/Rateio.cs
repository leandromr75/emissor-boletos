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
    public partial class Rateio : Form
    {
        public Rateio()
        {
            InitializeComponent();
        }

        private void textBox1_Enter(object sender, EventArgs e)
        {
            textBox1.BackColor = Color.Cyan;
            pictureBox7.Visible = true;
        }

        private void textBox1_Leave(object sender, EventArgs e)
        {
            textBox1.BackColor = Color.White;
            pictureBox7.Visible = false;
        }

        private void textBox2_Enter(object sender, EventArgs e)
        {
            textBox2.BackColor = Color.Cyan;
            pictureBox11.Visible = true;
        }

        private void textBox2_Leave(object sender, EventArgs e)
        {
            textBox2.BackColor = Color.White;
            pictureBox11.Visible = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(textBox1.Text) == false && String.IsNullOrEmpty(textBox2.Text) == false )
            {
                
                Double qtde2;
                if (Double.TryParse(textBox2.Text.Trim(), out qtde2) == false)
                {
                    MessageBox.Show("O campo valor só aceita valores numéricos");
                    textBox2.Text = "";
                    textBox2.Focus();
                    return;

                }
                if (Double.TryParse(textBox2.Text.Trim(), out qtde2) == true)
                {
                    if (checkBox1.Checked == false)
                    {
                        timer1.Enabled = true;
                        DataTable nome = DAL.Lista_Mes_Atual();
                        if (nome.Rows.Count > 0)
                        {
                            Double rec2 = Convert.ToDouble(textBox2.Text);
                            textBox2.Text = rec2.ToString("N2");
                            DAL.Insere_Rateio(textBox1.Text, textBox2.Text, "não", nome.Rows[0]["Atual"].ToString());
                           
                            
                        }
                        else
                        {
                            MessageBox.Show("Mês atual não definido");
                            return;
                        }
                        
                    }
                    if (checkBox1.Checked == true)
                    {
                        timer1.Enabled = true;
                        DataTable nome = DAL.Lista_Mes_Atual();
                        if (nome.Rows.Count > 0)
                        {
                            Double rec2 = Convert.ToDouble(textBox2.Text);
                            textBox2.Text = rec2.ToString("N2");
                            DAL.Insere_Rateio(textBox1.Text, textBox2.Text, "sim", nome.Rows[0]["Atual"].ToString());
                            int i = Convert.ToInt32(comboBox1.Text);
                            string result = "";
                            if (i > 0)
                            {
                                DataTable id = DAL.Lista_Rateio();
                                 
                                int idTemp = Convert.ToInt32( id.Rows[id.Rows.Count - 1]["Id"].ToString() );
                                if (String.IsNullOrEmpty(textBox2.Text) == false)
                                {
                                    string valor = textBox2.Text;
                                    Double re = Convert.ToDouble(valor) / i;
                                    result = re.ToString("N2");                                    
                                }
                                for (int j = 0; j < i; j++)
                                {
                                    DAL.Insere_Rateio_Parcelado(idTemp, textBox1.Text, Convert.ToString(j + 1), result);
                                }
                            }
                            if (i <= 1)
                            {
                                MessageBox.Show("Escolha pelo menos 2 parcelas");
                            }
                        }
                        else
                        {
                            MessageBox.Show("Mês atual não definido");
                            return;
                        }
                        
                    }
                }
            }
            else
            {
                MessageBox.Show("Os dois campos são obrigatórios");
            }
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked == false)
            {
                comboBox1.SelectedIndex = 0;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form visuRat = new VisualizaRateio();
            visuRat.ShowDialog();
        }
        int ampu = 0;
        private void timer1_Tick(object sender, EventArgs e)
        {
            Cursor = Cursors.WaitCursor;
            pictureBox20.Visible = true;
           
            ampu++;
            if (ampu == 10)
            {
                ampu = 0;
                pictureBox20.Visible = false;
                
                Cursor = Cursors.Default;
                timer1.Enabled = false;
                MessageBox.Show("Incluído com sucesso");
                textBox1.Text = "";
                textBox2.Text = "";
                checkBox1.Checked = false;
                
            }
        }
    }
}
