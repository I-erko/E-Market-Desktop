using System;
using System.Windows.Forms;

namespace CapaGUI.Reportes
{
    public partial class FrmReporteComprobanteVenta : Form
    {
        public FrmReporteComprobanteVenta()
        {
            InitializeComponent();
        }

        private void FrmReporteComprobanteVenta_Load(object sender, EventArgs e)
        {
            // TODO: esta línea de código carga datos en la tabla 'DsSistema.venta_comprobante' Puede moverla o quitarla según sea necesario.
            this.venta_comprobanteTableAdapter.Fill(this.DsSistema.venta_comprobante,Variables.IdVenta);

            this.reportViewer1.RefreshReport();
        }
    }
}
