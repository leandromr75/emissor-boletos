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
    public partial class Data : Form
    {
        public Data()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void monthCalendar1_DateSelected(object sender, DateRangeEventArgs e)
        {
            
        }

        private void Data_Load(object sender, EventArgs e)
        {
            textBox3.Text = Global.Config.Valor_Pago;
            textBox2.Text = Global.Config.Atraso;
            DataTable config = DAL.Lista_Config();
            //calcular valor
            string valor1 = config.Rows[0]["Valor_Base"].ToString();
            string valor2 = "0";
            string valor3 = "0";
            string valor4 = "0";
            string resultado = "0";
            int consu = Convert.ToInt32(Global.Config.Consumo);
            if (consu <= 10)
            {
                textBox7.Text = Convert.ToString(consu) + " m³ - taxa R$" + config.Rows[0]["Valor_Base"].ToString();  
            }
            if (consu > 10 && consu <= 30)
            {
                Double re = Convert.ToDouble(consu - 10) * Convert.ToDouble(config.Rows[0]["Dez_Trinta"].ToString()) ;
                valor2 = re.ToString("N2");
                textBox7.Text = Convert.ToString(consu) + " m³ - taxa R$" + config.Rows[0]["Dez_Trinta"].ToString();
            }
            if (consu > 30 && consu <= 90)
            {
                Double re30 = Convert.ToDouble(20) * Convert.ToDouble(config.Rows[0]["Dez_Trinta"].ToString());
                
                Double re = Convert.ToDouble(consu - 30) * Convert.ToDouble(config.Rows[0]["Trinta_Noventa"].ToString());
                re = re + re30;
                valor3 = re.ToString("N2");
                textBox7.Text = Convert.ToString(consu) + " m³ - taxa R$" + config.Rows[0]["Trinta_Noventa"].ToString();
            }
            if (consu > 90 )
            {
                Double re30 = Convert.ToDouble(20) * Convert.ToDouble(config.Rows[0]["Dez_Trinta"].ToString());
                Double re50 = Convert.ToDouble(50) * Convert.ToDouble(config.Rows[0]["Trinta_Noventa"].ToString());
                Double re = Convert.ToDouble(consu - 90) * Convert.ToDouble(config.Rows[0]["Noventa"].ToString());
                re = re + re30 + re50;
                valor4 = re.ToString("N2");
                textBox7.Text = Convert.ToString(consu) + " m³ - taxa R$" + config.Rows[0]["Noventa"].ToString();
            }
            Double rec = Convert.ToDouble(valor1) + Convert.ToDouble(valor2) + Convert.ToDouble(valor3) + Convert.ToDouble(valor4);
            resultado = rec.ToString("N2");
            DataTable nomes1 = DAL.Lista_Nome();
            //pega rateio
            DataTable rateio = DAL.Lista_Rateio();
            string valorRateio = "0";
            if (rateio.Rows.Count > 0)
            {
                for (int i = 0; i < rateio.Rows.Count; i++)
                {
                    if (rateio.Rows[i]["Parcelado"].ToString() == "não")
                    {
                        Double rec1 = Convert.ToDouble(resultado) + Convert.ToDouble(rateio.Rows[i]["Valor"].ToString()) / nomes1.Rows.Count ;
                        resultado = rec1.ToString("N2");

                        Double rec2 = Convert.ToDouble(valorRateio) + Convert.ToDouble(rateio.Rows[i]["Valor"].ToString()) / nomes1.Rows.Count;
                        valorRateio = rec2.ToString("N2");
                    }
                    if (rateio.Rows[i]["Parcelado"].ToString() == "sim")
                    {
                        DataTable rat_parc = DAL.Lista_Rateio_Parcelado(Convert.ToInt32 (rateio.Rows[i]["Id"].ToString()));
                        if (rat_parc.Rows.Count > 0)
                        {
                            Double rec1 = Convert.ToDouble(resultado) + Convert.ToDouble(rat_parc.Rows[0]["Valor"].ToString()) / nomes1.Rows.Count;
                            resultado = rec1.ToString("N2");

                            Double rec2 = Convert.ToDouble(valorRateio) + Convert.ToDouble(rat_parc.Rows[0]["Valor"].ToString()) / nomes1.Rows.Count;
                            valorRateio = rec2.ToString("N2");
 
                        }
                        
                    }
                }
            }
            textBox5.Text = valorRateio;
            string valorTX = "0";
            //tx
            DataTable tx = DAL.Lista_Nome();
            if (tx.Rows.Count > 0)
            {
                for (int i = 0; i < tx.Rows.Count; i++)
                {
                    if (tx.Rows[i]["Id"].ToString() == Global.Config.Pag_Id)
                    {
                        if (Convert.ToInt32(tx.Rows[i]["TX_Comercial"].ToString()) >= 1)
                        {
                            string taxa = config.Rows[0]["TX_Comercial"].ToString();
                            Double rec1 = Convert.ToDouble(resultado) + ( Convert.ToDouble(taxa) * Convert.ToDouble(tx.Rows[i]["TX_Comercial"].ToString()));
                            resultado = rec1.ToString("N2");

                            
                            Double rec2 = Convert.ToDouble(valorTX) + (Convert.ToDouble(taxa) * Convert.ToDouble(tx.Rows[i]["TX_Comercial"].ToString()));
                            valorTX = rec2.ToString("N2");
                        }     
                    }
                   
                }
            }
            textBox1.Text = resultado;
            textBox6.Text = valorTX;
            if (String.IsNullOrEmpty(textBox2.Text) == true)
            {
                textBox2.Text = "0";
            }

            Double rec4 = (Convert.ToDouble(resultado) + Convert.ToDouble(Global.Config.Atraso)) - Convert.ToDouble(Global.Config.Valor_Pago);
            textBox4.Text = rec4.ToString("N2");
            
            //DAL.Pagou_Id(Convert.ToInt32(Global.Config.Pag_Id), "sim");
            
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            DataTable config = DAL.Lista_Config();
            if (checkBox1.Checked == true)
            {
                checkBox2.Checked = false;
                textBox3.Text = Global.Config.Valor_Pago;
                textBox2.Text = Global.Config.Atraso;

                //calcular valor
                string valor1 = config.Rows[0]["Valor_Base"].ToString();
                string valor2 = "0";
                string valor3 = "0";
                string valor4 = "0";
                string resultado = "0";
                int consu = Convert.ToInt32(Global.Config.Consumo);
                if (consu <= 10)
                {
                    textBox7.Text = Convert.ToString(consu) + " m³ - taxa R$" + config.Rows[0]["Valor_Base"].ToString();
                }
                if (consu > 10 && consu <= 30)
                {
                    Double re = Convert.ToDouble(consu - 10) * Convert.ToDouble(config.Rows[0]["Dez_Trinta"].ToString());
                    valor2 = re.ToString("N2");
                    textBox7.Text = Convert.ToString(consu) + " m³ - taxa R$" + config.Rows[0]["Dez_Trinta"].ToString();
                }
                if (consu > 30 && consu <= 90)
                {
                    Double re30 = Convert.ToDouble(20) * Convert.ToDouble(config.Rows[0]["Dez_Trinta"].ToString());

                    Double re = Convert.ToDouble(consu - 30) * Convert.ToDouble(config.Rows[0]["Trinta_Noventa"].ToString());
                    re = re + re30;
                    valor3 = re.ToString("N2");
                    textBox7.Text = Convert.ToString(consu) + " m³ - taxa R$" + config.Rows[0]["Trinta_Noventa"].ToString();
                }
                if (consu > 90)
                {
                    Double re30 = Convert.ToDouble(20) * Convert.ToDouble(config.Rows[0]["Dez_Trinta"].ToString());
                    Double re50 = Convert.ToDouble(50) * Convert.ToDouble(config.Rows[0]["Trinta_Noventa"].ToString());
                    Double re = Convert.ToDouble(consu - 90) * Convert.ToDouble(config.Rows[0]["Noventa"].ToString());
                    re = re + re30 + re50;
                    valor4 = re.ToString("N2");
                    textBox7.Text = Convert.ToString(consu) + " m³ - taxa R$" + config.Rows[0]["Noventa"].ToString();
                }
                Double rec = Convert.ToDouble(valor1) + Convert.ToDouble(valor2) + Convert.ToDouble(valor3) + Convert.ToDouble(valor4);
                resultado = rec.ToString("N2");
                DataTable nomes1 = DAL.Lista_Nome();
                //pega rateio
                DataTable rateio = DAL.Lista_Rateio();
                string valorRateio = "0";
                if (rateio.Rows.Count > 0)
                {
                    for (int i = 0; i < rateio.Rows.Count; i++)
                    {
                        if (rateio.Rows[i]["Parcelado"].ToString() == "não")
                        {
                            Double rec1 = Convert.ToDouble(resultado) + Convert.ToDouble(rateio.Rows[i]["Valor"].ToString()) / nomes1.Rows.Count;
                            resultado = rec1.ToString("N2");

                            Double rec2 = Convert.ToDouble(valorRateio) + Convert.ToDouble(rateio.Rows[i]["Valor"].ToString()) / nomes1.Rows.Count;
                            valorRateio = rec2.ToString("N2");
                        }
                        if (rateio.Rows[i]["Parcelado"].ToString() == "sim")
                        {
                            DataTable rat_parc = DAL.Lista_Rateio_Parcelado(Convert.ToInt32(rateio.Rows[i]["Id"].ToString()));
                            if (rat_parc.Rows.Count > 0)
                            {
                                Double rec1 = Convert.ToDouble(resultado) + Convert.ToDouble(rat_parc.Rows[0]["Valor"].ToString()) / nomes1.Rows.Count;
                                resultado = rec1.ToString("N2");

                                Double rec2 = Convert.ToDouble(valorRateio) + Convert.ToDouble(rat_parc.Rows[0]["Valor"].ToString()) / nomes1.Rows.Count;
                                valorRateio = rec2.ToString("N2");

                            }

                        }
                    }
                }
                textBox5.Text = valorRateio;
                string valorTX = "0";
                //tx
                DataTable tx = DAL.Lista_Nome();
                if (tx.Rows.Count > 0)
                {
                    for (int i = 0; i < tx.Rows.Count; i++)
                    {
                        if (tx.Rows[i]["Id"].ToString() == Global.Config.Pag_Id)
                        {
                            if (Convert.ToInt32(tx.Rows[i]["TX_Comercial"].ToString()) >= 1)
                            {
                                string taxa = config.Rows[0]["TX_Comercial"].ToString();
                                Double rec1 = Convert.ToDouble(resultado) + (Convert.ToDouble(taxa) * Convert.ToDouble(tx.Rows[i]["TX_Comercial"].ToString()));
                                resultado = rec1.ToString("N2");


                                Double rec2 = Convert.ToDouble(valorTX) + (Convert.ToDouble(taxa) * Convert.ToDouble(tx.Rows[i]["TX_Comercial"].ToString()));
                                valorTX = rec2.ToString("N2");
                            }
                        }

                    }
                }
                textBox1.Text = resultado;
                textBox6.Text = valorTX;
                if (String.IsNullOrEmpty(textBox2.Text) == true)
                {
                    textBox2.Text = "0";
                }

                Double rec4 = (Convert.ToDouble(resultado) + Convert.ToDouble(Global.Config.Atraso)) - Convert.ToDouble(Global.Config.Valor_Pago);
                textBox4.Text = rec4.ToString("N2");
            
            }
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox2.Checked == true)
            {
                DataTable config = DAL.Lista_Config();
                checkBox1.Checked = false;
                textBox3.Text = Global.Config.Valor_Pago;
                textBox2.Text = Global.Config.Atraso;

                //calcular valor
                string valor1 = config.Rows[0]["Valor_Base"].ToString();
                string valor2 = "0";
                string valor3 = "0";
                string valor4 = "0";
                string resultado = "0";
                int consu = Convert.ToInt32(Global.Config.Consumo);
                if (consu <= 10)
                {
                    textBox7.Text = Convert.ToString(consu) + " m³ - taxa R$" + config.Rows[0]["Valor_Base"].ToString();
                }
                if (consu > 10 && consu <= 30)
                {
                    Double re = Convert.ToDouble(consu - 10) * Convert.ToDouble(config.Rows[0]["Dez_Trinta"].ToString());
                    valor2 = re.ToString("N2");
                    textBox7.Text = Convert.ToString(consu) + " m³ - taxa R$" + config.Rows[0]["Dez_Trinta"].ToString();
                }
                if (consu > 30 && consu <= 90)
                {
                    Double re30 = Convert.ToDouble(20) * Convert.ToDouble(config.Rows[0]["Dez_Trinta"].ToString());

                    Double re = Convert.ToDouble(consu - 30) * Convert.ToDouble(config.Rows[0]["Trinta_Noventa"].ToString());
                    re = re + re30;
                    valor3 = re.ToString("N2");
                    textBox7.Text = Convert.ToString(consu) + " m³ - taxa R$" + config.Rows[0]["Trinta_Noventa"].ToString();
                }
                if (consu > 90)
                {
                    Double re30 = Convert.ToDouble(20) * Convert.ToDouble(config.Rows[0]["Dez_Trinta"].ToString());
                    Double re50 = Convert.ToDouble(50) * Convert.ToDouble(config.Rows[0]["Trinta_Noventa"].ToString());
                    Double re = Convert.ToDouble(consu - 90) * Convert.ToDouble(config.Rows[0]["Noventa"].ToString());
                    re = re + re30 + re50;
                    valor4 = re.ToString("N2");
                    textBox7.Text = Convert.ToString(consu) + " m³ - taxa R$" + config.Rows[0]["Noventa"].ToString();
                }
                Double rec = Convert.ToDouble(valor1) + Convert.ToDouble(valor2) + Convert.ToDouble(valor3) + Convert.ToDouble(valor4);
                resultado = rec.ToString("N2");
                DataTable nomes1 = DAL.Lista_Nome();
                //pega rateio
                DataTable rateio = DAL.Lista_Rateio();
                string valorRateio = "0";
                if (rateio.Rows.Count > 0)
                {
                    for (int i = 0; i < rateio.Rows.Count; i++)
                    {
                        if (rateio.Rows[i]["Parcelado"].ToString() == "não")
                        {
                            Double rec1 = Convert.ToDouble(resultado) + Convert.ToDouble(rateio.Rows[i]["Valor"].ToString()) / nomes1.Rows.Count;
                            resultado = rec1.ToString("N2");

                            Double rec2 = Convert.ToDouble(valorRateio) + Convert.ToDouble(rateio.Rows[i]["Valor"].ToString()) / nomes1.Rows.Count;
                            valorRateio = rec2.ToString("N2");
                        }
                        if (rateio.Rows[i]["Parcelado"].ToString() == "sim")
                        {
                            DataTable rat_parc = DAL.Lista_Rateio_Parcelado(Convert.ToInt32(rateio.Rows[i]["Id"].ToString()));
                            if (rat_parc.Rows.Count > 0)
                            {
                                Double rec1 = Convert.ToDouble(resultado) + Convert.ToDouble(rat_parc.Rows[0]["Valor"].ToString()) / nomes1.Rows.Count;
                                resultado = rec1.ToString("N2");

                                Double rec2 = Convert.ToDouble(valorRateio) + Convert.ToDouble(rat_parc.Rows[0]["Valor"].ToString()) / nomes1.Rows.Count;
                                valorRateio = rec2.ToString("N2");

                            }

                        }
                    }
                }
                textBox5.Text = valorRateio;
                string valorTX = "0";
                //tx
                DataTable tx = DAL.Lista_Nome();
                if (tx.Rows.Count > 0)
                {
                    for (int i = 0; i < tx.Rows.Count; i++)
                    {
                        if (tx.Rows[i]["Id"].ToString() == Global.Config.Pag_Id)
                        {
                            if (Convert.ToInt32(tx.Rows[i]["TX_Comercial"].ToString()) >= 1)
                            {
                                string taxa = config.Rows[0]["TX_Comercial"].ToString();
                                Double rec1 = Convert.ToDouble(resultado) + (Convert.ToDouble(taxa) * Convert.ToDouble(tx.Rows[i]["TX_Comercial"].ToString()));
                                resultado = rec1.ToString("N2");


                                Double rec2 = Convert.ToDouble(valorTX) + (Convert.ToDouble(taxa) * Convert.ToDouble(tx.Rows[i]["TX_Comercial"].ToString()));
                                valorTX = rec2.ToString("N2");
                            }
                        }

                    }
                }
                Double rec3 = Convert.ToDouble(resultado) * Convert.ToDouble("1,0" + config.Rows[0]["Multa"].ToString()) ;
                textBox1.Text = rec3.ToString("N2");
                resultado = rec3.ToString("N2");
                textBox6.Text = valorTX;
                if (String.IsNullOrEmpty(textBox2.Text) == true)
                {
                    textBox2.Text = "0";
                }

                Double rec4 = (Convert.ToDouble(resultado) + Convert.ToDouble(Global.Config.Atraso)) - Convert.ToDouble(Global.Config.Valor_Pago);
                textBox4.Text = rec4.ToString("N2");
            
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
               // MessageBox.Show("Incluído com sucesso");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string message = "Você deseja finalizar este pagamento e atualizar o saldo devedor?.";
            string caption = "Finalizar Pagamento";
            MessageBoxButtons buttons = MessageBoxButtons.YesNo;
            DialogResult result;

            // Displays the MessageBox.
            result = MessageBox.Show(this, message, caption, buttons,
            MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);
            if (result == DialogResult.Yes)
            {
                timer1.Enabled = true;

                DAL.Pagou_Id(Convert.ToInt32(Global.Config.Pag_Id), "sim");
                //atualizar devedor    
                DAL.Atualiza_Atraso(Convert.ToInt32(Global.Config.Pag_Id),textBox4.Text);
                DataTable name = DAL.Lista_Nomes_Re(Global.Config.Nome);
                if (name.Rows.Count > 0)
                {
                    DAL.Altera_Relatorio(name.Rows[0]["Nome"].ToString(),textBox3.Text);
                }
                this.Close();
            }        
            
            
        }
    }
}
