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
    public partial class PrintOptions : Form
    {
        
        public PrintOptions()
        {
            InitializeComponent();
            
        }
       
        
        public PrintOptions(List<string> availableFields)
        {
            InitializeComponent();
            //Verifica quais os campos disponíveis
            foreach (string field in availableFields)
                chklst.Items.Add(field, true);
        }

        public List<string> GetSelectedColumns()
        {
            //"Guarda" os itens seleccionados na ListBox
            List<string> lst = new List<string>();
            foreach (object item in chklst.CheckedItems)
                lst.Add(item.ToString());
            return lst;
        }

        public string PrintTitle
        {
            //"Guarda" o texto referente ao título
            get { return txtTitle.Text; }
        }
        private void btnOK_Click(object sender, EventArgs e)
        {
            // Abre a caixa de diálogo referente à impressão
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            // Fecha a caixa de diálogo referente à impressão
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void PrintOptions_Load(object sender, EventArgs e)
        {
            if (Global.Config.Impressao == "atraso")
            {
                txtTitle.Text = "Associados com Pendências Ativas - Total: " + Global.Config.VA;
            }
            if (Global.Config.Impressao == "leitura")
            {
                txtTitle.Text += " " + System.Globalization.DateTimeFormatInfo.CurrentInfo.GetMonthName(DateTime.Now.Date.Month).ToLower() + " de " + DateTime.Now.Date.Year.ToString();    
            }
            if (Global.Config.Impressao == "medição")
            {
                txtTitle.Text = "AMBRA - ASSOCIAÇÃO DE MORADORES DO BAIRRO RECREIO DAS ACÁCIAS\n           Medição Referente ao Mês de " + System.Globalization.DateTimeFormatInfo.CurrentInfo.GetMonthName(DateTime.Now.Date.Month).ToLower() + " de " + DateTime.Now.Date.Year.ToString();
            }
            if (Global.Config.Impressao == "relatorio")
            {
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
                //txtTitle.Text = mes + " de " + DateTime.Now.Date.Year.ToString();
                txtTitle.Text = "AMBRA - ASSOCIAÇÃO DE MORADORES DO BAIRRO RECREIO DAS ACÁCIAS\n            Relatório Referente ao Mês de " + mes + " de " + DateTime.Now.Date.Year.ToString();
            }
            
        }

        private void txtTitle_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
