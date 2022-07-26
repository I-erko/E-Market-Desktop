using System;
using System.Data;
using System.Windows.Forms;

namespace CapaGUI
{
    public partial class FrmCliente : Form
    {
        private string NombreAnt;

        public FrmCliente()
        {
            InitializeComponent();
        }

        private void Listar()
        {
            try
            {
                ServicePersona.WebServicePersonaSoapClient persona = new ServicePersona.WebServicePersonaSoapClient();
                DataTable dt = persona.WebListarClientes().Tables[0];
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
                ServicePersona.WebServicePersonaSoapClient persona = new ServicePersona.WebServicePersonaSoapClient();
                DataTable dt = persona.WebBuscarClientes(TxtBuscar.Text).Tables[0];
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
            DgvListado.Columns[1].Width = 50;
            DgvListado.Columns[2].Width = 100;
            DgvListado.Columns[2].HeaderText = "Tipo Persona";
            DgvListado.Columns[3].Width = 170;
            DgvListado.Columns[4].Width = 100;
            DgvListado.Columns[4].HeaderText = "Documento";
            DgvListado.Columns[5].Width = 100;
            DgvListado.Columns[5].HeaderText = "Número Doc.";
            DgvListado.Columns[6].Width = 120;
            DgvListado.Columns[6].HeaderText = "Dirección";
            DgvListado.Columns[7].Width = 100;
            DgvListado.Columns[7].HeaderText = "Teléfono";
            DgvListado.Columns[8].Width = 120;
        }

        private void Limpiar()
        {
            TxtBuscar.Clear();
            TxtNombre.Clear();
            TxtId.Clear();
            TxtNumDoc.Clear();
            TxtDireccion.Clear();
            TxtTelefono.Clear();
            TxtEmail.Clear();
            BtnInsertar.Visible = true;
            BtnActualizar.Visible = false;
            ErrorIcono.Clear();

            DgvListado.Columns[0].Visible = false;
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

        private void BtnBuscar_Click(object sender, EventArgs e)
        {
            this.Buscar();
        }

        private void BtnInsertar_Click(object sender, EventArgs e)
        {
            try
            {
                string Rpta = "";
                if (TxtNombre.Text == string.Empty)
                {
                    this.MensajeError("Falta ingresar algunos datos, serán remarcados");
                    ErrorIcono.SetError(TxtNombre, "Ingrese un nombre.");

                }
                else
                {
                    ServicePersona.WebServicePersonaSoapClient persona = new ServicePersona.WebServicePersonaSoapClient();
                    Rpta = persona.WebInsertar("Cliente", TxtNombre.Text.Trim(), CboTipoDoc.Text, TxtNumDoc.Text.Trim(),
                                             TxtDireccion.Text.Trim(), TxtTelefono.Text.Trim(), TxtEmail.Text.Trim());

                    if (Rpta.Equals("OK"))
                    {
                        this.MensajeOk("Se insertó correctamente el registro");
                        this.Limpiar();
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
                this.NombreAnt = Convert.ToString(DgvListado.CurrentRow.Cells["Nombre"].Value);
                TxtNombre.Text = Convert.ToString(DgvListado.CurrentRow.Cells["Nombre"].Value);
                CboTipoDoc.Text = Convert.ToString(DgvListado.CurrentRow.Cells["Tipo_Documento"].Value);
                TxtNumDoc.Text = Convert.ToString(DgvListado.CurrentRow.Cells["Num_Documento"].Value);
                TxtDireccion.Text = Convert.ToString(DgvListado.CurrentRow.Cells["Direccion"].Value);
                TxtTelefono.Text = Convert.ToString(DgvListado.CurrentRow.Cells["Telefono"].Value);
                TxtEmail.Text = Convert.ToString(DgvListado.CurrentRow.Cells["Email"].Value);

                TabGeneral.SelectedIndex = 1;

            }
            catch (Exception ex)
            {

                MessageBox.Show("Seleccione desde la celda nombre. | Error: " + ex.Message);
            }
        }

        private void BtnActualizar_Click(object sender, EventArgs e)
        {
            try
            {
                string Rpta = "";
                if (TxtId.Text == string.Empty || TxtNombre.Text == string.Empty)
                {
                    this.MensajeError("Falta ingresar algunos datos, serán remarcados");
                    ErrorIcono.SetError(TxtNombre, "Ingrese un nombre.");

                }
                else
                {
                    ServicePersona.WebServicePersonaSoapClient persona = new ServicePersona.WebServicePersonaSoapClient();
                    Rpta = persona.WebActualizar(Convert.ToInt32(TxtId.Text), "Cliente", this.NombreAnt, TxtNombre.Text.Trim(), CboTipoDoc.Text, TxtNumDoc.Text.Trim(),
                                             TxtDireccion.Text.Trim(), TxtTelefono.Text.Trim(), TxtEmail.Text.Trim());

                    if (Rpta.Equals("OK"))
                    {
                        this.MensajeOk("Se actualizó correctamente el registro");
                        this.Limpiar();
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

        private void BtnCancelar_Click(object sender, EventArgs e)
        {
            this.Limpiar();
            TabGeneral.SelectedIndex = 0;
        }

        private void ChkSeleccionar_CheckedChanged(object sender, EventArgs e)
        {
            if (ChkSeleccionar.Checked)
            {
                DgvListado.Columns[0].Visible = true;
                BtnEliminar.Visible = true;
            }
            else
            {
                DgvListado.Columns[0].Visible = false;
                BtnEliminar.Visible = false;
            }
        }

        private void DgvListado_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == DgvListado.Columns["Seleccionar"].Index)
            {
                DataGridViewCheckBoxCell ChkEliminar = (DataGridViewCheckBoxCell)DgvListado.Rows[e.RowIndex].Cells["Seleccionar"];
                ChkEliminar.Value = !Convert.ToBoolean(ChkEliminar.Value);
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
                    foreach (DataGridViewRow row in DgvListado.Rows)
                    {
                        if (Convert.ToBoolean(row.Cells[0].Value))
                        {
                            Codigo = Convert.ToInt32(row.Cells[1].Value);
                            ServicePersona.WebServicePersonaSoapClient persona = new ServicePersona.WebServicePersonaSoapClient();
                            Rpta = persona.WebEliminar(Codigo);

                            if (Rpta.Equals("OK"))
                            {
                                this.MensajeOk("Se eliminó el registro: " + Convert.ToString(row.Cells[3].Value));
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

        private void FrmCliente_Load(object sender, EventArgs e)
        {
            this.Listar();
        }
    }
}
