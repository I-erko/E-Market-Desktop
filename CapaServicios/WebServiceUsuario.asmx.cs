using CapaNegocio;
using System.Data;
using System.Web.Services;

namespace CapaServicios
{
    /// <summary>
    /// Descripción breve de WebServiceUsuario
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // Para permitir que se llame a este servicio web desde un script, usando ASP.NET AJAX, quite la marca de comentario de la línea siguiente. 
    // [System.Web.Script.Services.ScriptService]
    public class WebServiceUsuario : System.Web.Services.WebService
    {
        [WebMethod]
        public DataSet WebLogin(string Email, string Clave)
        {
            NUsuario Datos = new NUsuario();
            return Datos.Login(Email, Clave);
        }

        [WebMethod]
        public DataSet WebListar()
        {
            NUsuario Datos = new NUsuario();
            return Datos.Listar();
        }

        [WebMethod]
        public DataSet WebBuscar(string Valor)
        {
            NUsuario Datos = new NUsuario();
            return Datos.Buscar(Valor);
        }

        [WebMethod]
        public string WebInsertar(int IdRol, string Nombre, string TipoDocumento, string NumDocumento,
                               string Direccion, string Telefono, string Email, string Clave)
        {
            NUsuario Datos = new NUsuario();
            return Datos.Insertar(IdRol, Nombre, TipoDocumento, NumDocumento, Direccion, Telefono, Email, Clave);
        }

        [WebMethod]
        public string WebActualizar(int Id, int IdRol, string Nombre, string TipoDocumento, string NumDocumento,
                                 string Direccion, string Telefono, string EmailAnt, string Email, string Clave)
        {
            NUsuario Datos = new NUsuario();
            return Datos.Actualizar(Id, IdRol, Nombre, TipoDocumento, NumDocumento, Direccion, Telefono, EmailAnt, Email, Clave);
        }

        [WebMethod]
        public string WebEliminar(int Id)
        {
            NUsuario Datos = new NUsuario();
            return Datos.Eliminar(Id);
        }

        [WebMethod]
        public string WebActivar(int Id)
        {
            NUsuario Datos = new NUsuario();
            return Datos.Activar(Id);
        }

        [WebMethod]
        public string WebDesactivar(int Id)
        {
            NUsuario Datos = new NUsuario();
            return Datos.Desactivar(Id);
        }        
    }
}
