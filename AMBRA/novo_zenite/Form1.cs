using CrystalDecisions.CrystalReports.Engine;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace novo_zenite
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            

        }
        DataTable nomes = new DataTable();
        CrystalReportRecibo rpt = new CrystalReportRecibo(); //Instancia o objeto do tipo seu relatório
        CrystalReportRelatorio rpt1 = new CrystalReportRelatorio(); //Instancia o objeto do tipo seu relatório
        CrystalReportLeitura rpt2 = new CrystalReportLeitura(); //Instancia o objeto do tipo seu relatório


        private void PopulateInstalledPrintersCombo()
        {
            // Add list of installed printers found to the combo box.
            // The pkInstalledPrinters string will be used to provide the display string.
            String pkInstalledPrinters;
            for (int i = 0; i < PrinterSettings.InstalledPrinters.Count; i++)
            {
                pkInstalledPrinters = PrinterSettings.InstalledPrinters[i];
                comboInstalledPrinters.Items.Add(pkInstalledPrinters);
                
            }
        }

        private void comboInstalledPrinters_SelectionChanged(object sender, System.EventArgs e)
        {

            // Set the printer to a printer in the combo box when the selection changes.

            if (comboInstalledPrinters.SelectedIndex != -1)
            {
                // The combo box's Text property returns the selected item's text, which is the printer name.
                rpt.PrintOptions.PrinterName = comboInstalledPrinters.Text;
                rpt1.PrintOptions.PrinterName = comboInstalledPrinters.Text;
                rpt2.PrintOptions.PrinterName = comboInstalledPrinters.Text;
                // MessageBox.Show("Impressora: " + comboInstalledPrinters.Text + " selecionada.");
            }

        }
        private void pictureBox1_Click(object sender, EventArgs e)
        {
            if (pictureBox1.BorderStyle == BorderStyle.Fixed3D)
            {                
                pictureBox1.BorderStyle = BorderStyle.None;
                //tabControl1.SelectedTab = tabPage1;
                label1.ForeColor = Color.Black;
                tabControl1.TabPages.Remove(tabPage1);
            }
            else
            {
               
                pictureBox1.BorderStyle = BorderStyle.Fixed3D;
                label1.ForeColor = Color.Red;
                tabControl1.TabPages.Add(tabPage1);
                tabControl1.SelectedTab = tabPage1;
                textBox6.Text = DateTime.Now.Month.ToString() + "/" + DateTime.Now.Year.ToString();
                textBox6.BackColor = Color.White;
                
                
            }
            

        }

        //String para informar reimpressão
        string informarNomes = "";
        private void Form1_Load(object sender, EventArgs e)
        {
            

            Global.Config.Texto = System.Globalization.DateTimeFormatInfo.CurrentInfo.GetMonthName(DateTime.Now.Date.Month).ToLower() + " de " + DateTime.Now.Date.Year.ToString();
            string mes = "";
            string a = DateTime.Now.Date.Year.ToString();

            if (DateTime.Now.Month == 1)
            {
                mes = "DEZEMBRO";
                a = Convert.ToString( Convert.ToInt32(a) - 1);
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
           
             TextObject txt3__ = (TextObject)rpt1.ReportDefinition.ReportObjects["Text3"]; //Instancie um objeto do tipo TextObject e informe o nome do textbox
             txt3__.Text = "Mês de " + mes + " de " + a;

             TextObject txt1__ = (TextObject)rpt2.ReportDefinition.ReportObjects["Text1"]; //Instancie um objeto do tipo TextObject e informe o nome do textbox
             txt1__.Text = "Mês de " + System.Globalization.DateTimeFormatInfo.CurrentInfo.GetMonthName(DateTime.Now.Date.Month).ToLower() + " de " + DateTime.Now.Date.Year.ToString();

            
            TextObject txt120 = (TextObject)rpt.ReportDefinition.ReportObjects["Text120"]; //Instancie um objeto do tipo TextObject e informe o nome do textbox
            txt120.Text = mes + " de " + a;

            TextObject txt186 = (TextObject)rpt.ReportDefinition.ReportObjects["Text186"]; //Instancie um objeto do tipo TextObject e informe o nome do textbox
            txt186.Text = mes + " de " + a;

            TextObject txt219 = (TextObject)rpt.ReportDefinition.ReportObjects["Text219"]; //Instancie um objeto do tipo TextObject e informe o nome do textbox
            txt219.Text = mes + " de " + a;

            TextObject txt252 = (TextObject)rpt.ReportDefinition.ReportObjects["Text252"]; //Instancie um objeto do tipo TextObject e informe o nome do textbox
            txt252.Text = mes + " de " + a;

            comboBox1.SelectedIndex = 0;

            //Sql local(local) ou IP(rede) 
            //**********************************
            //**********************************

            Global.Config.BancoDados = "rede";

            //**********************************
            //**********************************

            nomes = DAL.Lista_Mes_Atual();
            if (nomes.Rows.Count > 0)
            {
                this.Text += " --> Mês Atual: " + nomes.Rows[0]["Atual"].ToString();
                Global.Config.MesRegistro = nomes.Rows[0]["Atual"].ToString();
            }
            else
            {
                this.Text += " --> Mês Atual: Não Definido ";
            }

            ImageList iconsList = new ImageList();
            iconsList.TransparentColor = Color.Blue;
            iconsList.ColorDepth = ColorDepth.Depth32Bit;
            iconsList.ImageSize = new Size(25, 25);
            iconsList.Images.Add(Properties.Resources.calendario40);
            iconsList.Images.Add(Properties.Resources.Generate_tables_icon40);
            iconsList.Images.Add(Properties.Resources.orcamento40);
            iconsList.Images.Add(Properties.Resources.relat40);
            iconsList.Images.Add(Properties.Resources.icon_agua40);
            iconsList.Images.Add(Properties.Resources.Document_Add_icon40);
            iconsList.Images.Add(Properties.Resources.icone_2014_09_25_nossa_água40);
            //iconsList.Images.Add(Properties.Resources.imp);
            //iconsList.Images.Add(Properties.Resources.anot);
            //iconsList.Images.Add(Properties.Resources._10);
            //iconsList.Images.Add(Properties.Resources._11);
            
            
            tabControl1.ImageList = iconsList;
            tabPage1.ImageIndex = 0;
            tabPage2.ImageIndex = 1;
            tabPage3.ImageIndex = 2;
            tabPage4.ImageIndex = 3;
            tabPage5.ImageIndex = 4;
            tabPage6.ImageIndex = 5;
            tabPage7.ImageIndex = 6;
            //tabPage8.ImageIndex = 7;
            //tabPage9.ImageIndex = 8;
            

            tabControl1.TabPages.Remove(tabPage1);
            tabControl1.TabPages.Remove(tabPage2);
            tabControl1.TabPages.Remove(tabPage3);
            tabControl1.TabPages.Remove(tabPage4);
            tabControl1.TabPages.Remove(tabPage5);
            tabControl1.TabPages.Remove(tabPage6);
            tabControl1.TabPages.Remove(tabPage7);
            //tabControl1.TabPages.Remove(tabPage8);
            //tabControl1.TabPages.Remove(tabPage9);           
            

            // Create the ToolTip and associate with the Form container.
            ToolTip toolTip1 = new ToolTip();

            // Set up the delays for the ToolTip.
            toolTip1.AutoPopDelay = 3000;
            toolTip1.InitialDelay = 500;
            toolTip1.ReshowDelay = 500;
            // Force the ToolTip text to be displayed whether or not the form is active.
            toolTip1.ShowAlways = true;

            // Set up the ToolTip text for the Button and Checkbox.
            toolTip1.SetToolTip(this.pictureBox1, "Novo Mês");
            toolTip1.SetToolTip(this.pictureBox2, "Vencimento");
            toolTip1.SetToolTip(this.pictureBox3, "Recibos");
            toolTip1.SetToolTip(this.pictureBox4, "Relatório");
            toolTip1.SetToolTip(this.pictureBox5, "Leitura");
            toolTip1.SetToolTip(this.pictureBox22, "Configurações");
            toolTip1.SetToolTip(this.pictureBox10, "Cadastro");
            toolTip1.SetToolTip(this.pictureBox9, "Medição do Mês");
            toolTip1.SetToolTip(this.pictureBox8, "Sobre");
            
            //toolTip1.SetToolTip(this.pictureBox6, "Ordens de Compra");
            Form hello = new Hello();
            hello.ShowDialog();
            tabControl1.Visible = true;
            //toolTip1.SetToolTip(this.pictureBox15, "Notas Fiscais");

            //********************************************************************************
            //********************************************************************************

            
            

            if (pictureBox10.BorderStyle == BorderStyle.Fixed3D)
            {
                pictureBox10.BorderStyle = BorderStyle.None;
                //tabControl1.SelectedTab = tabPage1;
                label6.ForeColor = Color.Black;
                tabControl1.TabPages.Remove(tabPage6);
            }
            else
            {
                pictureBox10.BorderStyle = BorderStyle.Fixed3D;
                label6.ForeColor = Color.Red;
                tabControl1.TabPages.Add(tabPage6);
                tabControl1.SelectedTab = tabPage6;

                dataGridView4.DataSource = DAL.Lista_Ativo();
                if (dataGridView4.Rows.Count > 0)
                {
                    for (int i = 0; i < dataGridView4.Rows.Count; i++)
                    {
                        dataGridView4.Columns[0].Width = 200;
                        dataGridView4.Columns[1].Width = 50;
                        if (dataGridView4.Rows[i].Cells[2].Value.ToString() == "0")
                        {
                            dataGridView4.Rows[i].Cells[0].Style.BackColor = Color.White;
                            dataGridView4.Rows[i].Cells[1].Style.BackColor = Color.White;
                            dataGridView4.Rows[i].Cells[2].Style.BackColor = Color.White;
                        }
                        else
                        {
                            dataGridView4.Rows[i].Cells[0].Style.BackColor = Color.LightCyan;
                            dataGridView4.Rows[i].Cells[1].Style.BackColor = Color.LightCyan;
                            dataGridView4.Rows[i].Cells[2].Style.BackColor = Color.LightCyan;
                        }
                    }
                }
                // Set row labels.
                int rowNumber = 1;
                foreach (DataGridViewRow row in dataGridView4.Rows)
                {
                    if (row.IsNewRow) continue;
                    row.HeaderCell.Value = "" + rowNumber;
                    rowNumber = rowNumber + 1;
                }
                dataGridView4.AutoResizeRowHeadersWidth(DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders);
                textBox1.Focus();
                
            }

            //********************************************************************************
            //********************************************************************************

            //Carregar Relatório / Impressoras instaladas e padrão

            crystalReportViewer1.ReportSource = rpt;
            PopulateInstalledPrintersCombo();

            var configImpressora = new PrinterSettings();
            comboInstalledPrinters.Text = configImpressora.PrinterName;

            //********************************************************************************
            //********************************************************************************
            DataTable cs;
            cs = DAL.Lista_Nome();
           
            int consumo = 0;
            for (int i = 0; i < nomes.Rows.Count; i++)
            {               
                if (Convert.ToInt32(cs.Rows[i]["Atual"].ToString()) > 0)
                {                    
                    consumo += Convert.ToInt32(cs.Rows[i]["Atual"].ToString()) - Convert.ToInt32(cs.Rows[i]["Anterior"].ToString());
                }                
            }
            label27.Text = Convert.ToString(consumo);
            label16.Text = DateTime.Now.Year.ToString();

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            if (pictureBox2.BorderStyle == BorderStyle.Fixed3D)
            {
                pictureBox2.BorderStyle = BorderStyle.None;
                //tabControl1.SelectedTab = tabPage1;
                label2.ForeColor = Color.Black;
                tabControl1.TabPages.Remove(tabPage2);
            }
            else
            {
                pictureBox2.BorderStyle = BorderStyle.Fixed3D;
                label2.ForeColor = Color.Red;
                tabControl1.TabPages.Add(tabPage2);
                tabControl1.SelectedTab = tabPage2;
                nomes = DAL.Lista_Mes_Atual();
                if (nomes.Rows.Count > 0)
                {
                    label20.Text = nomes.Rows[0]["Atual"].ToString();   
                }
                else
                {
                    MessageBox.Show("Necessário abrir mês atual");
                    pictureBox2.BorderStyle = BorderStyle.None;
                    //tabControl1.SelectedTab = tabPage1;
                    label2.ForeColor = Color.Black;
                    tabControl1.TabPages.Remove(tabPage2);
                }
               
            }
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            

            if (pictureBox3.BorderStyle == BorderStyle.Fixed3D)
            {
                pictureBox3.BorderStyle = BorderStyle.None;
                //tabControl1.SelectedTab = tabPage1;
                label3.ForeColor = Color.Black;
                tabControl1.TabPages.Remove(tabPage3);
            }
            else
            {
                pictureBox3.BorderStyle = BorderStyle.Fixed3D;
                label3.ForeColor = Color.Red;
                tabControl1.TabPages.Add(tabPage3);
                tabControl1.SelectedTab = tabPage3;

                //pega config
                DataTable config1 = DAL.Lista_Config();
                //tabela de valores
                TextObject txt16 = (TextObject)rpt.ReportDefinition.ReportObjects["Text16"]; //Instancie um objeto do tipo TextObject e informe o nome do textbox
                txt16.Text = "Tabela para cálculo:\n" +
                            "Até 10 m³  -  R$ " + config1.Rows[0]["Valor_Base"].ToString() + "\n" +
                            "De   10 m³  a 30 m³ + R$ " + config1.Rows[0]["Dez_Trinta"].ToString() + " por m³\n" +
                            "De   30 m³  a 90 m³ + R$ " + config1.Rows[0]["Trinta_Noventa"].ToString() + " por m³\n" +
                            "Acima de  90 m³     + R$ " + config1.Rows[0]["Noventa"].ToString() + " por m³";

                TextObject txt160 = (TextObject)rpt.ReportDefinition.ReportObjects["Text160"]; //Instancie um objeto do tipo TextObject e informe o nome do textbox
                txt160.Text = "Tabela para cálculo:\n" +
                            "Até 10 m³  -  R$ " + config1.Rows[0]["Valor_Base"].ToString() + "\n" +
                            "De   10 m³  a 30 m³ + R$ " + config1.Rows[0]["Dez_Trinta"].ToString() + " por m³\n" +
                            "De   30 m³  a 90 m³ + R$ " + config1.Rows[0]["Trinta_Noventa"].ToString() + " por m³\n" +
                            "Acima de  90 m³     + R$ " + config1.Rows[0]["Noventa"].ToString() + " por m³";

                TextObject txt193 = (TextObject)rpt.ReportDefinition.ReportObjects["Text193"]; //Instancie um objeto do tipo TextObject e informe o nome do textbox
                txt193.Text = "Tabela para cálculo:\n" +
                            "Até 10 m³  -  R$ " + config1.Rows[0]["Valor_Base"].ToString() + "\n" +
                            "De   10 m³  a 30 m³ + R$ " + config1.Rows[0]["Dez_Trinta"].ToString() + " por m³\n" +
                            "De   30 m³  a 90 m³ + R$ " + config1.Rows[0]["Trinta_Noventa"].ToString() + " por m³\n" +
                            "Acima de  90 m³     + R$ " + config1.Rows[0]["Noventa"].ToString() + " por m³";

                TextObject txt226 = (TextObject)rpt.ReportDefinition.ReportObjects["Text226"]; //Instancie um objeto do tipo TextObject e informe o nome do textbox
                txt226.Text = "Tabela para cálculo:\n" +
                            "Até 10 m³  -  R$ " + config1.Rows[0]["Valor_Base"].ToString() + "\n" +
                            "De   10 m³  a 30 m³ + R$ " + config1.Rows[0]["Dez_Trinta"].ToString() + " por m³\n" +
                            "De   30 m³  a 90 m³ + R$ " + config1.Rows[0]["Trinta_Noventa"].ToString() + " por m³\n" +
                            "Acima de  90 m³     + R$ " + config1.Rows[0]["Noventa"].ToString() + " por m³";


                //Preparar campos do relatório
                TextObject txt120 = (TextObject)rpt.ReportDefinition.ReportObjects["Text120"]; //Instancie um objeto do tipo TextObject e informe o nome do textbox
                txt120.Text = "";
                TextObject txt256 = (TextObject)rpt.ReportDefinition.ReportObjects["Text256"]; //Instancie um objeto do tipo TextObject e informe o nome do textbox
                txt256.Text = "";
                TextObject txt110 = (TextObject)rpt.ReportDefinition.ReportObjects["Text110"]; //Instancie um objeto do tipo TextObject e informe o nome do textbox
                txt110.Text = "0";
                TextObject txt111 = (TextObject)rpt.ReportDefinition.ReportObjects["Text111"]; //Instancie um objeto do tipo TextObject e informe o nome do textbox
                txt111.Text = "0";
                TextObject txt112 = (TextObject)rpt.ReportDefinition.ReportObjects["Text112"]; //Instancie um objeto do tipo TextObject e informe o nome do textbox
                txt112.Text = "0";
                TextObject txt113 = (TextObject)rpt.ReportDefinition.ReportObjects["Text113"]; //Instancie um objeto do tipo TextObject e informe o nome do textbox
                txt113.Text = "0";
                TextObject txt114 = (TextObject)rpt.ReportDefinition.ReportObjects["Text114"]; //Instancie um objeto do tipo TextObject e informe o nome do textbox
                txt114.Text = "0";
                TextObject txt115 = (TextObject)rpt.ReportDefinition.ReportObjects["Text115"]; //Instancie um objeto do tipo TextObject e informe o nome do textbox
                txt115.Text = "0";
                TextObject txt116 = (TextObject)rpt.ReportDefinition.ReportObjects["Text116"]; //Instancie um objeto do tipo TextObject e informe o nome do textbox
                txt116.Text = "0";
                TextObject txt121 = (TextObject)rpt.ReportDefinition.ReportObjects["Text121"]; //Instancie um objeto do tipo TextObject e informe o nome do textbox
                txt121.Text = "";
                TextObject txt122 = (TextObject)rpt.ReportDefinition.ReportObjects["Text122"]; //Instancie um objeto do tipo TextObject e informe o nome do textbox
                txt122.Text = "";
                TextObject txt123 = (TextObject)rpt.ReportDefinition.ReportObjects["Text123"]; //Instancie um objeto do tipo TextObject e informe o nome do textbox
                txt123.Text = "";
                TextObject txt117 = (TextObject)rpt.ReportDefinition.ReportObjects["Text117"]; //Instancie um objeto do tipo TextObject e informe o nome do textbox
                txt117.Text = "0";
                TextObject txt118 = (TextObject)rpt.ReportDefinition.ReportObjects["Text118"]; //Instancie um objeto do tipo TextObject e informe o nome do textbox
                txt118.Text = "0";
                TextObject txt119 = (TextObject)rpt.ReportDefinition.ReportObjects["Text119"]; //Instancie um objeto do tipo TextObject e informe o nome do textbox
                txt119.Text = "0";

                TextObject txt186 = (TextObject)rpt.ReportDefinition.ReportObjects["Text186"]; //Instancie um objeto do tipo TextObject e informe o nome do textbox
                txt186.Text = "";
                TextObject txt257 = (TextObject)rpt.ReportDefinition.ReportObjects["Text257"]; //Instancie um objeto do tipo TextObject e informe o nome do textbox
                txt257.Text = "";
                TextObject txt176 = (TextObject)rpt.ReportDefinition.ReportObjects["Text176"]; //Instancie um objeto do tipo TextObject e informe o nome do textbox
                txt176.Text = "0";
                TextObject txt177 = (TextObject)rpt.ReportDefinition.ReportObjects["Text177"]; //Instancie um objeto do tipo TextObject e informe o nome do textbox
                txt177.Text = "0";
                TextObject txt178 = (TextObject)rpt.ReportDefinition.ReportObjects["Text178"]; //Instancie um objeto do tipo TextObject e informe o nome do textbox
                txt178.Text = "0";
                TextObject txt179 = (TextObject)rpt.ReportDefinition.ReportObjects["Text179"]; //Instancie um objeto do tipo TextObject e informe o nome do textbox
                txt179.Text = "0";
                TextObject txt180 = (TextObject)rpt.ReportDefinition.ReportObjects["Text180"]; //Instancie um objeto do tipo TextObject e informe o nome do textbox
                txt180.Text = "0";
                TextObject txt181 = (TextObject)rpt.ReportDefinition.ReportObjects["Text181"]; //Instancie um objeto do tipo TextObject e informe o nome do textbox
                txt181.Text = "0";
                TextObject txt182 = (TextObject)rpt.ReportDefinition.ReportObjects["Text182"]; //Instancie um objeto do tipo TextObject e informe o nome do textbox
                txt182.Text = "0";
                TextObject txt187 = (TextObject)rpt.ReportDefinition.ReportObjects["Text187"]; //Instancie um objeto do tipo TextObject e informe o nome do textbox
                txt187.Text = "";
                TextObject txt188 = (TextObject)rpt.ReportDefinition.ReportObjects["Text188"]; //Instancie um objeto do tipo TextObject e informe o nome do textbox
                txt188.Text = "";
                TextObject txt189 = (TextObject)rpt.ReportDefinition.ReportObjects["Text189"]; //Instancie um objeto do tipo TextObject e informe o nome do textbox
                txt189.Text = "";
                TextObject txt183 = (TextObject)rpt.ReportDefinition.ReportObjects["Text183"]; //Instancie um objeto do tipo TextObject e informe o nome do textbox
                txt183.Text = "0";
                TextObject txt184 = (TextObject)rpt.ReportDefinition.ReportObjects["Text184"]; //Instancie um objeto do tipo TextObject e informe o nome do textbox
                txt184.Text = "0";
                TextObject txt185 = (TextObject)rpt.ReportDefinition.ReportObjects["Text185"]; //Instancie um objeto do tipo TextObject e informe o nome do textbox
                txt185.Text = "0";


                TextObject txt219 = (TextObject)rpt.ReportDefinition.ReportObjects["Text219"]; //Instancie um objeto do tipo TextObject e informe o nome do textbox
                txt219.Text = "";
                TextObject txt258 = (TextObject)rpt.ReportDefinition.ReportObjects["Text258"]; //Instancie um objeto do tipo TextObject e informe o nome do textbox
                txt258.Text = "";
                TextObject txt209 = (TextObject)rpt.ReportDefinition.ReportObjects["Text209"]; //Instancie um objeto do tipo TextObject e informe o nome do textbox
                txt209.Text = "0";
                TextObject txt210 = (TextObject)rpt.ReportDefinition.ReportObjects["Text210"]; //Instancie um objeto do tipo TextObject e informe o nome do textbox
                txt210.Text = "0";
                TextObject txt211 = (TextObject)rpt.ReportDefinition.ReportObjects["Text211"]; //Instancie um objeto do tipo TextObject e informe o nome do textbox
                txt211.Text = "0";
                TextObject txt212 = (TextObject)rpt.ReportDefinition.ReportObjects["Text212"]; //Instancie um objeto do tipo TextObject e informe o nome do textbox
                txt212.Text = "0";
                TextObject txt213 = (TextObject)rpt.ReportDefinition.ReportObjects["Text213"]; //Instancie um objeto do tipo TextObject e informe o nome do textbox
                txt213.Text = "0";
                TextObject txt214 = (TextObject)rpt.ReportDefinition.ReportObjects["Text214"]; //Instancie um objeto do tipo TextObject e informe o nome do textbox
                txt214.Text = "0";
                TextObject txt215 = (TextObject)rpt.ReportDefinition.ReportObjects["Text215"]; //Instancie um objeto do tipo TextObject e informe o nome do textbox
                txt215.Text = "0";
                TextObject txt220 = (TextObject)rpt.ReportDefinition.ReportObjects["Text220"]; //Instancie um objeto do tipo TextObject e informe o nome do textbox
                txt220.Text = "";
                TextObject txt221 = (TextObject)rpt.ReportDefinition.ReportObjects["Text221"]; //Instancie um objeto do tipo TextObject e informe o nome do textbox
                txt221.Text = "";
                TextObject txt222 = (TextObject)rpt.ReportDefinition.ReportObjects["Text222"]; //Instancie um objeto do tipo TextObject e informe o nome do textbox
                txt222.Text = "";
                TextObject txt216 = (TextObject)rpt.ReportDefinition.ReportObjects["Text216"]; //Instancie um objeto do tipo TextObject e informe o nome do textbox
                txt216.Text = "0";
                TextObject txt217 = (TextObject)rpt.ReportDefinition.ReportObjects["Text217"]; //Instancie um objeto do tipo TextObject e informe o nome do textbox
                txt217.Text = "0";
                TextObject txt218 = (TextObject)rpt.ReportDefinition.ReportObjects["Text218"]; //Instancie um objeto do tipo TextObject e informe o nome do textbox
                txt218.Text = "0";


                TextObject txt252 = (TextObject)rpt.ReportDefinition.ReportObjects["Text252"]; //Instancie um objeto do tipo TextObject e informe o nome do textbox
                txt252.Text = "";
                TextObject txt259 = (TextObject)rpt.ReportDefinition.ReportObjects["Text259"]; //Instancie um objeto do tipo TextObject e informe o nome do textbox
                txt259.Text = "";
                TextObject txt242 = (TextObject)rpt.ReportDefinition.ReportObjects["Text242"]; //Instancie um objeto do tipo TextObject e informe o nome do textbox
                txt242.Text = "0";
                TextObject txt243 = (TextObject)rpt.ReportDefinition.ReportObjects["Text243"]; //Instancie um objeto do tipo TextObject e informe o nome do textbox
                txt243.Text = "0";
                TextObject txt244 = (TextObject)rpt.ReportDefinition.ReportObjects["Text244"]; //Instancie um objeto do tipo TextObject e informe o nome do textbox
                txt244.Text = "0";
                TextObject txt245 = (TextObject)rpt.ReportDefinition.ReportObjects["Text245"]; //Instancie um objeto do tipo TextObject e informe o nome do textbox
                txt245.Text = "0";
                TextObject txt246 = (TextObject)rpt.ReportDefinition.ReportObjects["Text246"]; //Instancie um objeto do tipo TextObject e informe o nome do textbox
                txt246.Text = "0";
                TextObject txt247 = (TextObject)rpt.ReportDefinition.ReportObjects["Text247"]; //Instancie um objeto do tipo TextObject e informe o nome do textbox
                txt247.Text = "0";
                TextObject txt248 = (TextObject)rpt.ReportDefinition.ReportObjects["Text248"]; //Instancie um objeto do tipo TextObject e informe o nome do textbox
                txt248.Text = "0";
                TextObject txt253 = (TextObject)rpt.ReportDefinition.ReportObjects["Text253"]; //Instancie um objeto do tipo TextObject e informe o nome do textbox
                txt253.Text = "";
                TextObject txt254 = (TextObject)rpt.ReportDefinition.ReportObjects["Text254"]; //Instancie um objeto do tipo TextObject e informe o nome do textbox
                txt254.Text = "";
                TextObject txt255 = (TextObject)rpt.ReportDefinition.ReportObjects["Text255"]; //Instancie um objeto do tipo TextObject e informe o nome do textbox
                txt255.Text = "";
                TextObject txt249 = (TextObject)rpt.ReportDefinition.ReportObjects["Text249"]; //Instancie um objeto do tipo TextObject e informe o nome do textbox
                txt249.Text = "0";
                TextObject txt250 = (TextObject)rpt.ReportDefinition.ReportObjects["Text250"]; //Instancie um objeto do tipo TextObject e informe o nome do textbox
                txt250.Text = "0";
                TextObject txt251 = (TextObject)rpt.ReportDefinition.ReportObjects["Text251"]; //Instancie um objeto do tipo TextObject e informe o nome do textbox
                txt251.Text = "0";



                

            }
            
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            if (pictureBox4.BorderStyle == BorderStyle.Fixed3D)
            {
                pictureBox4.BorderStyle = BorderStyle.None;
                //tabControl1.SelectedTab = tabPage1;
                label4.ForeColor = Color.Black;
                tabControl1.TabPages.Remove(tabPage4);
            }
            else
            {
                pictureBox4.BorderStyle = BorderStyle.Fixed3D;
                label4.ForeColor = Color.Red;
                tabControl1.TabPages.Add(tabPage4);
                tabControl1.SelectedTab = tabPage4;
                DataTable mes = DAL.Lista_Mes_Atual();
                if (mes.Rows.Count > 0)
                {
                    dataGridView2.DataSource = DAL.Lista_Relatorio3(mes.Rows[0]["Atual"].ToString());
                    for (int i = 0; i < dataGridView2.Rows.Count; i++)
                    {
                        //definir tamanho das colunas do DataGrid
                        dataGridView2.Columns[0].Width = 150;
                        dataGridView2.Columns[1].Width = 35;
                        dataGridView2.Columns[2].Width = 35;
                        dataGridView2.Columns[3].Width = 35;
                        dataGridView2.Columns[4].Width = 50;
                        dataGridView2.Columns[5].Width = 35;
                        dataGridView2.Columns[6].Width = 35;
                        dataGridView2.Columns[7].Width = 50;
                        dataGridView2.Columns[8].Width = 35;
                        dataGridView2.Columns[9].Width = 35;
                        dataGridView2.Columns[10].Width = 100;


                        dataGridView2.Rows[i].Cells[7].Style.Font = new Font(dataGridView2.Font, FontStyle.Bold);
                        dataGridView2.Rows[i].Cells[3].Style.Font = new Font(dataGridView2.Font, FontStyle.Bold);
                        dataGridView2.Rows[i].Cells[4].Style.Font = new Font(dataGridView2.Font, FontStyle.Bold);
                        //dataGridView2.Rows[i].Cells[10].Value = "";
                        dataGridView2.Rows[i].Cells[1].Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                        dataGridView2.Rows[i].Cells[2].Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                        dataGridView2.Rows[i].Cells[3].Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                        dataGridView2.Rows[i].Cells[4].Style.Alignment = DataGridViewContentAlignment.MiddleRight;
                        dataGridView2.Rows[i].Cells[5].Style.Alignment = DataGridViewContentAlignment.MiddleRight;
                        dataGridView2.Rows[i].Cells[6].Style.Alignment = DataGridViewContentAlignment.MiddleRight;
                        dataGridView2.Rows[i].Cells[7].Style.Alignment = DataGridViewContentAlignment.MiddleRight;
                        dataGridView2.Rows[i].Cells[8].Style.Alignment = DataGridViewContentAlignment.MiddleRight;
                        dataGridView2.Rows[i].Cells[9].Style.Alignment = DataGridViewContentAlignment.MiddleRight;
                        dataGridView2.Rows[i].Cells[10].Style.Alignment = DataGridViewContentAlignment.MiddleRight;
                    }
                    
                }
                else
                {
                    dataGridView2.DataSource = DAL.Lista_Relatorio3("mes");
                }
                

            }
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            if (pictureBox5.BorderStyle == BorderStyle.Fixed3D)
            {
                pictureBox5.BorderStyle = BorderStyle.None;
                //tabControl1.SelectedTab = tabPage1;
                label5.ForeColor = Color.Black;
                tabControl1.TabPages.Remove(tabPage5);
            }
            else
            {
                pictureBox5.BorderStyle = BorderStyle.Fixed3D;
                label5.ForeColor = Color.Red;
                tabControl1.TabPages.Add(tabPage5);
                tabControl1.SelectedTab = tabPage5;
                dataGridView1.DataSource = DAL.Lista_Leitura2();
                for (int i = 0; i < dataGridView1.Rows.Count; i++)
                {
                    dataGridView1.Rows[i].Cells[2].Value = "";
                }
                
            }
        }

        private void pictureBox10_Click(object sender, EventArgs e)
        {
            
            if (pictureBox10.BorderStyle == BorderStyle.Fixed3D)
            {
                pictureBox10.BorderStyle = BorderStyle.None;
                //tabControl1.SelectedTab = tabPage1;
                label6.ForeColor = Color.Black;
                tabControl1.TabPages.Remove(tabPage6);
            }
            else
            {
                pictureBox10.BorderStyle = BorderStyle.Fixed3D;
                label6.ForeColor = Color.Red;
                tabControl1.TabPages.Add(tabPage6);
                tabControl1.SelectedTab = tabPage6;

                dataGridView4.DataSource = DAL.Lista_Ativo();
                if (dataGridView4.Rows.Count > 0)
                {
                    for (int i = 0; i < dataGridView4.Rows.Count; i++)
                    {
                        dataGridView4.Columns[0].Width = 200;
                        dataGridView4.Columns[1].Width = 50;
                        if (dataGridView4.Rows[i].Cells[2].Value.ToString() == "0")
                        {
                            dataGridView4.Rows[i].Cells[0].Style.BackColor = Color.White;
                            dataGridView4.Rows[i].Cells[1].Style.BackColor = Color.White;
                            dataGridView4.Rows[i].Cells[2].Style.BackColor = Color.White;
                        }
                        else
                        {
                            dataGridView4.Rows[i].Cells[0].Style.BackColor = Color.LightCyan;
                            dataGridView4.Rows[i].Cells[1].Style.BackColor = Color.LightCyan;
                            dataGridView4.Rows[i].Cells[2].Style.BackColor = Color.LightCyan;
                        }
                    }
                }
                // Set row labels.
                int rowNumber = 1;
                foreach (DataGridViewRow row in dataGridView4.Rows)
                {
                    if (row.IsNewRow) continue;
                    row.HeaderCell.Value = "" + rowNumber;
                    rowNumber = rowNumber + 1;
                }
                dataGridView4.AutoResizeRowHeadersWidth(DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders);    
                
                textBox1.Focus();               

            }
        }

       

        private void pictureBox9_Click(object sender, EventArgs e)
        {
            if (pictureBox9.BorderStyle == BorderStyle.Fixed3D)
            {
                pictureBox9.BorderStyle = BorderStyle.None;
                //tabControl1.SelectedTab = tabPage1;
                label7.ForeColor = Color.Black;
                tabControl1.TabPages.Remove(tabPage7);
            }
            else
            {
                pictureBox9.BorderStyle = BorderStyle.Fixed3D;
                label7.ForeColor = Color.Red;
                tabControl1.TabPages.Add(tabPage7);
                tabControl1.SelectedTab = tabPage7;
                DataTable mes = DAL.Lista_Mes_Atual();
                if (mes.Rows.Count > 0)
                {
                    dataGridView3.DataSource = DAL.Lista_Medição2();
                    dataGridView3.Columns[0].Width = 350;
                    dataGridView3.Columns[1].Width = 100;
                    dataGridView3.Columns[1].DefaultCellStyle.Alignment = DataGridViewContentAlignment.TopCenter;
                    
                    dataGridView3.Columns[2].Width = 100;
                    dataGridView3.Columns[2].DefaultCellStyle.Alignment = DataGridViewContentAlignment.TopRight;
                    dataGridView3.Columns[3].Width = 100;
                    dataGridView3.Columns[3].DefaultCellStyle.Alignment = DataGridViewContentAlignment.TopRight;
                    dataGridView3.Columns[4].Width = 500;
                }
                else
                {
                    dataGridView3.DataSource = DAL.Lista_Medição2();
                    dataGridView3.Columns[0].Width = 350;
                    dataGridView3.Columns[1].Width = 100;
                    dataGridView3.Columns[1].DefaultCellStyle.Alignment = DataGridViewContentAlignment.TopCenter;

                    dataGridView3.Columns[2].Width = 100;
                    dataGridView3.Columns[2].DefaultCellStyle.Alignment = DataGridViewContentAlignment.TopRight;
                    dataGridView3.Columns[3].Width = 100;
                    dataGridView3.Columns[3].DefaultCellStyle.Alignment = DataGridViewContentAlignment.TopRight;
                    dataGridView3.Columns[4].Width = 500;
                }                
               
            }
        }

        private void pictureBox8_Click(object sender, EventArgs e)
        {
            label8.ForeColor = Color.Red;
            Form sobre = new Sobre();
            sobre.ShowDialog();
            label8.ForeColor = Color.Black;
        }

        private void pictureBox7_Click(object sender, EventArgs e)
        {
            
        }

        

       

      
        private void servidoresToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (pictureBox1.BorderStyle == BorderStyle.Fixed3D)
            {
                tabControl1.SelectedTab = tabPage1;
            }
            else
            {
                pictureBox1.BorderStyle = BorderStyle.Fixed3D;
                tabControl1.TabPages.Add(tabPage1);
                tabControl1.SelectedTab = tabPage1;
                

            }
        }

        private void computadoresReservaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (pictureBox2.BorderStyle == BorderStyle.Fixed3D)
            {
                tabControl1.SelectedTab = tabPage2;
            }
            else
            {
                pictureBox2.BorderStyle = BorderStyle.Fixed3D;
                tabControl1.TabPages.Add(tabPage2);
                tabControl1.SelectedTab = tabPage2;
                
            }
        }

        private void roteadoresToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (pictureBox3.BorderStyle == BorderStyle.Fixed3D)
            {
                tabControl1.SelectedTab = tabPage3;
            }
            else
            {
                pictureBox3.BorderStyle = BorderStyle.Fixed3D;
                tabControl1.TabPages.Add(tabPage3);
                tabControl1.SelectedTab = tabPage3;
                
            }
        }

        private void reservaReposiçãoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (pictureBox4.BorderStyle == BorderStyle.Fixed3D)
            {
                tabControl1.SelectedTab = tabPage4;
            }
            else
            {
                pictureBox4.BorderStyle = BorderStyle.Fixed3D;
                tabControl1.TabPages.Add(tabPage4);
                tabControl1.SelectedTab = tabPage4;
                
            }
        }

        private void webSiteArtChikToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (pictureBox5.BorderStyle == BorderStyle.Fixed3D)
            {
                tabControl1.SelectedTab = tabPage5;
            }
            else
            {
                pictureBox5.BorderStyle = BorderStyle.Fixed3D;
                tabControl1.TabPages.Add(tabPage5);
                tabControl1.SelectedTab = tabPage5;
               
            }
        }

        private void googleSuiteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (pictureBox10.BorderStyle == BorderStyle.Fixed3D)
            {
                tabControl1.SelectedTab = tabPage6;
            }
            else
            {
                pictureBox10.BorderStyle = BorderStyle.Fixed3D;
                tabControl1.TabPages.Add(tabPage6);
                tabControl1.SelectedTab = tabPage6;
                
            }
        }

        private void softwaresOriginaisToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (pictureBox9.BorderStyle == BorderStyle.Fixed3D)
            {
                tabControl1.SelectedTab = tabPage7;
            }
            else
            {
                pictureBox9.BorderStyle = BorderStyle.Fixed3D;
                tabControl1.TabPages.Add(tabPage7);
                tabControl1.SelectedTab = tabPage7;
               
            }
        }

        private void listaDeImpressorasToolStripMenuItem_Click(object sender, EventArgs e)
        {
           
        }

        private void anotaçõesDiversasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
        }

        private void sobreToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
        }

        private void tabPage8_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_MouseEnter(object sender, EventArgs e)
        {

        }

        private void pictureBox1_MouseLeave(object sender, EventArgs e)
        {

        }

        private void pictureBox2_MouseEnter(object sender, EventArgs e)
        {
            if (pictureBox2.BorderStyle == BorderStyle.None)
            {
                label2.ForeColor = Color.Red;
                
            }
            
        }

        private void pictureBox2_MouseLeave(object sender, EventArgs e)
        {
            if (pictureBox2.BorderStyle == BorderStyle.None)
            {
                label2.ForeColor = Color.Black;
               
            }
            
        }

        private void pictureBox3_MouseEnter(object sender, EventArgs e)
        {
            if (pictureBox3.BorderStyle == BorderStyle.None)
            {
                label3.ForeColor = Color.Red;
                
            }
        }

        private void pictureBox3_MouseLeave(object sender, EventArgs e)
        {
            if (pictureBox3.BorderStyle == BorderStyle.None)
            {
                label3.ForeColor = Color.Black;
                
            }
        }

        private void pictureBox4_MouseEnter(object sender, EventArgs e)
        {
            if (pictureBox4.BorderStyle == BorderStyle.None)
            {
                label4.ForeColor = Color.Red;
                
            }
        }

        private void pictureBox4_MouseLeave(object sender, EventArgs e)
        {
            if (pictureBox4.BorderStyle == BorderStyle.None)
            {
                label4.ForeColor = Color.Black;
                
            }
        }

        private void pictureBox5_MouseEnter(object sender, EventArgs e)
        {
            if (pictureBox5.BorderStyle == BorderStyle.None)
            {
                label5.ForeColor = Color.Red;
                
            }
        }

        private void pictureBox5_MouseLeave(object sender, EventArgs e)
        {
            if (pictureBox5.BorderStyle == BorderStyle.None)
            {
                label5.ForeColor = Color.Black;
                
            }
        }

        private void pictureBox10_MouseEnter(object sender, EventArgs e)
        {
            if (pictureBox10.BorderStyle == BorderStyle.None)
            {
                label6.ForeColor = Color.Red;
                
            }
        }

        private void pictureBox10_MouseLeave(object sender, EventArgs e)
        {
            if (pictureBox10.BorderStyle == BorderStyle.None)
            {
                label6.ForeColor = Color.Black;
               
            }
        }

        private void pictureBox9_MouseEnter(object sender, EventArgs e)
        {
            if (pictureBox9.BorderStyle == BorderStyle.None)
            {
                label7.ForeColor = Color.Red;
               
            }
        }

        private void pictureBox9_MouseLeave(object sender, EventArgs e)
        {
            if (pictureBox9.BorderStyle == BorderStyle.None)
            {
                label7.ForeColor = Color.Black;
                
            }
        }

        private void pictureBox8_MouseEnter(object sender, EventArgs e)
        {
            label8.ForeColor = Color.Red;
           
        }

        private void pictureBox8_MouseLeave(object sender, EventArgs e)
        {
            label8.ForeColor = Color.Black;
            
        }

        private void textBox1_Enter(object sender, EventArgs e)
        {
            pictureBox7.Visible = true;
            textBox1.BackColor = Color.Cyan;
            label9.ForeColor = Color.Red;

            button28.Visible = false;
            button1.Visible = true;
            button2.Visible = true;
            button27.Visible = false;
        }

        private void textBox1_Leave(object sender, EventArgs e)
        {
            pictureBox7.Visible = false;
            textBox1.BackColor = Color.White;
            label9.ForeColor = Color.Black;
        }

        private void textBox2_Enter(object sender, EventArgs e)
        {
            pictureBox11.Visible = true;
            textBox2.BackColor = Color.Cyan;
            label10.ForeColor = Color.Red;

            button28.Visible = false;
            button1.Visible = true;
            button2.Visible = true;
            button27.Visible = false;
        }

        private void textBox2_Leave(object sender, EventArgs e)
        {
            pictureBox11.Visible = false;
            textBox2.BackColor = Color.White;
            label10.ForeColor = Color.Black;
        }

        private void textBox3_Enter(object sender, EventArgs e)
        {
            pictureBox12.Visible = true;
            textBox3.BackColor = Color.Cyan;
            label11.ForeColor = Color.Red;

            button28.Visible = false;
            button1.Visible = true;
            button2.Visible = true;
            button27.Visible = false;
        }

        private void textBox3_Leave(object sender, EventArgs e)
        {
            pictureBox12.Visible = false;
            textBox3.BackColor = Color.White;
            label11.ForeColor = Color.Black;
        }

        private void textBox4_Enter(object sender, EventArgs e)
        {
            pictureBox13.Visible = true;
            textBox4.BackColor = Color.Cyan;
            label12.ForeColor = Color.Red;

            button28.Visible = true;
            button1.Visible = false;
            button2.Visible = false;
            button27.Visible = true;
        }

        private void textBox4_Leave(object sender, EventArgs e)
        {
            pictureBox13.Visible = false;
            textBox4.BackColor = Color.White;
            label12.ForeColor = Color.Black;

            
        }

        private void textBox5_Enter(object sender, EventArgs e)
        {
            pictureBox14.Visible = true;
            textBox5.BackColor = Color.Cyan;
            label13.ForeColor = Color.Red;

            button28.Visible = false;
            button1.Visible = true;
            button2.Visible = true;
            button27.Visible = false;
        }

        private void textBox5_Leave(object sender, EventArgs e)
        {
            pictureBox14.Visible = false;
            textBox5.BackColor = Color.White;
            label13.ForeColor = Color.Black;
        }

        private void richTextBox1_Enter(object sender, EventArgs e)
        {
            pictureBox15.Visible = true;
            richTextBox1.BackColor = Color.Cyan;
            label14.ForeColor = Color.Red;

            button28.Visible = false;
            button1.Visible = true;
            button2.Visible = true;
            button27.Visible = false;
        }

        private void richTextBox1_Leave(object sender, EventArgs e)
        {
            pictureBox15.Visible = false;
            richTextBox1.BackColor = Color.White;
            label14.ForeColor = Color.Black;
        }

        private void pictureBox16_MouseEnter(object sender, EventArgs e)
        {
            pictureBox16.Width = 45;
            pictureBox16.Height = 45;
            this.Cursor = Cursors.Hand;
            
        }

        private void pictureBox16_MouseLeave(object sender, EventArgs e)
        {
            pictureBox16.Width = 40;
            pictureBox16.Height = 40;
            Cursor = Cursors.Default;
        }

        private void pictureBox17_MouseEnter(object sender, EventArgs e)
        {
            pictureBox17.Width = 45;
            pictureBox17.Height = 45;
            Cursor = Cursors.Hand;
        }

        private void pictureBox17_MouseLeave(object sender, EventArgs e)
        {
            pictureBox17.Width = 40;
            pictureBox17.Height = 40;
           /* if (progressBar1.Width >= 112)
            {
                progressBar1.Width = 106;
            }*/
            Cursor = Cursors.Default;
        }

        private void pictureBox16_Click(object sender, EventArgs e)
        {
            int linha = 0;
            if (String.IsNullOrEmpty(label19.Text) == false)
            {
                nomes = DAL.Lista_Nome();
                
                for (int i = 0; i < nomes.Rows.Count; i++)
                {
                    if (nomes.Rows[i]["Id"].ToString() == label19.Text)
                    {
                        if (i - 1 < 0)
                        {
                            MessageBox.Show("Primeiro cadastro");
                            return;
                        }
                        
                        //progressBar1.Width = progressBar1.Width + 6;
                        label19.Text = nomes.Rows[i - 1]["Id"].ToString();
                        textBox1.Text = nomes.Rows[i - 1]["Nome"].ToString();
                        textBox2.Text = nomes.Rows[i - 1]["Anterior"].ToString();
                        textBox3.Text = nomes.Rows[i - 1]["Atual"].ToString();
                        textBox5.Text = nomes.Rows[i - 1]["Atraso"].ToString();
                        richTextBox1.Text = nomes.Rows[i - 1]["Observação"].ToString();
                        comboBox1.Text = nomes.Rows[i - 1]["TX_Comercial"].ToString();
                        DataTable pag = DAL.Pagou_Id_Lista(Convert.ToInt32(label19.Text));
                        if (pag.Rows.Count > 0)
                        {
                            label30.Text = "Pagamento Efetuado para Mês Atual";
                        }
                        if (pag.Rows.Count <= 0)
                        {
                            label30.Text = "";
                        }

                        //Mudar linha nomes
                        linha = dataGridView4.CurrentRow.Index;

                        linha--;

                        dataGridView4.CurrentCell = dataGridView4.Rows[linha].Cells[0];
                        textBox3.Focus();
                        if (!String.IsNullOrEmpty(textBox3.Text))
                        {
                            textBox3.SelectionStart = 0;
                            textBox3.SelectionLength = textBox3.Text.Length;
                        }
                        timer1.Enabled = true;
                        Cursor = Cursors.WaitCursor;
                        return;
                    }

                }
            }
                       
        }

        private void pictureBox17_Click(object sender, EventArgs e)
        {
            int linha = 0;
            if (String.IsNullOrEmpty(label19.Text) == true)
            {
                timer1.Enabled = true;
                Cursor = Cursors.WaitCursor;
                //progressBar1.Width = progressBar1.Width + 6;
                nomes = DAL.Lista_Nome();
                if (nomes.Rows.Count > 0)
                {
                    label19.Text = nomes.Rows[0]["Id"].ToString();
                    textBox1.Text = nomes.Rows[0]["Nome"].ToString();
                    textBox2.Text = nomes.Rows[0]["Anterior"].ToString();
                    textBox3.Text = nomes.Rows[0]["Atual"].ToString();
                    textBox5.Text = nomes.Rows[0]["Atraso"].ToString();
                    richTextBox1.Text = nomes.Rows[0]["Observação"].ToString();
                    comboBox1.Text = nomes.Rows[0]["TX_Comercial"].ToString();

                    DataTable pag = DAL.Pagou_Id_Lista(Convert.ToInt32( label19.Text) );
                    if (pag.Rows.Count > 0)
                    {
                        label30.Text = "Pagamento Efetuado para Mês Atual";
                    }
                    if (pag.Rows.Count <= 0)
                    {
                        label30.Text = "";
                    }
                    
                }
                textBox3.Focus();
                if (!String.IsNullOrEmpty(textBox3.Text))
                {
                    textBox3.SelectionStart = 0;
                    textBox3.SelectionLength = textBox3.Text.Length;
                }

            }
            else
            {
                
                nomes = DAL.Lista_Nome();
                
                for (int i = 0; i < nomes.Rows.Count; i++)
                {
                    if (nomes.Rows[i]["Id"].ToString() == label19.Text)
                    {
                        if (i + 1 == nomes.Rows.Count)
                        {
                            MessageBox.Show("Último cadastro");
                            return;
                        }
                        
                        //progressBar1.Width = progressBar1.Width + 6;
                        label19.Text = nomes.Rows[i + 1]["Id"].ToString();
                        textBox1.Text = nomes.Rows[i + 1]["Nome"].ToString();
                        textBox2.Text = nomes.Rows[i + 1]["Anterior"].ToString();
                        textBox3.Text = nomes.Rows[i + 1]["Atual"].ToString();
                        textBox5.Text = nomes.Rows[i + 1]["Atraso"].ToString();
                        richTextBox1.Text = nomes.Rows[i + 1]["Observação"].ToString();
                        comboBox1.Text = nomes.Rows[i + 1]["TX_Comercial"].ToString();
                        DataTable pag = DAL.Pagou_Id_Lista(Convert.ToInt32(label19.Text));
                        if (pag.Rows.Count > 0)
                        {
                            label30.Text = "Pagamento Efetuado para Mês Atual";
                        }
                        if (pag.Rows.Count <= 0)
                        {
                            label30.Text = "";
                        }

                        linha = dataGridView4.CurrentRow.Index;

                        linha++;

                        dataGridView4.CurrentCell = dataGridView4.Rows[linha].Cells[0];
                        textBox3.Focus();
                        if (!String.IsNullOrEmpty(textBox3.Text))
                        {
                            textBox3.SelectionStart = 0;
                            textBox3.SelectionLength = textBox3.Text.Length;
                        }
                        timer1.Enabled = true;
                        Cursor = Cursors.WaitCursor;
                        return;
                    }
                    
                }
            }
            
        }
        int contador = 0;
        private void timer1_Tick(object sender, EventArgs e)
        {

            //progressBar1.Visible = true;
            //progressBar1.PerformStep();
            
            if (contador == 3)
            {
                contador = 0;
                //progressBar1.Value = 0;
                //progressBar1.Visible = false;
                if (Cursor == Cursors.Hand)
                {
                    Cursor = Cursors.Default;
                }
                if(Cursor == Cursors.WaitCursor)
                {
                    Cursor = Cursors.Hand;
                }
                /*if (progressBar1.Width >= 112)
                {
                    progressBar1.Width = 106;
                }*/
                timer1.Enabled = false;
            }
            contador++;
        }

        private void pictureBox18_MouseEnter(object sender, EventArgs e)
        {
            pictureBox18.Width = 45;
            pictureBox18.Height = 45;
            Cursor = Cursors.Hand;
        }

        private void pictureBox18_MouseLeave(object sender, EventArgs e)
        {
            pictureBox18.Width = 40;
            pictureBox18.Height = 40;           
            Cursor = Cursors.Default;
        }

        private void pictureBox18_Click(object sender, EventArgs e)
        {
            label19.Text = "";
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
            textBox5.Text = "";
            richTextBox1.Text = "";
            comboBox1.Text = "";
            textBox1.Focus();
            /*timer3.Enabled = true;
            Form proc = new Procurar();
            proc.ShowDialog();
            timer3.Enabled = false;*/
        }

        private void monthCalendar1_DateChanged(object sender, DateRangeEventArgs e)
        {
            
        }

        private void textBox6_Enter(object sender, EventArgs e)
        {
            textBox6.BackColor = Color.Cyan;
        }

        private void textBox6_Leave(object sender, EventArgs e)
        {
            textBox6.BackColor = Color.White;
        }

        private void button15_Click(object sender, EventArgs e)
        {
            if ( Convert.ToInt32(label16.Text) <= Convert.ToInt32(DateTime.Now.Year.ToString()))
            {
                MessageBox.Show("Data incorreta");
            }
            else
            {
                label16.Text = Convert.ToString(Convert.ToInt32(label16.Text) - 1);
            }
        }

        private void button16_Click(object sender, EventArgs e)
        {
            if (Convert.ToInt32(DateTime.Now.Month) < 12)
            {
                MessageBox.Show("Disponível somente para\n  o mês de Dezembro");
                return;
            }
            if (Convert.ToInt32(label16.Text) + 1 > Convert.ToInt32(DateTime.Now.Year.ToString()) + 1)
            {
                MessageBox.Show("Data incorreta");
                return;
            }      
           label16.Text = Convert.ToString(Convert.ToInt32(label16.Text) + 1);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            
            textBox6.Text = "1/" + label16.Text;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            
            textBox6.Text = "2/" + label16.Text;
        }

        private void button6_Click(object sender, EventArgs e)
        {
            
            textBox6.Text = "3/" + label16.Text;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            textBox6.Text = "4/" + label16.Text;
        }

        private void button10_Click(object sender, EventArgs e)
        {
            textBox6.Text = "5/" + label16.Text;
        }

        private void button9_Click(object sender, EventArgs e)
        {
            textBox6.Text = "6/" + label16.Text;
        }

        private void button8_Click(object sender, EventArgs e)
        {
            textBox6.Text = "7/" + label16.Text;
        }

        private void button7_Click(object sender, EventArgs e)
        {
            textBox6.Text = "8/" + label16.Text;
        }

        private void button14_Click(object sender, EventArgs e)
        {
            textBox6.Text = "9/" + label16.Text;
        }

        private void button13_Click(object sender, EventArgs e)
        {
            textBox6.Text = "10/" + label16.Text;
        }

        private void button12_Click(object sender, EventArgs e)
        {
            textBox6.Text = "11/" + label16.Text;
        }

        private void button11_Click(object sender, EventArgs e)
        {
            textBox6.Text = "12/" + label16.Text;
        }

        private void button18_Click(object sender, EventArgs e)
        {
            pictureBox10.BorderStyle = BorderStyle.None;
            //tabControl1.SelectedTab = tabPage1;
            label6.ForeColor = Color.Black;
            tabControl1.TabPages.Remove(tabPage6);
        }

        private void button19_Click(object sender, EventArgs e)
        {
            pictureBox1.BorderStyle = BorderStyle.None;
            //tabControl1.SelectedTab = tabPage1;
            label1.ForeColor = Color.Black;
            tabControl1.TabPages.Remove(tabPage1);
        }
        int ampu = 0;
        private void timer2_Tick(object sender, EventArgs e)
        {
            Cursor = Cursors.WaitCursor;
            pictureBox20.Visible = true;
            pictureBox21.Visible = true;
            pictureBox24.Visible = true;
            ampu++;
            if (ampu == 3)
            {
                ampu = 0;
                pictureBox20.Visible = false;
                pictureBox21.Visible = false;
                pictureBox24.Visible = false;
                Cursor = Cursors.Default;
                timer2.Enabled = false;
                //MessageBox.Show("Incluído com sucesso");
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
            string tm = DateTime.Now.Month.ToString() + "/" + DateTime.Now.Year.ToString();
            
            if (tm != Global.Config.MesRegistro.ToString())
            {
                MessageBox.Show("Mês de cobrança definido para: " + Global.Config.MesRegistro.ToString() +
                ".\nÉ necessário a abertura de um novo mês antes de lançar o consumo atual.", "Mês", MessageBoxButtons.OK,
                    MessageBoxIcon.Exclamation);
                
            }
            if (String.IsNullOrEmpty(textBox1.Text) == false || String.IsNullOrEmpty(label19.Text) == false)
            {
                if (String.IsNullOrEmpty(label19.Text) == true)
                {
                    MessageBox.Show("Nenhum cadastro selecionado para edição");
                    return; 
                }
                if (String.IsNullOrEmpty(textBox4.Text) == false)
                {         
                     Double qtde2;
                     if (Double.TryParse(textBox4.Text.Trim(), out qtde2) == false)
                     {
                         
                     }
                     if (Double.TryParse(textBox4.Text.Trim(), out qtde2) == true)
                     {
                         //tratar do fechamento do mês
                     }                
                }
                if (String.IsNullOrEmpty(textBox5.Text) == false)
                {
                    

                    Double qtde2;
                    if (Double.TryParse(textBox5.Text.Trim(), out qtde2) == false)
                    {
                        MessageBox.Show("O campo só aceita valores numéricos");
                        textBox5.Text = "";
                        textBox5.Focus();
                        return;
                    }

                }
                if(Convert.ToInt32(textBox3.Text) < Convert.ToInt32(textBox2.Text))
                {
                    MessageBox.Show("Consumo atual fornecido é menor do que o consumo anterior.");
                    textBox3.Text = "0";
                    textBox3.Focus();
                    return;
                }
                timer2.Enabled = true;
                DAL.Altera_Nome(Convert.ToInt32(label19.Text) ,textBox1.Text, textBox2.Text, textBox3.Text, textBox5.Text, richTextBox1.Text, comboBox1.Text);
                nomes = DAL.Lista_Nome();
                int consumo = 0;
                for (int i = 0; i < nomes.Rows.Count; i++)
                {
                    if (Convert.ToInt32(nomes.Rows[i]["Atual"].ToString()) > 0)
                    {
                        consumo += Convert.ToInt32(nomes.Rows[i]["Atual"].ToString()) - Convert.ToInt32(nomes.Rows[i]["Anterior"].ToString()); 
                    }                    
                }
                label27.Text = Convert.ToString(consumo);

                for (int i = 0; i < nomes.Rows.Count; i++)
                {
                    if (nomes.Rows[i]["Nome"].ToString() == textBox1.Text)
                    {
                        label19.Text = nomes.Rows[i]["Id"].ToString();
                        textBox1.Text = nomes.Rows[i]["Nome"].ToString();
                        textBox2.Text = nomes.Rows[i]["Anterior"].ToString();
                        textBox3.Text = nomes.Rows[i]["Atual"].ToString();
                        textBox5.Text = nomes.Rows[i]["Atraso"].ToString();
                        richTextBox1.Text = nomes.Rows[i]["Observação"].ToString();
                        comboBox1.Text = nomes.Rows[i]["TX_Comercial"].ToString();
                        DataTable pag = DAL.Pagou_Id_Lista(Convert.ToInt32(label19.Text));
                        if (pag.Rows.Count > 0)
                        {
                            label30.Text = "Pagamento Efetuado para Mês Atual";
                        }
                        if (pag.Rows.Count <= 0)
                        {
                            label30.Text = "";
                        }
                    }
                }
                dataGridView4.CurrentRow.Cells[0].Style.BackColor = Color.LightCyan;
                dataGridView4.CurrentRow.Cells[1].Style.BackColor = Color.LightCyan;
                dataGridView4.CurrentRow.Cells[2].Style.BackColor = Color.LightCyan;
                if (dataGridView3.Rows.Count > 0)
                {
                    if (pictureBox9.BorderStyle == BorderStyle.Fixed3D)
                    {
                        pictureBox9.BorderStyle = BorderStyle.None;
                        //tabControl1.SelectedTab = tabPage1;
                        label7.ForeColor = Color.Black;
                        tabControl1.TabPages.Remove(tabPage7);
                    }
                    
                    
                }
                
            }
            else
            {
                MessageBox.Show("Nenhum cadastro selecionado para edição");
            }
            
        }

        private void button17_Click(object sender, EventArgs e)
        {
            label27.Text = "";
            string message = "Você deseja abrir um novo mês?\nEste processo irá atualizar o consumo em Metros Cúbicos.";
            string caption = "Definir Mês Atual";
            MessageBoxButtons buttons = MessageBoxButtons.YesNo;
            DialogResult result;

            // Displays the MessageBox.
            result = MessageBox.Show(this, message, caption, buttons,
            MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);
            if (result == DialogResult.Yes)
            {
                ////////////////////////////////////////////////////////////////////////////
                DataTable rateio = DAL.Lista_Rateio();
                if (rateio.Rows.Count > 0)
                {
                    for (int i = 0; i < rateio.Rows.Count; i++)
                    {
                        if (rateio.Rows[i]["Parcelado"].ToString() == "não")
                        {
                            DAL.Baixar_Rateio(Convert.ToInt32( rateio.Rows[i]["Id"].ToString()));
                        }
                        if (rateio.Rows[i]["Parcelado"].ToString() == "sim")
                        {
                            DataTable rat_parc = DAL.Lista_Rateio_Parcelado2(Convert.ToInt32(rateio.Rows[i]["Id"].ToString()));
                            if (rat_parc.Rows.Count > 0)
                            {
                                DAL.Baixar_Rateio_Parcelado( Convert.ToInt32( rat_parc.Rows[0]["Rateio"].ToString()), rat_parc.Rows[0]["Parcela"].ToString());
                                rat_parc = DAL.Lista_Rateio_Parcelado2(Convert.ToInt32(rateio.Rows[i]["Id"].ToString()));
                                if (rat_parc.Rows.Count <= 0)
                                {
                                    DAL.Baixar_Rateio(Convert.ToInt32( rateio.Rows[i]["Id"].ToString()));
                                }
                            }

                        }
                    }
                }

                //Inserir aqui alteração

                DataTable l = DAL.Lista_Nome();
                if (l.Rows.Count > 0)
                {
                    for (int i = 0; i < l.Rows.Count; i++)
                    {
                        
                        if (Convert.ToInt32(l.Rows[i]["Atual"].ToString()) < Convert.ToInt32(l.Rows[i]["Anterior"].ToString()))
                        {                          
                            DAL.Atualiza_Consumo(Convert.ToInt32(l.Rows[i]["Id"].ToString()), l.Rows[i]["Anterior"].ToString(), "0");
                        }
                        if (Convert.ToInt32(l.Rows[i]["Atual"].ToString()) >= Convert.ToInt32(l.Rows[i]["Anterior"].ToString()))
                        {                            
                            DAL.Atualiza_Consumo(Convert.ToInt32(l.Rows[i]["Id"].ToString()), l.Rows[i]["Atual"].ToString(), "0");
                        }
                    }
                }



                DAL.Deleta_Mes_Atual();
                DAL.Deleta_Pagou();
                nomes = DAL.Lista_Ativo();
                if (nomes.Rows.Count > 0)
                {
                    timer2.Enabled = true;
                    for (int i = 0; i < nomes.Rows.Count; i++)
                    {
                        DAL.Cria_Mes_Atual(textBox6.Text, DateTime.Now.Year.ToString(), DateTime.Now.Month.ToString(),
                            DateTime.Now.Day.ToString(), "", nomes.Rows[i]["Nome"].ToString(), "");
                    }
                }
                nomes = DAL.Lista_Mes_Atual();
                if (nomes.Rows.Count > 0)
                {
                    this.Text = "Associação dos Moradores do Bairro Recreio das Acácias --> Mês Atual: " + nomes.Rows[0]["Atual"].ToString();
                    Global.Config.MesRegistro = nomes.Rows[0]["Atual"].ToString();
                }
                else
                {
                    this.Text = "Associação dos Moradores do Bairro Recreio das Acácias --> Mês Atual: Não Definido";
                }

                pictureBox1.BorderStyle = BorderStyle.None;
                //tabControl1.SelectedTab = tabPage1;
                label1.ForeColor = Color.Black;
                tabControl1.TabPages.Remove(tabPage1);

                pictureBox2.BorderStyle = BorderStyle.Fixed3D;
                label2.ForeColor = Color.Red;
                tabControl1.TabPages.Add(tabPage2);
                tabControl1.SelectedTab = tabPage2;
                nomes = DAL.Lista_Mes_Atual();
                if (nomes.Rows.Count > 0)
                {
                    label20.Text = nomes.Rows[0]["Atual"].ToString();
                }
                else
                {
                    MessageBox.Show("Necessário abrir mês atual");
                    pictureBox2.BorderStyle = BorderStyle.None;
                    //tabControl1.SelectedTab = tabPage1;
                    label2.ForeColor = Color.Black;
                    tabControl1.TabPages.Remove(tabPage2);
                }

            }           
            
        }
        private void pictureBox22_MouseEnter(object sender, EventArgs e)
        {
            label17.ForeColor = Color.Red;
            
        }

        private void pictureBox22_MouseLeave(object sender, EventArgs e)
        {
            label17.ForeColor = Color.Black;
            
        }

        private void pictureBox1_MouseEnter_1(object sender, EventArgs e)
        {
            if (pictureBox1.BorderStyle == BorderStyle.None)
            {
                label1.ForeColor = Color.Red;

            }
            
            
        }

        private void pictureBox1_MouseLeave_1(object sender, EventArgs e)
        {
            if (pictureBox1.BorderStyle == BorderStyle.None)
            {
                label1.ForeColor = Color.Black;

            }
          
        }

        private void pictureBox22_Click(object sender, EventArgs e)
        {
            
            Form conf = new Config();
            conf.ShowDialog();
            if (pictureBox3.BorderStyle == BorderStyle.Fixed3D)
            {
                pictureBox3.BorderStyle = BorderStyle.None;
                //tabControl1.SelectedTab = tabPage1;
                label3.ForeColor = Color.Black;
                tabControl1.TabPages.Remove(tabPage3);
            }

            //pega config
            DataTable config1 = DAL.Lista_Config();
            //tabela de valores
            TextObject txt16 = (TextObject)rpt.ReportDefinition.ReportObjects["Text16"]; //Instancie um objeto do tipo TextObject e informe o nome do textbox
            txt16.Text = "Tabela para cálculo:\n" +
                        "Até 10 m³  -  R$ " + config1.Rows[0]["Valor_Base"].ToString() + "\n" +
                        "De   10 m³  a 30 m³ + R$ " + config1.Rows[0]["Dez_Trinta"].ToString() + " por m³\n" +
                        "De   30 m³  a 90 m³ + R$ " + config1.Rows[0]["Trinta_Noventa"].ToString() + " por m³\n" +
                        "Acima de  90 m³     + R$ " + config1.Rows[0]["Noventa"].ToString() + " por m³";

            TextObject txt160 = (TextObject)rpt.ReportDefinition.ReportObjects["Text160"]; //Instancie um objeto do tipo TextObject e informe o nome do textbox
            txt160.Text = "Tabela para cálculo:\n" +
                        "Até 10 m³  -  R$ " + config1.Rows[0]["Valor_Base"].ToString() + "\n" +
                        "De   10 m³  a 30 m³ + R$ " + config1.Rows[0]["Dez_Trinta"].ToString() + " por m³\n" +
                        "De   30 m³  a 90 m³ + R$ " + config1.Rows[0]["Trinta_Noventa"].ToString() + " por m³\n" +
                        "Acima de  90 m³     + R$ " + config1.Rows[0]["Noventa"].ToString() + " por m³";

            TextObject txt193 = (TextObject)rpt.ReportDefinition.ReportObjects["Text193"]; //Instancie um objeto do tipo TextObject e informe o nome do textbox
            txt193.Text = "Tabela para cálculo:\n" +
                        "Até 10 m³  -  R$ " + config1.Rows[0]["Valor_Base"].ToString() + "\n" +
                        "De   10 m³  a 30 m³ + R$ " + config1.Rows[0]["Dez_Trinta"].ToString() + " por m³\n" +
                        "De   30 m³  a 90 m³ + R$ " + config1.Rows[0]["Trinta_Noventa"].ToString() + " por m³\n" +
                        "Acima de  90 m³     + R$ " + config1.Rows[0]["Noventa"].ToString() + " por m³";

            TextObject txt226 = (TextObject)rpt.ReportDefinition.ReportObjects["Text226"]; //Instancie um objeto do tipo TextObject e informe o nome do textbox
            txt226.Text = "Tabela para cálculo:\n" +
                        "Até 10 m³  -  R$ " + config1.Rows[0]["Valor_Base"].ToString() + "\n" +
                        "De   10 m³  a 30 m³ + R$ " + config1.Rows[0]["Dez_Trinta"].ToString() + " por m³\n" +
                        "De   30 m³  a 90 m³ + R$ " + config1.Rows[0]["Trinta_Noventa"].ToString() + " por m³\n" +
                        "Acima de  90 m³     + R$ " + config1.Rows[0]["Noventa"].ToString() + " por m³";

            crystalReportViewer1.ReportSource = rpt;
            
            
        }
        
        private void button2_Click(object sender, EventArgs e)
        {
            
            if (String.IsNullOrEmpty(textBox1.Text) == true)
            {
                MessageBox.Show("Campo Nome não informado");
                textBox1.Focus();
                return;
            }
            
            nomes = DAL.Lista_Nome();
            if (nomes.Rows.Count > 0)
            {
                for (int k = 0; k < nomes.Rows.Count; k++)
                {
                    if (nomes.Rows[k]["Nome"].ToString() == textBox1.Text)
                    {
                        MessageBox.Show("Já existe um cadastro: " + textBox1.Text);
                        textBox1.Focus();
                        return;
                    }
                }
            }
            if (nomes.Rows.Count > 0)
            {
                if (String.IsNullOrEmpty(textBox4.Text) == false)
                {
                    

                    Double qtde2;
                    if (Double.TryParse(textBox4.Text.Trim(), out qtde2) == false)
                    {
                        
                    }

                }
                if (String.IsNullOrEmpty(textBox5.Text) == false)
                {
                    

                    Double qtde2;
                    if (Double.TryParse(textBox5.Text.Trim(), out qtde2) == false)
                    {
                        MessageBox.Show("O campo só aceita valores numéricos");
                        textBox5.Text = "";
                        textBox5.Focus();
                        return;
                    }

                }
                timer2.Enabled = true;
                if (String.IsNullOrEmpty(textBox2.Text) == false)
                {
                    DAL.Insere_Nome(textBox1.Text, textBox2.Text, textBox3.Text, textBox5.Text, richTextBox1.Text, comboBox1.Text);
                }
                else
                {
                    DAL.Insere_Nome(textBox1.Text, "0", textBox3.Text, textBox5.Text, richTextBox1.Text, comboBox1.Text);
                }

                dataGridView4.DataSource = DAL.Lista_Ativo();
                if (dataGridView4.Rows.Count > 0)
                {
                    for (int i = 0; i < dataGridView4.Rows.Count; i++)
                    {
                        dataGridView4.Columns[0].Width = 30;
                        dataGridView4.Columns[1].Width = 200;
                        if (dataGridView4.Rows[i].Cells[2].Value.ToString() == "0")
                        {
                            dataGridView4.Rows[i].Cells[0].Style.BackColor = Color.White;
                            dataGridView4.Rows[i].Cells[1].Style.BackColor = Color.White;
                            dataGridView4.Rows[i].Cells[2].Style.BackColor = Color.White;
                        }
                        else
                        {
                            dataGridView4.Rows[i].Cells[0].Style.BackColor = Color.LightCyan;
                            dataGridView4.Rows[i].Cells[1].Style.BackColor = Color.LightCyan;
                            dataGridView4.Rows[i].Cells[2].Style.BackColor = Color.LightCyan;
                        }
                    }
                }
                if (dataGridView4.Rows.Count > 0)
                {
                    for (int i = 0; i < dataGridView4.Rows.Count; i++)
                    {
                        if (dataGridView4.Rows[i].Cells[1].Value.ToString() == textBox1.Text)
                        {
                            dataGridView4.CurrentCell = dataGridView4.Rows[i].Cells[1];
                        }
                    }
                }
                textBox1.Focus(); 
                
                
             
            }
            if (nomes.Rows.Count == 0)
            {
                timer2.Enabled = true;
                if (String.IsNullOrEmpty(textBox2.Text) == false)
                {
                    DAL.Insere_Nome(textBox1.Text, textBox2.Text, textBox3.Text, textBox5.Text, richTextBox1.Text, comboBox1.SelectedValue.ToString());
                }
                else
                {
                    DAL.Insere_Nome(textBox1.Text, "0", textBox3.Text, textBox5.Text, richTextBox1.Text, comboBox1.Text);
                }
                
                nomes = DAL.Lista_Nome();
                for (int i = 0; i < nomes.Rows.Count; i++)
                {
                    if (nomes.Rows[i]["Nome"].ToString() == textBox1.Text)
                    {
                        label19.Text = nomes.Rows[i]["Id"].ToString();
                        textBox1.Text = nomes.Rows[i]["Nome"].ToString();
                        textBox2.Text = nomes.Rows[i]["Anterior"].ToString();
                        textBox3.Text = nomes.Rows[i]["Atual"].ToString();
                        textBox5.Text = nomes.Rows[i]["Atraso"].ToString();
                        richTextBox1.Text = nomes.Rows[i]["Observação"].ToString();
                    }
                }
                
                                     
            }
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            
            if (checkBox1.Checked == true && String.IsNullOrEmpty(label19.Text) == false)
            {
                string message = "Você deseja tornar este cadastro inativo?";
                string caption = "Inativos";
                MessageBoxButtons buttons = MessageBoxButtons.YesNo;
                DialogResult result;
                int linha = 0;
                // Displays the MessageBox.
                result = MessageBox.Show(this, message, caption, buttons,
                MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);
                if (result == DialogResult.Yes)
                {
                   
                    if (String.IsNullOrEmpty(label19.Text) == false)
                    {
                        
                        linha = dataGridView4.CurrentRow.Index;
                        if (linha > 1)
                        {
                            linha--;
                        }
                        //----------------
                        DAL.Torna_Inativo(Convert.ToInt32(label19.Text));
                        DAL.Deleta_Nome_Mes_Atual(textBox1.Text);
                        
                        //----------------
                        string temp = textBox1.Text;
                        label19.Text = "";
                        textBox1.Text = "";
                        textBox2.Text = "";
                        textBox3.Text = "";
                        textBox4.Text = "";
                        textBox5.Text = "";
                        richTextBox1.Text = "";
                        checkBox1.Checked = false;
                        MessageBox.Show("Cadastro: ||| " + temp + " |||" + "\nInativado");
                        
                        dataGridView4.DataSource = DAL.Lista_Ativo();
                        if (dataGridView4.Rows.Count > 0)
                        {
                            for (int i = 0; i < dataGridView4.Rows.Count; i++)
                            {
                                dataGridView4.Columns[0].Width = 200;
                                dataGridView4.Columns[1].Width = 50;
                                if (dataGridView4.Rows[i].Cells[2].Value.ToString() == "0")
                                {
                                    dataGridView4.Rows[i].Cells[0].Style.BackColor = Color.White;
                                    dataGridView4.Rows[i].Cells[1].Style.BackColor = Color.White;
                                    dataGridView4.Rows[i].Cells[2].Style.BackColor = Color.White;
                                }
                                else
                                {
                                    dataGridView4.Rows[i].Cells[0].Style.BackColor = Color.LightCyan;
                                    dataGridView4.Rows[i].Cells[1].Style.BackColor = Color.LightCyan;
                                    dataGridView4.Rows[i].Cells[2].Style.BackColor = Color.LightCyan;
                                }
                            }
                        }
                        // Set row labels.
                       int rowNumber = 1;
                       foreach (DataGridViewRow row in dataGridView4.Rows)
                       {
                           if (row.IsNewRow) continue;
                           row.HeaderCell.Value = "" + rowNumber;
                           rowNumber = rowNumber + 1;
                       }
                       dataGridView4.AutoResizeRowHeadersWidth(DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders);
                       dataGridView4.CurrentCell = dataGridView4.Rows[linha].Cells[0];
                       if (pictureBox9.BorderStyle == BorderStyle.Fixed3D)
                       {
                           pictureBox9.BorderStyle = BorderStyle.None;
                           //tabControl1.SelectedTab = tabPage1;
                           label7.ForeColor = Color.Black;
                           tabControl1.TabPages.Remove(tabPage7);
                       }
                       
                       textBox1.Focus();
                       
                    }
                }
                if (result == DialogResult.No)
                {
                    textBox1.Focus();
                    checkBox1.Checked = false;
                    return;
                }
            }
            else
            {
                checkBox1.Checked = false;
            }
            
        }

        private void timer3_Tick(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(Global.Config.Cad_ID) == false)
            {
                nomes = DAL.Lista_Nome();
                for (int i = 0; i < nomes.Rows.Count; i++)
                {
                    if (nomes.Rows[i]["Id"].ToString() == Global.Config.Cad_ID)
                    {
                        label19.Text = nomes.Rows[i]["Id"].ToString();
                        textBox1.Text = nomes.Rows[i]["Nome"].ToString();
                        textBox2.Text = nomes.Rows[i]["Anterior"].ToString();
                        textBox3.Text = nomes.Rows[i]["Atual"].ToString();
                        textBox5.Text = nomes.Rows[i]["Atraso"].ToString();
                        richTextBox1.Text = nomes.Rows[i]["Observação"].ToString();
                        comboBox1.Text = nomes.Rows[i]["TX_Comercial"].ToString();
                        DataTable pag = DAL.Pagou_Id_Lista(Convert.ToInt32(label19.Text));
                        if (pag.Rows.Count > 0)
                        {
                            label30.Text = "Pagamento Efetuado para Mês Atual";
                        }
                        if (pag.Rows.Count <= 0)
                        {
                            label30.Text = "";
                        }
                        Global.Config.Cad_ID = "";
                        return;
                    }
                }
            }
        }

        private void button20_Click(object sender, EventArgs e)
        {
            pictureBox2.BorderStyle = BorderStyle.None;
            //tabControl1.SelectedTab = tabPage1;
            label2.ForeColor = Color.Black;
            tabControl1.TabPages.Remove(tabPage2);
        }

        private void monthCalendar1_DateSelected(object sender, DateRangeEventArgs e)
        {
            textBox7.Text = monthCalendar1.SelectionStart.ToShortDateString();
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox2.Checked == false)
            {
                string message = "Você deseja lançar manualmente a leitura mensal?";
                string caption = "Leitura Atual";
                MessageBoxButtons buttons = MessageBoxButtons.YesNo;
                DialogResult result;

                // Displays the MessageBox.
                result = MessageBox.Show(this, message, caption, buttons,
                MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);
                if (result == DialogResult.Yes)
                {
                    
                }
                
                if (result == DialogResult.No)
                {
                    checkBox2.Checked = true;
                }
            }
        }

        private void button21_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(label20.Text) == false && String.IsNullOrEmpty(textBox7.Text) == false)
            {        
                DAL.Insere_Vencimento(1, textBox7.Text);
            }
            else
            {
                if (String.IsNullOrEmpty(label20.Text) == true)
                {
                    MessageBox.Show("Abrir Mês Atual Primeiro");
                    return;
                }
                if (String.IsNullOrEmpty(textBox7.Text) == true)
                {
                    MessageBox.Show("Selecionar Vencimento");
                    textBox7.Focus();
                    return;
                }
            }

            pictureBox2.BorderStyle = BorderStyle.None;
            //tabControl1.SelectedTab = tabPage1;
            label2.ForeColor = Color.Black;
            tabControl1.TabPages.Remove(tabPage2);


            pictureBox10.BorderStyle = BorderStyle.None;
            //tabControl1.SelectedTab = tabPage1;
            label6.ForeColor = Color.Black;
            tabControl1.TabPages.Remove(tabPage6);

            pictureBox10.BorderStyle = BorderStyle.Fixed3D;
            label6.ForeColor = Color.Red;
            tabControl1.TabPages.Add(tabPage6);
            tabControl1.SelectedTab = tabPage6;

            dataGridView4.DataSource = DAL.Lista_Ativo();
            if (dataGridView4.Rows.Count > 0)
            {
                for (int i = 0; i < dataGridView4.Rows.Count; i++)
                {
                    dataGridView4.Columns[0].Width = 30;
                    dataGridView4.Columns[1].Width = 200;
                }
            }
            nomes = DAL.Lista_Nome();
            if (nomes.Rows.Count > 0)
            {
                label19.Text = nomes.Rows[0]["Id"].ToString();
                textBox1.Text = nomes.Rows[0]["Nome"].ToString();
                textBox2.Text = nomes.Rows[0]["Anterior"].ToString();
                textBox3.Text = nomes.Rows[0]["Atual"].ToString();
                textBox5.Text = nomes.Rows[0]["Atraso"].ToString();
                richTextBox1.Text = nomes.Rows[0]["Observação"].ToString();
                comboBox1.Text = nomes.Rows[0]["TX_Comercial"].ToString();

                DataTable pag = DAL.Pagou_Id_Lista(Convert.ToInt32(label19.Text));
                if (pag.Rows.Count > 0)
                {
                    label30.Text = "Pagamento Efetuado para Mês Atual";
                }
                if (pag.Rows.Count <= 0)
                {
                    label30.Text = "";
                }

            }
            textBox3.Focus();
            if (!String.IsNullOrEmpty(textBox3.Text))
            {
                textBox3.SelectionStart = 0;
                textBox3.SelectionLength = textBox3.Text.Length;
            }
            textBox3.Focus();
            //Form leit = new Leitura();
            //leit.ShowDialog();


        }

        private void button22_Click(object sender, EventArgs e)
        {
            pictureBox5.BorderStyle = BorderStyle.None;
            //tabControl1.SelectedTab = tabPage1;
            label5.ForeColor = Color.Black;
            tabControl1.TabPages.Remove(tabPage5);
        }

        private void button23_Click(object sender, EventArgs e)
        {
            Global.Config.Impressao = "leitura";
            printDGV.Print_DataGridView(dataGridView1);
        }

      
        int pag = 0;
        int contImp = 0;
        private void button24_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(comboInstalledPrinters.Text) == true)
            {
                MessageBox.Show("Selecione uma Impressora");
                return;
            }
            pag = 0;

            Form entra = new EntrarMes();
            entra.ShowDialog();
            if (Global.Config.Cancela == "sim")
            {
                Global.Config.Cancela = "";
                return;
            }

            TextObject txt120 = (TextObject)rpt.ReportDefinition.ReportObjects["Text120"]; //Instancie um objeto do tipo TextObject e informe o nome do textbox
            txt120.Text = Global.Config.Texto;

            TextObject txt186 = (TextObject)rpt.ReportDefinition.ReportObjects["Text186"]; //Instancie um objeto do tipo TextObject e informe o nome do textbox
            txt186.Text = Global.Config.Texto;

            TextObject txt219 = (TextObject)rpt.ReportDefinition.ReportObjects["Text219"]; //Instancie um objeto do tipo TextObject e informe o nome do textbox
            txt219.Text = Global.Config.Texto;

            TextObject txt252 = (TextObject)rpt.ReportDefinition.ReportObjects["Text252"]; //Instancie um objeto do tipo TextObject e informe o nome do textbox
            txt252.Text = Global.Config.Texto;


            TextObject txt122 = (TextObject)rpt.ReportDefinition.ReportObjects["Text122"]; //Instancie um objeto do tipo TextObject e informe o nome do textbox
            txt122.Text = Global.Config.Aviso;

            TextObject txt188 = (TextObject)rpt.ReportDefinition.ReportObjects["Text188"]; //Instancie um objeto do tipo TextObject e informe o nome do textbox
            txt188.Text = Global.Config.Aviso;

            TextObject txt221 = (TextObject)rpt.ReportDefinition.ReportObjects["Text221"]; //Instancie um objeto do tipo TextObject e informe o nome do textbox
            txt221.Text = Global.Config.Aviso;

            TextObject txt254 = (TextObject)rpt.ReportDefinition.ReportObjects["Text254"]; //Instancie um objeto do tipo TextObject e informe o nome do textbox
            txt254.Text = Global.Config.Aviso;

           

            int termina = 0;
            DAL.Deleta_Relatorio();
            //variaveis relatório
            string Nome_Re = "";
            string Anterior_Re = "";
            string Atual_Re = "";
            string Consumo_Re = "0";
            string Valor_Re = "";
            string Rateio_Re = "";
            string TX_Re = "";
            string Total_Re = "";
            string TotalMulta_Re = "";
            string Atraso_Re = "";
            string Pagamento_Re = "";
            string Observação = "";
            string Mes_Re = "";
            DataTable at = DAL.Lista_Mes_Atual();
            if (at.Rows.Count > 0)
            {
                Mes_Re = at.Rows[0]["Atual"].ToString();
            }
            ///////////////////Impressão dos boletos///////////////////////
            //animação ampulheta
            pictureBox27.Visible = true;

            //pega config
            DataTable config = DAL.Lista_Config();
            
            //vencimento

            DataTable venc = DAL.Lista_Vencimento();
            if (venc.Rows.Count > 0)
            {
                TextObject txt114 = (TextObject)rpt.ReportDefinition.ReportObjects["Text114"]; //Instancie um objeto do tipo TextObject e informe o nome do textbox
                txt114.Text = venc.Rows[0]["Vencimento"].ToString();

                TextObject txt180 = (TextObject)rpt.ReportDefinition.ReportObjects["Text180"]; //Instancie um objeto do tipo TextObject e informe o nome do textbox
                txt180.Text = venc.Rows[0]["Vencimento"].ToString();

                TextObject txt213 = (TextObject)rpt.ReportDefinition.ReportObjects["Text213"]; //Instancie um objeto do tipo TextObject e informe o nome do textbox
                txt213.Text = venc.Rows[0]["Vencimento"].ToString();

                TextObject txt246 = (TextObject)rpt.ReportDefinition.ReportObjects["Text246"]; //Instancie um objeto do tipo TextObject e informe o nome do textbox
                txt246.Text = venc.Rows[0]["Vencimento"].ToString();

                
            }
            else
            {
                MessageBox.Show("Defina o dia do vencimento");
                return;
            }
            nomes = DAL.Lista_Nome();

            //verifica de atual foi lançado
            if (nomes.Rows.Count > 0)
            {
                for (int i = 0; i < nomes.Rows.Count; i++)
                {
                    if (nomes.Rows[i]["Atual"].ToString() == "0" )
                    {
                        string message = "Consumo atual de:\n" + nomes.Rows[i]["Nome"].ToString() + " , não informado.\nDeseja continuar mesmo assim?";
                        string caption = "Consumo Atual";
                        MessageBoxButtons buttons = MessageBoxButtons.YesNo;
                        DialogResult result;

                        // Displays the MessageBox.

                        result = MessageBox.Show(this, message, caption, buttons,
                        MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);

                       
                        if (result == DialogResult.No)
                        {
                            //Preparar campos do relatório
                            //TextObject txt120 = (TextObject)rpt.ReportDefinition.ReportObjects["Text120"]; //Instancie um objeto do tipo TextObject e informe o nome do textbox
                            txt120.Text = "";
                            TextObject txt256 = (TextObject)rpt.ReportDefinition.ReportObjects["Text256"]; //Instancie um objeto do tipo TextObject e informe o nome do textbox
                            txt256.Text = "";
                            TextObject txt110 = (TextObject)rpt.ReportDefinition.ReportObjects["Text110"]; //Instancie um objeto do tipo TextObject e informe o nome do textbox
                            txt110.Text = "0";
                            TextObject txt111 = (TextObject)rpt.ReportDefinition.ReportObjects["Text111"]; //Instancie um objeto do tipo TextObject e informe o nome do textbox
                            txt111.Text = "0";
                            TextObject txt112 = (TextObject)rpt.ReportDefinition.ReportObjects["Text112"]; //Instancie um objeto do tipo TextObject e informe o nome do textbox
                            txt112.Text = "0";
                            TextObject txt113 = (TextObject)rpt.ReportDefinition.ReportObjects["Text113"]; //Instancie um objeto do tipo TextObject e informe o nome do textbox
                            txt113.Text = "0";
                            TextObject txt114 = (TextObject)rpt.ReportDefinition.ReportObjects["Text114"]; //Instancie um objeto do tipo TextObject e informe o nome do textbox
                            txt114.Text = "0";
                            TextObject txt115 = (TextObject)rpt.ReportDefinition.ReportObjects["Text115"]; //Instancie um objeto do tipo TextObject e informe o nome do textbox
                            txt115.Text = "0";
                            TextObject txt116 = (TextObject)rpt.ReportDefinition.ReportObjects["Text116"]; //Instancie um objeto do tipo TextObject e informe o nome do textbox
                            txt116.Text = "0";
                            TextObject txt121 = (TextObject)rpt.ReportDefinition.ReportObjects["Text121"]; //Instancie um objeto do tipo TextObject e informe o nome do textbox
                            txt121.Text = "";
                            //TextObject txt122 = (TextObject)rpt.ReportDefinition.ReportObjects["Text122"]; //Instancie um objeto do tipo TextObject e informe o nome do textbox
                            txt122.Text = "";
                            TextObject txt123 = (TextObject)rpt.ReportDefinition.ReportObjects["Text123"]; //Instancie um objeto do tipo TextObject e informe o nome do textbox
                            txt123.Text = "";
                            TextObject txt117 = (TextObject)rpt.ReportDefinition.ReportObjects["Text117"]; //Instancie um objeto do tipo TextObject e informe o nome do textbox
                            txt117.Text = "0";
                            TextObject txt118 = (TextObject)rpt.ReportDefinition.ReportObjects["Text118"]; //Instancie um objeto do tipo TextObject e informe o nome do textbox
                            txt118.Text = "0";
                            TextObject txt119 = (TextObject)rpt.ReportDefinition.ReportObjects["Text119"]; //Instancie um objeto do tipo TextObject e informe o nome do textbox
                            txt119.Text = "0";

                            //TextObject txt186 = (TextObject)rpt.ReportDefinition.ReportObjects["Text186"]; //Instancie um objeto do tipo TextObject e informe o nome do textbox
                            txt186.Text = "";
                            TextObject txt257 = (TextObject)rpt.ReportDefinition.ReportObjects["Text257"]; //Instancie um objeto do tipo TextObject e informe o nome do textbox
                            txt257.Text = "";
                            TextObject txt176 = (TextObject)rpt.ReportDefinition.ReportObjects["Text176"]; //Instancie um objeto do tipo TextObject e informe o nome do textbox
                            txt176.Text = "0";
                            TextObject txt177 = (TextObject)rpt.ReportDefinition.ReportObjects["Text177"]; //Instancie um objeto do tipo TextObject e informe o nome do textbox
                            txt177.Text = "0";
                            TextObject txt178 = (TextObject)rpt.ReportDefinition.ReportObjects["Text178"]; //Instancie um objeto do tipo TextObject e informe o nome do textbox
                            txt178.Text = "0";
                            TextObject txt179 = (TextObject)rpt.ReportDefinition.ReportObjects["Text179"]; //Instancie um objeto do tipo TextObject e informe o nome do textbox
                            txt179.Text = "0";
                            TextObject txt180 = (TextObject)rpt.ReportDefinition.ReportObjects["Text180"]; //Instancie um objeto do tipo TextObject e informe o nome do textbox
                            txt180.Text = "0";
                            TextObject txt181 = (TextObject)rpt.ReportDefinition.ReportObjects["Text181"]; //Instancie um objeto do tipo TextObject e informe o nome do textbox
                            txt181.Text = "0";
                            TextObject txt182 = (TextObject)rpt.ReportDefinition.ReportObjects["Text182"]; //Instancie um objeto do tipo TextObject e informe o nome do textbox
                            txt182.Text = "0";
                            TextObject txt187 = (TextObject)rpt.ReportDefinition.ReportObjects["Text187"]; //Instancie um objeto do tipo TextObject e informe o nome do textbox
                            txt187.Text = "";
                            //TextObject txt188 = (TextObject)rpt.ReportDefinition.ReportObjects["Text188"]; //Instancie um objeto do tipo TextObject e informe o nome do textbox
                            txt188.Text = "";
                            TextObject txt189 = (TextObject)rpt.ReportDefinition.ReportObjects["Text189"]; //Instancie um objeto do tipo TextObject e informe o nome do textbox
                            txt189.Text = "";
                            TextObject txt183 = (TextObject)rpt.ReportDefinition.ReportObjects["Text183"]; //Instancie um objeto do tipo TextObject e informe o nome do textbox
                            txt183.Text = "0";
                            TextObject txt184 = (TextObject)rpt.ReportDefinition.ReportObjects["Text184"]; //Instancie um objeto do tipo TextObject e informe o nome do textbox
                            txt184.Text = "0";
                            TextObject txt185 = (TextObject)rpt.ReportDefinition.ReportObjects["Text185"]; //Instancie um objeto do tipo TextObject e informe o nome do textbox
                            txt185.Text = "0";


                            //TextObject txt219 = (TextObject)rpt.ReportDefinition.ReportObjects["Text219"]; //Instancie um objeto do tipo TextObject e informe o nome do textbox
                            txt219.Text = "";
                            TextObject txt258 = (TextObject)rpt.ReportDefinition.ReportObjects["Text258"]; //Instancie um objeto do tipo TextObject e informe o nome do textbox
                            txt258.Text = "";
                            TextObject txt209 = (TextObject)rpt.ReportDefinition.ReportObjects["Text209"]; //Instancie um objeto do tipo TextObject e informe o nome do textbox
                            txt209.Text = "0";
                            TextObject txt210 = (TextObject)rpt.ReportDefinition.ReportObjects["Text210"]; //Instancie um objeto do tipo TextObject e informe o nome do textbox
                            txt210.Text = "0";
                            TextObject txt211 = (TextObject)rpt.ReportDefinition.ReportObjects["Text211"]; //Instancie um objeto do tipo TextObject e informe o nome do textbox
                            txt211.Text = "0";
                            TextObject txt212 = (TextObject)rpt.ReportDefinition.ReportObjects["Text212"]; //Instancie um objeto do tipo TextObject e informe o nome do textbox
                            txt212.Text = "0";
                            TextObject txt213 = (TextObject)rpt.ReportDefinition.ReportObjects["Text213"]; //Instancie um objeto do tipo TextObject e informe o nome do textbox
                            txt213.Text = "0";
                            TextObject txt214 = (TextObject)rpt.ReportDefinition.ReportObjects["Text214"]; //Instancie um objeto do tipo TextObject e informe o nome do textbox
                            txt214.Text = "0";
                            TextObject txt215 = (TextObject)rpt.ReportDefinition.ReportObjects["Text215"]; //Instancie um objeto do tipo TextObject e informe o nome do textbox
                            txt215.Text = "0";
                            TextObject txt220 = (TextObject)rpt.ReportDefinition.ReportObjects["Text220"]; //Instancie um objeto do tipo TextObject e informe o nome do textbox
                            txt220.Text = "";
                            //TextObject txt221 = (TextObject)rpt.ReportDefinition.ReportObjects["Text221"]; //Instancie um objeto do tipo TextObject e informe o nome do textbox
                            txt221.Text = "";
                            TextObject txt222 = (TextObject)rpt.ReportDefinition.ReportObjects["Text222"]; //Instancie um objeto do tipo TextObject e informe o nome do textbox
                            txt222.Text = "";
                            TextObject txt216 = (TextObject)rpt.ReportDefinition.ReportObjects["Text216"]; //Instancie um objeto do tipo TextObject e informe o nome do textbox
                            txt216.Text = "0";
                            TextObject txt217 = (TextObject)rpt.ReportDefinition.ReportObjects["Text217"]; //Instancie um objeto do tipo TextObject e informe o nome do textbox
                            txt217.Text = "0";
                            TextObject txt218 = (TextObject)rpt.ReportDefinition.ReportObjects["Text218"]; //Instancie um objeto do tipo TextObject e informe o nome do textbox
                            txt218.Text = "0";


                            //TextObject txt252 = (TextObject)rpt.ReportDefinition.ReportObjects["Text252"]; //Instancie um objeto do tipo TextObject e informe o nome do textbox
                            txt252.Text = "";
                            TextObject txt259 = (TextObject)rpt.ReportDefinition.ReportObjects["Text259"]; //Instancie um objeto do tipo TextObject e informe o nome do textbox
                            txt259.Text = "";
                            TextObject txt242 = (TextObject)rpt.ReportDefinition.ReportObjects["Text242"]; //Instancie um objeto do tipo TextObject e informe o nome do textbox
                            txt242.Text = "0";
                            TextObject txt243 = (TextObject)rpt.ReportDefinition.ReportObjects["Text243"]; //Instancie um objeto do tipo TextObject e informe o nome do textbox
                            txt243.Text = "0";
                            TextObject txt244 = (TextObject)rpt.ReportDefinition.ReportObjects["Text244"]; //Instancie um objeto do tipo TextObject e informe o nome do textbox
                            txt244.Text = "0";
                            TextObject txt245 = (TextObject)rpt.ReportDefinition.ReportObjects["Text245"]; //Instancie um objeto do tipo TextObject e informe o nome do textbox
                            txt245.Text = "0";
                            TextObject txt246 = (TextObject)rpt.ReportDefinition.ReportObjects["Text246"]; //Instancie um objeto do tipo TextObject e informe o nome do textbox
                            txt246.Text = "0";
                            TextObject txt247 = (TextObject)rpt.ReportDefinition.ReportObjects["Text247"]; //Instancie um objeto do tipo TextObject e informe o nome do textbox
                            txt247.Text = "0";
                            TextObject txt248 = (TextObject)rpt.ReportDefinition.ReportObjects["Text248"]; //Instancie um objeto do tipo TextObject e informe o nome do textbox
                            txt248.Text = "0";
                            TextObject txt253 = (TextObject)rpt.ReportDefinition.ReportObjects["Text253"]; //Instancie um objeto do tipo TextObject e informe o nome do textbox
                            txt253.Text = "";
                            //TextObject txt254 = (TextObject)rpt.ReportDefinition.ReportObjects["Text254"]; //Instancie um objeto do tipo TextObject e informe o nome do textbox
                            txt254.Text = "";
                            TextObject txt255 = (TextObject)rpt.ReportDefinition.ReportObjects["Text255"]; //Instancie um objeto do tipo TextObject e informe o nome do textbox
                            txt255.Text = "";
                            TextObject txt249 = (TextObject)rpt.ReportDefinition.ReportObjects["Text249"]; //Instancie um objeto do tipo TextObject e informe o nome do textbox
                            txt249.Text = "0";
                            TextObject txt250 = (TextObject)rpt.ReportDefinition.ReportObjects["Text250"]; //Instancie um objeto do tipo TextObject e informe o nome do textbox
                            txt250.Text = "0";
                            TextObject txt251 = (TextObject)rpt.ReportDefinition.ReportObjects["Text251"]; //Instancie um objeto do tipo TextObject e informe o nome do textbox
                            txt251.Text = "0";



                            //********************************************************************************
                            //********************************************************************************

                            //Carregar Relatório / Impressoras instaladas e padrão

                            crystalReportViewer1.ReportSource = rpt;
                            pictureBox27.Visible = false;
                            Cursor = Cursors.Default;
                            return;
                        }
                    }
                }
            }
            
            termina = nomes.Rows.Count;
            for (int i = 0; i < nomes.Rows.Count; i++)
            {
                
                if (venc.Rows.Count > 0)
                {

                    TextObject txt114 = (TextObject)rpt.ReportDefinition.ReportObjects["Text114"]; //Instancie um objeto do tipo TextObject e informe o nome do textbox
                    txt114.Text = venc.Rows[0]["Vencimento"].ToString();

                    TextObject txt180 = (TextObject)rpt.ReportDefinition.ReportObjects["Text180"]; //Instancie um objeto do tipo TextObject e informe o nome do textbox
                    txt180.Text = venc.Rows[0]["Vencimento"].ToString();

                    TextObject txt213 = (TextObject)rpt.ReportDefinition.ReportObjects["Text213"]; //Instancie um objeto do tipo TextObject e informe o nome do textbox
                    txt213.Text = venc.Rows[0]["Vencimento"].ToString();

                    TextObject txt246 = (TextObject)rpt.ReportDefinition.ReportObjects["Text246"]; //Instancie um objeto do tipo TextObject e informe o nome do textbox
                    txt246.Text = venc.Rows[0]["Vencimento"].ToString();


                }

                Cursor = Cursors.WaitCursor;
                if (contImp == 0)
                {
                    TextObject txt256 = (TextObject)rpt.ReportDefinition.ReportObjects["Text256"]; //Instancie um objeto do tipo TextObject e informe o nome do textbox
                    txt256.Text = nomes.Rows[i]["Nome"].ToString();
                    Nome_Re = nomes.Rows[i]["Nome"].ToString();
                   

                    TextObject txt117 = (TextObject)rpt.ReportDefinition.ReportObjects["Text117"]; //Instancie um objeto do tipo TextObject e informe o nome do textbox
                    txt117.Text = nomes.Rows[i]["Anterior"].ToString();
                    Anterior_Re = nomes.Rows[i]["Anterior"].ToString();

                    TextObject txt118 = (TextObject)rpt.ReportDefinition.ReportObjects["Text118"]; //Instancie um objeto do tipo TextObject e informe o nome do textbox
                    txt118.Text = nomes.Rows[i]["Atual"].ToString();
                    Atual_Re = nomes.Rows[i]["Atual"].ToString();

                    TextObject txt116 = (TextObject)rpt.ReportDefinition.ReportObjects["Text116"]; //Instancie um objeto do tipo TextObject e informe o nome do textbox
                    txt116.Text = nomes.Rows[i]["Atraso"].ToString();
                    Atraso_Re = nomes.Rows[i]["Atraso"].ToString();

                    TextObject txt123 = (TextObject)rpt.ReportDefinition.ReportObjects["Text123"]; //Instancie um objeto do tipo TextObject e informe o nome do textbox
                    txt123.Text = nomes.Rows[i]["Observação"].ToString();
                }
                if (contImp == 1)
                {
                    TextObject txt257 = (TextObject)rpt.ReportDefinition.ReportObjects["Text257"]; //Instancie um objeto do tipo TextObject e informe o nome do textbox
                    txt257.Text = nomes.Rows[i]["Nome"].ToString();
                    Nome_Re = nomes.Rows[i]["Nome"].ToString();

                    informarNomes += Nome_Re + "\n";

                    TextObject txt183 = (TextObject)rpt.ReportDefinition.ReportObjects["Text183"]; //Instancie um objeto do tipo TextObject e informe o nome do textbox
                    txt183.Text = nomes.Rows[i]["Anterior"].ToString();
                    Anterior_Re = nomes.Rows[i]["Anterior"].ToString();

                    TextObject txt184 = (TextObject)rpt.ReportDefinition.ReportObjects["Text184"]; //Instancie um objeto do tipo TextObject e informe o nome do textbox
                    txt184.Text = nomes.Rows[i]["Atual"].ToString();
                    Atual_Re = nomes.Rows[i]["Atual"].ToString();

                    TextObject txt182 = (TextObject)rpt.ReportDefinition.ReportObjects["Text182"]; //Instancie um objeto do tipo TextObject e informe o nome do textbox
                    txt182.Text = nomes.Rows[i]["Atraso"].ToString();
                    Atraso_Re = nomes.Rows[i]["Atraso"].ToString();

                    TextObject txt189 = (TextObject)rpt.ReportDefinition.ReportObjects["Text189"]; //Instancie um objeto do tipo TextObject e informe o nome do textbox
                    txt189.Text = nomes.Rows[i]["Observação"].ToString();
                }
                if (contImp == 2)
                {
                    TextObject txt258 = (TextObject)rpt.ReportDefinition.ReportObjects["Text258"]; //Instancie um objeto do tipo TextObject e informe o nome do textbox
                    txt258.Text = nomes.Rows[i]["Nome"].ToString();
                    Nome_Re = nomes.Rows[i]["Nome"].ToString();

                   

                    TextObject txt216 = (TextObject)rpt.ReportDefinition.ReportObjects["Text216"]; //Instancie um objeto do tipo TextObject e informe o nome do textbox
                    txt216.Text = nomes.Rows[i]["Anterior"].ToString();
                    Anterior_Re = nomes.Rows[i]["Anterior"].ToString();

                    TextObject txt217 = (TextObject)rpt.ReportDefinition.ReportObjects["Text217"]; //Instancie um objeto do tipo TextObject e informe o nome do textbox
                    txt217.Text = nomes.Rows[i]["Atual"].ToString();
                    Atual_Re = nomes.Rows[i]["Atual"].ToString();

                    TextObject txt215 = (TextObject)rpt.ReportDefinition.ReportObjects["Text215"]; //Instancie um objeto do tipo TextObject e informe o nome do textbox
                    txt215.Text = nomes.Rows[i]["Atraso"].ToString();
                    Atraso_Re = nomes.Rows[i]["Atraso"].ToString();

                    TextObject txt222 = (TextObject)rpt.ReportDefinition.ReportObjects["Text222"]; //Instancie um objeto do tipo TextObject e informe o nome do textbox
                    txt222.Text = nomes.Rows[i]["Observação"].ToString();
                }
                if (contImp == 3)
                {
                    TextObject txt259 = (TextObject)rpt.ReportDefinition.ReportObjects["Text259"]; //Instancie um objeto do tipo TextObject e informe o nome do textbox
                    txt259.Text = nomes.Rows[i]["Nome"].ToString();
                    Nome_Re = nomes.Rows[i]["Nome"].ToString();

                    TextObject txt249 = (TextObject)rpt.ReportDefinition.ReportObjects["Text249"]; //Instancie um objeto do tipo TextObject e informe o nome do textbox
                    txt249.Text = nomes.Rows[i]["Anterior"].ToString();
                    Anterior_Re = nomes.Rows[i]["Anterior"].ToString();

                    TextObject txt250 = (TextObject)rpt.ReportDefinition.ReportObjects["Text250"]; //Instancie um objeto do tipo TextObject e informe o nome do textbox
                    txt250.Text = nomes.Rows[i]["Atual"].ToString();
                    Atual_Re = nomes.Rows[i]["Atual"].ToString();

                    TextObject txt248 = (TextObject)rpt.ReportDefinition.ReportObjects["Text248"]; //Instancie um objeto do tipo TextObject e informe o nome do textbox
                    txt248.Text = nomes.Rows[i]["Atraso"].ToString();
                    Atraso_Re = nomes.Rows[i]["Atraso"].ToString();

                    TextObject txt255 = (TextObject)rpt.ReportDefinition.ReportObjects["Text255"]; //Instancie um objeto do tipo TextObject e informe o nome do textbox
                    txt255.Text = nomes.Rows[i]["Observação"].ToString();
                }


                //consumo
                TextObject txt119 = (TextObject)rpt.ReportDefinition.ReportObjects["Text119"];
                if (String.IsNullOrEmpty(txt119.Text) == true)
                {
                    txt119.Text = "0";
                }
                TextObject txt185 = (TextObject)rpt.ReportDefinition.ReportObjects["Text185"];
                if (String.IsNullOrEmpty(txt185.Text) == true)
                {
                    txt185.Text = "0";
                }
                TextObject txt218 = (TextObject)rpt.ReportDefinition.ReportObjects["Text218"];
                if (String.IsNullOrEmpty(txt218.Text) == true)
                {
                    txt119.Text = "0";
                }
                TextObject txt251 = (TextObject)rpt.ReportDefinition.ReportObjects["Text251"];
                if (String.IsNullOrEmpty(txt251.Text) == true)
                {
                    txt251.Text = "0";
                }
                
                //contando consumo m³
                if (contImp == 0)
                {
                    TextObject txt118 = (TextObject)rpt.ReportDefinition.ReportObjects["Text118"];
                    TextObject txt117 = (TextObject)rpt.ReportDefinition.ReportObjects["Text117"];
                    txt119.Text = Convert.ToString(Convert.ToInt32(txt118.Text) - Convert.ToInt32(txt117.Text));
                    Consumo_Re = Convert.ToString(Convert.ToInt32(txt118.Text) - Convert.ToInt32(txt117.Text)); 
                }
                if (contImp == 1)
                {
                    TextObject txt184 = (TextObject)rpt.ReportDefinition.ReportObjects["Text184"];
                    TextObject txt183 = (TextObject)rpt.ReportDefinition.ReportObjects["Text183"];
                    txt185.Text = Convert.ToString(Convert.ToInt32(txt184.Text) - Convert.ToInt32(txt183.Text));
                    Consumo_Re = Convert.ToString(Convert.ToInt32(txt184.Text) - Convert.ToInt32(txt183.Text)); 
                }
                if (contImp == 2)
                {
                    TextObject txt217 = (TextObject)rpt.ReportDefinition.ReportObjects["Text217"];
                    TextObject txt216 = (TextObject)rpt.ReportDefinition.ReportObjects["Text216"];
                    txt218.Text = Convert.ToString(Convert.ToInt32(txt217.Text) - Convert.ToInt32(txt216.Text));
                    Consumo_Re = Convert.ToString(Convert.ToInt32(txt217.Text) - Convert.ToInt32(txt216.Text));
                }
                if (contImp == 3)
                {
                    TextObject txt250 = (TextObject)rpt.ReportDefinition.ReportObjects["Text250"];
                    TextObject txt249 = (TextObject)rpt.ReportDefinition.ReportObjects["Text249"];
                    txt251.Text = Convert.ToString(Convert.ToInt32(txt250.Text) - Convert.ToInt32(txt249.Text));
                    Consumo_Re = Convert.ToString(Convert.ToInt32(txt250.Text) - Convert.ToInt32(txt249.Text));
                }
                //valor consumo
                string valor1 = config.Rows[0]["Valor_Base"].ToString();
                string valor2 = "0";
                string valor3 = "0";
                string valor4 = "0";
                string resultado = "0";
                int consu = 0;
                if (contImp == 0)
                {
                    consu = Convert.ToInt32(txt119.Text);    
                }
                if (contImp == 1)
                {
                    consu = Convert.ToInt32(txt185.Text);
                }
                if (contImp == 2)
                {
                    consu = Convert.ToInt32(txt218.Text);
                }
                if (contImp == 3)
                {
                    consu = Convert.ToInt32(txt251.Text);
                }
                

                if (consu > 10 && consu <= 30)
                {
                   
                    Double re = Convert.ToDouble(consu - 10) * Convert.ToDouble(config.Rows[0]["Dez_Trinta"].ToString());
                    valor2 = re.ToString("N2");
                    
                   
                }
                if (consu > 30 && consu <= 90)
                {
                    Double re30 = Convert.ToDouble(20) * Convert.ToDouble(config.Rows[0]["Dez_Trinta"].ToString());
                    Double re = Convert.ToDouble(consu - 30) * Convert.ToDouble(config.Rows[0]["Trinta_Noventa"].ToString());
                    re = re + re30;
                    valor3 = re.ToString("N2");
                   

                }
                if (consu > 90)
                {
                    Double re30 = Convert.ToDouble(20) * Convert.ToDouble(config.Rows[0]["Dez_Trinta"].ToString());
                    Double re50 = Convert.ToDouble(50) * Convert.ToDouble(config.Rows[0]["Trinta_Noventa"].ToString());
                    
                    Double re = Convert.ToDouble(consu - 90)  * Convert.ToDouble(config.Rows[0]["Noventa"].ToString());

                    re = re + re30 + re50;
                    valor4 = re.ToString("N2");
                   

                }
                Double rec = Convert.ToDouble(valor1) + Convert.ToDouble(valor2) + Convert.ToDouble(valor3) + Convert.ToDouble(valor4);
                resultado = rec.ToString("N2");
                
                //valor consumo
                if (contImp == 0)
                {
                    TextObject txt110 = (TextObject)rpt.ReportDefinition.ReportObjects["Text110"];
                    txt110.Text = rec.ToString("N2");
                    Valor_Re = rec.ToString("N2");
                }
                if (contImp == 1)
                {
                    TextObject txt176 = (TextObject)rpt.ReportDefinition.ReportObjects["Text176"];
                    txt176.Text = rec.ToString("N2");
                    Valor_Re = rec.ToString("N2");
                }
                if (contImp == 2)
                {
                    TextObject txt209 = (TextObject)rpt.ReportDefinition.ReportObjects["Text209"];
                    txt209.Text = rec.ToString("N2");
                    Valor_Re = rec.ToString("N2");
                }
                if (contImp == 3)
                {
                    TextObject txt242 = (TextObject)rpt.ReportDefinition.ReportObjects["Text242"];
                    txt242.Text = rec.ToString("N2");
                    Valor_Re = rec.ToString("N2");
                }
               
                //pega rateio
                DataTable rateio = DAL.Lista_Rateio();
                string valorRateio = "0";
                if (rateio.Rows.Count > 0)
                {
                    for (int j = 0; j < rateio.Rows.Count; j++)
                    {
                        if (rateio.Rows[j]["Parcelado"].ToString() == "não")
                        {
                            Double rec1 = Convert.ToDouble(resultado) / nomes.Rows.Count + Convert.ToDouble(rateio.Rows[j]["Valor"].ToString());
                            resultado = rec1.ToString("N2");

                            Double rec2 = Convert.ToDouble(valorRateio) / nomes.Rows.Count + Convert.ToDouble(rateio.Rows[j]["Valor"].ToString());
                            valorRateio = rec2.ToString("N2");
                            //exibir rateio
                            if (contImp == 0)
                            {
                                TextObject txt121 = (TextObject)rpt.ReportDefinition.ReportObjects["Text121"];
                                txt121.Text += " - " + rateio.Rows[j]["Descrição"].ToString();    
                            }
                            if (contImp == 1)
                            {
                                TextObject txt187 = (TextObject)rpt.ReportDefinition.ReportObjects["Text187"];
                                txt187.Text += " - " + rateio.Rows[j]["Descrição"].ToString();
                            }
                            if (contImp == 2)
                            {
                                TextObject txt220 = (TextObject)rpt.ReportDefinition.ReportObjects["Text220"];
                                txt220.Text += " - " + rateio.Rows[j]["Descrição"].ToString();
                            }
                            if (contImp == 3)
                            {
                                TextObject txt253 = (TextObject)rpt.ReportDefinition.ReportObjects["Text253"];
                                txt253.Text += " - " + rateio.Rows[j]["Descrição"].ToString();
                            }
                            
                        }
                        if (rateio.Rows[j]["Parcelado"].ToString() == "sim")
                        {
                            DataTable rat_parc = DAL.Lista_Rateio_Parcelado(Convert.ToInt32(rateio.Rows[j]["Id"].ToString()));
                            if (rat_parc.Rows.Count > 0)
                            {
                                Double rec1 = Convert.ToDouble(resultado) + Convert.ToDouble(rat_parc.Rows[0]["Valor"].ToString()) / nomes.Rows.Count;
                                resultado = rec1.ToString("N2");

                                Double rec2 = Convert.ToDouble(valorRateio) + Convert.ToDouble(rat_parc.Rows[0]["Valor"].ToString()) / nomes.Rows.Count;
                                valorRateio = rec2.ToString("N2");
                                //exibir rateio parcelado
                                if (contImp == 0)
                                {
                                    TextObject txt121 = (TextObject)rpt.ReportDefinition.ReportObjects["Text121"];
                                    txt121.Text += "- " + rat_parc.Rows[0]["Descrição"].ToString() + ",Parc. " + rat_parc.Rows[0]["Parcela"].ToString();    
                                }
                                if (contImp == 1)
                                {
                                    TextObject txt187 = (TextObject)rpt.ReportDefinition.ReportObjects["Text187"];
                                    txt187.Text += "- " + rat_parc.Rows[0]["Descrição"].ToString() + ",Parc. " + rat_parc.Rows[0]["Parcela"].ToString();
                                }
                                if (contImp == 2)
                                {
                                    TextObject txt220 = (TextObject)rpt.ReportDefinition.ReportObjects["Text220"];
                                    txt220.Text += "- " + rat_parc.Rows[0]["Descrição"].ToString() + ",Parc. " + rat_parc.Rows[0]["Parcela"].ToString();
                                }
                                if (contImp == 3)
                                {
                                    TextObject txt253 = (TextObject)rpt.ReportDefinition.ReportObjects["Text253"];
                                    txt253.Text += "- " + rat_parc.Rows[0]["Descrição"].ToString() + ",Parc. " + rat_parc.Rows[0]["Parcela"].ToString();
                                }
                                
                            }

                        }
                    }
                }
                //exibir rateio valor
                if (contImp == 0)
                {
                    TextObject txt111 = (TextObject)rpt.ReportDefinition.ReportObjects["Text111"];
                    txt111.Text = valorRateio;
                    Rateio_Re = valorRateio;
                }
                if (contImp == 1)
                {
                    TextObject txt177 = (TextObject)rpt.ReportDefinition.ReportObjects["Text177"];
                    txt177.Text = valorRateio;
                    Rateio_Re = valorRateio;
                }
                if (contImp == 2)
                {
                    TextObject txt210 = (TextObject)rpt.ReportDefinition.ReportObjects["Text210"];
                    txt210.Text = valorRateio;
                    Rateio_Re = valorRateio;
                }
                if (contImp == 3)
                {
                    TextObject txt243 = (TextObject)rpt.ReportDefinition.ReportObjects["Text243"];
                    txt243.Text = valorRateio;
                    Rateio_Re = valorRateio;
                }
                
                string valorTX = "0";
                //tx
                //DataTable tx = DAL.Lista_Nome();

                if (Convert.ToInt32(nomes.Rows[i]["TX_Comercial"].ToString()) >= 1)
                {
                    string taxa = config.Rows[0]["TX_Comercial"].ToString();
                    Double rec1 = Convert.ToDouble(resultado) + (Convert.ToDouble(taxa) * Convert.ToDouble(nomes.Rows[i]["TX_Comercial"].ToString()));
                    resultado = rec1.ToString("N2");


                    Double rec2 = Convert.ToDouble(valorTX) + (Convert.ToDouble(taxa) * Convert.ToDouble(nomes.Rows[i]["TX_Comercial"].ToString()));
                    valorTX = rec2.ToString("N2");
                }

                if (contImp == 0)
                {
                    //valor total //tx
                    TextObject txt113 = (TextObject)rpt.ReportDefinition.ReportObjects["Text113"];
                    txt113.Text = resultado;
                    Total_Re = resultado;

                    TextObject txt112 = (TextObject)rpt.ReportDefinition.ReportObjects["Text112"];
                    txt112.Text = valorTX;
                    TX_Re = valorTX;
                }
                if (contImp == 1)
                {
                    //valor total //tx
                    TextObject txt179 = (TextObject)rpt.ReportDefinition.ReportObjects["Text179"];
                    txt179.Text = resultado;
                    Total_Re = resultado;

                    TextObject txt178 = (TextObject)rpt.ReportDefinition.ReportObjects["Text178"];
                    txt178.Text = valorTX;
                    TX_Re = valorTX;
                }
                if (contImp == 2)
                {
                    //valor total //tx
                    TextObject txt212 = (TextObject)rpt.ReportDefinition.ReportObjects["Text212"];
                    txt212.Text = resultado;
                    Total_Re = resultado;

                    TextObject txt211 = (TextObject)rpt.ReportDefinition.ReportObjects["Text211"];
                    txt211.Text = valorTX;
                    TX_Re = valorTX;
                }
                if (contImp == 3)
                {
                    //valor total //tx
                    TextObject txt245 = (TextObject)rpt.ReportDefinition.ReportObjects["Text245"];
                    txt245.Text = resultado;
                    Total_Re = resultado;

                    TextObject txt244 = (TextObject)rpt.ReportDefinition.ReportObjects["Text244"];
                    txt244.Text = valorTX;
                    TX_Re = valorTX;
                }
               

                //valor com multa
                Double rec3 = Convert.ToDouble(resultado) * Convert.ToDouble("1,0" + config.Rows[0]["Multa"].ToString());
                if (contImp == 0)
                {
                    TextObject txt115 = (TextObject)rpt.ReportDefinition.ReportObjects["Text115"];
                    txt115.Text = rec3.ToString("N2");
                    TotalMulta_Re = rec3.ToString("N2");
                }
                if (contImp == 1)
                {
                    TextObject txt181 = (TextObject)rpt.ReportDefinition.ReportObjects["Text181"];
                    txt181.Text = rec3.ToString("N2");
                    TotalMulta_Re = rec3.ToString("N2");
                }
                if (contImp == 2)
                {
                    TextObject txt214 = (TextObject)rpt.ReportDefinition.ReportObjects["Text214"];
                    txt214.Text = rec3.ToString("N2");
                    TotalMulta_Re = rec3.ToString("N2");
                }
                if (contImp == 3)
                {
                    TextObject txt247 = (TextObject)rpt.ReportDefinition.ReportObjects["Text247"];
                    txt247.Text = rec3.ToString("N2");
                    TotalMulta_Re = rec3.ToString("N2");
                }
                
                termina--;
                
                //relatório
                //************************************************************************************
                //************************************************************************************

                DAL.Cria_Relatorio(Nome_Re,Anterior_Re,Atual_Re,Consumo_Re,Valor_Re,Rateio_Re,TX_Re,Total_Re,TotalMulta_Re,Atraso_Re,"0,00",nomes.Rows[i]["Observação"].ToString(),Mes_Re);

                //************************************************************************************
                //************************************************************************************

                if ( termina == 0)
                {
                    
                    tabControl1.SelectedTab = tabPage3;
                    panel8.VerticalScroll.Value = 0;
                   
                    //*************************
                    //código para imprimir aqui
                    //*************************

                    crystalReportViewer1.ReportSource = rpt;

                    // crystalReportViewer1.PrintReport();
                    rpt.PrintToPrinter(1, false, 0, 0);

                    //*************************
                    //pictureBox27.Visible = false;
                    //Cursor = Cursors.Default;
                    pag++;
                    Form print = new Print("Imprimindo Recibos Pág. " + Convert.ToString(pag));
                    print.ShowDialog();

                    //Preparar campos do relatório
                    //TextObject txt120 = (TextObject)rpt.ReportDefinition.ReportObjects["Text120"]; //Instancie um objeto do tipo TextObject e informe o nome do textbox
                    //txt120.Text = "";
                    TextObject txt256 = (TextObject)rpt.ReportDefinition.ReportObjects["Text256"]; //Instancie um objeto do tipo TextObject e informe o nome do textbox
                    txt256.Text = "";
                    TextObject txt110 = (TextObject)rpt.ReportDefinition.ReportObjects["Text110"]; //Instancie um objeto do tipo TextObject e informe o nome do textbox
                    txt110.Text = "0";
                    TextObject txt111 = (TextObject)rpt.ReportDefinition.ReportObjects["Text111"]; //Instancie um objeto do tipo TextObject e informe o nome do textbox
                    txt111.Text = "0";
                    TextObject txt112 = (TextObject)rpt.ReportDefinition.ReportObjects["Text112"]; //Instancie um objeto do tipo TextObject e informe o nome do textbox
                    txt112.Text = "0";
                    TextObject txt113 = (TextObject)rpt.ReportDefinition.ReportObjects["Text113"]; //Instancie um objeto do tipo TextObject e informe o nome do textbox
                    txt113.Text = "0";
                    TextObject txt114 = (TextObject)rpt.ReportDefinition.ReportObjects["Text114"]; //Instancie um objeto do tipo TextObject e informe o nome do textbox
                    txt114.Text = "0";
                    TextObject txt115 = (TextObject)rpt.ReportDefinition.ReportObjects["Text115"]; //Instancie um objeto do tipo TextObject e informe o nome do textbox
                    txt115.Text = "0";
                    TextObject txt116 = (TextObject)rpt.ReportDefinition.ReportObjects["Text116"]; //Instancie um objeto do tipo TextObject e informe o nome do textbox
                    txt116.Text = "0";
                    TextObject txt121 = (TextObject)rpt.ReportDefinition.ReportObjects["Text121"]; //Instancie um objeto do tipo TextObject e informe o nome do textbox
                    txt121.Text = "";
                    //TextObject txt122 = (TextObject)rpt.ReportDefinition.ReportObjects["Text122"]; //Instancie um objeto do tipo TextObject e informe o nome do textbox
                    //txt122.Text = "";
                    TextObject txt123 = (TextObject)rpt.ReportDefinition.ReportObjects["Text123"]; //Instancie um objeto do tipo TextObject e informe o nome do textbox
                    txt123.Text = "";
                    TextObject txt117 = (TextObject)rpt.ReportDefinition.ReportObjects["Text117"]; //Instancie um objeto do tipo TextObject e informe o nome do textbox
                    txt117.Text = "0";
                    TextObject txt118 = (TextObject)rpt.ReportDefinition.ReportObjects["Text118"]; //Instancie um objeto do tipo TextObject e informe o nome do textbox
                    txt118.Text = "0";
                    //TextObject txt119 = (TextObject)rpt.ReportDefinition.ReportObjects["Text119"]; //Instancie um objeto do tipo TextObject e informe o nome do textbox
                    txt119.Text = "0";

                    //TextObject txt186 = (TextObject)rpt.ReportDefinition.ReportObjects["Text186"]; //Instancie um objeto do tipo TextObject e informe o nome do textbox
                    //txt186.Text = "";
                    TextObject txt257 = (TextObject)rpt.ReportDefinition.ReportObjects["Text257"]; //Instancie um objeto do tipo TextObject e informe o nome do textbox
                    txt257.Text = "";
                    TextObject txt176 = (TextObject)rpt.ReportDefinition.ReportObjects["Text176"]; //Instancie um objeto do tipo TextObject e informe o nome do textbox
                    txt176.Text = "0";
                    TextObject txt177 = (TextObject)rpt.ReportDefinition.ReportObjects["Text177"]; //Instancie um objeto do tipo TextObject e informe o nome do textbox
                    txt177.Text = "0";
                    TextObject txt178 = (TextObject)rpt.ReportDefinition.ReportObjects["Text178"]; //Instancie um objeto do tipo TextObject e informe o nome do textbox
                    txt178.Text = "0";
                    TextObject txt179 = (TextObject)rpt.ReportDefinition.ReportObjects["Text179"]; //Instancie um objeto do tipo TextObject e informe o nome do textbox
                    txt179.Text = "0";
                    TextObject txt180 = (TextObject)rpt.ReportDefinition.ReportObjects["Text180"]; //Instancie um objeto do tipo TextObject e informe o nome do textbox
                    txt180.Text = "0";
                    TextObject txt181 = (TextObject)rpt.ReportDefinition.ReportObjects["Text181"]; //Instancie um objeto do tipo TextObject e informe o nome do textbox
                    txt181.Text = "0";
                    TextObject txt182 = (TextObject)rpt.ReportDefinition.ReportObjects["Text182"]; //Instancie um objeto do tipo TextObject e informe o nome do textbox
                    txt182.Text = "0";
                    TextObject txt187 = (TextObject)rpt.ReportDefinition.ReportObjects["Text187"]; //Instancie um objeto do tipo TextObject e informe o nome do textbox
                    txt187.Text = "";
                    //TextObject txt188 = (TextObject)rpt.ReportDefinition.ReportObjects["Text188"]; //Instancie um objeto do tipo TextObject e informe o nome do textbox
                    //txt188.Text = "";
                    TextObject txt189 = (TextObject)rpt.ReportDefinition.ReportObjects["Text189"]; //Instancie um objeto do tipo TextObject e informe o nome do textbox
                    txt189.Text = "";
                    TextObject txt183 = (TextObject)rpt.ReportDefinition.ReportObjects["Text183"]; //Instancie um objeto do tipo TextObject e informe o nome do textbox
                    txt183.Text = "0";
                    TextObject txt184 = (TextObject)rpt.ReportDefinition.ReportObjects["Text184"]; //Instancie um objeto do tipo TextObject e informe o nome do textbox
                    txt184.Text = "0";
                    //TextObject txt185 = (TextObject)rpt.ReportDefinition.ReportObjects["Text185"]; //Instancie um objeto do tipo TextObject e informe o nome do textbox
                    txt185.Text = "0";


                    //TextObject txt219 = (TextObject)rpt.ReportDefinition.ReportObjects["Text219"]; //Instancie um objeto do tipo TextObject e informe o nome do textbox
                    //txt219.Text = "";
                    TextObject txt258 = (TextObject)rpt.ReportDefinition.ReportObjects["Text258"]; //Instancie um objeto do tipo TextObject e informe o nome do textbox
                    txt258.Text = "";
                    TextObject txt209 = (TextObject)rpt.ReportDefinition.ReportObjects["Text209"]; //Instancie um objeto do tipo TextObject e informe o nome do textbox
                    txt209.Text = "0";
                    TextObject txt210 = (TextObject)rpt.ReportDefinition.ReportObjects["Text210"]; //Instancie um objeto do tipo TextObject e informe o nome do textbox
                    txt210.Text = "0";
                    TextObject txt211 = (TextObject)rpt.ReportDefinition.ReportObjects["Text211"]; //Instancie um objeto do tipo TextObject e informe o nome do textbox
                    txt211.Text = "0";
                    TextObject txt212 = (TextObject)rpt.ReportDefinition.ReportObjects["Text212"]; //Instancie um objeto do tipo TextObject e informe o nome do textbox
                    txt212.Text = "0";
                    TextObject txt213 = (TextObject)rpt.ReportDefinition.ReportObjects["Text213"]; //Instancie um objeto do tipo TextObject e informe o nome do textbox
                    txt213.Text = "0";
                    TextObject txt214 = (TextObject)rpt.ReportDefinition.ReportObjects["Text214"]; //Instancie um objeto do tipo TextObject e informe o nome do textbox
                    txt214.Text = "0";
                    TextObject txt215 = (TextObject)rpt.ReportDefinition.ReportObjects["Text215"]; //Instancie um objeto do tipo TextObject e informe o nome do textbox
                    txt215.Text = "0";
                    TextObject txt220 = (TextObject)rpt.ReportDefinition.ReportObjects["Text220"]; //Instancie um objeto do tipo TextObject e informe o nome do textbox
                    txt220.Text = "";
                    //TextObject txt221 = (TextObject)rpt.ReportDefinition.ReportObjects["Text221"]; //Instancie um objeto do tipo TextObject e informe o nome do textbox
                    //txt221.Text = "";
                    TextObject txt222 = (TextObject)rpt.ReportDefinition.ReportObjects["Text222"]; //Instancie um objeto do tipo TextObject e informe o nome do textbox
                    txt222.Text = "";
                    TextObject txt216 = (TextObject)rpt.ReportDefinition.ReportObjects["Text216"]; //Instancie um objeto do tipo TextObject e informe o nome do textbox
                    txt216.Text = "0";
                    TextObject txt217 = (TextObject)rpt.ReportDefinition.ReportObjects["Text217"]; //Instancie um objeto do tipo TextObject e informe o nome do textbox
                    txt217.Text = "0";
                    //TextObject txt218 = (TextObject)rpt.ReportDefinition.ReportObjects["Text218"]; //Instancie um objeto do tipo TextObject e informe o nome do textbox
                    txt218.Text = "0";


                    //TextObject txt252 = (TextObject)rpt.ReportDefinition.ReportObjects["Text252"]; //Instancie um objeto do tipo TextObject e informe o nome do textbox
                    //txt252.Text = "";
                    TextObject txt259 = (TextObject)rpt.ReportDefinition.ReportObjects["Text259"]; //Instancie um objeto do tipo TextObject e informe o nome do textbox
                    txt259.Text = "";
                    TextObject txt242 = (TextObject)rpt.ReportDefinition.ReportObjects["Text242"]; //Instancie um objeto do tipo TextObject e informe o nome do textbox
                    txt242.Text = "0";
                    TextObject txt243 = (TextObject)rpt.ReportDefinition.ReportObjects["Text243"]; //Instancie um objeto do tipo TextObject e informe o nome do textbox
                    txt243.Text = "0";
                    TextObject txt244 = (TextObject)rpt.ReportDefinition.ReportObjects["Text244"]; //Instancie um objeto do tipo TextObject e informe o nome do textbox
                    txt244.Text = "0";
                    TextObject txt245 = (TextObject)rpt.ReportDefinition.ReportObjects["Text245"]; //Instancie um objeto do tipo TextObject e informe o nome do textbox
                    txt245.Text = "0";
                    TextObject txt246 = (TextObject)rpt.ReportDefinition.ReportObjects["Text246"]; //Instancie um objeto do tipo TextObject e informe o nome do textbox
                    txt246.Text = "0";
                    TextObject txt247 = (TextObject)rpt.ReportDefinition.ReportObjects["Text247"]; //Instancie um objeto do tipo TextObject e informe o nome do textbox
                    txt247.Text = "0";
                    TextObject txt248 = (TextObject)rpt.ReportDefinition.ReportObjects["Text248"]; //Instancie um objeto do tipo TextObject e informe o nome do textbox
                    txt248.Text = "0";
                    TextObject txt253 = (TextObject)rpt.ReportDefinition.ReportObjects["Text253"]; //Instancie um objeto do tipo TextObject e informe o nome do textbox
                    txt253.Text = "";
                    //TextObject txt254 = (TextObject)rpt.ReportDefinition.ReportObjects["Text254"]; //Instancie um objeto do tipo TextObject e informe o nome do textbox
                    //txt254.Text = "";
                    TextObject txt255 = (TextObject)rpt.ReportDefinition.ReportObjects["Text255"]; //Instancie um objeto do tipo TextObject e informe o nome do textbox
                    txt255.Text = "";
                    TextObject txt249 = (TextObject)rpt.ReportDefinition.ReportObjects["Text249"]; //Instancie um objeto do tipo TextObject e informe o nome do textbox
                    txt249.Text = "0";
                    TextObject txt250 = (TextObject)rpt.ReportDefinition.ReportObjects["Text250"]; //Instancie um objeto do tipo TextObject e informe o nome do textbox
                    txt250.Text = "0";
                    //TextObject txt251 = (TextObject)rpt.ReportDefinition.ReportObjects["Text251"]; //Instancie um objeto do tipo TextObject e informe o nome do textbox
                    txt251.Text = "0";



                    //********************************************************************************
                    //********************************************************************************
                    //crystalReportViewer1.ReportSource = rpt;

                    contImp = 0;

                    //********************************************************************************
                    //********************************************************************************
                    //********************************************************************************
                    //imprimir relatório
                    //********************************************************************************
                    //********************************************************************************
                    
                    

                    TextObject txt42 = (TextObject)rpt1.ReportDefinition.ReportObjects["Text42"]; //Instancie um objeto do tipo TextObject e informe o nome do textbox
                    txt42.Text = "";
                    TextObject txt43 = (TextObject)rpt1.ReportDefinition.ReportObjects["Text43"]; //Instancie um objeto do tipo TextObject e informe o nome do textbox
                    txt43.Text = "";
                    TextObject txt44 = (TextObject)rpt1.ReportDefinition.ReportObjects["Text44"]; //Instancie um objeto do tipo TextObject e informe o nome do textbox
                    txt44.Text = "";
                    TextObject txt1 = (TextObject)rpt1.ReportDefinition.ReportObjects["Text1"]; //Instancie um objeto do tipo TextObject e informe o nome do textbox
                    txt1.Text = "";
                    TextObject txt4 = (TextObject)rpt1.ReportDefinition.ReportObjects["Text4"]; //Instancie um objeto do tipo TextObject e informe o nome do textbox
                    txt4.Text = "";
                    TextObject txt14 = (TextObject)rpt1.ReportDefinition.ReportObjects["Text14"]; //Instancie um objeto do tipo TextObject e informe o nome do textbox
                    txt14.Text = "";
                    TextObject txt17 = (TextObject)rpt1.ReportDefinition.ReportObjects["Text17"]; //Instancie um objeto do tipo TextObject e informe o nome do textbox
                    txt17.Text = "";
                    TextObject txt27 = (TextObject)rpt1.ReportDefinition.ReportObjects["Text27"]; //Instancie um objeto do tipo TextObject e informe o nome do textbox
                    txt27.Text = "";
                    TextObject txt28 = (TextObject)rpt1.ReportDefinition.ReportObjects["Text28"]; //Instancie um objeto do tipo TextObject e informe o nome do textbox
                    txt28.Text = "";
                    TextObject txt29 = (TextObject)rpt1.ReportDefinition.ReportObjects["Text29"]; //Instancie um objeto do tipo TextObject e informe o nome do textbox
                    txt29.Text = "";
                    TextObject txt30 = (TextObject)rpt1.ReportDefinition.ReportObjects["Text30"]; //Instancie um objeto do tipo TextObject e informe o nome do textbox
                    txt30.Text = "";
                    TextObject txt31 = (TextObject)rpt1.ReportDefinition.ReportObjects["Text31"]; //Instancie um objeto do tipo TextObject e informe o nome do textbox
                    txt31.Text = "";
                    TextObject txt32 = (TextObject)rpt1.ReportDefinition.ReportObjects["Text32"]; //Instancie um objeto do tipo TextObject e informe o nome do textbox
                    txt32.Text = "";
                    TextObject txt33 = (TextObject)rpt1.ReportDefinition.ReportObjects["Text33"]; //Instancie um objeto do tipo TextObject e informe o nome do textbox
                    txt33.Text = "";
                    TextObject txt34 = (TextObject)rpt1.ReportDefinition.ReportObjects["Text34"]; //Instancie um objeto do tipo TextObject e informe o nome do textbox
                    txt34.Text = "";
                    TextObject txt35 = (TextObject)rpt1.ReportDefinition.ReportObjects["Text35"]; //Instancie um objeto do tipo TextObject e informe o nome do textbox
                    txt35.Text = "";
                    TextObject txt36 = (TextObject)rpt1.ReportDefinition.ReportObjects["Text36"]; //Instancie um objeto do tipo TextObject e informe o nome do textbox
                    txt36.Text = "";
                    TextObject txt37 = (TextObject)rpt1.ReportDefinition.ReportObjects["Text37"]; //Instancie um objeto do tipo TextObject e informe o nome do textbox
                    txt37.Text = "";
                    TextObject txt38 = (TextObject)rpt1.ReportDefinition.ReportObjects["Text38"]; //Instancie um objeto do tipo TextObject e informe o nome do textbox
                    txt38.Text = "";
                    TextObject txt39 = (TextObject)rpt1.ReportDefinition.ReportObjects["Text39"]; //Instancie um objeto do tipo TextObject e informe o nome do textbox
                    txt39.Text = "";
                    TextObject txt40 = (TextObject)rpt1.ReportDefinition.ReportObjects["Text40"]; //Instancie um objeto do tipo TextObject e informe o nome do textbox
                    txt40.Text = "";
                    TextObject txt41 = (TextObject)rpt1.ReportDefinition.ReportObjects["Text41"]; //Instancie um objeto do tipo TextObject e informe o nome do textbox
                    txt41.Text = "";
                    TextObject txt45 = (TextObject)rpt1.ReportDefinition.ReportObjects["Text45"]; //Instancie um objeto do tipo TextObject e informe o nome do textbox
                    txt45.Text = "";
                    TextObject txt46 = (TextObject)rpt1.ReportDefinition.ReportObjects["Text46"]; //Instancie um objeto do tipo TextObject e informe o nome do textbox
                    txt46.Text = "";
                    TextObject txt47 = (TextObject)rpt1.ReportDefinition.ReportObjects["Text47"]; //Instancie um objeto do tipo TextObject e informe o nome do textbox
                    txt47.Text = "";
                    TextObject txt48 = (TextObject)rpt1.ReportDefinition.ReportObjects["Text48"]; //Instancie um objeto do tipo TextObject e informe o nome do textbox
                    txt48.Text = "";
                    TextObject txt51 = (TextObject)rpt1.ReportDefinition.ReportObjects["Text51"]; //Instancie um objeto do tipo TextObject e informe o nome do textbox
                    txt51.Text = "";
                    TextObject txt52 = (TextObject)rpt1.ReportDefinition.ReportObjects["Text52"]; //Instancie um objeto do tipo TextObject e informe o nome do textbox
                    txt52.Text = "";

                    TextObject txt18 = (TextObject)rpt1.ReportDefinition.ReportObjects["Text18"]; //Instancie um objeto do tipo TextObject e informe o nome do textbox
                    txt18.Text = "";
                    TextObject txt49 = (TextObject)rpt1.ReportDefinition.ReportObjects["Text49"]; //Instancie um objeto do tipo TextObject e informe o nome do textbox
                    txt49.Text = "";
                    TextObject txt50 = (TextObject)rpt1.ReportDefinition.ReportObjects["Text50"]; //Instancie um objeto do tipo TextObject e informe o nome do textbox
                    txt50.Text = "";
                    TextObject txt53 = (TextObject)rpt1.ReportDefinition.ReportObjects["Text53"]; //Instancie um objeto do tipo TextObject e informe o nome do textbox
                    txt53.Text = "";
                    TextObject txt54 = (TextObject)rpt1.ReportDefinition.ReportObjects["Text54"]; //Instancie um objeto do tipo TextObject e informe o nome do textbox
                    txt54.Text = "";
                    TextObject txt55 = (TextObject)rpt1.ReportDefinition.ReportObjects["Text55"]; //Instancie um objeto do tipo TextObject e informe o nome do textbox
                    txt55.Text = "";
                    TextObject txt56 = (TextObject)rpt1.ReportDefinition.ReportObjects["Text56"]; //Instancie um objeto do tipo TextObject e informe o nome do textbox
                    txt56.Text = "";
                    TextObject txt57 = (TextObject)rpt1.ReportDefinition.ReportObjects["Text57"]; //Instancie um objeto do tipo TextObject e informe o nome do textbox
                    txt57.Text = "";
                    TextObject txt58 = (TextObject)rpt1.ReportDefinition.ReportObjects["Text58"]; //Instancie um objeto do tipo TextObject e informe o nome do textbox
                    txt58.Text = "";
                    TextObject txt59 = (TextObject)rpt1.ReportDefinition.ReportObjects["Text59"]; //Instancie um objeto do tipo TextObject e informe o nome do textbox
                    txt59.Text = "";
                    TextObject txt60 = (TextObject)rpt1.ReportDefinition.ReportObjects["Text60"]; //Instancie um objeto do tipo TextObject e informe o nome do textbox
                    txt60.Text = "";
                    TextObject txt61 = (TextObject)rpt1.ReportDefinition.ReportObjects["Text61"]; //Instancie um objeto do tipo TextObject e informe o nome do textbox
                    txt61.Text = "";
                    TextObject txt62 = (TextObject)rpt1.ReportDefinition.ReportObjects["Text62"]; //Instancie um objeto do tipo TextObject e informe o nome do textbox
                    txt62.Text = "";
                    TextObject txt63 = (TextObject)rpt1.ReportDefinition.ReportObjects["Text63"]; //Instancie um objeto do tipo TextObject e informe o nome do textbox
                    txt63.Text = "";
                    TextObject txt64 = (TextObject)rpt1.ReportDefinition.ReportObjects["Text64"]; //Instancie um objeto do tipo TextObject e informe o nome do textbox
                    txt64.Text = "";
                    TextObject txt65 = (TextObject)rpt1.ReportDefinition.ReportObjects["Text65"]; //Instancie um objeto do tipo TextObject e informe o nome do textbox
                    txt65.Text = "";
                    TextObject txt66 = (TextObject)rpt1.ReportDefinition.ReportObjects["Text66"]; //Instancie um objeto do tipo TextObject e informe o nome do textbox
                    txt66.Text = "";
                    TextObject txt67 = (TextObject)rpt1.ReportDefinition.ReportObjects["Text67"]; //Instancie um objeto do tipo TextObject e informe o nome do textbox
                    txt67.Text = "";
                    TextObject txt68 = (TextObject)rpt1.ReportDefinition.ReportObjects["Text68"]; //Instancie um objeto do tipo TextObject e informe o nome do textbox
                    txt68.Text = "";
                    TextObject txt69 = (TextObject)rpt1.ReportDefinition.ReportObjects["Text69"]; //Instancie um objeto do tipo TextObject e informe o nome do textbox
                    txt69.Text = "";
                    TextObject txt70 = (TextObject)rpt1.ReportDefinition.ReportObjects["Text70"]; //Instancie um objeto do tipo TextObject e informe o nome do textbox
                    txt70.Text = "";
                    TextObject txt71 = (TextObject)rpt1.ReportDefinition.ReportObjects["Text71"]; //Instancie um objeto do tipo TextObject e informe o nome do textbox
                    txt71.Text = "";
                    TextObject txt72 = (TextObject)rpt1.ReportDefinition.ReportObjects["Text72"]; //Instancie um objeto do tipo TextObject e informe o nome do textbox
                    txt72.Text = "";
                    TextObject txt73 = (TextObject)rpt1.ReportDefinition.ReportObjects["Text73"]; //Instancie um objeto do tipo TextObject e informe o nome do textbox
                    txt73.Text = "";
                    TextObject txt74 = (TextObject)rpt1.ReportDefinition.ReportObjects["Text74"]; //Instancie um objeto do tipo TextObject e informe o nome do textbox
                    txt74.Text = "";
                    TextObject txt75 = (TextObject)rpt1.ReportDefinition.ReportObjects["Text75"]; //Instancie um objeto do tipo TextObject e informe o nome do textbox
                    txt75.Text = "";
                    TextObject txt76 = (TextObject)rpt1.ReportDefinition.ReportObjects["Text76"]; //Instancie um objeto do tipo TextObject e informe o nome do textbox
                    txt76.Text = "";
                    TextObject txt77 = (TextObject)rpt1.ReportDefinition.ReportObjects["Text77"]; //Instancie um objeto do tipo TextObject e informe o nome do textbox
                    txt77.Text = "";

                    TextObject txt19 = (TextObject)rpt1.ReportDefinition.ReportObjects["Text19"]; //Instancie um objeto do tipo TextObject e informe o nome do textbox
                    txt19.Text = "";
                    TextObject txt78 = (TextObject)rpt1.ReportDefinition.ReportObjects["Text78"]; //Instancie um objeto do tipo TextObject e informe o nome do textbox
                    txt78.Text = "";
                    TextObject txt79 = (TextObject)rpt1.ReportDefinition.ReportObjects["Text79"]; //Instancie um objeto do tipo TextObject e informe o nome do textbox
                    txt79.Text = "";
                    TextObject txt80 = (TextObject)rpt1.ReportDefinition.ReportObjects["Text80"]; //Instancie um objeto do tipo TextObject e informe o nome do textbox
                    txt80.Text = "";
                    TextObject txt81 = (TextObject)rpt1.ReportDefinition.ReportObjects["Text81"]; //Instancie um objeto do tipo TextObject e informe o nome do textbox
                    txt81.Text = "";
                    TextObject txt82 = (TextObject)rpt1.ReportDefinition.ReportObjects["Text82"]; //Instancie um objeto do tipo TextObject e informe o nome do textbox
                    txt82.Text = "";
                    TextObject txt83 = (TextObject)rpt1.ReportDefinition.ReportObjects["Text83"]; //Instancie um objeto do tipo TextObject e informe o nome do textbox
                    txt83.Text = "";
                    TextObject txt84 = (TextObject)rpt1.ReportDefinition.ReportObjects["Text84"]; //Instancie um objeto do tipo TextObject e informe o nome do textbox
                    txt84.Text = "";
                    TextObject txt85 = (TextObject)rpt1.ReportDefinition.ReportObjects["Text85"]; //Instancie um objeto do tipo TextObject e informe o nome do textbox
                    txt85.Text = "";
                    TextObject txt86 = (TextObject)rpt1.ReportDefinition.ReportObjects["Text86"]; //Instancie um objeto do tipo TextObject e informe o nome do textbox
                    txt86.Text = "";
                    TextObject txt87 = (TextObject)rpt1.ReportDefinition.ReportObjects["Text87"]; //Instancie um objeto do tipo TextObject e informe o nome do textbox
                    txt87.Text = "";
                    TextObject txt88 = (TextObject)rpt1.ReportDefinition.ReportObjects["Text88"]; //Instancie um objeto do tipo TextObject e informe o nome do textbox
                    txt88.Text = "";
                    TextObject txt89 = (TextObject)rpt1.ReportDefinition.ReportObjects["Text89"]; //Instancie um objeto do tipo TextObject e informe o nome do textbox
                    txt89.Text = "";
                    TextObject txt90 = (TextObject)rpt1.ReportDefinition.ReportObjects["Text90"]; //Instancie um objeto do tipo TextObject e informe o nome do textbox
                    txt90.Text = "";
                    TextObject txt91 = (TextObject)rpt1.ReportDefinition.ReportObjects["Text91"]; //Instancie um objeto do tipo TextObject e informe o nome do textbox
                    txt91.Text = "";
                    TextObject txt92 = (TextObject)rpt1.ReportDefinition.ReportObjects["Text92"]; //Instancie um objeto do tipo TextObject e informe o nome do textbox
                    txt92.Text = "";
                    TextObject txt93 = (TextObject)rpt1.ReportDefinition.ReportObjects["Text93"]; //Instancie um objeto do tipo TextObject e informe o nome do textbox
                    txt93.Text = "";
                    TextObject txt94 = (TextObject)rpt1.ReportDefinition.ReportObjects["Text94"]; //Instancie um objeto do tipo TextObject e informe o nome do textbox
                    txt94.Text = "";
                    TextObject txt95 = (TextObject)rpt1.ReportDefinition.ReportObjects["Text95"]; //Instancie um objeto do tipo TextObject e informe o nome do textbox
                    txt95.Text = "";
                    TextObject txt96 = (TextObject)rpt1.ReportDefinition.ReportObjects["Text96"]; //Instancie um objeto do tipo TextObject e informe o nome do textbox
                    txt96.Text = "";
                    TextObject txt97 = (TextObject)rpt1.ReportDefinition.ReportObjects["Text97"]; //Instancie um objeto do tipo TextObject e informe o nome do textbox
                    txt97.Text = "";
                    TextObject txt98 = (TextObject)rpt1.ReportDefinition.ReportObjects["Text98"]; //Instancie um objeto do tipo TextObject e informe o nome do textbox
                    txt98.Text = "";
                    TextObject txt99 = (TextObject)rpt1.ReportDefinition.ReportObjects["Text99"]; //Instancie um objeto do tipo TextObject e informe o nome do textbox
                    txt99.Text = "";
                    TextObject txt100 = (TextObject)rpt1.ReportDefinition.ReportObjects["Text100"]; //Instancie um objeto do tipo TextObject e informe o nome do textbox
                    txt100.Text = "";
                    TextObject txt101 = (TextObject)rpt1.ReportDefinition.ReportObjects["Text101"]; //Instancie um objeto do tipo TextObject e informe o nome do textbox
                    txt101.Text = "";
                    TextObject txt102 = (TextObject)rpt1.ReportDefinition.ReportObjects["Text102"]; //Instancie um objeto do tipo TextObject e informe o nome do textbox
                    txt102.Text = "";
                    TextObject txt103 = (TextObject)rpt1.ReportDefinition.ReportObjects["Text103"]; //Instancie um objeto do tipo TextObject e informe o nome do textbox
                    txt103.Text = "";
                    TextObject txt104 = (TextObject)rpt1.ReportDefinition.ReportObjects["Text104"]; //Instancie um objeto do tipo TextObject e informe o nome do textbox
                    txt104.Text = "";

                    TextObject txt20 = (TextObject)rpt1.ReportDefinition.ReportObjects["Text20"]; //Instancie um objeto do tipo TextObject e informe o nome do textbox
                    txt20.Text = "";
                    TextObject txt105 = (TextObject)rpt1.ReportDefinition.ReportObjects["Text105"]; //Instancie um objeto do tipo TextObject e informe o nome do textbox
                    txt105.Text = "";
                    TextObject txt106 = (TextObject)rpt1.ReportDefinition.ReportObjects["Text106"]; //Instancie um objeto do tipo TextObject e informe o nome do textbox
                    txt106.Text = "";
                    TextObject txt107 = (TextObject)rpt1.ReportDefinition.ReportObjects["Text107"]; //Instancie um objeto do tipo TextObject e informe o nome do textbox
                    txt107.Text = "";
                    TextObject txt108 = (TextObject)rpt1.ReportDefinition.ReportObjects["Text108"]; //Instancie um objeto do tipo TextObject e informe o nome do textbox
                    txt108.Text = "";
                    TextObject txt109 = (TextObject)rpt1.ReportDefinition.ReportObjects["Text109"]; //Instancie um objeto do tipo TextObject e informe o nome do textbox
                    txt109.Text = "";
                    TextObject txt110_ = (TextObject)rpt1.ReportDefinition.ReportObjects["Text110"]; //Instancie um objeto do tipo TextObject e informe o nome do textbox
                    txt110_.Text = "";
                    TextObject txt111_ = (TextObject)rpt1.ReportDefinition.ReportObjects["Text111"]; //Instancie um objeto do tipo TextObject e informe o nome do textbox
                    txt111_.Text = "";
                    TextObject txt112_ = (TextObject)rpt1.ReportDefinition.ReportObjects["Text112"]; //Instancie um objeto do tipo TextObject e informe o nome do textbox
                    txt112_.Text = "";
                    TextObject txt113_ = (TextObject)rpt1.ReportDefinition.ReportObjects["Text113"]; //Instancie um objeto do tipo TextObject e informe o nome do textbox
                    txt113_.Text = "";
                    TextObject txt114_ = (TextObject)rpt1.ReportDefinition.ReportObjects["Text114"]; //Instancie um objeto do tipo TextObject e informe o nome do textbox
                    txt114_.Text = "";
                    TextObject txt115_ = (TextObject)rpt1.ReportDefinition.ReportObjects["Text115"]; //Instancie um objeto do tipo TextObject e informe o nome do textbox
                    txt115_.Text = "";
                    TextObject txt116_ = (TextObject)rpt1.ReportDefinition.ReportObjects["Text116"]; //Instancie um objeto do tipo TextObject e informe o nome do textbox
                    txt116_.Text = "";
                    TextObject txt117_ = (TextObject)rpt1.ReportDefinition.ReportObjects["Text117"]; //Instancie um objeto do tipo TextObject e informe o nome do textbox
                    txt117_.Text = "";
                    TextObject txt118_ = (TextObject)rpt1.ReportDefinition.ReportObjects["Text118"]; //Instancie um objeto do tipo TextObject e informe o nome do textbox
                    txt118_.Text = "";
                    TextObject txt119_ = (TextObject)rpt1.ReportDefinition.ReportObjects["Text119"]; //Instancie um objeto do tipo TextObject e informe o nome do textbox
                    txt119_.Text = "";
                    TextObject txt120_ = (TextObject)rpt1.ReportDefinition.ReportObjects["Text120"]; //Instancie um objeto do tipo TextObject e informe o nome do textbox
                    txt120_.Text = "";
                    TextObject txt121_ = (TextObject)rpt1.ReportDefinition.ReportObjects["Text121"]; //Instancie um objeto do tipo TextObject e informe o nome do textbox
                    txt121_.Text = "";
                    TextObject txt122_ = (TextObject)rpt1.ReportDefinition.ReportObjects["Text122"]; //Instancie um objeto do tipo TextObject e informe o nome do textbox
                    txt122_.Text = "";
                    TextObject txt123_ = (TextObject)rpt1.ReportDefinition.ReportObjects["Text123"]; //Instancie um objeto do tipo TextObject e informe o nome do textbox
                    txt123_.Text = "";
                    TextObject txt124 = (TextObject)rpt1.ReportDefinition.ReportObjects["Text124"]; //Instancie um objeto do tipo TextObject e informe o nome do textbox
                    txt124.Text = "";
                    TextObject txt125 = (TextObject)rpt1.ReportDefinition.ReportObjects["Text125"]; //Instancie um objeto do tipo TextObject e informe o nome do textbox
                    txt125.Text = "";
                    TextObject txt126 = (TextObject)rpt1.ReportDefinition.ReportObjects["Text126"]; //Instancie um objeto do tipo TextObject e informe o nome do textbox
                    txt126.Text = "";
                    TextObject txt127 = (TextObject)rpt1.ReportDefinition.ReportObjects["Text127"]; //Instancie um objeto do tipo TextObject e informe o nome do textbox
                    txt127.Text = "";
                    TextObject txt128 = (TextObject)rpt1.ReportDefinition.ReportObjects["Text128"]; //Instancie um objeto do tipo TextObject e informe o nome do textbox
                    txt128.Text = "";
                    TextObject txt129 = (TextObject)rpt1.ReportDefinition.ReportObjects["Text129"]; //Instancie um objeto do tipo TextObject e informe o nome do textbox
                    txt129.Text = "";
                    TextObject txt130 = (TextObject)rpt1.ReportDefinition.ReportObjects["Text130"]; //Instancie um objeto do tipo TextObject e informe o nome do textbox
                    txt130.Text = "";
                    TextObject txt131 = (TextObject)rpt1.ReportDefinition.ReportObjects["Text131"]; //Instancie um objeto do tipo TextObject e informe o nome do textbox
                    txt131.Text = "";


                    TextObject txt21 = (TextObject)rpt1.ReportDefinition.ReportObjects["Text21"]; //Instancie um objeto do tipo TextObject e informe o nome do textbox
                    txt21.Text = "";
                    TextObject txt132 = (TextObject)rpt1.ReportDefinition.ReportObjects["Text132"]; //Instancie um objeto do tipo TextObject e informe o nome do textbox
                    txt132.Text = "";
                    TextObject txt133 = (TextObject)rpt1.ReportDefinition.ReportObjects["Text133"]; //Instancie um objeto do tipo TextObject e informe o nome do textbox
                    txt133.Text = "";
                    TextObject txt134 = (TextObject)rpt1.ReportDefinition.ReportObjects["Text134"]; //Instancie um objeto do tipo TextObject e informe o nome do textbox
                    txt134.Text = "";
                    TextObject txt135 = (TextObject)rpt1.ReportDefinition.ReportObjects["Text135"]; //Instancie um objeto do tipo TextObject e informe o nome do textbox
                    txt135.Text = "";
                    TextObject txt136 = (TextObject)rpt1.ReportDefinition.ReportObjects["Text136"]; //Instancie um objeto do tipo TextObject e informe o nome do textbox
                    txt136.Text = "";
                    TextObject txt137 = (TextObject)rpt1.ReportDefinition.ReportObjects["Text137"]; //Instancie um objeto do tipo TextObject e informe o nome do textbox
                    txt137.Text = "";
                    TextObject txt138 = (TextObject)rpt1.ReportDefinition.ReportObjects["Text138"]; //Instancie um objeto do tipo TextObject e informe o nome do textbox
                    txt138.Text = "";
                    TextObject txt139 = (TextObject)rpt1.ReportDefinition.ReportObjects["Text139"]; //Instancie um objeto do tipo TextObject e informe o nome do textbox
                    txt139.Text = "";
                    TextObject txt140 = (TextObject)rpt1.ReportDefinition.ReportObjects["Text140"]; //Instancie um objeto do tipo TextObject e informe o nome do textbox
                    txt140.Text = "";
                    TextObject txt141 = (TextObject)rpt1.ReportDefinition.ReportObjects["Text141"]; //Instancie um objeto do tipo TextObject e informe o nome do textbox
                    txt141.Text = "";
                    TextObject txt142 = (TextObject)rpt1.ReportDefinition.ReportObjects["Text142"]; //Instancie um objeto do tipo TextObject e informe o nome do textbox
                    txt142.Text = "";
                    TextObject txt143 = (TextObject)rpt1.ReportDefinition.ReportObjects["Text143"]; //Instancie um objeto do tipo TextObject e informe o nome do textbox
                    txt143.Text = "";
                    TextObject txt144 = (TextObject)rpt1.ReportDefinition.ReportObjects["Text144"]; //Instancie um objeto do tipo TextObject e informe o nome do textbox
                    txt144.Text = "";
                    TextObject txt145 = (TextObject)rpt1.ReportDefinition.ReportObjects["Text145"]; //Instancie um objeto do tipo TextObject e informe o nome do textbox
                    txt145.Text = "";
                    TextObject txt146 = (TextObject)rpt1.ReportDefinition.ReportObjects["Text146"]; //Instancie um objeto do tipo TextObject e informe o nome do textbox
                    txt146.Text = "";
                    TextObject txt147 = (TextObject)rpt1.ReportDefinition.ReportObjects["Text147"]; //Instancie um objeto do tipo TextObject e informe o nome do textbox
                    txt147.Text = "";
                    TextObject txt148 = (TextObject)rpt1.ReportDefinition.ReportObjects["Text148"]; //Instancie um objeto do tipo TextObject e informe o nome do textbox
                    txt148.Text = "";
                    TextObject txt149 = (TextObject)rpt1.ReportDefinition.ReportObjects["Text149"]; //Instancie um objeto do tipo TextObject e informe o nome do textbox
                    txt149.Text = "";
                    TextObject txt150 = (TextObject)rpt1.ReportDefinition.ReportObjects["Text150"]; //Instancie um objeto do tipo TextObject e informe o nome do textbox
                    txt150.Text = "";
                    TextObject txt151 = (TextObject)rpt1.ReportDefinition.ReportObjects["Text151"]; //Instancie um objeto do tipo TextObject e informe o nome do textbox
                    txt151.Text = "";
                    TextObject txt152 = (TextObject)rpt1.ReportDefinition.ReportObjects["Text152"]; //Instancie um objeto do tipo TextObject e informe o nome do textbox
                    txt152.Text = "";
                    TextObject txt153 = (TextObject)rpt1.ReportDefinition.ReportObjects["Text153"]; //Instancie um objeto do tipo TextObject e informe o nome do textbox
                    txt153.Text = "";
                    TextObject txt154 = (TextObject)rpt1.ReportDefinition.ReportObjects["Text154"]; //Instancie um objeto do tipo TextObject e informe o nome do textbox
                    txt154.Text = "";
                    TextObject txt155 = (TextObject)rpt1.ReportDefinition.ReportObjects["Text155"]; //Instancie um objeto do tipo TextObject e informe o nome do textbox
                    txt155.Text = "";
                    TextObject txt156 = (TextObject)rpt1.ReportDefinition.ReportObjects["Text156"]; //Instancie um objeto do tipo TextObject e informe o nome do textbox
                    txt156.Text = "";
                    TextObject txt157 = (TextObject)rpt1.ReportDefinition.ReportObjects["Text157"]; //Instancie um objeto do tipo TextObject e informe o nome do textbox
                    txt157.Text = "";
                    TextObject txt158 = (TextObject)rpt1.ReportDefinition.ReportObjects["Text158"]; //Instancie um objeto do tipo TextObject e informe o nome do textbox
                    txt158.Text = "";

                    TextObject txt22 = (TextObject)rpt1.ReportDefinition.ReportObjects["Text22"]; //Instancie um objeto do tipo TextObject e informe o nome do textbox
                    txt22.Text = "";
                    TextObject txt159 = (TextObject)rpt1.ReportDefinition.ReportObjects["Text159"]; //Instancie um objeto do tipo TextObject e informe o nome do textbox
                    txt159.Text = "";
                    TextObject txt160 = (TextObject)rpt1.ReportDefinition.ReportObjects["Text160"]; //Instancie um objeto do tipo TextObject e informe o nome do textbox
                    txt160.Text = "";
                    TextObject txt161 = (TextObject)rpt1.ReportDefinition.ReportObjects["Text161"]; //Instancie um objeto do tipo TextObject e informe o nome do textbox
                    txt161.Text = "";
                    TextObject txt162 = (TextObject)rpt1.ReportDefinition.ReportObjects["Text162"]; //Instancie um objeto do tipo TextObject e informe o nome do textbox
                    txt162.Text = "";
                    TextObject txt163 = (TextObject)rpt1.ReportDefinition.ReportObjects["Text163"]; //Instancie um objeto do tipo TextObject e informe o nome do textbox
                    txt163.Text = "";
                    TextObject txt164 = (TextObject)rpt1.ReportDefinition.ReportObjects["Text164"]; //Instancie um objeto do tipo TextObject e informe o nome do textbox
                    txt164.Text = "";
                    TextObject txt165 = (TextObject)rpt1.ReportDefinition.ReportObjects["Text165"]; //Instancie um objeto do tipo TextObject e informe o nome do textbox
                    txt165.Text = "";
                    TextObject txt166 = (TextObject)rpt1.ReportDefinition.ReportObjects["Text166"]; //Instancie um objeto do tipo TextObject e informe o nome do textbox
                    txt166.Text = "";
                    TextObject txt167 = (TextObject)rpt1.ReportDefinition.ReportObjects["Text167"]; //Instancie um objeto do tipo TextObject e informe o nome do textbox
                    txt167.Text = "";
                    TextObject txt168 = (TextObject)rpt1.ReportDefinition.ReportObjects["Text168"]; //Instancie um objeto do tipo TextObject e informe o nome do textbox
                    txt168.Text = "";
                    TextObject txt169 = (TextObject)rpt1.ReportDefinition.ReportObjects["Text169"]; //Instancie um objeto do tipo TextObject e informe o nome do textbox
                    txt169.Text = "";
                    TextObject txt170 = (TextObject)rpt1.ReportDefinition.ReportObjects["Text170"]; //Instancie um objeto do tipo TextObject e informe o nome do textbox
                    txt170.Text = "";
                    TextObject txt171 = (TextObject)rpt1.ReportDefinition.ReportObjects["Text171"]; //Instancie um objeto do tipo TextObject e informe o nome do textbox
                    txt171.Text = "";
                    TextObject txt172 = (TextObject)rpt1.ReportDefinition.ReportObjects["Text172"]; //Instancie um objeto do tipo TextObject e informe o nome do textbox
                    txt172.Text = "";
                    TextObject txt173 = (TextObject)rpt1.ReportDefinition.ReportObjects["Text173"]; //Instancie um objeto do tipo TextObject e informe o nome do textbox
                    txt173.Text = "";
                    TextObject txt174 = (TextObject)rpt1.ReportDefinition.ReportObjects["Text174"]; //Instancie um objeto do tipo TextObject e informe o nome do textbox
                    txt174.Text = "";
                    TextObject txt175 = (TextObject)rpt1.ReportDefinition.ReportObjects["Text175"]; //Instancie um objeto do tipo TextObject e informe o nome do textbox
                    txt175.Text = "";
                    TextObject txt176_ = (TextObject)rpt1.ReportDefinition.ReportObjects["Text176"]; //Instancie um objeto do tipo TextObject e informe o nome do textbox
                    txt176_.Text = "";
                    TextObject txt177_ = (TextObject)rpt1.ReportDefinition.ReportObjects["Text177"]; //Instancie um objeto do tipo TextObject e informe o nome do textbox
                    txt177_.Text = "";
                    TextObject txt178_ = (TextObject)rpt1.ReportDefinition.ReportObjects["Text178"]; //Instancie um objeto do tipo TextObject e informe o nome do textbox
                    txt178_.Text = "";
                    TextObject txt179_ = (TextObject)rpt1.ReportDefinition.ReportObjects["Text179"]; //Instancie um objeto do tipo TextObject e informe o nome do textbox
                    txt179_.Text = "";
                    TextObject txt180_ = (TextObject)rpt1.ReportDefinition.ReportObjects["Text180"]; //Instancie um objeto do tipo TextObject e informe o nome do textbox
                    txt180_.Text = "";
                    TextObject txt181_ = (TextObject)rpt1.ReportDefinition.ReportObjects["Text181"]; //Instancie um objeto do tipo TextObject e informe o nome do textbox
                    txt181_.Text = "";
                    TextObject txt182_ = (TextObject)rpt1.ReportDefinition.ReportObjects["Text182"]; //Instancie um objeto do tipo TextObject e informe o nome do textbox
                    txt182_.Text = "";
                    TextObject txt183_ = (TextObject)rpt1.ReportDefinition.ReportObjects["Text183"]; //Instancie um objeto do tipo TextObject e informe o nome do textbox
                    txt183_.Text = "";
                    TextObject txt184_ = (TextObject)rpt1.ReportDefinition.ReportObjects["Text184"]; //Instancie um objeto do tipo TextObject e informe o nome do textbox
                    txt184_.Text = "";
                    TextObject txt185_ = (TextObject)rpt1.ReportDefinition.ReportObjects["Text185"]; //Instancie um objeto do tipo TextObject e informe o nome do textbox
                    txt185_.Text = "";

                    TextObject txt23 = (TextObject)rpt1.ReportDefinition.ReportObjects["Text23"]; //Instancie um objeto do tipo TextObject e informe o nome do textbox
                    txt23.Text = "";
                    TextObject txt186_ = (TextObject)rpt1.ReportDefinition.ReportObjects["Text186"]; //Instancie um objeto do tipo TextObject e informe o nome do textbox
                    txt186_.Text = "";
                    TextObject txt187_ = (TextObject)rpt1.ReportDefinition.ReportObjects["Text187"]; //Instancie um objeto do tipo TextObject e informe o nome do textbox
                    txt187_.Text = "";
                    TextObject txt188_ = (TextObject)rpt1.ReportDefinition.ReportObjects["Text188"]; //Instancie um objeto do tipo TextObject e informe o nome do textbox
                    txt188_.Text = "";
                    TextObject txt189_ = (TextObject)rpt1.ReportDefinition.ReportObjects["Text189"]; //Instancie um objeto do tipo TextObject e informe o nome do textbox
                    txt189_.Text = "";
                    TextObject txt190 = (TextObject)rpt1.ReportDefinition.ReportObjects["Text190"]; //Instancie um objeto do tipo TextObject e informe o nome do textbox
                    txt190.Text = "";
                    TextObject txt191 = (TextObject)rpt1.ReportDefinition.ReportObjects["Text191"]; //Instancie um objeto do tipo TextObject e informe o nome do textbox
                    txt191.Text = "";
                    TextObject txt192 = (TextObject)rpt1.ReportDefinition.ReportObjects["Text192"]; //Instancie um objeto do tipo TextObject e informe o nome do textbox
                    txt192.Text = "";
                    TextObject txt193 = (TextObject)rpt1.ReportDefinition.ReportObjects["Text193"]; //Instancie um objeto do tipo TextObject e informe o nome do textbox
                    txt193.Text = "";
                    TextObject txt194 = (TextObject)rpt1.ReportDefinition.ReportObjects["Text194"]; //Instancie um objeto do tipo TextObject e informe o nome do textbox
                    txt194.Text = "";
                    TextObject txt195 = (TextObject)rpt1.ReportDefinition.ReportObjects["Text195"]; //Instancie um objeto do tipo TextObject e informe o nome do textbox
                    txt195.Text = "";
                    TextObject txt196 = (TextObject)rpt1.ReportDefinition.ReportObjects["Text196"]; //Instancie um objeto do tipo TextObject e informe o nome do textbox
                    txt196.Text = "";
                    TextObject txt197 = (TextObject)rpt1.ReportDefinition.ReportObjects["Text197"]; //Instancie um objeto do tipo TextObject e informe o nome do textbox
                    txt197.Text = "";
                    TextObject txt198 = (TextObject)rpt1.ReportDefinition.ReportObjects["Text198"]; //Instancie um objeto do tipo TextObject e informe o nome do textbox
                    txt198.Text = "";
                    TextObject txt199 = (TextObject)rpt1.ReportDefinition.ReportObjects["Text199"]; //Instancie um objeto do tipo TextObject e informe o nome do textbox
                    txt199.Text = "";
                    TextObject txt200 = (TextObject)rpt1.ReportDefinition.ReportObjects["Text200"]; //Instancie um objeto do tipo TextObject e informe o nome do textbox
                    txt200.Text = "";
                    TextObject txt201 = (TextObject)rpt1.ReportDefinition.ReportObjects["Text201"]; //Instancie um objeto do tipo TextObject e informe o nome do textbox
                    txt201.Text = "";
                    TextObject txt202 = (TextObject)rpt1.ReportDefinition.ReportObjects["Text202"]; //Instancie um objeto do tipo TextObject e informe o nome do textbox
                    txt202.Text = "";
                    TextObject txt203 = (TextObject)rpt1.ReportDefinition.ReportObjects["Text203"]; //Instancie um objeto do tipo TextObject e informe o nome do textbox
                    txt203.Text = "";
                    TextObject txt204 = (TextObject)rpt1.ReportDefinition.ReportObjects["Text204"]; //Instancie um objeto do tipo TextObject e informe o nome do textbox
                    txt204.Text = "";
                    TextObject txt205 = (TextObject)rpt1.ReportDefinition.ReportObjects["Text205"]; //Instancie um objeto do tipo TextObject e informe o nome do textbox
                    txt205.Text = "";
                    TextObject txt206 = (TextObject)rpt1.ReportDefinition.ReportObjects["Text206"]; //Instancie um objeto do tipo TextObject e informe o nome do textbox
                    txt206.Text = "";
                    TextObject txt207 = (TextObject)rpt1.ReportDefinition.ReportObjects["Text207"]; //Instancie um objeto do tipo TextObject e informe o nome do textbox
                    txt207.Text = "";
                    TextObject txt208 = (TextObject)rpt1.ReportDefinition.ReportObjects["Text208"]; //Instancie um objeto do tipo TextObject e informe o nome do textbox
                    txt208.Text = "";
                    TextObject txt209_ = (TextObject)rpt1.ReportDefinition.ReportObjects["Text209"]; //Instancie um objeto do tipo TextObject e informe o nome do textbox
                    txt209_.Text = "";
                    TextObject txt210_ = (TextObject)rpt1.ReportDefinition.ReportObjects["Text210"]; //Instancie um objeto do tipo TextObject e informe o nome do textbox
                    txt210_.Text = "";
                    TextObject txt211_ = (TextObject)rpt1.ReportDefinition.ReportObjects["Text211"]; //Instancie um objeto do tipo TextObject e informe o nome do textbox
                    txt211_.Text = "";
                    TextObject txt212_ = (TextObject)rpt1.ReportDefinition.ReportObjects["Text212"]; //Instancie um objeto do tipo TextObject e informe o nome do textbox
                    txt212_.Text = "";

                    TextObject txt24 = (TextObject)rpt1.ReportDefinition.ReportObjects["Text24"]; //Instancie um objeto do tipo TextObject e informe o nome do textbox
                    txt24.Text = "";
                    TextObject txt213_ = (TextObject)rpt1.ReportDefinition.ReportObjects["Text213"]; //Instancie um objeto do tipo TextObject e informe o nome do textbox
                    txt213_.Text = "";
                    TextObject txt214_ = (TextObject)rpt1.ReportDefinition.ReportObjects["Text214"]; //Instancie um objeto do tipo TextObject e informe o nome do textbox
                    txt214_.Text = "";
                    TextObject txt215_ = (TextObject)rpt1.ReportDefinition.ReportObjects["Text215"]; //Instancie um objeto do tipo TextObject e informe o nome do textbox
                    txt215_.Text = "";
                    TextObject txt216_ = (TextObject)rpt1.ReportDefinition.ReportObjects["Text216"]; //Instancie um objeto do tipo TextObject e informe o nome do textbox
                    txt216_.Text = "";
                    TextObject txt217_ = (TextObject)rpt1.ReportDefinition.ReportObjects["Text217"]; //Instancie um objeto do tipo TextObject e informe o nome do textbox
                    txt217_.Text = "";
                    TextObject txt218_ = (TextObject)rpt1.ReportDefinition.ReportObjects["Text218"]; //Instancie um objeto do tipo TextObject e informe o nome do textbox
                    txt218_.Text = "";
                    TextObject txt219_ = (TextObject)rpt1.ReportDefinition.ReportObjects["Text219"]; //Instancie um objeto do tipo TextObject e informe o nome do textbox
                    txt219_.Text = "";
                    TextObject txt220_ = (TextObject)rpt1.ReportDefinition.ReportObjects["Text220"]; //Instancie um objeto do tipo TextObject e informe o nome do textbox
                    txt220_.Text = "";
                    TextObject txt221_ = (TextObject)rpt1.ReportDefinition.ReportObjects["Text221"]; //Instancie um objeto do tipo TextObject e informe o nome do textbox
                    txt221_.Text = "";
                    TextObject txt222_ = (TextObject)rpt1.ReportDefinition.ReportObjects["Text222"]; //Instancie um objeto do tipo TextObject e informe o nome do textbox
                    txt222_.Text = "";
                    TextObject txt223 = (TextObject)rpt1.ReportDefinition.ReportObjects["Text223"]; //Instancie um objeto do tipo TextObject e informe o nome do textbox
                    txt223.Text = "";
                    TextObject txt224 = (TextObject)rpt1.ReportDefinition.ReportObjects["Text224"]; //Instancie um objeto do tipo TextObject e informe o nome do textbox
                    txt224.Text = "";
                    TextObject txt225 = (TextObject)rpt1.ReportDefinition.ReportObjects["Text225"]; //Instancie um objeto do tipo TextObject e informe o nome do textbox
                    txt225.Text = "";
                    TextObject txt226 = (TextObject)rpt1.ReportDefinition.ReportObjects["Text226"]; //Instancie um objeto do tipo TextObject e informe o nome do textbox
                    txt226.Text = "";
                    TextObject txt227 = (TextObject)rpt1.ReportDefinition.ReportObjects["Text227"]; //Instancie um objeto do tipo TextObject e informe o nome do textbox
                    txt227.Text = "";
                    TextObject txt228 = (TextObject)rpt1.ReportDefinition.ReportObjects["Text228"]; //Instancie um objeto do tipo TextObject e informe o nome do textbox
                    txt228.Text = "";
                    TextObject txt229 = (TextObject)rpt1.ReportDefinition.ReportObjects["Text229"]; //Instancie um objeto do tipo TextObject e informe o nome do textbox
                    txt229.Text = "";
                    TextObject txt230 = (TextObject)rpt1.ReportDefinition.ReportObjects["Text230"]; //Instancie um objeto do tipo TextObject e informe o nome do textbox
                    txt230.Text = "";
                    TextObject txt231 = (TextObject)rpt1.ReportDefinition.ReportObjects["Text231"]; //Instancie um objeto do tipo TextObject e informe o nome do textbox
                    txt231.Text = "";
                    TextObject txt232 = (TextObject)rpt1.ReportDefinition.ReportObjects["Text232"]; //Instancie um objeto do tipo TextObject e informe o nome do textbox
                    txt232.Text = "";
                    TextObject txt233 = (TextObject)rpt1.ReportDefinition.ReportObjects["Text233"]; //Instancie um objeto do tipo TextObject e informe o nome do textbox
                    txt233.Text = "";
                    TextObject txt234 = (TextObject)rpt1.ReportDefinition.ReportObjects["Text234"]; //Instancie um objeto do tipo TextObject e informe o nome do textbox
                    txt234.Text = "";
                    TextObject txt235 = (TextObject)rpt1.ReportDefinition.ReportObjects["Text235"]; //Instancie um objeto do tipo TextObject e informe o nome do textbox
                    txt235.Text = "";
                    TextObject txt236 = (TextObject)rpt1.ReportDefinition.ReportObjects["Text236"]; //Instancie um objeto do tipo TextObject e informe o nome do textbox
                    txt236.Text = "";
                    TextObject txt237 = (TextObject)rpt1.ReportDefinition.ReportObjects["Text237"]; //Instancie um objeto do tipo TextObject e informe o nome do textbox
                    txt237.Text = "";
                    TextObject txt238 = (TextObject)rpt1.ReportDefinition.ReportObjects["Text238"]; //Instancie um objeto do tipo TextObject e informe o nome do textbox
                    txt238.Text = "";
                    TextObject txt239 = (TextObject)rpt1.ReportDefinition.ReportObjects["Text239"]; //Instancie um objeto do tipo TextObject e informe o nome do textbox
                    txt239.Text = "";

                    TextObject txt25 = (TextObject)rpt1.ReportDefinition.ReportObjects["Text25"]; //Instancie um objeto do tipo TextObject e informe o nome do textbox
                    txt25.Text = "";
                    TextObject txt240 = (TextObject)rpt1.ReportDefinition.ReportObjects["Text240"]; //Instancie um objeto do tipo TextObject e informe o nome do textbox
                    txt240.Text = "";
                    TextObject txt241 = (TextObject)rpt1.ReportDefinition.ReportObjects["Text241"]; //Instancie um objeto do tipo TextObject e informe o nome do textbox
                    txt241.Text = "";
                    TextObject txt242_ = (TextObject)rpt1.ReportDefinition.ReportObjects["Text242"]; //Instancie um objeto do tipo TextObject e informe o nome do textbox
                    txt242_.Text = "";
                    TextObject txt243_ = (TextObject)rpt1.ReportDefinition.ReportObjects["Text243"]; //Instancie um objeto do tipo TextObject e informe o nome do textbox
                    txt243_.Text = "";
                    TextObject txt244_ = (TextObject)rpt1.ReportDefinition.ReportObjects["Text244"]; //Instancie um objeto do tipo TextObject e informe o nome do textbox
                    txt244_.Text = "";
                    TextObject txt245_ = (TextObject)rpt1.ReportDefinition.ReportObjects["Text245"]; //Instancie um objeto do tipo TextObject e informe o nome do textbox
                    txt245_.Text = "";
                    TextObject txt246_ = (TextObject)rpt1.ReportDefinition.ReportObjects["Text246"]; //Instancie um objeto do tipo TextObject e informe o nome do textbox
                    txt246_.Text = "";
                    TextObject txt247_ = (TextObject)rpt1.ReportDefinition.ReportObjects["Text247"]; //Instancie um objeto do tipo TextObject e informe o nome do textbox
                    txt247_.Text = "";
                    TextObject txt248_ = (TextObject)rpt1.ReportDefinition.ReportObjects["Text248"]; //Instancie um objeto do tipo TextObject e informe o nome do textbox
                    txt248_.Text = "";
                    TextObject txt249_ = (TextObject)rpt1.ReportDefinition.ReportObjects["Text249"]; //Instancie um objeto do tipo TextObject e informe o nome do textbox
                    txt249_.Text = "";
                    TextObject txt250_ = (TextObject)rpt1.ReportDefinition.ReportObjects["Text250"]; //Instancie um objeto do tipo TextObject e informe o nome do textbox
                    txt250_.Text = "";
                    TextObject txt251_ = (TextObject)rpt1.ReportDefinition.ReportObjects["Text251"]; //Instancie um objeto do tipo TextObject e informe o nome do textbox
                    txt251_.Text = "";
                    TextObject txt252_ = (TextObject)rpt1.ReportDefinition.ReportObjects["Text252"]; //Instancie um objeto do tipo TextObject e informe o nome do textbox
                    txt252_.Text = "";
                    TextObject txt253_ = (TextObject)rpt1.ReportDefinition.ReportObjects["Text253"]; //Instancie um objeto do tipo TextObject e informe o nome do textbox
                    txt253_.Text = "";
                    TextObject txt254_ = (TextObject)rpt1.ReportDefinition.ReportObjects["Text254"]; //Instancie um objeto do tipo TextObject e informe o nome do textbox
                    txt254_.Text = "";
                    TextObject txt255_ = (TextObject)rpt1.ReportDefinition.ReportObjects["Text255"]; //Instancie um objeto do tipo TextObject e informe o nome do textbox
                    txt255_.Text = "";
                    TextObject txt256_ = (TextObject)rpt1.ReportDefinition.ReportObjects["Text256"]; //Instancie um objeto do tipo TextObject e informe o nome do textbox
                    txt256_.Text = "";
                    TextObject txt257_ = (TextObject)rpt1.ReportDefinition.ReportObjects["Text257"]; //Instancie um objeto do tipo TextObject e informe o nome do textbox
                    txt257_.Text = "";
                    TextObject txt258_ = (TextObject)rpt1.ReportDefinition.ReportObjects["Text258"]; //Instancie um objeto do tipo TextObject e informe o nome do textbox
                    txt258_.Text = "";
                    TextObject txt259_ = (TextObject)rpt1.ReportDefinition.ReportObjects["Text259"]; //Instancie um objeto do tipo TextObject e informe o nome do textbox
                    txt259_.Text = "";
                    TextObject txt260 = (TextObject)rpt1.ReportDefinition.ReportObjects["Text260"]; //Instancie um objeto do tipo TextObject e informe o nome do textbox
                    txt260.Text = "";
                    TextObject txt261 = (TextObject)rpt1.ReportDefinition.ReportObjects["Text261"]; //Instancie um objeto do tipo TextObject e informe o nome do textbox
                    txt261.Text = "";
                    TextObject txt262 = (TextObject)rpt1.ReportDefinition.ReportObjects["Text262"]; //Instancie um objeto do tipo TextObject e informe o nome do textbox
                    txt262.Text = "";
                    TextObject txt263 = (TextObject)rpt1.ReportDefinition.ReportObjects["Text263"]; //Instancie um objeto do tipo TextObject e informe o nome do textbox
                    txt263.Text = "";
                    TextObject txt264 = (TextObject)rpt1.ReportDefinition.ReportObjects["Text264"]; //Instancie um objeto do tipo TextObject e informe o nome do textbox
                    txt264.Text = "";
                    TextObject txt265 = (TextObject)rpt1.ReportDefinition.ReportObjects["Text265"]; //Instancie um objeto do tipo TextObject e informe o nome do textbox
                    txt265.Text = "";
                    TextObject txt266 = (TextObject)rpt1.ReportDefinition.ReportObjects["Text266"]; //Instancie um objeto do tipo TextObject e informe o nome do textbox
                    txt266.Text = "";


                    TextObject txt26 = (TextObject)rpt1.ReportDefinition.ReportObjects["Text26"]; //Instancie um objeto do tipo TextObject e informe o nome do textbox
                    txt26.Text = "0";
                    TextObject txt267 = (TextObject)rpt1.ReportDefinition.ReportObjects["Text267"]; //Instancie um objeto do tipo TextObject e informe o nome do textbox
                    txt267.Text = "0";
                    TextObject txt268 = (TextObject)rpt1.ReportDefinition.ReportObjects["Text268"]; //Instancie um objeto do tipo TextObject e informe o nome do textbox
                    txt268.Text = "0";
                    TextObject txt269 = (TextObject)rpt1.ReportDefinition.ReportObjects["Text269"]; //Instancie um objeto do tipo TextObject e informe o nome do textbox
                    txt269.Text = "0";
                    TextObject txt270 = (TextObject)rpt1.ReportDefinition.ReportObjects["Text270"]; //Instancie um objeto do tipo TextObject e informe o nome do textbox
                    txt270.Text = "0";
                    TextObject txt271 = (TextObject)rpt1.ReportDefinition.ReportObjects["Text271"]; //Instancie um objeto do tipo TextObject e informe o nome do textbox
                    txt271.Text = "0";
                    TextObject txt272 = (TextObject)rpt1.ReportDefinition.ReportObjects["Text272"]; //Instancie um objeto do tipo TextObject e informe o nome do textbox
                    txt272.Text = "0";
                    TextObject txt273 = (TextObject)rpt1.ReportDefinition.ReportObjects["Text273"]; //Instancie um objeto do tipo TextObject e informe o nome do textbox
                    txt273.Text = "0";
                    TextObject txt274 = (TextObject)rpt1.ReportDefinition.ReportObjects["Text274"]; //Instancie um objeto do tipo TextObject e informe o nome do textbox
                    txt274.Text = "0";
                    TextObject txt275 = (TextObject)rpt1.ReportDefinition.ReportObjects["Text275"]; //Instancie um objeto do tipo TextObject e informe o nome do textbox
                    txt275.Text = "0";
                    TextObject txt276 = (TextObject)rpt1.ReportDefinition.ReportObjects["Text276"]; //Instancie um objeto do tipo TextObject e informe o nome do textbox
                    txt276.Text = "0";
                    TextObject txt277 = (TextObject)rpt1.ReportDefinition.ReportObjects["Text277"]; //Instancie um objeto do tipo TextObject e informe o nome do textbox
                    txt277.Text = "0";
                    TextObject txt278 = (TextObject)rpt1.ReportDefinition.ReportObjects["Text278"]; //Instancie um objeto do tipo TextObject e informe o nome do textbox
                    txt278.Text = "0";
                    TextObject txt279 = (TextObject)rpt1.ReportDefinition.ReportObjects["Text279"]; //Instancie um objeto do tipo TextObject e informe o nome do textbox
                    txt279.Text = "0";
                    TextObject txt280 = (TextObject)rpt1.ReportDefinition.ReportObjects["Text280"]; //Instancie um objeto do tipo TextObject e informe o nome do textbox
                    txt280.Text = "0";
                    TextObject txt281 = (TextObject)rpt1.ReportDefinition.ReportObjects["Text281"]; //Instancie um objeto do tipo TextObject e informe o nome do textbox
                    txt281.Text = "0";
                    TextObject txt282 = (TextObject)rpt1.ReportDefinition.ReportObjects["Text282"]; //Instancie um objeto do tipo TextObject e informe o nome do textbox
                    txt282.Text = "0";
                    TextObject txt283 = (TextObject)rpt1.ReportDefinition.ReportObjects["Text283"]; //Instancie um objeto do tipo TextObject e informe o nome do textbox
                    txt283.Text = "0";
                    TextObject txt284 = (TextObject)rpt1.ReportDefinition.ReportObjects["Text284"]; //Instancie um objeto do tipo TextObject e informe o nome do textbox
                    txt284.Text = "0";
                    TextObject txt285 = (TextObject)rpt1.ReportDefinition.ReportObjects["Text285"]; //Instancie um objeto do tipo TextObject e informe o nome do textbox
                    txt285.Text = "0";
                    TextObject txt286 = (TextObject)rpt1.ReportDefinition.ReportObjects["Text286"]; //Instancie um objeto do tipo TextObject e informe o nome do textbox
                    txt286.Text = "0";
                    TextObject txt287 = (TextObject)rpt1.ReportDefinition.ReportObjects["Text287"]; //Instancie um objeto do tipo TextObject e informe o nome do textbox
                    txt287.Text = "0";
                    TextObject txt288 = (TextObject)rpt1.ReportDefinition.ReportObjects["Text288"]; //Instancie um objeto do tipo TextObject e informe o nome do textbox
                    txt288.Text = "0";
                    TextObject txt289 = (TextObject)rpt1.ReportDefinition.ReportObjects["Text289"]; //Instancie um objeto do tipo TextObject e informe o nome do textbox
                    txt289.Text = "0";
                    TextObject txt290 = (TextObject)rpt1.ReportDefinition.ReportObjects["Text290"]; //Instancie um objeto do tipo TextObject e informe o nome do textbox
                    txt290.Text = "0";
                    TextObject txt291 = (TextObject)rpt1.ReportDefinition.ReportObjects["Text291"]; //Instancie um objeto do tipo TextObject e informe o nome do textbox
                    txt291.Text = "0";
                    TextObject txt292 = (TextObject)rpt1.ReportDefinition.ReportObjects["Text292"]; //Instancie um objeto do tipo TextObject e informe o nome do textbox
                    txt292.Text = "0";
                    TextObject txt293 = (TextObject)rpt1.ReportDefinition.ReportObjects["Text293"]; //Instancie um objeto do tipo TextObject e informe o nome do textbox
                    txt293.Text = "0";



                    DataTable mes = DAL.Lista_Mes_Atual();
                    DataTable relat = null;
                    if (mes.Rows.Count > 0)
                    {
                        relat = DAL.Lista_Relatorio3(mes.Rows[0]["Atual"].ToString());
                    }
                    bool imprime = true;
                    int qtde = relat.Rows.Count;
                    int q = 0;
                    while (imprime == true)
                    {

                        //nome

                        if (qtde >= 28)
                        {
                            txt42.Text = relat.Rows[q]["Nome"].ToString();

                            txt43.Text = relat.Rows[q + 1]["Nome"].ToString();
                            txt44.Text = relat.Rows[q + 2]["Nome"].ToString();
                            txt1.Text = relat.Rows[q + 3]["Nome"].ToString();
                            txt4.Text = relat.Rows[q + 4]["Nome"].ToString();
                            txt14.Text = relat.Rows[q + 5]["Nome"].ToString();
                            txt17.Text = relat.Rows[q + 6]["Nome"].ToString();
                            txt27.Text = relat.Rows[q + 7]["Nome"].ToString();
                            txt28.Text = relat.Rows[q + 8]["Nome"].ToString();
                            txt29.Text = relat.Rows[q + 9]["Nome"].ToString();
                            txt30.Text = relat.Rows[q + 10]["Nome"].ToString();
                            txt31.Text = relat.Rows[q + 11]["Nome"].ToString();
                            txt32.Text = relat.Rows[q + 12]["Nome"].ToString();
                            txt33.Text = relat.Rows[q + 13]["Nome"].ToString();
                            txt34.Text = relat.Rows[q + 14]["Nome"].ToString();
                            txt35.Text = relat.Rows[q + 15]["Nome"].ToString();
                            txt36.Text = relat.Rows[q + 16]["Nome"].ToString();
                            txt37.Text = relat.Rows[q + 17]["Nome"].ToString();
                            txt38.Text = relat.Rows[q + 18]["Nome"].ToString();
                            txt39.Text = relat.Rows[q + 19]["Nome"].ToString();
                            txt40.Text = relat.Rows[q + 20]["Nome"].ToString();
                            txt41.Text = relat.Rows[q + 21]["Nome"].ToString();
                            txt45.Text = relat.Rows[q + 22]["Nome"].ToString();
                            txt46.Text = relat.Rows[q + 23]["Nome"].ToString();
                            txt47.Text = relat.Rows[q + 24]["Nome"].ToString();
                            txt48.Text = relat.Rows[q + 25]["Nome"].ToString();
                            txt51.Text = relat.Rows[q + 26]["Nome"].ToString();
                            txt52.Text = relat.Rows[q + 27]["Nome"].ToString();

                            //Anterior
                            txt18.Text = relat.Rows[q]["Anterior"].ToString();
                            txt49.Text = relat.Rows[q + 1]["Anterior"].ToString();
                            txt50.Text = relat.Rows[q + 2]["Anterior"].ToString();
                            txt53.Text = relat.Rows[q + 3]["Anterior"].ToString();
                            txt54.Text = relat.Rows[q + 4]["Anterior"].ToString();
                            txt55.Text = relat.Rows[q + 5]["Anterior"].ToString();
                            txt56.Text = relat.Rows[q + 6]["Anterior"].ToString();
                            txt57.Text = relat.Rows[q + 7]["Anterior"].ToString();
                            txt58.Text = relat.Rows[q + 8]["Anterior"].ToString();
                            txt59.Text = relat.Rows[q + 9]["Anterior"].ToString();
                            txt60.Text = relat.Rows[q + 10]["Anterior"].ToString();
                            txt61.Text = relat.Rows[q + 11]["Anterior"].ToString();
                            txt62.Text = relat.Rows[q + 12]["Anterior"].ToString();
                            txt63.Text = relat.Rows[q + 13]["Anterior"].ToString();
                            txt64.Text = relat.Rows[q + 14]["Anterior"].ToString();
                            txt65.Text = relat.Rows[q + 15]["Anterior"].ToString();
                            txt66.Text = relat.Rows[q + 16]["Anterior"].ToString();
                            txt67.Text = relat.Rows[q + 17]["Anterior"].ToString();
                            txt68.Text = relat.Rows[q + 18]["Anterior"].ToString();
                            txt69.Text = relat.Rows[q + 19]["Anterior"].ToString();
                            txt70.Text = relat.Rows[q + 20]["Anterior"].ToString();
                            txt71.Text = relat.Rows[q + 21]["Anterior"].ToString();
                            txt72.Text = relat.Rows[q + 22]["Anterior"].ToString();
                            txt73.Text = relat.Rows[q + 23]["Anterior"].ToString();
                            txt74.Text = relat.Rows[q + 24]["Anterior"].ToString();
                            txt75.Text = relat.Rows[q + 25]["Anterior"].ToString();
                            txt76.Text = relat.Rows[q + 26]["Anterior"].ToString();
                            txt77.Text = relat.Rows[q + 27]["Anterior"].ToString();

                            //atual
                            txt19.Text = relat.Rows[q]["Atual"].ToString();
                            txt78.Text = relat.Rows[q + 1]["Atual"].ToString();
                            txt79.Text = relat.Rows[q + 2]["Atual"].ToString();
                            txt80.Text = relat.Rows[q + 3]["Atual"].ToString();
                            txt81.Text = relat.Rows[q + 4]["Atual"].ToString();
                            txt82.Text = relat.Rows[q + 5]["Atual"].ToString();
                            txt83.Text = relat.Rows[q + 6]["Atual"].ToString();
                            txt84.Text = relat.Rows[q + 7]["Atual"].ToString();
                            txt85.Text = relat.Rows[q + 8]["Atual"].ToString();
                            txt86.Text = relat.Rows[q + 9]["Atual"].ToString();
                            txt87.Text = relat.Rows[q + 10]["Atual"].ToString();
                            txt88.Text = relat.Rows[q + 11]["Atual"].ToString();
                            txt89.Text = relat.Rows[q + 12]["Atual"].ToString();
                            txt90.Text = relat.Rows[q + 13]["Atual"].ToString();
                            txt91.Text = relat.Rows[q + 14]["Atual"].ToString();
                            txt92.Text = relat.Rows[q + 15]["Atual"].ToString();
                            txt93.Text = relat.Rows[q + 16]["Atual"].ToString();
                            txt94.Text = relat.Rows[q + 17]["Atual"].ToString();
                            txt95.Text = relat.Rows[q + 18]["Atual"].ToString();
                            txt96.Text = relat.Rows[q + 19]["Atual"].ToString();
                            txt97.Text = relat.Rows[q + 20]["Atual"].ToString();
                            txt98.Text = relat.Rows[q + 21]["Atual"].ToString();
                            txt99.Text = relat.Rows[q + 22]["Atual"].ToString();
                            txt100.Text = relat.Rows[q + 23]["Atual"].ToString();
                            txt101.Text = relat.Rows[q + 24]["Atual"].ToString();
                            txt102.Text = relat.Rows[q + 25]["Atual"].ToString();
                            txt103.Text = relat.Rows[q + 26]["Atual"].ToString();
                            txt104.Text = relat.Rows[q + 27]["Atual"].ToString();

                            //consumo
                            txt20.Text = relat.Rows[q]["Cons"].ToString();
                            txt105.Text = relat.Rows[q + 1]["Cons"].ToString();
                            txt106.Text = relat.Rows[q + 2]["Cons"].ToString();
                            txt107.Text = relat.Rows[q + 3]["Cons"].ToString();
                            txt108.Text = relat.Rows[q + 4]["Cons"].ToString();
                            txt109.Text = relat.Rows[q + 5]["Cons"].ToString();
                            txt110_.Text = relat.Rows[q + 6]["Cons"].ToString();
                            txt111_.Text = relat.Rows[q + 7]["Cons"].ToString();
                            txt112_.Text = relat.Rows[q + 8]["Cons"].ToString();
                            txt113_.Text = relat.Rows[q + 9]["Cons"].ToString();
                            txt114_.Text = relat.Rows[q + 10]["Cons"].ToString();
                            txt115_.Text = relat.Rows[q + 11]["Cons"].ToString();
                            txt116_.Text = relat.Rows[q + 12]["Cons"].ToString();
                            txt117_.Text = relat.Rows[q + 13]["Cons"].ToString();
                            txt118_.Text = relat.Rows[q + 14]["Cons"].ToString();
                            txt119_.Text = relat.Rows[q + 15]["Cons"].ToString();
                            txt120_.Text = relat.Rows[q + 16]["Cons"].ToString();
                            txt121_.Text = relat.Rows[q + 17]["Cons"].ToString();
                            txt122_.Text = relat.Rows[q + 18]["Cons"].ToString();
                            txt123_.Text = relat.Rows[q + 19]["Cons"].ToString();
                            txt124.Text = relat.Rows[q + 20]["Cons"].ToString();
                            txt125.Text = relat.Rows[q + 21]["Cons"].ToString();
                            txt126.Text = relat.Rows[q + 22]["Cons"].ToString();
                            txt127.Text = relat.Rows[q + 23]["Cons"].ToString();
                            txt128.Text = relat.Rows[q + 24]["Cons"].ToString();
                            txt129.Text = relat.Rows[q + 25]["Cons"].ToString();
                            txt130.Text = relat.Rows[q + 26]["Cons"].ToString();
                            txt131.Text = relat.Rows[q + 27]["Cons"].ToString();

                            //valor
                            txt21.Text = relat.Rows[q]["Valor"].ToString();
                            txt132.Text = relat.Rows[q + 1]["Valor"].ToString();
                            txt133.Text = relat.Rows[q + 2]["Valor"].ToString();
                            txt134.Text = relat.Rows[q + 3]["Valor"].ToString();
                            txt135.Text = relat.Rows[q + 4]["Valor"].ToString();
                            txt136.Text = relat.Rows[q + 5]["Valor"].ToString();
                            txt137.Text = relat.Rows[q + 6]["Valor"].ToString();
                            txt138.Text = relat.Rows[q + 7]["Valor"].ToString();
                            txt139.Text = relat.Rows[q + 8]["Valor"].ToString();
                            txt140.Text = relat.Rows[q + 9]["Valor"].ToString();
                            txt141.Text = relat.Rows[q + 10]["Valor"].ToString();
                            txt142.Text = relat.Rows[q + 11]["Valor"].ToString();
                            txt143.Text = relat.Rows[q + 12]["Valor"].ToString();
                            txt144.Text = relat.Rows[q + 13]["Valor"].ToString();
                            txt145.Text = relat.Rows[q + 14]["Valor"].ToString();
                            txt146.Text = relat.Rows[q + 15]["Valor"].ToString();
                            txt147.Text = relat.Rows[q + 16]["Valor"].ToString();
                            txt148.Text = relat.Rows[q + 17]["Valor"].ToString();
                            txt149.Text = relat.Rows[q + 18]["Valor"].ToString();
                            txt150.Text = relat.Rows[q + 19]["Valor"].ToString();
                            txt151.Text = relat.Rows[q + 20]["Valor"].ToString();
                            txt152.Text = relat.Rows[q + 21]["Valor"].ToString();
                            txt153.Text = relat.Rows[q + 22]["Valor"].ToString();
                            txt154.Text = relat.Rows[q + 23]["Valor"].ToString();
                            txt155.Text = relat.Rows[q + 24]["Valor"].ToString();
                            txt156.Text = relat.Rows[q + 25]["Valor"].ToString();
                            txt157.Text = relat.Rows[q + 26]["Valor"].ToString();
                            txt158.Text = relat.Rows[q + 27]["Valor"].ToString();

                            //rateio 
                            txt22.Text = relat.Rows[q]["Rat"].ToString();
                            txt159.Text = relat.Rows[q + 1]["Rat"].ToString();
                            txt160.Text = relat.Rows[q + 2]["Rat"].ToString();
                            txt161.Text = relat.Rows[q + 3]["Rat"].ToString();
                            txt162.Text = relat.Rows[q + 4]["Rat"].ToString();
                            txt163.Text = relat.Rows[q + 5]["Rat"].ToString();
                            txt164.Text = relat.Rows[q + 6]["Rat"].ToString();
                            txt165.Text = relat.Rows[q + 7]["Rat"].ToString();
                            txt166.Text = relat.Rows[q + 8]["Rat"].ToString();
                            txt167.Text = relat.Rows[q + 9]["Rat"].ToString();
                            txt168.Text = relat.Rows[q + 10]["Rat"].ToString();
                            txt169.Text = relat.Rows[q + 11]["Rat"].ToString();
                            txt170.Text = relat.Rows[q + 12]["Rat"].ToString();
                            txt171.Text = relat.Rows[q + 13]["Rat"].ToString();
                            txt172.Text = relat.Rows[q + 14]["Rat"].ToString();
                            txt173.Text = relat.Rows[q + 15]["Rat"].ToString();
                            txt174.Text = relat.Rows[q + 16]["Rat"].ToString();
                            txt175.Text = relat.Rows[q + 17]["Rat"].ToString();
                            txt176_.Text = relat.Rows[q + 18]["Rat"].ToString();
                            txt177_.Text = relat.Rows[q + 19]["Rat"].ToString();
                            txt178_.Text = relat.Rows[q + 20]["Rat"].ToString();
                            txt179_.Text = relat.Rows[q + 21]["Rat"].ToString();
                            txt180_.Text = relat.Rows[q + 22]["Rat"].ToString();
                            txt181_.Text = relat.Rows[q + 23]["Rat"].ToString();
                            txt182_.Text = relat.Rows[q + 24]["Rat"].ToString();
                            txt183_.Text = relat.Rows[q + 25]["Rat"].ToString();
                            txt184_.Text = relat.Rows[q + 26]["Rat"].ToString();
                            txt185_.Text = relat.Rows[q + 27]["Rat"].ToString();

                            //tx
                            txt23.Text = relat.Rows[q]["TX"].ToString();
                            txt186_.Text = relat.Rows[q + 1]["TX"].ToString();
                            txt187_.Text = relat.Rows[q + 2]["TX"].ToString();
                            txt188_.Text = relat.Rows[q + 3]["TX"].ToString();
                            txt189_.Text = relat.Rows[q + 4]["TX"].ToString();
                            txt190.Text = relat.Rows[q + 5]["TX"].ToString();
                            txt191.Text = relat.Rows[q + 6]["TX"].ToString();
                            txt192.Text = relat.Rows[q + 7]["TX"].ToString();
                            txt193.Text = relat.Rows[q + 8]["TX"].ToString();
                            txt194.Text = relat.Rows[q + 9]["TX"].ToString();
                            txt195.Text = relat.Rows[q + 10]["TX"].ToString();
                            txt196.Text = relat.Rows[q + 11]["TX"].ToString();
                            txt197.Text = relat.Rows[q + 12]["TX"].ToString();
                            txt198.Text = relat.Rows[q + 13]["TX"].ToString();
                            txt199.Text = relat.Rows[q + 14]["TX"].ToString();
                            txt200.Text = relat.Rows[q + 15]["TX"].ToString();
                            txt201.Text = relat.Rows[q + 16]["TX"].ToString();
                            txt202.Text = relat.Rows[q + 17]["TX"].ToString();
                            txt203.Text = relat.Rows[q + 18]["TX"].ToString();
                            txt204.Text = relat.Rows[q + 19]["TX"].ToString();
                            txt205.Text = relat.Rows[q + 20]["TX"].ToString();
                            txt206.Text = relat.Rows[q + 21]["TX"].ToString();
                            txt207.Text = relat.Rows[q + 22]["TX"].ToString();
                            txt208.Text = relat.Rows[q + 23]["TX"].ToString();
                            txt209_.Text = relat.Rows[q + 24]["TX"].ToString();
                            txt210_.Text = relat.Rows[q + 25]["TX"].ToString();
                            txt211_.Text = relat.Rows[q + 26]["TX"].ToString();
                            txt212_.Text = relat.Rows[q + 27]["TX"].ToString();

                            //total
                            txt24.Text = relat.Rows[q]["Total"].ToString();
                            txt213_.Text = relat.Rows[q + 1]["Total"].ToString();
                            txt214_.Text = relat.Rows[q + 2]["Total"].ToString();
                            txt215_.Text = relat.Rows[q + 3]["Total"].ToString();
                            txt216_.Text = relat.Rows[q + 4]["Total"].ToString();
                            txt217_.Text = relat.Rows[q + 5]["Total"].ToString();
                            txt218_.Text = relat.Rows[q + 6]["Total"].ToString();
                            txt219_.Text = relat.Rows[q + 7]["Total"].ToString();
                            txt220_.Text = relat.Rows[q + 8]["Total"].ToString();
                            txt221_.Text = relat.Rows[q + 9]["Total"].ToString();
                            txt222_.Text = relat.Rows[q + 10]["Total"].ToString();
                            txt223.Text = relat.Rows[q + 11]["Total"].ToString();
                            txt224.Text = relat.Rows[q + 12]["Total"].ToString();
                            txt225.Text = relat.Rows[q + 13]["Total"].ToString();
                            txt226.Text = relat.Rows[q + 14]["Total"].ToString();
                            txt227.Text = relat.Rows[q + 15]["Total"].ToString();
                            txt228.Text = relat.Rows[q + 16]["Total"].ToString();
                            txt229.Text = relat.Rows[q + 17]["Total"].ToString();
                            txt230.Text = relat.Rows[q + 18]["Total"].ToString();
                            txt231.Text = relat.Rows[q + 19]["Total"].ToString();
                            txt232.Text = relat.Rows[q + 20]["Total"].ToString();
                            txt233.Text = relat.Rows[q + 21]["Total"].ToString();
                            txt234.Text = relat.Rows[q + 22]["Total"].ToString();
                            txt235.Text = relat.Rows[q + 23]["Total"].ToString();
                            txt236.Text = relat.Rows[q + 24]["Total"].ToString();
                            txt237.Text = relat.Rows[q + 25]["Total"].ToString();
                            txt238.Text = relat.Rows[q + 26]["Total"].ToString();
                            txt239.Text = relat.Rows[q + 27]["Total"].ToString();

                            //multa
                            txt25.Text = relat.Rows[q]["Multa"].ToString();
                            txt240.Text = relat.Rows[q + 1]["Multa"].ToString();
                            txt241.Text = relat.Rows[q + 2]["Multa"].ToString();
                            txt242_.Text = relat.Rows[q + 3]["Multa"].ToString();
                            txt243_.Text = relat.Rows[q + 4]["Multa"].ToString();
                            txt244_.Text = relat.Rows[q + 5]["Multa"].ToString();
                            txt245_.Text = relat.Rows[q + 6]["Multa"].ToString();
                            txt246_.Text = relat.Rows[q + 7]["Multa"].ToString();
                            txt247_.Text = relat.Rows[q + 8]["Multa"].ToString();
                            txt248_.Text = relat.Rows[q + 9]["Multa"].ToString();
                            txt249_.Text = relat.Rows[q + 10]["Multa"].ToString();
                            txt250_.Text = relat.Rows[q + 11]["Multa"].ToString();
                            txt251_.Text = relat.Rows[q + 12]["Multa"].ToString();
                            txt252_.Text = relat.Rows[q + 13]["Multa"].ToString();
                            txt253_.Text = relat.Rows[q + 14]["Multa"].ToString();
                            txt254_.Text = relat.Rows[q + 15]["Multa"].ToString();
                            txt255_.Text = relat.Rows[q + 16]["Multa"].ToString();
                            txt256_.Text = relat.Rows[q + 17]["Multa"].ToString();
                            txt257_.Text = relat.Rows[q + 18]["Multa"].ToString();
                            txt258_.Text = relat.Rows[q + 19]["Multa"].ToString();
                            txt259_.Text = relat.Rows[q + 20]["Multa"].ToString();
                            txt260.Text = relat.Rows[q + 21]["Multa"].ToString();
                            txt261.Text = relat.Rows[q + 22]["Multa"].ToString();
                            txt262.Text = relat.Rows[q + 23]["Multa"].ToString();
                            txt263.Text = relat.Rows[q + 24]["Multa"].ToString();
                            txt264.Text = relat.Rows[q + 25]["Multa"].ToString();
                            txt265.Text = relat.Rows[q + 26]["Multa"].ToString();
                            txt266.Text = relat.Rows[q + 27]["Multa"].ToString();

                            //atraso
                            txt26.Text = relat.Rows[q]["Atraso"].ToString();
                            if (String.IsNullOrEmpty( relat.Rows[q]["Atraso"].ToString() ) == true)
                            {
                                txt26.Text = "0";
                            }
                            txt267.Text = relat.Rows[q + 1]["Atraso"].ToString();
                            if (String.IsNullOrEmpty(relat.Rows[q + 1]["Atraso"].ToString()) == true)
                            {
                                txt267.Text = "0";
                            }
                            txt268.Text = relat.Rows[q + 2]["Atraso"].ToString();
                            if (String.IsNullOrEmpty(relat.Rows[q + 2]["Atraso"].ToString()) == true)
                            {
                                txt268.Text = "0";
                            }
                            txt269.Text = relat.Rows[q + 3]["Atraso"].ToString();
                            if (String.IsNullOrEmpty(relat.Rows[q + 3]["Atraso"].ToString()) == true)
                            {
                                txt269.Text = "0";
                            }
                            txt270.Text = relat.Rows[q + 4]["Atraso"].ToString();
                            if (String.IsNullOrEmpty(relat.Rows[q + 5]["Atraso"].ToString()) == true)
                            {
                                txt270.Text = "0";
                            }
                            txt271.Text = relat.Rows[q + 5]["Atraso"].ToString();
                            if (String.IsNullOrEmpty(relat.Rows[q + 6]["Atraso"].ToString()) == true)
                            {
                                txt271.Text = "0";
                            }
                            txt272.Text = relat.Rows[q + 6]["Atraso"].ToString();
                            if (String.IsNullOrEmpty(relat.Rows[q + 6]["Atraso"].ToString()) == true)
                            {
                                txt272.Text = "0";
                            }
                            txt273.Text = relat.Rows[q + 7]["Atraso"].ToString();
                            if (String.IsNullOrEmpty(relat.Rows[q + 7]["Atraso"].ToString()) == true)
                            {
                                txt273.Text = "0";
                            }
                            txt274.Text = relat.Rows[q + 8]["Atraso"].ToString();
                            if (String.IsNullOrEmpty(relat.Rows[q + 8]["Atraso"].ToString()) == true)
                            {
                                txt274.Text = "0";
                            }
                            txt275.Text = relat.Rows[q + 9]["Atraso"].ToString();
                            if (String.IsNullOrEmpty(relat.Rows[q + 9]["Atraso"].ToString()) == true)
                            {
                                txt275.Text = "0";
                            }
                            txt276.Text = relat.Rows[q + 10]["Atraso"].ToString();
                            if (String.IsNullOrEmpty(relat.Rows[q + 10]["Atraso"].ToString()) == true)
                            {
                                txt276.Text = "0";
                            }
                            txt277.Text = relat.Rows[q + 11]["Atraso"].ToString();
                            if (String.IsNullOrEmpty(relat.Rows[q + 11]["Atraso"].ToString()) == true)
                            {
                                txt277.Text = "0";
                            }
                            txt278.Text = relat.Rows[q + 12]["Atraso"].ToString();
                            if (String.IsNullOrEmpty(relat.Rows[q + 12]["Atraso"].ToString()) == true)
                            {
                                txt278.Text = "0";
                            }
                            txt279.Text = relat.Rows[q + 13]["Atraso"].ToString();
                            if (String.IsNullOrEmpty(relat.Rows[q + 13]["Atraso"].ToString()) == true)
                            {
                                txt279.Text = "0";
                            }
                            txt280.Text = relat.Rows[q + 14]["Atraso"].ToString();
                            if (String.IsNullOrEmpty(relat.Rows[q + 14]["Atraso"].ToString()) == true)
                            {
                                txt280.Text = "0";
                            }
                            txt281.Text = relat.Rows[q + 15]["Atraso"].ToString();
                            if (String.IsNullOrEmpty(relat.Rows[q + 15]["Atraso"].ToString()) == true)
                            {
                                txt281.Text = "0";
                            }
                            txt282.Text = relat.Rows[q + 16]["Atraso"].ToString();
                            if (String.IsNullOrEmpty(relat.Rows[q + 16]["Atraso"].ToString()) == true)
                            {
                                txt282.Text = "0";
                            }
                            txt283.Text = relat.Rows[q + 17]["Atraso"].ToString();
                            if (String.IsNullOrEmpty(relat.Rows[q + 17]["Atraso"].ToString()) == true)
                            {
                                txt283.Text = "0";
                            }
                            txt284.Text = relat.Rows[q + 18]["Atraso"].ToString();
                            if (String.IsNullOrEmpty(relat.Rows[q + 18]["Atraso"].ToString()) == true)
                            {
                                txt284.Text = "0";
                            }
                            txt285.Text = relat.Rows[q + 19]["Atraso"].ToString();
                            if (String.IsNullOrEmpty(relat.Rows[q + 19]["Atraso"].ToString()) == true)
                            {
                                txt285.Text = "0";
                            }
                            txt286.Text = relat.Rows[q + 20]["Atraso"].ToString();
                            if (String.IsNullOrEmpty(relat.Rows[q + 20]["Atraso"].ToString()) == true)
                            {
                                txt286.Text = "0";
                            }
                            txt287.Text = relat.Rows[q + 21]["Atraso"].ToString();
                            if (String.IsNullOrEmpty(relat.Rows[q + 21]["Atraso"].ToString()) == true)
                            {
                                txt287.Text = "0";
                            }
                            txt288.Text = relat.Rows[q + 22]["Atraso"].ToString();
                            if (String.IsNullOrEmpty(relat.Rows[q + 22]["Atraso"].ToString()) == true)
                            {
                                txt288.Text = "0";
                            }
                            txt289.Text = relat.Rows[q + 23]["Atraso"].ToString();
                            if (String.IsNullOrEmpty(relat.Rows[q + 23]["Atraso"].ToString()) == true)
                            {
                                txt289.Text = "0";
                            }
                            txt290.Text = relat.Rows[q + 24]["Atraso"].ToString();
                            if (String.IsNullOrEmpty(relat.Rows[q + 24]["Atraso"].ToString()) == true)
                            {
                                txt290.Text = "0";
                            }
                            txt291.Text = relat.Rows[q + 25]["Atraso"].ToString();
                            if (String.IsNullOrEmpty(relat.Rows[q + 25]["Atraso"].ToString()) == true)
                            {
                                txt291.Text = "0";
                            }
                            txt292.Text = relat.Rows[q + 26]["Atraso"].ToString();
                            if (String.IsNullOrEmpty(relat.Rows[q + 26]["Atraso"].ToString()) == true)
                            {
                                txt292.Text = "0";
                            }
                            txt293.Text = relat.Rows[q + 27]["Atraso"].ToString();
                            if (String.IsNullOrEmpty(relat.Rows[q + 27]["Atraso"].ToString()) == true)
                            {
                                txt293.Text = "0";
                            }
                        }
                        else
                        {
                            int c = qtde;

                            
                            txt42.Text = "";

                            txt43.Text = "";
                            txt44.Text = "";
                            txt1.Text = "";
                            txt4.Text = "";
                            txt14.Text = "";
                            txt17.Text = "";
                            txt27.Text = "";
                            txt28.Text = "";
                            txt29.Text = "";
                            txt30.Text = "";
                            txt31.Text = "";
                            txt32.Text = "";
                            txt33.Text = "";
                            txt34.Text = "";
                            txt35.Text = "";
                            txt36.Text = "";
                            txt37.Text = "";
                            txt38.Text = "";
                            txt39.Text = "";
                            txt40.Text = "";
                            txt41.Text = "";
                            txt45.Text = "";
                            txt46.Text = "";
                            txt47.Text = "";
                            txt48.Text = "";
                            txt51.Text = "";
                            txt52.Text = "";

                            //Anterior
                            txt18.Text = "";
                            txt49.Text = "";
                            txt50.Text = "";
                            txt53.Text = "";
                            txt54.Text = "";
                            txt55.Text = "";
                            txt56.Text = "";
                            txt57.Text = "";
                            txt58.Text = "";
                            txt59.Text = "";
                            txt60.Text = "";
                            txt61.Text = "";
                            txt62.Text = "";
                            txt63.Text = "";
                            txt64.Text = "";
                            txt65.Text = "";
                            txt66.Text = "";
                            txt67.Text = "";
                            txt68.Text = "";
                            txt69.Text = "";
                            txt70.Text = "";
                            txt71.Text = "";
                            txt72.Text = "";
                            txt73.Text = "";
                            txt74.Text = "";
                            txt75.Text = "";
                            txt76.Text = "";
                            txt77.Text = "";

                            txt19.Text = "";
                            txt78.Text = "";
                            txt79.Text = "";
                            txt80.Text = "";
                            txt81.Text = "";
                            txt82.Text = "";
                            txt83.Text = "";
                            txt84.Text = "";
                            txt85.Text = "";
                            txt86.Text = "";
                            txt87.Text = "";
                            txt88.Text = "";
                            txt89.Text = "";
                            txt90.Text = "";
                            txt91.Text = "";
                            txt92.Text = "";
                            txt93.Text = "";
                            txt94.Text = "";
                            txt95.Text = "";
                            txt96.Text = "";
                            txt97.Text = "";
                            txt98.Text = "";
                            txt99.Text = "";
                            txt100.Text = "";
                            txt101.Text = "";
                            txt102.Text = "";
                            txt103.Text = "";
                            txt104.Text = "";

                            txt20.Text = "";
                            txt105.Text = "";
                            txt106.Text = "";
                            txt107.Text = "";
                            txt108.Text = "";
                            txt109.Text = "";
                            txt110_.Text = "";
                            txt111_.Text = "";
                            txt112_.Text = "";
                            txt113_.Text = "";
                            txt114_.Text = "";
                            txt115_.Text = "";
                            txt116_.Text = "";
                            txt117_.Text = "";
                            txt118_.Text = "";
                            txt119_.Text = "";
                            txt120_.Text = "";
                            txt121_.Text = "";
                            txt122_.Text = "";
                            txt123_.Text = "";
                            txt124.Text = "";
                            txt125.Text = "";
                            txt126.Text = "";
                            txt127.Text = "";
                            txt128.Text = "";
                            txt129.Text = "";
                            txt130.Text = "";
                            txt131.Text = "";


                            txt21.Text = "";
                            txt132.Text = "";
                            txt133.Text = "";
                            txt134.Text = "";
                            txt135.Text = "";
                            txt136.Text = "";
                            txt137.Text = "";
                            txt138.Text = "";
                            txt139.Text = "";
                            txt140.Text = "";
                            txt141.Text = "";
                            txt142.Text = "";
                            txt143.Text = "";
                            txt144.Text = "";
                            txt145.Text = "";
                            txt146.Text = "";
                            txt147.Text = "";
                            txt148.Text = "";
                            txt149.Text = "";
                            txt150.Text = "";
                            txt151.Text = "";
                            txt152.Text = "";
                            txt153.Text = "";
                            txt154.Text = "";
                            txt155.Text = "";
                            txt156.Text = "";
                            txt157.Text = "";
                            txt158.Text = "";

                            txt22.Text = "";
                            txt159.Text = "";
                            txt160.Text = "";
                            txt161.Text = "";
                            txt162.Text = "";
                            txt163.Text = "";
                            txt164.Text = "";
                            txt165.Text = "";
                            txt166.Text = "";
                            txt167.Text = "";
                            txt168.Text = "";
                            txt169.Text = "";
                            txt170.Text = "";
                            txt171.Text = "";
                            txt172.Text = "";
                            txt173.Text = "";
                            txt174.Text = "";
                            txt175.Text = "";
                            txt176_.Text = "";
                            txt177_.Text = "";
                            txt178_.Text = "";
                            txt179_.Text = "";
                            txt180_.Text = "";
                            txt181_.Text = "";
                            txt182_.Text = "";
                            txt183_.Text = "";
                            txt184_.Text = "";
                            txt185_.Text = "";

                            txt23.Text = "";
                            txt186_.Text = "";
                            txt187_.Text = "";
                            txt188_.Text = "";
                            txt189_.Text = "";
                            txt190.Text = "";
                            txt191.Text = "";
                            txt192.Text = "";
                            txt193.Text = "";
                            txt194.Text = "";
                            txt195.Text = "";
                            txt196.Text = "";
                            txt197.Text = "";
                            txt198.Text = "";
                            txt199.Text = "";
                            txt200.Text = "";
                            txt201.Text = "";
                            txt202.Text = "";
                            txt203.Text = "";
                            txt204.Text = "";
                            txt205.Text = "";
                            txt206.Text = "";
                            txt207.Text = "";
                            txt208.Text = "";
                            txt209_.Text = "";
                            txt210_.Text = "";
                            txt211_.Text = "";
                            txt212_.Text = "";

                            txt24.Text = "";
                            txt213_.Text = "";
                            txt214_.Text = "";
                            txt215_.Text = "";
                            txt216_.Text = "";
                            txt217_.Text = "";
                            txt218_.Text = "";
                            txt219_.Text = "";
                            txt220_.Text = "";
                            txt221_.Text = "";
                            txt222_.Text = "";
                            txt223.Text = "";
                            txt224.Text = "";
                            txt225.Text = "";
                            txt226.Text = "";
                            txt227.Text = "";
                            txt228.Text = "";
                            txt229.Text = "";
                            txt230.Text = "";
                            txt231.Text = "";
                            txt232.Text = "";
                            txt233.Text = "";
                            txt234.Text = "";
                            txt235.Text = "";
                            txt236.Text = "";
                            txt237.Text = "";
                            txt238.Text = "";
                            txt239.Text = "";

                            txt25.Text = "";
                            txt240.Text = "";
                            txt241.Text = "";
                            txt242_.Text = "";
                            txt243_.Text = "";
                            txt244_.Text = "";
                            txt245_.Text = "";
                            txt246_.Text = "";
                            txt247_.Text = "";
                            txt248_.Text = "";
                            txt249_.Text = "";
                            txt250_.Text = "";
                            txt251_.Text = "";
                            txt252_.Text = "";
                            txt253_.Text = "";
                            txt254_.Text = "";
                            txt255_.Text = "";
                            txt256_.Text = "";
                            txt257_.Text = "";
                            txt258_.Text = "";
                            txt259_.Text = "";
                            txt260.Text = "";
                            txt261.Text = "";
                            txt262.Text = "";
                            txt263.Text = "";
                            txt264.Text = "";
                            txt265.Text = "";
                            txt266.Text = "";


                            txt26.Text = "0";
                            txt267.Text = "0";
                            txt268.Text = "0";
                            txt269.Text = "0";
                            txt270.Text = "0";
                            txt271.Text = "0";
                            txt272.Text = "0";
                            txt273.Text = "0";
                            txt274.Text = "0";
                            txt275.Text = "0";
                            txt276.Text = "0";
                            txt277.Text = "0";
                            txt278.Text = "0";
                            txt279.Text = "0";
                            txt280.Text = "0";
                            txt281.Text = "0";
                            txt282.Text = "0";
                            txt283.Text = "0";
                            txt284.Text = "0";
                            txt285.Text = "0";
                            txt286.Text = "0";
                            txt287.Text = "0";
                            txt288.Text = "0";
                            txt289.Text = "0";
                            txt290.Text = "0";
                            txt291.Text = "0";
                            txt292.Text = "0";
                            txt293.Text = "0";

                            if (c > 0)
                            {
                                txt42.Text = relat.Rows[q]["Nome"].ToString();
                                
                            }
                               
                            c--;
                            if (c > 0)
                            {
                                txt43.Text = relat.Rows[q + 1]["Nome"].ToString();
                                
                            }
                            
                            c--;
                            if (c > 0)
                            {
                                txt44.Text = relat.Rows[q + 2]["Nome"].ToString();
                            }
                                                        
                            c--;
                            if (c > 0)
                            {
                                txt1.Text = relat.Rows[q + 3]["Nome"].ToString();
                            }
                           
                            c--;
                            if (c > 0)
                            {
                                txt4.Text = relat.Rows[q + 4]["Nome"].ToString();
                            }
                            
                            c--;
                            if (c > 0)
                            {
                                txt14.Text = relat.Rows[q + 5]["Nome"].ToString();
                            }
                            
                            c--;
                            if (c > 0)
                            {
                                txt17.Text = relat.Rows[q + 6]["Nome"].ToString();
                            }
                            
                            c--;
                            if (c > 0)
                            {
                                txt27.Text = relat.Rows[q + 7]["Nome"].ToString();
                            }
                            
                            c--;
                            if (c > 0)
                            {
                                txt28.Text = relat.Rows[q + 8]["Nome"].ToString();
                            }
                            
                            c--;
                            if (c > 0)
                            {
                                txt29.Text = relat.Rows[q + 9]["Nome"].ToString();
                            }
                            
                            c--;
                            if (c > 0)
                            {
                                txt30.Text = relat.Rows[q + 10]["Nome"].ToString();
                            }
                            
                            c--;
                            if (c > 0)
                            {
                                txt31.Text = relat.Rows[q + 11]["Nome"].ToString();
                            }
                            
                            c--;
                            if (c > 0)
                            {
                                txt32.Text = relat.Rows[q + 12]["Nome"].ToString();
                            }
                            
                            c--;
                            if (c > 0)
                            {
                                txt33.Text = relat.Rows[q + 13]["Nome"].ToString();
                            }
                            
                            c--;
                            if (c > 0)
                            {
                                txt34.Text = relat.Rows[q + 14]["Nome"].ToString();
                            }
                            
                            c--;
                            if (c > 0)
                            {
                                txt35.Text = relat.Rows[q + 15]["Nome"].ToString();
                            }
                            
                            c--;
                            if (c > 0)
                            {
                                txt36.Text = relat.Rows[q + 16]["Nome"].ToString();
                            }
                            
                            c--;
                            if (c > 0)
                            {
                                txt37.Text = relat.Rows[q + 17]["Nome"].ToString();
                            }
                            
                            c--;
                            if (c > 0)
                            {
                                txt38.Text = relat.Rows[q + 18]["Nome"].ToString();
                            }
                            
                            c--;
                            if (c > 0)
                            {
                                txt39.Text = relat.Rows[q + 19]["Nome"].ToString();
                            }
                            
                            c--;
                            if (c > 0)
                            {
                                txt40.Text = relat.Rows[q + 20]["Nome"].ToString();
                            }
                            
                            c--;
                            if (c > 0)
                            {
                                txt41.Text = relat.Rows[q + 21]["Nome"].ToString();
                            }
                           
                            c--;
                            if (c > 0)
                            {
                                txt45.Text = relat.Rows[q + 22]["Nome"].ToString();
                            }
                            
                            c--;
                            if (c > 0)
                            {
                                txt46.Text = relat.Rows[q + 23]["Nome"].ToString();
                            }
                            
                            c--;
                            if (c > 0)
                            {
                                txt47.Text = relat.Rows[q + 24]["Nome"].ToString();
                            }
                            
                            c--;
                            if (c > 0)
                            {
                                txt48.Text = relat.Rows[q + 25]["Nome"].ToString();
                            }
                            
                            c--;
                            if (c > 0)
                            {
                                txt51.Text = relat.Rows[q + 26]["Nome"].ToString();
                            }
                            
                            c--;
                            if (c > 0)
                            {
                                txt52.Text = relat.Rows[q + 27]["Nome"].ToString();
                            }


                            c = qtde;
                            //Anterior
                            txt18.Text = relat.Rows[q]["Anterior"].ToString();
                            c--;
                            if (c > 0)
                            {
                                txt49.Text = relat.Rows[q + 1]["Anterior"].ToString();
                            }
                            
                            c--;
                            if (c > 0)
                            {
                                txt50.Text = relat.Rows[q + 2]["Anterior"].ToString();
                            }
                            
                            c--;
                            if (c > 0)
                            {
                                txt53.Text = relat.Rows[q + 3]["Anterior"].ToString();
                            }
                            
                            c--;
                            if (c > 0)
                            {
                                txt54.Text = relat.Rows[q + 4]["Anterior"].ToString();
                            }
                            
                            c--;
                            if (c > 0)
                            {
                                txt55.Text = relat.Rows[q + 5]["Anterior"].ToString();
                            }
                            
                            c--;
                            if (c > 0)
                            {
                                txt56.Text = relat.Rows[q + 6]["Anterior"].ToString();
                            }
                            
                            c--;
                            if (c > 0)
                            {
                                txt57.Text = relat.Rows[q + 7]["Anterior"].ToString();
                            }
                            
                            c--;
                            if (c > 0)
                            {
                                txt58.Text = relat.Rows[q + 8]["Anterior"].ToString();
                            }
                            
                            c--;
                            if (c > 0)
                            {
                                txt59.Text = relat.Rows[q + 9]["Anterior"].ToString();
                            }
                            
                            c--;
                            if (c > 0)
                            {
                                txt60.Text = relat.Rows[q + 10]["Anterior"].ToString();
                            }
                            
                            c--;
                            if (c > 0)
                            {
                                txt61.Text = relat.Rows[q + 11]["Anterior"].ToString();
                            }
                            
                            c--;
                            if (c > 0)
                            {
                                txt62.Text = relat.Rows[q + 12]["Anterior"].ToString();
                            }
                            
                            c--;
                            if (c > 0)
                            {
                                txt63.Text = relat.Rows[q + 13]["Anterior"].ToString();

                            }

                            c--;
                            if (c > 0)
                            {
                                txt64.Text = relat.Rows[q + 14]["Anterior"].ToString();
                            }
                            
                            c--;
                            if (c > 0)
                            {
                                txt65.Text = relat.Rows[q + 15]["Anterior"].ToString();
                            }
                           
                            c--;
                            if (c > 0)
                            {
                                txt66.Text = relat.Rows[q + 16]["Anterior"].ToString();
                            }
                            
                            c--;
                            if (c > 0)
                            {
                                txt67.Text = relat.Rows[q + 17]["Anterior"].ToString();    
                            }
                            
                            c--;
                            if (c > 0)
                            {
                                txt68.Text = relat.Rows[q + 18]["Anterior"].ToString();
                            }
                            
                            c--;
                            if (c > 0)
                            {
                                txt69.Text = relat.Rows[q + 19]["Anterior"].ToString();
                            }
                            
                            c--;
                            if (c > 0)
                            {
                                txt70.Text = relat.Rows[q + 20]["Anterior"].ToString();
                            }
                            
                            c--;
                            if (c > 0)
                            {
                                txt71.Text = relat.Rows[q + 21]["Anterior"].ToString();
                            }
                            
                            c--;
                            if (c > 0)
                            {
                                txt72.Text = relat.Rows[q + 22]["Anterior"].ToString();
                            }
                            
                            c--;
                            if (c > 0)
                            {
                                txt73.Text = relat.Rows[q + 23]["Anterior"].ToString();    
                            }
                            
                            c--;
                            if (c > 0)
                            {
                                txt74.Text = relat.Rows[q + 24]["Anterior"].ToString();
                            }
                            
                            c--;
                            if (c > 0)
                            {
                                txt75.Text = relat.Rows[q + 25]["Anterior"].ToString();
                            }
                            
                            c--;
                            if (c > 0)
                            {
                                txt76.Text = relat.Rows[q + 26]["Anterior"].ToString();
                            }
                            
                            c--;
                            if (c > 0)
                            {
                                txt77.Text = relat.Rows[q + 27]["Anterior"].ToString();
                            }



                            c = qtde;
                            //atual
                            txt19.Text = relat.Rows[q]["Atual"].ToString();
                            c--;
                            if (c > 0)
                            {
                                txt77.Text = relat.Rows[q + 1]["Anterior"].ToString();
                            }
                           
                            c--;
                            if (c > 0)
                            {
                                txt79.Text = relat.Rows[q + 2]["Atual"].ToString();
                            }
                            
                            c--;
                            if (c > 0)
                            {
                                txt80.Text = relat.Rows[q + 3]["Atual"].ToString();
                            }
                            
                            c--;
                            if (c > 0)
                            {
                                txt81.Text = relat.Rows[q + 4]["Atual"].ToString();
                            }
                            
                            c--;
                            if (c > 0)
                            {
                                txt82.Text = relat.Rows[q + 5]["Atual"].ToString();
                            }
                            
                            c--;
                            if (c > 0)
                            {
                                txt83.Text = relat.Rows[q + 6]["Atual"].ToString();
                            }
                            
                            c--;
                            if (c > 0)
                            {
                                txt84.Text = relat.Rows[q + 7]["Atual"].ToString();
                            }
                           
                            c--;
                            if (c > 0)
                            {
                                txt85.Text = relat.Rows[q + 8]["Atual"].ToString();
                            }
                            
                            c--;
                            if (c > 0)
                            {
                                txt86.Text = relat.Rows[q + 9]["Atual"].ToString();
                            }
                            
                            c--;
                            if (c > 0)
                            {
                                txt87.Text = relat.Rows[q + 10]["Atual"].ToString();
                            }
                            
                            c--;
                            if (c > 0)
                            {
                                txt88.Text = relat.Rows[q + 11]["Atual"].ToString();
                            }
                            
                            c--;
                            if (c > 0)
                            {
                                txt89.Text = relat.Rows[q + 12]["Atual"].ToString();
                            }
                            
                            c--;
                            if (c > 0)
                            {
                                txt90.Text = relat.Rows[q + 13]["Atual"].ToString();
                            }
                            
                            c--;
                            if (c > 0)
                            {
                                txt91.Text = relat.Rows[q + 14]["Atual"].ToString();
                            }
                            
                            c--;
                            if (c > 0)
                            {
                                txt92.Text = relat.Rows[q + 15]["Atual"].ToString();
                            }
                           
                            c--;
                            if (c > 0)
                            {
                                txt93.Text = relat.Rows[q + 16]["Atual"].ToString();
                            }
                            
                            c--;
                            if (c > 0)
                            {
                                txt94.Text = relat.Rows[q + 17]["Atual"].ToString();
                            }
                            
                            c--;
                            if (c > 0)
                            {
                                txt95.Text = relat.Rows[q + 18]["Atual"].ToString();
                            }
                            
                            c--;
                            if (c > 0)
                            {
                                txt96.Text = relat.Rows[q + 19]["Atual"].ToString();
                            }
                           
                            c--;
                            if (c > 0)
                            {
                                txt97.Text = relat.Rows[q + 20]["Atual"].ToString();
                            }
                            
                            c--;
                            if (c > 0)
                            {
                                txt98.Text = relat.Rows[q + 21]["Atual"].ToString();
                            }
                            
                            c--;
                            if (c > 0)
                            {
                                txt99.Text = relat.Rows[q + 22]["Atual"].ToString();
                            }
                            
                            c--;
                            if (c > 0)
                            {
                                txt100.Text = relat.Rows[q + 23]["Atual"].ToString();
                            }
                            
                            c--;
                            if (c > 0)
                            {
                                txt101.Text = relat.Rows[q + 24]["Atual"].ToString();
                            }
                            
                            c--;
                            if (c > 0)
                            {
                                txt102.Text = relat.Rows[q + 25]["Atual"].ToString();
                            }
                           
                            c--;
                            if (c > 0)
                            {
                                txt103.Text = relat.Rows[q + 26]["Atual"].ToString();
                            }
                           
                            c--;
                            if (c > 0)
                            {
                                txt104.Text = relat.Rows[q + 27]["Atual"].ToString();
                            }

                            c = qtde;

                            //consumo
                            txt20.Text = relat.Rows[q]["Cons"].ToString();

                            c--;
                            if (c > 0)
                            {
                                txt105.Text = relat.Rows[q + 1]["Cons"].ToString();          
                            }
                            
                            c--;
                            if (c > 0)
                            {
                                txt106.Text = relat.Rows[q + 2]["Cons"].ToString();
                            }
                            
                            c--;
                            if (c > 0)
                            {
                                txt107.Text = relat.Rows[q + 3]["Cons"].ToString();

                            }
                                                        c--;
                            if (c > 0)
                            {
                                txt108.Text = relat.Rows[q + 4]["Cons"].ToString();
                            }
                            
                            c--;
                            if (c > 0)
                            {
                                txt109.Text = relat.Rows[q + 5]["Cons"].ToString();
                            }
                            
                            c--;
                            if (c > 0)
                            {
                                txt110_.Text = relat.Rows[q + 6]["Cons"].ToString();
                            }
                            
                            c--;
                            if (c > 0)
                            {
                                txt111_.Text = relat.Rows[q + 7]["Cons"].ToString();
                            }
                            
                            c--;
                            if (c > 0)
                            {
                                txt112_.Text = relat.Rows[q + 8]["Cons"].ToString();
                            }
                            
                            c--;
                            if (c > 0)
                            {
                                txt113_.Text = relat.Rows[q + 9]["Cons"].ToString();
                            }
                            
                            c--;
                            if (c > 0)
                            {
                                txt114_.Text = relat.Rows[q + 10]["Cons"].ToString();
                            }
                            
                            c--;
                            if (c > 0)
                            {
                                txt115_.Text = relat.Rows[q + 11]["Cons"].ToString();
                            }
                            
                            c--;
                            if (c > 0)
                            {
                                txt116_.Text = relat.Rows[q + 12]["Cons"].ToString();
                            }
                            
                            c--;
                            if (c > 0)
                            {
                                txt117_.Text = relat.Rows[q + 13]["Cons"].ToString();
                            }
                            
                            c--;
                            if (c > 0)
                            {
                                txt118_.Text = relat.Rows[q + 14]["Cons"].ToString();
                            }
                            
                            c--;
                            if (c > 0)
                            {
                                txt119_.Text = relat.Rows[q + 15]["Cons"].ToString();
                            }
                            
                            c--;
                            if (c > 0)
                            {
                                txt120_.Text = relat.Rows[q + 16]["Cons"].ToString();
                            }
                            
                            c--;
                            if (c > 0)
                            {
                                txt121_.Text = relat.Rows[q + 17]["Cons"].ToString();
                            }
                            
                            c--;
                            if (c > 0)
                            {
                                txt122_.Text = relat.Rows[q + 18]["Cons"].ToString();
                            }
                            
                            c--;
                            if (c > 0)
                            {
                                txt123_.Text = relat.Rows[q + 19]["Cons"].ToString();
                            }
                            
                            c--;
                            if (c > 0)
                            {
                                txt124.Text = relat.Rows[q + 20]["Cons"].ToString();
                            }
                            
                            c--;
                            if (c > 0)
                            {
                                txt125.Text = relat.Rows[q + 21]["Cons"].ToString();
                            }
                            
                            c--;
                            if (c > 0)
                            {
                                txt126.Text = relat.Rows[q + 22]["Cons"].ToString();
                            }
                            
                            c--;
                            if (c > 0)
                            {
                                txt127.Text = relat.Rows[q + 23]["Cons"].ToString();
                            }
                            
                            c--;
                            if (c > 0)
                            {
                                txt128.Text = relat.Rows[q + 24]["Cons"].ToString();
                            }
                            
                            c--;
                            if (c > 0)
                            {
                                txt129.Text = relat.Rows[q + 25]["Cons"].ToString();
                            }
                            
                            c--;
                            if (c > 0)
                            {
                                txt130.Text = relat.Rows[q + 26]["Cons"].ToString();
                            }
                           
                            c--;
                            if (c > 0)
                            {
                                txt131.Text = relat.Rows[q + 27]["Cons"].ToString();
                            }
                            

                            c = qtde;
                            //valor
                            txt21.Text = relat.Rows[q]["Valor"].ToString();
                            c--;
                            if (c > 0)
                            {
                                txt132.Text = relat.Rows[q + 1]["Valor"].ToString();
                            }
                            
                            c--;
                            if (c > 0)
                            {
                                txt133.Text = relat.Rows[q + 2]["Valor"].ToString();
                            }
                            
                            c--;
                            if (c > 0)
                            {
                                txt134.Text = relat.Rows[q + 3]["Valor"].ToString();
                            }
                            
                            c--;
                            if (c > 0)
                            {
                                txt135.Text = relat.Rows[q + 4]["Valor"].ToString();
                            }
                            
                            c--;
                            if (c > 0)
                            {
                                txt136.Text = relat.Rows[q + 5]["Valor"].ToString();
                            }
                            
                            c--;
                            if (c > 0)
                            {
                                txt137.Text = relat.Rows[q + 6]["Valor"].ToString();
                            }
                            
                            c--;
                            if (c > 0)
                            {
                                txt138.Text = relat.Rows[q + 7]["Valor"].ToString();
                            }
                            
                            c--;
                            if (c > 0)
                            {
                                txt139.Text = relat.Rows[q + 8]["Valor"].ToString();
                            }
                            
                            c--;
                            if (c > 0)
                            {
                                txt140.Text = relat.Rows[q + 9]["Valor"].ToString();
                            }
                            
                            c--;
                            if (c > 0)
                            {
                                txt141.Text = relat.Rows[q + 10]["Valor"].ToString();
                            }
                            
                            c--;
                            if (c > 0)
                            {
                                txt142.Text = relat.Rows[q + 11]["Valor"].ToString();
                            }
                            
                            c--;
                            if (c > 0)
                            {
                                txt143.Text = relat.Rows[q + 12]["Valor"].ToString();
                            }
                            
                            c--;
                            if (c > 0)
                            {
                                txt144.Text = relat.Rows[q + 13]["Valor"].ToString();
                            }
                            
                            c--;
                            if (c > 0)
                            {
                                txt145.Text = relat.Rows[q + 14]["Valor"].ToString();
                            }
                            
                            c--;
                            if (c > 0)
                            {
                                txt146.Text = relat.Rows[q + 15]["Valor"].ToString();
                            }
                            
                            c--;
                            if (c > 0)
                            {
                                txt147.Text = relat.Rows[q + 16]["Valor"].ToString();
                            }
                            
                            c--;
                            if (c > 0)
                            {
                                txt148.Text = relat.Rows[q + 17]["Valor"].ToString();
                            }
                            
                            c--;
                            if (c > 0)
                            {
                                txt149.Text = relat.Rows[q + 18]["Valor"].ToString();
                            }
                            
                            c--;
                            if (c > 0)
                            {
                                txt150.Text = relat.Rows[q + 19]["Valor"].ToString();
                            }
                            
                            c--;
                            if (c > 0)
                            {
                                txt151.Text = relat.Rows[q + 20]["Valor"].ToString();
                            }
                            
                            c--;
                            if (c > 0)
                            {
                                txt152.Text = relat.Rows[q + 21]["Valor"].ToString();
                            }
                            
                            c--;
                            if (c > 0)
                            {
                                txt153.Text = relat.Rows[q + 22]["Valor"].ToString();
                            }
                            
                            c--;
                            if (c > 0)
                            {
                                txt154.Text = relat.Rows[q + 23]["Valor"].ToString();
                            }
                            
                            c--;
                            if (c > 0)
                            {
                                txt155.Text = relat.Rows[q + 24]["Valor"].ToString();
                            }
                            
                            c--;
                            if (c > 0)
                            {
                                txt156.Text = relat.Rows[q + 25]["Valor"].ToString();
                            }
                            
                            c--;
                            if (c > 0)
                            {
                                txt157.Text = relat.Rows[q + 26]["Valor"].ToString();
                            }
                            
                            c--;
                            if (c > 0)
                            {
                                txt158.Text = relat.Rows[q + 27]["Valor"].ToString();
                            }
                            

                            c = qtde;
                            //rateio 
                            txt22.Text = relat.Rows[q]["Rat"].ToString();
                            c--;
                            if (c > 0)
                            {
                                txt159.Text = relat.Rows[q + 1]["Rat"].ToString();
                            }
                            
                            c--;
                            if (c > 0)
                            {
                                txt160.Text = relat.Rows[q + 2]["Rat"].ToString();
                            }
                            
                            c--;
                            if (c > 0)
                            {
                                txt161.Text = relat.Rows[q + 3]["Rat"].ToString();
                            }
                            
                            c--;
                            if (c > 0)
                            {
                                txt162.Text = relat.Rows[q + 4]["Rat"].ToString();
                            }
                            
                            c--;
                            if (c > 0)
                            {
                                txt163.Text = relat.Rows[q + 5]["Rat"].ToString();
                            }
                            
                            c--;
                            if (c > 0)
                            {
                                txt164.Text = relat.Rows[q + 6]["Rat"].ToString();
                            }
                            
                            c--;
                            if (c > 0)
                            {
                                txt165.Text = relat.Rows[q + 7]["Rat"].ToString();
                            }
                            
                            c--;
                            if (c > 0)
                            {
                                txt166.Text = relat.Rows[q + 8]["Rat"].ToString();
                            }
                            
                            c--;
                            if (c > 0)
                            {
                                txt167.Text = relat.Rows[q + 9]["Rat"].ToString();
                            }
                            
                            c--;
                            if (c > 0)
                            {
                                txt168.Text = relat.Rows[q + 10]["Rat"].ToString();
                            }
                            
                            c--;
                            if (c > 0)
                            {
                                txt169.Text = relat.Rows[q + 11]["Rat"].ToString();
                            }
                           
                            c--;
                            if (c > 0)
                            {
                                txt170.Text = relat.Rows[q + 12]["Rat"].ToString();
                            }
                            
                            c--;
                            if (c > 0)
                            {
                                txt171.Text = relat.Rows[q + 13]["Rat"].ToString();
                            }
                            
                            c--;
                            if (c > 0)
                            {
                                txt172.Text = relat.Rows[q + 14]["Rat"].ToString();
                            }
                            
                            c--;
                            if (c > 0)
                            {
                                txt173.Text = relat.Rows[q + 15]["Rat"].ToString();
                            }
                            
                            c--;
                            if (c > 0)
                            {
                                txt174.Text = relat.Rows[q + 16]["Rat"].ToString();
                            }
                            
                            c--;
                            if (c > 0)
                            {
                                txt175.Text = relat.Rows[q + 17]["Rat"].ToString();
                            }
                            
                            c--;
                            if (c > 0)
                            {
                                txt176_.Text = relat.Rows[q + 18]["Rat"].ToString();
                            }
                            
                            c--;
                            if (c > 0)
                            {
                                txt177_.Text = relat.Rows[q + 19]["Rat"].ToString();
                            }
                           
                            c--;
                            if (c > 0)
                            {
                                txt178_.Text = relat.Rows[q + 20]["Rat"].ToString();
                            }
                            
                            c--;
                            if (c > 0)
                            {
                                txt179_.Text = relat.Rows[q + 21]["Rat"].ToString();
                            }
                            
                            c--;
                            if (c > 0)
                            {
                                txt180_.Text = relat.Rows[q + 22]["Rat"].ToString();
                            }
                            
                            c--;
                            if (c > 0)
                            {
                                txt181_.Text = relat.Rows[q + 23]["Rat"].ToString();
                            }
                            
                            c--;
                            if (c > 0)
                            {
                                txt182_.Text = relat.Rows[q + 24]["Rat"].ToString();
                            }
                            
                            c--;
                            if (c > 0)
                            {
                                txt183_.Text = relat.Rows[q + 25]["Rat"].ToString();
                            }
                            
                            c--;
                            if (c > 0)
                            {
                                txt184_.Text = relat.Rows[q + 26]["Rat"].ToString();
                            }
                            
                            c--;
                            if (c > 0)
                            {
                                txt185_.Text = relat.Rows[q + 27]["Rat"].ToString();
                            }
                            

                            c = qtde;
                            //tx
                            txt23.Text = relat.Rows[q]["TX"].ToString();
                            c--;
                            if (c > 0)
                            {
                                txt186_.Text = relat.Rows[q + 1]["TX"].ToString();
                            }
                            
                            c--;
                            if (c > 0)
                            {
                                txt187_.Text = relat.Rows[q + 2]["TX"].ToString();
                            }
                            
                            c--;
                            if (c > 0)
                            {
                                txt188_.Text = relat.Rows[q + 3]["TX"].ToString();
                            }
                            
                            c--;
                            if (c > 0)
                            {
                                txt189_.Text = relat.Rows[q + 4]["TX"].ToString();
                            }
                           
                            c--;
                            if (c > 0)
                            {
                                txt190.Text = relat.Rows[q + 5]["TX"].ToString();
                            }
                            
                            c--;
                            if (c > 0)
                            {
                                txt191.Text = relat.Rows[q + 6]["TX"].ToString();
                            }
                            
                            c--;
                            if (c > 0)
                            {
                                txt192.Text = relat.Rows[q + 7]["TX"].ToString();
                            }
                            
                            c--;
                            if (c > 0)
                            {
                                txt193.Text = relat.Rows[q + 8]["TX"].ToString();
                            }
                            
                            c--;
                            if (c > 0)
                            {
                                txt194.Text = relat.Rows[q + 9]["TX"].ToString();
                            }
                            
                            c--;
                            if (c > 0)
                            {
                                txt195.Text = relat.Rows[q + 10]["TX"].ToString();
                            }
                            
                            c--;
                            if (c > 0)
                            {
                                txt196.Text = relat.Rows[q + 11]["TX"].ToString();
                            }
                            
                            c--;
                            if (c > 0)
                            {
                                txt197.Text = relat.Rows[q + 12]["TX"].ToString();
                            }
                            
                            c--;
                            if (c > 0)
                            {
                                txt198.Text = relat.Rows[q + 13]["TX"].ToString();
                            }
                            
                            c--;
                            if (c > 0)
                            {
                                txt199.Text = relat.Rows[q + 14]["TX"].ToString();
                            }
                            
                            c--;
                            if (c > 0)
                            {
                                txt200.Text = relat.Rows[q + 15]["TX"].ToString();
                            }
                            
                            c--;
                            if (c > 0)
                            {
                                txt201.Text = relat.Rows[q + 16]["TX"].ToString();
                            }
                            
                            c--;
                            if (c > 0)
                            {
                                txt202.Text = relat.Rows[q + 17]["TX"].ToString();
                            }
                            
                            c--;
                            if (c > 0)
                            {
                                txt203.Text = relat.Rows[q + 18]["TX"].ToString();
                            }
                            
                            c--;
                            if (c > 0)
                            {
                                txt204.Text = relat.Rows[q + 19]["TX"].ToString();
                            }
                            
                            c--;
                            if (c > 0)
                            {
                                txt205.Text = relat.Rows[q + 20]["TX"].ToString();
                            }
                            
                            c--;
                            if (c > 0)
                            {
                                txt206.Text = relat.Rows[q + 21]["TX"].ToString();
                            }
                            
                            c--;
                            if (c > 0)
                            {
                                txt207.Text = relat.Rows[q + 22]["TX"].ToString();
                            }
                            
                            c--;
                            if (c > 0)
                            {
                                txt208.Text = relat.Rows[q + 23]["TX"].ToString();
                            }
                            
                            c--;
                            if (c > 0)
                            {
                                txt209_.Text = relat.Rows[q + 24]["TX"].ToString();
                            }
                            
                            c--;
                            if (c > 0)
                            {
                                txt210_.Text = relat.Rows[q + 25]["TX"].ToString();
                            }
                            
                            c--;
                            if (c > 0)
                            {
                                txt211_.Text = relat.Rows[q + 26]["TX"].ToString();
                            }
                            
                            c--;
                            if (c > 0)
                            {
                                txt212_.Text = relat.Rows[q + 27]["TX"].ToString();
                            }
                            

                            c = qtde;
                            //total
                            txt24.Text = relat.Rows[q]["Total"].ToString();
                            c--;
                            if (c > 0)
                            {
                                txt213_.Text = relat.Rows[q + 1]["Total"].ToString();
                            }
                            
                            c--;
                            if (c > 0)
                            {
                                txt214_.Text = relat.Rows[q + 2]["Total"].ToString();
                            }
                           
                            c--;
                            if (c > 0)
                            {
                                txt215_.Text = relat.Rows[q + 3]["Total"].ToString();
                            }
                            
                            c--;
                            if (c > 0)
                            {
                                txt216_.Text = relat.Rows[q + 4]["Total"].ToString();
                            }
                           
                            c--;
                            if (c > 0)
                            {
                                txt217_.Text = relat.Rows[q + 5]["Total"].ToString();
                            }
                            
                            c--;
                            if (c > 0)
                            {
                                txt218_.Text = relat.Rows[q + 6]["Total"].ToString();
                            }
                            
                            c--;
                            if (c > 0)
                            {
                                txt219_.Text = relat.Rows[q + 7]["Total"].ToString();
                            }
                            
                            c--;
                            if (c > 0)
                            {
                                txt220_.Text = relat.Rows[q + 8]["Total"].ToString();
                            }
                           
                            c--;
                            if (c > 0)
                            {
                                txt221_.Text = relat.Rows[q + 9]["Total"].ToString();
                            }
                            
                            c--;
                            if (c > 0)
                            {
                                txt222_.Text = relat.Rows[q + 10]["Total"].ToString();
                            }
                           
                            c--;
                            if (c > 0)
                            {
                                txt223.Text = relat.Rows[q + 11]["Total"].ToString();
                            }
                            
                            c--;
                            if (c > 0)
                            {
                                txt224.Text = relat.Rows[q + 12]["Total"].ToString();
                            }
                           
                            c--;
                            if (c > 0)
                            {
                                txt225.Text = relat.Rows[q + 13]["Total"].ToString();
                            }
                            
                            c--;
                            if (c > 0)
                            {
                                txt226.Text = relat.Rows[q + 14]["Total"].ToString();
                            }
                            
                            c--;
                            if (c > 0)
                            {
                                txt227.Text = relat.Rows[q + 15]["Total"].ToString();
                            }
                           
                            c--;
                            if (c > 0)
                            {
                                txt228.Text = relat.Rows[q + 16]["Total"].ToString();
                            }
                           
                            c--;
                            if (c > 0)
                            {
                                txt229.Text = relat.Rows[q + 17]["Total"].ToString();
                            }
                            
                            c--;
                            if (c > 0)
                            {
                                txt230.Text = relat.Rows[q + 18]["Total"].ToString();
                            }
                            
                            c--;
                            if (c > 0)
                            {
                                txt231.Text = relat.Rows[q + 19]["Total"].ToString();
                            }
                            
                            c--;
                            if (c > 0)
                            {
                                txt232.Text = relat.Rows[q + 20]["Total"].ToString();

                            }
                           
                            c--;
                            if (c > 0)
                            {
                                txt233.Text = relat.Rows[q + 21]["Total"].ToString();
                            }
                            
                            c--;
                            if (c > 0)
                            {
                                txt234.Text = relat.Rows[q + 22]["Total"].ToString();
                            }
                            
                            c--;
                            if (c > 0)
                            {
                                txt235.Text = relat.Rows[q + 23]["Total"].ToString();
                            }
                            
                            c--;
                            if (c > 0)
                            {
                                txt236.Text = relat.Rows[q + 24]["Total"].ToString();
                            }
                           
                            c--;
                            if (c > 0)
                            {
                                txt237.Text = relat.Rows[q + 25]["Total"].ToString();
                            }
                            
                            c--;
                            if (c > 0)
                            {
                                txt238.Text = relat.Rows[q + 26]["Total"].ToString();
                            }
                            
                            c--;
                            if (c > 0)
                            {
                                txt239.Text = relat.Rows[q + 27]["Total"].ToString();

                            }
                           
                            c = qtde;
                            //multa
                            txt25.Text = relat.Rows[q]["Multa"].ToString();
                            c--;
                            if (c > 0)
                            {
                                txt240.Text = relat.Rows[q + 1]["Multa"].ToString();
                            }
                           
                            c--;
                            if (c > 0)
                            {
                                txt241.Text = relat.Rows[q + 2]["Multa"].ToString();
                            }
                            
                            c--;
                            if (c > 0)
                            {
                                txt242_.Text = relat.Rows[q + 3]["Multa"].ToString();
                            }
                            
                            c--;
                            if (c > 0)
                            {
                                txt243_.Text = relat.Rows[q + 4]["Multa"].ToString();
                            }
                            
                            c--;
                            if (c > 0)
                            {
                                txt244_.Text = relat.Rows[q + 5]["Multa"].ToString();
                            }
                            
                            c--;
                            if (c > 0)
                            {
                                txt245_.Text = relat.Rows[q + 6]["Multa"].ToString();
                            }
                            
                            c--;
                            if (c > 0)
                            {
                                txt246_.Text = relat.Rows[q + 7]["Multa"].ToString();
                            }
                           
                            c--;
                            if (c > 0)
                            {
                                txt247_.Text = relat.Rows[q + 8]["Multa"].ToString();
                            }
                            
                            c--;
                            if (c > 0)
                            {
                                txt248_.Text = relat.Rows[q + 9]["Multa"].ToString();
                            }
                            
                            c--;
                            if (c > 0)
                            {
                                txt249_.Text = relat.Rows[q + 10]["Multa"].ToString();
                            }
                           
                            c--;
                            if (c > 0)
                            {
                                txt250_.Text = relat.Rows[q + 11]["Multa"].ToString();
                            }
                           
                            c--;
                            if (c > 0)
                            {
                                txt251_.Text = relat.Rows[q + 12]["Multa"].ToString();
                            }
                            
                            c--;
                            if (c > 0)
                            {
                                txt252_.Text = relat.Rows[q + 13]["Multa"].ToString();
                            }
                            
                            c--;
                            if (c > 0)
                            {
                                txt253_.Text = relat.Rows[q + 14]["Multa"].ToString();
                            }
                            
                            c--;
                            if (c > 0)
                            {
                                txt254_.Text = relat.Rows[q + 15]["Multa"].ToString();
                            }
                            
                            c--;
                            if (c > 0)
                            {
                                txt255_.Text = relat.Rows[q + 16]["Multa"].ToString();
                            }
                            
                            c--;
                            if (c > 0)
                            {
                                txt256_.Text = relat.Rows[q + 17]["Multa"].ToString();
                            }
                           
                            c--;
                            if (c > 0)
                            {
                                txt257_.Text = relat.Rows[q + 18]["Multa"].ToString();
                            }
                            
                            c--;
                            if (c > 0)
                            {
                                txt258_.Text = relat.Rows[q + 19]["Multa"].ToString();
                            }
                           
                            c--;
                            if (c > 0)
                            {
                                txt259_.Text = relat.Rows[q + 20]["Multa"].ToString();
                            }
                            
                            c--;
                            if (c > 0)
                            {
                                txt260.Text = relat.Rows[q + 21]["Multa"].ToString();
                            }
                           
                            c--;
                            if (c > 0)
                            {
                                txt261.Text = relat.Rows[q + 22]["Multa"].ToString();
                            }
                           
                            c--;
                            if (c > 0)
                            {
                                txt262.Text = relat.Rows[q + 23]["Multa"].ToString();
                            }
                            
                            c--;
                            if (c > 0)
                            {
                                txt263.Text = relat.Rows[q + 24]["Multa"].ToString();
                            }
                            
                            c--;
                            if (c > 0)
                            {
                                txt264.Text = relat.Rows[q + 25]["Multa"].ToString();
                            }
                           
                            c--;
                            if (c > 0)
                            {
                                txt265.Text = relat.Rows[q + 26]["Multa"].ToString();
                            }
                           
                            c--;
                            if (c > 0)
                            {
                                txt266.Text = relat.Rows[q + 27]["Multa"].ToString();

                            }
                           
                            c = qtde;
                            //atraso
                            txt26.Text = relat.Rows[q]["Atraso"].ToString();
                            c--;
                            if (c > 0)
                            {
                                txt267.Text = relat.Rows[q + 1]["Atraso"].ToString();
                            }
                            else
                            {
                                txt267.Text = "";
                            }
                            
                            c--;
                            if (c > 0)
                            {
                                txt268.Text = relat.Rows[q + 2]["Atraso"].ToString();
                            }
                            else
                            {
                                txt268.Text = "";
                            }
                           
                            c--;
                            if (c > 0)
                            {
                                txt269.Text = relat.Rows[q + 3]["Atraso"].ToString();
                            }
                            else
                            {
                                txt269.Text = "";
                            }
                           
                            c--;
                            if (c > 0)
                            {
                                txt270.Text = relat.Rows[q + 4]["Atraso"].ToString();
                            }
                            else
                            {
                                txt270.Text = "";
                            }
                            
                            c--;
                            if (c > 0)
                            {
                                txt271.Text = relat.Rows[q + 5]["Atraso"].ToString();
                            }
                            else
                            {
                                txt271.Text = "";
                            }
                            
                            c--;
                            if (c > 0)
                            {
                                txt272.Text = relat.Rows[q + 6]["Atraso"].ToString();
                            }
                            else
                            {
                                txt272.Text = "";
                            }
                           
                            c--;
                            if (c > 0)
                            {
                                txt273.Text = relat.Rows[q + 7]["Atraso"].ToString();
                            }
                            else
                            {
                                txt273.Text = "";
                            }
                            
                            c--;
                            if (c > 0)
                            {
                                txt274.Text = relat.Rows[q + 8]["Atraso"].ToString();
                            }
                            else
                            {
                                txt274.Text = "";
                            }
                            
                            c--;
                            if (c > 0)
                            {
                                txt275.Text = relat.Rows[q + 9]["Atraso"].ToString();
                            }
                            else
                            {
                                txt275.Text = "";
                            }
                            
                            c--;
                            if (c > 0)
                            {
                                txt276.Text = relat.Rows[q + 10]["Atraso"].ToString();
                            }
                            else
                            {
                                txt276.Text = "";
                            }
                           
                            c--;
                            if (c > 0)
                            {
                                txt277.Text = relat.Rows[q + 11]["Atraso"].ToString();
                            }
                            else
                            {
                                txt277.Text = "";
                            }
                            
                            c--;
                            if (c > 0)
                            {
                                txt278.Text = relat.Rows[q + 12]["Atraso"].ToString();
                            }
                            else
                            {
                                txt278.Text = "";
                            }
                            
                            c--;
                            if (c > 0)
                            {
                                txt279.Text = relat.Rows[q + 13]["Atraso"].ToString();
                            }
                            else
                            {
                                txt279.Text = "";
                            }
                            
                            c--;
                            if (c > 0)
                            {
                                txt280.Text = relat.Rows[q + 14]["Atraso"].ToString();
                            }
                            else
                            {
                                txt280.Text = "";
                            }
                           
                            c--;
                            if (c > 0)
                            {
                                txt281.Text = relat.Rows[q + 15]["Atraso"].ToString();
                            }
                            else
                            {
                                txt281.Text = "";
                            }
                            
                            c--;
                            if (c > 0)
                            {
                                txt282.Text = relat.Rows[q + 16]["Atraso"].ToString();
                            }
                            else
                            {
                                txt282.Text = "";
                            }
                            
                            c--;
                            if (c > 0)
                            {
                                txt283.Text = relat.Rows[q + 17]["Atraso"].ToString();
                            }
                            else
                            {
                                txt283.Text = "";
                            }
                            
                            c--;
                            if (c > 0)
                            {
                                txt284.Text = relat.Rows[q + 18]["Atraso"].ToString();
                            }
                            else
                            {
                                txt284.Text = "";
                            }
                           
                            c--;
                            if (c > 0)
                            {
                                txt285.Text = relat.Rows[q + 19]["Atraso"].ToString();
                            }
                            else
                            {
                                txt285.Text = "";
                            }
                            
                            c--;
                            if (c > 0)
                            {
                                txt286.Text = relat.Rows[q + 20]["Atraso"].ToString();
                            }
                            else
                            {
                                txt286.Text = "";
                            }
                            
                            c--;
                            if (c > 0)
                            {
                                txt287.Text = relat.Rows[q + 21]["Atraso"].ToString();
                            }
                            else
                            {
                                txt287.Text = "";
                            }
                            
                            c--;
                            if (c > 0)
                            {
                                txt288.Text = relat.Rows[q + 22]["Atraso"].ToString();
                            }
                            else
                            {
                                txt288.Text = "";
                            }
                            
                            c--;
                            if (c > 0)
                            {
                                txt289.Text = relat.Rows[q + 23]["Atraso"].ToString();
                            }
                            else
                            {
                                txt289.Text = "";
                            }
                            
                            c--;
                            if (c > 0)
                            {
                                txt290.Text = relat.Rows[q + 24]["Atraso"].ToString();
                            }
                            else
                            {
                                txt290.Text = "";
                            }
                            
                            c--;
                            if (c > 0)
                            {
                                txt291.Text = relat.Rows[q + 25]["Atraso"].ToString();
                            }
                            else
                            {
                                txt291.Text = "";
                            }
                            
                            c--;
                            if (c > 0)
                            {
                                txt292.Text = relat.Rows[q + 26]["Atraso"].ToString();
                            }
                            else
                            {
                                txt292.Text = "";
                            }
                            
                            c--;
                            if (c > 0)
                            {
                                txt293.Text = relat.Rows[q + 27]["Atraso"].ToString();
                            }
                            else
                            {
                                txt293.Text = "";
                            }
                            

                           
                        }






                        crystalReportViewer1.ReportSource = rpt1;
                        crystalReportViewer1.Refresh();

                        // crystalReportViewer1.PrintReport();
                        rpt1.PrintToPrinter(1, false, 0, 0);
                        rpt1.PrintToPrinter(1, false, 0, 0);
                        Form print1 = new Print("Imprimindo o Relatório");
                        print1.ShowDialog();

                        q = q + 28;
                        qtde = qtde - 28;

                        if (qtde <= 0)
                        {
                            imprime = false;
                        }

                    }
                    

                    //******************************************
                    //Imprimir leitura
                    //******************************************

                    TextObject txt17__ = (TextObject)rpt2.ReportDefinition.ReportObjects["Text17"]; //Instancie um objeto do tipo TextObject e informe o nome do textbox
                    txt17__.Text = "";
                    TextObject txt8__ = (TextObject)rpt2.ReportDefinition.ReportObjects["Text8"]; //Instancie um objeto do tipo TextObject e informe o nome do textbox
                    txt8__.Text = "";
                    TextObject txt7__ = (TextObject)rpt2.ReportDefinition.ReportObjects["Text7"]; //Instancie um objeto do tipo TextObject e informe o nome do textbox
                    txt7__.Text = "";
                    TextObject txt14__ = (TextObject)rpt2.ReportDefinition.ReportObjects["Text14"]; //Instancie um objeto do tipo TextObject e informe o nome do textbox
                    txt14__.Text = "";
                    TextObject txt42__ = (TextObject)rpt2.ReportDefinition.ReportObjects["Text42"]; //Instancie um objeto do tipo TextObject e informe o nome do textbox
                    txt42__.Text = "";
                    TextObject txt27__ = (TextObject)rpt2.ReportDefinition.ReportObjects["Text27"]; //Instancie um objeto do tipo TextObject e informe o nome do textbox
                    txt27__.Text = "";
                    TextObject txt44__ = (TextObject)rpt2.ReportDefinition.ReportObjects["Text44"]; //Instancie um objeto do tipo TextObject e informe o nome do textbox
                    txt44__.Text = "";
                    TextObject txt10__ = (TextObject)rpt2.ReportDefinition.ReportObjects["Text10"]; //Instancie um objeto do tipo TextObject e informe o nome do textbox
                    txt10__.Text = "";
                    TextObject txt11__ = (TextObject)rpt2.ReportDefinition.ReportObjects["Text11"]; //Instancie um objeto do tipo TextObject e informe o nome do textbox
                    txt11__.Text = "";
                    TextObject txt12__ = (TextObject)rpt2.ReportDefinition.ReportObjects["Text12"]; //Instancie um objeto do tipo TextObject e informe o nome do textbox
                    txt12__.Text = "";
                    TextObject txt13__ = (TextObject)rpt2.ReportDefinition.ReportObjects["Text13"]; //Instancie um objeto do tipo TextObject e informe o nome do textbox
                    txt13__.Text = "";
                    TextObject txt15__ = (TextObject)rpt2.ReportDefinition.ReportObjects["Text15"]; //Instancie um objeto do tipo TextObject e informe o nome do textbox
                    txt15__.Text = "";
                    TextObject txt18__ = (TextObject)rpt2.ReportDefinition.ReportObjects["Text18"]; //Instancie um objeto do tipo TextObject e informe o nome do textbox
                    txt18__.Text = "";
                    TextObject txt19__ = (TextObject)rpt2.ReportDefinition.ReportObjects["Text19"]; //Instancie um objeto do tipo TextObject e informe o nome do textbox
                    txt19__.Text = "";
                    TextObject txt28__ = (TextObject)rpt2.ReportDefinition.ReportObjects["Text28"]; //Instancie um objeto do tipo TextObject e informe o nome do textbox
                    txt28__.Text = "";
                    TextObject txt29__ = (TextObject)rpt2.ReportDefinition.ReportObjects["Text29"]; //Instancie um objeto do tipo TextObject e informe o nome do textbox
                    txt29__.Text = "";
                    TextObject txt30__ = (TextObject)rpt2.ReportDefinition.ReportObjects["Text30"]; //Instancie um objeto do tipo TextObject e informe o nome do textbox
                    txt30__.Text = "";
                    TextObject txt31__ = (TextObject)rpt2.ReportDefinition.ReportObjects["Text31"]; //Instancie um objeto do tipo TextObject e informe o nome do textbox
                    txt31__.Text = "";
                    TextObject txt32__ = (TextObject)rpt2.ReportDefinition.ReportObjects["Text32"]; //Instancie um objeto do tipo TextObject e informe o nome do textbox
                    txt32__.Text = "";
                    TextObject txt33__ = (TextObject)rpt2.ReportDefinition.ReportObjects["Text33"]; //Instancie um objeto do tipo TextObject e informe o nome do textbox
                    txt33__.Text = "";
                    TextObject txt34__ = (TextObject)rpt2.ReportDefinition.ReportObjects["Text34"]; //Instancie um objeto do tipo TextObject e informe o nome do textbox
                    txt34__.Text = "";
                    TextObject txt35__ = (TextObject)rpt2.ReportDefinition.ReportObjects["Text35"]; //Instancie um objeto do tipo TextObject e informe o nome do textbox
                    txt35__.Text = "";
                    TextObject txt36__ = (TextObject)rpt2.ReportDefinition.ReportObjects["Text36"]; //Instancie um objeto do tipo TextObject e informe o nome do textbox
                    txt36__.Text = "";
                    TextObject txt37__ = (TextObject)rpt2.ReportDefinition.ReportObjects["Text37"]; //Instancie um objeto do tipo TextObject e informe o nome do textbox
                    txt37__.Text = "";
                    TextObject txt38__ = (TextObject)rpt2.ReportDefinition.ReportObjects["Text38"]; //Instancie um objeto do tipo TextObject e informe o nome do textbox
                    txt38__.Text = "";
                    TextObject txt39__ = (TextObject)rpt2.ReportDefinition.ReportObjects["Text39"]; //Instancie um objeto do tipo TextObject e informe o nome do textbox
                    txt39__.Text = "";
                    TextObject txt40__ = (TextObject)rpt2.ReportDefinition.ReportObjects["Text40"]; //Instancie um objeto do tipo TextObject e informe o nome do textbox
                    txt40__.Text = "";
                    TextObject txt41__ = (TextObject)rpt2.ReportDefinition.ReportObjects["Text41"]; //Instancie um objeto do tipo TextObject e informe o nome do textbox
                    txt41__.Text = "";
                    TextObject txt45__ = (TextObject)rpt2.ReportDefinition.ReportObjects["Text45"]; //Instancie um objeto do tipo TextObject e informe o nome do textbox
                    txt45__.Text = "";
                    TextObject txt46__ = (TextObject)rpt2.ReportDefinition.ReportObjects["Text46"]; //Instancie um objeto do tipo TextObject e informe o nome do textbox
                    txt46__.Text = "";
                    TextObject txt47__ = (TextObject)rpt2.ReportDefinition.ReportObjects["Text47"]; //Instancie um objeto do tipo TextObject e informe o nome do textbox
                    txt47__.Text = "";
                    TextObject txt48__ = (TextObject)rpt2.ReportDefinition.ReportObjects["Text48"]; //Instancie um objeto do tipo TextObject e informe o nome do textbox
                    txt48__.Text = "";
                    TextObject txt51__ = (TextObject)rpt2.ReportDefinition.ReportObjects["Text51"]; //Instancie um objeto do tipo TextObject e informe o nome do textbox
                    txt51__.Text = "";
                    TextObject txt52__ = (TextObject)rpt2.ReportDefinition.ReportObjects["Text52"]; //Instancie um objeto do tipo TextObject e informe o nome do textbox
                    txt52__.Text = "";
                    TextObject txt20__ = (TextObject)rpt2.ReportDefinition.ReportObjects["Text20"]; //Instancie um objeto do tipo TextObject e informe o nome do textbox
                    txt20__.Text = "";
                    TextObject txt21__ = (TextObject)rpt2.ReportDefinition.ReportObjects["Text21"]; //Instancie um objeto do tipo TextObject e informe o nome do textbox
                    txt21__.Text = "";
                    TextObject txt22__ = (TextObject)rpt2.ReportDefinition.ReportObjects["Text22"]; //Instancie um objeto do tipo TextObject e informe o nome do textbox
                    txt22__.Text = "";


                    TextObject txt24__ = (TextObject)rpt2.ReportDefinition.ReportObjects["Text24"]; //Instancie um objeto do tipo TextObject e informe o nome do textbox
                    txt24__.Text = "";
                    TextObject txt25__ = (TextObject)rpt2.ReportDefinition.ReportObjects["Text25"]; //Instancie um objeto do tipo TextObject e informe o nome do textbox
                    txt25__.Text = "";
                    TextObject txt26__ = (TextObject)rpt2.ReportDefinition.ReportObjects["Text26"]; //Instancie um objeto do tipo TextObject e informe o nome do textbox
                    txt26__.Text = "";
                    TextObject txt43__ = (TextObject)rpt2.ReportDefinition.ReportObjects["Text43"]; //Instancie um objeto do tipo TextObject e informe o nome do textbox
                    txt43__.Text = "";
                    TextObject txt49__ = (TextObject)rpt2.ReportDefinition.ReportObjects["Text49"]; //Instancie um objeto do tipo TextObject e informe o nome do textbox
                    txt49__.Text = "";
                    TextObject txt50__ = (TextObject)rpt2.ReportDefinition.ReportObjects["Text50"]; //Instancie um objeto do tipo TextObject e informe o nome do textbox
                    txt50__.Text = "";
                    TextObject txt53__ = (TextObject)rpt2.ReportDefinition.ReportObjects["Text53"]; //Instancie um objeto do tipo TextObject e informe o nome do textbox
                    txt53__.Text = "";
                    TextObject txt54__ = (TextObject)rpt2.ReportDefinition.ReportObjects["Text54"]; //Instancie um objeto do tipo TextObject e informe o nome do textbox
                    txt54__.Text = "";
                    TextObject txt55__ = (TextObject)rpt2.ReportDefinition.ReportObjects["Text55"]; //Instancie um objeto do tipo TextObject e informe o nome do textbox
                    txt55__.Text = "";
                    TextObject txt56__ = (TextObject)rpt2.ReportDefinition.ReportObjects["Text56"]; //Instancie um objeto do tipo TextObject e informe o nome do textbox
                    txt56__.Text = "";
                    TextObject txt57__ = (TextObject)rpt2.ReportDefinition.ReportObjects["Text57"]; //Instancie um objeto do tipo TextObject e informe o nome do textbox
                    txt57__.Text = "";
                    TextObject txt58__ = (TextObject)rpt2.ReportDefinition.ReportObjects["Text58"]; //Instancie um objeto do tipo TextObject e informe o nome do textbox
                    txt58__.Text = "";
                    TextObject txt59__ = (TextObject)rpt2.ReportDefinition.ReportObjects["Text59"]; //Instancie um objeto do tipo TextObject e informe o nome do textbox
                    txt59__.Text = "";
                    TextObject txt60__ = (TextObject)rpt2.ReportDefinition.ReportObjects["Text60"]; //Instancie um objeto do tipo TextObject e informe o nome do textbox
                    txt60__.Text = "";
                    TextObject txt61__ = (TextObject)rpt2.ReportDefinition.ReportObjects["Text61"]; //Instancie um objeto do tipo TextObject e informe o nome do textbox
                    txt61__.Text = "";
                    TextObject txt62__ = (TextObject)rpt2.ReportDefinition.ReportObjects["Text62"]; //Instancie um objeto do tipo TextObject e informe o nome do textbox
                    txt62__.Text = "";
                    TextObject txt63__ = (TextObject)rpt2.ReportDefinition.ReportObjects["Text63"]; //Instancie um objeto do tipo TextObject e informe o nome do textbox
                    txt63__.Text = "";
                    TextObject txt64__ = (TextObject)rpt2.ReportDefinition.ReportObjects["Text64"]; //Instancie um objeto do tipo TextObject e informe o nome do textbox
                    txt64__.Text = "";
                    TextObject txt65__ = (TextObject)rpt2.ReportDefinition.ReportObjects["Text65"]; //Instancie um objeto do tipo TextObject e informe o nome do textbox
                    txt65__.Text = "";
                    TextObject txt66__ = (TextObject)rpt2.ReportDefinition.ReportObjects["Text66"]; //Instancie um objeto do tipo TextObject e informe o nome do textbox
                    txt66__.Text = "";
                    TextObject txt67__ = (TextObject)rpt2.ReportDefinition.ReportObjects["Text67"]; //Instancie um objeto do tipo TextObject e informe o nome do textbox
                    txt67__.Text = "";
                    TextObject txt68__ = (TextObject)rpt2.ReportDefinition.ReportObjects["Text68"]; //Instancie um objeto do tipo TextObject e informe o nome do textbox
                    txt68__.Text = "";
                    TextObject txt69__ = (TextObject)rpt2.ReportDefinition.ReportObjects["Text69"]; //Instancie um objeto do tipo TextObject e informe o nome do textbox
                    txt69__.Text = "";
                    TextObject txt70__ = (TextObject)rpt2.ReportDefinition.ReportObjects["Text70"]; //Instancie um objeto do tipo TextObject e informe o nome do textbox
                    txt70__.Text = "";
                    TextObject txt71__ = (TextObject)rpt2.ReportDefinition.ReportObjects["Text71"]; //Instancie um objeto do tipo TextObject e informe o nome do textbox
                    txt71__.Text = "";
                    TextObject txt72__ = (TextObject)rpt2.ReportDefinition.ReportObjects["Text72"]; //Instancie um objeto do tipo TextObject e informe o nome do textbox
                    txt72__.Text = "";
                    TextObject txt73__ = (TextObject)rpt2.ReportDefinition.ReportObjects["Text73"]; //Instancie um objeto do tipo TextObject e informe o nome do textbox
                    txt73__.Text = "";
                    TextObject txt74__ = (TextObject)rpt2.ReportDefinition.ReportObjects["Text74"]; //Instancie um objeto do tipo TextObject e informe o nome do textbox
                    txt74__.Text = "";
                    TextObject txt75__ = (TextObject)rpt2.ReportDefinition.ReportObjects["Text75"]; //Instancie um objeto do tipo TextObject e informe o nome do textbox
                    txt75__.Text = "";
                    TextObject txt76__ = (TextObject)rpt2.ReportDefinition.ReportObjects["Text76"]; //Instancie um objeto do tipo TextObject e informe o nome do textbox
                    txt76__.Text = "";
                    TextObject txt77__ = (TextObject)rpt2.ReportDefinition.ReportObjects["Text77"]; //Instancie um objeto do tipo TextObject e informe o nome do textbox
                    txt77__.Text = "";
                    TextObject txt78__ = (TextObject)rpt2.ReportDefinition.ReportObjects["Text78"]; //Instancie um objeto do tipo TextObject e informe o nome do textbox
                    txt78__.Text = "";
                    TextObject txt79__ = (TextObject)rpt2.ReportDefinition.ReportObjects["Text79"]; //Instancie um objeto do tipo TextObject e informe o nome do textbox
                    txt79__.Text = "";
                    TextObject txt80__ = (TextObject)rpt2.ReportDefinition.ReportObjects["Text80"]; //Instancie um objeto do tipo TextObject e informe o nome do textbox
                    txt80__.Text = "";
                    TextObject txt81__ = (TextObject)rpt2.ReportDefinition.ReportObjects["Text81"]; //Instancie um objeto do tipo TextObject e informe o nome do textbox
                    txt81__.Text = "";
                    TextObject txt82__ = (TextObject)rpt2.ReportDefinition.ReportObjects["Text82"]; //Instancie um objeto do tipo TextObject e informe o nome do textbox
                    txt82__.Text = "";
                    TextObject txt83__ = (TextObject)rpt2.ReportDefinition.ReportObjects["Text83"]; //Instancie um objeto do tipo TextObject e informe o nome do textbox
                    txt83__.Text = "";


                    DataTable l = DAL.Lista_Leitura();
                    bool imprime2 = true;
                    int qtde2 = l.Rows.Count;
                    int b = 0;

                    while (imprime2 == true)
                    {
                        if (qtde2 >= 37)
                        {
                            //preencher páginas inteiras
                            txt17__.Text = l.Rows[b]["Nome"].ToString();
                            txt8__.Text = l.Rows[b + 1]["Nome"].ToString();
                            txt7__.Text = l.Rows[b + 2]["Nome"].ToString();
                            txt14__.Text = l.Rows[b + 3]["Nome"].ToString();
                            txt42__.Text = l.Rows[b + 4]["Nome"].ToString();
                            txt27__.Text = l.Rows[b + 5]["Nome"].ToString();
                            txt44__.Text = l.Rows[b + 6]["Nome"].ToString();
                            txt10__.Text = l.Rows[b + 7]["Nome"].ToString();
                            txt11__.Text = l.Rows[b + 8]["Nome"].ToString();
                            txt12__.Text = l.Rows[b + 9]["Nome"].ToString();
                            txt13__.Text = l.Rows[b + 10]["Nome"].ToString();
                            txt15__.Text = l.Rows[b + 11]["Nome"].ToString();
                            txt18__.Text = l.Rows[b + 12]["Nome"].ToString();
                            txt19__.Text = l.Rows[b + 13]["Nome"].ToString();
                            txt28__.Text = l.Rows[b + 14]["Nome"].ToString();
                            txt29__.Text = l.Rows[b + 15]["Nome"].ToString();
                            txt30__.Text = l.Rows[b + 16]["Nome"].ToString();
                            txt31__.Text = l.Rows[b + 17]["Nome"].ToString();
                            txt32__.Text = l.Rows[b + 18]["Nome"].ToString();
                            txt33__.Text = l.Rows[b + 19]["Nome"].ToString();
                            txt34__.Text = l.Rows[b + 20]["Nome"].ToString();
                            txt35__.Text = l.Rows[b + 21]["Nome"].ToString();
                            txt36__.Text = l.Rows[b + 22]["Nome"].ToString();
                            txt37__.Text = l.Rows[b + 23]["Nome"].ToString();
                            txt38__.Text = l.Rows[b + 24]["Nome"].ToString();
                            txt39__.Text = l.Rows[b + 25]["Nome"].ToString();
                            txt40__.Text = l.Rows[b + 26]["Nome"].ToString();
                            txt41__.Text = l.Rows[b + 27]["Nome"].ToString();
                            txt45__.Text = l.Rows[b + 28]["Nome"].ToString();
                            txt46__.Text = l.Rows[b + 29]["Nome"].ToString();
                            txt47__.Text = l.Rows[b + 30]["Nome"].ToString();
                            txt48__.Text = l.Rows[b + 31]["Nome"].ToString();
                            txt51__.Text = l.Rows[b + 32]["Nome"].ToString();
                            txt52__.Text = l.Rows[b + 33]["Nome"].ToString();
                            txt20__.Text = l.Rows[b + 34]["Nome"].ToString();
                            txt21__.Text = l.Rows[b + 35]["Nome"].ToString();
                            txt22__.Text = l.Rows[b + 36]["Nome"].ToString();

                            if (Convert.ToInt32(l.Rows[b]["Atual"].ToString()) < Convert.ToInt32(l.Rows[b]["Anterior"].ToString()))
                            {
                                txt24__.Text = l.Rows[b]["Anterior"].ToString();    
                            }
                            if (Convert.ToInt32(l.Rows[b]["Atual"].ToString()) > Convert.ToInt32(l.Rows[b]["Anterior"].ToString()))
                            {
                                txt24__.Text = l.Rows[b]["Atual"].ToString();
                            }
                            if (String.IsNullOrEmpty(txt24__.Text) == true)
                            {
                                txt24__.Text = l.Rows[b]["Anterior"].ToString();
                            }
                            
                            
                            if (Convert.ToInt32(l.Rows[b + 1]["Atual"].ToString()) < Convert.ToInt32(l.Rows[b + 1]["Anterior"].ToString()))
                            {
                                txt25__.Text = l.Rows[b + 1]["Anterior"].ToString();
                            }
                            if (Convert.ToInt32(l.Rows[b + 1]["Atual"].ToString()) > Convert.ToInt32(l.Rows[b + 1]["Anterior"].ToString()))
                            {
                                txt25__.Text = l.Rows[b + 1]["Atual"].ToString();
                            }
                            if (String.IsNullOrEmpty(txt25__.Text) == true)
                            {
                                txt25__.Text = l.Rows[b + 1]["Anterior"].ToString();
                            }

                            
                            if (Convert.ToInt32(l.Rows[b + 2]["Atual"].ToString()) < Convert.ToInt32(l.Rows[b + 2]["Anterior"].ToString()))
                            {
                                txt26__.Text = l.Rows[b + 2]["Anterior"].ToString();
                            }
                            if (Convert.ToInt32(l.Rows[b + 2]["Atual"].ToString()) > Convert.ToInt32(l.Rows[b + 2]["Anterior"].ToString()))
                            {
                                txt26__.Text = l.Rows[b + 2]["Atual"].ToString();
                            }
                            if (String.IsNullOrEmpty(txt26__.Text) == true)
                            {
                                txt26__.Text = l.Rows[b + 2]["Anterior"].ToString();
                            }

                            
                            if (Convert.ToInt32(l.Rows[b + 3]["Atual"].ToString()) < Convert.ToInt32(l.Rows[b + 3]["Anterior"].ToString()))
                            {
                                txt43__.Text = l.Rows[b + 3]["Anterior"].ToString();
                            }
                            if (Convert.ToInt32(l.Rows[b + 3]["Atual"].ToString()) > Convert.ToInt32(l.Rows[b + 3]["Anterior"].ToString()))
                            {
                                txt43__.Text = l.Rows[b + 3]["Atual"].ToString();
                            }
                            if (String.IsNullOrEmpty(txt43__.Text) == true)
                            {
                                txt43__.Text = l.Rows[b + 3]["Anterior"].ToString();
                            }

                            
                            if (Convert.ToInt32(l.Rows[b + 4]["Atual"].ToString()) < Convert.ToInt32(l.Rows[b + 4]["Anterior"].ToString()))
                            {
                                txt49__.Text = l.Rows[b + 4]["Anterior"].ToString();
                            }
                            if (Convert.ToInt32(l.Rows[b + 4]["Atual"].ToString()) > Convert.ToInt32(l.Rows[b + 4]["Anterior"].ToString()))
                            {
                                txt49__.Text = l.Rows[b + 4]["Atual"].ToString();
                            }
                            if (String.IsNullOrEmpty(txt49__.Text) == true)
                            {
                                txt49__.Text = l.Rows[b + 4]["Anterior"].ToString();
                            }

                            
                            if (Convert.ToInt32(l.Rows[b + 5]["Atual"].ToString()) < Convert.ToInt32(l.Rows[b + 5]["Anterior"].ToString()))
                            {
                                txt50__.Text = l.Rows[b + 5]["Anterior"].ToString();
                            }
                            if (Convert.ToInt32(l.Rows[b + 5]["Atual"].ToString()) > Convert.ToInt32(l.Rows[b + 5]["Anterior"].ToString()))
                            {
                                txt50__.Text = l.Rows[b + 5]["Atual"].ToString();
                            }
                            if (String.IsNullOrEmpty(txt50__.Text) == true)
                            {
                                txt50__.Text = l.Rows[b + 5]["Anterior"].ToString();
                            }

                            
                            if (Convert.ToInt32(l.Rows[b + 6]["Atual"].ToString()) < Convert.ToInt32(l.Rows[b + 6]["Anterior"].ToString()))
                            {
                                txt53__.Text = l.Rows[b + 6]["Anterior"].ToString();
                            }
                            if (Convert.ToInt32(l.Rows[b + 6]["Atual"].ToString()) > Convert.ToInt32(l.Rows[b + 6]["Anterior"].ToString()))
                            {
                                txt53__.Text = l.Rows[b + 6]["Atual"].ToString();
                            }
                            if (String.IsNullOrEmpty(txt53__.Text) == true)
                            {
                                txt53__.Text = l.Rows[b + 6]["Anterior"].ToString();
                            }

                            
                            if (Convert.ToInt32(l.Rows[b + 7]["Atual"].ToString()) < Convert.ToInt32(l.Rows[b + 7]["Anterior"].ToString()))
                            {
                                txt54__.Text = l.Rows[b + 7]["Anterior"].ToString();
                            }
                            if (Convert.ToInt32(l.Rows[b + 7]["Atual"].ToString()) > Convert.ToInt32(l.Rows[b + 7]["Anterior"].ToString()))
                            {
                                txt54__.Text = l.Rows[b + 7]["Atual"].ToString();
                            }
                            if (String.IsNullOrEmpty(txt54__.Text) == true)
                            {
                                txt54__.Text = l.Rows[b + 7]["Anterior"].ToString();
                            }

                            
                            if (Convert.ToInt32(l.Rows[b + 8]["Atual"].ToString()) < Convert.ToInt32(l.Rows[b + 8]["Anterior"].ToString()))
                            {
                                txt55__.Text = l.Rows[b + 8]["Anterior"].ToString();
                            }
                            if (Convert.ToInt32(l.Rows[b + 8]["Atual"].ToString()) > Convert.ToInt32(l.Rows[b + 8]["Anterior"].ToString()))
                            {
                                txt55__.Text = l.Rows[b + 8]["Atual"].ToString();
                            }
                            if (String.IsNullOrEmpty(txt55__.Text) == true)
                            {
                                txt55__.Text = l.Rows[b + 8]["Anterior"].ToString();
                            }

                            
                            if (Convert.ToInt32(l.Rows[b + 9]["Atual"].ToString()) < Convert.ToInt32(l.Rows[b + 9]["Anterior"].ToString()))
                            {
                                txt56__.Text = l.Rows[b + 9]["Anterior"].ToString();
                            }
                            if (Convert.ToInt32(l.Rows[b + 9]["Atual"].ToString()) > Convert.ToInt32(l.Rows[b + 9]["Anterior"].ToString()))
                            {
                                txt56__.Text = l.Rows[b + 9]["Atual"].ToString();
                            }
                            if (String.IsNullOrEmpty(txt56__.Text) == true)
                            {
                                txt56__.Text = l.Rows[b + 9]["Anterior"].ToString();
                            }

                            
                            if (Convert.ToInt32(l.Rows[b + 10]["Atual"].ToString()) < Convert.ToInt32(l.Rows[b + 10]["Anterior"].ToString()))
                            {
                                txt57__.Text = l.Rows[b + 10]["Anterior"].ToString();
                            }
                            if (Convert.ToInt32(l.Rows[b + 10]["Atual"].ToString()) > Convert.ToInt32(l.Rows[b + 10]["Anterior"].ToString()))
                            {
                                txt57__.Text = l.Rows[b + 10]["Atual"].ToString();
                            }
                            if (String.IsNullOrEmpty(txt57__.Text) == true)
                            {
                                txt57__.Text = l.Rows[b + 10]["Anterior"].ToString();
                            }

                            
                            if (Convert.ToInt32(l.Rows[b + 11]["Atual"].ToString()) < Convert.ToInt32(l.Rows[b + 11]["Anterior"].ToString()))
                            {
                                txt58__.Text = l.Rows[b + 11]["Anterior"].ToString();
                            }
                            if (Convert.ToInt32(l.Rows[b + 11]["Atual"].ToString()) > Convert.ToInt32(l.Rows[b + 11]["Anterior"].ToString()))
                            {
                                txt58__.Text = l.Rows[b + 11]["Atual"].ToString();
                            }
                            if (String.IsNullOrEmpty(txt58__.Text) == true)
                            {
                                txt58__.Text = l.Rows[b + 11]["Anterior"].ToString();
                            }

                           
                            if (Convert.ToInt32(l.Rows[b + 12]["Atual"].ToString()) < Convert.ToInt32(l.Rows[b + 12]["Anterior"].ToString()))
                            {
                                txt59__.Text = l.Rows[b + 12]["Anterior"].ToString();
                            }
                            if (Convert.ToInt32(l.Rows[b + 12]["Atual"].ToString()) > Convert.ToInt32(l.Rows[b + 12]["Anterior"].ToString()))
                            {
                                txt59__.Text = l.Rows[b + 12]["Atual"].ToString();
                            }
                            if (String.IsNullOrEmpty(txt59__.Text) == true)
                            {
                                txt59__.Text = l.Rows[b + 12]["Anterior"].ToString();
                            }

                            
                            if (Convert.ToInt32(l.Rows[b + 13]["Atual"].ToString()) < Convert.ToInt32(l.Rows[b + 13]["Anterior"].ToString()))
                            {
                                txt60__.Text = l.Rows[b + 13]["Anterior"].ToString();
                            }
                            if (Convert.ToInt32(l.Rows[b + 13]["Atual"].ToString()) > Convert.ToInt32(l.Rows[b + 13]["Anterior"].ToString()))
                            {
                                txt60__.Text = l.Rows[b + 13]["Atual"].ToString();
                            }
                            if (String.IsNullOrEmpty(txt60__.Text) == true)
                            {
                                txt60__.Text = l.Rows[b + 13]["Anterior"].ToString();
                            }

                           
                            if (Convert.ToInt32(l.Rows[b + 14]["Atual"].ToString()) < Convert.ToInt32(l.Rows[b + 14]["Anterior"].ToString()))
                            {
                                txt61__.Text = l.Rows[b + 14]["Anterior"].ToString();
                            }
                            if (Convert.ToInt32(l.Rows[b + 14]["Atual"].ToString()) > Convert.ToInt32(l.Rows[b + 14]["Anterior"].ToString()))
                            {
                                txt61__.Text = l.Rows[b + 14]["Atual"].ToString();
                            }
                            if (String.IsNullOrEmpty(txt61__.Text) == true)
                            {
                                txt61__.Text = l.Rows[b + 14]["Anterior"].ToString();
                            }

                            
                            if (Convert.ToInt32(l.Rows[b + 15]["Atual"].ToString()) < Convert.ToInt32(l.Rows[b + 15]["Anterior"].ToString()))
                            {
                                txt62__.Text = l.Rows[b + 15]["Anterior"].ToString();
                            }
                            if (Convert.ToInt32(l.Rows[b + 15]["Atual"].ToString()) > Convert.ToInt32(l.Rows[b + 15]["Anterior"].ToString()))
                            {
                                txt62__.Text = l.Rows[b + 15]["Atual"].ToString();
                            }
                            if (String.IsNullOrEmpty(txt62__.Text) == true)
                            {
                                txt62__.Text = l.Rows[b + 15]["Anterior"].ToString();
                            }


                            if (Convert.ToInt32(l.Rows[b + 16]["Atual"].ToString()) < Convert.ToInt32(l.Rows[b + 16]["Anterior"].ToString()))
                            {
                                txt63__.Text = l.Rows[b + 16]["Anterior"].ToString();
                            }
                            if (Convert.ToInt32(l.Rows[b + 16]["Atual"].ToString()) > Convert.ToInt32(l.Rows[b + 16]["Anterior"].ToString()))
                            {
                                txt63__.Text = l.Rows[b + 16]["Atual"].ToString();
                            }
                            if (String.IsNullOrEmpty(txt63__.Text) == true)
                            {
                                txt63__.Text = l.Rows[b + 16]["Anterior"].ToString();
                            }


                            if (Convert.ToInt32(l.Rows[b + 17]["Atual"].ToString()) < Convert.ToInt32(l.Rows[b + 17]["Anterior"].ToString()))
                            {
                                txt64__.Text = l.Rows[b + 17]["Anterior"].ToString();
                            }
                            if (Convert.ToInt32(l.Rows[b + 17]["Atual"].ToString()) > Convert.ToInt32(l.Rows[b + 17]["Anterior"].ToString()))
                            {
                                txt64__.Text = l.Rows[b + 17]["Atual"].ToString();
                            }
                            if (String.IsNullOrEmpty(txt64__.Text) == true)
                            {
                                txt64__.Text = l.Rows[b + 17]["Anterior"].ToString();
                            }

                            if (Convert.ToInt32(l.Rows[b + 18]["Atual"].ToString()) < Convert.ToInt32(l.Rows[b + 18]["Anterior"].ToString()))
                            {
                                txt65__.Text = l.Rows[b + 18]["Anterior"].ToString();
                            }
                            if (Convert.ToInt32(l.Rows[b + 18]["Atual"].ToString()) > Convert.ToInt32(l.Rows[b + 18]["Anterior"].ToString()))
                            {
                                txt65__.Text = l.Rows[b + 18]["Atual"].ToString();
                            }
                            if (String.IsNullOrEmpty(txt65__.Text) == true)
                            {
                                txt65__.Text = l.Rows[b + 18]["Anterior"].ToString();
                            }


                            if (Convert.ToInt32(l.Rows[b + 19]["Atual"].ToString()) < Convert.ToInt32(l.Rows[b + 19]["Anterior"].ToString()))
                            {
                                txt66__.Text = l.Rows[b + 19]["Anterior"].ToString();
                            }
                            if (Convert.ToInt32(l.Rows[b + 19]["Atual"].ToString()) > Convert.ToInt32(l.Rows[b + 19]["Anterior"].ToString()))
                            {
                                txt66__.Text = l.Rows[b + 19]["Atual"].ToString();
                            }
                            if (String.IsNullOrEmpty(txt66__.Text) == true)
                            {
                                txt66__.Text = l.Rows[b + 19]["Anterior"].ToString();
                            }


                            if (Convert.ToInt32(l.Rows[b + 20]["Atual"].ToString()) < Convert.ToInt32(l.Rows[b + 20]["Anterior"].ToString()))
                            {
                                txt67__.Text = l.Rows[b + 20]["Anterior"].ToString();
                            }
                            if (Convert.ToInt32(l.Rows[b + 20]["Atual"].ToString()) > Convert.ToInt32(l.Rows[b + 20]["Anterior"].ToString()))
                            {
                                txt67__.Text = l.Rows[b + 20]["Atual"].ToString();
                            }
                            if (String.IsNullOrEmpty(txt67__.Text) == true)
                            {
                                txt67__.Text = l.Rows[b + 20]["Anterior"].ToString();
                            }


                            if (Convert.ToInt32(l.Rows[b + 21]["Atual"].ToString()) < Convert.ToInt32(l.Rows[b + 21]["Anterior"].ToString()))
                            {
                                txt68__.Text = l.Rows[b + 21]["Anterior"].ToString();
                            }
                            if (Convert.ToInt32(l.Rows[b + 21]["Atual"].ToString()) > Convert.ToInt32(l.Rows[b + 21]["Anterior"].ToString()))
                            {
                                txt68__.Text = l.Rows[b + 21]["Atual"].ToString();
                            }
                            if (String.IsNullOrEmpty(txt68__.Text) == true)
                            {
                                txt68__.Text = l.Rows[b + 21]["Anterior"].ToString();
                            }


                            if (Convert.ToInt32(l.Rows[b + 22]["Atual"].ToString()) < Convert.ToInt32(l.Rows[b + 22]["Anterior"].ToString()))
                            {
                                txt69__.Text = l.Rows[b + 22]["Anterior"].ToString();
                            }
                            if (Convert.ToInt32(l.Rows[b + 22]["Atual"].ToString()) > Convert.ToInt32(l.Rows[b + 22]["Anterior"].ToString()))
                            {
                                txt69__.Text = l.Rows[b + 22]["Atual"].ToString();
                            }
                            if (String.IsNullOrEmpty(txt69__.Text) == true)
                            {
                                txt69__.Text = l.Rows[b + 22]["Anterior"].ToString();
                            }


                            if (Convert.ToInt32(l.Rows[b + 23]["Atual"].ToString()) < Convert.ToInt32(l.Rows[b + 23]["Anterior"].ToString()))
                            {
                                txt70__.Text = l.Rows[b + 23]["Anterior"].ToString();
                            }
                            if (Convert.ToInt32(l.Rows[b + 23]["Atual"].ToString()) > Convert.ToInt32(l.Rows[b + 23]["Anterior"].ToString()))
                            {
                                txt70__.Text = l.Rows[b + 23]["Atual"].ToString();
                            }
                            if (String.IsNullOrEmpty(txt70__.Text) == true)
                            {
                                txt70__.Text = l.Rows[b + 23]["Anterior"].ToString();
                            }


                            if (Convert.ToInt32(l.Rows[b + 24]["Atual"].ToString()) < Convert.ToInt32(l.Rows[b + 24]["Anterior"].ToString()))
                            {
                                txt71__.Text = l.Rows[b + 24]["Anterior"].ToString();
                            }
                            if (Convert.ToInt32(l.Rows[b + 24]["Atual"].ToString()) > Convert.ToInt32(l.Rows[b + 24]["Anterior"].ToString()))
                            {
                                txt71__.Text = l.Rows[b + 24]["Atual"].ToString();
                            }
                            if (String.IsNullOrEmpty(txt71__.Text) == true)
                            {
                                txt71__.Text = l.Rows[b + 24]["Anterior"].ToString();
                            }


                            if (Convert.ToInt32(l.Rows[b + 25]["Atual"].ToString()) < Convert.ToInt32(l.Rows[b + 25]["Anterior"].ToString()))
                            {
                                txt72__.Text = l.Rows[b + 25]["Anterior"].ToString();
                            }
                            if (Convert.ToInt32(l.Rows[b + 25]["Atual"].ToString()) > Convert.ToInt32(l.Rows[b + 25]["Anterior"].ToString()))
                            {
                                txt72__.Text = l.Rows[b + 25]["Atual"].ToString();
                            }
                            if (String.IsNullOrEmpty(txt72__.Text) == true)
                            {
                                txt72__.Text = l.Rows[b + 25]["Anterior"].ToString();
                            }



                            if (Convert.ToInt32(l.Rows[b + 26]["Atual"].ToString()) < Convert.ToInt32(l.Rows[b + 26]["Anterior"].ToString()))
                            {
                                txt73__.Text = l.Rows[b + 26]["Anterior"].ToString();
                            }
                            if (Convert.ToInt32(l.Rows[b + 26]["Atual"].ToString()) > Convert.ToInt32(l.Rows[b + 26]["Anterior"].ToString()))
                            {
                                txt73__.Text = l.Rows[b + 26]["Atual"].ToString();
                            }
                            if (String.IsNullOrEmpty(txt73__.Text) == true)
                            {
                                txt73__.Text = l.Rows[b + 26]["Anterior"].ToString();
                            }


                            if (Convert.ToInt32(l.Rows[b + 27]["Atual"].ToString()) < Convert.ToInt32(l.Rows[b + 27]["Anterior"].ToString()))
                            {
                                txt74__.Text = l.Rows[b + 27]["Anterior"].ToString();
                            }
                            if (Convert.ToInt32(l.Rows[b + 27]["Atual"].ToString()) > Convert.ToInt32(l.Rows[b + 27]["Anterior"].ToString()))
                            {
                                txt74__.Text = l.Rows[b + 27]["Atual"].ToString();
                            }
                            if (String.IsNullOrEmpty(txt74__.Text) == true)
                            {
                                txt74__.Text = l.Rows[b + 27]["Anterior"].ToString();
                            }


                            if (Convert.ToInt32(l.Rows[b + 28]["Atual"].ToString()) < Convert.ToInt32(l.Rows[b + 28]["Anterior"].ToString()))
                            {
                                txt75__.Text = l.Rows[b + 28]["Anterior"].ToString();
                            }
                            if (Convert.ToInt32(l.Rows[b + 28]["Atual"].ToString()) > Convert.ToInt32(l.Rows[b + 28]["Anterior"].ToString()))
                            {
                                txt75__.Text = l.Rows[b + 28]["Atual"].ToString();
                            }
                            if (String.IsNullOrEmpty(txt75__.Text) == true)
                            {
                                txt75__.Text = l.Rows[b + 28]["Anterior"].ToString();
                            }


                            if (Convert.ToInt32(l.Rows[b + 29]["Atual"].ToString()) < Convert.ToInt32(l.Rows[b + 29]["Anterior"].ToString()))
                            {
                                txt76__.Text = l.Rows[b + 29]["Anterior"].ToString();
                            }
                            if (Convert.ToInt32(l.Rows[b + 29]["Atual"].ToString()) > Convert.ToInt32(l.Rows[b + 29]["Anterior"].ToString()))
                            {
                                txt76__.Text = l.Rows[b + 29]["Atual"].ToString();
                            }
                            if (String.IsNullOrEmpty(txt76__.Text) == true)
                            {
                                txt76__.Text = l.Rows[b + 29]["Anterior"].ToString();
                            }



                            if (Convert.ToInt32(l.Rows[b + 30]["Atual"].ToString()) < Convert.ToInt32(l.Rows[b + 30]["Anterior"].ToString()))
                            {
                                txt77__.Text = l.Rows[b + 30]["Anterior"].ToString();
                            }
                            if (Convert.ToInt32(l.Rows[b + 30]["Atual"].ToString()) > Convert.ToInt32(l.Rows[b + 30]["Anterior"].ToString()))
                            {
                                txt77__.Text = l.Rows[b + 30]["Atual"].ToString();
                            }
                            if (String.IsNullOrEmpty(txt77__.Text) == true)
                            {
                                txt77__.Text = l.Rows[b + 30]["Anterior"].ToString();
                            }


                            if (Convert.ToInt32(l.Rows[b + 31]["Atual"].ToString()) < Convert.ToInt32(l.Rows[b + 31]["Anterior"].ToString()))
                            {
                                txt78__.Text = l.Rows[b + 31]["Anterior"].ToString();
                            }
                            if (Convert.ToInt32(l.Rows[b + 31]["Atual"].ToString()) > Convert.ToInt32(l.Rows[b + 31]["Anterior"].ToString()))
                            {
                                txt78__.Text = l.Rows[b + 31]["Atual"].ToString();
                            }
                            if (String.IsNullOrEmpty(txt78__.Text) == true)
                            {
                                txt78__.Text = l.Rows[b + 31]["Anterior"].ToString();
                            }


                            if (Convert.ToInt32(l.Rows[b + 32]["Atual"].ToString()) < Convert.ToInt32(l.Rows[b + 32]["Anterior"].ToString()))
                            {
                                txt79__.Text = l.Rows[b + 32]["Anterior"].ToString();
                            }
                            if (Convert.ToInt32(l.Rows[b + 32]["Atual"].ToString()) > Convert.ToInt32(l.Rows[b + 32]["Anterior"].ToString()))
                            {
                                txt79__.Text = l.Rows[b + 32]["Atual"].ToString();
                            }
                            if (String.IsNullOrEmpty(txt79__.Text) == true)
                            {
                                txt79__.Text = l.Rows[b + 32]["Anterior"].ToString();
                            }

                            if (Convert.ToInt32(l.Rows[b + 33]["Atual"].ToString()) < Convert.ToInt32(l.Rows[b + 33]["Anterior"].ToString()))
                            {
                                txt80__.Text = l.Rows[b + 33]["Anterior"].ToString();
                            }
                            if (Convert.ToInt32(l.Rows[b + 33]["Atual"].ToString()) > Convert.ToInt32(l.Rows[b + 33]["Anterior"].ToString()))
                            {
                                txt80__.Text = l.Rows[b + 33]["Atual"].ToString();
                            }
                            if (String.IsNullOrEmpty(txt80__.Text) == true)
                            {
                                txt80__.Text = l.Rows[b + 33]["Anterior"].ToString();
                            }


                            if (Convert.ToInt32(l.Rows[b + 34]["Atual"].ToString()) < Convert.ToInt32(l.Rows[b + 34]["Anterior"].ToString()))
                            {
                                txt81__.Text = l.Rows[b + 34]["Anterior"].ToString();
                            }
                            if (Convert.ToInt32(l.Rows[b + 34]["Atual"].ToString()) > Convert.ToInt32(l.Rows[b + 34]["Anterior"].ToString()))
                            {
                                txt81__.Text = l.Rows[b + 34]["Atual"].ToString();
                            }
                            if (String.IsNullOrEmpty(txt81__.Text) == true)
                            {
                                txt81__.Text = l.Rows[b + 34]["Anterior"].ToString();
                            }


                            if (Convert.ToInt32(l.Rows[b + 35]["Atual"].ToString()) < Convert.ToInt32(l.Rows[b + 35]["Anterior"].ToString()))
                            {
                                txt82__.Text = l.Rows[b + 35]["Anterior"].ToString();
                            }
                            if (Convert.ToInt32(l.Rows[b + 35]["Atual"].ToString()) > Convert.ToInt32(l.Rows[b + 35]["Anterior"].ToString()))
                            {
                                txt82__.Text = l.Rows[b + 35]["Atual"].ToString();
                            }
                            if (String.IsNullOrEmpty(txt82__.Text) == true)
                            {
                                txt82__.Text = l.Rows[b + 35]["Anterior"].ToString();
                            }


                            if (Convert.ToInt32(l.Rows[b + 36]["Atual"].ToString()) < Convert.ToInt32(l.Rows[b + 36]["Anterior"].ToString()))
                            {
                                txt83__.Text = l.Rows[b + 36]["Anterior"].ToString();
                            }
                            if (Convert.ToInt32(l.Rows[b + 36]["Atual"].ToString()) > Convert.ToInt32(l.Rows[b + 36]["Anterior"].ToString()))
                            {
                                txt83__.Text = l.Rows[b + 36]["Atual"].ToString();
                            }
                            if (String.IsNullOrEmpty(txt83__.Text) == true)
                            {
                                txt83__.Text = l.Rows[b + 36]["Anterior"].ToString();
                            }
                           

                        }
                        else
                        {
                            int k = qtde2;

                            //limpar campos
                            txt17__.Text = "";
                            txt8__.Text = "";
                            txt7__.Text = "";
                            txt14__.Text = "";
                            txt42__.Text = "";
                            txt27__.Text = "";
                            txt44__.Text = "";
                            txt10__.Text = "";
                            txt11__.Text = "";
                            txt12__.Text = "";
                            txt13__.Text = "";
                            txt15__.Text = "";
                            txt18__.Text = "";
                            txt19__.Text = "";
                            txt28__.Text = "";
                            txt29__.Text = "";
                            txt30__.Text = "";
                            txt31__.Text = "";
                            txt32__.Text = "";
                            txt33__.Text = "";
                            txt34__.Text = "";
                            txt35__.Text = "";
                            txt36__.Text = "";
                            txt37__.Text = "";
                            txt38__.Text = "";
                            txt39__.Text = "";
                            txt40__.Text = "";
                            txt41__.Text = "";
                            txt45__.Text = "";
                            txt46__.Text = "";
                            txt47__.Text = "";
                            txt48__.Text = "";
                            txt51__.Text = "";
                            txt52__.Text = "";
                            txt20__.Text = "";
                            txt21__.Text = "";
                            txt22__.Text = "";


                            txt24__.Text = "";
                            txt25__.Text = "";
                            txt26__.Text = "";
                            txt43__.Text = "";
                            txt49__.Text = "";
                            txt50__.Text = "";
                            txt53__.Text = "";
                            txt54__.Text = "";
                            txt55__.Text = "";
                            txt56__.Text = "";
                            txt57__.Text = "";
                            txt58__.Text = "";
                            txt59__.Text = "";
                            txt60__.Text = "";
                            txt61__.Text = "";
                            txt62__.Text = "";
                            txt63__.Text = "";
                            txt64__.Text = "";
                            txt65__.Text = "";
                            txt66__.Text = "";
                            txt67__.Text = "";
                            txt68__.Text = "";
                            txt69__.Text = "";
                            txt70__.Text = "";
                            txt71__.Text = "";
                            txt72__.Text = "";
                            txt73__.Text = "";
                            txt74__.Text = "";
                            txt75__.Text = "";
                            txt76__.Text = "";
                            txt77__.Text = "";
                            txt78__.Text = "";
                            txt79__.Text = "";
                            txt80__.Text = "";
                            txt81__.Text = "";
                            txt82__.Text = "";
                            txt83__.Text = "";

                            
                            if (k > 0)
                            {
                                txt17__.Text = l.Rows[b]["Nome"].ToString();
                            }
                            
                            k--;
                            if (k > 0)
                            {
                                txt8__.Text = l.Rows[b + 1]["Nome"].ToString();    
                            }
                            
                            k--;
                            if (k > 0)
                            {
                                txt7__.Text = l.Rows[b + 2]["Nome"].ToString();
                            }
                            

                            k--;
                            if (k > 0)
                            {
                                txt14__.Text = l.Rows[b + 3]["Nome"].ToString();
                            }
                            k--;
                            if (k > 0)
                            {
                                txt42__.Text = l.Rows[b + 4]["Nome"].ToString();
                            }
                            
                            k--;
                            if (k > 0)
                            {
                                txt27__.Text = l.Rows[b + 5]["Nome"].ToString();
                            }
                            
                            k--;
                            if (k > 0)
                            {
                                txt44__.Text = l.Rows[b + 6]["Nome"].ToString();
                            }
                            
                            k--;
                            if (k > 0)
                            {
                                txt10__.Text = l.Rows[b + 7]["Nome"].ToString();
                            }
                            
                            k--;
                            if (k > 0)
                            {
                                txt11__.Text = l.Rows[b + 8]["Nome"].ToString();
                            }
                            
                            k--;
                            if (k > 0)
                            {
                                txt12__.Text = l.Rows[b + 9]["Nome"].ToString();
                            }
                            
                            k--;
                            if (k > 0)
                            {
                                txt13__.Text = l.Rows[b + 10]["Nome"].ToString();
                            }
                            
                            k--;
                            if (k > 0)
                            {
                                txt15__.Text = l.Rows[b + 11]["Nome"].ToString();
                            }
                            
                            k--;
                            if (k > 0)
                            {
                                txt18__.Text = l.Rows[b + 12]["Nome"].ToString();
                            }
                            
                            k--;
                            if (k > 0)
                            {
                                txt19__.Text = l.Rows[b + 13]["Nome"].ToString();
                            }
                            
                            k--;
                            if (k > 0)
                            {
                                txt28__.Text = l.Rows[b + 14]["Nome"].ToString();
                            }
                            
                            k--;
                            if (k > 0)
                            {
                                txt29__.Text = l.Rows[b + 15]["Nome"].ToString();
                            }
                            
                            k--;
                            if (k > 0)
                            {
                                txt30__.Text = l.Rows[b + 16]["Nome"].ToString();
                            }
                            
                            k--;
                            if (k > 0)
                            {
                                txt31__.Text = l.Rows[b + 17]["Nome"].ToString();
                            }
                            
                            k--;
                            if (k > 0)
                            {
                                txt32__.Text = l.Rows[b + 18]["Nome"].ToString();
                            }
                            
                            k--;
                            if (k > 0)
                            {
                                txt33__.Text = l.Rows[b + 19]["Nome"].ToString();
                            }
                            
                            k--;
                            if (k > 0)
                            {
                                txt34__.Text = l.Rows[b + 20]["Nome"].ToString();
                            }
                            
                            k--;
                            if (k > 0)
                            {
                                txt35__.Text = l.Rows[b + 21]["Nome"].ToString();
                            }
                           
                            k--;
                            if (k > 0)
                            {
                                txt36__.Text = l.Rows[b + 22]["Nome"].ToString();
                            }
                            
                            k--;
                            if (k > 0)
                            {
                                txt37__.Text = l.Rows[b + 23]["Nome"].ToString();
                            }
                            
                            k--;
                            if (k > 0)
                            {
                                txt38__.Text = l.Rows[b + 24]["Nome"].ToString();
                            }
                            
                            k--;
                            if (k > 0)
                            {
                                txt39__.Text = l.Rows[b + 25]["Nome"].ToString();
                            }
                            
                            k--;
                            if (k > 0)
                            {
                                txt40__.Text = l.Rows[b + 26]["Nome"].ToString();
                            }
                            
                            k--;
                            if (k > 0)
                            {
                                txt41__.Text = l.Rows[b + 27]["Nome"].ToString();
                            }
                           
                            k--;
                            if (k > 0)
                            {
                                txt45__.Text = l.Rows[b + 28]["Nome"].ToString();
                            }
                           
                            k--;
                            if (k > 0)
                            {
                                txt46__.Text = l.Rows[b + 29]["Nome"].ToString();
                            }
                            
                            k--;
                            if (k > 0)
                            {
                                txt47__.Text = l.Rows[b + 30]["Nome"].ToString();
                            }
                            
                            k--;
                            if (k > 0)
                            {
                                txt48__.Text = l.Rows[b + 31]["Nome"].ToString();
                            }
                            
                            k--;
                            if (k > 0)
                            {
                                txt51__.Text = l.Rows[b + 32]["Nome"].ToString();
                            }
                            
                            k--;
                            if (k > 0)
                            {
                                txt52__.Text = l.Rows[b + 33]["Nome"].ToString();
                            }
                            
                            k--;
                            if (k > 0)
                            {
                                txt20__.Text = l.Rows[b + 34]["Nome"].ToString();
                            }
                            
                            k--;
                            if (k > 0)
                            {
                                txt21__.Text = l.Rows[b + 35]["Nome"].ToString();
                            }
                            
                            k--;
                            if (k > 0)
                            {
                                txt22__.Text = l.Rows[b + 36]["Nome"].ToString();
                            }
                           

                            k = qtde2;

                            if (k > 0)
                            {
                                if (Convert.ToInt32(l.Rows[b]["Atual"].ToString()) < Convert.ToInt32(l.Rows[b]["Anterior"].ToString()))
                                {
                                    txt24__.Text = l.Rows[b]["Anterior"].ToString();
                                }
                                if (Convert.ToInt32(l.Rows[b]["Atual"].ToString()) > Convert.ToInt32(l.Rows[b]["Anterior"].ToString()))
                                {
                                    txt24__.Text = l.Rows[b]["Atual"].ToString();
                                }
                                if (String.IsNullOrEmpty(txt24__.Text) == true)
                                {
                                    txt24__.Text = l.Rows[b]["Anterior"].ToString();
                                }
                                
                            }
                           
                            k--;
                            if (k > 0)
                            {
                                if (Convert.ToInt32(l.Rows[b + 1]["Atual"].ToString()) < Convert.ToInt32(l.Rows[b + 1]["Anterior"].ToString()))
                                {
                                    txt25__.Text = l.Rows[b + 1]["Anterior"].ToString();
                                }
                                if (Convert.ToInt32(l.Rows[b + 1]["Atual"].ToString()) > Convert.ToInt32(l.Rows[b + 1]["Anterior"].ToString()))
                                {
                                    txt25__.Text = l.Rows[b + 1]["Atual"].ToString();
                                }
                                if (String.IsNullOrEmpty(txt25__.Text) == true)
                                {
                                    txt25__.Text = l.Rows[b + 1]["Anterior"].ToString();
                                }
                                
                            }
                            
                            k--;
                            if (k > 0)
                            {
                                if (Convert.ToInt32(l.Rows[b + 2]["Atual"].ToString()) < Convert.ToInt32(l.Rows[b + 2]["Anterior"].ToString()))
                                {
                                    txt26__.Text = l.Rows[b + 2]["Anterior"].ToString();
                                }
                                if (Convert.ToInt32(l.Rows[b + 2]["Atual"].ToString()) > Convert.ToInt32(l.Rows[b + 2]["Anterior"].ToString()))
                                {
                                    txt26__.Text = l.Rows[b + 2]["Atual"].ToString();
                                }
                                if (String.IsNullOrEmpty(txt26__.Text) == true)
                                {
                                    txt26__.Text = l.Rows[b + 2]["Anterior"].ToString();
                                }
                                
                            }
                            
                            k--;
                            if (k > 0)
                            {
                                if (Convert.ToInt32(l.Rows[b + 3]["Atual"].ToString()) < Convert.ToInt32(l.Rows[b + 3]["Anterior"].ToString()))
                                {
                                    txt43__.Text = l.Rows[b + 3]["Anterior"].ToString();
                                }
                                if (Convert.ToInt32(l.Rows[b + 3]["Atual"].ToString()) > Convert.ToInt32(l.Rows[b + 3]["Anterior"].ToString()))
                                {
                                    txt43__.Text = l.Rows[b + 3]["Atual"].ToString();
                                }
                                if (String.IsNullOrEmpty(txt43__.Text) == true)
                                {
                                    txt43__.Text = l.Rows[b + 3]["Anterior"].ToString();
                                }
                                
                                
                            }
                            
                            k--;
                            if (k > 0)
                            {
                                if (Convert.ToInt32(l.Rows[b + 4]["Atual"].ToString()) < Convert.ToInt32(l.Rows[b + 4]["Anterior"].ToString()))
                                {
                                    txt49__.Text = l.Rows[b + 4]["Anterior"].ToString();
                                }
                                if (Convert.ToInt32(l.Rows[b + 4]["Atual"].ToString()) > Convert.ToInt32(l.Rows[b + 4]["Anterior"].ToString()))
                                {
                                    txt49__.Text = l.Rows[b + 4]["Atual"].ToString();
                                }
                                if (String.IsNullOrEmpty(txt49__.Text) == true)
                                {
                                    txt49__.Text = l.Rows[b + 4]["Anterior"].ToString();
                                }
                                
                            }
                            
                            k--;
                            if (k > 0)
                            {
                                if (Convert.ToInt32(l.Rows[b + 5]["Atual"].ToString()) < Convert.ToInt32(l.Rows[b + 5]["Anterior"].ToString()))
                                {
                                    txt50__.Text = l.Rows[b + 5]["Anterior"].ToString();
                                }
                                if (Convert.ToInt32(l.Rows[b + 5]["Atual"].ToString()) > Convert.ToInt32(l.Rows[b + 5]["Anterior"].ToString()))
                                {
                                    txt50__.Text = l.Rows[b + 5]["Atual"].ToString();
                                }
                                if (String.IsNullOrEmpty(txt50__.Text) == true)
                                {
                                    txt50__.Text = l.Rows[b + 5]["Anterior"].ToString();
                                }
                                
                            }
                           
                            k--;
                            if (k > 0)
                            {
                                if (Convert.ToInt32(l.Rows[b + 6]["Atual"].ToString()) < Convert.ToInt32(l.Rows[b + 6]["Anterior"].ToString()))
                                {
                                    txt53__.Text = l.Rows[b + 6]["Anterior"].ToString();
                                }
                                if (Convert.ToInt32(l.Rows[b + 6]["Atual"].ToString()) > Convert.ToInt32(l.Rows[b + 6]["Anterior"].ToString()))
                                {
                                    txt53__.Text = l.Rows[b + 6]["Atual"].ToString();
                                }
                                if (String.IsNullOrEmpty(txt53__.Text) == true)
                                {
                                    txt53__.Text = l.Rows[b + 6]["Anterior"].ToString();
                                }
                                
                            }
                            
                            k--;
                            if (k > 0)
                            {
                                if (Convert.ToInt32(l.Rows[b + 7]["Atual"].ToString()) < Convert.ToInt32(l.Rows[b + 7]["Anterior"].ToString()))
                                {
                                    txt54__.Text = l.Rows[b + 7]["Anterior"].ToString();
                                }
                                if (Convert.ToInt32(l.Rows[b + 7]["Atual"].ToString()) > Convert.ToInt32(l.Rows[b + 7]["Anterior"].ToString()))
                                {
                                    txt54__.Text = l.Rows[b + 7]["Atual"].ToString();
                                }
                                if (String.IsNullOrEmpty(txt54__.Text) == true)
                                {
                                    txt54__.Text = l.Rows[b + 7]["Anterior"].ToString();
                                }
                               
                            }
                            
                            k--;
                            if (k > 0)
                            {
                                if (Convert.ToInt32(l.Rows[b + 8]["Atual"].ToString()) < Convert.ToInt32(l.Rows[b + 8]["Anterior"].ToString()))
                                {
                                    txt55__.Text = l.Rows[b + 8]["Anterior"].ToString();
                                }
                                if (Convert.ToInt32(l.Rows[b + 8]["Atual"].ToString()) > Convert.ToInt32(l.Rows[b + 8]["Anterior"].ToString()))
                                {
                                    txt55__.Text = l.Rows[b + 8]["Atual"].ToString();
                                }
                                if (String.IsNullOrEmpty(txt55__.Text) == true)
                                {
                                    txt55__.Text = l.Rows[b + 8]["Anterior"].ToString();
                                }
                                
                            }
                            
                            k--;
                            if (k > 0)
                            {
                                if (Convert.ToInt32(l.Rows[b + 9]["Atual"].ToString()) < Convert.ToInt32(l.Rows[b + 9]["Anterior"].ToString()))
                                {
                                    txt56__.Text = l.Rows[b + 9]["Anterior"].ToString();
                                }
                                if (Convert.ToInt32(l.Rows[b + 9]["Atual"].ToString()) > Convert.ToInt32(l.Rows[b + 9]["Anterior"].ToString()))
                                {
                                    txt56__.Text = l.Rows[b + 9]["Atual"].ToString();
                                }
                                if (String.IsNullOrEmpty(txt56__.Text) == true)
                                {
                                    txt56__.Text = l.Rows[b + 9]["Anterior"].ToString();
                                }
                                
                            }
                           
                            k--;
                            if (k > 0)
                            {
                                if (Convert.ToInt32(l.Rows[b + 10]["Atual"].ToString()) < Convert.ToInt32(l.Rows[b + 10]["Anterior"].ToString()))
                                {
                                    txt57__.Text = l.Rows[b + 10]["Anterior"].ToString();
                                }
                                if (Convert.ToInt32(l.Rows[b + 10]["Atual"].ToString()) > Convert.ToInt32(l.Rows[b + 10]["Anterior"].ToString()))
                                {
                                    txt57__.Text = l.Rows[b + 10]["Atual"].ToString();
                                }
                                if (String.IsNullOrEmpty(txt57__.Text) == true)
                                {
                                    txt57__.Text = l.Rows[b + 10]["Anterior"].ToString();
                                }
                               
                            }
                            
                            k--;
                            if (k > 0)
                            {
                                if (Convert.ToInt32(l.Rows[b + 11]["Atual"].ToString()) < Convert.ToInt32(l.Rows[b + 11]["Anterior"].ToString()))
                                {
                                    txt58__.Text = l.Rows[b + 11]["Anterior"].ToString();
                                }
                                if (Convert.ToInt32(l.Rows[b + 11]["Atual"].ToString()) > Convert.ToInt32(l.Rows[b + 11]["Anterior"].ToString()))
                                {
                                    txt58__.Text = l.Rows[b + 11]["Atual"].ToString();
                                }
                                if (String.IsNullOrEmpty(txt58__.Text) == true)
                                {
                                    txt58__.Text = l.Rows[b + 11]["Anterior"].ToString();
                                }
                                
                            }
                            
                            k--;
                            if (k > 0)
                            {
                                if (Convert.ToInt32(l.Rows[b + 12]["Atual"].ToString()) < Convert.ToInt32(l.Rows[b + 12]["Anterior"].ToString()))
                                {
                                    txt59__.Text = l.Rows[b + 12]["Anterior"].ToString();
                                }
                                if (Convert.ToInt32(l.Rows[b + 12]["Atual"].ToString()) > Convert.ToInt32(l.Rows[b + 12]["Anterior"].ToString()))
                                {
                                    txt59__.Text = l.Rows[b + 12]["Atual"].ToString();
                                }
                                if (String.IsNullOrEmpty(txt59__.Text) == true)
                                {
                                    txt59__.Text = l.Rows[b + 12]["Anterior"].ToString();
                                }
                                
                            }
                            
                            k--;
                            if (k > 0)
                            {
                                if (Convert.ToInt32(l.Rows[b + 13]["Atual"].ToString()) < Convert.ToInt32(l.Rows[b + 13]["Anterior"].ToString()))
                                {
                                    txt60__.Text = l.Rows[b + 13]["Anterior"].ToString();
                                }
                                if (Convert.ToInt32(l.Rows[b + 13]["Atual"].ToString()) > Convert.ToInt32(l.Rows[b + 13]["Anterior"].ToString()))
                                {
                                    txt60__.Text = l.Rows[b + 13]["Atual"].ToString();
                                }
                                if (String.IsNullOrEmpty(txt60__.Text) == true)
                                {
                                    txt60__.Text = l.Rows[b + 13]["Anterior"].ToString();
                                }
                                
                            }
                           
                            k--;
                            if (k > 0)
                            {
                                if (Convert.ToInt32(l.Rows[b + 14]["Atual"].ToString()) < Convert.ToInt32(l.Rows[b + 14]["Anterior"].ToString()))
                                {
                                    txt61__.Text = l.Rows[b + 14]["Anterior"].ToString();
                                }
                                if (Convert.ToInt32(l.Rows[b + 14]["Atual"].ToString()) > Convert.ToInt32(l.Rows[b + 14]["Anterior"].ToString()))
                                {
                                    txt61__.Text = l.Rows[b + 14]["Atual"].ToString();
                                }
                                if (String.IsNullOrEmpty(txt61__.Text) == true)
                                {
                                    txt61__.Text = l.Rows[b + 14]["Anterior"].ToString();
                                }
                                
                            }
                           
                            k--;
                            if (k > 0)
                            {
                                if (Convert.ToInt32(l.Rows[b + 15]["Atual"].ToString()) < Convert.ToInt32(l.Rows[b + 15]["Anterior"].ToString()))
                                {
                                    txt62__.Text = l.Rows[b + 15]["Anterior"].ToString();
                                }
                                if (Convert.ToInt32(l.Rows[b + 15]["Atual"].ToString()) > Convert.ToInt32(l.Rows[b + 15]["Anterior"].ToString()))
                                {
                                    txt62__.Text = l.Rows[b + 15]["Atual"].ToString();
                                }
                                if (String.IsNullOrEmpty(txt62__.Text) == true)
                                {
                                    txt62__.Text = l.Rows[b + 15]["Anterior"].ToString();
                                }
                                
                            }
                            
                            k--;
                            if (k > 0)
                            {
                                if (Convert.ToInt32(l.Rows[b + 16]["Atual"].ToString()) < Convert.ToInt32(l.Rows[b + 16]["Anterior"].ToString()))
                                {
                                    txt63__.Text = l.Rows[b + 16]["Anterior"].ToString();
                                }
                                if (Convert.ToInt32(l.Rows[b + 16]["Atual"].ToString()) > Convert.ToInt32(l.Rows[b + 16]["Anterior"].ToString()))
                                {
                                    txt63__.Text = l.Rows[b + 16]["Atual"].ToString();
                                }
                                if (String.IsNullOrEmpty(txt63__.Text) == true)
                                {
                                    txt63__.Text = l.Rows[b + 16]["Anterior"].ToString();
                                }
                                
                            }
                            
                            k--;
                            if (k > 0)
                            {
                                if (Convert.ToInt32(l.Rows[b + 17]["Atual"].ToString()) < Convert.ToInt32(l.Rows[b + 17]["Anterior"].ToString()))
                                {
                                    txt64__.Text = l.Rows[b + 17]["Anterior"].ToString();
                                }
                                if (Convert.ToInt32(l.Rows[b + 17]["Atual"].ToString()) > Convert.ToInt32(l.Rows[b + 17]["Anterior"].ToString()))
                                {
                                    txt64__.Text = l.Rows[b + 17]["Atual"].ToString();
                                }
                                if (String.IsNullOrEmpty(txt64__.Text) == true)
                                {
                                    txt64__.Text = l.Rows[b + 17]["Anterior"].ToString();
                                }
                                
                            }
                            
                            k--;
                            if (k > 0)
                            {
                                if (Convert.ToInt32(l.Rows[b + 18]["Atual"].ToString()) < Convert.ToInt32(l.Rows[b + 18]["Anterior"].ToString()))
                                {
                                    txt65__.Text = l.Rows[b + 18]["Anterior"].ToString();
                                }
                                if (Convert.ToInt32(l.Rows[b + 18]["Atual"].ToString()) > Convert.ToInt32(l.Rows[b + 18]["Anterior"].ToString()))
                                {
                                    txt65__.Text = l.Rows[b + 18]["Atual"].ToString();
                                }
                                if (String.IsNullOrEmpty(txt65__.Text) == true)
                                {
                                    txt65__.Text = l.Rows[b + 18]["Anterior"].ToString();
                                }
                                
                            }
                           
                            k--;
                            if (k > 0)
                            {
                                if (Convert.ToInt32(l.Rows[b + 19]["Atual"].ToString()) < Convert.ToInt32(l.Rows[b + 19]["Anterior"].ToString()))
                                {
                                    txt66__.Text = l.Rows[b + 19]["Anterior"].ToString();
                                }
                                if (Convert.ToInt32(l.Rows[b + 19]["Atual"].ToString()) > Convert.ToInt32(l.Rows[b + 19]["Anterior"].ToString()))
                                {
                                    txt66__.Text = l.Rows[b + 19]["Atual"].ToString();
                                }
                                if (String.IsNullOrEmpty(txt66__.Text) == true)
                                {
                                    txt66__.Text = l.Rows[b + 19]["Anterior"].ToString();
                                }
                                
                            }
                            
                            k--;
                            if (k > 0)
                            {
                                if (Convert.ToInt32(l.Rows[b + 20]["Atual"].ToString()) < Convert.ToInt32(l.Rows[b + 20]["Anterior"].ToString()))
                                {
                                    txt67__.Text = l.Rows[b + 20]["Anterior"].ToString();
                                }
                                if (Convert.ToInt32(l.Rows[b + 20]["Atual"].ToString()) > Convert.ToInt32(l.Rows[b + 20]["Anterior"].ToString()))
                                {
                                    txt67__.Text = l.Rows[b + 20]["Atual"].ToString();
                                }
                                if (String.IsNullOrEmpty(txt67__.Text) == true)
                                {
                                    txt67__.Text = l.Rows[b + 20]["Anterior"].ToString();
                                }
                                
                            }
                           
                            k--;
                            if (k > 0)
                            {
                                if (Convert.ToInt32(l.Rows[b + 21]["Atual"].ToString()) < Convert.ToInt32(l.Rows[b + 21]["Anterior"].ToString()))
                                {
                                    txt68__.Text = l.Rows[b + 21]["Anterior"].ToString();
                                }
                                if (Convert.ToInt32(l.Rows[b + 21]["Atual"].ToString()) > Convert.ToInt32(l.Rows[b + 21]["Anterior"].ToString()))
                                {
                                    txt68__.Text = l.Rows[b + 21]["Atual"].ToString();
                                }
                                if (String.IsNullOrEmpty(txt68__.Text) == true)
                                {
                                    txt68__.Text = l.Rows[b + 21]["Anterior"].ToString();
                                }
                               
                            }
                            
                            k--;
                            if (k > 0)
                            {
                                if (Convert.ToInt32(l.Rows[b + 22]["Atual"].ToString()) < Convert.ToInt32(l.Rows[b + 22]["Anterior"].ToString()))
                                {
                                    txt69__.Text = l.Rows[b + 22]["Anterior"].ToString();
                                }
                                if (Convert.ToInt32(l.Rows[b + 22]["Atual"].ToString()) > Convert.ToInt32(l.Rows[b + 22]["Anterior"].ToString()))
                                {
                                    txt69__.Text = l.Rows[b + 22]["Atual"].ToString();
                                }
                                if (String.IsNullOrEmpty(txt69__.Text) == true)
                                {
                                    txt69__.Text = l.Rows[b + 22]["Anterior"].ToString();
                                }
                                
                            }
                            
                            k--;
                            if (k > 0)
                            {
                                if (Convert.ToInt32(l.Rows[b + 23]["Atual"].ToString()) < Convert.ToInt32(l.Rows[b + 23]["Anterior"].ToString()))
                                {
                                    txt70__.Text = l.Rows[b + 23]["Anterior"].ToString();
                                }
                                if (Convert.ToInt32(l.Rows[b + 23]["Atual"].ToString()) > Convert.ToInt32(l.Rows[b + 23]["Anterior"].ToString()))
                                {
                                    txt70__.Text = l.Rows[b + 23]["Atual"].ToString();
                                }
                                if (String.IsNullOrEmpty(txt70__.Text) == true)
                                {
                                    txt70__.Text = l.Rows[b + 23]["Anterior"].ToString();
                                }
                                
                            }
                           
                            k--;
                            if (k > 0)
                            {
                                if (Convert.ToInt32(l.Rows[b + 24]["Atual"].ToString()) < Convert.ToInt32(l.Rows[b + 24]["Anterior"].ToString()))
                                {
                                    txt71__.Text = l.Rows[b + 24]["Anterior"].ToString();
                                }
                                if (Convert.ToInt32(l.Rows[b + 24]["Atual"].ToString()) > Convert.ToInt32(l.Rows[b + 24]["Anterior"].ToString()))
                                {
                                    txt71__.Text = l.Rows[b + 24]["Atual"].ToString();
                                }
                                if (String.IsNullOrEmpty(txt71__.Text) == true)
                                {
                                    txt71__.Text = l.Rows[b + 24]["Anterior"].ToString();
                                }
                                
                            }
                            
                            k--;
                            if (k > 0)
                            {
                                if (Convert.ToInt32(l.Rows[b + 25]["Atual"].ToString()) < Convert.ToInt32(l.Rows[b + 25]["Anterior"].ToString()))
                                {
                                    txt72__.Text = l.Rows[b + 25]["Anterior"].ToString();
                                }
                                if (Convert.ToInt32(l.Rows[b + 25]["Atual"].ToString()) > Convert.ToInt32(l.Rows[b + 25]["Anterior"].ToString()))
                                {
                                    txt72__.Text = l.Rows[b + 25]["Atual"].ToString();
                                }
                                if (String.IsNullOrEmpty(txt72__.Text) == true)
                                {
                                    txt72__.Text = l.Rows[b + 25]["Anterior"].ToString();
                                }
                                
                            }
                            
                            k--;
                            if (k > 0)
                            {
                                if (Convert.ToInt32(l.Rows[b + 26]["Atual"].ToString()) < Convert.ToInt32(l.Rows[b + 26]["Anterior"].ToString()))
                                {
                                    txt73__.Text = l.Rows[b + 26]["Anterior"].ToString();
                                }
                                if (Convert.ToInt32(l.Rows[b + 26]["Atual"].ToString()) > Convert.ToInt32(l.Rows[b + 26]["Anterior"].ToString()))
                                {
                                    txt73__.Text = l.Rows[b + 26]["Atual"].ToString();
                                }
                                if (String.IsNullOrEmpty(txt73__.Text) == true)
                                {
                                    txt73__.Text = l.Rows[b + 26]["Anterior"].ToString();
                                }
                                
                            }
                            
                            k--;
                            if (k > 0)
                            {
                                if (Convert.ToInt32(l.Rows[b + 27]["Atual"].ToString()) < Convert.ToInt32(l.Rows[b + 27]["Anterior"].ToString()))
                                {
                                    txt74__.Text = l.Rows[b + 27]["Anterior"].ToString();
                                }
                                if (Convert.ToInt32(l.Rows[b + 27]["Atual"].ToString()) > Convert.ToInt32(l.Rows[b + 27]["Anterior"].ToString()))
                                {
                                    txt74__.Text = l.Rows[b + 27]["Atual"].ToString();
                                }
                                if (String.IsNullOrEmpty(txt74__.Text) == true)
                                {
                                    txt74__.Text = l.Rows[b + 27]["Anterior"].ToString();
                                }
                                
                            }
                            
                            k--;
                            if (k > 0)
                            {
                                if (Convert.ToInt32(l.Rows[b + 28]["Atual"].ToString()) < Convert.ToInt32(l.Rows[b + 28]["Anterior"].ToString()))
                                {
                                    txt75__.Text = l.Rows[b + 28]["Anterior"].ToString();
                                }
                                if (Convert.ToInt32(l.Rows[b + 28]["Atual"].ToString()) > Convert.ToInt32(l.Rows[b + 28]["Anterior"].ToString()))
                                {
                                    txt75__.Text = l.Rows[b + 28]["Atual"].ToString();
                                }
                                if (String.IsNullOrEmpty(txt75__.Text) == true)
                                {
                                    txt75__.Text = l.Rows[b + 28]["Anterior"].ToString();
                                }
                                
                            }
                            
                            k--;
                            if (k > 0)
                            {
                                if (Convert.ToInt32(l.Rows[b + 29]["Atual"].ToString()) < Convert.ToInt32(l.Rows[b + 29]["Anterior"].ToString()))
                                {
                                    txt76__.Text = l.Rows[b + 29]["Anterior"].ToString();
                                }
                                if (Convert.ToInt32(l.Rows[b + 29]["Atual"].ToString()) > Convert.ToInt32(l.Rows[b + 29]["Anterior"].ToString()))
                                {
                                    txt76__.Text = l.Rows[b + 29]["Atual"].ToString();
                                }
                                if (String.IsNullOrEmpty(txt76__.Text) == true)
                                {
                                    txt76__.Text = l.Rows[b + 29]["Anterior"].ToString();
                                }
                                
                            }
                            
                            k--;
                            if (k > 0)
                            {
                                if (Convert.ToInt32(l.Rows[b + 30]["Atual"].ToString()) < Convert.ToInt32(l.Rows[b + 30]["Anterior"].ToString()))
                                {
                                    txt77__.Text = l.Rows[b + 30]["Anterior"].ToString();
                                }
                                if (Convert.ToInt32(l.Rows[b + 30]["Atual"].ToString()) > Convert.ToInt32(l.Rows[b + 30]["Anterior"].ToString()))
                                {
                                    txt77__.Text = l.Rows[b + 30]["Atual"].ToString();
                                }
                                if (String.IsNullOrEmpty(txt77__.Text) == true)
                                {
                                    txt77__.Text = l.Rows[b + 30]["Anterior"].ToString();
                                }
                                
                            }
                            
                            k--;
                            if (k > 0)
                            {
                                if (Convert.ToInt32(l.Rows[b + 31]["Atual"].ToString()) < Convert.ToInt32(l.Rows[b + 31]["Anterior"].ToString()))
                                {
                                    txt78__.Text = l.Rows[b + 31]["Anterior"].ToString();
                                }
                                if (Convert.ToInt32(l.Rows[b + 31]["Atual"].ToString()) > Convert.ToInt32(l.Rows[b + 31]["Anterior"].ToString()))
                                {
                                    txt78__.Text = l.Rows[b + 31]["Atual"].ToString();
                                }
                                if (String.IsNullOrEmpty(txt78__.Text) == true)
                                {
                                    txt78__.Text = l.Rows[b + 31]["Anterior"].ToString();
                                }
                                
                            }
                           
                            k--;
                            if (k > 0)
                            {
                                if (Convert.ToInt32(l.Rows[b + 32]["Atual"].ToString()) < Convert.ToInt32(l.Rows[b + 32]["Anterior"].ToString()))
                                {
                                    txt79__.Text = l.Rows[b + 32]["Anterior"].ToString();
                                }
                                if (Convert.ToInt32(l.Rows[b + 32]["Atual"].ToString()) > Convert.ToInt32(l.Rows[b + 32]["Anterior"].ToString()))
                                {
                                    txt79__.Text = l.Rows[b + 32]["Atual"].ToString();
                                }
                                if (String.IsNullOrEmpty(txt79__.Text) == true)
                                {
                                    txt79__.Text = l.Rows[b + 32]["Anterior"].ToString();
                                }
                                
                            }
                            
                            k--;
                            if (k > 0)
                            {
                                if (Convert.ToInt32(l.Rows[b + 33]["Atual"].ToString()) < Convert.ToInt32(l.Rows[b + 33]["Anterior"].ToString()))
                                {
                                    txt80__.Text = l.Rows[b + 33]["Anterior"].ToString();
                                }
                                if (Convert.ToInt32(l.Rows[b + 33]["Atual"].ToString()) > Convert.ToInt32(l.Rows[b + 33]["Anterior"].ToString()))
                                {
                                    txt80__.Text = l.Rows[b + 33]["Atual"].ToString();
                                }
                                if (String.IsNullOrEmpty(txt80__.Text) == true)
                                {
                                    txt80__.Text = l.Rows[b + 33]["Anterior"].ToString();
                                }
                               
                            }
                            
                            k--;
                            if (k > 0)
                            {
                                if (Convert.ToInt32(l.Rows[b + 34]["Atual"].ToString()) < Convert.ToInt32(l.Rows[b + 34]["Anterior"].ToString()))
                                {
                                    txt81__.Text = l.Rows[b + 34]["Anterior"].ToString();
                                }
                                if (Convert.ToInt32(l.Rows[b + 34]["Atual"].ToString()) > Convert.ToInt32(l.Rows[b + 34]["Anterior"].ToString()))
                                {
                                    txt81__.Text = l.Rows[b + 34]["Atual"].ToString();
                                }
                                if (String.IsNullOrEmpty(txt81__.Text) == true)
                                {
                                    txt81__.Text = l.Rows[b + 34]["Anterior"].ToString();
                                }
                                
                            }
                            
                            k--;
                            if (k > 0)
                            {
                                if (Convert.ToInt32(l.Rows[b + 35]["Atual"].ToString()) < Convert.ToInt32(l.Rows[b + 35]["Anterior"].ToString()))
                                {
                                    txt82__.Text = l.Rows[b + 35]["Anterior"].ToString();
                                }
                                if (Convert.ToInt32(l.Rows[b + 35]["Atual"].ToString()) > Convert.ToInt32(l.Rows[b + 35]["Anterior"].ToString()))
                                {
                                    txt82__.Text = l.Rows[b + 35]["Atual"].ToString();
                                }
                                if (String.IsNullOrEmpty(txt82__.Text) == true)
                                {
                                    txt82__.Text = l.Rows[b + 35]["Anterior"].ToString();
                                }
                              
                            }
                            
                            k--;
                            if (k > 0)
                            {
                                if (Convert.ToInt32(l.Rows[b + 36]["Atual"].ToString()) < Convert.ToInt32(l.Rows[b + 36]["Anterior"].ToString()))
                                {
                                    txt83__.Text = l.Rows[b + 36]["Anterior"].ToString();
                                }
                                if (Convert.ToInt32(l.Rows[b + 36]["Atual"].ToString()) > Convert.ToInt32(l.Rows[b + 36]["Anterior"].ToString()))
                                {
                                    txt83__.Text = l.Rows[b + 36]["Atual"].ToString();
                                }
                                if (String.IsNullOrEmpty(txt83__.Text) == true)
                                {
                                    txt83__.Text = l.Rows[b + 36]["Anterior"].ToString();
                                }
                                
                            }
                           
                        }

                        crystalReportViewer1.ReportSource = rpt2;
                        crystalReportViewer1.Refresh();

                        // crystalReportViewer1.PrintReport();
                        rpt2.PrintToPrinter(1, false, 0, 0);
                        rpt2.PrintToPrinter(1, false, 0, 0);
                        Form print2 = new Print("Imp. a Leitura do próximo Mês");
                        print2.ShowDialog();

                        //limpar campos
                        txt17__.Text = "";
                        txt8__.Text = "";
                        txt7__.Text = "";
                        txt14__.Text = "";
                        txt42__.Text = "";
                        txt27__.Text = "";
                        txt44__.Text = "";
                        txt10__.Text = "";
                        txt11__.Text = "";
                        txt12__.Text = "";
                        txt13__.Text = "";
                        txt15__.Text = "";
                        txt18__.Text = "";
                        txt19__.Text = "";
                        txt28__.Text = "";
                        txt29__.Text = "";
                        txt30__.Text = "";
                        txt31__.Text = "";
                        txt32__.Text = "";
                        txt33__.Text = "";
                        txt34__.Text = "";
                        txt35__.Text = "";
                        txt36__.Text = "";
                        txt37__.Text = "";
                        txt38__.Text = "";
                        txt39__.Text = "";
                        txt40__.Text = "";
                        txt41__.Text = "";
                        txt45__.Text = "";
                        txt46__.Text = "";
                        txt47__.Text = "";
                        txt48__.Text = "";
                        txt51__.Text = "";
                        txt52__.Text = "";
                        txt20__.Text = "";
                        txt21__.Text = "";
                        txt22__.Text = "";


                        txt24__.Text = "";
                        txt25__.Text = "";
                        txt26__.Text = "";
                        txt43__.Text = "";
                        txt49__.Text = "";
                        txt50__.Text = "";
                        txt53__.Text = "";
                        txt54__.Text = "";
                        txt55__.Text = "";
                        txt56__.Text = "";
                        txt57__.Text = "";
                        txt58__.Text = "";
                        txt59__.Text = "";
                        txt60__.Text = "";
                        txt61__.Text = "";
                        txt62__.Text = "";
                        txt63__.Text = "";
                        txt64__.Text = "";
                        txt65__.Text = "";
                        txt66__.Text = "";
                        txt67__.Text = "";
                        txt68__.Text = "";
                        txt69__.Text = "";
                        txt70__.Text = "";
                        txt71__.Text = "";
                        txt72__.Text = "";
                        txt73__.Text = "";
                        txt74__.Text = "";
                        txt75__.Text = "";
                        txt76__.Text = "";
                        txt77__.Text = "";
                        txt78__.Text = "";
                        txt79__.Text = "";
                        txt80__.Text = "";
                        txt81__.Text = "";
                        txt82__.Text = "";
                        txt83__.Text = "";
                            

                        b = b + 37;
                        qtde2 = qtde2 - 37;

                        if (qtde2 <= 0)
                        {
                            imprime2 = false;
                        }
                    }


                   

                   

                    //finalizando
                    pictureBox27.Visible = false;
                    Cursor = Cursors.Default;
                    crystalReportViewer1.ReportSource = rpt;
                    return;

                }                
                contImp++;
               

                if (contImp > 3)
                {
                    //imprime
                    tabControl1.SelectedTab = tabPage3;
                    panel8.VerticalScroll.Value = 0;
                    /*Print(this.panel9);

                    if (checkBox4.Checked == false)
                    {
                        Form print = new Print();
                        print.ShowDialog();
                    }*/

                    //código para imprimir aqui
                    //*************************

                    crystalReportViewer1.ReportSource = rpt;

                    // crystalReportViewer1.PrintReport();
                    
                    rpt.PrintToPrinter(1,false,0,0);
                    pag++;
                    Form print = new Print("Imprimindo Recibos Pág. " + Convert.ToString(pag));
                    print.ShowDialog();
                    //*************************
                    //Preparar campos do relatório
                    //TextObject txt120 = (TextObject)rpt.ReportDefinition.ReportObjects["Text120"]; //Instancie um objeto do tipo TextObject e informe o nome do textbox
                    //txt120.Text = "";
                    TextObject txt256 = (TextObject)rpt.ReportDefinition.ReportObjects["Text256"]; //Instancie um objeto do tipo TextObject e informe o nome do textbox
                    txt256.Text = "";
                    TextObject txt110 = (TextObject)rpt.ReportDefinition.ReportObjects["Text110"]; //Instancie um objeto do tipo TextObject e informe o nome do textbox
                    txt110.Text = "0";
                    TextObject txt111 = (TextObject)rpt.ReportDefinition.ReportObjects["Text111"]; //Instancie um objeto do tipo TextObject e informe o nome do textbox
                    txt111.Text = "0";
                    TextObject txt112 = (TextObject)rpt.ReportDefinition.ReportObjects["Text112"]; //Instancie um objeto do tipo TextObject e informe o nome do textbox
                    txt112.Text = "0";
                    TextObject txt113 = (TextObject)rpt.ReportDefinition.ReportObjects["Text113"]; //Instancie um objeto do tipo TextObject e informe o nome do textbox
                    txt113.Text = "0";
                    TextObject txt114 = (TextObject)rpt.ReportDefinition.ReportObjects["Text114"]; //Instancie um objeto do tipo TextObject e informe o nome do textbox
                    txt114.Text = "0";
                    TextObject txt115 = (TextObject)rpt.ReportDefinition.ReportObjects["Text115"]; //Instancie um objeto do tipo TextObject e informe o nome do textbox
                    txt115.Text = "0";
                    TextObject txt116 = (TextObject)rpt.ReportDefinition.ReportObjects["Text116"]; //Instancie um objeto do tipo TextObject e informe o nome do textbox
                    txt116.Text = "0";
                    TextObject txt121 = (TextObject)rpt.ReportDefinition.ReportObjects["Text121"]; //Instancie um objeto do tipo TextObject e informe o nome do textbox
                    txt121.Text = "";
                    //TextObject txt122 = (TextObject)rpt.ReportDefinition.ReportObjects["Text122"]; //Instancie um objeto do tipo TextObject e informe o nome do textbox
                    //txt122.Text = "";
                    TextObject txt123 = (TextObject)rpt.ReportDefinition.ReportObjects["Text123"]; //Instancie um objeto do tipo TextObject e informe o nome do textbox
                    txt123.Text = "";
                    TextObject txt117 = (TextObject)rpt.ReportDefinition.ReportObjects["Text117"]; //Instancie um objeto do tipo TextObject e informe o nome do textbox
                    txt117.Text = "0";
                    TextObject txt118 = (TextObject)rpt.ReportDefinition.ReportObjects["Text118"]; //Instancie um objeto do tipo TextObject e informe o nome do textbox
                    txt118.Text = "0";
                    //TextObject txt119 = (TextObject)rpt.ReportDefinition.ReportObjects["Text119"]; //Instancie um objeto do tipo TextObject e informe o nome do textbox
                    txt119.Text = "0";

                    //TextObject txt186 = (TextObject)rpt.ReportDefinition.ReportObjects["Text186"]; //Instancie um objeto do tipo TextObject e informe o nome do textbox
                    //txt186.Text = "";
                    TextObject txt257 = (TextObject)rpt.ReportDefinition.ReportObjects["Text257"]; //Instancie um objeto do tipo TextObject e informe o nome do textbox
                    txt257.Text = "";
                    TextObject txt176 = (TextObject)rpt.ReportDefinition.ReportObjects["Text176"]; //Instancie um objeto do tipo TextObject e informe o nome do textbox
                    txt176.Text = "0";
                    TextObject txt177 = (TextObject)rpt.ReportDefinition.ReportObjects["Text177"]; //Instancie um objeto do tipo TextObject e informe o nome do textbox
                    txt177.Text = "0";
                    TextObject txt178 = (TextObject)rpt.ReportDefinition.ReportObjects["Text178"]; //Instancie um objeto do tipo TextObject e informe o nome do textbox
                    txt178.Text = "0";
                    TextObject txt179 = (TextObject)rpt.ReportDefinition.ReportObjects["Text179"]; //Instancie um objeto do tipo TextObject e informe o nome do textbox
                    txt179.Text = "0";
                    TextObject txt180 = (TextObject)rpt.ReportDefinition.ReportObjects["Text180"]; //Instancie um objeto do tipo TextObject e informe o nome do textbox
                    txt180.Text = "0";
                    TextObject txt181 = (TextObject)rpt.ReportDefinition.ReportObjects["Text181"]; //Instancie um objeto do tipo TextObject e informe o nome do textbox
                    txt181.Text = "0";
                    TextObject txt182 = (TextObject)rpt.ReportDefinition.ReportObjects["Text182"]; //Instancie um objeto do tipo TextObject e informe o nome do textbox
                    txt182.Text = "0";
                    TextObject txt187 = (TextObject)rpt.ReportDefinition.ReportObjects["Text187"]; //Instancie um objeto do tipo TextObject e informe o nome do textbox
                    txt187.Text = "";
                    //TextObject txt188 = (TextObject)rpt.ReportDefinition.ReportObjects["Text188"]; //Instancie um objeto do tipo TextObject e informe o nome do textbox
                    //txt188.Text = "";
                    TextObject txt189 = (TextObject)rpt.ReportDefinition.ReportObjects["Text189"]; //Instancie um objeto do tipo TextObject e informe o nome do textbox
                    txt189.Text = "";
                    TextObject txt183 = (TextObject)rpt.ReportDefinition.ReportObjects["Text183"]; //Instancie um objeto do tipo TextObject e informe o nome do textbox
                    txt183.Text = "0";
                    TextObject txt184 = (TextObject)rpt.ReportDefinition.ReportObjects["Text184"]; //Instancie um objeto do tipo TextObject e informe o nome do textbox
                    txt184.Text = "0";
                    //TextObject txt185 = (TextObject)rpt.ReportDefinition.ReportObjects["Text185"]; //Instancie um objeto do tipo TextObject e informe o nome do textbox
                    txt185.Text = "0";


                    //TextObject txt219 = (TextObject)rpt.ReportDefinition.ReportObjects["Text219"]; //Instancie um objeto do tipo TextObject e informe o nome do textbox
                    //txt219.Text = "";
                    TextObject txt258 = (TextObject)rpt.ReportDefinition.ReportObjects["Text258"]; //Instancie um objeto do tipo TextObject e informe o nome do textbox
                    txt258.Text = "";
                    TextObject txt209 = (TextObject)rpt.ReportDefinition.ReportObjects["Text209"]; //Instancie um objeto do tipo TextObject e informe o nome do textbox
                    txt209.Text = "0";
                    TextObject txt210 = (TextObject)rpt.ReportDefinition.ReportObjects["Text210"]; //Instancie um objeto do tipo TextObject e informe o nome do textbox
                    txt210.Text = "0";
                    TextObject txt211 = (TextObject)rpt.ReportDefinition.ReportObjects["Text211"]; //Instancie um objeto do tipo TextObject e informe o nome do textbox
                    txt211.Text = "0";
                    TextObject txt212 = (TextObject)rpt.ReportDefinition.ReportObjects["Text212"]; //Instancie um objeto do tipo TextObject e informe o nome do textbox
                    txt212.Text = "0";
                    TextObject txt213 = (TextObject)rpt.ReportDefinition.ReportObjects["Text213"]; //Instancie um objeto do tipo TextObject e informe o nome do textbox
                    txt213.Text = "0";
                    TextObject txt214 = (TextObject)rpt.ReportDefinition.ReportObjects["Text214"]; //Instancie um objeto do tipo TextObject e informe o nome do textbox
                    txt214.Text = "0";
                    TextObject txt215 = (TextObject)rpt.ReportDefinition.ReportObjects["Text215"]; //Instancie um objeto do tipo TextObject e informe o nome do textbox
                    txt215.Text = "0";
                    TextObject txt220 = (TextObject)rpt.ReportDefinition.ReportObjects["Text220"]; //Instancie um objeto do tipo TextObject e informe o nome do textbox
                    txt220.Text = "";
                    //TextObject txt221 = (TextObject)rpt.ReportDefinition.ReportObjects["Text221"]; //Instancie um objeto do tipo TextObject e informe o nome do textbox
                    //txt221.Text = "";
                    TextObject txt222 = (TextObject)rpt.ReportDefinition.ReportObjects["Text222"]; //Instancie um objeto do tipo TextObject e informe o nome do textbox
                    txt222.Text = "";
                    TextObject txt216 = (TextObject)rpt.ReportDefinition.ReportObjects["Text216"]; //Instancie um objeto do tipo TextObject e informe o nome do textbox
                    txt216.Text = "0";
                    TextObject txt217 = (TextObject)rpt.ReportDefinition.ReportObjects["Text217"]; //Instancie um objeto do tipo TextObject e informe o nome do textbox
                    txt217.Text = "0";
                    //TextObject txt218 = (TextObject)rpt.ReportDefinition.ReportObjects["Text218"]; //Instancie um objeto do tipo TextObject e informe o nome do textbox
                    txt218.Text = "0";


                    //TextObject txt252 = (TextObject)rpt.ReportDefinition.ReportObjects["Text252"]; //Instancie um objeto do tipo TextObject e informe o nome do textbox
                    //txt252.Text = "";
                    TextObject txt259 = (TextObject)rpt.ReportDefinition.ReportObjects["Text259"]; //Instancie um objeto do tipo TextObject e informe o nome do textbox
                    txt259.Text = "";
                    TextObject txt242 = (TextObject)rpt.ReportDefinition.ReportObjects["Text242"]; //Instancie um objeto do tipo TextObject e informe o nome do textbox
                    txt242.Text = "0";
                    TextObject txt243 = (TextObject)rpt.ReportDefinition.ReportObjects["Text243"]; //Instancie um objeto do tipo TextObject e informe o nome do textbox
                    txt243.Text = "0";
                    TextObject txt244 = (TextObject)rpt.ReportDefinition.ReportObjects["Text244"]; //Instancie um objeto do tipo TextObject e informe o nome do textbox
                    txt244.Text = "0";
                    TextObject txt245 = (TextObject)rpt.ReportDefinition.ReportObjects["Text245"]; //Instancie um objeto do tipo TextObject e informe o nome do textbox
                    txt245.Text = "0";
                    TextObject txt246 = (TextObject)rpt.ReportDefinition.ReportObjects["Text246"]; //Instancie um objeto do tipo TextObject e informe o nome do textbox
                    txt246.Text = "0";
                    TextObject txt247 = (TextObject)rpt.ReportDefinition.ReportObjects["Text247"]; //Instancie um objeto do tipo TextObject e informe o nome do textbox
                    txt247.Text = "0";
                    TextObject txt248 = (TextObject)rpt.ReportDefinition.ReportObjects["Text248"]; //Instancie um objeto do tipo TextObject e informe o nome do textbox
                    txt248.Text = "0";
                    TextObject txt253 = (TextObject)rpt.ReportDefinition.ReportObjects["Text253"]; //Instancie um objeto do tipo TextObject e informe o nome do textbox
                    txt253.Text = "";
                    //TextObject txt254 = (TextObject)rpt.ReportDefinition.ReportObjects["Text254"]; //Instancie um objeto do tipo TextObject e informe o nome do textbox
                    //txt254.Text = "";
                    TextObject txt255 = (TextObject)rpt.ReportDefinition.ReportObjects["Text255"]; //Instancie um objeto do tipo TextObject e informe o nome do textbox
                    txt255.Text = "";
                    TextObject txt249 = (TextObject)rpt.ReportDefinition.ReportObjects["Text249"]; //Instancie um objeto do tipo TextObject e informe o nome do textbox
                    txt249.Text = "0";
                    TextObject txt250 = (TextObject)rpt.ReportDefinition.ReportObjects["Text250"]; //Instancie um objeto do tipo TextObject e informe o nome do textbox
                    txt250.Text = "0";
                    //TextObject txt251 = (TextObject)rpt.ReportDefinition.ReportObjects["Text251"]; //Instancie um objeto do tipo TextObject e informe o nome do textbox
                    txt251.Text = "0";



                    //********************************************************************************
                    //********************************************************************************


                    contImp = 0;                       
                       
                }

               
            }
            
        }

        private void pictureBox26_MouseEnter(object sender, EventArgs e)
        {
            if (pictureBox26.BorderStyle == BorderStyle.None)
            {
                label109.ForeColor = Color.Red;

            }
            
        }

        private void pictureBox26_MouseLeave(object sender, EventArgs e)
        {
            if (pictureBox26.BorderStyle == BorderStyle.None)
            {
                label109.ForeColor = Color.Black;
            }
           
        }

        private void pictureBox26_Click(object sender, EventArgs e)
        {
            pictureBox26.BorderStyle = BorderStyle.Fixed3D;
            label109.ForeColor = Color.Red;
            Form rat = new Rateio();
            rat.ShowDialog();
            pictureBox26.BorderStyle = BorderStyle.None;
            label109.ForeColor = Color.Black;
            
        }

        private void pictureBox27_Click(object sender, EventArgs e)
        {
            
        }

        private void button25_Click(object sender, EventArgs e)
        {
            pictureBox3.BorderStyle = BorderStyle.None;
            //tabControl1.SelectedTab = tabPage1;
            label3.ForeColor = Color.Black;
            tabControl1.TabPages.Remove(tabPage3);
        }

        private void button27_Click(object sender, EventArgs e)
        {
            pictureBox4.BorderStyle = BorderStyle.None;
            //tabControl1.SelectedTab = tabPage1;
            label4.ForeColor = Color.Black;
            tabControl1.TabPages.Remove(tabPage4);
        }

        private void checkBox3_CheckedChanged(object sender, EventArgs e)
        {
            
        }

        private void button28_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(label30.Text) == false)
            {
                MessageBox.Show("Pagamento já efetuado. Tente alterar diretamente o saldo devedor (atraso)");
                button28.Visible = false;
                button1.Visible = true;
                button2.Visible = true;
                button27.Visible = false;
                textBox4.Text = "0";
                return;
            }
            if (textBox4.ReadOnly == false)
            {
                if (String.IsNullOrEmpty( textBox4.Text) == false)
                {
                    Double qtde2;
                    if (Double.TryParse(textBox4.Text.Trim(), out qtde2) == false)
                    {
                        MessageBox.Show("O campo só aceita valores numéricos");
                        textBox4.Text = "";
                        textBox4.Focus();
                        return;
                    }
                   
                    if (Double.TryParse(textBox4.Text.Trim(), out qtde2) == true)
                    {
                        if (String.IsNullOrEmpty(label19.Text) == true)
                        {
                            MessageBox.Show("Selecionar um cadastro");
                            button28.Visible = false;
                            button1.Visible = true;
                            button2.Visible = true;
                            button27.Visible = false;
                            return;
                        }
                        string valor = textBox4.Text;
                        Double re = Convert.ToDouble(valor);
                        

                        Global.Config.Valor_Pago = re.ToString("N2");
                        Global.Config.Pag_Id = label19.Text;
                        Global.Config.Consumo = Convert.ToString( Convert.ToInt32(textBox3.Text) - Convert.ToInt32(textBox2.Text));
                        Global.Config.Nome = textBox1.Text;
                        if (String.IsNullOrEmpty(textBox5.Text) == true)
                        {
                            textBox5.Text = "0";
                        }
                        Double qtde3;
                        if (Double.TryParse(textBox5.Text.Trim(), out qtde3) == false)
                        {
                            MessageBox.Show("O campo só aceita valores numéricos");
                            textBox5.Text = "";
                            textBox5.Focus();
                            button28.Visible = false;
                            button1.Visible = true;
                            button2.Visible = true;
                            button27.Visible = false;
                            return;
                        }
                        Global.Config.Atraso = textBox5.Text;
                        Global.Config.TX = comboBox1.Text;
                        Form dt = new Data();
                        dt.ShowDialog();
                        nomes = DAL.Lista_Nome();
                        for (int i = 0; i < nomes.Rows.Count; i++)
                        {
                            if (nomes.Rows[i]["Nome"].ToString() == textBox1.Text)
                            {
                                label19.Text = nomes.Rows[i]["Id"].ToString();
                                textBox1.Text = nomes.Rows[i]["Nome"].ToString();
                                textBox2.Text = nomes.Rows[i]["Anterior"].ToString();
                                textBox3.Text = nomes.Rows[i]["Atual"].ToString();
                                textBox5.Text = nomes.Rows[i]["Atraso"].ToString();
                                richTextBox1.Text = nomes.Rows[i]["Observação"].ToString();
                                comboBox1.Text = nomes.Rows[i]["TX_Comercial"].ToString();
                                DataTable pag = DAL.Pagou_Id_Lista(Convert.ToInt32(label19.Text));
                                if (pag.Rows.Count > 0)
                                {
                                    label30.Text = "Pagamento Efetuado para Mês Atual";
                                }
                            }
                        }
                        button28.Visible = false;
                        button1.Visible = true;
                        button2.Visible = true;
                        button27.Visible = false;
                        textBox4.Text = "0";

                    }
                    
                }
                if (String.IsNullOrEmpty(textBox4.Text) == true)
                {
                    MessageBox.Show("Insira um valor");
                    button28.Visible = false;
                    button1.Visible = true;
                    button2.Visible = true;
                    button27.Visible = false;
                    textBox4.Focus();
                }   
            }
            else
            {
                MessageBox.Show("Insira o valor do pagamento antes");
                button28.Visible = false;
                button1.Visible = true;
                button2.Visible = true;
                button27.Visible = false;
                textBox4.Focus();
            }
        }

        private void checkBox3_CheckedChanged_1(object sender, EventArgs e)
        {
            if (checkBox3.Checked == true)
            {
                MessageBox.Show("O Pagamento é a última etapa antes do fechamento do mês\nSó forneça o valor depois de gerar os todos os dados\nnecessários para imprimir os recibos.");
                textBox4.ReadOnly = false;
                textBox4.Focus();
            }
            if (checkBox3.Checked == false)
            {
                textBox4.ReadOnly = true;            
            }
        }

        private void button26_Click(object sender, EventArgs e)
        {
            Global.Config.Impressao = "relatorio";
            printDGV.Print_DataGridView(dataGridView2);
        }

        private static int CentimetrosParaCentesimasPolegada(double cm)
        {
            return (int)Math.Round(cm / 0.393701 * 100, MidpointRounding.AwayFromZero);
        }

        private void button29_Click(object sender, EventArgs e)
        {
            Global.Config.Impressao = "leitura";
            printDGV.Print_DataGridView(dataGridView3);          
            

        }

        private void checkBox6_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox6.Checked == true)
            {
                Global.Config.Relat = "sim";

            }
            if (checkBox6.Checked == false)
            {
                Global.Config.Relat = "não";

            }
        }

        private void checkBox5_CheckedChanged(object sender, EventArgs e)
        {
            //if (checkBox5.Checked == false)
            //{
              //  checkBox5.Checked = true;
            //}
        }

        private void button30_Click(object sender, EventArgs e)
        {
            pictureBox9.BorderStyle = BorderStyle.None;
            //tabControl1.SelectedTab = tabPage1;
            label7.ForeColor = Color.Black;
            tabControl1.TabPages.Remove(tabPage7);
        }

        private void dataGridView4_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            nomes = DAL.Lista_Nome();
            for (int i = 0; i < nomes.Rows.Count; i++)
            {
                if (nomes.Rows[i]["Id"].ToString() == dataGridView4.Rows[dataGridView4.SelectedCells[0].RowIndex].Cells[2].FormattedValue.ToString())
                {
                    label19.Text = nomes.Rows[i]["Id"].ToString();
                    textBox1.Text = nomes.Rows[i]["Nome"].ToString();
                    textBox2.Text = nomes.Rows[i]["Anterior"].ToString();
                    textBox3.Text = nomes.Rows[i]["Atual"].ToString();
                    textBox5.Text = nomes.Rows[i]["Atraso"].ToString();
                    richTextBox1.Text = nomes.Rows[i]["Observação"].ToString();
                    comboBox1.Text = nomes.Rows[i]["TX_Comercial"].ToString();
                    DataTable pag = DAL.Pagou_Id_Lista(Convert.ToInt32(label19.Text));
                    if (pag.Rows.Count > 0)
                    {
                        label30.Text = "Pagamento Efetuado para Mês Atual";
                    }
                    if (pag.Rows.Count <= 0)
                    {
                        label30.Text = "";
                    }
                    Global.Config.Cad_ID = "";
                    textBox3.Focus();
                    if (!String.IsNullOrEmpty(textBox3.Text))
                    {
                        textBox3.SelectionStart = 0;
                        textBox3.SelectionLength = textBox3.Text.Length;
                    }
                    return;
                }
            }
        }

        private void button27_Click_1(object sender, EventArgs e)
        {
            button28.Visible = false;
            button1.Visible = true;
            button2.Visible = true;
            button27.Visible = false;
        }

        private void button31_Click(object sender, EventArgs e)
        {
            pictureBox4.BorderStyle = BorderStyle.None;
            //tabControl1.SelectedTab = tabPage1;
            label4.ForeColor = Color.Black;
            tabControl1.TabPages.Remove(tabPage4);
        }

        private void textBox3_KeyPress(object sender, KeyPressEventArgs e)
        {
            
            if (e.KeyChar == 13)
            {
                if (String.IsNullOrEmpty(textBox1.Text) == false || String.IsNullOrEmpty(label19.Text) == false)
                {
                    if (String.IsNullOrEmpty(label19.Text) == true)
                    {
                        MessageBox.Show("Nenhum cadastro selecionado para edição");
                        return;
                    }
                    if (String.IsNullOrEmpty(textBox4.Text) == false)
                    {


                        Double qtde2;
                        if (Double.TryParse(textBox4.Text.Trim(), out qtde2) == false)
                        {

                        }
                        if (Double.TryParse(textBox4.Text.Trim(), out qtde2) == true)
                        {
                            //tratar do fechamento do mês
                        }

                    }
                    if (String.IsNullOrEmpty(textBox5.Text) == false)
                    {


                        Double qtde2;
                        if (Double.TryParse(textBox5.Text.Trim(), out qtde2) == false)
                        {
                            MessageBox.Show("O campo só aceita valores numéricos");
                            textBox5.Text = "";
                            textBox5.Focus();
                            return;
                        }

                    }
                    if (Convert.ToInt32(textBox3.Text) < Convert.ToInt32(textBox2.Text))
                    {
                        MessageBox.Show("Consumo atual fornecido é menor do que o consumo anterior.");
                        textBox3.Text = "0";
                        textBox3.Focus();
                        return;
                    }
                    timer2.Enabled = true;
                    DAL.Altera_Nome(Convert.ToInt32(label19.Text), textBox1.Text, textBox2.Text, textBox3.Text, textBox5.Text, richTextBox1.Text, comboBox1.Text);
                    nomes = DAL.Lista_Nome();
                    for (int i = 0; i < nomes.Rows.Count; i++)
                    {
                        if (nomes.Rows[i]["Nome"].ToString() == textBox1.Text)
                        {
                            label19.Text = nomes.Rows[i]["Id"].ToString();
                            textBox1.Text = nomes.Rows[i]["Nome"].ToString();
                            textBox2.Text = nomes.Rows[i]["Anterior"].ToString();
                            textBox3.Text = nomes.Rows[i]["Atual"].ToString();
                            textBox5.Text = nomes.Rows[i]["Atraso"].ToString();
                            richTextBox1.Text = nomes.Rows[i]["Observação"].ToString();
                            comboBox1.Text = nomes.Rows[i]["TX_Comercial"].ToString();
                            DataTable pag = DAL.Pagou_Id_Lista(Convert.ToInt32(label19.Text));
                            if (pag.Rows.Count > 0)
                            {
                                label30.Text = "Pagamento Efetuado para Mês Atual";
                            }
                            if (pag.Rows.Count <= 0)
                            {
                                label30.Text = "";
                            }
                        }
                    }
                    dataGridView4.CurrentRow.Cells[0].Style.BackColor = Color.LightCyan;
                    dataGridView4.CurrentRow.Cells[1].Style.BackColor = Color.LightCyan;
                    dataGridView4.CurrentRow.Cells[2].Style.BackColor = Color.LightCyan;
                    
                }
                else
                {
                    MessageBox.Show("Nenhum cadastro selecionado para edição");
                }





                int linha = 0;
                if (String.IsNullOrEmpty(label19.Text) == true)
                {
                    timer1.Enabled = true;
                    Cursor = Cursors.WaitCursor;
                    //progressBar1.Width = progressBar1.Width + 6;
                    nomes = DAL.Lista_Nome();
                    if (nomes.Rows.Count > 0)
                    {
                        label19.Text = nomes.Rows[0]["Id"].ToString();
                        textBox1.Text = nomes.Rows[0]["Nome"].ToString();
                        textBox2.Text = nomes.Rows[0]["Anterior"].ToString();
                        textBox3.Text = nomes.Rows[0]["Atual"].ToString();
                        textBox5.Text = nomes.Rows[0]["Atraso"].ToString();
                        richTextBox1.Text = nomes.Rows[0]["Observação"].ToString();
                        comboBox1.Text = nomes.Rows[0]["TX_Comercial"].ToString();

                        DataTable pag = DAL.Pagou_Id_Lista(Convert.ToInt32(label19.Text));
                        if (pag.Rows.Count > 0)
                        {
                            label30.Text = "Pagamento Efetuado para Mês Atual";
                        }
                        if (pag.Rows.Count <= 0)
                        {
                            label30.Text = "";
                        }

                    }
                    textBox3.Focus();
                    if (!String.IsNullOrEmpty(textBox3.Text))
                    {
                        textBox3.SelectionStart = 0;
                        textBox3.SelectionLength = textBox3.Text.Length;
                    }

                }
                else
                {

                    nomes = DAL.Lista_Nome();

                    for (int i = 0; i < nomes.Rows.Count; i++)
                    {
                        if (nomes.Rows[i]["Id"].ToString() == label19.Text)
                        {
                            if (i + 1 == nomes.Rows.Count)
                            {
                                MessageBox.Show("Último cadastro");
                                return;
                            }

                            //progressBar1.Width = progressBar1.Width + 6;
                            label19.Text = nomes.Rows[i + 1]["Id"].ToString();
                            textBox1.Text = nomes.Rows[i + 1]["Nome"].ToString();
                            textBox2.Text = nomes.Rows[i + 1]["Anterior"].ToString();
                            textBox3.Text = nomes.Rows[i + 1]["Atual"].ToString();
                            textBox5.Text = nomes.Rows[i + 1]["Atraso"].ToString();
                            richTextBox1.Text = nomes.Rows[i + 1]["Observação"].ToString();
                            comboBox1.Text = nomes.Rows[i + 1]["TX_Comercial"].ToString();
                            DataTable pag = DAL.Pagou_Id_Lista(Convert.ToInt32(label19.Text));
                            if (pag.Rows.Count > 0)
                            {
                                label30.Text = "Pagamento Efetuado para Mês Atual";
                            }
                            if (pag.Rows.Count <= 0)
                            {
                                label30.Text = "";
                            }

                            linha = dataGridView4.CurrentRow.Index;

                            linha++;

                            dataGridView4.CurrentCell = dataGridView4.Rows[linha].Cells[0];
                            textBox3.Focus();
                            if (!String.IsNullOrEmpty(textBox3.Text))
                            {
                                textBox3.SelectionStart = 0;
                                textBox3.SelectionLength = textBox3.Text.Length;
                            }
                            timer1.Enabled = true;
                            Cursor = Cursors.WaitCursor;
                            return;
                        }

                    }
                }
            }
        }

        private void dataGridView4_Scroll(object sender, ScrollEventArgs e)
        {

        }

        private void pictureBox32_MouseEnter(object sender, EventArgs e)
        {
            label23.ForeColor = Color.Red;
        }

        private void pictureBox32_MouseLeave(object sender, EventArgs e)
        {
            label23.ForeColor = Color.Black;
        }

        private void pictureBox32_Click(object sender, EventArgs e)
        {
            Form a = new Ajuda();
            a.ShowDialog();
        }

        private void dataGridView4_MouseEnter(object sender, EventArgs e)
        {
            dataGridView4.Focus();
        }

        private void dataGridView4_MouseLeave(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(textBox1.Text) == false)
            {
                textBox3.Focus();
                if (!String.IsNullOrEmpty(textBox3.Text))
                {
                    textBox3.SelectionStart = 0;
                    textBox3.SelectionLength = textBox3.Text.Length;
                }    
            }
            
        }

        private void pictureBox34_MouseEnter(object sender, EventArgs e)
        {
            Cursor = Cursors.Hand;
        }

        private void pictureBox34_MouseLeave(object sender, EventArgs e)
        {
            Cursor = Cursors.Default;
        }

        private void button32_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(comboInstalledPrinters.Text) == true)
            {
                MessageBox.Show("Selecione uma Impressora");
                return;
            }
            informarNomes = "";
            pag = 0;
            Form entra = new EntrarMes();
            entra.ShowDialog();
            if (Global.Config.Cancela == "sim")
            {
                Global.Config.Cancela = "";
                return;
            }

            TextObject txt120 = (TextObject)rpt.ReportDefinition.ReportObjects["Text120"]; //Instancie um objeto do tipo TextObject e informe o nome do textbox
            txt120.Text = Global.Config.Texto;

            TextObject txt186 = (TextObject)rpt.ReportDefinition.ReportObjects["Text186"]; //Instancie um objeto do tipo TextObject e informe o nome do textbox
            txt186.Text = Global.Config.Texto;

            TextObject txt219 = (TextObject)rpt.ReportDefinition.ReportObjects["Text219"]; //Instancie um objeto do tipo TextObject e informe o nome do textbox
            txt219.Text = Global.Config.Texto;

            TextObject txt252 = (TextObject)rpt.ReportDefinition.ReportObjects["Text252"]; //Instancie um objeto do tipo TextObject e informe o nome do textbox
            txt252.Text = Global.Config.Texto;


            TextObject txt122 = (TextObject)rpt.ReportDefinition.ReportObjects["Text122"]; //Instancie um objeto do tipo TextObject e informe o nome do textbox
            txt122.Text = Global.Config.Aviso;

            TextObject txt188 = (TextObject)rpt.ReportDefinition.ReportObjects["Text188"]; //Instancie um objeto do tipo TextObject e informe o nome do textbox
            txt188.Text = Global.Config.Aviso;

            TextObject txt221 = (TextObject)rpt.ReportDefinition.ReportObjects["Text221"]; //Instancie um objeto do tipo TextObject e informe o nome do textbox
            txt221.Text = Global.Config.Aviso;

            TextObject txt254 = (TextObject)rpt.ReportDefinition.ReportObjects["Text254"]; //Instancie um objeto do tipo TextObject e informe o nome do textbox
            txt254.Text = Global.Config.Aviso;



            int termina = 0;
            DAL.Deleta_Relatorio();
            //variaveis relatório
            string Nome_Re = "";
            string Anterior_Re = "";
            string Atual_Re = "";
            string Consumo_Re = "0";
            string Valor_Re = "";
            string Rateio_Re = "";
            string TX_Re = "";
            string Total_Re = "";
            string TotalMulta_Re = "";
            string Atraso_Re = "";
            //string Pagamento_Re = "";
            //string Observação = "";
            string Mes_Re = "";
            DataTable at = DAL.Lista_Mes_Atual();
            if (at.Rows.Count > 0)
            {
                Mes_Re = at.Rows[0]["Atual"].ToString();
            }
            ///////////////////Impressão dos boletos///////////////////////
            //animação ampulheta
            //pictureBox27.Visible = true;

            //pega config
            DataTable config = DAL.Lista_Config();

            //vencimento

            DataTable venc = DAL.Lista_Vencimento();
            if (venc.Rows.Count > 0)
            {
                TextObject txt114 = (TextObject)rpt.ReportDefinition.ReportObjects["Text114"]; //Instancie um objeto do tipo TextObject e informe o nome do textbox
                txt114.Text = venc.Rows[0]["Vencimento"].ToString();

                TextObject txt180 = (TextObject)rpt.ReportDefinition.ReportObjects["Text180"]; //Instancie um objeto do tipo TextObject e informe o nome do textbox
                txt180.Text = venc.Rows[0]["Vencimento"].ToString();

                TextObject txt213 = (TextObject)rpt.ReportDefinition.ReportObjects["Text213"]; //Instancie um objeto do tipo TextObject e informe o nome do textbox
                txt213.Text = venc.Rows[0]["Vencimento"].ToString();

                TextObject txt246 = (TextObject)rpt.ReportDefinition.ReportObjects["Text246"]; //Instancie um objeto do tipo TextObject e informe o nome do textbox
                txt246.Text = venc.Rows[0]["Vencimento"].ToString();


            }
            else
            {
                MessageBox.Show("Defina o dia do vencimento");
                return;
            }
            nomes = DAL.Lista_Nome();

            //verifica de atual foi lançado
            if (nomes.Rows.Count > 0)
            {
                for (int i = 0; i < nomes.Rows.Count; i++)
                {
                    if (nomes.Rows[i]["Atual"].ToString() == "0")
                    {
                        string message = "Consumo atual de:\n" + nomes.Rows[i]["Nome"].ToString() + " , não informado.\nDeseja continuar mesmo assim?";
                        string caption = "Consumo Atual";
                        MessageBoxButtons buttons = MessageBoxButtons.YesNo;
                        DialogResult result;

                        // Displays the MessageBox.

                        result = MessageBox.Show(this, message, caption, buttons,
                        MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);


                        if (result == DialogResult.No)
                        {
                            //Preparar campos do relatório
                            //TextObject txt120 = (TextObject)rpt.ReportDefinition.ReportObjects["Text120"]; //Instancie um objeto do tipo TextObject e informe o nome do textbox
                            txt120.Text = "";
                            TextObject txt256 = (TextObject)rpt.ReportDefinition.ReportObjects["Text256"]; //Instancie um objeto do tipo TextObject e informe o nome do textbox
                            txt256.Text = "";
                            TextObject txt110 = (TextObject)rpt.ReportDefinition.ReportObjects["Text110"]; //Instancie um objeto do tipo TextObject e informe o nome do textbox
                            txt110.Text = "0";
                            TextObject txt111 = (TextObject)rpt.ReportDefinition.ReportObjects["Text111"]; //Instancie um objeto do tipo TextObject e informe o nome do textbox
                            txt111.Text = "0";
                            TextObject txt112 = (TextObject)rpt.ReportDefinition.ReportObjects["Text112"]; //Instancie um objeto do tipo TextObject e informe o nome do textbox
                            txt112.Text = "0";
                            TextObject txt113 = (TextObject)rpt.ReportDefinition.ReportObjects["Text113"]; //Instancie um objeto do tipo TextObject e informe o nome do textbox
                            txt113.Text = "0";
                            TextObject txt114 = (TextObject)rpt.ReportDefinition.ReportObjects["Text114"]; //Instancie um objeto do tipo TextObject e informe o nome do textbox
                            txt114.Text = "0";
                            TextObject txt115 = (TextObject)rpt.ReportDefinition.ReportObjects["Text115"]; //Instancie um objeto do tipo TextObject e informe o nome do textbox
                            txt115.Text = "0";
                            TextObject txt116 = (TextObject)rpt.ReportDefinition.ReportObjects["Text116"]; //Instancie um objeto do tipo TextObject e informe o nome do textbox
                            txt116.Text = "0";
                            TextObject txt121 = (TextObject)rpt.ReportDefinition.ReportObjects["Text121"]; //Instancie um objeto do tipo TextObject e informe o nome do textbox
                            txt121.Text = "";
                            //TextObject txt122 = (TextObject)rpt.ReportDefinition.ReportObjects["Text122"]; //Instancie um objeto do tipo TextObject e informe o nome do textbox
                            txt122.Text = "";
                            TextObject txt123 = (TextObject)rpt.ReportDefinition.ReportObjects["Text123"]; //Instancie um objeto do tipo TextObject e informe o nome do textbox
                            txt123.Text = "";
                            TextObject txt117 = (TextObject)rpt.ReportDefinition.ReportObjects["Text117"]; //Instancie um objeto do tipo TextObject e informe o nome do textbox
                            txt117.Text = "0";
                            TextObject txt118 = (TextObject)rpt.ReportDefinition.ReportObjects["Text118"]; //Instancie um objeto do tipo TextObject e informe o nome do textbox
                            txt118.Text = "0";
                            TextObject txt119 = (TextObject)rpt.ReportDefinition.ReportObjects["Text119"]; //Instancie um objeto do tipo TextObject e informe o nome do textbox
                            txt119.Text = "0";

                            //TextObject txt186 = (TextObject)rpt.ReportDefinition.ReportObjects["Text186"]; //Instancie um objeto do tipo TextObject e informe o nome do textbox
                            txt186.Text = "";
                            TextObject txt257 = (TextObject)rpt.ReportDefinition.ReportObjects["Text257"]; //Instancie um objeto do tipo TextObject e informe o nome do textbox
                            txt257.Text = "";
                            TextObject txt176 = (TextObject)rpt.ReportDefinition.ReportObjects["Text176"]; //Instancie um objeto do tipo TextObject e informe o nome do textbox
                            txt176.Text = "0";
                            TextObject txt177 = (TextObject)rpt.ReportDefinition.ReportObjects["Text177"]; //Instancie um objeto do tipo TextObject e informe o nome do textbox
                            txt177.Text = "0";
                            TextObject txt178 = (TextObject)rpt.ReportDefinition.ReportObjects["Text178"]; //Instancie um objeto do tipo TextObject e informe o nome do textbox
                            txt178.Text = "0";
                            TextObject txt179 = (TextObject)rpt.ReportDefinition.ReportObjects["Text179"]; //Instancie um objeto do tipo TextObject e informe o nome do textbox
                            txt179.Text = "0";
                            TextObject txt180 = (TextObject)rpt.ReportDefinition.ReportObjects["Text180"]; //Instancie um objeto do tipo TextObject e informe o nome do textbox
                            txt180.Text = "0";
                            TextObject txt181 = (TextObject)rpt.ReportDefinition.ReportObjects["Text181"]; //Instancie um objeto do tipo TextObject e informe o nome do textbox
                            txt181.Text = "0";
                            TextObject txt182 = (TextObject)rpt.ReportDefinition.ReportObjects["Text182"]; //Instancie um objeto do tipo TextObject e informe o nome do textbox
                            txt182.Text = "0";
                            TextObject txt187 = (TextObject)rpt.ReportDefinition.ReportObjects["Text187"]; //Instancie um objeto do tipo TextObject e informe o nome do textbox
                            txt187.Text = "";
                            //TextObject txt188 = (TextObject)rpt.ReportDefinition.ReportObjects["Text188"]; //Instancie um objeto do tipo TextObject e informe o nome do textbox
                            txt188.Text = "";
                            TextObject txt189 = (TextObject)rpt.ReportDefinition.ReportObjects["Text189"]; //Instancie um objeto do tipo TextObject e informe o nome do textbox
                            txt189.Text = "";
                            TextObject txt183 = (TextObject)rpt.ReportDefinition.ReportObjects["Text183"]; //Instancie um objeto do tipo TextObject e informe o nome do textbox
                            txt183.Text = "0";
                            TextObject txt184 = (TextObject)rpt.ReportDefinition.ReportObjects["Text184"]; //Instancie um objeto do tipo TextObject e informe o nome do textbox
                            txt184.Text = "0";
                            TextObject txt185 = (TextObject)rpt.ReportDefinition.ReportObjects["Text185"]; //Instancie um objeto do tipo TextObject e informe o nome do textbox
                            txt185.Text = "0";


                            //TextObject txt219 = (TextObject)rpt.ReportDefinition.ReportObjects["Text219"]; //Instancie um objeto do tipo TextObject e informe o nome do textbox
                            txt219.Text = "";
                            TextObject txt258 = (TextObject)rpt.ReportDefinition.ReportObjects["Text258"]; //Instancie um objeto do tipo TextObject e informe o nome do textbox
                            txt258.Text = "";
                            TextObject txt209 = (TextObject)rpt.ReportDefinition.ReportObjects["Text209"]; //Instancie um objeto do tipo TextObject e informe o nome do textbox
                            txt209.Text = "0";
                            TextObject txt210 = (TextObject)rpt.ReportDefinition.ReportObjects["Text210"]; //Instancie um objeto do tipo TextObject e informe o nome do textbox
                            txt210.Text = "0";
                            TextObject txt211 = (TextObject)rpt.ReportDefinition.ReportObjects["Text211"]; //Instancie um objeto do tipo TextObject e informe o nome do textbox
                            txt211.Text = "0";
                            TextObject txt212 = (TextObject)rpt.ReportDefinition.ReportObjects["Text212"]; //Instancie um objeto do tipo TextObject e informe o nome do textbox
                            txt212.Text = "0";
                            TextObject txt213 = (TextObject)rpt.ReportDefinition.ReportObjects["Text213"]; //Instancie um objeto do tipo TextObject e informe o nome do textbox
                            txt213.Text = "0";
                            TextObject txt214 = (TextObject)rpt.ReportDefinition.ReportObjects["Text214"]; //Instancie um objeto do tipo TextObject e informe o nome do textbox
                            txt214.Text = "0";
                            TextObject txt215 = (TextObject)rpt.ReportDefinition.ReportObjects["Text215"]; //Instancie um objeto do tipo TextObject e informe o nome do textbox
                            txt215.Text = "0";
                            TextObject txt220 = (TextObject)rpt.ReportDefinition.ReportObjects["Text220"]; //Instancie um objeto do tipo TextObject e informe o nome do textbox
                            txt220.Text = "";
                            //TextObject txt221 = (TextObject)rpt.ReportDefinition.ReportObjects["Text221"]; //Instancie um objeto do tipo TextObject e informe o nome do textbox
                            txt221.Text = "";
                            TextObject txt222 = (TextObject)rpt.ReportDefinition.ReportObjects["Text222"]; //Instancie um objeto do tipo TextObject e informe o nome do textbox
                            txt222.Text = "";
                            TextObject txt216 = (TextObject)rpt.ReportDefinition.ReportObjects["Text216"]; //Instancie um objeto do tipo TextObject e informe o nome do textbox
                            txt216.Text = "0";
                            TextObject txt217 = (TextObject)rpt.ReportDefinition.ReportObjects["Text217"]; //Instancie um objeto do tipo TextObject e informe o nome do textbox
                            txt217.Text = "0";
                            TextObject txt218 = (TextObject)rpt.ReportDefinition.ReportObjects["Text218"]; //Instancie um objeto do tipo TextObject e informe o nome do textbox
                            txt218.Text = "0";


                            //TextObject txt252 = (TextObject)rpt.ReportDefinition.ReportObjects["Text252"]; //Instancie um objeto do tipo TextObject e informe o nome do textbox
                            txt252.Text = "";
                            TextObject txt259 = (TextObject)rpt.ReportDefinition.ReportObjects["Text259"]; //Instancie um objeto do tipo TextObject e informe o nome do textbox
                            txt259.Text = "";
                            TextObject txt242 = (TextObject)rpt.ReportDefinition.ReportObjects["Text242"]; //Instancie um objeto do tipo TextObject e informe o nome do textbox
                            txt242.Text = "0";
                            TextObject txt243 = (TextObject)rpt.ReportDefinition.ReportObjects["Text243"]; //Instancie um objeto do tipo TextObject e informe o nome do textbox
                            txt243.Text = "0";
                            TextObject txt244 = (TextObject)rpt.ReportDefinition.ReportObjects["Text244"]; //Instancie um objeto do tipo TextObject e informe o nome do textbox
                            txt244.Text = "0";
                            TextObject txt245 = (TextObject)rpt.ReportDefinition.ReportObjects["Text245"]; //Instancie um objeto do tipo TextObject e informe o nome do textbox
                            txt245.Text = "0";
                            TextObject txt246 = (TextObject)rpt.ReportDefinition.ReportObjects["Text246"]; //Instancie um objeto do tipo TextObject e informe o nome do textbox
                            txt246.Text = "0";
                            TextObject txt247 = (TextObject)rpt.ReportDefinition.ReportObjects["Text247"]; //Instancie um objeto do tipo TextObject e informe o nome do textbox
                            txt247.Text = "0";
                            TextObject txt248 = (TextObject)rpt.ReportDefinition.ReportObjects["Text248"]; //Instancie um objeto do tipo TextObject e informe o nome do textbox
                            txt248.Text = "0";
                            TextObject txt253 = (TextObject)rpt.ReportDefinition.ReportObjects["Text253"]; //Instancie um objeto do tipo TextObject e informe o nome do textbox
                            txt253.Text = "";
                            //TextObject txt254 = (TextObject)rpt.ReportDefinition.ReportObjects["Text254"]; //Instancie um objeto do tipo TextObject e informe o nome do textbox
                            txt254.Text = "";
                            TextObject txt255 = (TextObject)rpt.ReportDefinition.ReportObjects["Text255"]; //Instancie um objeto do tipo TextObject e informe o nome do textbox
                            txt255.Text = "";
                            TextObject txt249 = (TextObject)rpt.ReportDefinition.ReportObjects["Text249"]; //Instancie um objeto do tipo TextObject e informe o nome do textbox
                            txt249.Text = "0";
                            TextObject txt250 = (TextObject)rpt.ReportDefinition.ReportObjects["Text250"]; //Instancie um objeto do tipo TextObject e informe o nome do textbox
                            txt250.Text = "0";
                            TextObject txt251 = (TextObject)rpt.ReportDefinition.ReportObjects["Text251"]; //Instancie um objeto do tipo TextObject e informe o nome do textbox
                            txt251.Text = "0";



                            //********************************************************************************
                            //********************************************************************************

                            //Carregar Relatório / Impressoras instaladas e padrão

                            crystalReportViewer1.ReportSource = rpt;
                            pictureBox27.Visible = false;
                            Cursor = Cursors.Default;
                            return;
                        }
                    }
                }
            }

            termina = nomes.Rows.Count;
            for (int i = 0; i < nomes.Rows.Count; i++)
            {

                if (venc.Rows.Count > 0)
                {

                    TextObject txt114 = (TextObject)rpt.ReportDefinition.ReportObjects["Text114"]; //Instancie um objeto do tipo TextObject e informe o nome do textbox
                    txt114.Text = venc.Rows[0]["Vencimento"].ToString();

                    TextObject txt180 = (TextObject)rpt.ReportDefinition.ReportObjects["Text180"]; //Instancie um objeto do tipo TextObject e informe o nome do textbox
                    txt180.Text = venc.Rows[0]["Vencimento"].ToString();

                    TextObject txt213 = (TextObject)rpt.ReportDefinition.ReportObjects["Text213"]; //Instancie um objeto do tipo TextObject e informe o nome do textbox
                    txt213.Text = venc.Rows[0]["Vencimento"].ToString();

                    TextObject txt246 = (TextObject)rpt.ReportDefinition.ReportObjects["Text246"]; //Instancie um objeto do tipo TextObject e informe o nome do textbox
                    txt246.Text = venc.Rows[0]["Vencimento"].ToString();


                }

                Cursor = Cursors.WaitCursor;
                if (contImp == 0)
                {
                    TextObject txt256 = (TextObject)rpt.ReportDefinition.ReportObjects["Text256"]; //Instancie um objeto do tipo TextObject e informe o nome do textbox
                    txt256.Text = nomes.Rows[i]["Nome"].ToString();
                    Nome_Re = nomes.Rows[i]["Nome"].ToString();

                    //reimpressão
                    informarNomes += Nome_Re + "\n";

                    TextObject txt117 = (TextObject)rpt.ReportDefinition.ReportObjects["Text117"]; //Instancie um objeto do tipo TextObject e informe o nome do textbox
                    txt117.Text = nomes.Rows[i]["Anterior"].ToString();
                    Anterior_Re = nomes.Rows[i]["Anterior"].ToString();

                    TextObject txt118 = (TextObject)rpt.ReportDefinition.ReportObjects["Text118"]; //Instancie um objeto do tipo TextObject e informe o nome do textbox
                    txt118.Text = nomes.Rows[i]["Atual"].ToString();
                    Atual_Re = nomes.Rows[i]["Atual"].ToString();

                    TextObject txt116 = (TextObject)rpt.ReportDefinition.ReportObjects["Text116"]; //Instancie um objeto do tipo TextObject e informe o nome do textbox
                    txt116.Text = nomes.Rows[i]["Atraso"].ToString();
                    Atraso_Re = nomes.Rows[i]["Atraso"].ToString();

                    TextObject txt123 = (TextObject)rpt.ReportDefinition.ReportObjects["Text123"]; //Instancie um objeto do tipo TextObject e informe o nome do textbox
                    txt123.Text = nomes.Rows[i]["Observação"].ToString();
                }
                if (contImp == 1)
                {
                    TextObject txt257 = (TextObject)rpt.ReportDefinition.ReportObjects["Text257"]; //Instancie um objeto do tipo TextObject e informe o nome do textbox
                    txt257.Text = nomes.Rows[i]["Nome"].ToString();
                    Nome_Re = nomes.Rows[i]["Nome"].ToString();

                    //reimpressão
                    informarNomes += Nome_Re + "\n";

                    TextObject txt183 = (TextObject)rpt.ReportDefinition.ReportObjects["Text183"]; //Instancie um objeto do tipo TextObject e informe o nome do textbox
                    txt183.Text = nomes.Rows[i]["Anterior"].ToString();
                    Anterior_Re = nomes.Rows[i]["Anterior"].ToString();

                    TextObject txt184 = (TextObject)rpt.ReportDefinition.ReportObjects["Text184"]; //Instancie um objeto do tipo TextObject e informe o nome do textbox
                    txt184.Text = nomes.Rows[i]["Atual"].ToString();
                    Atual_Re = nomes.Rows[i]["Atual"].ToString();

                    TextObject txt182 = (TextObject)rpt.ReportDefinition.ReportObjects["Text182"]; //Instancie um objeto do tipo TextObject e informe o nome do textbox
                    txt182.Text = nomes.Rows[i]["Atraso"].ToString();
                    Atraso_Re = nomes.Rows[i]["Atraso"].ToString();

                    TextObject txt189 = (TextObject)rpt.ReportDefinition.ReportObjects["Text189"]; //Instancie um objeto do tipo TextObject e informe o nome do textbox
                    txt189.Text = nomes.Rows[i]["Observação"].ToString();
                }
                if (contImp == 2)
                {
                    TextObject txt258 = (TextObject)rpt.ReportDefinition.ReportObjects["Text258"]; //Instancie um objeto do tipo TextObject e informe o nome do textbox
                    txt258.Text = nomes.Rows[i]["Nome"].ToString();
                    Nome_Re = nomes.Rows[i]["Nome"].ToString();

                    //reimpressão
                    informarNomes += Nome_Re + "\n";

                    TextObject txt216 = (TextObject)rpt.ReportDefinition.ReportObjects["Text216"]; //Instancie um objeto do tipo TextObject e informe o nome do textbox
                    txt216.Text = nomes.Rows[i]["Anterior"].ToString();
                    Anterior_Re = nomes.Rows[i]["Anterior"].ToString();

                    TextObject txt217 = (TextObject)rpt.ReportDefinition.ReportObjects["Text217"]; //Instancie um objeto do tipo TextObject e informe o nome do textbox
                    txt217.Text = nomes.Rows[i]["Atual"].ToString();
                    Atual_Re = nomes.Rows[i]["Atual"].ToString();

                    TextObject txt215 = (TextObject)rpt.ReportDefinition.ReportObjects["Text215"]; //Instancie um objeto do tipo TextObject e informe o nome do textbox
                    txt215.Text = nomes.Rows[i]["Atraso"].ToString();
                    Atraso_Re = nomes.Rows[i]["Atraso"].ToString();

                    TextObject txt222 = (TextObject)rpt.ReportDefinition.ReportObjects["Text222"]; //Instancie um objeto do tipo TextObject e informe o nome do textbox
                    txt222.Text = nomes.Rows[i]["Observação"].ToString();
                }
                if (contImp == 3)
                {
                    TextObject txt259 = (TextObject)rpt.ReportDefinition.ReportObjects["Text259"]; //Instancie um objeto do tipo TextObject e informe o nome do textbox
                    txt259.Text = nomes.Rows[i]["Nome"].ToString();
                    Nome_Re = nomes.Rows[i]["Nome"].ToString();

                    //reimpressão
                    informarNomes += Nome_Re + "\n";

                    TextObject txt249 = (TextObject)rpt.ReportDefinition.ReportObjects["Text249"]; //Instancie um objeto do tipo TextObject e informe o nome do textbox
                    txt249.Text = nomes.Rows[i]["Anterior"].ToString();
                    Anterior_Re = nomes.Rows[i]["Anterior"].ToString();

                    TextObject txt250 = (TextObject)rpt.ReportDefinition.ReportObjects["Text250"]; //Instancie um objeto do tipo TextObject e informe o nome do textbox
                    txt250.Text = nomes.Rows[i]["Atual"].ToString();
                    Atual_Re = nomes.Rows[i]["Atual"].ToString();

                    TextObject txt248 = (TextObject)rpt.ReportDefinition.ReportObjects["Text248"]; //Instancie um objeto do tipo TextObject e informe o nome do textbox
                    txt248.Text = nomes.Rows[i]["Atraso"].ToString();
                    Atraso_Re = nomes.Rows[i]["Atraso"].ToString();

                    TextObject txt255 = (TextObject)rpt.ReportDefinition.ReportObjects["Text255"]; //Instancie um objeto do tipo TextObject e informe o nome do textbox
                    txt255.Text = nomes.Rows[i]["Observação"].ToString();
                }


                //consumo
                TextObject txt119 = (TextObject)rpt.ReportDefinition.ReportObjects["Text119"];
                if (String.IsNullOrEmpty(txt119.Text) == true)
                {
                    txt119.Text = "0";
                }
                TextObject txt185 = (TextObject)rpt.ReportDefinition.ReportObjects["Text185"];
                if (String.IsNullOrEmpty(txt185.Text) == true)
                {
                    txt185.Text = "0";
                }
                TextObject txt218 = (TextObject)rpt.ReportDefinition.ReportObjects["Text218"];
                if (String.IsNullOrEmpty(txt218.Text) == true)
                {
                    txt119.Text = "0";
                }
                TextObject txt251 = (TextObject)rpt.ReportDefinition.ReportObjects["Text251"];
                if (String.IsNullOrEmpty(txt251.Text) == true)
                {
                    txt251.Text = "0";
                }

                //contando consumo m³
                if (contImp == 0)
                {
                    TextObject txt118 = (TextObject)rpt.ReportDefinition.ReportObjects["Text118"];
                    TextObject txt117 = (TextObject)rpt.ReportDefinition.ReportObjects["Text117"];
                    txt119.Text = Convert.ToString(Convert.ToInt32(txt118.Text) - Convert.ToInt32(txt117.Text));
                    Consumo_Re = Convert.ToString(Convert.ToInt32(txt118.Text) - Convert.ToInt32(txt117.Text));
                }
                if (contImp == 1)
                {
                    TextObject txt184 = (TextObject)rpt.ReportDefinition.ReportObjects["Text184"];
                    TextObject txt183 = (TextObject)rpt.ReportDefinition.ReportObjects["Text183"];
                    txt185.Text = Convert.ToString(Convert.ToInt32(txt184.Text) - Convert.ToInt32(txt183.Text));
                    Consumo_Re = Convert.ToString(Convert.ToInt32(txt184.Text) - Convert.ToInt32(txt183.Text));
                }
                if (contImp == 2)
                {
                    TextObject txt217 = (TextObject)rpt.ReportDefinition.ReportObjects["Text217"];
                    TextObject txt216 = (TextObject)rpt.ReportDefinition.ReportObjects["Text216"];
                    txt218.Text = Convert.ToString(Convert.ToInt32(txt217.Text) - Convert.ToInt32(txt216.Text));
                    Consumo_Re = Convert.ToString(Convert.ToInt32(txt217.Text) - Convert.ToInt32(txt216.Text));
                }
                if (contImp == 3)
                {
                    TextObject txt250 = (TextObject)rpt.ReportDefinition.ReportObjects["Text250"];
                    TextObject txt249 = (TextObject)rpt.ReportDefinition.ReportObjects["Text249"];
                    txt251.Text = Convert.ToString(Convert.ToInt32(txt250.Text) - Convert.ToInt32(txt249.Text));
                    Consumo_Re = Convert.ToString(Convert.ToInt32(txt250.Text) - Convert.ToInt32(txt249.Text));
                }
                //valor consumo
                string valor1 = config.Rows[0]["Valor_Base"].ToString();
                string valor2 = "0";
                string valor3 = "0";
                string valor4 = "0";
                string resultado = "0";
                int consu = 0;
                if (contImp == 0)
                {
                    consu = Convert.ToInt32(txt119.Text);
                }
                if (contImp == 1)
                {
                    consu = Convert.ToInt32(txt185.Text);
                }
                if (contImp == 2)
                {
                    consu = Convert.ToInt32(txt218.Text);
                }
                if (contImp == 3)
                {
                    consu = Convert.ToInt32(txt251.Text);
                }


                if (consu > 10 && consu <= 30)
                {

                    Double re = Convert.ToDouble(consu - 10) * Convert.ToDouble(config.Rows[0]["Dez_Trinta"].ToString());
                    valor2 = re.ToString("N2");


                }
                if (consu > 30 && consu <= 90)
                {
                    Double re30 = Convert.ToDouble(20) * Convert.ToDouble(config.Rows[0]["Dez_Trinta"].ToString());
                    Double re = Convert.ToDouble(consu - 30) * Convert.ToDouble(config.Rows[0]["Trinta_Noventa"].ToString());
                    re = re + re30;
                    valor3 = re.ToString("N2");


                }
                if (consu > 90)
                {
                    Double re30 = Convert.ToDouble(20) * Convert.ToDouble(config.Rows[0]["Dez_Trinta"].ToString());
                    Double re50 = Convert.ToDouble(50) * Convert.ToDouble(config.Rows[0]["Trinta_Noventa"].ToString());

                    Double re = Convert.ToDouble(consu - 90) * Convert.ToDouble(config.Rows[0]["Noventa"].ToString());

                    re = re + re30 + re50;
                    valor4 = re.ToString("N2");


                }
                Double rec = Convert.ToDouble(valor1) + Convert.ToDouble(valor2) + Convert.ToDouble(valor3) + Convert.ToDouble(valor4);
                resultado = rec.ToString("N2");

                //valor consumo
                if (contImp == 0)
                {
                    TextObject txt110 = (TextObject)rpt.ReportDefinition.ReportObjects["Text110"];
                    txt110.Text = rec.ToString("N2");
                    Valor_Re = rec.ToString("N2");
                }
                if (contImp == 1)
                {
                    TextObject txt176 = (TextObject)rpt.ReportDefinition.ReportObjects["Text176"];
                    txt176.Text = rec.ToString("N2");
                    Valor_Re = rec.ToString("N2");
                }
                if (contImp == 2)
                {
                    TextObject txt209 = (TextObject)rpt.ReportDefinition.ReportObjects["Text209"];
                    txt209.Text = rec.ToString("N2");
                    Valor_Re = rec.ToString("N2");
                }
                if (contImp == 3)
                {
                    TextObject txt242 = (TextObject)rpt.ReportDefinition.ReportObjects["Text242"];
                    txt242.Text = rec.ToString("N2");
                    Valor_Re = rec.ToString("N2");
                }

                //pega rateio
                DataTable rateio = DAL.Lista_Rateio();
                string valorRateio = "0";
                if (rateio.Rows.Count > 0)
                {
                    for (int j = 0; j < rateio.Rows.Count; j++)
                    {
                        if (rateio.Rows[j]["Parcelado"].ToString() == "não")
                        {
                            Double rec1 = Convert.ToDouble(resultado) / nomes.Rows.Count + Convert.ToDouble(rateio.Rows[j]["Valor"].ToString());
                            resultado = rec1.ToString("N2");

                            Double rec2 = Convert.ToDouble(valorRateio) / nomes.Rows.Count + Convert.ToDouble(rateio.Rows[j]["Valor"].ToString());
                            valorRateio = rec2.ToString("N2");
                            //exibir rateio
                            if (contImp == 0)
                            {
                                TextObject txt121 = (TextObject)rpt.ReportDefinition.ReportObjects["Text121"];
                                txt121.Text += " - " + rateio.Rows[j]["Descrição"].ToString();
                            }
                            if (contImp == 1)
                            {
                                TextObject txt187 = (TextObject)rpt.ReportDefinition.ReportObjects["Text187"];
                                txt187.Text += " - " + rateio.Rows[j]["Descrição"].ToString();
                            }
                            if (contImp == 2)
                            {
                                TextObject txt220 = (TextObject)rpt.ReportDefinition.ReportObjects["Text220"];
                                txt220.Text += " - " + rateio.Rows[j]["Descrição"].ToString();
                            }
                            if (contImp == 3)
                            {
                                TextObject txt253 = (TextObject)rpt.ReportDefinition.ReportObjects["Text253"];
                                txt253.Text += " - " + rateio.Rows[j]["Descrição"].ToString();
                            }

                        }
                        if (rateio.Rows[j]["Parcelado"].ToString() == "sim")
                        {
                            DataTable rat_parc = DAL.Lista_Rateio_Parcelado(Convert.ToInt32(rateio.Rows[j]["Id"].ToString()));
                            if (rat_parc.Rows.Count > 0)
                            {
                                Double rec1 = Convert.ToDouble(resultado) + Convert.ToDouble(rat_parc.Rows[0]["Valor"].ToString()) / nomes.Rows.Count;
                                resultado = rec1.ToString("N2");

                                Double rec2 = Convert.ToDouble(valorRateio) + Convert.ToDouble(rat_parc.Rows[0]["Valor"].ToString()) / nomes.Rows.Count;
                                valorRateio = rec2.ToString("N2");
                                //exibir rateio parcelado
                                if (contImp == 0)
                                {
                                    TextObject txt121 = (TextObject)rpt.ReportDefinition.ReportObjects["Text121"];
                                    txt121.Text += "- " + rat_parc.Rows[0]["Descrição"].ToString() + ",Parc. " + rat_parc.Rows[0]["Parcela"].ToString();
                                }
                                if (contImp == 1)
                                {
                                    TextObject txt187 = (TextObject)rpt.ReportDefinition.ReportObjects["Text187"];
                                    txt187.Text += "- " + rat_parc.Rows[0]["Descrição"].ToString() + ",Parc. " + rat_parc.Rows[0]["Parcela"].ToString();
                                }
                                if (contImp == 2)
                                {
                                    TextObject txt220 = (TextObject)rpt.ReportDefinition.ReportObjects["Text220"];
                                    txt220.Text += "- " + rat_parc.Rows[0]["Descrição"].ToString() + ",Parc. " + rat_parc.Rows[0]["Parcela"].ToString();
                                }
                                if (contImp == 3)
                                {
                                    TextObject txt253 = (TextObject)rpt.ReportDefinition.ReportObjects["Text253"];
                                    txt253.Text += "- " + rat_parc.Rows[0]["Descrição"].ToString() + ",Parc. " + rat_parc.Rows[0]["Parcela"].ToString();
                                }

                            }

                        }
                    }
                }
                //exibir rateio valor
                if (contImp == 0)
                {
                    TextObject txt111 = (TextObject)rpt.ReportDefinition.ReportObjects["Text111"];
                    txt111.Text = valorRateio;
                    Rateio_Re = valorRateio;
                }
                if (contImp == 1)
                {
                    TextObject txt177 = (TextObject)rpt.ReportDefinition.ReportObjects["Text177"];
                    txt177.Text = valorRateio;
                    Rateio_Re = valorRateio;
                }
                if (contImp == 2)
                {
                    TextObject txt210 = (TextObject)rpt.ReportDefinition.ReportObjects["Text210"];
                    txt210.Text = valorRateio;
                    Rateio_Re = valorRateio;
                }
                if (contImp == 3)
                {
                    TextObject txt243 = (TextObject)rpt.ReportDefinition.ReportObjects["Text243"];
                    txt243.Text = valorRateio;
                    Rateio_Re = valorRateio;
                }

                string valorTX = "0";
                //tx
                //DataTable tx = DAL.Lista_Nome();

                if (Convert.ToInt32(nomes.Rows[i]["TX_Comercial"].ToString()) >= 1)
                {
                    string taxa = config.Rows[0]["TX_Comercial"].ToString();
                    Double rec1 = Convert.ToDouble(resultado) + (Convert.ToDouble(taxa) * Convert.ToDouble(nomes.Rows[i]["TX_Comercial"].ToString()));
                    resultado = rec1.ToString("N2");


                    Double rec2 = Convert.ToDouble(valorTX) + (Convert.ToDouble(taxa) * Convert.ToDouble(nomes.Rows[i]["TX_Comercial"].ToString()));
                    valorTX = rec2.ToString("N2");
                }

                if (contImp == 0)
                {
                    //valor total //tx
                    TextObject txt113 = (TextObject)rpt.ReportDefinition.ReportObjects["Text113"];
                    txt113.Text = resultado;
                    Total_Re = resultado;

                    TextObject txt112 = (TextObject)rpt.ReportDefinition.ReportObjects["Text112"];
                    txt112.Text = valorTX;
                    TX_Re = valorTX;
                }
                if (contImp == 1)
                {
                    //valor total //tx
                    TextObject txt179 = (TextObject)rpt.ReportDefinition.ReportObjects["Text179"];
                    txt179.Text = resultado;
                    Total_Re = resultado;

                    TextObject txt178 = (TextObject)rpt.ReportDefinition.ReportObjects["Text178"];
                    txt178.Text = valorTX;
                    TX_Re = valorTX;
                }
                if (contImp == 2)
                {
                    //valor total //tx
                    TextObject txt212 = (TextObject)rpt.ReportDefinition.ReportObjects["Text212"];
                    txt212.Text = resultado;
                    Total_Re = resultado;

                    TextObject txt211 = (TextObject)rpt.ReportDefinition.ReportObjects["Text211"];
                    txt211.Text = valorTX;
                    TX_Re = valorTX;
                }
                if (contImp == 3)
                {
                    //valor total //tx
                    TextObject txt245 = (TextObject)rpt.ReportDefinition.ReportObjects["Text245"];
                    txt245.Text = resultado;
                    Total_Re = resultado;

                    TextObject txt244 = (TextObject)rpt.ReportDefinition.ReportObjects["Text244"];
                    txt244.Text = valorTX;
                    TX_Re = valorTX;
                }


                //valor com multa
                Double rec3 = Convert.ToDouble(resultado) * Convert.ToDouble("1,0" + config.Rows[0]["Multa"].ToString());
                if (contImp == 0)
                {
                    TextObject txt115 = (TextObject)rpt.ReportDefinition.ReportObjects["Text115"];
                    txt115.Text = rec3.ToString("N2");
                    TotalMulta_Re = rec3.ToString("N2");
                }
                if (contImp == 1)
                {
                    TextObject txt181 = (TextObject)rpt.ReportDefinition.ReportObjects["Text181"];
                    txt181.Text = rec3.ToString("N2");
                    TotalMulta_Re = rec3.ToString("N2");
                }
                if (contImp == 2)
                {
                    TextObject txt214 = (TextObject)rpt.ReportDefinition.ReportObjects["Text214"];
                    txt214.Text = rec3.ToString("N2");
                    TotalMulta_Re = rec3.ToString("N2");
                }
                if (contImp == 3)
                {
                    TextObject txt247 = (TextObject)rpt.ReportDefinition.ReportObjects["Text247"];
                    txt247.Text = rec3.ToString("N2");
                    TotalMulta_Re = rec3.ToString("N2");
                }

                termina--;

                //relatório
                //************************************************************************************
                //************************************************************************************

               DAL.Cria_Relatorio(Nome_Re, Anterior_Re, Atual_Re, Consumo_Re, Valor_Re, Rateio_Re, TX_Re, Total_Re, TotalMulta_Re, Atraso_Re, "0,00", nomes.Rows[i]["Observação"].ToString(), Mes_Re);

                //************************************************************************************
                //************************************************************************************
                
                if (termina == 0)
                {

                    tabControl1.SelectedTab = tabPage3;
                    panel8.VerticalScroll.Value = 0;

                    //*************************
                    //código para imprimir aqui
                    //*************************

                    crystalReportViewer1.ReportSource = rpt;
                    //

                    string message = "Deseja Imprimir esta página?\n\n" + informarNomes;
                    informarNomes = "";
                    string caption = "Reimpressão";
                    MessageBoxButtons buttons = MessageBoxButtons.YesNo;
                    DialogResult result;

                    // Displays the MessageBox.

                    result = MessageBox.Show(this, message, caption, buttons,
                    MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);


                    if (result == DialogResult.No)
                    {
                       
                        
                    }
                    if (result == DialogResult.Yes)
                    {
                        // crystalReportViewer1.PrintReport();
                        rpt.PrintToPrinter(1, false, 0, 0);

                        //*************************
                        //pictureBox27.Visible = false;
                        //Cursor = Cursors.Default;
                        pag++;
                        Form print = new Print("Imprimindo Recibos Pág. " + Convert.ToString(pag));
                        print.ShowDialog();
                    }
   

                    

                    //Preparar campos do relatório
                    //TextObject txt120 = (TextObject)rpt.ReportDefinition.ReportObjects["Text120"]; //Instancie um objeto do tipo TextObject e informe o nome do textbox
                    //txt120.Text = "";
                    TextObject txt256 = (TextObject)rpt.ReportDefinition.ReportObjects["Text256"]; //Instancie um objeto do tipo TextObject e informe o nome do textbox
                    txt256.Text = "";
                    TextObject txt110 = (TextObject)rpt.ReportDefinition.ReportObjects["Text110"]; //Instancie um objeto do tipo TextObject e informe o nome do textbox
                    txt110.Text = "0";
                    TextObject txt111 = (TextObject)rpt.ReportDefinition.ReportObjects["Text111"]; //Instancie um objeto do tipo TextObject e informe o nome do textbox
                    txt111.Text = "0";
                    TextObject txt112 = (TextObject)rpt.ReportDefinition.ReportObjects["Text112"]; //Instancie um objeto do tipo TextObject e informe o nome do textbox
                    txt112.Text = "0";
                    TextObject txt113 = (TextObject)rpt.ReportDefinition.ReportObjects["Text113"]; //Instancie um objeto do tipo TextObject e informe o nome do textbox
                    txt113.Text = "0";
                    TextObject txt114 = (TextObject)rpt.ReportDefinition.ReportObjects["Text114"]; //Instancie um objeto do tipo TextObject e informe o nome do textbox
                    txt114.Text = "0";
                    TextObject txt115 = (TextObject)rpt.ReportDefinition.ReportObjects["Text115"]; //Instancie um objeto do tipo TextObject e informe o nome do textbox
                    txt115.Text = "0";
                    TextObject txt116 = (TextObject)rpt.ReportDefinition.ReportObjects["Text116"]; //Instancie um objeto do tipo TextObject e informe o nome do textbox
                    txt116.Text = "0";
                    TextObject txt121 = (TextObject)rpt.ReportDefinition.ReportObjects["Text121"]; //Instancie um objeto do tipo TextObject e informe o nome do textbox
                    txt121.Text = "";
                    //TextObject txt122 = (TextObject)rpt.ReportDefinition.ReportObjects["Text122"]; //Instancie um objeto do tipo TextObject e informe o nome do textbox
                    //txt122.Text = "";
                    TextObject txt123 = (TextObject)rpt.ReportDefinition.ReportObjects["Text123"]; //Instancie um objeto do tipo TextObject e informe o nome do textbox
                    txt123.Text = "";
                    TextObject txt117 = (TextObject)rpt.ReportDefinition.ReportObjects["Text117"]; //Instancie um objeto do tipo TextObject e informe o nome do textbox
                    txt117.Text = "0";
                    TextObject txt118 = (TextObject)rpt.ReportDefinition.ReportObjects["Text118"]; //Instancie um objeto do tipo TextObject e informe o nome do textbox
                    txt118.Text = "0";
                    //TextObject txt119 = (TextObject)rpt.ReportDefinition.ReportObjects["Text119"]; //Instancie um objeto do tipo TextObject e informe o nome do textbox
                    txt119.Text = "0";

                    //TextObject txt186 = (TextObject)rpt.ReportDefinition.ReportObjects["Text186"]; //Instancie um objeto do tipo TextObject e informe o nome do textbox
                    //txt186.Text = "";
                    TextObject txt257 = (TextObject)rpt.ReportDefinition.ReportObjects["Text257"]; //Instancie um objeto do tipo TextObject e informe o nome do textbox
                    txt257.Text = "";
                    TextObject txt176 = (TextObject)rpt.ReportDefinition.ReportObjects["Text176"]; //Instancie um objeto do tipo TextObject e informe o nome do textbox
                    txt176.Text = "0";
                    TextObject txt177 = (TextObject)rpt.ReportDefinition.ReportObjects["Text177"]; //Instancie um objeto do tipo TextObject e informe o nome do textbox
                    txt177.Text = "0";
                    TextObject txt178 = (TextObject)rpt.ReportDefinition.ReportObjects["Text178"]; //Instancie um objeto do tipo TextObject e informe o nome do textbox
                    txt178.Text = "0";
                    TextObject txt179 = (TextObject)rpt.ReportDefinition.ReportObjects["Text179"]; //Instancie um objeto do tipo TextObject e informe o nome do textbox
                    txt179.Text = "0";
                    TextObject txt180 = (TextObject)rpt.ReportDefinition.ReportObjects["Text180"]; //Instancie um objeto do tipo TextObject e informe o nome do textbox
                    txt180.Text = "0";
                    TextObject txt181 = (TextObject)rpt.ReportDefinition.ReportObjects["Text181"]; //Instancie um objeto do tipo TextObject e informe o nome do textbox
                    txt181.Text = "0";
                    TextObject txt182 = (TextObject)rpt.ReportDefinition.ReportObjects["Text182"]; //Instancie um objeto do tipo TextObject e informe o nome do textbox
                    txt182.Text = "0";
                    TextObject txt187 = (TextObject)rpt.ReportDefinition.ReportObjects["Text187"]; //Instancie um objeto do tipo TextObject e informe o nome do textbox
                    txt187.Text = "";
                    //TextObject txt188 = (TextObject)rpt.ReportDefinition.ReportObjects["Text188"]; //Instancie um objeto do tipo TextObject e informe o nome do textbox
                    //txt188.Text = "";
                    TextObject txt189 = (TextObject)rpt.ReportDefinition.ReportObjects["Text189"]; //Instancie um objeto do tipo TextObject e informe o nome do textbox
                    txt189.Text = "";
                    TextObject txt183 = (TextObject)rpt.ReportDefinition.ReportObjects["Text183"]; //Instancie um objeto do tipo TextObject e informe o nome do textbox
                    txt183.Text = "0";
                    TextObject txt184 = (TextObject)rpt.ReportDefinition.ReportObjects["Text184"]; //Instancie um objeto do tipo TextObject e informe o nome do textbox
                    txt184.Text = "0";
                    //TextObject txt185 = (TextObject)rpt.ReportDefinition.ReportObjects["Text185"]; //Instancie um objeto do tipo TextObject e informe o nome do textbox
                    txt185.Text = "0";


                    //TextObject txt219 = (TextObject)rpt.ReportDefinition.ReportObjects["Text219"]; //Instancie um objeto do tipo TextObject e informe o nome do textbox
                    //txt219.Text = "";
                    TextObject txt258 = (TextObject)rpt.ReportDefinition.ReportObjects["Text258"]; //Instancie um objeto do tipo TextObject e informe o nome do textbox
                    txt258.Text = "";
                    TextObject txt209 = (TextObject)rpt.ReportDefinition.ReportObjects["Text209"]; //Instancie um objeto do tipo TextObject e informe o nome do textbox
                    txt209.Text = "0";
                    TextObject txt210 = (TextObject)rpt.ReportDefinition.ReportObjects["Text210"]; //Instancie um objeto do tipo TextObject e informe o nome do textbox
                    txt210.Text = "0";
                    TextObject txt211 = (TextObject)rpt.ReportDefinition.ReportObjects["Text211"]; //Instancie um objeto do tipo TextObject e informe o nome do textbox
                    txt211.Text = "0";
                    TextObject txt212 = (TextObject)rpt.ReportDefinition.ReportObjects["Text212"]; //Instancie um objeto do tipo TextObject e informe o nome do textbox
                    txt212.Text = "0";
                    TextObject txt213 = (TextObject)rpt.ReportDefinition.ReportObjects["Text213"]; //Instancie um objeto do tipo TextObject e informe o nome do textbox
                    txt213.Text = "0";
                    TextObject txt214 = (TextObject)rpt.ReportDefinition.ReportObjects["Text214"]; //Instancie um objeto do tipo TextObject e informe o nome do textbox
                    txt214.Text = "0";
                    TextObject txt215 = (TextObject)rpt.ReportDefinition.ReportObjects["Text215"]; //Instancie um objeto do tipo TextObject e informe o nome do textbox
                    txt215.Text = "0";
                    TextObject txt220 = (TextObject)rpt.ReportDefinition.ReportObjects["Text220"]; //Instancie um objeto do tipo TextObject e informe o nome do textbox
                    txt220.Text = "";
                    //TextObject txt221 = (TextObject)rpt.ReportDefinition.ReportObjects["Text221"]; //Instancie um objeto do tipo TextObject e informe o nome do textbox
                    //txt221.Text = "";
                    TextObject txt222 = (TextObject)rpt.ReportDefinition.ReportObjects["Text222"]; //Instancie um objeto do tipo TextObject e informe o nome do textbox
                    txt222.Text = "";
                    TextObject txt216 = (TextObject)rpt.ReportDefinition.ReportObjects["Text216"]; //Instancie um objeto do tipo TextObject e informe o nome do textbox
                    txt216.Text = "0";
                    TextObject txt217 = (TextObject)rpt.ReportDefinition.ReportObjects["Text217"]; //Instancie um objeto do tipo TextObject e informe o nome do textbox
                    txt217.Text = "0";
                    //TextObject txt218 = (TextObject)rpt.ReportDefinition.ReportObjects["Text218"]; //Instancie um objeto do tipo TextObject e informe o nome do textbox
                    txt218.Text = "0";


                    //TextObject txt252 = (TextObject)rpt.ReportDefinition.ReportObjects["Text252"]; //Instancie um objeto do tipo TextObject e informe o nome do textbox
                    //txt252.Text = "";
                    TextObject txt259 = (TextObject)rpt.ReportDefinition.ReportObjects["Text259"]; //Instancie um objeto do tipo TextObject e informe o nome do textbox
                    txt259.Text = "";
                    TextObject txt242 = (TextObject)rpt.ReportDefinition.ReportObjects["Text242"]; //Instancie um objeto do tipo TextObject e informe o nome do textbox
                    txt242.Text = "0";
                    TextObject txt243 = (TextObject)rpt.ReportDefinition.ReportObjects["Text243"]; //Instancie um objeto do tipo TextObject e informe o nome do textbox
                    txt243.Text = "0";
                    TextObject txt244 = (TextObject)rpt.ReportDefinition.ReportObjects["Text244"]; //Instancie um objeto do tipo TextObject e informe o nome do textbox
                    txt244.Text = "0";
                    TextObject txt245 = (TextObject)rpt.ReportDefinition.ReportObjects["Text245"]; //Instancie um objeto do tipo TextObject e informe o nome do textbox
                    txt245.Text = "0";
                    TextObject txt246 = (TextObject)rpt.ReportDefinition.ReportObjects["Text246"]; //Instancie um objeto do tipo TextObject e informe o nome do textbox
                    txt246.Text = "0";
                    TextObject txt247 = (TextObject)rpt.ReportDefinition.ReportObjects["Text247"]; //Instancie um objeto do tipo TextObject e informe o nome do textbox
                    txt247.Text = "0";
                    TextObject txt248 = (TextObject)rpt.ReportDefinition.ReportObjects["Text248"]; //Instancie um objeto do tipo TextObject e informe o nome do textbox
                    txt248.Text = "0";
                    TextObject txt253 = (TextObject)rpt.ReportDefinition.ReportObjects["Text253"]; //Instancie um objeto do tipo TextObject e informe o nome do textbox
                    txt253.Text = "";
                    //TextObject txt254 = (TextObject)rpt.ReportDefinition.ReportObjects["Text254"]; //Instancie um objeto do tipo TextObject e informe o nome do textbox
                    //txt254.Text = "";
                    TextObject txt255 = (TextObject)rpt.ReportDefinition.ReportObjects["Text255"]; //Instancie um objeto do tipo TextObject e informe o nome do textbox
                    txt255.Text = "";
                    TextObject txt249 = (TextObject)rpt.ReportDefinition.ReportObjects["Text249"]; //Instancie um objeto do tipo TextObject e informe o nome do textbox
                    txt249.Text = "0";
                    TextObject txt250 = (TextObject)rpt.ReportDefinition.ReportObjects["Text250"]; //Instancie um objeto do tipo TextObject e informe o nome do textbox
                    txt250.Text = "0";
                    //TextObject txt251 = (TextObject)rpt.ReportDefinition.ReportObjects["Text251"]; //Instancie um objeto do tipo TextObject e informe o nome do textbox
                    txt251.Text = "0";



                    //********************************************************************************
                    //********************************************************************************
                    //crystalReportViewer1.ReportSource = rpt;

                    contImp = 0;

                    //********************************************************************************
                    //********************************************************************************
                    //********************************************************************************
                    //imprimir relatório
                    //********************************************************************************
                    //********************************************************************************



                    TextObject txt42 = (TextObject)rpt1.ReportDefinition.ReportObjects["Text42"]; //Instancie um objeto do tipo TextObject e informe o nome do textbox
                    txt42.Text = "";
                    TextObject txt43 = (TextObject)rpt1.ReportDefinition.ReportObjects["Text43"]; //Instancie um objeto do tipo TextObject e informe o nome do textbox
                    txt43.Text = "";
                    TextObject txt44 = (TextObject)rpt1.ReportDefinition.ReportObjects["Text44"]; //Instancie um objeto do tipo TextObject e informe o nome do textbox
                    txt44.Text = "";
                    TextObject txt1 = (TextObject)rpt1.ReportDefinition.ReportObjects["Text1"]; //Instancie um objeto do tipo TextObject e informe o nome do textbox
                    txt1.Text = "";
                    TextObject txt4 = (TextObject)rpt1.ReportDefinition.ReportObjects["Text4"]; //Instancie um objeto do tipo TextObject e informe o nome do textbox
                    txt4.Text = "";
                    TextObject txt14 = (TextObject)rpt1.ReportDefinition.ReportObjects["Text14"]; //Instancie um objeto do tipo TextObject e informe o nome do textbox
                    txt14.Text = "";
                    TextObject txt17 = (TextObject)rpt1.ReportDefinition.ReportObjects["Text17"]; //Instancie um objeto do tipo TextObject e informe o nome do textbox
                    txt17.Text = "";
                    TextObject txt27 = (TextObject)rpt1.ReportDefinition.ReportObjects["Text27"]; //Instancie um objeto do tipo TextObject e informe o nome do textbox
                    txt27.Text = "";
                    TextObject txt28 = (TextObject)rpt1.ReportDefinition.ReportObjects["Text28"]; //Instancie um objeto do tipo TextObject e informe o nome do textbox
                    txt28.Text = "";
                    TextObject txt29 = (TextObject)rpt1.ReportDefinition.ReportObjects["Text29"]; //Instancie um objeto do tipo TextObject e informe o nome do textbox
                    txt29.Text = "";
                    TextObject txt30 = (TextObject)rpt1.ReportDefinition.ReportObjects["Text30"]; //Instancie um objeto do tipo TextObject e informe o nome do textbox
                    txt30.Text = "";
                    TextObject txt31 = (TextObject)rpt1.ReportDefinition.ReportObjects["Text31"]; //Instancie um objeto do tipo TextObject e informe o nome do textbox
                    txt31.Text = "";
                    TextObject txt32 = (TextObject)rpt1.ReportDefinition.ReportObjects["Text32"]; //Instancie um objeto do tipo TextObject e informe o nome do textbox
                    txt32.Text = "";
                    TextObject txt33 = (TextObject)rpt1.ReportDefinition.ReportObjects["Text33"]; //Instancie um objeto do tipo TextObject e informe o nome do textbox
                    txt33.Text = "";
                    TextObject txt34 = (TextObject)rpt1.ReportDefinition.ReportObjects["Text34"]; //Instancie um objeto do tipo TextObject e informe o nome do textbox
                    txt34.Text = "";
                    TextObject txt35 = (TextObject)rpt1.ReportDefinition.ReportObjects["Text35"]; //Instancie um objeto do tipo TextObject e informe o nome do textbox
                    txt35.Text = "";
                    TextObject txt36 = (TextObject)rpt1.ReportDefinition.ReportObjects["Text36"]; //Instancie um objeto do tipo TextObject e informe o nome do textbox
                    txt36.Text = "";
                    TextObject txt37 = (TextObject)rpt1.ReportDefinition.ReportObjects["Text37"]; //Instancie um objeto do tipo TextObject e informe o nome do textbox
                    txt37.Text = "";
                    TextObject txt38 = (TextObject)rpt1.ReportDefinition.ReportObjects["Text38"]; //Instancie um objeto do tipo TextObject e informe o nome do textbox
                    txt38.Text = "";
                    TextObject txt39 = (TextObject)rpt1.ReportDefinition.ReportObjects["Text39"]; //Instancie um objeto do tipo TextObject e informe o nome do textbox
                    txt39.Text = "";
                    TextObject txt40 = (TextObject)rpt1.ReportDefinition.ReportObjects["Text40"]; //Instancie um objeto do tipo TextObject e informe o nome do textbox
                    txt40.Text = "";
                    TextObject txt41 = (TextObject)rpt1.ReportDefinition.ReportObjects["Text41"]; //Instancie um objeto do tipo TextObject e informe o nome do textbox
                    txt41.Text = "";
                    TextObject txt45 = (TextObject)rpt1.ReportDefinition.ReportObjects["Text45"]; //Instancie um objeto do tipo TextObject e informe o nome do textbox
                    txt45.Text = "";
                    TextObject txt46 = (TextObject)rpt1.ReportDefinition.ReportObjects["Text46"]; //Instancie um objeto do tipo TextObject e informe o nome do textbox
                    txt46.Text = "";
                    TextObject txt47 = (TextObject)rpt1.ReportDefinition.ReportObjects["Text47"]; //Instancie um objeto do tipo TextObject e informe o nome do textbox
                    txt47.Text = "";
                    TextObject txt48 = (TextObject)rpt1.ReportDefinition.ReportObjects["Text48"]; //Instancie um objeto do tipo TextObject e informe o nome do textbox
                    txt48.Text = "";
                    TextObject txt51 = (TextObject)rpt1.ReportDefinition.ReportObjects["Text51"]; //Instancie um objeto do tipo TextObject e informe o nome do textbox
                    txt51.Text = "";
                    TextObject txt52 = (TextObject)rpt1.ReportDefinition.ReportObjects["Text52"]; //Instancie um objeto do tipo TextObject e informe o nome do textbox
                    txt52.Text = "";

                    TextObject txt18 = (TextObject)rpt1.ReportDefinition.ReportObjects["Text18"]; //Instancie um objeto do tipo TextObject e informe o nome do textbox
                    txt18.Text = "";
                    TextObject txt49 = (TextObject)rpt1.ReportDefinition.ReportObjects["Text49"]; //Instancie um objeto do tipo TextObject e informe o nome do textbox
                    txt49.Text = "";
                    TextObject txt50 = (TextObject)rpt1.ReportDefinition.ReportObjects["Text50"]; //Instancie um objeto do tipo TextObject e informe o nome do textbox
                    txt50.Text = "";
                    TextObject txt53 = (TextObject)rpt1.ReportDefinition.ReportObjects["Text53"]; //Instancie um objeto do tipo TextObject e informe o nome do textbox
                    txt53.Text = "";
                    TextObject txt54 = (TextObject)rpt1.ReportDefinition.ReportObjects["Text54"]; //Instancie um objeto do tipo TextObject e informe o nome do textbox
                    txt54.Text = "";
                    TextObject txt55 = (TextObject)rpt1.ReportDefinition.ReportObjects["Text55"]; //Instancie um objeto do tipo TextObject e informe o nome do textbox
                    txt55.Text = "";
                    TextObject txt56 = (TextObject)rpt1.ReportDefinition.ReportObjects["Text56"]; //Instancie um objeto do tipo TextObject e informe o nome do textbox
                    txt56.Text = "";
                    TextObject txt57 = (TextObject)rpt1.ReportDefinition.ReportObjects["Text57"]; //Instancie um objeto do tipo TextObject e informe o nome do textbox
                    txt57.Text = "";
                    TextObject txt58 = (TextObject)rpt1.ReportDefinition.ReportObjects["Text58"]; //Instancie um objeto do tipo TextObject e informe o nome do textbox
                    txt58.Text = "";
                    TextObject txt59 = (TextObject)rpt1.ReportDefinition.ReportObjects["Text59"]; //Instancie um objeto do tipo TextObject e informe o nome do textbox
                    txt59.Text = "";
                    TextObject txt60 = (TextObject)rpt1.ReportDefinition.ReportObjects["Text60"]; //Instancie um objeto do tipo TextObject e informe o nome do textbox
                    txt60.Text = "";
                    TextObject txt61 = (TextObject)rpt1.ReportDefinition.ReportObjects["Text61"]; //Instancie um objeto do tipo TextObject e informe o nome do textbox
                    txt61.Text = "";
                    TextObject txt62 = (TextObject)rpt1.ReportDefinition.ReportObjects["Text62"]; //Instancie um objeto do tipo TextObject e informe o nome do textbox
                    txt62.Text = "";
                    TextObject txt63 = (TextObject)rpt1.ReportDefinition.ReportObjects["Text63"]; //Instancie um objeto do tipo TextObject e informe o nome do textbox
                    txt63.Text = "";
                    TextObject txt64 = (TextObject)rpt1.ReportDefinition.ReportObjects["Text64"]; //Instancie um objeto do tipo TextObject e informe o nome do textbox
                    txt64.Text = "";
                    TextObject txt65 = (TextObject)rpt1.ReportDefinition.ReportObjects["Text65"]; //Instancie um objeto do tipo TextObject e informe o nome do textbox
                    txt65.Text = "";
                    TextObject txt66 = (TextObject)rpt1.ReportDefinition.ReportObjects["Text66"]; //Instancie um objeto do tipo TextObject e informe o nome do textbox
                    txt66.Text = "";
                    TextObject txt67 = (TextObject)rpt1.ReportDefinition.ReportObjects["Text67"]; //Instancie um objeto do tipo TextObject e informe o nome do textbox
                    txt67.Text = "";
                    TextObject txt68 = (TextObject)rpt1.ReportDefinition.ReportObjects["Text68"]; //Instancie um objeto do tipo TextObject e informe o nome do textbox
                    txt68.Text = "";
                    TextObject txt69 = (TextObject)rpt1.ReportDefinition.ReportObjects["Text69"]; //Instancie um objeto do tipo TextObject e informe o nome do textbox
                    txt69.Text = "";
                    TextObject txt70 = (TextObject)rpt1.ReportDefinition.ReportObjects["Text70"]; //Instancie um objeto do tipo TextObject e informe o nome do textbox
                    txt70.Text = "";
                    TextObject txt71 = (TextObject)rpt1.ReportDefinition.ReportObjects["Text71"]; //Instancie um objeto do tipo TextObject e informe o nome do textbox
                    txt71.Text = "";
                    TextObject txt72 = (TextObject)rpt1.ReportDefinition.ReportObjects["Text72"]; //Instancie um objeto do tipo TextObject e informe o nome do textbox
                    txt72.Text = "";
                    TextObject txt73 = (TextObject)rpt1.ReportDefinition.ReportObjects["Text73"]; //Instancie um objeto do tipo TextObject e informe o nome do textbox
                    txt73.Text = "";
                    TextObject txt74 = (TextObject)rpt1.ReportDefinition.ReportObjects["Text74"]; //Instancie um objeto do tipo TextObject e informe o nome do textbox
                    txt74.Text = "";
                    TextObject txt75 = (TextObject)rpt1.ReportDefinition.ReportObjects["Text75"]; //Instancie um objeto do tipo TextObject e informe o nome do textbox
                    txt75.Text = "";
                    TextObject txt76 = (TextObject)rpt1.ReportDefinition.ReportObjects["Text76"]; //Instancie um objeto do tipo TextObject e informe o nome do textbox
                    txt76.Text = "";
                    TextObject txt77 = (TextObject)rpt1.ReportDefinition.ReportObjects["Text77"]; //Instancie um objeto do tipo TextObject e informe o nome do textbox
                    txt77.Text = "";

                    TextObject txt19 = (TextObject)rpt1.ReportDefinition.ReportObjects["Text19"]; //Instancie um objeto do tipo TextObject e informe o nome do textbox
                    txt19.Text = "";
                    TextObject txt78 = (TextObject)rpt1.ReportDefinition.ReportObjects["Text78"]; //Instancie um objeto do tipo TextObject e informe o nome do textbox
                    txt78.Text = "";
                    TextObject txt79 = (TextObject)rpt1.ReportDefinition.ReportObjects["Text79"]; //Instancie um objeto do tipo TextObject e informe o nome do textbox
                    txt79.Text = "";
                    TextObject txt80 = (TextObject)rpt1.ReportDefinition.ReportObjects["Text80"]; //Instancie um objeto do tipo TextObject e informe o nome do textbox
                    txt80.Text = "";
                    TextObject txt81 = (TextObject)rpt1.ReportDefinition.ReportObjects["Text81"]; //Instancie um objeto do tipo TextObject e informe o nome do textbox
                    txt81.Text = "";
                    TextObject txt82 = (TextObject)rpt1.ReportDefinition.ReportObjects["Text82"]; //Instancie um objeto do tipo TextObject e informe o nome do textbox
                    txt82.Text = "";
                    TextObject txt83 = (TextObject)rpt1.ReportDefinition.ReportObjects["Text83"]; //Instancie um objeto do tipo TextObject e informe o nome do textbox
                    txt83.Text = "";
                    TextObject txt84 = (TextObject)rpt1.ReportDefinition.ReportObjects["Text84"]; //Instancie um objeto do tipo TextObject e informe o nome do textbox
                    txt84.Text = "";
                    TextObject txt85 = (TextObject)rpt1.ReportDefinition.ReportObjects["Text85"]; //Instancie um objeto do tipo TextObject e informe o nome do textbox
                    txt85.Text = "";
                    TextObject txt86 = (TextObject)rpt1.ReportDefinition.ReportObjects["Text86"]; //Instancie um objeto do tipo TextObject e informe o nome do textbox
                    txt86.Text = "";
                    TextObject txt87 = (TextObject)rpt1.ReportDefinition.ReportObjects["Text87"]; //Instancie um objeto do tipo TextObject e informe o nome do textbox
                    txt87.Text = "";
                    TextObject txt88 = (TextObject)rpt1.ReportDefinition.ReportObjects["Text88"]; //Instancie um objeto do tipo TextObject e informe o nome do textbox
                    txt88.Text = "";
                    TextObject txt89 = (TextObject)rpt1.ReportDefinition.ReportObjects["Text89"]; //Instancie um objeto do tipo TextObject e informe o nome do textbox
                    txt89.Text = "";
                    TextObject txt90 = (TextObject)rpt1.ReportDefinition.ReportObjects["Text90"]; //Instancie um objeto do tipo TextObject e informe o nome do textbox
                    txt90.Text = "";
                    TextObject txt91 = (TextObject)rpt1.ReportDefinition.ReportObjects["Text91"]; //Instancie um objeto do tipo TextObject e informe o nome do textbox
                    txt91.Text = "";
                    TextObject txt92 = (TextObject)rpt1.ReportDefinition.ReportObjects["Text92"]; //Instancie um objeto do tipo TextObject e informe o nome do textbox
                    txt92.Text = "";
                    TextObject txt93 = (TextObject)rpt1.ReportDefinition.ReportObjects["Text93"]; //Instancie um objeto do tipo TextObject e informe o nome do textbox
                    txt93.Text = "";
                    TextObject txt94 = (TextObject)rpt1.ReportDefinition.ReportObjects["Text94"]; //Instancie um objeto do tipo TextObject e informe o nome do textbox
                    txt94.Text = "";
                    TextObject txt95 = (TextObject)rpt1.ReportDefinition.ReportObjects["Text95"]; //Instancie um objeto do tipo TextObject e informe o nome do textbox
                    txt95.Text = "";
                    TextObject txt96 = (TextObject)rpt1.ReportDefinition.ReportObjects["Text96"]; //Instancie um objeto do tipo TextObject e informe o nome do textbox
                    txt96.Text = "";
                    TextObject txt97 = (TextObject)rpt1.ReportDefinition.ReportObjects["Text97"]; //Instancie um objeto do tipo TextObject e informe o nome do textbox
                    txt97.Text = "";
                    TextObject txt98 = (TextObject)rpt1.ReportDefinition.ReportObjects["Text98"]; //Instancie um objeto do tipo TextObject e informe o nome do textbox
                    txt98.Text = "";
                    TextObject txt99 = (TextObject)rpt1.ReportDefinition.ReportObjects["Text99"]; //Instancie um objeto do tipo TextObject e informe o nome do textbox
                    txt99.Text = "";
                    TextObject txt100 = (TextObject)rpt1.ReportDefinition.ReportObjects["Text100"]; //Instancie um objeto do tipo TextObject e informe o nome do textbox
                    txt100.Text = "";
                    TextObject txt101 = (TextObject)rpt1.ReportDefinition.ReportObjects["Text101"]; //Instancie um objeto do tipo TextObject e informe o nome do textbox
                    txt101.Text = "";
                    TextObject txt102 = (TextObject)rpt1.ReportDefinition.ReportObjects["Text102"]; //Instancie um objeto do tipo TextObject e informe o nome do textbox
                    txt102.Text = "";
                    TextObject txt103 = (TextObject)rpt1.ReportDefinition.ReportObjects["Text103"]; //Instancie um objeto do tipo TextObject e informe o nome do textbox
                    txt103.Text = "";
                    TextObject txt104 = (TextObject)rpt1.ReportDefinition.ReportObjects["Text104"]; //Instancie um objeto do tipo TextObject e informe o nome do textbox
                    txt104.Text = "";

                    TextObject txt20 = (TextObject)rpt1.ReportDefinition.ReportObjects["Text20"]; //Instancie um objeto do tipo TextObject e informe o nome do textbox
                    txt20.Text = "";
                    TextObject txt105 = (TextObject)rpt1.ReportDefinition.ReportObjects["Text105"]; //Instancie um objeto do tipo TextObject e informe o nome do textbox
                    txt105.Text = "";
                    TextObject txt106 = (TextObject)rpt1.ReportDefinition.ReportObjects["Text106"]; //Instancie um objeto do tipo TextObject e informe o nome do textbox
                    txt106.Text = "";
                    TextObject txt107 = (TextObject)rpt1.ReportDefinition.ReportObjects["Text107"]; //Instancie um objeto do tipo TextObject e informe o nome do textbox
                    txt107.Text = "";
                    TextObject txt108 = (TextObject)rpt1.ReportDefinition.ReportObjects["Text108"]; //Instancie um objeto do tipo TextObject e informe o nome do textbox
                    txt108.Text = "";
                    TextObject txt109 = (TextObject)rpt1.ReportDefinition.ReportObjects["Text109"]; //Instancie um objeto do tipo TextObject e informe o nome do textbox
                    txt109.Text = "";
                    TextObject txt110_ = (TextObject)rpt1.ReportDefinition.ReportObjects["Text110"]; //Instancie um objeto do tipo TextObject e informe o nome do textbox
                    txt110_.Text = "";
                    TextObject txt111_ = (TextObject)rpt1.ReportDefinition.ReportObjects["Text111"]; //Instancie um objeto do tipo TextObject e informe o nome do textbox
                    txt111_.Text = "";
                    TextObject txt112_ = (TextObject)rpt1.ReportDefinition.ReportObjects["Text112"]; //Instancie um objeto do tipo TextObject e informe o nome do textbox
                    txt112_.Text = "";
                    TextObject txt113_ = (TextObject)rpt1.ReportDefinition.ReportObjects["Text113"]; //Instancie um objeto do tipo TextObject e informe o nome do textbox
                    txt113_.Text = "";
                    TextObject txt114_ = (TextObject)rpt1.ReportDefinition.ReportObjects["Text114"]; //Instancie um objeto do tipo TextObject e informe o nome do textbox
                    txt114_.Text = "";
                    TextObject txt115_ = (TextObject)rpt1.ReportDefinition.ReportObjects["Text115"]; //Instancie um objeto do tipo TextObject e informe o nome do textbox
                    txt115_.Text = "";
                    TextObject txt116_ = (TextObject)rpt1.ReportDefinition.ReportObjects["Text116"]; //Instancie um objeto do tipo TextObject e informe o nome do textbox
                    txt116_.Text = "";
                    TextObject txt117_ = (TextObject)rpt1.ReportDefinition.ReportObjects["Text117"]; //Instancie um objeto do tipo TextObject e informe o nome do textbox
                    txt117_.Text = "";
                    TextObject txt118_ = (TextObject)rpt1.ReportDefinition.ReportObjects["Text118"]; //Instancie um objeto do tipo TextObject e informe o nome do textbox
                    txt118_.Text = "";
                    TextObject txt119_ = (TextObject)rpt1.ReportDefinition.ReportObjects["Text119"]; //Instancie um objeto do tipo TextObject e informe o nome do textbox
                    txt119_.Text = "";
                    TextObject txt120_ = (TextObject)rpt1.ReportDefinition.ReportObjects["Text120"]; //Instancie um objeto do tipo TextObject e informe o nome do textbox
                    txt120_.Text = "";
                    TextObject txt121_ = (TextObject)rpt1.ReportDefinition.ReportObjects["Text121"]; //Instancie um objeto do tipo TextObject e informe o nome do textbox
                    txt121_.Text = "";
                    TextObject txt122_ = (TextObject)rpt1.ReportDefinition.ReportObjects["Text122"]; //Instancie um objeto do tipo TextObject e informe o nome do textbox
                    txt122_.Text = "";
                    TextObject txt123_ = (TextObject)rpt1.ReportDefinition.ReportObjects["Text123"]; //Instancie um objeto do tipo TextObject e informe o nome do textbox
                    txt123_.Text = "";
                    TextObject txt124 = (TextObject)rpt1.ReportDefinition.ReportObjects["Text124"]; //Instancie um objeto do tipo TextObject e informe o nome do textbox
                    txt124.Text = "";
                    TextObject txt125 = (TextObject)rpt1.ReportDefinition.ReportObjects["Text125"]; //Instancie um objeto do tipo TextObject e informe o nome do textbox
                    txt125.Text = "";
                    TextObject txt126 = (TextObject)rpt1.ReportDefinition.ReportObjects["Text126"]; //Instancie um objeto do tipo TextObject e informe o nome do textbox
                    txt126.Text = "";
                    TextObject txt127 = (TextObject)rpt1.ReportDefinition.ReportObjects["Text127"]; //Instancie um objeto do tipo TextObject e informe o nome do textbox
                    txt127.Text = "";
                    TextObject txt128 = (TextObject)rpt1.ReportDefinition.ReportObjects["Text128"]; //Instancie um objeto do tipo TextObject e informe o nome do textbox
                    txt128.Text = "";
                    TextObject txt129 = (TextObject)rpt1.ReportDefinition.ReportObjects["Text129"]; //Instancie um objeto do tipo TextObject e informe o nome do textbox
                    txt129.Text = "";
                    TextObject txt130 = (TextObject)rpt1.ReportDefinition.ReportObjects["Text130"]; //Instancie um objeto do tipo TextObject e informe o nome do textbox
                    txt130.Text = "";
                    TextObject txt131 = (TextObject)rpt1.ReportDefinition.ReportObjects["Text131"]; //Instancie um objeto do tipo TextObject e informe o nome do textbox
                    txt131.Text = "";


                    TextObject txt21 = (TextObject)rpt1.ReportDefinition.ReportObjects["Text21"]; //Instancie um objeto do tipo TextObject e informe o nome do textbox
                    txt21.Text = "";
                    TextObject txt132 = (TextObject)rpt1.ReportDefinition.ReportObjects["Text132"]; //Instancie um objeto do tipo TextObject e informe o nome do textbox
                    txt132.Text = "";
                    TextObject txt133 = (TextObject)rpt1.ReportDefinition.ReportObjects["Text133"]; //Instancie um objeto do tipo TextObject e informe o nome do textbox
                    txt133.Text = "";
                    TextObject txt134 = (TextObject)rpt1.ReportDefinition.ReportObjects["Text134"]; //Instancie um objeto do tipo TextObject e informe o nome do textbox
                    txt134.Text = "";
                    TextObject txt135 = (TextObject)rpt1.ReportDefinition.ReportObjects["Text135"]; //Instancie um objeto do tipo TextObject e informe o nome do textbox
                    txt135.Text = "";
                    TextObject txt136 = (TextObject)rpt1.ReportDefinition.ReportObjects["Text136"]; //Instancie um objeto do tipo TextObject e informe o nome do textbox
                    txt136.Text = "";
                    TextObject txt137 = (TextObject)rpt1.ReportDefinition.ReportObjects["Text137"]; //Instancie um objeto do tipo TextObject e informe o nome do textbox
                    txt137.Text = "";
                    TextObject txt138 = (TextObject)rpt1.ReportDefinition.ReportObjects["Text138"]; //Instancie um objeto do tipo TextObject e informe o nome do textbox
                    txt138.Text = "";
                    TextObject txt139 = (TextObject)rpt1.ReportDefinition.ReportObjects["Text139"]; //Instancie um objeto do tipo TextObject e informe o nome do textbox
                    txt139.Text = "";
                    TextObject txt140 = (TextObject)rpt1.ReportDefinition.ReportObjects["Text140"]; //Instancie um objeto do tipo TextObject e informe o nome do textbox
                    txt140.Text = "";
                    TextObject txt141 = (TextObject)rpt1.ReportDefinition.ReportObjects["Text141"]; //Instancie um objeto do tipo TextObject e informe o nome do textbox
                    txt141.Text = "";
                    TextObject txt142 = (TextObject)rpt1.ReportDefinition.ReportObjects["Text142"]; //Instancie um objeto do tipo TextObject e informe o nome do textbox
                    txt142.Text = "";
                    TextObject txt143 = (TextObject)rpt1.ReportDefinition.ReportObjects["Text143"]; //Instancie um objeto do tipo TextObject e informe o nome do textbox
                    txt143.Text = "";
                    TextObject txt144 = (TextObject)rpt1.ReportDefinition.ReportObjects["Text144"]; //Instancie um objeto do tipo TextObject e informe o nome do textbox
                    txt144.Text = "";
                    TextObject txt145 = (TextObject)rpt1.ReportDefinition.ReportObjects["Text145"]; //Instancie um objeto do tipo TextObject e informe o nome do textbox
                    txt145.Text = "";
                    TextObject txt146 = (TextObject)rpt1.ReportDefinition.ReportObjects["Text146"]; //Instancie um objeto do tipo TextObject e informe o nome do textbox
                    txt146.Text = "";
                    TextObject txt147 = (TextObject)rpt1.ReportDefinition.ReportObjects["Text147"]; //Instancie um objeto do tipo TextObject e informe o nome do textbox
                    txt147.Text = "";
                    TextObject txt148 = (TextObject)rpt1.ReportDefinition.ReportObjects["Text148"]; //Instancie um objeto do tipo TextObject e informe o nome do textbox
                    txt148.Text = "";
                    TextObject txt149 = (TextObject)rpt1.ReportDefinition.ReportObjects["Text149"]; //Instancie um objeto do tipo TextObject e informe o nome do textbox
                    txt149.Text = "";
                    TextObject txt150 = (TextObject)rpt1.ReportDefinition.ReportObjects["Text150"]; //Instancie um objeto do tipo TextObject e informe o nome do textbox
                    txt150.Text = "";
                    TextObject txt151 = (TextObject)rpt1.ReportDefinition.ReportObjects["Text151"]; //Instancie um objeto do tipo TextObject e informe o nome do textbox
                    txt151.Text = "";
                    TextObject txt152 = (TextObject)rpt1.ReportDefinition.ReportObjects["Text152"]; //Instancie um objeto do tipo TextObject e informe o nome do textbox
                    txt152.Text = "";
                    TextObject txt153 = (TextObject)rpt1.ReportDefinition.ReportObjects["Text153"]; //Instancie um objeto do tipo TextObject e informe o nome do textbox
                    txt153.Text = "";
                    TextObject txt154 = (TextObject)rpt1.ReportDefinition.ReportObjects["Text154"]; //Instancie um objeto do tipo TextObject e informe o nome do textbox
                    txt154.Text = "";
                    TextObject txt155 = (TextObject)rpt1.ReportDefinition.ReportObjects["Text155"]; //Instancie um objeto do tipo TextObject e informe o nome do textbox
                    txt155.Text = "";
                    TextObject txt156 = (TextObject)rpt1.ReportDefinition.ReportObjects["Text156"]; //Instancie um objeto do tipo TextObject e informe o nome do textbox
                    txt156.Text = "";
                    TextObject txt157 = (TextObject)rpt1.ReportDefinition.ReportObjects["Text157"]; //Instancie um objeto do tipo TextObject e informe o nome do textbox
                    txt157.Text = "";
                    TextObject txt158 = (TextObject)rpt1.ReportDefinition.ReportObjects["Text158"]; //Instancie um objeto do tipo TextObject e informe o nome do textbox
                    txt158.Text = "";

                    TextObject txt22 = (TextObject)rpt1.ReportDefinition.ReportObjects["Text22"]; //Instancie um objeto do tipo TextObject e informe o nome do textbox
                    txt22.Text = "";
                    TextObject txt159 = (TextObject)rpt1.ReportDefinition.ReportObjects["Text159"]; //Instancie um objeto do tipo TextObject e informe o nome do textbox
                    txt159.Text = "";
                    TextObject txt160 = (TextObject)rpt1.ReportDefinition.ReportObjects["Text160"]; //Instancie um objeto do tipo TextObject e informe o nome do textbox
                    txt160.Text = "";
                    TextObject txt161 = (TextObject)rpt1.ReportDefinition.ReportObjects["Text161"]; //Instancie um objeto do tipo TextObject e informe o nome do textbox
                    txt161.Text = "";
                    TextObject txt162 = (TextObject)rpt1.ReportDefinition.ReportObjects["Text162"]; //Instancie um objeto do tipo TextObject e informe o nome do textbox
                    txt162.Text = "";
                    TextObject txt163 = (TextObject)rpt1.ReportDefinition.ReportObjects["Text163"]; //Instancie um objeto do tipo TextObject e informe o nome do textbox
                    txt163.Text = "";
                    TextObject txt164 = (TextObject)rpt1.ReportDefinition.ReportObjects["Text164"]; //Instancie um objeto do tipo TextObject e informe o nome do textbox
                    txt164.Text = "";
                    TextObject txt165 = (TextObject)rpt1.ReportDefinition.ReportObjects["Text165"]; //Instancie um objeto do tipo TextObject e informe o nome do textbox
                    txt165.Text = "";
                    TextObject txt166 = (TextObject)rpt1.ReportDefinition.ReportObjects["Text166"]; //Instancie um objeto do tipo TextObject e informe o nome do textbox
                    txt166.Text = "";
                    TextObject txt167 = (TextObject)rpt1.ReportDefinition.ReportObjects["Text167"]; //Instancie um objeto do tipo TextObject e informe o nome do textbox
                    txt167.Text = "";
                    TextObject txt168 = (TextObject)rpt1.ReportDefinition.ReportObjects["Text168"]; //Instancie um objeto do tipo TextObject e informe o nome do textbox
                    txt168.Text = "";
                    TextObject txt169 = (TextObject)rpt1.ReportDefinition.ReportObjects["Text169"]; //Instancie um objeto do tipo TextObject e informe o nome do textbox
                    txt169.Text = "";
                    TextObject txt170 = (TextObject)rpt1.ReportDefinition.ReportObjects["Text170"]; //Instancie um objeto do tipo TextObject e informe o nome do textbox
                    txt170.Text = "";
                    TextObject txt171 = (TextObject)rpt1.ReportDefinition.ReportObjects["Text171"]; //Instancie um objeto do tipo TextObject e informe o nome do textbox
                    txt171.Text = "";
                    TextObject txt172 = (TextObject)rpt1.ReportDefinition.ReportObjects["Text172"]; //Instancie um objeto do tipo TextObject e informe o nome do textbox
                    txt172.Text = "";
                    TextObject txt173 = (TextObject)rpt1.ReportDefinition.ReportObjects["Text173"]; //Instancie um objeto do tipo TextObject e informe o nome do textbox
                    txt173.Text = "";
                    TextObject txt174 = (TextObject)rpt1.ReportDefinition.ReportObjects["Text174"]; //Instancie um objeto do tipo TextObject e informe o nome do textbox
                    txt174.Text = "";
                    TextObject txt175 = (TextObject)rpt1.ReportDefinition.ReportObjects["Text175"]; //Instancie um objeto do tipo TextObject e informe o nome do textbox
                    txt175.Text = "";
                    TextObject txt176_ = (TextObject)rpt1.ReportDefinition.ReportObjects["Text176"]; //Instancie um objeto do tipo TextObject e informe o nome do textbox
                    txt176_.Text = "";
                    TextObject txt177_ = (TextObject)rpt1.ReportDefinition.ReportObjects["Text177"]; //Instancie um objeto do tipo TextObject e informe o nome do textbox
                    txt177_.Text = "";
                    TextObject txt178_ = (TextObject)rpt1.ReportDefinition.ReportObjects["Text178"]; //Instancie um objeto do tipo TextObject e informe o nome do textbox
                    txt178_.Text = "";
                    TextObject txt179_ = (TextObject)rpt1.ReportDefinition.ReportObjects["Text179"]; //Instancie um objeto do tipo TextObject e informe o nome do textbox
                    txt179_.Text = "";
                    TextObject txt180_ = (TextObject)rpt1.ReportDefinition.ReportObjects["Text180"]; //Instancie um objeto do tipo TextObject e informe o nome do textbox
                    txt180_.Text = "";
                    TextObject txt181_ = (TextObject)rpt1.ReportDefinition.ReportObjects["Text181"]; //Instancie um objeto do tipo TextObject e informe o nome do textbox
                    txt181_.Text = "";
                    TextObject txt182_ = (TextObject)rpt1.ReportDefinition.ReportObjects["Text182"]; //Instancie um objeto do tipo TextObject e informe o nome do textbox
                    txt182_.Text = "";
                    TextObject txt183_ = (TextObject)rpt1.ReportDefinition.ReportObjects["Text183"]; //Instancie um objeto do tipo TextObject e informe o nome do textbox
                    txt183_.Text = "";
                    TextObject txt184_ = (TextObject)rpt1.ReportDefinition.ReportObjects["Text184"]; //Instancie um objeto do tipo TextObject e informe o nome do textbox
                    txt184_.Text = "";
                    TextObject txt185_ = (TextObject)rpt1.ReportDefinition.ReportObjects["Text185"]; //Instancie um objeto do tipo TextObject e informe o nome do textbox
                    txt185_.Text = "";

                    TextObject txt23 = (TextObject)rpt1.ReportDefinition.ReportObjects["Text23"]; //Instancie um objeto do tipo TextObject e informe o nome do textbox
                    txt23.Text = "";
                    TextObject txt186_ = (TextObject)rpt1.ReportDefinition.ReportObjects["Text186"]; //Instancie um objeto do tipo TextObject e informe o nome do textbox
                    txt186_.Text = "";
                    TextObject txt187_ = (TextObject)rpt1.ReportDefinition.ReportObjects["Text187"]; //Instancie um objeto do tipo TextObject e informe o nome do textbox
                    txt187_.Text = "";
                    TextObject txt188_ = (TextObject)rpt1.ReportDefinition.ReportObjects["Text188"]; //Instancie um objeto do tipo TextObject e informe o nome do textbox
                    txt188_.Text = "";
                    TextObject txt189_ = (TextObject)rpt1.ReportDefinition.ReportObjects["Text189"]; //Instancie um objeto do tipo TextObject e informe o nome do textbox
                    txt189_.Text = "";
                    TextObject txt190 = (TextObject)rpt1.ReportDefinition.ReportObjects["Text190"]; //Instancie um objeto do tipo TextObject e informe o nome do textbox
                    txt190.Text = "";
                    TextObject txt191 = (TextObject)rpt1.ReportDefinition.ReportObjects["Text191"]; //Instancie um objeto do tipo TextObject e informe o nome do textbox
                    txt191.Text = "";
                    TextObject txt192 = (TextObject)rpt1.ReportDefinition.ReportObjects["Text192"]; //Instancie um objeto do tipo TextObject e informe o nome do textbox
                    txt192.Text = "";
                    TextObject txt193 = (TextObject)rpt1.ReportDefinition.ReportObjects["Text193"]; //Instancie um objeto do tipo TextObject e informe o nome do textbox
                    txt193.Text = "";
                    TextObject txt194 = (TextObject)rpt1.ReportDefinition.ReportObjects["Text194"]; //Instancie um objeto do tipo TextObject e informe o nome do textbox
                    txt194.Text = "";
                    TextObject txt195 = (TextObject)rpt1.ReportDefinition.ReportObjects["Text195"]; //Instancie um objeto do tipo TextObject e informe o nome do textbox
                    txt195.Text = "";
                    TextObject txt196 = (TextObject)rpt1.ReportDefinition.ReportObjects["Text196"]; //Instancie um objeto do tipo TextObject e informe o nome do textbox
                    txt196.Text = "";
                    TextObject txt197 = (TextObject)rpt1.ReportDefinition.ReportObjects["Text197"]; //Instancie um objeto do tipo TextObject e informe o nome do textbox
                    txt197.Text = "";
                    TextObject txt198 = (TextObject)rpt1.ReportDefinition.ReportObjects["Text198"]; //Instancie um objeto do tipo TextObject e informe o nome do textbox
                    txt198.Text = "";
                    TextObject txt199 = (TextObject)rpt1.ReportDefinition.ReportObjects["Text199"]; //Instancie um objeto do tipo TextObject e informe o nome do textbox
                    txt199.Text = "";
                    TextObject txt200 = (TextObject)rpt1.ReportDefinition.ReportObjects["Text200"]; //Instancie um objeto do tipo TextObject e informe o nome do textbox
                    txt200.Text = "";
                    TextObject txt201 = (TextObject)rpt1.ReportDefinition.ReportObjects["Text201"]; //Instancie um objeto do tipo TextObject e informe o nome do textbox
                    txt201.Text = "";
                    TextObject txt202 = (TextObject)rpt1.ReportDefinition.ReportObjects["Text202"]; //Instancie um objeto do tipo TextObject e informe o nome do textbox
                    txt202.Text = "";
                    TextObject txt203 = (TextObject)rpt1.ReportDefinition.ReportObjects["Text203"]; //Instancie um objeto do tipo TextObject e informe o nome do textbox
                    txt203.Text = "";
                    TextObject txt204 = (TextObject)rpt1.ReportDefinition.ReportObjects["Text204"]; //Instancie um objeto do tipo TextObject e informe o nome do textbox
                    txt204.Text = "";
                    TextObject txt205 = (TextObject)rpt1.ReportDefinition.ReportObjects["Text205"]; //Instancie um objeto do tipo TextObject e informe o nome do textbox
                    txt205.Text = "";
                    TextObject txt206 = (TextObject)rpt1.ReportDefinition.ReportObjects["Text206"]; //Instancie um objeto do tipo TextObject e informe o nome do textbox
                    txt206.Text = "";
                    TextObject txt207 = (TextObject)rpt1.ReportDefinition.ReportObjects["Text207"]; //Instancie um objeto do tipo TextObject e informe o nome do textbox
                    txt207.Text = "";
                    TextObject txt208 = (TextObject)rpt1.ReportDefinition.ReportObjects["Text208"]; //Instancie um objeto do tipo TextObject e informe o nome do textbox
                    txt208.Text = "";
                    TextObject txt209_ = (TextObject)rpt1.ReportDefinition.ReportObjects["Text209"]; //Instancie um objeto do tipo TextObject e informe o nome do textbox
                    txt209_.Text = "";
                    TextObject txt210_ = (TextObject)rpt1.ReportDefinition.ReportObjects["Text210"]; //Instancie um objeto do tipo TextObject e informe o nome do textbox
                    txt210_.Text = "";
                    TextObject txt211_ = (TextObject)rpt1.ReportDefinition.ReportObjects["Text211"]; //Instancie um objeto do tipo TextObject e informe o nome do textbox
                    txt211_.Text = "";
                    TextObject txt212_ = (TextObject)rpt1.ReportDefinition.ReportObjects["Text212"]; //Instancie um objeto do tipo TextObject e informe o nome do textbox
                    txt212_.Text = "";

                    TextObject txt24 = (TextObject)rpt1.ReportDefinition.ReportObjects["Text24"]; //Instancie um objeto do tipo TextObject e informe o nome do textbox
                    txt24.Text = "";
                    TextObject txt213_ = (TextObject)rpt1.ReportDefinition.ReportObjects["Text213"]; //Instancie um objeto do tipo TextObject e informe o nome do textbox
                    txt213_.Text = "";
                    TextObject txt214_ = (TextObject)rpt1.ReportDefinition.ReportObjects["Text214"]; //Instancie um objeto do tipo TextObject e informe o nome do textbox
                    txt214_.Text = "";
                    TextObject txt215_ = (TextObject)rpt1.ReportDefinition.ReportObjects["Text215"]; //Instancie um objeto do tipo TextObject e informe o nome do textbox
                    txt215_.Text = "";
                    TextObject txt216_ = (TextObject)rpt1.ReportDefinition.ReportObjects["Text216"]; //Instancie um objeto do tipo TextObject e informe o nome do textbox
                    txt216_.Text = "";
                    TextObject txt217_ = (TextObject)rpt1.ReportDefinition.ReportObjects["Text217"]; //Instancie um objeto do tipo TextObject e informe o nome do textbox
                    txt217_.Text = "";
                    TextObject txt218_ = (TextObject)rpt1.ReportDefinition.ReportObjects["Text218"]; //Instancie um objeto do tipo TextObject e informe o nome do textbox
                    txt218_.Text = "";
                    TextObject txt219_ = (TextObject)rpt1.ReportDefinition.ReportObjects["Text219"]; //Instancie um objeto do tipo TextObject e informe o nome do textbox
                    txt219_.Text = "";
                    TextObject txt220_ = (TextObject)rpt1.ReportDefinition.ReportObjects["Text220"]; //Instancie um objeto do tipo TextObject e informe o nome do textbox
                    txt220_.Text = "";
                    TextObject txt221_ = (TextObject)rpt1.ReportDefinition.ReportObjects["Text221"]; //Instancie um objeto do tipo TextObject e informe o nome do textbox
                    txt221_.Text = "";
                    TextObject txt222_ = (TextObject)rpt1.ReportDefinition.ReportObjects["Text222"]; //Instancie um objeto do tipo TextObject e informe o nome do textbox
                    txt222_.Text = "";
                    TextObject txt223 = (TextObject)rpt1.ReportDefinition.ReportObjects["Text223"]; //Instancie um objeto do tipo TextObject e informe o nome do textbox
                    txt223.Text = "";
                    TextObject txt224 = (TextObject)rpt1.ReportDefinition.ReportObjects["Text224"]; //Instancie um objeto do tipo TextObject e informe o nome do textbox
                    txt224.Text = "";
                    TextObject txt225 = (TextObject)rpt1.ReportDefinition.ReportObjects["Text225"]; //Instancie um objeto do tipo TextObject e informe o nome do textbox
                    txt225.Text = "";
                    TextObject txt226 = (TextObject)rpt1.ReportDefinition.ReportObjects["Text226"]; //Instancie um objeto do tipo TextObject e informe o nome do textbox
                    txt226.Text = "";
                    TextObject txt227 = (TextObject)rpt1.ReportDefinition.ReportObjects["Text227"]; //Instancie um objeto do tipo TextObject e informe o nome do textbox
                    txt227.Text = "";
                    TextObject txt228 = (TextObject)rpt1.ReportDefinition.ReportObjects["Text228"]; //Instancie um objeto do tipo TextObject e informe o nome do textbox
                    txt228.Text = "";
                    TextObject txt229 = (TextObject)rpt1.ReportDefinition.ReportObjects["Text229"]; //Instancie um objeto do tipo TextObject e informe o nome do textbox
                    txt229.Text = "";
                    TextObject txt230 = (TextObject)rpt1.ReportDefinition.ReportObjects["Text230"]; //Instancie um objeto do tipo TextObject e informe o nome do textbox
                    txt230.Text = "";
                    TextObject txt231 = (TextObject)rpt1.ReportDefinition.ReportObjects["Text231"]; //Instancie um objeto do tipo TextObject e informe o nome do textbox
                    txt231.Text = "";
                    TextObject txt232 = (TextObject)rpt1.ReportDefinition.ReportObjects["Text232"]; //Instancie um objeto do tipo TextObject e informe o nome do textbox
                    txt232.Text = "";
                    TextObject txt233 = (TextObject)rpt1.ReportDefinition.ReportObjects["Text233"]; //Instancie um objeto do tipo TextObject e informe o nome do textbox
                    txt233.Text = "";
                    TextObject txt234 = (TextObject)rpt1.ReportDefinition.ReportObjects["Text234"]; //Instancie um objeto do tipo TextObject e informe o nome do textbox
                    txt234.Text = "";
                    TextObject txt235 = (TextObject)rpt1.ReportDefinition.ReportObjects["Text235"]; //Instancie um objeto do tipo TextObject e informe o nome do textbox
                    txt235.Text = "";
                    TextObject txt236 = (TextObject)rpt1.ReportDefinition.ReportObjects["Text236"]; //Instancie um objeto do tipo TextObject e informe o nome do textbox
                    txt236.Text = "";
                    TextObject txt237 = (TextObject)rpt1.ReportDefinition.ReportObjects["Text237"]; //Instancie um objeto do tipo TextObject e informe o nome do textbox
                    txt237.Text = "";
                    TextObject txt238 = (TextObject)rpt1.ReportDefinition.ReportObjects["Text238"]; //Instancie um objeto do tipo TextObject e informe o nome do textbox
                    txt238.Text = "";
                    TextObject txt239 = (TextObject)rpt1.ReportDefinition.ReportObjects["Text239"]; //Instancie um objeto do tipo TextObject e informe o nome do textbox
                    txt239.Text = "";

                    TextObject txt25 = (TextObject)rpt1.ReportDefinition.ReportObjects["Text25"]; //Instancie um objeto do tipo TextObject e informe o nome do textbox
                    txt25.Text = "";
                    TextObject txt240 = (TextObject)rpt1.ReportDefinition.ReportObjects["Text240"]; //Instancie um objeto do tipo TextObject e informe o nome do textbox
                    txt240.Text = "";
                    TextObject txt241 = (TextObject)rpt1.ReportDefinition.ReportObjects["Text241"]; //Instancie um objeto do tipo TextObject e informe o nome do textbox
                    txt241.Text = "";
                    TextObject txt242_ = (TextObject)rpt1.ReportDefinition.ReportObjects["Text242"]; //Instancie um objeto do tipo TextObject e informe o nome do textbox
                    txt242_.Text = "";
                    TextObject txt243_ = (TextObject)rpt1.ReportDefinition.ReportObjects["Text243"]; //Instancie um objeto do tipo TextObject e informe o nome do textbox
                    txt243_.Text = "";
                    TextObject txt244_ = (TextObject)rpt1.ReportDefinition.ReportObjects["Text244"]; //Instancie um objeto do tipo TextObject e informe o nome do textbox
                    txt244_.Text = "";
                    TextObject txt245_ = (TextObject)rpt1.ReportDefinition.ReportObjects["Text245"]; //Instancie um objeto do tipo TextObject e informe o nome do textbox
                    txt245_.Text = "";
                    TextObject txt246_ = (TextObject)rpt1.ReportDefinition.ReportObjects["Text246"]; //Instancie um objeto do tipo TextObject e informe o nome do textbox
                    txt246_.Text = "";
                    TextObject txt247_ = (TextObject)rpt1.ReportDefinition.ReportObjects["Text247"]; //Instancie um objeto do tipo TextObject e informe o nome do textbox
                    txt247_.Text = "";
                    TextObject txt248_ = (TextObject)rpt1.ReportDefinition.ReportObjects["Text248"]; //Instancie um objeto do tipo TextObject e informe o nome do textbox
                    txt248_.Text = "";
                    TextObject txt249_ = (TextObject)rpt1.ReportDefinition.ReportObjects["Text249"]; //Instancie um objeto do tipo TextObject e informe o nome do textbox
                    txt249_.Text = "";
                    TextObject txt250_ = (TextObject)rpt1.ReportDefinition.ReportObjects["Text250"]; //Instancie um objeto do tipo TextObject e informe o nome do textbox
                    txt250_.Text = "";
                    TextObject txt251_ = (TextObject)rpt1.ReportDefinition.ReportObjects["Text251"]; //Instancie um objeto do tipo TextObject e informe o nome do textbox
                    txt251_.Text = "";
                    TextObject txt252_ = (TextObject)rpt1.ReportDefinition.ReportObjects["Text252"]; //Instancie um objeto do tipo TextObject e informe o nome do textbox
                    txt252_.Text = "";
                    TextObject txt253_ = (TextObject)rpt1.ReportDefinition.ReportObjects["Text253"]; //Instancie um objeto do tipo TextObject e informe o nome do textbox
                    txt253_.Text = "";
                    TextObject txt254_ = (TextObject)rpt1.ReportDefinition.ReportObjects["Text254"]; //Instancie um objeto do tipo TextObject e informe o nome do textbox
                    txt254_.Text = "";
                    TextObject txt255_ = (TextObject)rpt1.ReportDefinition.ReportObjects["Text255"]; //Instancie um objeto do tipo TextObject e informe o nome do textbox
                    txt255_.Text = "";
                    TextObject txt256_ = (TextObject)rpt1.ReportDefinition.ReportObjects["Text256"]; //Instancie um objeto do tipo TextObject e informe o nome do textbox
                    txt256_.Text = "";
                    TextObject txt257_ = (TextObject)rpt1.ReportDefinition.ReportObjects["Text257"]; //Instancie um objeto do tipo TextObject e informe o nome do textbox
                    txt257_.Text = "";
                    TextObject txt258_ = (TextObject)rpt1.ReportDefinition.ReportObjects["Text258"]; //Instancie um objeto do tipo TextObject e informe o nome do textbox
                    txt258_.Text = "";
                    TextObject txt259_ = (TextObject)rpt1.ReportDefinition.ReportObjects["Text259"]; //Instancie um objeto do tipo TextObject e informe o nome do textbox
                    txt259_.Text = "";
                    TextObject txt260 = (TextObject)rpt1.ReportDefinition.ReportObjects["Text260"]; //Instancie um objeto do tipo TextObject e informe o nome do textbox
                    txt260.Text = "";
                    TextObject txt261 = (TextObject)rpt1.ReportDefinition.ReportObjects["Text261"]; //Instancie um objeto do tipo TextObject e informe o nome do textbox
                    txt261.Text = "";
                    TextObject txt262 = (TextObject)rpt1.ReportDefinition.ReportObjects["Text262"]; //Instancie um objeto do tipo TextObject e informe o nome do textbox
                    txt262.Text = "";
                    TextObject txt263 = (TextObject)rpt1.ReportDefinition.ReportObjects["Text263"]; //Instancie um objeto do tipo TextObject e informe o nome do textbox
                    txt263.Text = "";
                    TextObject txt264 = (TextObject)rpt1.ReportDefinition.ReportObjects["Text264"]; //Instancie um objeto do tipo TextObject e informe o nome do textbox
                    txt264.Text = "";
                    TextObject txt265 = (TextObject)rpt1.ReportDefinition.ReportObjects["Text265"]; //Instancie um objeto do tipo TextObject e informe o nome do textbox
                    txt265.Text = "";
                    TextObject txt266 = (TextObject)rpt1.ReportDefinition.ReportObjects["Text266"]; //Instancie um objeto do tipo TextObject e informe o nome do textbox
                    txt266.Text = "";


                    TextObject txt26 = (TextObject)rpt1.ReportDefinition.ReportObjects["Text26"]; //Instancie um objeto do tipo TextObject e informe o nome do textbox
                    txt26.Text = "0";
                    TextObject txt267 = (TextObject)rpt1.ReportDefinition.ReportObjects["Text267"]; //Instancie um objeto do tipo TextObject e informe o nome do textbox
                    txt267.Text = "0";
                    TextObject txt268 = (TextObject)rpt1.ReportDefinition.ReportObjects["Text268"]; //Instancie um objeto do tipo TextObject e informe o nome do textbox
                    txt268.Text = "0";
                    TextObject txt269 = (TextObject)rpt1.ReportDefinition.ReportObjects["Text269"]; //Instancie um objeto do tipo TextObject e informe o nome do textbox
                    txt269.Text = "0";
                    TextObject txt270 = (TextObject)rpt1.ReportDefinition.ReportObjects["Text270"]; //Instancie um objeto do tipo TextObject e informe o nome do textbox
                    txt270.Text = "0";
                    TextObject txt271 = (TextObject)rpt1.ReportDefinition.ReportObjects["Text271"]; //Instancie um objeto do tipo TextObject e informe o nome do textbox
                    txt271.Text = "0";
                    TextObject txt272 = (TextObject)rpt1.ReportDefinition.ReportObjects["Text272"]; //Instancie um objeto do tipo TextObject e informe o nome do textbox
                    txt272.Text = "0";
                    TextObject txt273 = (TextObject)rpt1.ReportDefinition.ReportObjects["Text273"]; //Instancie um objeto do tipo TextObject e informe o nome do textbox
                    txt273.Text = "0";
                    TextObject txt274 = (TextObject)rpt1.ReportDefinition.ReportObjects["Text274"]; //Instancie um objeto do tipo TextObject e informe o nome do textbox
                    txt274.Text = "0";
                    TextObject txt275 = (TextObject)rpt1.ReportDefinition.ReportObjects["Text275"]; //Instancie um objeto do tipo TextObject e informe o nome do textbox
                    txt275.Text = "0";
                    TextObject txt276 = (TextObject)rpt1.ReportDefinition.ReportObjects["Text276"]; //Instancie um objeto do tipo TextObject e informe o nome do textbox
                    txt276.Text = "0";
                    TextObject txt277 = (TextObject)rpt1.ReportDefinition.ReportObjects["Text277"]; //Instancie um objeto do tipo TextObject e informe o nome do textbox
                    txt277.Text = "0";
                    TextObject txt278 = (TextObject)rpt1.ReportDefinition.ReportObjects["Text278"]; //Instancie um objeto do tipo TextObject e informe o nome do textbox
                    txt278.Text = "0";
                    TextObject txt279 = (TextObject)rpt1.ReportDefinition.ReportObjects["Text279"]; //Instancie um objeto do tipo TextObject e informe o nome do textbox
                    txt279.Text = "0";
                    TextObject txt280 = (TextObject)rpt1.ReportDefinition.ReportObjects["Text280"]; //Instancie um objeto do tipo TextObject e informe o nome do textbox
                    txt280.Text = "0";
                    TextObject txt281 = (TextObject)rpt1.ReportDefinition.ReportObjects["Text281"]; //Instancie um objeto do tipo TextObject e informe o nome do textbox
                    txt281.Text = "0";
                    TextObject txt282 = (TextObject)rpt1.ReportDefinition.ReportObjects["Text282"]; //Instancie um objeto do tipo TextObject e informe o nome do textbox
                    txt282.Text = "0";
                    TextObject txt283 = (TextObject)rpt1.ReportDefinition.ReportObjects["Text283"]; //Instancie um objeto do tipo TextObject e informe o nome do textbox
                    txt283.Text = "0";
                    TextObject txt284 = (TextObject)rpt1.ReportDefinition.ReportObjects["Text284"]; //Instancie um objeto do tipo TextObject e informe o nome do textbox
                    txt284.Text = "0";
                    TextObject txt285 = (TextObject)rpt1.ReportDefinition.ReportObjects["Text285"]; //Instancie um objeto do tipo TextObject e informe o nome do textbox
                    txt285.Text = "0";
                    TextObject txt286 = (TextObject)rpt1.ReportDefinition.ReportObjects["Text286"]; //Instancie um objeto do tipo TextObject e informe o nome do textbox
                    txt286.Text = "0";
                    TextObject txt287 = (TextObject)rpt1.ReportDefinition.ReportObjects["Text287"]; //Instancie um objeto do tipo TextObject e informe o nome do textbox
                    txt287.Text = "0";
                    TextObject txt288 = (TextObject)rpt1.ReportDefinition.ReportObjects["Text288"]; //Instancie um objeto do tipo TextObject e informe o nome do textbox
                    txt288.Text = "0";
                    TextObject txt289 = (TextObject)rpt1.ReportDefinition.ReportObjects["Text289"]; //Instancie um objeto do tipo TextObject e informe o nome do textbox
                    txt289.Text = "0";
                    TextObject txt290 = (TextObject)rpt1.ReportDefinition.ReportObjects["Text290"]; //Instancie um objeto do tipo TextObject e informe o nome do textbox
                    txt290.Text = "0";
                    TextObject txt291 = (TextObject)rpt1.ReportDefinition.ReportObjects["Text291"]; //Instancie um objeto do tipo TextObject e informe o nome do textbox
                    txt291.Text = "0";
                    TextObject txt292 = (TextObject)rpt1.ReportDefinition.ReportObjects["Text292"]; //Instancie um objeto do tipo TextObject e informe o nome do textbox
                    txt292.Text = "0";
                    TextObject txt293 = (TextObject)rpt1.ReportDefinition.ReportObjects["Text293"]; //Instancie um objeto do tipo TextObject e informe o nome do textbox
                    txt293.Text = "0";



                    DataTable mes = DAL.Lista_Mes_Atual();
                    DataTable relat = null;
                    if (mes.Rows.Count > 0)
                    {
                        relat = DAL.Lista_Relatorio3(mes.Rows[0]["Atual"].ToString());
                    }
                    bool imprime = true;
                    int qtde = relat.Rows.Count;
                    int q = 0;
                    while (imprime == true)
                    {

                        //nome

                        if (qtde >= 28)
                        {
                            txt42.Text = relat.Rows[q]["Nome"].ToString();

                            txt43.Text = relat.Rows[q + 1]["Nome"].ToString();
                            txt44.Text = relat.Rows[q + 2]["Nome"].ToString();
                            txt1.Text = relat.Rows[q + 3]["Nome"].ToString();
                            txt4.Text = relat.Rows[q + 4]["Nome"].ToString();
                            txt14.Text = relat.Rows[q + 5]["Nome"].ToString();
                            txt17.Text = relat.Rows[q + 6]["Nome"].ToString();
                            txt27.Text = relat.Rows[q + 7]["Nome"].ToString();
                            txt28.Text = relat.Rows[q + 8]["Nome"].ToString();
                            txt29.Text = relat.Rows[q + 9]["Nome"].ToString();
                            txt30.Text = relat.Rows[q + 10]["Nome"].ToString();
                            txt31.Text = relat.Rows[q + 11]["Nome"].ToString();
                            txt32.Text = relat.Rows[q + 12]["Nome"].ToString();
                            txt33.Text = relat.Rows[q + 13]["Nome"].ToString();
                            txt34.Text = relat.Rows[q + 14]["Nome"].ToString();
                            txt35.Text = relat.Rows[q + 15]["Nome"].ToString();
                            txt36.Text = relat.Rows[q + 16]["Nome"].ToString();
                            txt37.Text = relat.Rows[q + 17]["Nome"].ToString();
                            txt38.Text = relat.Rows[q + 18]["Nome"].ToString();
                            txt39.Text = relat.Rows[q + 19]["Nome"].ToString();
                            txt40.Text = relat.Rows[q + 20]["Nome"].ToString();
                            txt41.Text = relat.Rows[q + 21]["Nome"].ToString();
                            txt45.Text = relat.Rows[q + 22]["Nome"].ToString();
                            txt46.Text = relat.Rows[q + 23]["Nome"].ToString();
                            txt47.Text = relat.Rows[q + 24]["Nome"].ToString();
                            txt48.Text = relat.Rows[q + 25]["Nome"].ToString();
                            txt51.Text = relat.Rows[q + 26]["Nome"].ToString();
                            txt52.Text = relat.Rows[q + 27]["Nome"].ToString();

                            //Anterior
                            txt18.Text = relat.Rows[q]["Anterior"].ToString();
                            txt49.Text = relat.Rows[q + 1]["Anterior"].ToString();
                            txt50.Text = relat.Rows[q + 2]["Anterior"].ToString();
                            txt53.Text = relat.Rows[q + 3]["Anterior"].ToString();
                            txt54.Text = relat.Rows[q + 4]["Anterior"].ToString();
                            txt55.Text = relat.Rows[q + 5]["Anterior"].ToString();
                            txt56.Text = relat.Rows[q + 6]["Anterior"].ToString();
                            txt57.Text = relat.Rows[q + 7]["Anterior"].ToString();
                            txt58.Text = relat.Rows[q + 8]["Anterior"].ToString();
                            txt59.Text = relat.Rows[q + 9]["Anterior"].ToString();
                            txt60.Text = relat.Rows[q + 10]["Anterior"].ToString();
                            txt61.Text = relat.Rows[q + 11]["Anterior"].ToString();
                            txt62.Text = relat.Rows[q + 12]["Anterior"].ToString();
                            txt63.Text = relat.Rows[q + 13]["Anterior"].ToString();
                            txt64.Text = relat.Rows[q + 14]["Anterior"].ToString();
                            txt65.Text = relat.Rows[q + 15]["Anterior"].ToString();
                            txt66.Text = relat.Rows[q + 16]["Anterior"].ToString();
                            txt67.Text = relat.Rows[q + 17]["Anterior"].ToString();
                            txt68.Text = relat.Rows[q + 18]["Anterior"].ToString();
                            txt69.Text = relat.Rows[q + 19]["Anterior"].ToString();
                            txt70.Text = relat.Rows[q + 20]["Anterior"].ToString();
                            txt71.Text = relat.Rows[q + 21]["Anterior"].ToString();
                            txt72.Text = relat.Rows[q + 22]["Anterior"].ToString();
                            txt73.Text = relat.Rows[q + 23]["Anterior"].ToString();
                            txt74.Text = relat.Rows[q + 24]["Anterior"].ToString();
                            txt75.Text = relat.Rows[q + 25]["Anterior"].ToString();
                            txt76.Text = relat.Rows[q + 26]["Anterior"].ToString();
                            txt77.Text = relat.Rows[q + 27]["Anterior"].ToString();

                            //atual
                            txt19.Text = relat.Rows[q]["Atual"].ToString();
                            txt78.Text = relat.Rows[q + 1]["Atual"].ToString();
                            txt79.Text = relat.Rows[q + 2]["Atual"].ToString();
                            txt80.Text = relat.Rows[q + 3]["Atual"].ToString();
                            txt81.Text = relat.Rows[q + 4]["Atual"].ToString();
                            txt82.Text = relat.Rows[q + 5]["Atual"].ToString();
                            txt83.Text = relat.Rows[q + 6]["Atual"].ToString();
                            txt84.Text = relat.Rows[q + 7]["Atual"].ToString();
                            txt85.Text = relat.Rows[q + 8]["Atual"].ToString();
                            txt86.Text = relat.Rows[q + 9]["Atual"].ToString();
                            txt87.Text = relat.Rows[q + 10]["Atual"].ToString();
                            txt88.Text = relat.Rows[q + 11]["Atual"].ToString();
                            txt89.Text = relat.Rows[q + 12]["Atual"].ToString();
                            txt90.Text = relat.Rows[q + 13]["Atual"].ToString();
                            txt91.Text = relat.Rows[q + 14]["Atual"].ToString();
                            txt92.Text = relat.Rows[q + 15]["Atual"].ToString();
                            txt93.Text = relat.Rows[q + 16]["Atual"].ToString();
                            txt94.Text = relat.Rows[q + 17]["Atual"].ToString();
                            txt95.Text = relat.Rows[q + 18]["Atual"].ToString();
                            txt96.Text = relat.Rows[q + 19]["Atual"].ToString();
                            txt97.Text = relat.Rows[q + 20]["Atual"].ToString();
                            txt98.Text = relat.Rows[q + 21]["Atual"].ToString();
                            txt99.Text = relat.Rows[q + 22]["Atual"].ToString();
                            txt100.Text = relat.Rows[q + 23]["Atual"].ToString();
                            txt101.Text = relat.Rows[q + 24]["Atual"].ToString();
                            txt102.Text = relat.Rows[q + 25]["Atual"].ToString();
                            txt103.Text = relat.Rows[q + 26]["Atual"].ToString();
                            txt104.Text = relat.Rows[q + 27]["Atual"].ToString();

                            //consumo
                            txt20.Text = relat.Rows[q]["Cons"].ToString();
                            txt105.Text = relat.Rows[q + 1]["Cons"].ToString();
                            txt106.Text = relat.Rows[q + 2]["Cons"].ToString();
                            txt107.Text = relat.Rows[q + 3]["Cons"].ToString();
                            txt108.Text = relat.Rows[q + 4]["Cons"].ToString();
                            txt109.Text = relat.Rows[q + 5]["Cons"].ToString();
                            txt110_.Text = relat.Rows[q + 6]["Cons"].ToString();
                            txt111_.Text = relat.Rows[q + 7]["Cons"].ToString();
                            txt112_.Text = relat.Rows[q + 8]["Cons"].ToString();
                            txt113_.Text = relat.Rows[q + 9]["Cons"].ToString();
                            txt114_.Text = relat.Rows[q + 10]["Cons"].ToString();
                            txt115_.Text = relat.Rows[q + 11]["Cons"].ToString();
                            txt116_.Text = relat.Rows[q + 12]["Cons"].ToString();
                            txt117_.Text = relat.Rows[q + 13]["Cons"].ToString();
                            txt118_.Text = relat.Rows[q + 14]["Cons"].ToString();
                            txt119_.Text = relat.Rows[q + 15]["Cons"].ToString();
                            txt120_.Text = relat.Rows[q + 16]["Cons"].ToString();
                            txt121_.Text = relat.Rows[q + 17]["Cons"].ToString();
                            txt122_.Text = relat.Rows[q + 18]["Cons"].ToString();
                            txt123_.Text = relat.Rows[q + 19]["Cons"].ToString();
                            txt124.Text = relat.Rows[q + 20]["Cons"].ToString();
                            txt125.Text = relat.Rows[q + 21]["Cons"].ToString();
                            txt126.Text = relat.Rows[q + 22]["Cons"].ToString();
                            txt127.Text = relat.Rows[q + 23]["Cons"].ToString();
                            txt128.Text = relat.Rows[q + 24]["Cons"].ToString();
                            txt129.Text = relat.Rows[q + 25]["Cons"].ToString();
                            txt130.Text = relat.Rows[q + 26]["Cons"].ToString();
                            txt131.Text = relat.Rows[q + 27]["Cons"].ToString();

                            //valor
                            txt21.Text = relat.Rows[q]["Valor"].ToString();
                            txt132.Text = relat.Rows[q + 1]["Valor"].ToString();
                            txt133.Text = relat.Rows[q + 2]["Valor"].ToString();
                            txt134.Text = relat.Rows[q + 3]["Valor"].ToString();
                            txt135.Text = relat.Rows[q + 4]["Valor"].ToString();
                            txt136.Text = relat.Rows[q + 5]["Valor"].ToString();
                            txt137.Text = relat.Rows[q + 6]["Valor"].ToString();
                            txt138.Text = relat.Rows[q + 7]["Valor"].ToString();
                            txt139.Text = relat.Rows[q + 8]["Valor"].ToString();
                            txt140.Text = relat.Rows[q + 9]["Valor"].ToString();
                            txt141.Text = relat.Rows[q + 10]["Valor"].ToString();
                            txt142.Text = relat.Rows[q + 11]["Valor"].ToString();
                            txt143.Text = relat.Rows[q + 12]["Valor"].ToString();
                            txt144.Text = relat.Rows[q + 13]["Valor"].ToString();
                            txt145.Text = relat.Rows[q + 14]["Valor"].ToString();
                            txt146.Text = relat.Rows[q + 15]["Valor"].ToString();
                            txt147.Text = relat.Rows[q + 16]["Valor"].ToString();
                            txt148.Text = relat.Rows[q + 17]["Valor"].ToString();
                            txt149.Text = relat.Rows[q + 18]["Valor"].ToString();
                            txt150.Text = relat.Rows[q + 19]["Valor"].ToString();
                            txt151.Text = relat.Rows[q + 20]["Valor"].ToString();
                            txt152.Text = relat.Rows[q + 21]["Valor"].ToString();
                            txt153.Text = relat.Rows[q + 22]["Valor"].ToString();
                            txt154.Text = relat.Rows[q + 23]["Valor"].ToString();
                            txt155.Text = relat.Rows[q + 24]["Valor"].ToString();
                            txt156.Text = relat.Rows[q + 25]["Valor"].ToString();
                            txt157.Text = relat.Rows[q + 26]["Valor"].ToString();
                            txt158.Text = relat.Rows[q + 27]["Valor"].ToString();

                            //rateio 
                            txt22.Text = relat.Rows[q]["Rat"].ToString();
                            txt159.Text = relat.Rows[q + 1]["Rat"].ToString();
                            txt160.Text = relat.Rows[q + 2]["Rat"].ToString();
                            txt161.Text = relat.Rows[q + 3]["Rat"].ToString();
                            txt162.Text = relat.Rows[q + 4]["Rat"].ToString();
                            txt163.Text = relat.Rows[q + 5]["Rat"].ToString();
                            txt164.Text = relat.Rows[q + 6]["Rat"].ToString();
                            txt165.Text = relat.Rows[q + 7]["Rat"].ToString();
                            txt166.Text = relat.Rows[q + 8]["Rat"].ToString();
                            txt167.Text = relat.Rows[q + 9]["Rat"].ToString();
                            txt168.Text = relat.Rows[q + 10]["Rat"].ToString();
                            txt169.Text = relat.Rows[q + 11]["Rat"].ToString();
                            txt170.Text = relat.Rows[q + 12]["Rat"].ToString();
                            txt171.Text = relat.Rows[q + 13]["Rat"].ToString();
                            txt172.Text = relat.Rows[q + 14]["Rat"].ToString();
                            txt173.Text = relat.Rows[q + 15]["Rat"].ToString();
                            txt174.Text = relat.Rows[q + 16]["Rat"].ToString();
                            txt175.Text = relat.Rows[q + 17]["Rat"].ToString();
                            txt176_.Text = relat.Rows[q + 18]["Rat"].ToString();
                            txt177_.Text = relat.Rows[q + 19]["Rat"].ToString();
                            txt178_.Text = relat.Rows[q + 20]["Rat"].ToString();
                            txt179_.Text = relat.Rows[q + 21]["Rat"].ToString();
                            txt180_.Text = relat.Rows[q + 22]["Rat"].ToString();
                            txt181_.Text = relat.Rows[q + 23]["Rat"].ToString();
                            txt182_.Text = relat.Rows[q + 24]["Rat"].ToString();
                            txt183_.Text = relat.Rows[q + 25]["Rat"].ToString();
                            txt184_.Text = relat.Rows[q + 26]["Rat"].ToString();
                            txt185_.Text = relat.Rows[q + 27]["Rat"].ToString();

                            //tx
                            txt23.Text = relat.Rows[q]["TX"].ToString();
                            txt186_.Text = relat.Rows[q + 1]["TX"].ToString();
                            txt187_.Text = relat.Rows[q + 2]["TX"].ToString();
                            txt188_.Text = relat.Rows[q + 3]["TX"].ToString();
                            txt189_.Text = relat.Rows[q + 4]["TX"].ToString();
                            txt190.Text = relat.Rows[q + 5]["TX"].ToString();
                            txt191.Text = relat.Rows[q + 6]["TX"].ToString();
                            txt192.Text = relat.Rows[q + 7]["TX"].ToString();
                            txt193.Text = relat.Rows[q + 8]["TX"].ToString();
                            txt194.Text = relat.Rows[q + 9]["TX"].ToString();
                            txt195.Text = relat.Rows[q + 10]["TX"].ToString();
                            txt196.Text = relat.Rows[q + 11]["TX"].ToString();
                            txt197.Text = relat.Rows[q + 12]["TX"].ToString();
                            txt198.Text = relat.Rows[q + 13]["TX"].ToString();
                            txt199.Text = relat.Rows[q + 14]["TX"].ToString();
                            txt200.Text = relat.Rows[q + 15]["TX"].ToString();
                            txt201.Text = relat.Rows[q + 16]["TX"].ToString();
                            txt202.Text = relat.Rows[q + 17]["TX"].ToString();
                            txt203.Text = relat.Rows[q + 18]["TX"].ToString();
                            txt204.Text = relat.Rows[q + 19]["TX"].ToString();
                            txt205.Text = relat.Rows[q + 20]["TX"].ToString();
                            txt206.Text = relat.Rows[q + 21]["TX"].ToString();
                            txt207.Text = relat.Rows[q + 22]["TX"].ToString();
                            txt208.Text = relat.Rows[q + 23]["TX"].ToString();
                            txt209_.Text = relat.Rows[q + 24]["TX"].ToString();
                            txt210_.Text = relat.Rows[q + 25]["TX"].ToString();
                            txt211_.Text = relat.Rows[q + 26]["TX"].ToString();
                            txt212_.Text = relat.Rows[q + 27]["TX"].ToString();

                            //total
                            txt24.Text = relat.Rows[q]["Total"].ToString();
                            txt213_.Text = relat.Rows[q + 1]["Total"].ToString();
                            txt214_.Text = relat.Rows[q + 2]["Total"].ToString();
                            txt215_.Text = relat.Rows[q + 3]["Total"].ToString();
                            txt216_.Text = relat.Rows[q + 4]["Total"].ToString();
                            txt217_.Text = relat.Rows[q + 5]["Total"].ToString();
                            txt218_.Text = relat.Rows[q + 6]["Total"].ToString();
                            txt219_.Text = relat.Rows[q + 7]["Total"].ToString();
                            txt220_.Text = relat.Rows[q + 8]["Total"].ToString();
                            txt221_.Text = relat.Rows[q + 9]["Total"].ToString();
                            txt222_.Text = relat.Rows[q + 10]["Total"].ToString();
                            txt223.Text = relat.Rows[q + 11]["Total"].ToString();
                            txt224.Text = relat.Rows[q + 12]["Total"].ToString();
                            txt225.Text = relat.Rows[q + 13]["Total"].ToString();
                            txt226.Text = relat.Rows[q + 14]["Total"].ToString();
                            txt227.Text = relat.Rows[q + 15]["Total"].ToString();
                            txt228.Text = relat.Rows[q + 16]["Total"].ToString();
                            txt229.Text = relat.Rows[q + 17]["Total"].ToString();
                            txt230.Text = relat.Rows[q + 18]["Total"].ToString();
                            txt231.Text = relat.Rows[q + 19]["Total"].ToString();
                            txt232.Text = relat.Rows[q + 20]["Total"].ToString();
                            txt233.Text = relat.Rows[q + 21]["Total"].ToString();
                            txt234.Text = relat.Rows[q + 22]["Total"].ToString();
                            txt235.Text = relat.Rows[q + 23]["Total"].ToString();
                            txt236.Text = relat.Rows[q + 24]["Total"].ToString();
                            txt237.Text = relat.Rows[q + 25]["Total"].ToString();
                            txt238.Text = relat.Rows[q + 26]["Total"].ToString();
                            txt239.Text = relat.Rows[q + 27]["Total"].ToString();

                            //multa
                            txt25.Text = relat.Rows[q]["Multa"].ToString();
                            txt240.Text = relat.Rows[q + 1]["Multa"].ToString();
                            txt241.Text = relat.Rows[q + 2]["Multa"].ToString();
                            txt242_.Text = relat.Rows[q + 3]["Multa"].ToString();
                            txt243_.Text = relat.Rows[q + 4]["Multa"].ToString();
                            txt244_.Text = relat.Rows[q + 5]["Multa"].ToString();
                            txt245_.Text = relat.Rows[q + 6]["Multa"].ToString();
                            txt246_.Text = relat.Rows[q + 7]["Multa"].ToString();
                            txt247_.Text = relat.Rows[q + 8]["Multa"].ToString();
                            txt248_.Text = relat.Rows[q + 9]["Multa"].ToString();
                            txt249_.Text = relat.Rows[q + 10]["Multa"].ToString();
                            txt250_.Text = relat.Rows[q + 11]["Multa"].ToString();
                            txt251_.Text = relat.Rows[q + 12]["Multa"].ToString();
                            txt252_.Text = relat.Rows[q + 13]["Multa"].ToString();
                            txt253_.Text = relat.Rows[q + 14]["Multa"].ToString();
                            txt254_.Text = relat.Rows[q + 15]["Multa"].ToString();
                            txt255_.Text = relat.Rows[q + 16]["Multa"].ToString();
                            txt256_.Text = relat.Rows[q + 17]["Multa"].ToString();
                            txt257_.Text = relat.Rows[q + 18]["Multa"].ToString();
                            txt258_.Text = relat.Rows[q + 19]["Multa"].ToString();
                            txt259_.Text = relat.Rows[q + 20]["Multa"].ToString();
                            txt260.Text = relat.Rows[q + 21]["Multa"].ToString();
                            txt261.Text = relat.Rows[q + 22]["Multa"].ToString();
                            txt262.Text = relat.Rows[q + 23]["Multa"].ToString();
                            txt263.Text = relat.Rows[q + 24]["Multa"].ToString();
                            txt264.Text = relat.Rows[q + 25]["Multa"].ToString();
                            txt265.Text = relat.Rows[q + 26]["Multa"].ToString();
                            txt266.Text = relat.Rows[q + 27]["Multa"].ToString();

                            //atraso
                            txt26.Text = relat.Rows[q]["Atraso"].ToString();
                            if (String.IsNullOrEmpty(relat.Rows[q]["Atraso"].ToString()) == true)
                            {
                                txt26.Text = "0";
                            }
                            txt267.Text = relat.Rows[q + 1]["Atraso"].ToString();
                            if (String.IsNullOrEmpty(relat.Rows[q + 1]["Atraso"].ToString()) == true)
                            {
                                txt267.Text = "0";
                            }
                            txt268.Text = relat.Rows[q + 2]["Atraso"].ToString();
                            if (String.IsNullOrEmpty(relat.Rows[q + 2]["Atraso"].ToString()) == true)
                            {
                                txt268.Text = "0";
                            }
                            txt269.Text = relat.Rows[q + 3]["Atraso"].ToString();
                            if (String.IsNullOrEmpty(relat.Rows[q + 3]["Atraso"].ToString()) == true)
                            {
                                txt269.Text = "0";
                            }
                            txt270.Text = relat.Rows[q + 4]["Atraso"].ToString();
                            if (String.IsNullOrEmpty(relat.Rows[q + 5]["Atraso"].ToString()) == true)
                            {
                                txt270.Text = "0";
                            }
                            txt271.Text = relat.Rows[q + 5]["Atraso"].ToString();
                            if (String.IsNullOrEmpty(relat.Rows[q + 6]["Atraso"].ToString()) == true)
                            {
                                txt271.Text = "0";
                            }
                            txt272.Text = relat.Rows[q + 6]["Atraso"].ToString();
                            if (String.IsNullOrEmpty(relat.Rows[q + 6]["Atraso"].ToString()) == true)
                            {
                                txt272.Text = "0";
                            }
                            txt273.Text = relat.Rows[q + 7]["Atraso"].ToString();
                            if (String.IsNullOrEmpty(relat.Rows[q + 7]["Atraso"].ToString()) == true)
                            {
                                txt273.Text = "0";
                            }
                            txt274.Text = relat.Rows[q + 8]["Atraso"].ToString();
                            if (String.IsNullOrEmpty(relat.Rows[q + 8]["Atraso"].ToString()) == true)
                            {
                                txt274.Text = "0";
                            }
                            txt275.Text = relat.Rows[q + 9]["Atraso"].ToString();
                            if (String.IsNullOrEmpty(relat.Rows[q + 9]["Atraso"].ToString()) == true)
                            {
                                txt275.Text = "0";
                            }
                            txt276.Text = relat.Rows[q + 10]["Atraso"].ToString();
                            if (String.IsNullOrEmpty(relat.Rows[q + 10]["Atraso"].ToString()) == true)
                            {
                                txt276.Text = "0";
                            }
                            txt277.Text = relat.Rows[q + 11]["Atraso"].ToString();
                            if (String.IsNullOrEmpty(relat.Rows[q + 11]["Atraso"].ToString()) == true)
                            {
                                txt277.Text = "0";
                            }
                            txt278.Text = relat.Rows[q + 12]["Atraso"].ToString();
                            if (String.IsNullOrEmpty(relat.Rows[q + 12]["Atraso"].ToString()) == true)
                            {
                                txt278.Text = "0";
                            }
                            txt279.Text = relat.Rows[q + 13]["Atraso"].ToString();
                            if (String.IsNullOrEmpty(relat.Rows[q + 13]["Atraso"].ToString()) == true)
                            {
                                txt279.Text = "0";
                            }
                            txt280.Text = relat.Rows[q + 14]["Atraso"].ToString();
                            if (String.IsNullOrEmpty(relat.Rows[q + 14]["Atraso"].ToString()) == true)
                            {
                                txt280.Text = "0";
                            }
                            txt281.Text = relat.Rows[q + 15]["Atraso"].ToString();
                            if (String.IsNullOrEmpty(relat.Rows[q + 15]["Atraso"].ToString()) == true)
                            {
                                txt281.Text = "0";
                            }
                            txt282.Text = relat.Rows[q + 16]["Atraso"].ToString();
                            if (String.IsNullOrEmpty(relat.Rows[q + 16]["Atraso"].ToString()) == true)
                            {
                                txt282.Text = "0";
                            }
                            txt283.Text = relat.Rows[q + 17]["Atraso"].ToString();
                            if (String.IsNullOrEmpty(relat.Rows[q + 17]["Atraso"].ToString()) == true)
                            {
                                txt283.Text = "0";
                            }
                            txt284.Text = relat.Rows[q + 18]["Atraso"].ToString();
                            if (String.IsNullOrEmpty(relat.Rows[q + 18]["Atraso"].ToString()) == true)
                            {
                                txt284.Text = "0";
                            }
                            txt285.Text = relat.Rows[q + 19]["Atraso"].ToString();
                            if (String.IsNullOrEmpty(relat.Rows[q + 19]["Atraso"].ToString()) == true)
                            {
                                txt285.Text = "0";
                            }
                            txt286.Text = relat.Rows[q + 20]["Atraso"].ToString();
                            if (String.IsNullOrEmpty(relat.Rows[q + 20]["Atraso"].ToString()) == true)
                            {
                                txt286.Text = "0";
                            }
                            txt287.Text = relat.Rows[q + 21]["Atraso"].ToString();
                            if (String.IsNullOrEmpty(relat.Rows[q + 21]["Atraso"].ToString()) == true)
                            {
                                txt287.Text = "0";
                            }
                            txt288.Text = relat.Rows[q + 22]["Atraso"].ToString();
                            if (String.IsNullOrEmpty(relat.Rows[q + 22]["Atraso"].ToString()) == true)
                            {
                                txt288.Text = "0";
                            }
                            txt289.Text = relat.Rows[q + 23]["Atraso"].ToString();
                            if (String.IsNullOrEmpty(relat.Rows[q + 23]["Atraso"].ToString()) == true)
                            {
                                txt289.Text = "0";
                            }
                            txt290.Text = relat.Rows[q + 24]["Atraso"].ToString();
                            if (String.IsNullOrEmpty(relat.Rows[q + 24]["Atraso"].ToString()) == true)
                            {
                                txt290.Text = "0";
                            }
                            txt291.Text = relat.Rows[q + 25]["Atraso"].ToString();
                            if (String.IsNullOrEmpty(relat.Rows[q + 25]["Atraso"].ToString()) == true)
                            {
                                txt291.Text = "0";
                            }
                            txt292.Text = relat.Rows[q + 26]["Atraso"].ToString();
                            if (String.IsNullOrEmpty(relat.Rows[q + 26]["Atraso"].ToString()) == true)
                            {
                                txt292.Text = "0";
                            }
                            txt293.Text = relat.Rows[q + 27]["Atraso"].ToString();
                            if (String.IsNullOrEmpty(relat.Rows[q + 27]["Atraso"].ToString()) == true)
                            {
                                txt293.Text = "0";
                            }
                        }
                        else
                        {
                            int c = qtde;


                            txt42.Text = "";

                            txt43.Text = "";
                            txt44.Text = "";
                            txt1.Text = "";
                            txt4.Text = "";
                            txt14.Text = "";
                            txt17.Text = "";
                            txt27.Text = "";
                            txt28.Text = "";
                            txt29.Text = "";
                            txt30.Text = "";
                            txt31.Text = "";
                            txt32.Text = "";
                            txt33.Text = "";
                            txt34.Text = "";
                            txt35.Text = "";
                            txt36.Text = "";
                            txt37.Text = "";
                            txt38.Text = "";
                            txt39.Text = "";
                            txt40.Text = "";
                            txt41.Text = "";
                            txt45.Text = "";
                            txt46.Text = "";
                            txt47.Text = "";
                            txt48.Text = "";
                            txt51.Text = "";
                            txt52.Text = "";

                            //Anterior
                            txt18.Text = "";
                            txt49.Text = "";
                            txt50.Text = "";
                            txt53.Text = "";
                            txt54.Text = "";
                            txt55.Text = "";
                            txt56.Text = "";
                            txt57.Text = "";
                            txt58.Text = "";
                            txt59.Text = "";
                            txt60.Text = "";
                            txt61.Text = "";
                            txt62.Text = "";
                            txt63.Text = "";
                            txt64.Text = "";
                            txt65.Text = "";
                            txt66.Text = "";
                            txt67.Text = "";
                            txt68.Text = "";
                            txt69.Text = "";
                            txt70.Text = "";
                            txt71.Text = "";
                            txt72.Text = "";
                            txt73.Text = "";
                            txt74.Text = "";
                            txt75.Text = "";
                            txt76.Text = "";
                            txt77.Text = "";

                            txt19.Text = "";
                            txt78.Text = "";
                            txt79.Text = "";
                            txt80.Text = "";
                            txt81.Text = "";
                            txt82.Text = "";
                            txt83.Text = "";
                            txt84.Text = "";
                            txt85.Text = "";
                            txt86.Text = "";
                            txt87.Text = "";
                            txt88.Text = "";
                            txt89.Text = "";
                            txt90.Text = "";
                            txt91.Text = "";
                            txt92.Text = "";
                            txt93.Text = "";
                            txt94.Text = "";
                            txt95.Text = "";
                            txt96.Text = "";
                            txt97.Text = "";
                            txt98.Text = "";
                            txt99.Text = "";
                            txt100.Text = "";
                            txt101.Text = "";
                            txt102.Text = "";
                            txt103.Text = "";
                            txt104.Text = "";

                            txt20.Text = "";
                            txt105.Text = "";
                            txt106.Text = "";
                            txt107.Text = "";
                            txt108.Text = "";
                            txt109.Text = "";
                            txt110_.Text = "";
                            txt111_.Text = "";
                            txt112_.Text = "";
                            txt113_.Text = "";
                            txt114_.Text = "";
                            txt115_.Text = "";
                            txt116_.Text = "";
                            txt117_.Text = "";
                            txt118_.Text = "";
                            txt119_.Text = "";
                            txt120_.Text = "";
                            txt121_.Text = "";
                            txt122_.Text = "";
                            txt123_.Text = "";
                            txt124.Text = "";
                            txt125.Text = "";
                            txt126.Text = "";
                            txt127.Text = "";
                            txt128.Text = "";
                            txt129.Text = "";
                            txt130.Text = "";
                            txt131.Text = "";


                            txt21.Text = "";
                            txt132.Text = "";
                            txt133.Text = "";
                            txt134.Text = "";
                            txt135.Text = "";
                            txt136.Text = "";
                            txt137.Text = "";
                            txt138.Text = "";
                            txt139.Text = "";
                            txt140.Text = "";
                            txt141.Text = "";
                            txt142.Text = "";
                            txt143.Text = "";
                            txt144.Text = "";
                            txt145.Text = "";
                            txt146.Text = "";
                            txt147.Text = "";
                            txt148.Text = "";
                            txt149.Text = "";
                            txt150.Text = "";
                            txt151.Text = "";
                            txt152.Text = "";
                            txt153.Text = "";
                            txt154.Text = "";
                            txt155.Text = "";
                            txt156.Text = "";
                            txt157.Text = "";
                            txt158.Text = "";

                            txt22.Text = "";
                            txt159.Text = "";
                            txt160.Text = "";
                            txt161.Text = "";
                            txt162.Text = "";
                            txt163.Text = "";
                            txt164.Text = "";
                            txt165.Text = "";
                            txt166.Text = "";
                            txt167.Text = "";
                            txt168.Text = "";
                            txt169.Text = "";
                            txt170.Text = "";
                            txt171.Text = "";
                            txt172.Text = "";
                            txt173.Text = "";
                            txt174.Text = "";
                            txt175.Text = "";
                            txt176_.Text = "";
                            txt177_.Text = "";
                            txt178_.Text = "";
                            txt179_.Text = "";
                            txt180_.Text = "";
                            txt181_.Text = "";
                            txt182_.Text = "";
                            txt183_.Text = "";
                            txt184_.Text = "";
                            txt185_.Text = "";

                            txt23.Text = "";
                            txt186_.Text = "";
                            txt187_.Text = "";
                            txt188_.Text = "";
                            txt189_.Text = "";
                            txt190.Text = "";
                            txt191.Text = "";
                            txt192.Text = "";
                            txt193.Text = "";
                            txt194.Text = "";
                            txt195.Text = "";
                            txt196.Text = "";
                            txt197.Text = "";
                            txt198.Text = "";
                            txt199.Text = "";
                            txt200.Text = "";
                            txt201.Text = "";
                            txt202.Text = "";
                            txt203.Text = "";
                            txt204.Text = "";
                            txt205.Text = "";
                            txt206.Text = "";
                            txt207.Text = "";
                            txt208.Text = "";
                            txt209_.Text = "";
                            txt210_.Text = "";
                            txt211_.Text = "";
                            txt212_.Text = "";

                            txt24.Text = "";
                            txt213_.Text = "";
                            txt214_.Text = "";
                            txt215_.Text = "";
                            txt216_.Text = "";
                            txt217_.Text = "";
                            txt218_.Text = "";
                            txt219_.Text = "";
                            txt220_.Text = "";
                            txt221_.Text = "";
                            txt222_.Text = "";
                            txt223.Text = "";
                            txt224.Text = "";
                            txt225.Text = "";
                            txt226.Text = "";
                            txt227.Text = "";
                            txt228.Text = "";
                            txt229.Text = "";
                            txt230.Text = "";
                            txt231.Text = "";
                            txt232.Text = "";
                            txt233.Text = "";
                            txt234.Text = "";
                            txt235.Text = "";
                            txt236.Text = "";
                            txt237.Text = "";
                            txt238.Text = "";
                            txt239.Text = "";

                            txt25.Text = "";
                            txt240.Text = "";
                            txt241.Text = "";
                            txt242_.Text = "";
                            txt243_.Text = "";
                            txt244_.Text = "";
                            txt245_.Text = "";
                            txt246_.Text = "";
                            txt247_.Text = "";
                            txt248_.Text = "";
                            txt249_.Text = "";
                            txt250_.Text = "";
                            txt251_.Text = "";
                            txt252_.Text = "";
                            txt253_.Text = "";
                            txt254_.Text = "";
                            txt255_.Text = "";
                            txt256_.Text = "";
                            txt257_.Text = "";
                            txt258_.Text = "";
                            txt259_.Text = "";
                            txt260.Text = "";
                            txt261.Text = "";
                            txt262.Text = "";
                            txt263.Text = "";
                            txt264.Text = "";
                            txt265.Text = "";
                            txt266.Text = "";


                            txt26.Text = "0";
                            txt267.Text = "0";
                            txt268.Text = "0";
                            txt269.Text = "0";
                            txt270.Text = "0";
                            txt271.Text = "0";
                            txt272.Text = "0";
                            txt273.Text = "0";
                            txt274.Text = "0";
                            txt275.Text = "0";
                            txt276.Text = "0";
                            txt277.Text = "0";
                            txt278.Text = "0";
                            txt279.Text = "0";
                            txt280.Text = "0";
                            txt281.Text = "0";
                            txt282.Text = "0";
                            txt283.Text = "0";
                            txt284.Text = "0";
                            txt285.Text = "0";
                            txt286.Text = "0";
                            txt287.Text = "0";
                            txt288.Text = "0";
                            txt289.Text = "0";
                            txt290.Text = "0";
                            txt291.Text = "0";
                            txt292.Text = "0";
                            txt293.Text = "0";

                            if (c > 0)
                            {
                                txt42.Text = relat.Rows[q]["Nome"].ToString();

                            }

                            c--;
                            if (c > 0)
                            {
                                txt43.Text = relat.Rows[q + 1]["Nome"].ToString();

                            }

                            c--;
                            if (c > 0)
                            {
                                txt44.Text = relat.Rows[q + 2]["Nome"].ToString();
                            }

                            c--;
                            if (c > 0)
                            {
                                txt1.Text = relat.Rows[q + 3]["Nome"].ToString();
                            }

                            c--;
                            if (c > 0)
                            {
                                txt4.Text = relat.Rows[q + 4]["Nome"].ToString();
                            }

                            c--;
                            if (c > 0)
                            {
                                txt14.Text = relat.Rows[q + 5]["Nome"].ToString();
                            }

                            c--;
                            if (c > 0)
                            {
                                txt17.Text = relat.Rows[q + 6]["Nome"].ToString();
                            }

                            c--;
                            if (c > 0)
                            {
                                txt27.Text = relat.Rows[q + 7]["Nome"].ToString();
                            }

                            c--;
                            if (c > 0)
                            {
                                txt28.Text = relat.Rows[q + 8]["Nome"].ToString();
                            }

                            c--;
                            if (c > 0)
                            {
                                txt29.Text = relat.Rows[q + 9]["Nome"].ToString();
                            }

                            c--;
                            if (c > 0)
                            {
                                txt30.Text = relat.Rows[q + 10]["Nome"].ToString();
                            }

                            c--;
                            if (c > 0)
                            {
                                txt31.Text = relat.Rows[q + 11]["Nome"].ToString();
                            }

                            c--;
                            if (c > 0)
                            {
                                txt32.Text = relat.Rows[q + 12]["Nome"].ToString();
                            }

                            c--;
                            if (c > 0)
                            {
                                txt33.Text = relat.Rows[q + 13]["Nome"].ToString();
                            }

                            c--;
                            if (c > 0)
                            {
                                txt34.Text = relat.Rows[q + 14]["Nome"].ToString();
                            }

                            c--;
                            if (c > 0)
                            {
                                txt35.Text = relat.Rows[q + 15]["Nome"].ToString();
                            }

                            c--;
                            if (c > 0)
                            {
                                txt36.Text = relat.Rows[q + 16]["Nome"].ToString();
                            }

                            c--;
                            if (c > 0)
                            {
                                txt37.Text = relat.Rows[q + 17]["Nome"].ToString();
                            }

                            c--;
                            if (c > 0)
                            {
                                txt38.Text = relat.Rows[q + 18]["Nome"].ToString();
                            }

                            c--;
                            if (c > 0)
                            {
                                txt39.Text = relat.Rows[q + 19]["Nome"].ToString();
                            }

                            c--;
                            if (c > 0)
                            {
                                txt40.Text = relat.Rows[q + 20]["Nome"].ToString();
                            }

                            c--;
                            if (c > 0)
                            {
                                txt41.Text = relat.Rows[q + 21]["Nome"].ToString();
                            }

                            c--;
                            if (c > 0)
                            {
                                txt45.Text = relat.Rows[q + 22]["Nome"].ToString();
                            }

                            c--;
                            if (c > 0)
                            {
                                txt46.Text = relat.Rows[q + 23]["Nome"].ToString();
                            }

                            c--;
                            if (c > 0)
                            {
                                txt47.Text = relat.Rows[q + 24]["Nome"].ToString();
                            }

                            c--;
                            if (c > 0)
                            {
                                txt48.Text = relat.Rows[q + 25]["Nome"].ToString();
                            }

                            c--;
                            if (c > 0)
                            {
                                txt51.Text = relat.Rows[q + 26]["Nome"].ToString();
                            }

                            c--;
                            if (c > 0)
                            {
                                txt52.Text = relat.Rows[q + 27]["Nome"].ToString();
                            }


                            c = qtde;
                            //Anterior
                            txt18.Text = relat.Rows[q]["Anterior"].ToString();
                            c--;
                            if (c > 0)
                            {
                                txt49.Text = relat.Rows[q + 1]["Anterior"].ToString();
                            }

                            c--;
                            if (c > 0)
                            {
                                txt50.Text = relat.Rows[q + 2]["Anterior"].ToString();
                            }

                            c--;
                            if (c > 0)
                            {
                                txt53.Text = relat.Rows[q + 3]["Anterior"].ToString();
                            }

                            c--;
                            if (c > 0)
                            {
                                txt54.Text = relat.Rows[q + 4]["Anterior"].ToString();
                            }

                            c--;
                            if (c > 0)
                            {
                                txt55.Text = relat.Rows[q + 5]["Anterior"].ToString();
                            }

                            c--;
                            if (c > 0)
                            {
                                txt56.Text = relat.Rows[q + 6]["Anterior"].ToString();
                            }

                            c--;
                            if (c > 0)
                            {
                                txt57.Text = relat.Rows[q + 7]["Anterior"].ToString();
                            }

                            c--;
                            if (c > 0)
                            {
                                txt58.Text = relat.Rows[q + 8]["Anterior"].ToString();
                            }

                            c--;
                            if (c > 0)
                            {
                                txt59.Text = relat.Rows[q + 9]["Anterior"].ToString();
                            }

                            c--;
                            if (c > 0)
                            {
                                txt60.Text = relat.Rows[q + 10]["Anterior"].ToString();
                            }

                            c--;
                            if (c > 0)
                            {
                                txt61.Text = relat.Rows[q + 11]["Anterior"].ToString();
                            }

                            c--;
                            if (c > 0)
                            {
                                txt62.Text = relat.Rows[q + 12]["Anterior"].ToString();
                            }

                            c--;
                            if (c > 0)
                            {
                                txt63.Text = relat.Rows[q + 13]["Anterior"].ToString();

                            }

                            c--;
                            if (c > 0)
                            {
                                txt64.Text = relat.Rows[q + 14]["Anterior"].ToString();
                            }

                            c--;
                            if (c > 0)
                            {
                                txt65.Text = relat.Rows[q + 15]["Anterior"].ToString();
                            }

                            c--;
                            if (c > 0)
                            {
                                txt66.Text = relat.Rows[q + 16]["Anterior"].ToString();
                            }

                            c--;
                            if (c > 0)
                            {
                                txt67.Text = relat.Rows[q + 17]["Anterior"].ToString();
                            }

                            c--;
                            if (c > 0)
                            {
                                txt68.Text = relat.Rows[q + 18]["Anterior"].ToString();
                            }

                            c--;
                            if (c > 0)
                            {
                                txt69.Text = relat.Rows[q + 19]["Anterior"].ToString();
                            }

                            c--;
                            if (c > 0)
                            {
                                txt70.Text = relat.Rows[q + 20]["Anterior"].ToString();
                            }

                            c--;
                            if (c > 0)
                            {
                                txt71.Text = relat.Rows[q + 21]["Anterior"].ToString();
                            }

                            c--;
                            if (c > 0)
                            {
                                txt72.Text = relat.Rows[q + 22]["Anterior"].ToString();
                            }

                            c--;
                            if (c > 0)
                            {
                                txt73.Text = relat.Rows[q + 23]["Anterior"].ToString();
                            }

                            c--;
                            if (c > 0)
                            {
                                txt74.Text = relat.Rows[q + 24]["Anterior"].ToString();
                            }

                            c--;
                            if (c > 0)
                            {
                                txt75.Text = relat.Rows[q + 25]["Anterior"].ToString();
                            }

                            c--;
                            if (c > 0)
                            {
                                txt76.Text = relat.Rows[q + 26]["Anterior"].ToString();
                            }

                            c--;
                            if (c > 0)
                            {
                                txt77.Text = relat.Rows[q + 27]["Anterior"].ToString();
                            }



                            c = qtde;
                            //atual
                            txt19.Text = relat.Rows[q]["Atual"].ToString();
                            c--;
                            if (c > 0)
                            {
                                txt77.Text = relat.Rows[q + 1]["Anterior"].ToString();
                            }

                            c--;
                            if (c > 0)
                            {
                                txt79.Text = relat.Rows[q + 2]["Atual"].ToString();
                            }

                            c--;
                            if (c > 0)
                            {
                                txt80.Text = relat.Rows[q + 3]["Atual"].ToString();
                            }

                            c--;
                            if (c > 0)
                            {
                                txt81.Text = relat.Rows[q + 4]["Atual"].ToString();
                            }

                            c--;
                            if (c > 0)
                            {
                                txt82.Text = relat.Rows[q + 5]["Atual"].ToString();
                            }

                            c--;
                            if (c > 0)
                            {
                                txt83.Text = relat.Rows[q + 6]["Atual"].ToString();
                            }

                            c--;
                            if (c > 0)
                            {
                                txt84.Text = relat.Rows[q + 7]["Atual"].ToString();
                            }

                            c--;
                            if (c > 0)
                            {
                                txt85.Text = relat.Rows[q + 8]["Atual"].ToString();
                            }

                            c--;
                            if (c > 0)
                            {
                                txt86.Text = relat.Rows[q + 9]["Atual"].ToString();
                            }

                            c--;
                            if (c > 0)
                            {
                                txt87.Text = relat.Rows[q + 10]["Atual"].ToString();
                            }

                            c--;
                            if (c > 0)
                            {
                                txt88.Text = relat.Rows[q + 11]["Atual"].ToString();
                            }

                            c--;
                            if (c > 0)
                            {
                                txt89.Text = relat.Rows[q + 12]["Atual"].ToString();
                            }

                            c--;
                            if (c > 0)
                            {
                                txt90.Text = relat.Rows[q + 13]["Atual"].ToString();
                            }

                            c--;
                            if (c > 0)
                            {
                                txt91.Text = relat.Rows[q + 14]["Atual"].ToString();
                            }

                            c--;
                            if (c > 0)
                            {
                                txt92.Text = relat.Rows[q + 15]["Atual"].ToString();
                            }

                            c--;
                            if (c > 0)
                            {
                                txt93.Text = relat.Rows[q + 16]["Atual"].ToString();
                            }

                            c--;
                            if (c > 0)
                            {
                                txt94.Text = relat.Rows[q + 17]["Atual"].ToString();
                            }

                            c--;
                            if (c > 0)
                            {
                                txt95.Text = relat.Rows[q + 18]["Atual"].ToString();
                            }

                            c--;
                            if (c > 0)
                            {
                                txt96.Text = relat.Rows[q + 19]["Atual"].ToString();
                            }

                            c--;
                            if (c > 0)
                            {
                                txt97.Text = relat.Rows[q + 20]["Atual"].ToString();
                            }

                            c--;
                            if (c > 0)
                            {
                                txt98.Text = relat.Rows[q + 21]["Atual"].ToString();
                            }

                            c--;
                            if (c > 0)
                            {
                                txt99.Text = relat.Rows[q + 22]["Atual"].ToString();
                            }

                            c--;
                            if (c > 0)
                            {
                                txt100.Text = relat.Rows[q + 23]["Atual"].ToString();
                            }

                            c--;
                            if (c > 0)
                            {
                                txt101.Text = relat.Rows[q + 24]["Atual"].ToString();
                            }

                            c--;
                            if (c > 0)
                            {
                                txt102.Text = relat.Rows[q + 25]["Atual"].ToString();
                            }

                            c--;
                            if (c > 0)
                            {
                                txt103.Text = relat.Rows[q + 26]["Atual"].ToString();
                            }

                            c--;
                            if (c > 0)
                            {
                                txt104.Text = relat.Rows[q + 27]["Atual"].ToString();
                            }

                            c = qtde;

                            //consumo
                            txt20.Text = relat.Rows[q]["Cons"].ToString();

                            c--;
                            if (c > 0)
                            {
                                txt105.Text = relat.Rows[q + 1]["Cons"].ToString();
                            }

                            c--;
                            if (c > 0)
                            {
                                txt106.Text = relat.Rows[q + 2]["Cons"].ToString();
                            }

                            c--;
                            if (c > 0)
                            {
                                txt107.Text = relat.Rows[q + 3]["Cons"].ToString();

                            }
                            c--;
                            if (c > 0)
                            {
                                txt108.Text = relat.Rows[q + 4]["Cons"].ToString();
                            }

                            c--;
                            if (c > 0)
                            {
                                txt109.Text = relat.Rows[q + 5]["Cons"].ToString();
                            }

                            c--;
                            if (c > 0)
                            {
                                txt110_.Text = relat.Rows[q + 6]["Cons"].ToString();
                            }

                            c--;
                            if (c > 0)
                            {
                                txt111_.Text = relat.Rows[q + 7]["Cons"].ToString();
                            }

                            c--;
                            if (c > 0)
                            {
                                txt112_.Text = relat.Rows[q + 8]["Cons"].ToString();
                            }

                            c--;
                            if (c > 0)
                            {
                                txt113_.Text = relat.Rows[q + 9]["Cons"].ToString();
                            }

                            c--;
                            if (c > 0)
                            {
                                txt114_.Text = relat.Rows[q + 10]["Cons"].ToString();
                            }

                            c--;
                            if (c > 0)
                            {
                                txt115_.Text = relat.Rows[q + 11]["Cons"].ToString();
                            }

                            c--;
                            if (c > 0)
                            {
                                txt116_.Text = relat.Rows[q + 12]["Cons"].ToString();
                            }

                            c--;
                            if (c > 0)
                            {
                                txt117_.Text = relat.Rows[q + 13]["Cons"].ToString();
                            }

                            c--;
                            if (c > 0)
                            {
                                txt118_.Text = relat.Rows[q + 14]["Cons"].ToString();
                            }

                            c--;
                            if (c > 0)
                            {
                                txt119_.Text = relat.Rows[q + 15]["Cons"].ToString();
                            }

                            c--;
                            if (c > 0)
                            {
                                txt120_.Text = relat.Rows[q + 16]["Cons"].ToString();
                            }

                            c--;
                            if (c > 0)
                            {
                                txt121_.Text = relat.Rows[q + 17]["Cons"].ToString();
                            }

                            c--;
                            if (c > 0)
                            {
                                txt122_.Text = relat.Rows[q + 18]["Cons"].ToString();
                            }

                            c--;
                            if (c > 0)
                            {
                                txt123_.Text = relat.Rows[q + 19]["Cons"].ToString();
                            }

                            c--;
                            if (c > 0)
                            {
                                txt124.Text = relat.Rows[q + 20]["Cons"].ToString();
                            }

                            c--;
                            if (c > 0)
                            {
                                txt125.Text = relat.Rows[q + 21]["Cons"].ToString();
                            }

                            c--;
                            if (c > 0)
                            {
                                txt126.Text = relat.Rows[q + 22]["Cons"].ToString();
                            }

                            c--;
                            if (c > 0)
                            {
                                txt127.Text = relat.Rows[q + 23]["Cons"].ToString();
                            }

                            c--;
                            if (c > 0)
                            {
                                txt128.Text = relat.Rows[q + 24]["Cons"].ToString();
                            }

                            c--;
                            if (c > 0)
                            {
                                txt129.Text = relat.Rows[q + 25]["Cons"].ToString();
                            }

                            c--;
                            if (c > 0)
                            {
                                txt130.Text = relat.Rows[q + 26]["Cons"].ToString();
                            }

                            c--;
                            if (c > 0)
                            {
                                txt131.Text = relat.Rows[q + 27]["Cons"].ToString();
                            }


                            c = qtde;
                            //valor
                            txt21.Text = relat.Rows[q]["Valor"].ToString();
                            c--;
                            if (c > 0)
                            {
                                txt132.Text = relat.Rows[q + 1]["Valor"].ToString();
                            }

                            c--;
                            if (c > 0)
                            {
                                txt133.Text = relat.Rows[q + 2]["Valor"].ToString();
                            }

                            c--;
                            if (c > 0)
                            {
                                txt134.Text = relat.Rows[q + 3]["Valor"].ToString();
                            }

                            c--;
                            if (c > 0)
                            {
                                txt135.Text = relat.Rows[q + 4]["Valor"].ToString();
                            }

                            c--;
                            if (c > 0)
                            {
                                txt136.Text = relat.Rows[q + 5]["Valor"].ToString();
                            }

                            c--;
                            if (c > 0)
                            {
                                txt137.Text = relat.Rows[q + 6]["Valor"].ToString();
                            }

                            c--;
                            if (c > 0)
                            {
                                txt138.Text = relat.Rows[q + 7]["Valor"].ToString();
                            }

                            c--;
                            if (c > 0)
                            {
                                txt139.Text = relat.Rows[q + 8]["Valor"].ToString();
                            }

                            c--;
                            if (c > 0)
                            {
                                txt140.Text = relat.Rows[q + 9]["Valor"].ToString();
                            }

                            c--;
                            if (c > 0)
                            {
                                txt141.Text = relat.Rows[q + 10]["Valor"].ToString();
                            }

                            c--;
                            if (c > 0)
                            {
                                txt142.Text = relat.Rows[q + 11]["Valor"].ToString();
                            }

                            c--;
                            if (c > 0)
                            {
                                txt143.Text = relat.Rows[q + 12]["Valor"].ToString();
                            }

                            c--;
                            if (c > 0)
                            {
                                txt144.Text = relat.Rows[q + 13]["Valor"].ToString();
                            }

                            c--;
                            if (c > 0)
                            {
                                txt145.Text = relat.Rows[q + 14]["Valor"].ToString();
                            }

                            c--;
                            if (c > 0)
                            {
                                txt146.Text = relat.Rows[q + 15]["Valor"].ToString();
                            }

                            c--;
                            if (c > 0)
                            {
                                txt147.Text = relat.Rows[q + 16]["Valor"].ToString();
                            }

                            c--;
                            if (c > 0)
                            {
                                txt148.Text = relat.Rows[q + 17]["Valor"].ToString();
                            }

                            c--;
                            if (c > 0)
                            {
                                txt149.Text = relat.Rows[q + 18]["Valor"].ToString();
                            }

                            c--;
                            if (c > 0)
                            {
                                txt150.Text = relat.Rows[q + 19]["Valor"].ToString();
                            }

                            c--;
                            if (c > 0)
                            {
                                txt151.Text = relat.Rows[q + 20]["Valor"].ToString();
                            }

                            c--;
                            if (c > 0)
                            {
                                txt152.Text = relat.Rows[q + 21]["Valor"].ToString();
                            }

                            c--;
                            if (c > 0)
                            {
                                txt153.Text = relat.Rows[q + 22]["Valor"].ToString();
                            }

                            c--;
                            if (c > 0)
                            {
                                txt154.Text = relat.Rows[q + 23]["Valor"].ToString();
                            }

                            c--;
                            if (c > 0)
                            {
                                txt155.Text = relat.Rows[q + 24]["Valor"].ToString();
                            }

                            c--;
                            if (c > 0)
                            {
                                txt156.Text = relat.Rows[q + 25]["Valor"].ToString();
                            }

                            c--;
                            if (c > 0)
                            {
                                txt157.Text = relat.Rows[q + 26]["Valor"].ToString();
                            }

                            c--;
                            if (c > 0)
                            {
                                txt158.Text = relat.Rows[q + 27]["Valor"].ToString();
                            }


                            c = qtde;
                            //rateio 
                            txt22.Text = relat.Rows[q]["Rat"].ToString();
                            c--;
                            if (c > 0)
                            {
                                txt159.Text = relat.Rows[q + 1]["Rat"].ToString();
                            }

                            c--;
                            if (c > 0)
                            {
                                txt160.Text = relat.Rows[q + 2]["Rat"].ToString();
                            }

                            c--;
                            if (c > 0)
                            {
                                txt161.Text = relat.Rows[q + 3]["Rat"].ToString();
                            }

                            c--;
                            if (c > 0)
                            {
                                txt162.Text = relat.Rows[q + 4]["Rat"].ToString();
                            }

                            c--;
                            if (c > 0)
                            {
                                txt163.Text = relat.Rows[q + 5]["Rat"].ToString();
                            }

                            c--;
                            if (c > 0)
                            {
                                txt164.Text = relat.Rows[q + 6]["Rat"].ToString();
                            }

                            c--;
                            if (c > 0)
                            {
                                txt165.Text = relat.Rows[q + 7]["Rat"].ToString();
                            }

                            c--;
                            if (c > 0)
                            {
                                txt166.Text = relat.Rows[q + 8]["Rat"].ToString();
                            }

                            c--;
                            if (c > 0)
                            {
                                txt167.Text = relat.Rows[q + 9]["Rat"].ToString();
                            }

                            c--;
                            if (c > 0)
                            {
                                txt168.Text = relat.Rows[q + 10]["Rat"].ToString();
                            }

                            c--;
                            if (c > 0)
                            {
                                txt169.Text = relat.Rows[q + 11]["Rat"].ToString();
                            }

                            c--;
                            if (c > 0)
                            {
                                txt170.Text = relat.Rows[q + 12]["Rat"].ToString();
                            }

                            c--;
                            if (c > 0)
                            {
                                txt171.Text = relat.Rows[q + 13]["Rat"].ToString();
                            }

                            c--;
                            if (c > 0)
                            {
                                txt172.Text = relat.Rows[q + 14]["Rat"].ToString();
                            }

                            c--;
                            if (c > 0)
                            {
                                txt173.Text = relat.Rows[q + 15]["Rat"].ToString();
                            }

                            c--;
                            if (c > 0)
                            {
                                txt174.Text = relat.Rows[q + 16]["Rat"].ToString();
                            }

                            c--;
                            if (c > 0)
                            {
                                txt175.Text = relat.Rows[q + 17]["Rat"].ToString();
                            }

                            c--;
                            if (c > 0)
                            {
                                txt176_.Text = relat.Rows[q + 18]["Rat"].ToString();
                            }

                            c--;
                            if (c > 0)
                            {
                                txt177_.Text = relat.Rows[q + 19]["Rat"].ToString();
                            }

                            c--;
                            if (c > 0)
                            {
                                txt178_.Text = relat.Rows[q + 20]["Rat"].ToString();
                            }

                            c--;
                            if (c > 0)
                            {
                                txt179_.Text = relat.Rows[q + 21]["Rat"].ToString();
                            }

                            c--;
                            if (c > 0)
                            {
                                txt180_.Text = relat.Rows[q + 22]["Rat"].ToString();
                            }

                            c--;
                            if (c > 0)
                            {
                                txt181_.Text = relat.Rows[q + 23]["Rat"].ToString();
                            }

                            c--;
                            if (c > 0)
                            {
                                txt182_.Text = relat.Rows[q + 24]["Rat"].ToString();
                            }

                            c--;
                            if (c > 0)
                            {
                                txt183_.Text = relat.Rows[q + 25]["Rat"].ToString();
                            }

                            c--;
                            if (c > 0)
                            {
                                txt184_.Text = relat.Rows[q + 26]["Rat"].ToString();
                            }

                            c--;
                            if (c > 0)
                            {
                                txt185_.Text = relat.Rows[q + 27]["Rat"].ToString();
                            }


                            c = qtde;
                            //tx
                            txt23.Text = relat.Rows[q]["TX"].ToString();
                            c--;
                            if (c > 0)
                            {
                                txt186_.Text = relat.Rows[q + 1]["TX"].ToString();
                            }

                            c--;
                            if (c > 0)
                            {
                                txt187_.Text = relat.Rows[q + 2]["TX"].ToString();
                            }

                            c--;
                            if (c > 0)
                            {
                                txt188_.Text = relat.Rows[q + 3]["TX"].ToString();
                            }

                            c--;
                            if (c > 0)
                            {
                                txt189_.Text = relat.Rows[q + 4]["TX"].ToString();
                            }

                            c--;
                            if (c > 0)
                            {
                                txt190.Text = relat.Rows[q + 5]["TX"].ToString();
                            }

                            c--;
                            if (c > 0)
                            {
                                txt191.Text = relat.Rows[q + 6]["TX"].ToString();
                            }

                            c--;
                            if (c > 0)
                            {
                                txt192.Text = relat.Rows[q + 7]["TX"].ToString();
                            }

                            c--;
                            if (c > 0)
                            {
                                txt193.Text = relat.Rows[q + 8]["TX"].ToString();
                            }

                            c--;
                            if (c > 0)
                            {
                                txt194.Text = relat.Rows[q + 9]["TX"].ToString();
                            }

                            c--;
                            if (c > 0)
                            {
                                txt195.Text = relat.Rows[q + 10]["TX"].ToString();
                            }

                            c--;
                            if (c > 0)
                            {
                                txt196.Text = relat.Rows[q + 11]["TX"].ToString();
                            }

                            c--;
                            if (c > 0)
                            {
                                txt197.Text = relat.Rows[q + 12]["TX"].ToString();
                            }

                            c--;
                            if (c > 0)
                            {
                                txt198.Text = relat.Rows[q + 13]["TX"].ToString();
                            }

                            c--;
                            if (c > 0)
                            {
                                txt199.Text = relat.Rows[q + 14]["TX"].ToString();
                            }

                            c--;
                            if (c > 0)
                            {
                                txt200.Text = relat.Rows[q + 15]["TX"].ToString();
                            }

                            c--;
                            if (c > 0)
                            {
                                txt201.Text = relat.Rows[q + 16]["TX"].ToString();
                            }

                            c--;
                            if (c > 0)
                            {
                                txt202.Text = relat.Rows[q + 17]["TX"].ToString();
                            }

                            c--;
                            if (c > 0)
                            {
                                txt203.Text = relat.Rows[q + 18]["TX"].ToString();
                            }

                            c--;
                            if (c > 0)
                            {
                                txt204.Text = relat.Rows[q + 19]["TX"].ToString();
                            }

                            c--;
                            if (c > 0)
                            {
                                txt205.Text = relat.Rows[q + 20]["TX"].ToString();
                            }

                            c--;
                            if (c > 0)
                            {
                                txt206.Text = relat.Rows[q + 21]["TX"].ToString();
                            }

                            c--;
                            if (c > 0)
                            {
                                txt207.Text = relat.Rows[q + 22]["TX"].ToString();
                            }

                            c--;
                            if (c > 0)
                            {
                                txt208.Text = relat.Rows[q + 23]["TX"].ToString();
                            }

                            c--;
                            if (c > 0)
                            {
                                txt209_.Text = relat.Rows[q + 24]["TX"].ToString();
                            }

                            c--;
                            if (c > 0)
                            {
                                txt210_.Text = relat.Rows[q + 25]["TX"].ToString();
                            }

                            c--;
                            if (c > 0)
                            {
                                txt211_.Text = relat.Rows[q + 26]["TX"].ToString();
                            }

                            c--;
                            if (c > 0)
                            {
                                txt212_.Text = relat.Rows[q + 27]["TX"].ToString();
                            }


                            c = qtde;
                            //total
                            txt24.Text = relat.Rows[q]["Total"].ToString();
                            c--;
                            if (c > 0)
                            {
                                txt213_.Text = relat.Rows[q + 1]["Total"].ToString();
                            }

                            c--;
                            if (c > 0)
                            {
                                txt214_.Text = relat.Rows[q + 2]["Total"].ToString();
                            }

                            c--;
                            if (c > 0)
                            {
                                txt215_.Text = relat.Rows[q + 3]["Total"].ToString();
                            }

                            c--;
                            if (c > 0)
                            {
                                txt216_.Text = relat.Rows[q + 4]["Total"].ToString();
                            }

                            c--;
                            if (c > 0)
                            {
                                txt217_.Text = relat.Rows[q + 5]["Total"].ToString();
                            }

                            c--;
                            if (c > 0)
                            {
                                txt218_.Text = relat.Rows[q + 6]["Total"].ToString();
                            }

                            c--;
                            if (c > 0)
                            {
                                txt219_.Text = relat.Rows[q + 7]["Total"].ToString();
                            }

                            c--;
                            if (c > 0)
                            {
                                txt220_.Text = relat.Rows[q + 8]["Total"].ToString();
                            }

                            c--;
                            if (c > 0)
                            {
                                txt221_.Text = relat.Rows[q + 9]["Total"].ToString();
                            }

                            c--;
                            if (c > 0)
                            {
                                txt222_.Text = relat.Rows[q + 10]["Total"].ToString();
                            }

                            c--;
                            if (c > 0)
                            {
                                txt223.Text = relat.Rows[q + 11]["Total"].ToString();
                            }

                            c--;
                            if (c > 0)
                            {
                                txt224.Text = relat.Rows[q + 12]["Total"].ToString();
                            }

                            c--;
                            if (c > 0)
                            {
                                txt225.Text = relat.Rows[q + 13]["Total"].ToString();
                            }

                            c--;
                            if (c > 0)
                            {
                                txt226.Text = relat.Rows[q + 14]["Total"].ToString();
                            }

                            c--;
                            if (c > 0)
                            {
                                txt227.Text = relat.Rows[q + 15]["Total"].ToString();
                            }

                            c--;
                            if (c > 0)
                            {
                                txt228.Text = relat.Rows[q + 16]["Total"].ToString();
                            }

                            c--;
                            if (c > 0)
                            {
                                txt229.Text = relat.Rows[q + 17]["Total"].ToString();
                            }

                            c--;
                            if (c > 0)
                            {
                                txt230.Text = relat.Rows[q + 18]["Total"].ToString();
                            }

                            c--;
                            if (c > 0)
                            {
                                txt231.Text = relat.Rows[q + 19]["Total"].ToString();
                            }

                            c--;
                            if (c > 0)
                            {
                                txt232.Text = relat.Rows[q + 20]["Total"].ToString();

                            }

                            c--;
                            if (c > 0)
                            {
                                txt233.Text = relat.Rows[q + 21]["Total"].ToString();
                            }

                            c--;
                            if (c > 0)
                            {
                                txt234.Text = relat.Rows[q + 22]["Total"].ToString();
                            }

                            c--;
                            if (c > 0)
                            {
                                txt235.Text = relat.Rows[q + 23]["Total"].ToString();
                            }

                            c--;
                            if (c > 0)
                            {
                                txt236.Text = relat.Rows[q + 24]["Total"].ToString();
                            }

                            c--;
                            if (c > 0)
                            {
                                txt237.Text = relat.Rows[q + 25]["Total"].ToString();
                            }

                            c--;
                            if (c > 0)
                            {
                                txt238.Text = relat.Rows[q + 26]["Total"].ToString();
                            }

                            c--;
                            if (c > 0)
                            {
                                txt239.Text = relat.Rows[q + 27]["Total"].ToString();

                            }

                            c = qtde;
                            //multa
                            txt25.Text = relat.Rows[q]["Multa"].ToString();
                            c--;
                            if (c > 0)
                            {
                                txt240.Text = relat.Rows[q + 1]["Multa"].ToString();
                            }

                            c--;
                            if (c > 0)
                            {
                                txt241.Text = relat.Rows[q + 2]["Multa"].ToString();
                            }

                            c--;
                            if (c > 0)
                            {
                                txt242_.Text = relat.Rows[q + 3]["Multa"].ToString();
                            }

                            c--;
                            if (c > 0)
                            {
                                txt243_.Text = relat.Rows[q + 4]["Multa"].ToString();
                            }

                            c--;
                            if (c > 0)
                            {
                                txt244_.Text = relat.Rows[q + 5]["Multa"].ToString();
                            }

                            c--;
                            if (c > 0)
                            {
                                txt245_.Text = relat.Rows[q + 6]["Multa"].ToString();
                            }

                            c--;
                            if (c > 0)
                            {
                                txt246_.Text = relat.Rows[q + 7]["Multa"].ToString();
                            }

                            c--;
                            if (c > 0)
                            {
                                txt247_.Text = relat.Rows[q + 8]["Multa"].ToString();
                            }

                            c--;
                            if (c > 0)
                            {
                                txt248_.Text = relat.Rows[q + 9]["Multa"].ToString();
                            }

                            c--;
                            if (c > 0)
                            {
                                txt249_.Text = relat.Rows[q + 10]["Multa"].ToString();
                            }

                            c--;
                            if (c > 0)
                            {
                                txt250_.Text = relat.Rows[q + 11]["Multa"].ToString();
                            }

                            c--;
                            if (c > 0)
                            {
                                txt251_.Text = relat.Rows[q + 12]["Multa"].ToString();
                            }

                            c--;
                            if (c > 0)
                            {
                                txt252_.Text = relat.Rows[q + 13]["Multa"].ToString();
                            }

                            c--;
                            if (c > 0)
                            {
                                txt253_.Text = relat.Rows[q + 14]["Multa"].ToString();
                            }

                            c--;
                            if (c > 0)
                            {
                                txt254_.Text = relat.Rows[q + 15]["Multa"].ToString();
                            }

                            c--;
                            if (c > 0)
                            {
                                txt255_.Text = relat.Rows[q + 16]["Multa"].ToString();
                            }

                            c--;
                            if (c > 0)
                            {
                                txt256_.Text = relat.Rows[q + 17]["Multa"].ToString();
                            }

                            c--;
                            if (c > 0)
                            {
                                txt257_.Text = relat.Rows[q + 18]["Multa"].ToString();
                            }

                            c--;
                            if (c > 0)
                            {
                                txt258_.Text = relat.Rows[q + 19]["Multa"].ToString();
                            }

                            c--;
                            if (c > 0)
                            {
                                txt259_.Text = relat.Rows[q + 20]["Multa"].ToString();
                            }

                            c--;
                            if (c > 0)
                            {
                                txt260.Text = relat.Rows[q + 21]["Multa"].ToString();
                            }

                            c--;
                            if (c > 0)
                            {
                                txt261.Text = relat.Rows[q + 22]["Multa"].ToString();
                            }

                            c--;
                            if (c > 0)
                            {
                                txt262.Text = relat.Rows[q + 23]["Multa"].ToString();
                            }

                            c--;
                            if (c > 0)
                            {
                                txt263.Text = relat.Rows[q + 24]["Multa"].ToString();
                            }

                            c--;
                            if (c > 0)
                            {
                                txt264.Text = relat.Rows[q + 25]["Multa"].ToString();
                            }

                            c--;
                            if (c > 0)
                            {
                                txt265.Text = relat.Rows[q + 26]["Multa"].ToString();
                            }

                            c--;
                            if (c > 0)
                            {
                                txt266.Text = relat.Rows[q + 27]["Multa"].ToString();

                            }

                            c = qtde;
                            //atraso
                            txt26.Text = relat.Rows[q]["Atraso"].ToString();
                            c--;
                            if (c > 0)
                            {
                                txt267.Text = relat.Rows[q + 1]["Atraso"].ToString();
                            }
                            else
                            {
                                txt267.Text = "";
                            }

                            c--;
                            if (c > 0)
                            {
                                txt268.Text = relat.Rows[q + 2]["Atraso"].ToString();
                            }
                            else
                            {
                                txt268.Text = "";
                            }

                            c--;
                            if (c > 0)
                            {
                                txt269.Text = relat.Rows[q + 3]["Atraso"].ToString();
                            }
                            else
                            {
                                txt269.Text = "";
                            }

                            c--;
                            if (c > 0)
                            {
                                txt270.Text = relat.Rows[q + 4]["Atraso"].ToString();
                            }
                            else
                            {
                                txt270.Text = "";
                            }

                            c--;
                            if (c > 0)
                            {
                                txt271.Text = relat.Rows[q + 5]["Atraso"].ToString();
                            }
                            else
                            {
                                txt271.Text = "";
                            }

                            c--;
                            if (c > 0)
                            {
                                txt272.Text = relat.Rows[q + 6]["Atraso"].ToString();
                            }
                            else
                            {
                                txt272.Text = "";
                            }

                            c--;
                            if (c > 0)
                            {
                                txt273.Text = relat.Rows[q + 7]["Atraso"].ToString();
                            }
                            else
                            {
                                txt273.Text = "";
                            }

                            c--;
                            if (c > 0)
                            {
                                txt274.Text = relat.Rows[q + 8]["Atraso"].ToString();
                            }
                            else
                            {
                                txt274.Text = "";
                            }

                            c--;
                            if (c > 0)
                            {
                                txt275.Text = relat.Rows[q + 9]["Atraso"].ToString();
                            }
                            else
                            {
                                txt275.Text = "";
                            }

                            c--;
                            if (c > 0)
                            {
                                txt276.Text = relat.Rows[q + 10]["Atraso"].ToString();
                            }
                            else
                            {
                                txt276.Text = "";
                            }

                            c--;
                            if (c > 0)
                            {
                                txt277.Text = relat.Rows[q + 11]["Atraso"].ToString();
                            }
                            else
                            {
                                txt277.Text = "";
                            }

                            c--;
                            if (c > 0)
                            {
                                txt278.Text = relat.Rows[q + 12]["Atraso"].ToString();
                            }
                            else
                            {
                                txt278.Text = "";
                            }

                            c--;
                            if (c > 0)
                            {
                                txt279.Text = relat.Rows[q + 13]["Atraso"].ToString();
                            }
                            else
                            {
                                txt279.Text = "";
                            }

                            c--;
                            if (c > 0)
                            {
                                txt280.Text = relat.Rows[q + 14]["Atraso"].ToString();
                            }
                            else
                            {
                                txt280.Text = "";
                            }

                            c--;
                            if (c > 0)
                            {
                                txt281.Text = relat.Rows[q + 15]["Atraso"].ToString();
                            }
                            else
                            {
                                txt281.Text = "";
                            }

                            c--;
                            if (c > 0)
                            {
                                txt282.Text = relat.Rows[q + 16]["Atraso"].ToString();
                            }
                            else
                            {
                                txt282.Text = "";
                            }

                            c--;
                            if (c > 0)
                            {
                                txt283.Text = relat.Rows[q + 17]["Atraso"].ToString();
                            }
                            else
                            {
                                txt283.Text = "";
                            }

                            c--;
                            if (c > 0)
                            {
                                txt284.Text = relat.Rows[q + 18]["Atraso"].ToString();
                            }
                            else
                            {
                                txt284.Text = "";
                            }

                            c--;
                            if (c > 0)
                            {
                                txt285.Text = relat.Rows[q + 19]["Atraso"].ToString();
                            }
                            else
                            {
                                txt285.Text = "";
                            }

                            c--;
                            if (c > 0)
                            {
                                txt286.Text = relat.Rows[q + 20]["Atraso"].ToString();
                            }
                            else
                            {
                                txt286.Text = "";
                            }

                            c--;
                            if (c > 0)
                            {
                                txt287.Text = relat.Rows[q + 21]["Atraso"].ToString();
                            }
                            else
                            {
                                txt287.Text = "";
                            }

                            c--;
                            if (c > 0)
                            {
                                txt288.Text = relat.Rows[q + 22]["Atraso"].ToString();
                            }
                            else
                            {
                                txt288.Text = "";
                            }

                            c--;
                            if (c > 0)
                            {
                                txt289.Text = relat.Rows[q + 23]["Atraso"].ToString();
                            }
                            else
                            {
                                txt289.Text = "";
                            }

                            c--;
                            if (c > 0)
                            {
                                txt290.Text = relat.Rows[q + 24]["Atraso"].ToString();
                            }
                            else
                            {
                                txt290.Text = "";
                            }

                            c--;
                            if (c > 0)
                            {
                                txt291.Text = relat.Rows[q + 25]["Atraso"].ToString();
                            }
                            else
                            {
                                txt291.Text = "";
                            }

                            c--;
                            if (c > 0)
                            {
                                txt292.Text = relat.Rows[q + 26]["Atraso"].ToString();
                            }
                            else
                            {
                                txt292.Text = "";
                            }

                            c--;
                            if (c > 0)
                            {
                                txt293.Text = relat.Rows[q + 27]["Atraso"].ToString();
                            }
                            else
                            {
                                txt293.Text = "";
                            }



                        }






                        crystalReportViewer1.ReportSource = rpt1;
                        crystalReportViewer1.Refresh();

                        string message1 = "Deseja Imprimir o relatório?";
                        string caption1 = "Reimpressão";
                        MessageBoxButtons buttons1 = MessageBoxButtons.YesNo;
                        DialogResult result1;

                        // Displays the MessageBox.

                        result1 = MessageBox.Show(this, message1, caption1, buttons1,
                        MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);


                        if (result == DialogResult.No)
                        {

                        }
                        if (result == DialogResult.Yes)
                        {
                            rpt1.PrintToPrinter(1, false, 0, 0);
                            rpt1.PrintToPrinter(1, false, 0, 0);
                            Form print1 = new Print("Imprimindo o Relatório");
                            print1.ShowDialog();
                        }

                        // crystalReportViewer1.PrintReport();
                        

                        q = q + 28;
                        qtde = qtde - 28;

                        if (qtde <= 0)
                        {
                            imprime = false;
                        }

                    }


                    //******************************************
                    //Imprimir leitura
                    //******************************************

                    TextObject txt17__ = (TextObject)rpt2.ReportDefinition.ReportObjects["Text17"]; //Instancie um objeto do tipo TextObject e informe o nome do textbox
                    txt17__.Text = "";
                    TextObject txt8__ = (TextObject)rpt2.ReportDefinition.ReportObjects["Text8"]; //Instancie um objeto do tipo TextObject e informe o nome do textbox
                    txt8__.Text = "";
                    TextObject txt7__ = (TextObject)rpt2.ReportDefinition.ReportObjects["Text7"]; //Instancie um objeto do tipo TextObject e informe o nome do textbox
                    txt7__.Text = "";
                    TextObject txt14__ = (TextObject)rpt2.ReportDefinition.ReportObjects["Text14"]; //Instancie um objeto do tipo TextObject e informe o nome do textbox
                    txt14__.Text = "";
                    TextObject txt42__ = (TextObject)rpt2.ReportDefinition.ReportObjects["Text42"]; //Instancie um objeto do tipo TextObject e informe o nome do textbox
                    txt42__.Text = "";
                    TextObject txt27__ = (TextObject)rpt2.ReportDefinition.ReportObjects["Text27"]; //Instancie um objeto do tipo TextObject e informe o nome do textbox
                    txt27__.Text = "";
                    TextObject txt44__ = (TextObject)rpt2.ReportDefinition.ReportObjects["Text44"]; //Instancie um objeto do tipo TextObject e informe o nome do textbox
                    txt44__.Text = "";
                    TextObject txt10__ = (TextObject)rpt2.ReportDefinition.ReportObjects["Text10"]; //Instancie um objeto do tipo TextObject e informe o nome do textbox
                    txt10__.Text = "";
                    TextObject txt11__ = (TextObject)rpt2.ReportDefinition.ReportObjects["Text11"]; //Instancie um objeto do tipo TextObject e informe o nome do textbox
                    txt11__.Text = "";
                    TextObject txt12__ = (TextObject)rpt2.ReportDefinition.ReportObjects["Text12"]; //Instancie um objeto do tipo TextObject e informe o nome do textbox
                    txt12__.Text = "";
                    TextObject txt13__ = (TextObject)rpt2.ReportDefinition.ReportObjects["Text13"]; //Instancie um objeto do tipo TextObject e informe o nome do textbox
                    txt13__.Text = "";
                    TextObject txt15__ = (TextObject)rpt2.ReportDefinition.ReportObjects["Text15"]; //Instancie um objeto do tipo TextObject e informe o nome do textbox
                    txt15__.Text = "";
                    TextObject txt18__ = (TextObject)rpt2.ReportDefinition.ReportObjects["Text18"]; //Instancie um objeto do tipo TextObject e informe o nome do textbox
                    txt18__.Text = "";
                    TextObject txt19__ = (TextObject)rpt2.ReportDefinition.ReportObjects["Text19"]; //Instancie um objeto do tipo TextObject e informe o nome do textbox
                    txt19__.Text = "";
                    TextObject txt28__ = (TextObject)rpt2.ReportDefinition.ReportObjects["Text28"]; //Instancie um objeto do tipo TextObject e informe o nome do textbox
                    txt28__.Text = "";
                    TextObject txt29__ = (TextObject)rpt2.ReportDefinition.ReportObjects["Text29"]; //Instancie um objeto do tipo TextObject e informe o nome do textbox
                    txt29__.Text = "";
                    TextObject txt30__ = (TextObject)rpt2.ReportDefinition.ReportObjects["Text30"]; //Instancie um objeto do tipo TextObject e informe o nome do textbox
                    txt30__.Text = "";
                    TextObject txt31__ = (TextObject)rpt2.ReportDefinition.ReportObjects["Text31"]; //Instancie um objeto do tipo TextObject e informe o nome do textbox
                    txt31__.Text = "";
                    TextObject txt32__ = (TextObject)rpt2.ReportDefinition.ReportObjects["Text32"]; //Instancie um objeto do tipo TextObject e informe o nome do textbox
                    txt32__.Text = "";
                    TextObject txt33__ = (TextObject)rpt2.ReportDefinition.ReportObjects["Text33"]; //Instancie um objeto do tipo TextObject e informe o nome do textbox
                    txt33__.Text = "";
                    TextObject txt34__ = (TextObject)rpt2.ReportDefinition.ReportObjects["Text34"]; //Instancie um objeto do tipo TextObject e informe o nome do textbox
                    txt34__.Text = "";
                    TextObject txt35__ = (TextObject)rpt2.ReportDefinition.ReportObjects["Text35"]; //Instancie um objeto do tipo TextObject e informe o nome do textbox
                    txt35__.Text = "";
                    TextObject txt36__ = (TextObject)rpt2.ReportDefinition.ReportObjects["Text36"]; //Instancie um objeto do tipo TextObject e informe o nome do textbox
                    txt36__.Text = "";
                    TextObject txt37__ = (TextObject)rpt2.ReportDefinition.ReportObjects["Text37"]; //Instancie um objeto do tipo TextObject e informe o nome do textbox
                    txt37__.Text = "";
                    TextObject txt38__ = (TextObject)rpt2.ReportDefinition.ReportObjects["Text38"]; //Instancie um objeto do tipo TextObject e informe o nome do textbox
                    txt38__.Text = "";
                    TextObject txt39__ = (TextObject)rpt2.ReportDefinition.ReportObjects["Text39"]; //Instancie um objeto do tipo TextObject e informe o nome do textbox
                    txt39__.Text = "";
                    TextObject txt40__ = (TextObject)rpt2.ReportDefinition.ReportObjects["Text40"]; //Instancie um objeto do tipo TextObject e informe o nome do textbox
                    txt40__.Text = "";
                    TextObject txt41__ = (TextObject)rpt2.ReportDefinition.ReportObjects["Text41"]; //Instancie um objeto do tipo TextObject e informe o nome do textbox
                    txt41__.Text = "";
                    TextObject txt45__ = (TextObject)rpt2.ReportDefinition.ReportObjects["Text45"]; //Instancie um objeto do tipo TextObject e informe o nome do textbox
                    txt45__.Text = "";
                    TextObject txt46__ = (TextObject)rpt2.ReportDefinition.ReportObjects["Text46"]; //Instancie um objeto do tipo TextObject e informe o nome do textbox
                    txt46__.Text = "";
                    TextObject txt47__ = (TextObject)rpt2.ReportDefinition.ReportObjects["Text47"]; //Instancie um objeto do tipo TextObject e informe o nome do textbox
                    txt47__.Text = "";
                    TextObject txt48__ = (TextObject)rpt2.ReportDefinition.ReportObjects["Text48"]; //Instancie um objeto do tipo TextObject e informe o nome do textbox
                    txt48__.Text = "";
                    TextObject txt51__ = (TextObject)rpt2.ReportDefinition.ReportObjects["Text51"]; //Instancie um objeto do tipo TextObject e informe o nome do textbox
                    txt51__.Text = "";
                    TextObject txt52__ = (TextObject)rpt2.ReportDefinition.ReportObjects["Text52"]; //Instancie um objeto do tipo TextObject e informe o nome do textbox
                    txt52__.Text = "";
                    TextObject txt20__ = (TextObject)rpt2.ReportDefinition.ReportObjects["Text20"]; //Instancie um objeto do tipo TextObject e informe o nome do textbox
                    txt20__.Text = "";
                    TextObject txt21__ = (TextObject)rpt2.ReportDefinition.ReportObjects["Text21"]; //Instancie um objeto do tipo TextObject e informe o nome do textbox
                    txt21__.Text = "";
                    TextObject txt22__ = (TextObject)rpt2.ReportDefinition.ReportObjects["Text22"]; //Instancie um objeto do tipo TextObject e informe o nome do textbox
                    txt22__.Text = "";


                    TextObject txt24__ = (TextObject)rpt2.ReportDefinition.ReportObjects["Text24"]; //Instancie um objeto do tipo TextObject e informe o nome do textbox
                    txt24__.Text = "";
                    TextObject txt25__ = (TextObject)rpt2.ReportDefinition.ReportObjects["Text25"]; //Instancie um objeto do tipo TextObject e informe o nome do textbox
                    txt25__.Text = "";
                    TextObject txt26__ = (TextObject)rpt2.ReportDefinition.ReportObjects["Text26"]; //Instancie um objeto do tipo TextObject e informe o nome do textbox
                    txt26__.Text = "";
                    TextObject txt43__ = (TextObject)rpt2.ReportDefinition.ReportObjects["Text43"]; //Instancie um objeto do tipo TextObject e informe o nome do textbox
                    txt43__.Text = "";
                    TextObject txt49__ = (TextObject)rpt2.ReportDefinition.ReportObjects["Text49"]; //Instancie um objeto do tipo TextObject e informe o nome do textbox
                    txt49__.Text = "";
                    TextObject txt50__ = (TextObject)rpt2.ReportDefinition.ReportObjects["Text50"]; //Instancie um objeto do tipo TextObject e informe o nome do textbox
                    txt50__.Text = "";
                    TextObject txt53__ = (TextObject)rpt2.ReportDefinition.ReportObjects["Text53"]; //Instancie um objeto do tipo TextObject e informe o nome do textbox
                    txt53__.Text = "";
                    TextObject txt54__ = (TextObject)rpt2.ReportDefinition.ReportObjects["Text54"]; //Instancie um objeto do tipo TextObject e informe o nome do textbox
                    txt54__.Text = "";
                    TextObject txt55__ = (TextObject)rpt2.ReportDefinition.ReportObjects["Text55"]; //Instancie um objeto do tipo TextObject e informe o nome do textbox
                    txt55__.Text = "";
                    TextObject txt56__ = (TextObject)rpt2.ReportDefinition.ReportObjects["Text56"]; //Instancie um objeto do tipo TextObject e informe o nome do textbox
                    txt56__.Text = "";
                    TextObject txt57__ = (TextObject)rpt2.ReportDefinition.ReportObjects["Text57"]; //Instancie um objeto do tipo TextObject e informe o nome do textbox
                    txt57__.Text = "";
                    TextObject txt58__ = (TextObject)rpt2.ReportDefinition.ReportObjects["Text58"]; //Instancie um objeto do tipo TextObject e informe o nome do textbox
                    txt58__.Text = "";
                    TextObject txt59__ = (TextObject)rpt2.ReportDefinition.ReportObjects["Text59"]; //Instancie um objeto do tipo TextObject e informe o nome do textbox
                    txt59__.Text = "";
                    TextObject txt60__ = (TextObject)rpt2.ReportDefinition.ReportObjects["Text60"]; //Instancie um objeto do tipo TextObject e informe o nome do textbox
                    txt60__.Text = "";
                    TextObject txt61__ = (TextObject)rpt2.ReportDefinition.ReportObjects["Text61"]; //Instancie um objeto do tipo TextObject e informe o nome do textbox
                    txt61__.Text = "";
                    TextObject txt62__ = (TextObject)rpt2.ReportDefinition.ReportObjects["Text62"]; //Instancie um objeto do tipo TextObject e informe o nome do textbox
                    txt62__.Text = "";
                    TextObject txt63__ = (TextObject)rpt2.ReportDefinition.ReportObjects["Text63"]; //Instancie um objeto do tipo TextObject e informe o nome do textbox
                    txt63__.Text = "";
                    TextObject txt64__ = (TextObject)rpt2.ReportDefinition.ReportObjects["Text64"]; //Instancie um objeto do tipo TextObject e informe o nome do textbox
                    txt64__.Text = "";
                    TextObject txt65__ = (TextObject)rpt2.ReportDefinition.ReportObjects["Text65"]; //Instancie um objeto do tipo TextObject e informe o nome do textbox
                    txt65__.Text = "";
                    TextObject txt66__ = (TextObject)rpt2.ReportDefinition.ReportObjects["Text66"]; //Instancie um objeto do tipo TextObject e informe o nome do textbox
                    txt66__.Text = "";
                    TextObject txt67__ = (TextObject)rpt2.ReportDefinition.ReportObjects["Text67"]; //Instancie um objeto do tipo TextObject e informe o nome do textbox
                    txt67__.Text = "";
                    TextObject txt68__ = (TextObject)rpt2.ReportDefinition.ReportObjects["Text68"]; //Instancie um objeto do tipo TextObject e informe o nome do textbox
                    txt68__.Text = "";
                    TextObject txt69__ = (TextObject)rpt2.ReportDefinition.ReportObjects["Text69"]; //Instancie um objeto do tipo TextObject e informe o nome do textbox
                    txt69__.Text = "";
                    TextObject txt70__ = (TextObject)rpt2.ReportDefinition.ReportObjects["Text70"]; //Instancie um objeto do tipo TextObject e informe o nome do textbox
                    txt70__.Text = "";
                    TextObject txt71__ = (TextObject)rpt2.ReportDefinition.ReportObjects["Text71"]; //Instancie um objeto do tipo TextObject e informe o nome do textbox
                    txt71__.Text = "";
                    TextObject txt72__ = (TextObject)rpt2.ReportDefinition.ReportObjects["Text72"]; //Instancie um objeto do tipo TextObject e informe o nome do textbox
                    txt72__.Text = "";
                    TextObject txt73__ = (TextObject)rpt2.ReportDefinition.ReportObjects["Text73"]; //Instancie um objeto do tipo TextObject e informe o nome do textbox
                    txt73__.Text = "";
                    TextObject txt74__ = (TextObject)rpt2.ReportDefinition.ReportObjects["Text74"]; //Instancie um objeto do tipo TextObject e informe o nome do textbox
                    txt74__.Text = "";
                    TextObject txt75__ = (TextObject)rpt2.ReportDefinition.ReportObjects["Text75"]; //Instancie um objeto do tipo TextObject e informe o nome do textbox
                    txt75__.Text = "";
                    TextObject txt76__ = (TextObject)rpt2.ReportDefinition.ReportObjects["Text76"]; //Instancie um objeto do tipo TextObject e informe o nome do textbox
                    txt76__.Text = "";
                    TextObject txt77__ = (TextObject)rpt2.ReportDefinition.ReportObjects["Text77"]; //Instancie um objeto do tipo TextObject e informe o nome do textbox
                    txt77__.Text = "";
                    TextObject txt78__ = (TextObject)rpt2.ReportDefinition.ReportObjects["Text78"]; //Instancie um objeto do tipo TextObject e informe o nome do textbox
                    txt78__.Text = "";
                    TextObject txt79__ = (TextObject)rpt2.ReportDefinition.ReportObjects["Text79"]; //Instancie um objeto do tipo TextObject e informe o nome do textbox
                    txt79__.Text = "";
                    TextObject txt80__ = (TextObject)rpt2.ReportDefinition.ReportObjects["Text80"]; //Instancie um objeto do tipo TextObject e informe o nome do textbox
                    txt80__.Text = "";
                    TextObject txt81__ = (TextObject)rpt2.ReportDefinition.ReportObjects["Text81"]; //Instancie um objeto do tipo TextObject e informe o nome do textbox
                    txt81__.Text = "";
                    TextObject txt82__ = (TextObject)rpt2.ReportDefinition.ReportObjects["Text82"]; //Instancie um objeto do tipo TextObject e informe o nome do textbox
                    txt82__.Text = "";
                    TextObject txt83__ = (TextObject)rpt2.ReportDefinition.ReportObjects["Text83"]; //Instancie um objeto do tipo TextObject e informe o nome do textbox
                    txt83__.Text = "";


                    DataTable l = DAL.Lista_Leitura();
                    bool imprime2 = true;
                    int qtde2 = l.Rows.Count;
                    int b = 0;

                    while (imprime2 == true)
                    {
                        if (qtde2 >= 37)
                        {
                            //preencher páginas inteiras
                            txt17__.Text = l.Rows[b]["Nome"].ToString();
                            txt8__.Text = l.Rows[b + 1]["Nome"].ToString();
                            txt7__.Text = l.Rows[b + 2]["Nome"].ToString();
                            txt14__.Text = l.Rows[b + 3]["Nome"].ToString();
                            txt42__.Text = l.Rows[b + 4]["Nome"].ToString();
                            txt27__.Text = l.Rows[b + 5]["Nome"].ToString();
                            txt44__.Text = l.Rows[b + 6]["Nome"].ToString();
                            txt10__.Text = l.Rows[b + 7]["Nome"].ToString();
                            txt11__.Text = l.Rows[b + 8]["Nome"].ToString();
                            txt12__.Text = l.Rows[b + 9]["Nome"].ToString();
                            txt13__.Text = l.Rows[b + 10]["Nome"].ToString();
                            txt15__.Text = l.Rows[b + 11]["Nome"].ToString();
                            txt18__.Text = l.Rows[b + 12]["Nome"].ToString();
                            txt19__.Text = l.Rows[b + 13]["Nome"].ToString();
                            txt28__.Text = l.Rows[b + 14]["Nome"].ToString();
                            txt29__.Text = l.Rows[b + 15]["Nome"].ToString();
                            txt30__.Text = l.Rows[b + 16]["Nome"].ToString();
                            txt31__.Text = l.Rows[b + 17]["Nome"].ToString();
                            txt32__.Text = l.Rows[b + 18]["Nome"].ToString();
                            txt33__.Text = l.Rows[b + 19]["Nome"].ToString();
                            txt34__.Text = l.Rows[b + 20]["Nome"].ToString();
                            txt35__.Text = l.Rows[b + 21]["Nome"].ToString();
                            txt36__.Text = l.Rows[b + 22]["Nome"].ToString();
                            txt37__.Text = l.Rows[b + 23]["Nome"].ToString();
                            txt38__.Text = l.Rows[b + 24]["Nome"].ToString();
                            txt39__.Text = l.Rows[b + 25]["Nome"].ToString();
                            txt40__.Text = l.Rows[b + 26]["Nome"].ToString();
                            txt41__.Text = l.Rows[b + 27]["Nome"].ToString();
                            txt45__.Text = l.Rows[b + 28]["Nome"].ToString();
                            txt46__.Text = l.Rows[b + 29]["Nome"].ToString();
                            txt47__.Text = l.Rows[b + 30]["Nome"].ToString();
                            txt48__.Text = l.Rows[b + 31]["Nome"].ToString();
                            txt51__.Text = l.Rows[b + 32]["Nome"].ToString();
                            txt52__.Text = l.Rows[b + 33]["Nome"].ToString();
                            txt20__.Text = l.Rows[b + 34]["Nome"].ToString();
                            txt21__.Text = l.Rows[b + 35]["Nome"].ToString();
                            txt22__.Text = l.Rows[b + 36]["Nome"].ToString();

                            if (Convert.ToInt32(l.Rows[b]["Atual"].ToString()) < Convert.ToInt32(l.Rows[b]["Anterior"].ToString()))
                            {
                                txt24__.Text = l.Rows[b]["Anterior"].ToString();
                            }
                            if (Convert.ToInt32(l.Rows[b]["Atual"].ToString()) > Convert.ToInt32(l.Rows[b]["Anterior"].ToString()))
                            {
                                txt24__.Text = l.Rows[b]["Atual"].ToString();
                            }
                            if (String.IsNullOrEmpty(txt24__.Text) == true)
                            {
                                txt24__.Text = l.Rows[b]["Anterior"].ToString();
                            }


                            if (Convert.ToInt32(l.Rows[b + 1]["Atual"].ToString()) < Convert.ToInt32(l.Rows[b + 1]["Anterior"].ToString()))
                            {
                                txt25__.Text = l.Rows[b + 1]["Anterior"].ToString();
                            }
                            if (Convert.ToInt32(l.Rows[b + 1]["Atual"].ToString()) > Convert.ToInt32(l.Rows[b + 1]["Anterior"].ToString()))
                            {
                                txt25__.Text = l.Rows[b + 1]["Atual"].ToString();
                            }
                            if (String.IsNullOrEmpty(txt25__.Text) == true)
                            {
                                txt25__.Text = l.Rows[b + 1]["Anterior"].ToString();
                            }


                            if (Convert.ToInt32(l.Rows[b + 2]["Atual"].ToString()) < Convert.ToInt32(l.Rows[b + 2]["Anterior"].ToString()))
                            {
                                txt26__.Text = l.Rows[b + 2]["Anterior"].ToString();
                            }
                            if (Convert.ToInt32(l.Rows[b + 2]["Atual"].ToString()) > Convert.ToInt32(l.Rows[b + 2]["Anterior"].ToString()))
                            {
                                txt26__.Text = l.Rows[b + 2]["Atual"].ToString();
                            }
                            if (String.IsNullOrEmpty(txt26__.Text) == true)
                            {
                                txt26__.Text = l.Rows[b + 2]["Anterior"].ToString();
                            }


                            if (Convert.ToInt32(l.Rows[b + 3]["Atual"].ToString()) < Convert.ToInt32(l.Rows[b + 3]["Anterior"].ToString()))
                            {
                                txt43__.Text = l.Rows[b + 3]["Anterior"].ToString();
                            }
                            if (Convert.ToInt32(l.Rows[b + 3]["Atual"].ToString()) > Convert.ToInt32(l.Rows[b + 3]["Anterior"].ToString()))
                            {
                                txt43__.Text = l.Rows[b + 3]["Atual"].ToString();
                            }
                            if (String.IsNullOrEmpty(txt43__.Text) == true)
                            {
                                txt43__.Text = l.Rows[b + 3]["Anterior"].ToString();
                            }


                            if (Convert.ToInt32(l.Rows[b + 4]["Atual"].ToString()) < Convert.ToInt32(l.Rows[b + 4]["Anterior"].ToString()))
                            {
                                txt49__.Text = l.Rows[b + 4]["Anterior"].ToString();
                            }
                            if (Convert.ToInt32(l.Rows[b + 4]["Atual"].ToString()) > Convert.ToInt32(l.Rows[b + 4]["Anterior"].ToString()))
                            {
                                txt49__.Text = l.Rows[b + 4]["Atual"].ToString();
                            }
                            if (String.IsNullOrEmpty(txt49__.Text) == true)
                            {
                                txt49__.Text = l.Rows[b + 4]["Anterior"].ToString();
                            }


                            if (Convert.ToInt32(l.Rows[b + 5]["Atual"].ToString()) < Convert.ToInt32(l.Rows[b + 5]["Anterior"].ToString()))
                            {
                                txt50__.Text = l.Rows[b + 5]["Anterior"].ToString();
                            }
                            if (Convert.ToInt32(l.Rows[b + 5]["Atual"].ToString()) > Convert.ToInt32(l.Rows[b + 5]["Anterior"].ToString()))
                            {
                                txt50__.Text = l.Rows[b + 5]["Atual"].ToString();
                            }
                            if (String.IsNullOrEmpty(txt50__.Text) == true)
                            {
                                txt50__.Text = l.Rows[b + 5]["Anterior"].ToString();
                            }


                            if (Convert.ToInt32(l.Rows[b + 6]["Atual"].ToString()) < Convert.ToInt32(l.Rows[b + 6]["Anterior"].ToString()))
                            {
                                txt53__.Text = l.Rows[b + 6]["Anterior"].ToString();
                            }
                            if (Convert.ToInt32(l.Rows[b + 6]["Atual"].ToString()) > Convert.ToInt32(l.Rows[b + 6]["Anterior"].ToString()))
                            {
                                txt53__.Text = l.Rows[b + 6]["Atual"].ToString();
                            }
                            if (String.IsNullOrEmpty(txt53__.Text) == true)
                            {
                                txt53__.Text = l.Rows[b + 6]["Anterior"].ToString();
                            }


                            if (Convert.ToInt32(l.Rows[b + 7]["Atual"].ToString()) < Convert.ToInt32(l.Rows[b + 7]["Anterior"].ToString()))
                            {
                                txt54__.Text = l.Rows[b + 7]["Anterior"].ToString();
                            }
                            if (Convert.ToInt32(l.Rows[b + 7]["Atual"].ToString()) > Convert.ToInt32(l.Rows[b + 7]["Anterior"].ToString()))
                            {
                                txt54__.Text = l.Rows[b + 7]["Atual"].ToString();
                            }
                            if (String.IsNullOrEmpty(txt54__.Text) == true)
                            {
                                txt54__.Text = l.Rows[b + 7]["Anterior"].ToString();
                            }


                            if (Convert.ToInt32(l.Rows[b + 8]["Atual"].ToString()) < Convert.ToInt32(l.Rows[b + 8]["Anterior"].ToString()))
                            {
                                txt55__.Text = l.Rows[b + 8]["Anterior"].ToString();
                            }
                            if (Convert.ToInt32(l.Rows[b + 8]["Atual"].ToString()) > Convert.ToInt32(l.Rows[b + 8]["Anterior"].ToString()))
                            {
                                txt55__.Text = l.Rows[b + 8]["Atual"].ToString();
                            }
                            if (String.IsNullOrEmpty(txt55__.Text) == true)
                            {
                                txt55__.Text = l.Rows[b + 8]["Anterior"].ToString();
                            }


                            if (Convert.ToInt32(l.Rows[b + 9]["Atual"].ToString()) < Convert.ToInt32(l.Rows[b + 9]["Anterior"].ToString()))
                            {
                                txt56__.Text = l.Rows[b + 9]["Anterior"].ToString();
                            }
                            if (Convert.ToInt32(l.Rows[b + 9]["Atual"].ToString()) > Convert.ToInt32(l.Rows[b + 9]["Anterior"].ToString()))
                            {
                                txt56__.Text = l.Rows[b + 9]["Atual"].ToString();
                            }
                            if (String.IsNullOrEmpty(txt56__.Text) == true)
                            {
                                txt56__.Text = l.Rows[b + 9]["Anterior"].ToString();
                            }


                            if (Convert.ToInt32(l.Rows[b + 10]["Atual"].ToString()) < Convert.ToInt32(l.Rows[b + 10]["Anterior"].ToString()))
                            {
                                txt57__.Text = l.Rows[b + 10]["Anterior"].ToString();
                            }
                            if (Convert.ToInt32(l.Rows[b + 10]["Atual"].ToString()) > Convert.ToInt32(l.Rows[b + 10]["Anterior"].ToString()))
                            {
                                txt57__.Text = l.Rows[b + 10]["Atual"].ToString();
                            }
                            if (String.IsNullOrEmpty(txt57__.Text) == true)
                            {
                                txt57__.Text = l.Rows[b + 10]["Anterior"].ToString();
                            }


                            if (Convert.ToInt32(l.Rows[b + 11]["Atual"].ToString()) < Convert.ToInt32(l.Rows[b + 11]["Anterior"].ToString()))
                            {
                                txt58__.Text = l.Rows[b + 11]["Anterior"].ToString();
                            }
                            if (Convert.ToInt32(l.Rows[b + 11]["Atual"].ToString()) > Convert.ToInt32(l.Rows[b + 11]["Anterior"].ToString()))
                            {
                                txt58__.Text = l.Rows[b + 11]["Atual"].ToString();
                            }
                            if (String.IsNullOrEmpty(txt58__.Text) == true)
                            {
                                txt58__.Text = l.Rows[b + 11]["Anterior"].ToString();
                            }


                            if (Convert.ToInt32(l.Rows[b + 12]["Atual"].ToString()) < Convert.ToInt32(l.Rows[b + 12]["Anterior"].ToString()))
                            {
                                txt59__.Text = l.Rows[b + 12]["Anterior"].ToString();
                            }
                            if (Convert.ToInt32(l.Rows[b + 12]["Atual"].ToString()) > Convert.ToInt32(l.Rows[b + 12]["Anterior"].ToString()))
                            {
                                txt59__.Text = l.Rows[b + 12]["Atual"].ToString();
                            }
                            if (String.IsNullOrEmpty(txt59__.Text) == true)
                            {
                                txt59__.Text = l.Rows[b + 12]["Anterior"].ToString();
                            }


                            if (Convert.ToInt32(l.Rows[b + 13]["Atual"].ToString()) < Convert.ToInt32(l.Rows[b + 13]["Anterior"].ToString()))
                            {
                                txt60__.Text = l.Rows[b + 13]["Anterior"].ToString();
                            }
                            if (Convert.ToInt32(l.Rows[b + 13]["Atual"].ToString()) > Convert.ToInt32(l.Rows[b + 13]["Anterior"].ToString()))
                            {
                                txt60__.Text = l.Rows[b + 13]["Atual"].ToString();
                            }
                            if (String.IsNullOrEmpty(txt60__.Text) == true)
                            {
                                txt60__.Text = l.Rows[b + 13]["Anterior"].ToString();
                            }


                            if (Convert.ToInt32(l.Rows[b + 14]["Atual"].ToString()) < Convert.ToInt32(l.Rows[b + 14]["Anterior"].ToString()))
                            {
                                txt61__.Text = l.Rows[b + 14]["Anterior"].ToString();
                            }
                            if (Convert.ToInt32(l.Rows[b + 14]["Atual"].ToString()) > Convert.ToInt32(l.Rows[b + 14]["Anterior"].ToString()))
                            {
                                txt61__.Text = l.Rows[b + 14]["Atual"].ToString();
                            }
                            if (String.IsNullOrEmpty(txt61__.Text) == true)
                            {
                                txt61__.Text = l.Rows[b + 14]["Anterior"].ToString();
                            }


                            if (Convert.ToInt32(l.Rows[b + 15]["Atual"].ToString()) < Convert.ToInt32(l.Rows[b + 15]["Anterior"].ToString()))
                            {
                                txt62__.Text = l.Rows[b + 15]["Anterior"].ToString();
                            }
                            if (Convert.ToInt32(l.Rows[b + 15]["Atual"].ToString()) > Convert.ToInt32(l.Rows[b + 15]["Anterior"].ToString()))
                            {
                                txt62__.Text = l.Rows[b + 15]["Atual"].ToString();
                            }
                            if (String.IsNullOrEmpty(txt62__.Text) == true)
                            {
                                txt62__.Text = l.Rows[b + 15]["Anterior"].ToString();
                            }


                            if (Convert.ToInt32(l.Rows[b + 16]["Atual"].ToString()) < Convert.ToInt32(l.Rows[b + 16]["Anterior"].ToString()))
                            {
                                txt63__.Text = l.Rows[b + 16]["Anterior"].ToString();
                            }
                            if (Convert.ToInt32(l.Rows[b + 16]["Atual"].ToString()) > Convert.ToInt32(l.Rows[b + 16]["Anterior"].ToString()))
                            {
                                txt63__.Text = l.Rows[b + 16]["Atual"].ToString();
                            }
                            if (String.IsNullOrEmpty(txt63__.Text) == true)
                            {
                                txt63__.Text = l.Rows[b + 16]["Anterior"].ToString();
                            }


                            if (Convert.ToInt32(l.Rows[b + 17]["Atual"].ToString()) < Convert.ToInt32(l.Rows[b + 17]["Anterior"].ToString()))
                            {
                                txt64__.Text = l.Rows[b + 17]["Anterior"].ToString();
                            }
                            if (Convert.ToInt32(l.Rows[b + 17]["Atual"].ToString()) > Convert.ToInt32(l.Rows[b + 17]["Anterior"].ToString()))
                            {
                                txt64__.Text = l.Rows[b + 17]["Atual"].ToString();
                            }
                            if (String.IsNullOrEmpty(txt64__.Text) == true)
                            {
                                txt64__.Text = l.Rows[b + 17]["Anterior"].ToString();
                            }

                            if (Convert.ToInt32(l.Rows[b + 18]["Atual"].ToString()) < Convert.ToInt32(l.Rows[b + 18]["Anterior"].ToString()))
                            {
                                txt65__.Text = l.Rows[b + 18]["Anterior"].ToString();
                            }
                            if (Convert.ToInt32(l.Rows[b + 18]["Atual"].ToString()) > Convert.ToInt32(l.Rows[b + 18]["Anterior"].ToString()))
                            {
                                txt65__.Text = l.Rows[b + 18]["Atual"].ToString();
                            }
                            if (String.IsNullOrEmpty(txt65__.Text) == true)
                            {
                                txt65__.Text = l.Rows[b + 18]["Anterior"].ToString();
                            }


                            if (Convert.ToInt32(l.Rows[b + 19]["Atual"].ToString()) < Convert.ToInt32(l.Rows[b + 19]["Anterior"].ToString()))
                            {
                                txt66__.Text = l.Rows[b + 19]["Anterior"].ToString();
                            }
                            if (Convert.ToInt32(l.Rows[b + 19]["Atual"].ToString()) > Convert.ToInt32(l.Rows[b + 19]["Anterior"].ToString()))
                            {
                                txt66__.Text = l.Rows[b + 19]["Atual"].ToString();
                            }
                            if (String.IsNullOrEmpty(txt66__.Text) == true)
                            {
                                txt66__.Text = l.Rows[b + 19]["Anterior"].ToString();
                            }


                            if (Convert.ToInt32(l.Rows[b + 20]["Atual"].ToString()) < Convert.ToInt32(l.Rows[b + 20]["Anterior"].ToString()))
                            {
                                txt67__.Text = l.Rows[b + 20]["Anterior"].ToString();
                            }
                            if (Convert.ToInt32(l.Rows[b + 20]["Atual"].ToString()) > Convert.ToInt32(l.Rows[b + 20]["Anterior"].ToString()))
                            {
                                txt67__.Text = l.Rows[b + 20]["Atual"].ToString();
                            }
                            if (String.IsNullOrEmpty(txt67__.Text) == true)
                            {
                                txt67__.Text = l.Rows[b + 20]["Anterior"].ToString();
                            }


                            if (Convert.ToInt32(l.Rows[b + 21]["Atual"].ToString()) < Convert.ToInt32(l.Rows[b + 21]["Anterior"].ToString()))
                            {
                                txt68__.Text = l.Rows[b + 21]["Anterior"].ToString();
                            }
                            if (Convert.ToInt32(l.Rows[b + 21]["Atual"].ToString()) > Convert.ToInt32(l.Rows[b + 21]["Anterior"].ToString()))
                            {
                                txt68__.Text = l.Rows[b + 21]["Atual"].ToString();
                            }
                            if (String.IsNullOrEmpty(txt68__.Text) == true)
                            {
                                txt68__.Text = l.Rows[b + 21]["Anterior"].ToString();
                            }


                            if (Convert.ToInt32(l.Rows[b + 22]["Atual"].ToString()) < Convert.ToInt32(l.Rows[b + 22]["Anterior"].ToString()))
                            {
                                txt69__.Text = l.Rows[b + 22]["Anterior"].ToString();
                            }
                            if (Convert.ToInt32(l.Rows[b + 22]["Atual"].ToString()) > Convert.ToInt32(l.Rows[b + 22]["Anterior"].ToString()))
                            {
                                txt69__.Text = l.Rows[b + 22]["Atual"].ToString();
                            }
                            if (String.IsNullOrEmpty(txt69__.Text) == true)
                            {
                                txt69__.Text = l.Rows[b + 22]["Anterior"].ToString();
                            }


                            if (Convert.ToInt32(l.Rows[b + 23]["Atual"].ToString()) < Convert.ToInt32(l.Rows[b + 23]["Anterior"].ToString()))
                            {
                                txt70__.Text = l.Rows[b + 23]["Anterior"].ToString();
                            }
                            if (Convert.ToInt32(l.Rows[b + 23]["Atual"].ToString()) > Convert.ToInt32(l.Rows[b + 23]["Anterior"].ToString()))
                            {
                                txt70__.Text = l.Rows[b + 23]["Atual"].ToString();
                            }
                            if (String.IsNullOrEmpty(txt70__.Text) == true)
                            {
                                txt70__.Text = l.Rows[b + 23]["Anterior"].ToString();
                            }


                            if (Convert.ToInt32(l.Rows[b + 24]["Atual"].ToString()) < Convert.ToInt32(l.Rows[b + 24]["Anterior"].ToString()))
                            {
                                txt71__.Text = l.Rows[b + 24]["Anterior"].ToString();
                            }
                            if (Convert.ToInt32(l.Rows[b + 24]["Atual"].ToString()) > Convert.ToInt32(l.Rows[b + 24]["Anterior"].ToString()))
                            {
                                txt71__.Text = l.Rows[b + 24]["Atual"].ToString();
                            }
                            if (String.IsNullOrEmpty(txt71__.Text) == true)
                            {
                                txt71__.Text = l.Rows[b + 24]["Anterior"].ToString();
                            }


                            if (Convert.ToInt32(l.Rows[b + 25]["Atual"].ToString()) < Convert.ToInt32(l.Rows[b + 25]["Anterior"].ToString()))
                            {
                                txt72__.Text = l.Rows[b + 25]["Anterior"].ToString();
                            }
                            if (Convert.ToInt32(l.Rows[b + 25]["Atual"].ToString()) > Convert.ToInt32(l.Rows[b + 25]["Anterior"].ToString()))
                            {
                                txt72__.Text = l.Rows[b + 25]["Atual"].ToString();
                            }
                            if (String.IsNullOrEmpty(txt72__.Text) == true)
                            {
                                txt72__.Text = l.Rows[b + 25]["Anterior"].ToString();
                            }



                            if (Convert.ToInt32(l.Rows[b + 26]["Atual"].ToString()) < Convert.ToInt32(l.Rows[b + 26]["Anterior"].ToString()))
                            {
                                txt73__.Text = l.Rows[b + 26]["Anterior"].ToString();
                            }
                            if (Convert.ToInt32(l.Rows[b + 26]["Atual"].ToString()) > Convert.ToInt32(l.Rows[b + 26]["Anterior"].ToString()))
                            {
                                txt73__.Text = l.Rows[b + 26]["Atual"].ToString();
                            }
                            if (String.IsNullOrEmpty(txt73__.Text) == true)
                            {
                                txt73__.Text = l.Rows[b + 26]["Anterior"].ToString();
                            }


                            if (Convert.ToInt32(l.Rows[b + 27]["Atual"].ToString()) < Convert.ToInt32(l.Rows[b + 27]["Anterior"].ToString()))
                            {
                                txt74__.Text = l.Rows[b + 27]["Anterior"].ToString();
                            }
                            if (Convert.ToInt32(l.Rows[b + 27]["Atual"].ToString()) > Convert.ToInt32(l.Rows[b + 27]["Anterior"].ToString()))
                            {
                                txt74__.Text = l.Rows[b + 27]["Atual"].ToString();
                            }
                            if (String.IsNullOrEmpty(txt74__.Text) == true)
                            {
                                txt74__.Text = l.Rows[b + 27]["Anterior"].ToString();
                            }


                            if (Convert.ToInt32(l.Rows[b + 28]["Atual"].ToString()) < Convert.ToInt32(l.Rows[b + 28]["Anterior"].ToString()))
                            {
                                txt75__.Text = l.Rows[b + 28]["Anterior"].ToString();
                            }
                            if (Convert.ToInt32(l.Rows[b + 28]["Atual"].ToString()) > Convert.ToInt32(l.Rows[b + 28]["Anterior"].ToString()))
                            {
                                txt75__.Text = l.Rows[b + 28]["Atual"].ToString();
                            }
                            if (String.IsNullOrEmpty(txt75__.Text) == true)
                            {
                                txt75__.Text = l.Rows[b + 28]["Anterior"].ToString();
                            }


                            if (Convert.ToInt32(l.Rows[b + 29]["Atual"].ToString()) < Convert.ToInt32(l.Rows[b + 29]["Anterior"].ToString()))
                            {
                                txt76__.Text = l.Rows[b + 29]["Anterior"].ToString();
                            }
                            if (Convert.ToInt32(l.Rows[b + 29]["Atual"].ToString()) > Convert.ToInt32(l.Rows[b + 29]["Anterior"].ToString()))
                            {
                                txt76__.Text = l.Rows[b + 29]["Atual"].ToString();
                            }
                            if (String.IsNullOrEmpty(txt76__.Text) == true)
                            {
                                txt76__.Text = l.Rows[b + 29]["Anterior"].ToString();
                            }



                            if (Convert.ToInt32(l.Rows[b + 30]["Atual"].ToString()) < Convert.ToInt32(l.Rows[b + 30]["Anterior"].ToString()))
                            {
                                txt77__.Text = l.Rows[b + 30]["Anterior"].ToString();
                            }
                            if (Convert.ToInt32(l.Rows[b + 30]["Atual"].ToString()) > Convert.ToInt32(l.Rows[b + 30]["Anterior"].ToString()))
                            {
                                txt77__.Text = l.Rows[b + 30]["Atual"].ToString();
                            }
                            if (String.IsNullOrEmpty(txt77__.Text) == true)
                            {
                                txt77__.Text = l.Rows[b + 30]["Anterior"].ToString();
                            }


                            if (Convert.ToInt32(l.Rows[b + 31]["Atual"].ToString()) < Convert.ToInt32(l.Rows[b + 31]["Anterior"].ToString()))
                            {
                                txt78__.Text = l.Rows[b + 31]["Anterior"].ToString();
                            }
                            if (Convert.ToInt32(l.Rows[b + 31]["Atual"].ToString()) > Convert.ToInt32(l.Rows[b + 31]["Anterior"].ToString()))
                            {
                                txt78__.Text = l.Rows[b + 31]["Atual"].ToString();
                            }
                            if (String.IsNullOrEmpty(txt78__.Text) == true)
                            {
                                txt78__.Text = l.Rows[b + 31]["Anterior"].ToString();
                            }


                            if (Convert.ToInt32(l.Rows[b + 32]["Atual"].ToString()) < Convert.ToInt32(l.Rows[b + 32]["Anterior"].ToString()))
                            {
                                txt79__.Text = l.Rows[b + 32]["Anterior"].ToString();
                            }
                            if (Convert.ToInt32(l.Rows[b + 32]["Atual"].ToString()) > Convert.ToInt32(l.Rows[b + 32]["Anterior"].ToString()))
                            {
                                txt79__.Text = l.Rows[b + 32]["Atual"].ToString();
                            }
                            if (String.IsNullOrEmpty(txt79__.Text) == true)
                            {
                                txt79__.Text = l.Rows[b + 32]["Anterior"].ToString();
                            }

                            if (Convert.ToInt32(l.Rows[b + 33]["Atual"].ToString()) < Convert.ToInt32(l.Rows[b + 33]["Anterior"].ToString()))
                            {
                                txt80__.Text = l.Rows[b + 33]["Anterior"].ToString();
                            }
                            if (Convert.ToInt32(l.Rows[b + 33]["Atual"].ToString()) > Convert.ToInt32(l.Rows[b + 33]["Anterior"].ToString()))
                            {
                                txt80__.Text = l.Rows[b + 33]["Atual"].ToString();
                            }
                            if (String.IsNullOrEmpty(txt80__.Text) == true)
                            {
                                txt80__.Text = l.Rows[b + 33]["Anterior"].ToString();
                            }


                            if (Convert.ToInt32(l.Rows[b + 34]["Atual"].ToString()) < Convert.ToInt32(l.Rows[b + 34]["Anterior"].ToString()))
                            {
                                txt81__.Text = l.Rows[b + 34]["Anterior"].ToString();
                            }
                            if (Convert.ToInt32(l.Rows[b + 34]["Atual"].ToString()) > Convert.ToInt32(l.Rows[b + 34]["Anterior"].ToString()))
                            {
                                txt81__.Text = l.Rows[b + 34]["Atual"].ToString();
                            }
                            if (String.IsNullOrEmpty(txt81__.Text) == true)
                            {
                                txt81__.Text = l.Rows[b + 34]["Anterior"].ToString();
                            }


                            if (Convert.ToInt32(l.Rows[b + 35]["Atual"].ToString()) < Convert.ToInt32(l.Rows[b + 35]["Anterior"].ToString()))
                            {
                                txt82__.Text = l.Rows[b + 35]["Anterior"].ToString();
                            }
                            if (Convert.ToInt32(l.Rows[b + 35]["Atual"].ToString()) > Convert.ToInt32(l.Rows[b + 35]["Anterior"].ToString()))
                            {
                                txt82__.Text = l.Rows[b + 35]["Atual"].ToString();
                            }
                            if (String.IsNullOrEmpty(txt82__.Text) == true)
                            {
                                txt82__.Text = l.Rows[b + 35]["Anterior"].ToString();
                            }


                            if (Convert.ToInt32(l.Rows[b + 36]["Atual"].ToString()) < Convert.ToInt32(l.Rows[b + 36]["Anterior"].ToString()))
                            {
                                txt83__.Text = l.Rows[b + 36]["Anterior"].ToString();
                            }
                            if (Convert.ToInt32(l.Rows[b + 36]["Atual"].ToString()) > Convert.ToInt32(l.Rows[b + 36]["Anterior"].ToString()))
                            {
                                txt83__.Text = l.Rows[b + 36]["Atual"].ToString();
                            }
                            if (String.IsNullOrEmpty(txt83__.Text) == true)
                            {
                                txt83__.Text = l.Rows[b + 36]["Anterior"].ToString();
                            }


                        }
                        else
                        {
                            int k = qtde2;

                            //limpar campos
                            txt17__.Text = "";
                            txt8__.Text = "";
                            txt7__.Text = "";
                            txt14__.Text = "";
                            txt42__.Text = "";
                            txt27__.Text = "";
                            txt44__.Text = "";
                            txt10__.Text = "";
                            txt11__.Text = "";
                            txt12__.Text = "";
                            txt13__.Text = "";
                            txt15__.Text = "";
                            txt18__.Text = "";
                            txt19__.Text = "";
                            txt28__.Text = "";
                            txt29__.Text = "";
                            txt30__.Text = "";
                            txt31__.Text = "";
                            txt32__.Text = "";
                            txt33__.Text = "";
                            txt34__.Text = "";
                            txt35__.Text = "";
                            txt36__.Text = "";
                            txt37__.Text = "";
                            txt38__.Text = "";
                            txt39__.Text = "";
                            txt40__.Text = "";
                            txt41__.Text = "";
                            txt45__.Text = "";
                            txt46__.Text = "";
                            txt47__.Text = "";
                            txt48__.Text = "";
                            txt51__.Text = "";
                            txt52__.Text = "";
                            txt20__.Text = "";
                            txt21__.Text = "";
                            txt22__.Text = "";


                            txt24__.Text = "";
                            txt25__.Text = "";
                            txt26__.Text = "";
                            txt43__.Text = "";
                            txt49__.Text = "";
                            txt50__.Text = "";
                            txt53__.Text = "";
                            txt54__.Text = "";
                            txt55__.Text = "";
                            txt56__.Text = "";
                            txt57__.Text = "";
                            txt58__.Text = "";
                            txt59__.Text = "";
                            txt60__.Text = "";
                            txt61__.Text = "";
                            txt62__.Text = "";
                            txt63__.Text = "";
                            txt64__.Text = "";
                            txt65__.Text = "";
                            txt66__.Text = "";
                            txt67__.Text = "";
                            txt68__.Text = "";
                            txt69__.Text = "";
                            txt70__.Text = "";
                            txt71__.Text = "";
                            txt72__.Text = "";
                            txt73__.Text = "";
                            txt74__.Text = "";
                            txt75__.Text = "";
                            txt76__.Text = "";
                            txt77__.Text = "";
                            txt78__.Text = "";
                            txt79__.Text = "";
                            txt80__.Text = "";
                            txt81__.Text = "";
                            txt82__.Text = "";
                            txt83__.Text = "";


                            if (k > 0)
                            {
                                txt17__.Text = l.Rows[b]["Nome"].ToString();
                            }

                            k--;
                            if (k > 0)
                            {
                                txt8__.Text = l.Rows[b + 1]["Nome"].ToString();
                            }

                            k--;
                            if (k > 0)
                            {
                                txt7__.Text = l.Rows[b + 2]["Nome"].ToString();
                            }


                            k--;
                            if (k > 0)
                            {
                                txt14__.Text = l.Rows[b + 3]["Nome"].ToString();
                            }
                            k--;
                            if (k > 0)
                            {
                                txt42__.Text = l.Rows[b + 4]["Nome"].ToString();
                            }

                            k--;
                            if (k > 0)
                            {
                                txt27__.Text = l.Rows[b + 5]["Nome"].ToString();
                            }

                            k--;
                            if (k > 0)
                            {
                                txt44__.Text = l.Rows[b + 6]["Nome"].ToString();
                            }

                            k--;
                            if (k > 0)
                            {
                                txt10__.Text = l.Rows[b + 7]["Nome"].ToString();
                            }

                            k--;
                            if (k > 0)
                            {
                                txt11__.Text = l.Rows[b + 8]["Nome"].ToString();
                            }

                            k--;
                            if (k > 0)
                            {
                                txt12__.Text = l.Rows[b + 9]["Nome"].ToString();
                            }

                            k--;
                            if (k > 0)
                            {
                                txt13__.Text = l.Rows[b + 10]["Nome"].ToString();
                            }

                            k--;
                            if (k > 0)
                            {
                                txt15__.Text = l.Rows[b + 11]["Nome"].ToString();
                            }

                            k--;
                            if (k > 0)
                            {
                                txt18__.Text = l.Rows[b + 12]["Nome"].ToString();
                            }

                            k--;
                            if (k > 0)
                            {
                                txt19__.Text = l.Rows[b + 13]["Nome"].ToString();
                            }

                            k--;
                            if (k > 0)
                            {
                                txt28__.Text = l.Rows[b + 14]["Nome"].ToString();
                            }

                            k--;
                            if (k > 0)
                            {
                                txt29__.Text = l.Rows[b + 15]["Nome"].ToString();
                            }

                            k--;
                            if (k > 0)
                            {
                                txt30__.Text = l.Rows[b + 16]["Nome"].ToString();
                            }

                            k--;
                            if (k > 0)
                            {
                                txt31__.Text = l.Rows[b + 17]["Nome"].ToString();
                            }

                            k--;
                            if (k > 0)
                            {
                                txt32__.Text = l.Rows[b + 18]["Nome"].ToString();
                            }

                            k--;
                            if (k > 0)
                            {
                                txt33__.Text = l.Rows[b + 19]["Nome"].ToString();
                            }

                            k--;
                            if (k > 0)
                            {
                                txt34__.Text = l.Rows[b + 20]["Nome"].ToString();
                            }

                            k--;
                            if (k > 0)
                            {
                                txt35__.Text = l.Rows[b + 21]["Nome"].ToString();
                            }

                            k--;
                            if (k > 0)
                            {
                                txt36__.Text = l.Rows[b + 22]["Nome"].ToString();
                            }

                            k--;
                            if (k > 0)
                            {
                                txt37__.Text = l.Rows[b + 23]["Nome"].ToString();
                            }

                            k--;
                            if (k > 0)
                            {
                                txt38__.Text = l.Rows[b + 24]["Nome"].ToString();
                            }

                            k--;
                            if (k > 0)
                            {
                                txt39__.Text = l.Rows[b + 25]["Nome"].ToString();
                            }

                            k--;
                            if (k > 0)
                            {
                                txt40__.Text = l.Rows[b + 26]["Nome"].ToString();
                            }

                            k--;
                            if (k > 0)
                            {
                                txt41__.Text = l.Rows[b + 27]["Nome"].ToString();
                            }

                            k--;
                            if (k > 0)
                            {
                                txt45__.Text = l.Rows[b + 28]["Nome"].ToString();
                            }

                            k--;
                            if (k > 0)
                            {
                                txt46__.Text = l.Rows[b + 29]["Nome"].ToString();
                            }

                            k--;
                            if (k > 0)
                            {
                                txt47__.Text = l.Rows[b + 30]["Nome"].ToString();
                            }

                            k--;
                            if (k > 0)
                            {
                                txt48__.Text = l.Rows[b + 31]["Nome"].ToString();
                            }

                            k--;
                            if (k > 0)
                            {
                                txt51__.Text = l.Rows[b + 32]["Nome"].ToString();
                            }

                            k--;
                            if (k > 0)
                            {
                                txt52__.Text = l.Rows[b + 33]["Nome"].ToString();
                            }

                            k--;
                            if (k > 0)
                            {
                                txt20__.Text = l.Rows[b + 34]["Nome"].ToString();
                            }

                            k--;
                            if (k > 0)
                            {
                                txt21__.Text = l.Rows[b + 35]["Nome"].ToString();
                            }

                            k--;
                            if (k > 0)
                            {
                                txt22__.Text = l.Rows[b + 36]["Nome"].ToString();
                            }


                            k = qtde2;

                            if (k > 0)
                            {
                                if (Convert.ToInt32(l.Rows[b]["Atual"].ToString()) < Convert.ToInt32(l.Rows[b]["Anterior"].ToString()))
                                {
                                    txt24__.Text = l.Rows[b]["Anterior"].ToString();
                                }
                                if (Convert.ToInt32(l.Rows[b]["Atual"].ToString()) > Convert.ToInt32(l.Rows[b]["Anterior"].ToString()))
                                {
                                    txt24__.Text = l.Rows[b]["Atual"].ToString();
                                }
                                if (String.IsNullOrEmpty(txt24__.Text) == true)
                                {
                                    txt24__.Text = l.Rows[b]["Anterior"].ToString();
                                }

                            }

                            k--;
                            if (k > 0)
                            {
                                if (Convert.ToInt32(l.Rows[b + 1]["Atual"].ToString()) < Convert.ToInt32(l.Rows[b + 1]["Anterior"].ToString()))
                                {
                                    txt25__.Text = l.Rows[b + 1]["Anterior"].ToString();
                                }
                                if (Convert.ToInt32(l.Rows[b + 1]["Atual"].ToString()) > Convert.ToInt32(l.Rows[b + 1]["Anterior"].ToString()))
                                {
                                    txt25__.Text = l.Rows[b + 1]["Atual"].ToString();
                                }
                                if (String.IsNullOrEmpty(txt25__.Text) == true)
                                {
                                    txt25__.Text = l.Rows[b + 1]["Anterior"].ToString();
                                }

                            }

                            k--;
                            if (k > 0)
                            {
                                if (Convert.ToInt32(l.Rows[b + 2]["Atual"].ToString()) < Convert.ToInt32(l.Rows[b + 2]["Anterior"].ToString()))
                                {
                                    txt26__.Text = l.Rows[b + 2]["Anterior"].ToString();
                                }
                                if (Convert.ToInt32(l.Rows[b + 2]["Atual"].ToString()) > Convert.ToInt32(l.Rows[b + 2]["Anterior"].ToString()))
                                {
                                    txt26__.Text = l.Rows[b + 2]["Atual"].ToString();
                                }
                                if (String.IsNullOrEmpty(txt26__.Text) == true)
                                {
                                    txt26__.Text = l.Rows[b + 2]["Anterior"].ToString();
                                }

                            }

                            k--;
                            if (k > 0)
                            {
                                if (Convert.ToInt32(l.Rows[b + 3]["Atual"].ToString()) < Convert.ToInt32(l.Rows[b + 3]["Anterior"].ToString()))
                                {
                                    txt43__.Text = l.Rows[b + 3]["Anterior"].ToString();
                                }
                                if (Convert.ToInt32(l.Rows[b + 3]["Atual"].ToString()) > Convert.ToInt32(l.Rows[b + 3]["Anterior"].ToString()))
                                {
                                    txt43__.Text = l.Rows[b + 3]["Atual"].ToString();
                                }
                                if (String.IsNullOrEmpty(txt43__.Text) == true)
                                {
                                    txt43__.Text = l.Rows[b + 3]["Anterior"].ToString();
                                }


                            }

                            k--;
                            if (k > 0)
                            {
                                if (Convert.ToInt32(l.Rows[b + 4]["Atual"].ToString()) < Convert.ToInt32(l.Rows[b + 4]["Anterior"].ToString()))
                                {
                                    txt49__.Text = l.Rows[b + 4]["Anterior"].ToString();
                                }
                                if (Convert.ToInt32(l.Rows[b + 4]["Atual"].ToString()) > Convert.ToInt32(l.Rows[b + 4]["Anterior"].ToString()))
                                {
                                    txt49__.Text = l.Rows[b + 4]["Atual"].ToString();
                                }
                                if (String.IsNullOrEmpty(txt49__.Text) == true)
                                {
                                    txt49__.Text = l.Rows[b + 4]["Anterior"].ToString();
                                }

                            }

                            k--;
                            if (k > 0)
                            {
                                if (Convert.ToInt32(l.Rows[b + 5]["Atual"].ToString()) < Convert.ToInt32(l.Rows[b + 5]["Anterior"].ToString()))
                                {
                                    txt50__.Text = l.Rows[b + 5]["Anterior"].ToString();
                                }
                                if (Convert.ToInt32(l.Rows[b + 5]["Atual"].ToString()) > Convert.ToInt32(l.Rows[b + 5]["Anterior"].ToString()))
                                {
                                    txt50__.Text = l.Rows[b + 5]["Atual"].ToString();
                                }
                                if (String.IsNullOrEmpty(txt50__.Text) == true)
                                {
                                    txt50__.Text = l.Rows[b + 5]["Anterior"].ToString();
                                }

                            }

                            k--;
                            if (k > 0)
                            {
                                if (Convert.ToInt32(l.Rows[b + 6]["Atual"].ToString()) < Convert.ToInt32(l.Rows[b + 6]["Anterior"].ToString()))
                                {
                                    txt53__.Text = l.Rows[b + 6]["Anterior"].ToString();
                                }
                                if (Convert.ToInt32(l.Rows[b + 6]["Atual"].ToString()) > Convert.ToInt32(l.Rows[b + 6]["Anterior"].ToString()))
                                {
                                    txt53__.Text = l.Rows[b + 6]["Atual"].ToString();
                                }
                                if (String.IsNullOrEmpty(txt53__.Text) == true)
                                {
                                    txt53__.Text = l.Rows[b + 6]["Anterior"].ToString();
                                }

                            }

                            k--;
                            if (k > 0)
                            {
                                if (Convert.ToInt32(l.Rows[b + 7]["Atual"].ToString()) < Convert.ToInt32(l.Rows[b + 7]["Anterior"].ToString()))
                                {
                                    txt54__.Text = l.Rows[b + 7]["Anterior"].ToString();
                                }
                                if (Convert.ToInt32(l.Rows[b + 7]["Atual"].ToString()) > Convert.ToInt32(l.Rows[b + 7]["Anterior"].ToString()))
                                {
                                    txt54__.Text = l.Rows[b + 7]["Atual"].ToString();
                                }
                                if (String.IsNullOrEmpty(txt54__.Text) == true)
                                {
                                    txt54__.Text = l.Rows[b + 7]["Anterior"].ToString();
                                }

                            }

                            k--;
                            if (k > 0)
                            {
                                if (Convert.ToInt32(l.Rows[b + 8]["Atual"].ToString()) < Convert.ToInt32(l.Rows[b + 8]["Anterior"].ToString()))
                                {
                                    txt55__.Text = l.Rows[b + 8]["Anterior"].ToString();
                                }
                                if (Convert.ToInt32(l.Rows[b + 8]["Atual"].ToString()) > Convert.ToInt32(l.Rows[b + 8]["Anterior"].ToString()))
                                {
                                    txt55__.Text = l.Rows[b + 8]["Atual"].ToString();
                                }
                                if (String.IsNullOrEmpty(txt55__.Text) == true)
                                {
                                    txt55__.Text = l.Rows[b + 8]["Anterior"].ToString();
                                }

                            }

                            k--;
                            if (k > 0)
                            {
                                if (Convert.ToInt32(l.Rows[b + 9]["Atual"].ToString()) < Convert.ToInt32(l.Rows[b + 9]["Anterior"].ToString()))
                                {
                                    txt56__.Text = l.Rows[b + 9]["Anterior"].ToString();
                                }
                                if (Convert.ToInt32(l.Rows[b + 9]["Atual"].ToString()) > Convert.ToInt32(l.Rows[b + 9]["Anterior"].ToString()))
                                {
                                    txt56__.Text = l.Rows[b + 9]["Atual"].ToString();
                                }
                                if (String.IsNullOrEmpty(txt56__.Text) == true)
                                {
                                    txt56__.Text = l.Rows[b + 9]["Anterior"].ToString();
                                }

                            }

                            k--;
                            if (k > 0)
                            {
                                if (Convert.ToInt32(l.Rows[b + 10]["Atual"].ToString()) < Convert.ToInt32(l.Rows[b + 10]["Anterior"].ToString()))
                                {
                                    txt57__.Text = l.Rows[b + 10]["Anterior"].ToString();
                                }
                                if (Convert.ToInt32(l.Rows[b + 10]["Atual"].ToString()) > Convert.ToInt32(l.Rows[b + 10]["Anterior"].ToString()))
                                {
                                    txt57__.Text = l.Rows[b + 10]["Atual"].ToString();
                                }
                                if (String.IsNullOrEmpty(txt57__.Text) == true)
                                {
                                    txt57__.Text = l.Rows[b + 10]["Anterior"].ToString();
                                }

                            }

                            k--;
                            if (k > 0)
                            {
                                if (Convert.ToInt32(l.Rows[b + 11]["Atual"].ToString()) < Convert.ToInt32(l.Rows[b + 11]["Anterior"].ToString()))
                                {
                                    txt58__.Text = l.Rows[b + 11]["Anterior"].ToString();
                                }
                                if (Convert.ToInt32(l.Rows[b + 11]["Atual"].ToString()) > Convert.ToInt32(l.Rows[b + 11]["Anterior"].ToString()))
                                {
                                    txt58__.Text = l.Rows[b + 11]["Atual"].ToString();
                                }
                                if (String.IsNullOrEmpty(txt58__.Text) == true)
                                {
                                    txt58__.Text = l.Rows[b + 11]["Anterior"].ToString();
                                }

                            }

                            k--;
                            if (k > 0)
                            {
                                if (Convert.ToInt32(l.Rows[b + 12]["Atual"].ToString()) < Convert.ToInt32(l.Rows[b + 12]["Anterior"].ToString()))
                                {
                                    txt59__.Text = l.Rows[b + 12]["Anterior"].ToString();
                                }
                                if (Convert.ToInt32(l.Rows[b + 12]["Atual"].ToString()) > Convert.ToInt32(l.Rows[b + 12]["Anterior"].ToString()))
                                {
                                    txt59__.Text = l.Rows[b + 12]["Atual"].ToString();
                                }
                                if (String.IsNullOrEmpty(txt59__.Text) == true)
                                {
                                    txt59__.Text = l.Rows[b + 12]["Anterior"].ToString();
                                }

                            }

                            k--;
                            if (k > 0)
                            {
                                if (Convert.ToInt32(l.Rows[b + 13]["Atual"].ToString()) < Convert.ToInt32(l.Rows[b + 13]["Anterior"].ToString()))
                                {
                                    txt60__.Text = l.Rows[b + 13]["Anterior"].ToString();
                                }
                                if (Convert.ToInt32(l.Rows[b + 13]["Atual"].ToString()) > Convert.ToInt32(l.Rows[b + 13]["Anterior"].ToString()))
                                {
                                    txt60__.Text = l.Rows[b + 13]["Atual"].ToString();
                                }
                                if (String.IsNullOrEmpty(txt60__.Text) == true)
                                {
                                    txt60__.Text = l.Rows[b + 13]["Anterior"].ToString();
                                }

                            }

                            k--;
                            if (k > 0)
                            {
                                if (Convert.ToInt32(l.Rows[b + 14]["Atual"].ToString()) < Convert.ToInt32(l.Rows[b + 14]["Anterior"].ToString()))
                                {
                                    txt61__.Text = l.Rows[b + 14]["Anterior"].ToString();
                                }
                                if (Convert.ToInt32(l.Rows[b + 14]["Atual"].ToString()) > Convert.ToInt32(l.Rows[b + 14]["Anterior"].ToString()))
                                {
                                    txt61__.Text = l.Rows[b + 14]["Atual"].ToString();
                                }
                                if (String.IsNullOrEmpty(txt61__.Text) == true)
                                {
                                    txt61__.Text = l.Rows[b + 14]["Anterior"].ToString();
                                }

                            }

                            k--;
                            if (k > 0)
                            {
                                if (Convert.ToInt32(l.Rows[b + 15]["Atual"].ToString()) < Convert.ToInt32(l.Rows[b + 15]["Anterior"].ToString()))
                                {
                                    txt62__.Text = l.Rows[b + 15]["Anterior"].ToString();
                                }
                                if (Convert.ToInt32(l.Rows[b + 15]["Atual"].ToString()) > Convert.ToInt32(l.Rows[b + 15]["Anterior"].ToString()))
                                {
                                    txt62__.Text = l.Rows[b + 15]["Atual"].ToString();
                                }
                                if (String.IsNullOrEmpty(txt62__.Text) == true)
                                {
                                    txt62__.Text = l.Rows[b + 15]["Anterior"].ToString();
                                }

                            }

                            k--;
                            if (k > 0)
                            {
                                if (Convert.ToInt32(l.Rows[b + 16]["Atual"].ToString()) < Convert.ToInt32(l.Rows[b + 16]["Anterior"].ToString()))
                                {
                                    txt63__.Text = l.Rows[b + 16]["Anterior"].ToString();
                                }
                                if (Convert.ToInt32(l.Rows[b + 16]["Atual"].ToString()) > Convert.ToInt32(l.Rows[b + 16]["Anterior"].ToString()))
                                {
                                    txt63__.Text = l.Rows[b + 16]["Atual"].ToString();
                                }
                                if (String.IsNullOrEmpty(txt63__.Text) == true)
                                {
                                    txt63__.Text = l.Rows[b + 16]["Anterior"].ToString();
                                }

                            }

                            k--;
                            if (k > 0)
                            {
                                if (Convert.ToInt32(l.Rows[b + 17]["Atual"].ToString()) < Convert.ToInt32(l.Rows[b + 17]["Anterior"].ToString()))
                                {
                                    txt64__.Text = l.Rows[b + 17]["Anterior"].ToString();
                                }
                                if (Convert.ToInt32(l.Rows[b + 17]["Atual"].ToString()) > Convert.ToInt32(l.Rows[b + 17]["Anterior"].ToString()))
                                {
                                    txt64__.Text = l.Rows[b + 17]["Atual"].ToString();
                                }
                                if (String.IsNullOrEmpty(txt64__.Text) == true)
                                {
                                    txt64__.Text = l.Rows[b + 17]["Anterior"].ToString();
                                }

                            }

                            k--;
                            if (k > 0)
                            {
                                if (Convert.ToInt32(l.Rows[b + 18]["Atual"].ToString()) < Convert.ToInt32(l.Rows[b + 18]["Anterior"].ToString()))
                                {
                                    txt65__.Text = l.Rows[b + 18]["Anterior"].ToString();
                                }
                                if (Convert.ToInt32(l.Rows[b + 18]["Atual"].ToString()) > Convert.ToInt32(l.Rows[b + 18]["Anterior"].ToString()))
                                {
                                    txt65__.Text = l.Rows[b + 18]["Atual"].ToString();
                                }
                                if (String.IsNullOrEmpty(txt65__.Text) == true)
                                {
                                    txt65__.Text = l.Rows[b + 18]["Anterior"].ToString();
                                }

                            }

                            k--;
                            if (k > 0)
                            {
                                if (Convert.ToInt32(l.Rows[b + 19]["Atual"].ToString()) < Convert.ToInt32(l.Rows[b + 19]["Anterior"].ToString()))
                                {
                                    txt66__.Text = l.Rows[b + 19]["Anterior"].ToString();
                                }
                                if (Convert.ToInt32(l.Rows[b + 19]["Atual"].ToString()) > Convert.ToInt32(l.Rows[b + 19]["Anterior"].ToString()))
                                {
                                    txt66__.Text = l.Rows[b + 19]["Atual"].ToString();
                                }
                                if (String.IsNullOrEmpty(txt66__.Text) == true)
                                {
                                    txt66__.Text = l.Rows[b + 19]["Anterior"].ToString();
                                }

                            }

                            k--;
                            if (k > 0)
                            {
                                if (Convert.ToInt32(l.Rows[b + 20]["Atual"].ToString()) < Convert.ToInt32(l.Rows[b + 20]["Anterior"].ToString()))
                                {
                                    txt67__.Text = l.Rows[b + 20]["Anterior"].ToString();
                                }
                                if (Convert.ToInt32(l.Rows[b + 20]["Atual"].ToString()) > Convert.ToInt32(l.Rows[b + 20]["Anterior"].ToString()))
                                {
                                    txt67__.Text = l.Rows[b + 20]["Atual"].ToString();
                                }
                                if (String.IsNullOrEmpty(txt67__.Text) == true)
                                {
                                    txt67__.Text = l.Rows[b + 20]["Anterior"].ToString();
                                }

                            }

                            k--;
                            if (k > 0)
                            {
                                if (Convert.ToInt32(l.Rows[b + 21]["Atual"].ToString()) < Convert.ToInt32(l.Rows[b + 21]["Anterior"].ToString()))
                                {
                                    txt68__.Text = l.Rows[b + 21]["Anterior"].ToString();
                                }
                                if (Convert.ToInt32(l.Rows[b + 21]["Atual"].ToString()) > Convert.ToInt32(l.Rows[b + 21]["Anterior"].ToString()))
                                {
                                    txt68__.Text = l.Rows[b + 21]["Atual"].ToString();
                                }
                                if (String.IsNullOrEmpty(txt68__.Text) == true)
                                {
                                    txt68__.Text = l.Rows[b + 21]["Anterior"].ToString();
                                }

                            }

                            k--;
                            if (k > 0)
                            {
                                if (Convert.ToInt32(l.Rows[b + 22]["Atual"].ToString()) < Convert.ToInt32(l.Rows[b + 22]["Anterior"].ToString()))
                                {
                                    txt69__.Text = l.Rows[b + 22]["Anterior"].ToString();
                                }
                                if (Convert.ToInt32(l.Rows[b + 22]["Atual"].ToString()) > Convert.ToInt32(l.Rows[b + 22]["Anterior"].ToString()))
                                {
                                    txt69__.Text = l.Rows[b + 22]["Atual"].ToString();
                                }
                                if (String.IsNullOrEmpty(txt69__.Text) == true)
                                {
                                    txt69__.Text = l.Rows[b + 22]["Anterior"].ToString();
                                }

                            }

                            k--;
                            if (k > 0)
                            {
                                if (Convert.ToInt32(l.Rows[b + 23]["Atual"].ToString()) < Convert.ToInt32(l.Rows[b + 23]["Anterior"].ToString()))
                                {
                                    txt70__.Text = l.Rows[b + 23]["Anterior"].ToString();
                                }
                                if (Convert.ToInt32(l.Rows[b + 23]["Atual"].ToString()) > Convert.ToInt32(l.Rows[b + 23]["Anterior"].ToString()))
                                {
                                    txt70__.Text = l.Rows[b + 23]["Atual"].ToString();
                                }
                                if (String.IsNullOrEmpty(txt70__.Text) == true)
                                {
                                    txt70__.Text = l.Rows[b + 23]["Anterior"].ToString();
                                }

                            }

                            k--;
                            if (k > 0)
                            {
                                if (Convert.ToInt32(l.Rows[b + 24]["Atual"].ToString()) < Convert.ToInt32(l.Rows[b + 24]["Anterior"].ToString()))
                                {
                                    txt71__.Text = l.Rows[b + 24]["Anterior"].ToString();
                                }
                                if (Convert.ToInt32(l.Rows[b + 24]["Atual"].ToString()) > Convert.ToInt32(l.Rows[b + 24]["Anterior"].ToString()))
                                {
                                    txt71__.Text = l.Rows[b + 24]["Atual"].ToString();
                                }
                                if (String.IsNullOrEmpty(txt71__.Text) == true)
                                {
                                    txt71__.Text = l.Rows[b + 24]["Anterior"].ToString();
                                }

                            }

                            k--;
                            if (k > 0)
                            {
                                if (Convert.ToInt32(l.Rows[b + 25]["Atual"].ToString()) < Convert.ToInt32(l.Rows[b + 25]["Anterior"].ToString()))
                                {
                                    txt72__.Text = l.Rows[b + 25]["Anterior"].ToString();
                                }
                                if (Convert.ToInt32(l.Rows[b + 25]["Atual"].ToString()) > Convert.ToInt32(l.Rows[b + 25]["Anterior"].ToString()))
                                {
                                    txt72__.Text = l.Rows[b + 25]["Atual"].ToString();
                                }
                                if (String.IsNullOrEmpty(txt72__.Text) == true)
                                {
                                    txt72__.Text = l.Rows[b + 25]["Anterior"].ToString();
                                }

                            }

                            k--;
                            if (k > 0)
                            {
                                if (Convert.ToInt32(l.Rows[b + 26]["Atual"].ToString()) < Convert.ToInt32(l.Rows[b + 26]["Anterior"].ToString()))
                                {
                                    txt73__.Text = l.Rows[b + 26]["Anterior"].ToString();
                                }
                                if (Convert.ToInt32(l.Rows[b + 26]["Atual"].ToString()) > Convert.ToInt32(l.Rows[b + 26]["Anterior"].ToString()))
                                {
                                    txt73__.Text = l.Rows[b + 26]["Atual"].ToString();
                                }
                                if (String.IsNullOrEmpty(txt73__.Text) == true)
                                {
                                    txt73__.Text = l.Rows[b + 26]["Anterior"].ToString();
                                }

                            }

                            k--;
                            if (k > 0)
                            {
                                if (Convert.ToInt32(l.Rows[b + 27]["Atual"].ToString()) < Convert.ToInt32(l.Rows[b + 27]["Anterior"].ToString()))
                                {
                                    txt74__.Text = l.Rows[b + 27]["Anterior"].ToString();
                                }
                                if (Convert.ToInt32(l.Rows[b + 27]["Atual"].ToString()) > Convert.ToInt32(l.Rows[b + 27]["Anterior"].ToString()))
                                {
                                    txt74__.Text = l.Rows[b + 27]["Atual"].ToString();
                                }
                                if (String.IsNullOrEmpty(txt74__.Text) == true)
                                {
                                    txt74__.Text = l.Rows[b + 27]["Anterior"].ToString();
                                }

                            }

                            k--;
                            if (k > 0)
                            {
                                if (Convert.ToInt32(l.Rows[b + 28]["Atual"].ToString()) < Convert.ToInt32(l.Rows[b + 28]["Anterior"].ToString()))
                                {
                                    txt75__.Text = l.Rows[b + 28]["Anterior"].ToString();
                                }
                                if (Convert.ToInt32(l.Rows[b + 28]["Atual"].ToString()) > Convert.ToInt32(l.Rows[b + 28]["Anterior"].ToString()))
                                {
                                    txt75__.Text = l.Rows[b + 28]["Atual"].ToString();
                                }
                                if (String.IsNullOrEmpty(txt75__.Text) == true)
                                {
                                    txt75__.Text = l.Rows[b + 28]["Anterior"].ToString();
                                }

                            }

                            k--;
                            if (k > 0)
                            {
                                if (Convert.ToInt32(l.Rows[b + 29]["Atual"].ToString()) < Convert.ToInt32(l.Rows[b + 29]["Anterior"].ToString()))
                                {
                                    txt76__.Text = l.Rows[b + 29]["Anterior"].ToString();
                                }
                                if (Convert.ToInt32(l.Rows[b + 29]["Atual"].ToString()) > Convert.ToInt32(l.Rows[b + 29]["Anterior"].ToString()))
                                {
                                    txt76__.Text = l.Rows[b + 29]["Atual"].ToString();
                                }
                                if (String.IsNullOrEmpty(txt76__.Text) == true)
                                {
                                    txt76__.Text = l.Rows[b + 29]["Anterior"].ToString();
                                }

                            }

                            k--;
                            if (k > 0)
                            {
                                if (Convert.ToInt32(l.Rows[b + 30]["Atual"].ToString()) < Convert.ToInt32(l.Rows[b + 30]["Anterior"].ToString()))
                                {
                                    txt77__.Text = l.Rows[b + 30]["Anterior"].ToString();
                                }
                                if (Convert.ToInt32(l.Rows[b + 30]["Atual"].ToString()) > Convert.ToInt32(l.Rows[b + 30]["Anterior"].ToString()))
                                {
                                    txt77__.Text = l.Rows[b + 30]["Atual"].ToString();
                                }
                                if (String.IsNullOrEmpty(txt77__.Text) == true)
                                {
                                    txt77__.Text = l.Rows[b + 30]["Anterior"].ToString();
                                }

                            }

                            k--;
                            if (k > 0)
                            {
                                if (Convert.ToInt32(l.Rows[b + 31]["Atual"].ToString()) < Convert.ToInt32(l.Rows[b + 31]["Anterior"].ToString()))
                                {
                                    txt78__.Text = l.Rows[b + 31]["Anterior"].ToString();
                                }
                                if (Convert.ToInt32(l.Rows[b + 31]["Atual"].ToString()) > Convert.ToInt32(l.Rows[b + 31]["Anterior"].ToString()))
                                {
                                    txt78__.Text = l.Rows[b + 31]["Atual"].ToString();
                                }
                                if (String.IsNullOrEmpty(txt78__.Text) == true)
                                {
                                    txt78__.Text = l.Rows[b + 31]["Anterior"].ToString();
                                }

                            }

                            k--;
                            if (k > 0)
                            {
                                if (Convert.ToInt32(l.Rows[b + 32]["Atual"].ToString()) < Convert.ToInt32(l.Rows[b + 32]["Anterior"].ToString()))
                                {
                                    txt79__.Text = l.Rows[b + 32]["Anterior"].ToString();
                                }
                                if (Convert.ToInt32(l.Rows[b + 32]["Atual"].ToString()) > Convert.ToInt32(l.Rows[b + 32]["Anterior"].ToString()))
                                {
                                    txt79__.Text = l.Rows[b + 32]["Atual"].ToString();
                                }
                                if (String.IsNullOrEmpty(txt79__.Text) == true)
                                {
                                    txt79__.Text = l.Rows[b + 32]["Anterior"].ToString();
                                }

                            }

                            k--;
                            if (k > 0)
                            {
                                if (Convert.ToInt32(l.Rows[b + 33]["Atual"].ToString()) < Convert.ToInt32(l.Rows[b + 33]["Anterior"].ToString()))
                                {
                                    txt80__.Text = l.Rows[b + 33]["Anterior"].ToString();
                                }
                                if (Convert.ToInt32(l.Rows[b + 33]["Atual"].ToString()) > Convert.ToInt32(l.Rows[b + 33]["Anterior"].ToString()))
                                {
                                    txt80__.Text = l.Rows[b + 33]["Atual"].ToString();
                                }
                                if (String.IsNullOrEmpty(txt80__.Text) == true)
                                {
                                    txt80__.Text = l.Rows[b + 33]["Anterior"].ToString();
                                }

                            }

                            k--;
                            if (k > 0)
                            {
                                if (Convert.ToInt32(l.Rows[b + 34]["Atual"].ToString()) < Convert.ToInt32(l.Rows[b + 34]["Anterior"].ToString()))
                                {
                                    txt81__.Text = l.Rows[b + 34]["Anterior"].ToString();
                                }
                                if (Convert.ToInt32(l.Rows[b + 34]["Atual"].ToString()) > Convert.ToInt32(l.Rows[b + 34]["Anterior"].ToString()))
                                {
                                    txt81__.Text = l.Rows[b + 34]["Atual"].ToString();
                                }
                                if (String.IsNullOrEmpty(txt81__.Text) == true)
                                {
                                    txt81__.Text = l.Rows[b + 34]["Anterior"].ToString();
                                }

                            }

                            k--;
                            if (k > 0)
                            {
                                if (Convert.ToInt32(l.Rows[b + 35]["Atual"].ToString()) < Convert.ToInt32(l.Rows[b + 35]["Anterior"].ToString()))
                                {
                                    txt82__.Text = l.Rows[b + 35]["Anterior"].ToString();
                                }
                                if (Convert.ToInt32(l.Rows[b + 35]["Atual"].ToString()) > Convert.ToInt32(l.Rows[b + 35]["Anterior"].ToString()))
                                {
                                    txt82__.Text = l.Rows[b + 35]["Atual"].ToString();
                                }
                                if (String.IsNullOrEmpty(txt82__.Text) == true)
                                {
                                    txt82__.Text = l.Rows[b + 35]["Anterior"].ToString();
                                }

                            }

                            k--;
                            if (k > 0)
                            {
                                if (Convert.ToInt32(l.Rows[b + 36]["Atual"].ToString()) < Convert.ToInt32(l.Rows[b + 36]["Anterior"].ToString()))
                                {
                                    txt83__.Text = l.Rows[b + 36]["Anterior"].ToString();
                                }
                                if (Convert.ToInt32(l.Rows[b + 36]["Atual"].ToString()) > Convert.ToInt32(l.Rows[b + 36]["Anterior"].ToString()))
                                {
                                    txt83__.Text = l.Rows[b + 36]["Atual"].ToString();
                                }
                                if (String.IsNullOrEmpty(txt83__.Text) == true)
                                {
                                    txt83__.Text = l.Rows[b + 36]["Anterior"].ToString();
                                }

                            }

                        }

                        crystalReportViewer1.ReportSource = rpt2;
                        crystalReportViewer1.Refresh();

                        string message3 = "Deseja Imprimir a leitura?";
                        string caption3 = "Reimpressão";
                        MessageBoxButtons buttons3 = MessageBoxButtons.YesNo;
                        DialogResult result3;

                        // Displays the MessageBox.

                        result3 = MessageBox.Show(this, message3, caption3, buttons3,
                        MessageBoxIcon.Question, MessageBoxDefaultButton.Button3);


                        if (result == DialogResult.No)
                        {

                        }
                        if (result == DialogResult.Yes)
                        {
                            rpt2.PrintToPrinter(1, false, 0, 0);
                            rpt2.PrintToPrinter(1, false, 0, 0);
                            Form print2 = new Print("Imp. a Leitura do próximo Mês");
                            print2.ShowDialog();
                        }

                        // crystalReportViewer1.PrintReport();
                        

                        //limpar campos
                        txt17__.Text = "";
                        txt8__.Text = "";
                        txt7__.Text = "";
                        txt14__.Text = "";
                        txt42__.Text = "";
                        txt27__.Text = "";
                        txt44__.Text = "";
                        txt10__.Text = "";
                        txt11__.Text = "";
                        txt12__.Text = "";
                        txt13__.Text = "";
                        txt15__.Text = "";
                        txt18__.Text = "";
                        txt19__.Text = "";
                        txt28__.Text = "";
                        txt29__.Text = "";
                        txt30__.Text = "";
                        txt31__.Text = "";
                        txt32__.Text = "";
                        txt33__.Text = "";
                        txt34__.Text = "";
                        txt35__.Text = "";
                        txt36__.Text = "";
                        txt37__.Text = "";
                        txt38__.Text = "";
                        txt39__.Text = "";
                        txt40__.Text = "";
                        txt41__.Text = "";
                        txt45__.Text = "";
                        txt46__.Text = "";
                        txt47__.Text = "";
                        txt48__.Text = "";
                        txt51__.Text = "";
                        txt52__.Text = "";
                        txt20__.Text = "";
                        txt21__.Text = "";
                        txt22__.Text = "";


                        txt24__.Text = "";
                        txt25__.Text = "";
                        txt26__.Text = "";
                        txt43__.Text = "";
                        txt49__.Text = "";
                        txt50__.Text = "";
                        txt53__.Text = "";
                        txt54__.Text = "";
                        txt55__.Text = "";
                        txt56__.Text = "";
                        txt57__.Text = "";
                        txt58__.Text = "";
                        txt59__.Text = "";
                        txt60__.Text = "";
                        txt61__.Text = "";
                        txt62__.Text = "";
                        txt63__.Text = "";
                        txt64__.Text = "";
                        txt65__.Text = "";
                        txt66__.Text = "";
                        txt67__.Text = "";
                        txt68__.Text = "";
                        txt69__.Text = "";
                        txt70__.Text = "";
                        txt71__.Text = "";
                        txt72__.Text = "";
                        txt73__.Text = "";
                        txt74__.Text = "";
                        txt75__.Text = "";
                        txt76__.Text = "";
                        txt77__.Text = "";
                        txt78__.Text = "";
                        txt79__.Text = "";
                        txt80__.Text = "";
                        txt81__.Text = "";
                        txt82__.Text = "";
                        txt83__.Text = "";


                        b = b + 37;
                        qtde2 = qtde2 - 37;

                        if (qtde2 <= 0)
                        {
                            imprime2 = false;
                        }
                    }






                    //finalizando
                    pictureBox27.Visible = false;
                    Cursor = Cursors.Default;
                    crystalReportViewer1.ReportSource = rpt;
                    return;

                }
                contImp++;


                if (contImp > 3)
                {
                    //imprime
                    tabControl1.SelectedTab = tabPage3;
                    panel8.VerticalScroll.Value = 0;
                    /*Print(this.panel9);

                    if (checkBox4.Checked == false)
                    {
                        Form print = new Print();
                        print.ShowDialog();
                    }*/

                    //código para imprimir aqui
                    //*************************

                    crystalReportViewer1.ReportSource = rpt;

                    // crystalReportViewer1.PrintReport();


                    string message = "Deseja Imprimir esta página?\n\n" + informarNomes;
                    string caption = "Reimpressão";
                    informarNomes = "";
                    MessageBoxButtons buttons = MessageBoxButtons.YesNo;
                    DialogResult result;

                    // Displays the MessageBox.

                    result = MessageBox.Show(this, message, caption, buttons,
                    MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);


                    if (result == DialogResult.No)
                    {
                        
                        

                    }
                    if (result == DialogResult.Yes)
                    {
                        rpt.PrintToPrinter(1, false, 0, 0);
                        pag++;
                        Form print = new Print("Imprimindo Recibos Pág. " + Convert.ToString(pag));
                        print.ShowDialog();
                    }
                    
                    //*************************
                    //Preparar campos do relatório
                    //TextObject txt120 = (TextObject)rpt.ReportDefinition.ReportObjects["Text120"]; //Instancie um objeto do tipo TextObject e informe o nome do textbox
                    //txt120.Text = "";
                    TextObject txt256 = (TextObject)rpt.ReportDefinition.ReportObjects["Text256"]; //Instancie um objeto do tipo TextObject e informe o nome do textbox
                    txt256.Text = "";
                    TextObject txt110 = (TextObject)rpt.ReportDefinition.ReportObjects["Text110"]; //Instancie um objeto do tipo TextObject e informe o nome do textbox
                    txt110.Text = "0";
                    TextObject txt111 = (TextObject)rpt.ReportDefinition.ReportObjects["Text111"]; //Instancie um objeto do tipo TextObject e informe o nome do textbox
                    txt111.Text = "0";
                    TextObject txt112 = (TextObject)rpt.ReportDefinition.ReportObjects["Text112"]; //Instancie um objeto do tipo TextObject e informe o nome do textbox
                    txt112.Text = "0";
                    TextObject txt113 = (TextObject)rpt.ReportDefinition.ReportObjects["Text113"]; //Instancie um objeto do tipo TextObject e informe o nome do textbox
                    txt113.Text = "0";
                    TextObject txt114 = (TextObject)rpt.ReportDefinition.ReportObjects["Text114"]; //Instancie um objeto do tipo TextObject e informe o nome do textbox
                    txt114.Text = "0";
                    TextObject txt115 = (TextObject)rpt.ReportDefinition.ReportObjects["Text115"]; //Instancie um objeto do tipo TextObject e informe o nome do textbox
                    txt115.Text = "0";
                    TextObject txt116 = (TextObject)rpt.ReportDefinition.ReportObjects["Text116"]; //Instancie um objeto do tipo TextObject e informe o nome do textbox
                    txt116.Text = "0";
                    TextObject txt121 = (TextObject)rpt.ReportDefinition.ReportObjects["Text121"]; //Instancie um objeto do tipo TextObject e informe o nome do textbox
                    txt121.Text = "";
                    //TextObject txt122 = (TextObject)rpt.ReportDefinition.ReportObjects["Text122"]; //Instancie um objeto do tipo TextObject e informe o nome do textbox
                    //txt122.Text = "";
                    TextObject txt123 = (TextObject)rpt.ReportDefinition.ReportObjects["Text123"]; //Instancie um objeto do tipo TextObject e informe o nome do textbox
                    txt123.Text = "";
                    TextObject txt117 = (TextObject)rpt.ReportDefinition.ReportObjects["Text117"]; //Instancie um objeto do tipo TextObject e informe o nome do textbox
                    txt117.Text = "0";
                    TextObject txt118 = (TextObject)rpt.ReportDefinition.ReportObjects["Text118"]; //Instancie um objeto do tipo TextObject e informe o nome do textbox
                    txt118.Text = "0";
                    //TextObject txt119 = (TextObject)rpt.ReportDefinition.ReportObjects["Text119"]; //Instancie um objeto do tipo TextObject e informe o nome do textbox
                    txt119.Text = "0";

                    //TextObject txt186 = (TextObject)rpt.ReportDefinition.ReportObjects["Text186"]; //Instancie um objeto do tipo TextObject e informe o nome do textbox
                    //txt186.Text = "";
                    TextObject txt257 = (TextObject)rpt.ReportDefinition.ReportObjects["Text257"]; //Instancie um objeto do tipo TextObject e informe o nome do textbox
                    txt257.Text = "";
                    TextObject txt176 = (TextObject)rpt.ReportDefinition.ReportObjects["Text176"]; //Instancie um objeto do tipo TextObject e informe o nome do textbox
                    txt176.Text = "0";
                    TextObject txt177 = (TextObject)rpt.ReportDefinition.ReportObjects["Text177"]; //Instancie um objeto do tipo TextObject e informe o nome do textbox
                    txt177.Text = "0";
                    TextObject txt178 = (TextObject)rpt.ReportDefinition.ReportObjects["Text178"]; //Instancie um objeto do tipo TextObject e informe o nome do textbox
                    txt178.Text = "0";
                    TextObject txt179 = (TextObject)rpt.ReportDefinition.ReportObjects["Text179"]; //Instancie um objeto do tipo TextObject e informe o nome do textbox
                    txt179.Text = "0";
                    TextObject txt180 = (TextObject)rpt.ReportDefinition.ReportObjects["Text180"]; //Instancie um objeto do tipo TextObject e informe o nome do textbox
                    txt180.Text = "0";
                    TextObject txt181 = (TextObject)rpt.ReportDefinition.ReportObjects["Text181"]; //Instancie um objeto do tipo TextObject e informe o nome do textbox
                    txt181.Text = "0";
                    TextObject txt182 = (TextObject)rpt.ReportDefinition.ReportObjects["Text182"]; //Instancie um objeto do tipo TextObject e informe o nome do textbox
                    txt182.Text = "0";
                    TextObject txt187 = (TextObject)rpt.ReportDefinition.ReportObjects["Text187"]; //Instancie um objeto do tipo TextObject e informe o nome do textbox
                    txt187.Text = "";
                    //TextObject txt188 = (TextObject)rpt.ReportDefinition.ReportObjects["Text188"]; //Instancie um objeto do tipo TextObject e informe o nome do textbox
                    //txt188.Text = "";
                    TextObject txt189 = (TextObject)rpt.ReportDefinition.ReportObjects["Text189"]; //Instancie um objeto do tipo TextObject e informe o nome do textbox
                    txt189.Text = "";
                    TextObject txt183 = (TextObject)rpt.ReportDefinition.ReportObjects["Text183"]; //Instancie um objeto do tipo TextObject e informe o nome do textbox
                    txt183.Text = "0";
                    TextObject txt184 = (TextObject)rpt.ReportDefinition.ReportObjects["Text184"]; //Instancie um objeto do tipo TextObject e informe o nome do textbox
                    txt184.Text = "0";
                    //TextObject txt185 = (TextObject)rpt.ReportDefinition.ReportObjects["Text185"]; //Instancie um objeto do tipo TextObject e informe o nome do textbox
                    txt185.Text = "0";


                    //TextObject txt219 = (TextObject)rpt.ReportDefinition.ReportObjects["Text219"]; //Instancie um objeto do tipo TextObject e informe o nome do textbox
                    //txt219.Text = "";
                    TextObject txt258 = (TextObject)rpt.ReportDefinition.ReportObjects["Text258"]; //Instancie um objeto do tipo TextObject e informe o nome do textbox
                    txt258.Text = "";
                    TextObject txt209 = (TextObject)rpt.ReportDefinition.ReportObjects["Text209"]; //Instancie um objeto do tipo TextObject e informe o nome do textbox
                    txt209.Text = "0";
                    TextObject txt210 = (TextObject)rpt.ReportDefinition.ReportObjects["Text210"]; //Instancie um objeto do tipo TextObject e informe o nome do textbox
                    txt210.Text = "0";
                    TextObject txt211 = (TextObject)rpt.ReportDefinition.ReportObjects["Text211"]; //Instancie um objeto do tipo TextObject e informe o nome do textbox
                    txt211.Text = "0";
                    TextObject txt212 = (TextObject)rpt.ReportDefinition.ReportObjects["Text212"]; //Instancie um objeto do tipo TextObject e informe o nome do textbox
                    txt212.Text = "0";
                    TextObject txt213 = (TextObject)rpt.ReportDefinition.ReportObjects["Text213"]; //Instancie um objeto do tipo TextObject e informe o nome do textbox
                    txt213.Text = "0";
                    TextObject txt214 = (TextObject)rpt.ReportDefinition.ReportObjects["Text214"]; //Instancie um objeto do tipo TextObject e informe o nome do textbox
                    txt214.Text = "0";
                    TextObject txt215 = (TextObject)rpt.ReportDefinition.ReportObjects["Text215"]; //Instancie um objeto do tipo TextObject e informe o nome do textbox
                    txt215.Text = "0";
                    TextObject txt220 = (TextObject)rpt.ReportDefinition.ReportObjects["Text220"]; //Instancie um objeto do tipo TextObject e informe o nome do textbox
                    txt220.Text = "";
                    //TextObject txt221 = (TextObject)rpt.ReportDefinition.ReportObjects["Text221"]; //Instancie um objeto do tipo TextObject e informe o nome do textbox
                    //txt221.Text = "";
                    TextObject txt222 = (TextObject)rpt.ReportDefinition.ReportObjects["Text222"]; //Instancie um objeto do tipo TextObject e informe o nome do textbox
                    txt222.Text = "";
                    TextObject txt216 = (TextObject)rpt.ReportDefinition.ReportObjects["Text216"]; //Instancie um objeto do tipo TextObject e informe o nome do textbox
                    txt216.Text = "0";
                    TextObject txt217 = (TextObject)rpt.ReportDefinition.ReportObjects["Text217"]; //Instancie um objeto do tipo TextObject e informe o nome do textbox
                    txt217.Text = "0";
                    //TextObject txt218 = (TextObject)rpt.ReportDefinition.ReportObjects["Text218"]; //Instancie um objeto do tipo TextObject e informe o nome do textbox
                    txt218.Text = "0";


                    //TextObject txt252 = (TextObject)rpt.ReportDefinition.ReportObjects["Text252"]; //Instancie um objeto do tipo TextObject e informe o nome do textbox
                    //txt252.Text = "";
                    TextObject txt259 = (TextObject)rpt.ReportDefinition.ReportObjects["Text259"]; //Instancie um objeto do tipo TextObject e informe o nome do textbox
                    txt259.Text = "";
                    TextObject txt242 = (TextObject)rpt.ReportDefinition.ReportObjects["Text242"]; //Instancie um objeto do tipo TextObject e informe o nome do textbox
                    txt242.Text = "0";
                    TextObject txt243 = (TextObject)rpt.ReportDefinition.ReportObjects["Text243"]; //Instancie um objeto do tipo TextObject e informe o nome do textbox
                    txt243.Text = "0";
                    TextObject txt244 = (TextObject)rpt.ReportDefinition.ReportObjects["Text244"]; //Instancie um objeto do tipo TextObject e informe o nome do textbox
                    txt244.Text = "0";
                    TextObject txt245 = (TextObject)rpt.ReportDefinition.ReportObjects["Text245"]; //Instancie um objeto do tipo TextObject e informe o nome do textbox
                    txt245.Text = "0";
                    TextObject txt246 = (TextObject)rpt.ReportDefinition.ReportObjects["Text246"]; //Instancie um objeto do tipo TextObject e informe o nome do textbox
                    txt246.Text = "0";
                    TextObject txt247 = (TextObject)rpt.ReportDefinition.ReportObjects["Text247"]; //Instancie um objeto do tipo TextObject e informe o nome do textbox
                    txt247.Text = "0";
                    TextObject txt248 = (TextObject)rpt.ReportDefinition.ReportObjects["Text248"]; //Instancie um objeto do tipo TextObject e informe o nome do textbox
                    txt248.Text = "0";
                    TextObject txt253 = (TextObject)rpt.ReportDefinition.ReportObjects["Text253"]; //Instancie um objeto do tipo TextObject e informe o nome do textbox
                    txt253.Text = "";
                    //TextObject txt254 = (TextObject)rpt.ReportDefinition.ReportObjects["Text254"]; //Instancie um objeto do tipo TextObject e informe o nome do textbox
                    //txt254.Text = "";
                    TextObject txt255 = (TextObject)rpt.ReportDefinition.ReportObjects["Text255"]; //Instancie um objeto do tipo TextObject e informe o nome do textbox
                    txt255.Text = "";
                    TextObject txt249 = (TextObject)rpt.ReportDefinition.ReportObjects["Text249"]; //Instancie um objeto do tipo TextObject e informe o nome do textbox
                    txt249.Text = "0";
                    TextObject txt250 = (TextObject)rpt.ReportDefinition.ReportObjects["Text250"]; //Instancie um objeto do tipo TextObject e informe o nome do textbox
                    txt250.Text = "0";
                    //TextObject txt251 = (TextObject)rpt.ReportDefinition.ReportObjects["Text251"]; //Instancie um objeto do tipo TextObject e informe o nome do textbox
                    txt251.Text = "0";



                    //********************************************************************************
                    //********************************************************************************


                    contImp = 0;

                }

            }      
        }

        private void pictureBox36_Click(object sender, EventArgs e)
        {
            

            
        }

        private void button33_Click(object sender, EventArgs e)
        {
            Form listaa = new ListaAtraso();
            listaa.ShowDialog();
        }

        private void dataGridView2_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            pictureBox10.BorderStyle = BorderStyle.None;
            //tabControl1.SelectedTab = tabPage1;
            label6.ForeColor = Color.Black;
            tabControl1.TabPages.Remove(tabPage6);

            pictureBox10.BorderStyle = BorderStyle.Fixed3D;
            label6.ForeColor = Color.Red;
            tabControl1.TabPages.Add(tabPage6);
            tabControl1.SelectedTab = tabPage6;

            dataGridView4.DataSource = DAL.Lista_Ativo();
            if (dataGridView4.Rows.Count > 0)
            {
                for (int i = 0; i < dataGridView4.Rows.Count; i++)
                {
                    dataGridView4.Columns[0].Width = 200;
                    dataGridView4.Columns[1].Width = 50;
                    if (dataGridView4.Rows[i].Cells[2].Value.ToString() == "0")
                    {
                        dataGridView4.Rows[i].Cells[0].Style.BackColor = Color.White;
                        dataGridView4.Rows[i].Cells[1].Style.BackColor = Color.White;
                        dataGridView4.Rows[i].Cells[2].Style.BackColor = Color.White;
                    }
                    else
                    {
                        dataGridView4.Rows[i].Cells[0].Style.BackColor = Color.LightCyan;
                        dataGridView4.Rows[i].Cells[1].Style.BackColor = Color.LightCyan;
                        dataGridView4.Rows[i].Cells[2].Style.BackColor = Color.LightCyan;
                    }
                }
            }
            // Set row labels.
            int rowNumber = 1;
            foreach (DataGridViewRow row in dataGridView4.Rows)
            {
                if (row.IsNewRow) continue;
                row.HeaderCell.Value = "" + rowNumber;
                rowNumber = rowNumber + 1;
            }
            dataGridView4.AutoResizeRowHeadersWidth(DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders); 
            

            nomes = DAL.Lista_Nome();
            for (int i = 0; i < nomes.Rows.Count; i++)
            {
                if (nomes.Rows[i]["Nome"].ToString() == dataGridView2.Rows[dataGridView2.SelectedCells[0].RowIndex].Cells[0].FormattedValue.ToString())
                {
                    label19.Text = nomes.Rows[i]["Id"].ToString();
                    textBox1.Text = nomes.Rows[i]["Nome"].ToString();
                    textBox2.Text = nomes.Rows[i]["Anterior"].ToString();
                    textBox3.Text = nomes.Rows[i]["Atual"].ToString();
                    textBox5.Text = nomes.Rows[i]["Atraso"].ToString();
                    richTextBox1.Text = nomes.Rows[i]["Observação"].ToString();
                    comboBox1.Text = nomes.Rows[i]["TX_Comercial"].ToString();
                    DataTable pag = DAL.Pagou_Id_Lista(Convert.ToInt32(label19.Text));
                    if (pag.Rows.Count > 0)
                    {
                        label30.Text = "Pagamento Efetuado para Mês Atual";
                    }
                    if (pag.Rows.Count <= 0)
                    {
                        label30.Text = "";
                    }
                    Global.Config.Cad_ID = "";
                    textBox3.Focus();
                    if (!String.IsNullOrEmpty(textBox3.Text))
                    {
                        textBox3.SelectionStart = 0;
                        textBox3.SelectionLength = textBox3.Text.Length;
                    }
                    //return;
                }
            }
            int linha = 0;
            linha = dataGridView2.CurrentRow.Index;
                        
            dataGridView4.CurrentCell = dataGridView4.Rows[linha].Cells[0];
            
           
        }

        private void dataGridView3_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            pictureBox10.BorderStyle = BorderStyle.None;
            //tabControl1.SelectedTab = tabPage1;
            label6.ForeColor = Color.Black;
            tabControl1.TabPages.Remove(tabPage6);

            pictureBox10.BorderStyle = BorderStyle.Fixed3D;
            label6.ForeColor = Color.Red;
            tabControl1.TabPages.Add(tabPage6);
            tabControl1.SelectedTab = tabPage6;

            dataGridView4.DataSource = DAL.Lista_Ativo();
            if (dataGridView4.Rows.Count > 0)
            {
                for (int i = 0; i < dataGridView4.Rows.Count; i++)
                {
                    dataGridView4.Columns[0].Width = 200;
                    dataGridView4.Columns[1].Width = 50;
                    if (dataGridView4.Rows[i].Cells[2].Value.ToString() == "0")
                    {
                        dataGridView4.Rows[i].Cells[0].Style.BackColor = Color.White;
                        dataGridView4.Rows[i].Cells[1].Style.BackColor = Color.White;
                        dataGridView4.Rows[i].Cells[2].Style.BackColor = Color.White;
                    }
                    else
                    {
                        dataGridView4.Rows[i].Cells[0].Style.BackColor = Color.LightCyan;
                        dataGridView4.Rows[i].Cells[1].Style.BackColor = Color.LightCyan;
                        dataGridView4.Rows[i].Cells[2].Style.BackColor = Color.LightCyan;
                    }
                }
            }
            // Set row labels.
            int rowNumber = 1;
            foreach (DataGridViewRow row in dataGridView4.Rows)
            {
                if (row.IsNewRow) continue;
                row.HeaderCell.Value = "" + rowNumber;
                rowNumber = rowNumber + 1;
            }
            dataGridView4.AutoResizeRowHeadersWidth(DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders); 


            nomes = DAL.Lista_Nome();
            for (int i = 0; i < nomes.Rows.Count; i++)
            {
                if (nomes.Rows[i]["Nome"].ToString() == dataGridView3.Rows[dataGridView3.SelectedCells[0].RowIndex].Cells[0].FormattedValue.ToString())
                {
                    label19.Text = nomes.Rows[i]["Id"].ToString();
                    textBox1.Text = nomes.Rows[i]["Nome"].ToString();
                    textBox2.Text = nomes.Rows[i]["Anterior"].ToString();
                    textBox3.Text = nomes.Rows[i]["Atual"].ToString();
                    textBox5.Text = nomes.Rows[i]["Atraso"].ToString();
                    richTextBox1.Text = nomes.Rows[i]["Observação"].ToString();
                    comboBox1.Text = nomes.Rows[i]["TX_Comercial"].ToString();
                    DataTable pag = DAL.Pagou_Id_Lista(Convert.ToInt32(label19.Text));
                    if (pag.Rows.Count > 0)
                    {
                        label30.Text = "Pagamento Efetuado para Mês Atual";
                    }
                    if (pag.Rows.Count <= 0)
                    {
                        label30.Text = "";
                    }
                    Global.Config.Cad_ID = "";
                    textBox3.Focus();
                    if (!String.IsNullOrEmpty(textBox3.Text))
                    {
                        textBox3.SelectionStart = 0;
                        textBox3.SelectionLength = textBox3.Text.Length;
                    }
                    //return;
                }
            }
            int linha = 0;
            linha = dataGridView3.CurrentRow.Index;

            dataGridView4.CurrentCell = dataGridView4.Rows[linha].Cells[0];
        }

        private void pictureBox25_MouseEnter(object sender, EventArgs e)
        {
            pictureBox25.Width = 45;
            pictureBox25.Height = 45;
            this.Cursor = Cursors.Hand;
        }

        private void pictureBox34_MouseEnter_1(object sender, EventArgs e)
        {
            pictureBox34.Width = 45;
            pictureBox34.Height = 45;
            Cursor = Cursors.Hand;
        }

        private void pictureBox25_MouseLeave(object sender, EventArgs e)
        {
            pictureBox25.Width = 40;
            pictureBox25.Height = 40;
            this.Cursor = Cursors.Default;
        }

        private void pictureBox34_MouseLeave_1(object sender, EventArgs e)
        {
            pictureBox34.Width = 40;
            pictureBox34.Height = 40;
            Cursor = Cursors.Default;
        }
        int NumReg = 0;
        int NumRegCont = 0;
        private void pictureBox34_Click(object sender, EventArgs e)
        {
            
            nomes = DAL.Lista_Nome();
            for (int i = 0; i < nomes.Rows.Count; i++)
            {
                NumReg++;
            }
            if (NumRegCont + 4 <= NumReg)
            {
                NumRegCont += 4;
                //MessageBox.Show(Convert.ToString(NumRegCont - 4));
                //MessageBox.Show(Convert.ToString(NumRegCont - 3));
                //MessageBox.Show(Convert.ToString(NumRegCont - 2));
                //MessageBox.Show(Convert.ToString(NumRegCont - 1));

            }
            
        }

        private void pictureBox25_Click(object sender, EventArgs e)
        {
            nomes = DAL.Lista_Nome();
            for (int i = 0; i < nomes.Rows.Count; i++)
            {
                NumReg++;
            }
            if (NumRegCont - 4 >= 4)
            {
                NumRegCont -= 4;
                //MessageBox.Show(Convert.ToString(NumRegCont - 4));
                //MessageBox.Show(Convert.ToString(NumRegCont - 3));
                //MessageBox.Show(Convert.ToString(NumRegCont - 2));
                //MessageBox.Show(Convert.ToString(NumRegCont - 1));
            }
        }
    }
}
