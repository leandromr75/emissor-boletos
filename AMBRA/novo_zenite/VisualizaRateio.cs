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
    public partial class VisualizaRateio : Form
    {
        public VisualizaRateio()
        {
            InitializeComponent();
        }

        private void VisualizaRateio_Load(object sender, EventArgs e)
        {
            dataGridView1.DataSource = DAL.Lista_Rateio();
            
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView1.Rows.Count > 0)
            {
                dataGridView2.DataSource = DAL.Lista_Rateio_Parcelado( Convert.ToInt32( dataGridView1.Rows[dataGridView1.SelectedCells[0].RowIndex].Cells[0].FormattedValue.ToString() ));
            }
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView1.Rows.Count > 0)
            {
                string message = "Você deseja baixar este rateio ativo?\nSe for rateio parcelado, todas as parcelas serão baixadas!";
                string caption = "Baixar Rateio";
                MessageBoxButtons buttons = MessageBoxButtons.YesNo;
                DialogResult result;

                // Displays the MessageBox.
                result = MessageBox.Show(this, message, caption, buttons,
                MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);
                if (result == DialogResult.Yes)
                {
                    DAL.Baixar_Rateio_Parcelado(Convert.ToInt32(dataGridView1.Rows[dataGridView1.SelectedCells[0].RowIndex].Cells[0].FormattedValue.ToString()), dataGridView1.Rows[dataGridView1.SelectedCells[0].RowIndex].Cells[2].FormattedValue.ToString());
                    DAL.Baixar_Rateio(Convert.ToInt32(dataGridView1.Rows[dataGridView1.SelectedCells[0].RowIndex].Cells[0].FormattedValue.ToString()));
                    dataGridView1.DataSource = DAL.Lista_Rateio();
                    dataGridView2.DataSource = DAL.Lista_Rateio_Parcelado(0);
                }           
                
            }

        }

        private void dataGridView2_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
