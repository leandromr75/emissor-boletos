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
    public partial class Config : Form
    {
        public Config()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(textBox1.Text) == false && String.IsNullOrEmpty(textBox2.Text) == false && String.IsNullOrEmpty(textBox3.Text) == false &&
                String.IsNullOrEmpty(textBox6.Text) == false && String.IsNullOrEmpty(textBox5.Text) == false)
            {
                
                Double qtde2;
                if (Double.TryParse(textBox1.Text.Trim(), out qtde2) == false)
                {
                    MessageBox.Show("O campo só aceita valores numéricos");
                    textBox1.Text = "";
                    textBox1.Focus();
                    return;
                }
                
                if (Double.TryParse(textBox2.Text.Trim(), out qtde2) == false)
                {
                    MessageBox.Show("O campo só aceita valores numéricos");
                    textBox2.Text = "";
                    textBox2.Focus();
                    return;
                }
                if (Double.TryParse(textBox3.Text.Trim(), out qtde2) == false)
                {
                    MessageBox.Show("O campo só aceita valores numéricos");
                    textBox3.Text = "";
                    textBox3.Focus();
                    return;
                }
                if (Double.TryParse(textBox5.Text.Trim(), out qtde2) == false)
                {
                    MessageBox.Show("O campo só aceita valores numéricos");
                    textBox5.Text = "";
                    textBox5.Focus();
                    return;
                }
                if (Double.TryParse(textBox6.Text.Trim(), out qtde2) == false)
                {
                    MessageBox.Show("O campo só aceita valores numéricos");
                    textBox6.Text = "";
                    textBox6.Focus();
                    return;
                }
                //inserir parâmetros
                timer1.Enabled = true;
                DAL.Deleta_Config();
                DAL.Insere_Config(textBox1.Text, textBox2.Text, textBox3.Text, textBox6.Text, comboBox1.Text, textBox5.Text);
                
            }
            else
            {
                MessageBox.Show("Nenhum campo pode ser vazio");
                if (String.IsNullOrEmpty(textBox1.Text) == true)
                {
                    textBox1.Focus();
                    return;
                }
                if (String.IsNullOrEmpty(textBox2.Text) == true)
                {
                    textBox2.Focus();
                    return;
                }
                if (String.IsNullOrEmpty(textBox3.Text) == true)
                {
                    textBox3.Focus();
                    return;
                }
                if (String.IsNullOrEmpty(textBox6.Text) == true)
                {
                    textBox6.Focus();
                    return;
                }
                if (String.IsNullOrEmpty(textBox5.Text) == true)
                {
                    textBox5.Focus();
                    return;
                }
                
            }
            
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
                this.Close();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void textBox1_Enter(object sender, EventArgs e)
        {
            pictureBox7.Visible = true;
            textBox1.BackColor = Color.Cyan;
        }

        private void textBox1_Leave(object sender, EventArgs e)
        {
            pictureBox7.Visible = false;
            textBox1.BackColor = Color.White;
        }

        private void textBox2_Enter(object sender, EventArgs e)
        {
            pictureBox11.Visible = true;
            textBox2.BackColor = Color.Cyan;
        }

        private void textBox2_Leave(object sender, EventArgs e)
        {
            pictureBox11.Visible = false;
            textBox2.BackColor = Color.White;
        }

        private void textBox3_Enter(object sender, EventArgs e)
        {
            pictureBox12.Visible = true;
            textBox3.BackColor = Color.Cyan;
        }

        private void textBox3_Leave(object sender, EventArgs e)
        {
            pictureBox12.Visible = false;
            textBox3.BackColor = Color.White;
        }

        private void textBox6_Enter(object sender, EventArgs e)
        {
            pictureBox3.Visible = true;
            textBox6.BackColor = Color.Cyan;
        }

        private void textBox6_Leave(object sender, EventArgs e)
        {
            pictureBox3.Visible = false;
            textBox6.BackColor = Color.White;
        }

        private void textBox5_Enter(object sender, EventArgs e)
        {
            pictureBox2.Visible = true;
            textBox5.BackColor = Color.Cyan;
        }

        private void textBox5_Leave(object sender, EventArgs e)
        {
            pictureBox2.Visible = false;
            textBox5.BackColor = Color.White;
        }

        private void Config_Load(object sender, EventArgs e)
        {
            comboBox1.Text = "5";

            DataTable conf = DAL.Lista_Config();
            if (conf.Rows.Count > 0)
            {
                textBox1.Text = conf.Rows[0]["Valor_Base"].ToString();
                textBox2.Text = conf.Rows[0]["Dez_Trinta"].ToString();
                textBox3.Text = conf.Rows[0]["Trinta_Noventa"].ToString();
                textBox6.Text = conf.Rows[0]["Noventa"].ToString();
                textBox5.Text = conf.Rows[0]["TX_Comercial"].ToString();
                comboBox1.Text = conf.Rows[0]["Multa"].ToString();
            }
        }
    }
}
