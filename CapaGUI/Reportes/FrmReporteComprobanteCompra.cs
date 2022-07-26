using System;
using System.Windows.Forms;

namespace CapaGUI.Reportes
{
    public partial class FrmReporteComprobanteCompra : Form
    {
        public FrmReporteComprobanteCompra()
        {
            InitializeComponent();
        }

        private void FrmReporteComprobanteCompra_Load(object sender, EventArgs e)
        {
            // TODO: esta línea de código carga datos en la tabla 'DsSistema.ingreso_consulta_fechas' Puede moverla o quitarla según sea necesario.
            this.compra_comprobanteTableAdapter.Fill(this.DsSistema.compra_comprobante, Variables.IdIngreso);

            this.reportViewer1.RefreshReport();
        }
    }
}
