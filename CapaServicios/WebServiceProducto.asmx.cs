using CapaNegocio;
using System.Data;
using System.Web.Services;

namespace CapaServicios
{
    /// <summary>
    /// Descripción breve de WebServiceProducto
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // Para permitir que se llame a este servicio web desde un script, usando ASP.NET AJAX, quite la marca de comentario de la línea siguiente. 
    // [System.Web.Script.Services.ScriptService]
    public class WebServiceProducto : System.Web.Services.WebService
    {

        [WebMethod]
        public DataSet WebListar()
        {
            NProducto Datos = new NProducto();
            return Datos.Listar();
        }

        [WebMethod]
        public DataSet WebBuscar(string Valor)
        {
            NProducto Datos = new NProducto();
            return Datos.Buscar(Valor);
        }

        [WebMethod]
        public DataSet WebBuscarVenta(string Valor)
        {
            NProducto Datos = new NProducto();
            return Datos.BuscarVenta(Valor);
        }

        [WebMethod]
        public DataSet WebBuscarCodigo(string Valor)
        {
            NProducto Datos = new NProducto();
            return Datos.BuscarCodigo(Valor);
        }

        [WebMethod]
        public DataSet WebBuscarCodigoVenta(string Valor)
        {
            NProducto Datos = new NProducto();
            return Datos.BuscarCodigoVenta(Valor);
        }

        [WebMethod]
        public string WebInsertar(int IdCategoria, string Codigo, string Nombre, decimal PrecioVenta, int Stock, string Descripcion, string Imagen)
        {
            NProducto datos = new NProducto();
            return datos.Insertar(IdCategoria, Codigo, Nombre, PrecioVenta, Stock, Descripcion, Imagen);
        }

        [WebMethod]
        public string WebActualizar(int Id, int IdCategoria, string Codigo, string NombreAnt, string Nombre, decimal PrecioVenta, int Stock, string Descripcion, string Imagen)
        {
            NProducto Datos = new NProducto();
            return Datos.Actualizar(Id, IdCategoria, Codigo, NombreAnt, Nombre, PrecioVenta, Stock, Descripcion, Imagen);
        }

        [WebMethod]
        public string WebEliminar(int Id)
        {
            NProducto Datos = new NProducto();
            return Datos.Eliminar(Id);
        }

        [WebMethod]
        public string WebActivar(int Id)
        {
            NProducto Datos = new NProducto();
            return Datos.Activar(Id);
        }

        [WebMethod]
        public string WebDesactivar(int Id)
        {
            NProducto Datos = new NProducto();
            return Datos.Desactivar(Id);
        }
    }
}
