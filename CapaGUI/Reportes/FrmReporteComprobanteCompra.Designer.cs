
namespace CapaGUI.Reportes
{
    partial class FrmReporteComprobanteCompra
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource1 = new Microsoft.Reporting.WinForms.ReportDataSource();
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.DsSistema = new CapaGUI.Reportes.DsSistema();
            this.compra_comprobanteBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.compra_comprobanteTableAdapter = new CapaGUI.Reportes.DsSistemaTableAdapters.compra_comprobanteTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.DsSistema)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.compra_comprobanteBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // reportViewer1
            // 
            this.reportViewer1.Dock = System.Windows.Forms.DockStyle.Fill;
            reportDataSource1.Name = "DsCompra";
            reportDataSource1.Value = this.compra_comprobanteBindingSource;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource1);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "CapaGUI.Reportes.RptComprobanteCompra.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(0, 0);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.ServerReport.BearerToken = null;
            this.reportViewer1.Size = new System.Drawing.Size(800, 450);
            this.reportViewer1.TabIndex = 0;
            // 
            // DsSistema
            // 
            this.DsSistema.DataSetName = "DsSistema";
            this.DsSistema.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // ingreso_consulta_fechasBindingSource
            // 
            this.compra_comprobanteBindingSource.DataMember = "compra_comprobante";
            this.compra_comprobanteBindingSource.DataSource = this.DsSistema;
            // 
            // ingreso_consulta_fechasTableAdapter
            // 
            this.compra_comprobanteTableAdapter.ClearBeforeFill = true;
            // 
            // FrmReporteComprobanteCompra
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.reportViewer1);
            this.Name = "FrmReporteComprobanteCompra";
            this.Text = "Reporte Comprobante Compra";
            this.Load += new System.EventHandler(this.FrmReporteComprobanteCompra_Load);
            ((System.ComponentModel.ISupportInitialize)(this.DsSistema)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.compra_comprobanteBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private System.Windows.Forms.BindingSource compra_comprobanteBindingSource;
        private DsSistema DsSistema;
        private DsSistemaTableAdapters.compra_comprobanteTableAdapter compra_comprobanteTableAdapter;
    }
}