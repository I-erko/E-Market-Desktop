﻿using System;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Windows.Forms;

namespace CapaGUI
{
    public partial class FrmProducto : Form
    {
        private string RutaOrigen;
        private string RutaDestino;
        private string Directorio = "C:\\Users\\yerko\\Desktop\\CODEPROY-GAY\\Directorio\\";
        private string NombreAnt;

        public FrmProducto()
        {
            InitializeComponent();
        }

        private void Listar()
        {
            try
            {
                ServiceProducto.WebServiceProductoSoapClient producto = new ServiceProducto.WebServiceProductoSoapClient();
                DataTable dt = producto.WebListar().Tables[0];
                DgvListado.DataSource = dt;
                this.Formato();
                this.Limpiar();
                LblTotal.Text = "Total registros: " + Convert.ToString(DgvListado.Rows.Count);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ex.StackTrace);
            }
        }

        private void Buscar()
        {
            try
            {
                ServiceProducto.WebServiceProductoSoapClient producto = new ServiceProducto.WebServiceProductoSoapClient();
                DataTable dt = producto.WebBuscar(TxtBuscar.Text).Tables[0];
                DgvListado.DataSource = dt;
                this.Formato();
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
            DgvListado.Columns[2].Visible = false;
            DgvListado.Columns[0].Width = 100;
            DgvListado.Columns[1].Width = 50;
            DgvListado.Columns[3].Width = 100;
            DgvListado.Columns[3].HeaderText = "Categoría";
            DgvListado.Columns[4].Width = 100;
            DgvListado.Columns[4].HeaderText = "Código";
            DgvListado.Columns[5].Width = 150;
            DgvListado.Columns[6].Width = 100;
            DgvListado.Columns[6].HeaderText = "Precio Venta";
            DgvListado.Columns[7].Width = 60;
            DgvListado.Columns[8].Width = 200;
            DgvListado.Columns[8].HeaderText = "Descripción";
            DgvListado.Columns[9].Width = 100;
            DgvListado.Columns[10].Width = 100;

        }

        private void Limpiar()
        {
            TxtBuscar.Clear();
            TxtNombre.Clear();
            TxtId.Clear();
            TxtCodigo.Clear();
            PanelCodigo.BackgroundImage = null;
            BtnGuardarCodigo.Enabled = true;
            TxtPrecioVenta.Clear();
            TxtStock.Clear();
            TxtImagen.Clear();
            PicImagen.Image = null;
            TxtDescripcion.Clear();
            BtnInsertar.Visible = true;
            BtnActualizar.Visible = false;
            ErrorIcono.Clear();
            this.RutaDestino = "";
            this.RutaOrigen = "";

            DgvListado.Columns[0].Visible = false;
            BtnActivar.Visible = false;
            BtnDesactivar.Visible = false;
            BtnEliminar.Visible = false;
            ChkSeleccionar.Checked = false;
        }

        private void MensajeError(string Mensaje)
        {
            MessageBox.Show(Mensaje, "Sistema de ventas", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void MensajeOk(string Mensaje)
        {
            MessageBox.Show(Mensaje, "Sistema de ventas", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void CargarCategoria()
        {
            try
            {
                ServiceCategoria.WebServiceCategoriaSoapClient cat = new ServiceCategoria.WebServiceCategoriaSoapClient();
                DataTable dt = cat.WebSeleccionar().Tables[0];
                CboCategoria.DataSource = dt;
                CboCategoria.ValueMember = "idcategoria";
                CboCategoria.DisplayMember = "nombre";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ex.StackTrace);
            }
        }

        private void FrmProducto_Load(object sender, EventArgs e)
        {
            this.Listar();
            this.CargarCategoria();
        }

        private void BtnBuscar_Click(object sender, EventArgs e)
        {
            this.Buscar();
        }

        private void BtnCargarImagen_Click(object sender, EventArgs e)
        {
            OpenFileDialog file = new OpenFileDialog();
            file.Filter = "Image files (*.jpg, *.jpeg, *.jpe, *.jfif, *.png) | *.jpg; *.jpeg; *.jpe; *.jfif; *.png";
            if (file.ShowDialog() == DialogResult.OK)
            {
                PicImagen.Image = Image.FromFile(file.FileName);
                TxtImagen.Text = file.FileName.Substring(file.FileName.LastIndexOf("\\") + 1);
                this.RutaOrigen = file.FileName;
            }
        }

        private void BtnGenerar_Click(object sender, EventArgs e)
        {
            BarcodeLib.Barcode Codigo = new BarcodeLib.Barcode();
            Codigo.IncludeLabel = true;
            PanelCodigo.BackgroundImage = Codigo.Encode(BarcodeLib.TYPE.CODE128, TxtCodigo.Text, Color.Black, Color.White, 332, 100);
            BtnGuardarCodigo.Enabled = true;
        }

        private void BtnGuardarCodigo_Click(object sender, EventArgs e)
        {
            Image imgFinal = (Image)PanelCodigo.BackgroundImage.Clone();

            SaveFileDialog DialogoGuardar = new SaveFileDialog();
            DialogoGuardar.AddExtension = true;
            DialogoGuardar.Filter = "Image PNG (*.png) | *.png";
            DialogoGuardar.ShowDialog();
            if (!string.IsNullOrEmpty(DialogoGuardar.FileName))
            {
                imgFinal.Save(DialogoGuardar.FileName, ImageFormat.Png);
            }
            imgFinal.Dispose();
        }

        private void BtnInsertar_Click(object sender, EventArgs e)
        {
            try
            {
                string Rpta = "";
                if (CboCategoria.Text == string.Empty || TxtNombre.Text == string.Empty
                    || TxtPrecioVenta.Text == string.Empty || TxtStock.Text == string.Empty)
                {
                    this.MensajeError("Falta ingresar algunos datos, serán remarcados");
                    ErrorIcono.SetError(CboCategoria, "Seleccione una categoría");
                    ErrorIcono.SetError(TxtNombre, "Ingrese un nombre");
                    ErrorIcono.SetError(TxtPrecioVenta, "Ingrese un precio");
                    ErrorIcono.SetError(TxtStock, "Ingrese un stock inicial");
                }
                else
                {
                    ServiceProducto.WebServiceProductoSoapClient producto = new ServiceProducto.WebServiceProductoSoapClient();
                    Rpta = producto.WebInsertar(Convert.ToInt32(CboCategoria.SelectedValue), TxtCodigo.Text.Trim(),
                        TxtNombre.Text.Trim(), Convert.ToDecimal(TxtPrecioVenta.Text), Convert.ToInt32(TxtStock.Text), TxtDescripcion.Text.Trim(),
                        TxtImagen.Text.Trim());
                    if (Rpta.Equals("OK"))
                    {
                        this.MensajeOk("Se insertó correctamente el registro");
                        if (TxtImagen.Text != string.Empty)
                        {
                            this.RutaDestino = this.Directorio + TxtImagen.Text;
                            File.Copy(this.RutaOrigen, this.RutaDestino);
                        }
                        this.Listar();
                    }
                    else
                    {
                        this.MensajeError(Rpta);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ex.StackTrace);
            }
        }

        private void DgvListado_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                this.Limpiar();
                BtnActualizar.Visible = true;
                BtnInsertar.Visible = false;
                TxtId.Text = Convert.ToString(DgvListado.CurrentRow.Cells["ID"].Value);
                CboCategoria.SelectedValue = Convert.ToString(DgvListado.CurrentRow.Cells["idcategoria"].Value);
                TxtCodigo.Text = Convert.ToString(DgvListado.CurrentRow.Cells["Codigo"].Value);
                this.NombreAnt = Convert.ToString(DgvListado.CurrentRow.Cells["Nombre"].Value);
                TxtNombre.Text = Convert.ToString(DgvListado.CurrentRow.Cells["Nombre"].Value);
                TxtPrecioVenta.Text = Convert.ToString(DgvListado.CurrentRow.Cells["Precio_Venta"].Value);
                TxtStock.Text = Convert.ToString(DgvListado.CurrentRow.Cells["Stock"].Value);
                TxtDescripcion.Text = Convert.ToString(DgvListado.CurrentRow.Cells["Descripcion"].Value);
                string Imagen;
                Imagen = Convert.ToString(DgvListado.CurrentRow.Cells["Imagen"].Value);
                if (Imagen != string.Empty)
                {
                    PicImagen.Image = Image.FromFile(this.Directorio + Imagen);
                    TxtImagen.Text = Imagen;
                }
                else
                {
                    PicImagen.Image = null;
                    TxtImagen.Text = "";
                }
                TabGeneral.SelectedIndex = 1;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Seleccione desde la celda nombre" + " Error: " + ex.Message);
            }
        }

        private void BtnActualizar_Click(object sender, EventArgs e)
        {
            try
            {
                string Rpta = "";
                if (TxtId.Text == string.Empty || CboCategoria.Text == string.Empty || TxtNombre.Text == string.Empty
                    || TxtPrecioVenta.Text == string.Empty || TxtStock.Text == string.Empty)
                {
                    this.MensajeError("Falta ingresar algunos datos, serán remarcados");
                    ErrorIcono.SetError(CboCategoria, "Seleccione una categoría");
                    ErrorIcono.SetError(TxtNombre, "Ingrese un nombre");
                    ErrorIcono.SetError(TxtPrecioVenta, "Ingrese un precio");
                    ErrorIcono.SetError(TxtStock, "Ingrese un stock inicial");
                }
                else
                {
                    ServiceProducto.WebServiceProductoSoapClient producto = new ServiceProducto.WebServiceProductoSoapClient();
                    Rpta = producto.WebActualizar(Convert.ToInt32(TxtId.Text), Convert.ToInt32(CboCategoria.SelectedValue), TxtCodigo.Text.Trim(),
                        this.NombreAnt, TxtNombre.Text.Trim(), Convert.ToDecimal(TxtPrecioVenta.Text), Convert.ToInt32(TxtStock.Text), TxtDescripcion.Text.Trim(),
                        TxtImagen.Text.Trim());
                    if (Rpta.Equals("OK"))
                    {
                        this.MensajeOk("Se actualizó correctamente el registro");
                        if (TxtImagen.Text != string.Empty && this.RutaOrigen != string.Empty)
                        {
                            this.RutaDestino = this.Directorio + TxtImagen.Text;
                            File.Copy(this.RutaOrigen, this.RutaDestino);
                        }
                        this.Listar();
                        TabGeneral.SelectedIndex = 0;
                    }
                    else
                    {
                        this.MensajeError(Rpta);
                    }
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ex.StackTrace);
            }
        }

        private void BtnCancelar_Click(object sender, EventArgs e)
        {
            this.Limpiar();
            TabGeneral.SelectedIndex = 0;
        }

        private void DgvListado_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == DgvListado.Columns["Seleccionar"].Index)
            {
                DataGridViewCheckBoxCell ChkEliminar = (DataGridViewCheckBoxCell)DgvListado.Rows[e.RowIndex].Cells["Seleccionar"];
                ChkEliminar.Value = !Convert.ToBoolean(ChkEliminar.Value);
            }
        }

        private void ChkSeleccionar_CheckedChanged(object sender, EventArgs e)
        {
            if (ChkSeleccionar.Checked)
            {
                DgvListado.Columns[0].Visible = true;
                BtnActivar.Visible = true;
                BtnDesactivar.Visible = true;
                BtnEliminar.Visible = true;
            }
            else
            {
                DgvListado.Columns[0].Visible = false;
                BtnActivar.Visible = false;
                BtnDesactivar.Visible = false;
                BtnEliminar.Visible = false;
            }
        }

        private void BtnEliminar_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult Opcion;
                Opcion = MessageBox.Show("Realmente deseas eliminar el/los registro(s)?", "Sistema de ventas", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                if (Opcion == DialogResult.OK)
                {
                    int Codigo;
                    string Rpta = "";
                    string Imagen = "";

                    foreach (DataGridViewRow row in DgvListado.Rows)
                    {
                        if (Convert.ToBoolean(row.Cells[0].Value))
                        {
                            Codigo = Convert.ToInt32(row.Cells[1].Value);
                            Imagen = Convert.ToString(row.Cells[9].Value);
                            ServiceProducto.WebServiceProductoSoapClient producto = new ServiceProducto.WebServiceProductoSoapClient();
                            Rpta = producto.WebEliminar(Codigo);

                            if (Rpta.Equals("OK"))
                            {
                                this.MensajeOk("Se eliminó el registro: " + Convert.ToString(row.Cells[5].Value));
                                File.Delete(this.Directorio + Imagen);
                            }
                            else
                            {
                                this.MensajeError(Rpta);
                            }
                        }
                    }
                    this.Listar();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ex.StackTrace);
            }
        }

