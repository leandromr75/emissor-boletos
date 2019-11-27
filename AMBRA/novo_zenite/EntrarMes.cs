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
    public partial class EntrarMes : Form
    {
        public EntrarMes()
        {
            InitializeComponent();
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked == true)
            {
                textBox1.ReadOnly = false;
                textBox2.ReadOnly = false;
            }
            if (checkBox1.Checked == false)
            {
                textBox1.ReadOnly = true;
                textBox2.ReadOnly = true;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (checkBox1.Checked == true)
            {
                if (String.IsNullOrEmpty(textBox1.Text) == false && String.IsNullOrEmpty(textBox2.Text) == false)
                {
                    DAL.Insere_Vencimento(1, textBox1.Text);
                    Global.Config.Texto = textBox2.Text;
                    Global.Config.Aviso = textBox3.Text;

                    this.Close();
                }
            }
            if (checkBox1.Checked == false)
            {
                Global.Config.Texto = textBox2.Text;
                Global.Config.Aviso = textBox3.Text;
                this.Close();
            }
        }

        private void EntrarMes_Load(object sender, EventArgs e)
        {
            
            DataTable ven = DAL.Lista_Vencimento();
            if (ven.Rows.Count > 0)
            {
                textBox1.Text = ven.Rows[0]["Vencimento"].ToString();
            }
            string mes = "";
            if (DateTime.Now.Month == 1)
            {
                mes = "DEZEMBRO";
            }
            if (DateTime.Now.Month == 2)
            {
                mes = "JANEIRO";
            }
            if (DateTime.Now.Month == 3)
            {
                mes = "FEVEREIRO";
            }
            if (DateTime.Now.Month == 4)
            {
                mes = "MARÇO";
            }
            if (DateTime.Now.Month == 5)
            {
                mes = "ABRIL";
            }
            if (DateTime.Now.Month == 6)
            {
                mes = "MAIO";
            }
            if (DateTime.Now.Month == 7)
            {
                mes = "JUNHO";
            }
            if (DateTime.Now.Month == 8)
            {
                mes = "JULHO";
            }
            if (DateTime.Now.Month == 9)
            {
                mes = "AGOSTO";
            }
            if (DateTime.Now.Month == 10)
            {
                mes = "SETEMBRO";
            }
            if (DateTime.Now.Month == 11)
            {
                mes = "OUTUBRO";
            }
            if (DateTime.Now.Month == 12)
            {
                mes = "NOVEMBRO";
            }
           // textBox2.Text = System.Globalization.DateTimeFormatInfo.CurrentInfo.GetMonthName(DateTime.Now.Date.Month).ToLower() + " de " + DateTime.Now.Date.Year.ToString();
            textBox2.Text = mes + " de " + DateTime.Now.Date.Year.ToString();
            textBox3.Focus();
        }


        private void button2_Click(object sender, EventArgs e)
        {
            Global.Config.Cancela = "sim";
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
            pictureBox1.Visible = true;
            textBox3.BackColor = Color.Cyan;
        }

        private void textBox3_Leave(object sender, EventArgs e)
        {
            pictureBox1.Visible = false;
            textBox3.BackColor = Color.White;
        }
    }
}
