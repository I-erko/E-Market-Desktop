using System;
using System.Data;
using System.Windows.Forms;

namespace CapaGUI
{
    public partial class FrmRol : Form
    {
        public FrmRol()
        {
            InitializeComponent();
        }

        private void Listar()
        {
            try
            {
                ServiceRol.WebServiceRolSoapClient rol = new ServiceRol.WebServiceRolSoapClient();
                DataTable dt = rol.WebListar().Tables[0];
                DgvListado.DataSource = dt;
                //NRol rol = new NRol();
                //DgvListado.DataSource = rol.Listar();
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
            DgvListado.Columns[0].Width = 100;
            DgvListado.Columns[0].HeaderText = "ID";
            DgvListado.Columns[1].Width = 200;
            DgvListado.Columns[1].HeaderText = "Nombre";
        }

        private void FrmRol_Load(object sender, EventArgs e)
        {
            this.Listar();
        }
    }
}
