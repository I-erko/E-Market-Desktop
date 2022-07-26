using CapaNegocio;
using System;
using System.Data;
using System.Web.Services;

namespace CapaServicios
{
    /// <summary>
    /// Descripción breve de WebServiceIngreso
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // Para permitir que se llame a este servicio web desde un script, usando ASP.NET AJAX, quite la marca de comentario de la línea siguiente. 
    // [System.Web.Script.Services.ScriptService]
    public class WebServiceIngreso : System.Web.Services.WebService
    {

        [WebMethod]
        public DataSet WebListar()
        {
            NIngreso Datos = new NIngreso();
            return Datos.Listar();
        }

        [WebMethod]
        public DataSet WebBuscar(string Valor)
        {
            NIngreso Datos = new NIngreso();
            return Datos.Buscar(Valor);
        }

        [WebMethod]
        public DataSet WebConsultaFechas(DateTime FechaInicio, DateTime FechaFin)
        {
            NIngreso Datos = new NIngreso();
            return Datos.ConsultaFechas(FechaInicio, FechaFin);
        }

        [WebMethod]
        public DataSet WebListarDetalle(int Id)
        {
            NIngreso Datos = new NIngreso();
            return Datos.ListarDetalle(Id);
        }

        [WebMethod]
        public string WebInsertar(int IdProveedor, int IdUsuario, string TipoComprobante, string SerieComprobante,
                               string NumComprobante, decimal Impuesto, decimal Total, DataTable Detalles)
        {
            NIngreso Datos = new NIngreso();
            return Datos.Insertar(IdProveedor, IdUsuario, TipoComprobante, SerieComprobante,
                                  NumComprobante, Impuesto, Total, Detalles);
        }

        [WebMethod]
        public string WebAnular(int Id)
        {
            NIngreso Datos = new NIngreso();
            return Datos.Anular(Id);
        }
    }
}
