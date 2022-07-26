using CapaNegocio;
using System.Data;
using System.Web.Services;

namespace CapaServicios
{
    /// <summary>
    /// Descripción breve de WebServicePersona
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // Para permitir que se llame a este servicio web desde un script, usando ASP.NET AJAX, quite la marca de comentario de la línea siguiente. 
    // [System.Web.Script.Services.ScriptService]
    public class WebServicePersona : System.Web.Services.WebService
    {

        [WebMethod]
        public DataSet WebListar()
        {
            NPersona Datos = new NPersona();
            return Datos.Listar();
        }

        [WebMethod]
        public DataSet WebListarProveedores()
        {
            NPersona Datos = new NPersona();
            return Datos.ListarProveedores();
        }

        [WebMethod]
        public DataSet WebListarClientes()
        {
            NPersona Datos = new NPersona();
            return Datos.ListarClientes();
        }

        [WebMethod]
        public DataSet WebBuscar(string Valor)
        {
            NPersona Datos = new NPersona();
            return Datos.Buscar(Valor);
        }

        [WebMethod]
        public DataSet WebBuscarProveedores(string Valor)
        {
            NPersona Datos = new NPersona();
            return Datos.BuscarProveedores(Valor);
        }

        [WebMethod]
        public DataSet WebBuscarClientes(string Valor)
        {
            NPersona Datos = new NPersona();
            return Datos.BuscarClientes(Valor);
        }

        [WebMethod]
        public string WebInsertar(string TipoPersona, string Nombre, string TipoDocumento,
                               string NumDocumento, string Direccion, string Telefono, string Email)
        {
            NPersona Datos = new NPersona();
            return Datos.Insertar(TipoPersona, Nombre, TipoDocumento, NumDocumento, Direccion, Telefono, Email);
        }

        [WebMethod]
        public string WebActualizar(int Id, string TipoPersona, string NombreAnt, string Nombre, string TipoDocumento,
                                        string NumDocumento, string Direccion, string Telefono, string Email)
        {
            NPersona Datos = new NPersona();
            return Datos.Actualizar(Id, TipoPersona, NombreAnt, Nombre, TipoDocumento, NumDocumento, Direccion, Telefono, Email);
        }

        [WebMethod]
        public string WebEliminar(int Id)
        {
            NPersona Datos = new NPersona();
            return Datos.Eliminar(Id);
        }
    }
}
