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
    public partial class Procurar : Form
    {
        public Procurar()
        {
            InitializeComponent();
        }

        private void Procurar_Load(object sender, EventArgs e)
        {
            Location = new Point(Location.X + 180, Location.Y);
            dataGridView1.DataSource = DAL.Lista_Ativo();
            if (dataGridView1.Rows.Count > 0)
            {
                for (int i = 0; i < dataGridView1.Rows.Count; i++)
                {
                    dataGridView1.Columns[0].Width = 40;
                }
            }
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked == true)
            {
                dataGridView1.DataSource = DAL.Lista_Inativo();
                if (dataGridView1.Rows.Count > 0)
                {
                    for (int i = 0; i < dataGridView1.Rows.Count; i++)
                    {
                        dataGridView1.Columns[0].Width = 40;
                    }
                }
            }
            if (checkBox1.Checked == false)
            {
                dataGridView1.DataSource = DAL.Lista_Ativo();
                if (dataGridView1.Rows.Count > 0)
                {
                    for (int i = 0; i < dataGridView1.Rows.Count; i++)
                    {
                        dataGridView1.Columns[0].Width = 40; 
                    }
                }
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (checkBox1.Checked == false)
            {
                if (dataGridView1.Rows.Count > 0)
                {
                    Global.Config.Cad_ID = dataGridView1.Rows[dataGridView1.SelectedCells[0].RowIndex].Cells[0].FormattedValue.ToString();

                }    
            }
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
