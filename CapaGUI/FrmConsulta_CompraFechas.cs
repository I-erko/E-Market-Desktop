using System;
using System.Data;
using System.Windows.Forms;

namespace CapaGUI
{
    public partial class FrmConsulta_CompraFechas : Form
    {
        public FrmConsulta_CompraFechas()
        {
            InitializeComponent();
        }

        private void Buscar()
        {
            try
            {
                ServiceIngreso.WebServiceIngresoSoapClient compra = new ServiceIngreso.WebServiceIngresoSoapClient();
                DataTable dt = compra.WebConsultaFechas(Convert.ToDateTime(DtpFechaInicio.Value), Convert.ToDateTime(DtpFechaFin.Value)).Tables[0];
                DgvListado.DataSource = dt;
                //this.Formato();
                this.Limpiar();
                LblTotal.Text = "Total registros: " + Convert.ToString(DgvListado.Rows.Count);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ex.StackTrace);
            }
        }

        private void Formato()
        {
            DgvListado.Columns[0].Visible = false;
            DgvListado.Columns[1].Visible = false;
            DgvListado.Columns[2].Visible = false;
            DgvListado.Columns[0].Width = 100;
            DgvListado.Columns[3].Width = 150;
            DgvListado.Columns[4].Width = 150;
            DgvListado.Columns[5].Width = 100;
            DgvListado.Columns[5].HeaderText = "Documento";
            DgvListado.Columns[6].Width = 70;
            DgvListado.Columns[6].HeaderText = "Serie";
            DgvListado.Columns[7].Width = 70;
            DgvListado.Columns[7].HeaderText = "Número";
            DgvListado.Columns[8].Width = 60;
            DgvListado.Columns[9].Width = 100;
            DgvListado.Columns[10].Width = 100;
            DgvListado.Columns[11].Width = 100;
        }
        private void Limpiar()
        {
            DgvListado.Columns[0].Visible = false;
        }
        private void MensajeError(string Mensaje)
        {
            MessageBox.Show(Mensaje, "Sistema de ventas", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void MensajeOk(string Mensaje)
        {
            MessageBox.Show(Mensaje, "Sistema de ventas", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void DgvListado_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                ServiceIngreso.WebServiceIngresoSoapClient compra = new ServiceIngreso.WebServiceIngresoSoapClient();
                DataTable dt = compra.WebListarDetalle(Convert.ToInt32(DgvListado.CurrentRow.Cells["ID"].Value)).Tables[0];
                DgvMostrarDetalle.DataSource = dt;
                decimal Total, SubTotal;
                decimal Impuesto = Convert.ToDecimal(DgvListado.CurrentRow.Cells["Impuesto"].Value);
                Total = Convert.ToDecimal(DgvListado.CurrentRow.Cells["Total"].Value);
                SubTotal = Total / (1 + Impuesto);
                TxtSubtotalD.Text = SubTotal.ToString("#0.00#");
                TxtTotalImpuestoD.Text = (Total - SubTotal).ToString("#0.00#");
                TxtTotalD.Text = Total.ToString("#0.00#");
                PanelMostrar.Visible = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void BtnComprobante_Click(object sender, EventArgs e)
        {
            try
            {
                Variables.IdIngreso = Convert.ToInt32(DgvListado.CurrentRow.Cells["ID"].Value);
                Reportes.FrmReporteComprobanteCompra reporte = new Reportes.FrmReporteComprobanteCompra();
                reporte.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void BtnCerrarDetalle_Click(object sender, EventArgs e)
        {
            PanelMostrar.Visible = false;
        }

        private void BtnBuscar_Click(object sender, EventArgs e)
        {
            this.Buscar();
        }

        private void FrmConsulta_CompraFechas_Load(object sender, EventArgs e)
        {

        }
    }
}
