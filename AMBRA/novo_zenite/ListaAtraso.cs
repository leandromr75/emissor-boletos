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
    public partial class ListaAtraso : Form
    {
        public ListaAtraso()
        {
            InitializeComponent();
        }

        private void ListaAtraso_Load(object sender, EventArgs e)
        {
            
            //dataGridView2.DataSource = DAL.Lista_Atraso();
            DataTable temp = DAL.Lista_Atraso();
            DataTable atr  = new DataTable();
            atr.Columns.Add("Nome", typeof(string));
            atr.Columns.Add("Atraso", typeof(string));
            double total = 0;            
            if (temp.Rows.Count > 0)
            {
                for (int i = 0; i < temp.Rows.Count; i++)
                {
                    if (string.IsNullOrEmpty( temp.Rows[i]["Atraso"].ToString()) == false)
                    {
                        if (Convert.ToDecimal( temp.Rows[i]["Atraso"].ToString()) > 0)
                        {
                            atr.Rows.Add(temp.Rows[i]["Nome"].ToString(),temp.Rows[i]["Atraso"].ToString());
                            Double qtde2;
                            if (Double.TryParse(temp.Rows[i]["Atraso"].ToString().Trim(), out qtde2) == true)
                            {
                                total += qtde2;
                            }
                        }
                    }
                }
            }
            dataGridView2.DataSource = atr;
            label2.Text = "R$" + total.ToString("N2");
            dataGridView2.Columns[1].Width = 100;
            
        }

        private void button26_Click(object sender, EventArgs e)
        {
            Global.Config.Impressao = "atraso";
            Global.Config.VA = label2.Text;
            printDGV.Print_DataGridView(dataGridView2);

        }
    }
}