        private void BtnActivar_Click(object sender, EventArgs e)
        {
            DialogResult Opcion;
            Opcion = MessageBox.Show("Realmente deseas activar el/los registro(s)?", "Sistema de ventas", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            if (Opcion == DialogResult.OK)
            {
                int Codigo;
                string Rpta = "";
                foreach (DataGridViewRow row in DgvListado.Rows)
                {
                    if (Convert.ToBoolean(row.Cells[0].Value))
                    {
                        Codigo = Convert.ToInt32(row.Cells[1].Value);
                        ServiceProducto.WebServiceProductoSoapClient producto = new ServiceProducto.WebServiceProductoSoapClient();
                        Rpta = producto.WebActivar(Codigo);

                        if (Rpta.Equals("OK"))
                        {
                            this.MensajeOk("Se activó el registro: " + Convert.ToString(row.Cells[5].Value));
                        }
                        else
                        {
                            this.MensajeError(Rpta);
                        }
                    }
                }
                this.Listar();
            }
        }

        private void BtnDesactivar_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult Opcion;
                Opcion = MessageBox.Show("Realmente deseas desactivar el/los registro(s)?", "Sistema de ventas", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                if (Opcion == DialogResult.OK)
                {
                    int Codigo;
                    string Rpta = "";
                    foreach (DataGridViewRow row in DgvListado.Rows)
                    {
                        if (Convert.ToBoolean(row.Cells[0].Value))
                        {
                            Codigo = Convert.ToInt32(row.Cells[1].Value);
                            ServiceProducto.WebServiceProductoSoapClient producto = new ServiceProducto.WebServiceProductoSoapClient();
                            Rpta = producto.WebDesactivar(Codigo);

                            if (Rpta.Equals("OK"))
                            {
                                this.MensajeOk("Se desactivó el registro: " + Convert.ToString(row.Cells[5].Value));
                            }
                            else
                            {
                                this.MensajeError(Rpta);
                            }
                        }
                    }
                    this.Listar();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ex.StackTrace);
            }
        }

        private void BtnReporte_Click(object sender, EventArgs e)
        {
            Reportes.FrmReporteProductos Reporte = new Reportes.FrmReporteProductos();
            Reporte.ShowDialog();
        }
    }
}
