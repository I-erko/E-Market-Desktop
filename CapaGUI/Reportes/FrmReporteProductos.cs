using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CapaGUI.Reportes
{
    public partial class FrmReporteProductos : Form
    {
        public FrmReporteProductos()
        {
            InitializeComponent();
        }

        private void FrmReporteProductos_Load(object sender, EventArgs e)
        {
            // TODO: esta línea de código carga datos en la tabla 'DsSistema.producto_listar' Puede moverla o quitarla según sea necesario.
            this.producto_listarTableAdapter.Fill(this.DsSistema.producto_listar);

            this.reportViewer1.RefreshReport();
        }
    }
}
