using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Prototipo2P.Sentencias.Movimientos;
using Prototipo2P.Objetos;

namespace Prototipo2P.Proceso.MovimientoInventario.Forms
{
    public partial class ListaMovimientos : Form
    {
        public ListaMovimientos()
        {
            InitializeComponent();

            dgv.Columns.Add("codigo", "CODIGO");
            dgv.Columns.Add("tipo", "TIPO MOVIMEINTO");
            dgv.Columns.Add("fecha", "FECHA");
            dgv.Columns.Add("estado", "ESTADO");
            llenarLista();
        }


        private void llenarLista()
        {


            SQL movimientoEncabezado = new SQL();
            
            dgv.Rows.Clear();
            int fila = 0;

            foreach (MovimientoEncabezado movEncTmp in movimientoEncabezado.obtenerEncabezados())
            {
                dgv.Rows.Add();
                dgv.Rows[fila].Cells[0].Value = movEncTmp.CODIGO.ToString();
                dgv.Rows[fila].Cells[1].Value = movEncTmp.TIPO.SIGNO;
                dgv.Rows[fila].Cells[2].Value = movEncTmp.FECHA.ToShortDateString();
                dgv.Rows[fila].Cells[3].Value = movEncTmp.ESTADO.ToString();
                fila++;
            }

        }

        private void Btn_editar_Click(object sender, EventArgs e)
        {

        }
    }
}
