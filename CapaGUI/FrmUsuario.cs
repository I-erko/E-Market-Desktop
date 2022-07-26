using System;
using System.Data;
using System.Windows.Forms;

namespace CapaGUI
{
    public partial class FrmUsuario : Form
    {
        private string EmailAnt;

        public FrmUsuario()
        {
            InitializeComponent();
        }

        private void Listar()
        {
            try
            {
                ServiceUsuario.WebServiceUsuarioSoapClient user = new ServiceUsuario.WebServiceUsuarioSoapClient();
                DataTable dt = user.WebListar().Tables[0];
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
                ServiceUsuario.WebServiceUsuarioSoapClient user = new ServiceUsuario.WebServiceUsuarioSoapClient();
                DataTable dt = user.WebBuscar(TxtBuscar.Text).Tables[0];
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
            DgvListado.Columns[1].Width = 50;
            DgvListado.Columns[3].Width = 100;
            DgvListado.Columns[4].Width = 170;
            DgvListado.Columns[5].Width = 100;
            DgvListado.Columns[5].HeaderText = "Documento";
            DgvListado.Columns[6].Width = 100;
            DgvListado.Columns[6].HeaderText = "Número Doc.";
            DgvListado.Columns[7].Width = 120;
            DgvListado.Columns[7].HeaderText = "Dirección";
            DgvListado.Columns[8].Width = 100;
            DgvListado.Columns[8].HeaderText = "Teléfono";
            DgvListado.Columns[9].Width = 120;

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
            TxtClave.Clear();
            BtnInsertar.Visible = true;
            BtnActualizar.Visible = false;
            ErrorIcono.Clear();

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

        private void CargarRol()
        {
            try
            {
                //NRol rol = new NRol();
                ServiceRol.WebServiceRolSoapClient rol = new ServiceRol.WebServiceRolSoapClient();
                DataTable dt = rol.WebListar().Tables[0];
                CboRol.DataSource = dt;
                CboRol.ValueMember = "idrol";
                CboRol.DisplayMember = "nombre";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ex.StackTrace);
            }
        }

        private void FrmUsuario_Load(object sender, EventArgs e)
        {
            this.Listar();
            this.CargarRol();
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
                if (CboRol.Text == string.Empty || TxtNombre.Text == string.Empty || TxtEmail.Text == string.Empty ||
                    TxtClave.Text == string.Empty)
                {
                    this.MensajeError("Falta ingresar algunos datos, serán remarcados");
                    ErrorIcono.SetError(CboRol, "Seleccione un rol.");
                    ErrorIcono.SetError(TxtNombre, "Ingrese un nombre.");
                    ErrorIcono.SetError(TxtEmail, "Ingrese un email.");
                    ErrorIcono.SetError(TxtClave, "Ingrese una clave.");

                }
                else
                {
                    ServiceUsuario.WebServiceUsuarioSoapClient user = new ServiceUsuario.WebServiceUsuarioSoapClient();
                    Rpta = user.WebInsertar(Convert.ToInt32(CboRol.SelectedValue), TxtNombre.Text.Trim(), CboTipoDoc.Text,
                        TxtNumDoc.Text.Trim(), TxtDireccion.Text.Trim(), TxtTelefono.Text.Trim(), TxtEmail.Text.Trim(), TxtClave.Text.Trim());

                    if (Rpta.Equals("OK"))
                    {
                        this.MensajeOk("Se insertó correctamente el registro");
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
                CboRol.SelectedValue = Convert.ToString(DgvListado.CurrentRow.Cells["idrol"].Value);
                TxtNombre.Text = Convert.ToString(DgvListado.CurrentRow.Cells["Nombre"].Value);
                CboTipoDoc.Text = Convert.ToString(DgvListado.CurrentRow.Cells["Tipo_Documento"].Value);
                TxtNumDoc.Text = Convert.ToString(DgvListado.CurrentRow.Cells["Num_Documento"].Value);
                TxtDireccion.Text = Convert.ToString(DgvListado.CurrentRow.Cells["Direccion"].Value);
                TxtTelefono.Text = Convert.ToString(DgvListado.CurrentRow.Cells["Telefono"].Value);
                this.EmailAnt = Convert.ToString(DgvListado.CurrentRow.Cells["Email"].Value);
                TxtEmail.Text = Convert.ToString(DgvListado.CurrentRow.Cells["Email"].Value);

                TabGeneral.SelectedIndex = 1;

            }
            catch (Exception ex)
            {

                MessageBox.Show("Seleccione desde la celda nombre | Error: " + ex.Message);
            }
        }

        private void BtnActualizar_Click(object sender, EventArgs e)
        {
            try
            {
                string Rpta = "";
                if (TxtId.Text == string.Empty || CboRol.Text == string.Empty ||
                    TxtNombre.Text == string.Empty || TxtEmail.Text == string.Empty)
                {
                    this.MensajeError("Falta ingresar algunos datos, serán remarcados");
                    ErrorIcono.SetError(CboRol, "Seleccione un rol.");
                    ErrorIcono.SetError(TxtNombre, "Ingrese un nombre.");
                    ErrorIcono.SetError(TxtEmail, "Ingrese un email.");
                }
                else
                {
                    ServiceUsuario.WebServiceUsuarioSoapClient user = new ServiceUsuario.WebServiceUsuarioSoapClient();
                    Rpta = user.WebActualizar(Convert.ToInt32(TxtId.Text), Convert.ToInt32(CboRol.SelectedValue), TxtNombre.Text.Trim(), CboTipoDoc.Text,
                        TxtNumDoc.Text.Trim(), TxtDireccion.Text.Trim(), TxtTelefono.Text.Trim(), this.EmailAnt, TxtEmail.Text.Trim(), TxtClave.Text.Trim());

                    if (Rpta.Equals("OK"))
                    {
                        this.MensajeOk("Se actualizó correctamente el registro");
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
                    foreach (DataGridViewRow row in DgvListado.Rows)
                    {
                        if (Convert.ToBoolean(row.Cells[0].Value))
                        {
                            Codigo = Convert.ToInt32(row.Cells[1].Value);
                            ServiceUsuario.WebServiceUsuarioSoapClient user = new ServiceUsuario.WebServiceUsuarioSoapClient();
                            Rpta = user.WebEliminar(Codigo);

                            if (Rpta.Equals("OK"))
                            {
                                this.MensajeOk("Se eliminó el registro: " + Convert.ToString(row.Cells[4].Value));
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
                            ServiceUsuario.WebServiceUsuarioSoapClient user = new ServiceUsuario.WebServiceUsuarioSoapClient();
                            Rpta = user.WebDesactivar(Codigo);

                            if (Rpta.Equals("OK"))
                            {
                                this.MensajeOk("Se desactivó el registro: " + Convert.ToString(row.Cells[4].Value));
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
            try
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
                            ServiceUsuario.WebServiceUsuarioSoapClient user = new ServiceUsuario.WebServiceUsuarioSoapClient();
                            Rpta = user.WebActivar(Codigo);

                            if (Rpta.Equals("OK"))
                            {
                                this.MensajeOk("Se activó el registro: " + Convert.ToString(row.Cells[4].Value));
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
    }
}
