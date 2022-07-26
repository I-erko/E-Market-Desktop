using CapaNegocio;
using System.Data;
using System.Web.Services;

namespace CapaServicios
{
    /// <summary>
    /// Descripción breve de WebServiceCategoria
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // Para permitir que se llame a este servicio web desde un script, usando ASP.NET AJAX, quite la marca de comentario de la línea siguiente. 
    // [System.Web.Script.Services.ScriptService]
    public class WebServiceCategoria : System.Web.Services.WebService
    {

        [WebMethod]
        public DataSet WebListar()
        {
            NCategoria Datos = new NCategoria();
            return Datos.Listar();
        }

        [WebMethod]
        public DataSet WebBuscar(string Valor)
        {
            NCategoria Datos = new NCategoria();
            return Datos.Buscar(Valor);
        }

        [WebMethod]
        public DataSet WebSeleccionar()
        {
            NCategoria Datos = new NCategoria();
            return Datos.Seleccionar();
        }

        [WebMethod]
        public string WebInsertar(string Nombre, string Descripcion)
        {
            NCategoria Datos = new NCategoria();
            return Datos.Insertar(Nombre, Descripcion);
        }

        [WebMethod]
        public string WebActualizar(int Id, string NombreAnt, string Nombre, string Descripcion)
        {
            NCategoria cat = new NCategoria();
            return cat.Actualizar(Id, NombreAnt, Nombre, Descripcion);
        }

        [WebMethod]
        public string WebEliminar(int Id)
        {
            NCategoria Datos = new NCategoria();
            return Datos.Eliminar(Id);
        }

        [WebMethod]
        public string WebActivar(int Id)
        {
            NCategoria Datos = new NCategoria();
            return Datos.Activar(Id);
        }

        [WebMethod]
        public string WebDesactivar(int Id)
        {
            NCategoria Datos = new NCategoria();
            return Datos.Desactivar(Id);
        }
    }
}
