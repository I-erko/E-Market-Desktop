using CapaNegocio;
using System;
using System.Data;
using System.Web.Services;

namespace CapaServicios
{
    /// <summary>
    /// Descripción breve de WebServiceVenta
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // Para permitir que se llame a este servicio web desde un script, usando ASP.NET AJAX, quite la marca de comentario de la línea siguiente. 
    // [System.Web.Script.Services.ScriptService]
    public class WebServiceVenta : System.Web.Services.WebService
    {

        [WebMethod]
        public DataSet WebListar()
        {
            NVenta Datos = new NVenta();
            return Datos.Listar();
        }

        [WebMethod]
        public DataSet WebBuscar(string Valor)
        {
            NVenta Datos = new NVenta();
            return Datos.Buscar(Valor);
        }

        [WebMethod]
        public DataSet WebConsultaFechas(DateTime FechaInicio, DateTime FechaFin)
        {
            NVenta Datos = new NVenta();
            return Datos.ConsultaFechas(FechaInicio, FechaFin);
        }

        [WebMethod]
        public DataSet WebListarDetalle(int Id)
        {
            NVenta Datos = new NVenta();
            return Datos.ListarDetalle(Id);
        }

        [WebMethod]
        public string WebAnular(int Id)
        {
            NVenta Datos = new NVenta();
            return Datos.Anular(Id);
        }
    }
}
