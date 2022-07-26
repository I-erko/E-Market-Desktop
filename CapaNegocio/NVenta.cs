using CapaConexion;
using CapaDTO;
using System;
using System.Data;

namespace CapaNegocio
{
    public class NVenta
    {
        public DataSet Listar()
        {
            CVenta Datos = new CVenta();
            return Datos.Listar();
        }

        public DataSet Buscar(string Valor)
        {
            CVenta Datos = new CVenta();
            return Datos.Buscar(Valor);
        }

        public DataSet ConsultaFechas(DateTime FechaInicio, DateTime FechaFin)
        {
            CVenta Datos = new CVenta();
            return Datos.ConsultaFechas(FechaInicio, FechaFin);
        }

        public DataSet ListarDetalle(int Id)
        {
            CVenta Datos = new CVenta();
            return Datos.ListarDetalle(Id);
        }

        public static string Insertar(int IdCliente, int IdUsuario, string TipoComprobante, string SerieComprobante,
                                      string NumComprobante, decimal Impuesto, decimal Total, DataTable Detalles)
        {
            CVenta Datos = new CVenta();
            Venta Obj = new Venta();

            Obj.IdCliente = IdCliente;
            Obj.IdUsuario = IdUsuario;
            Obj.TipoComprobante = TipoComprobante;
            Obj.SerieComprobante = SerieComprobante;
            Obj.NumComprobante = NumComprobante;
            Obj.Impuesto = Impuesto;
            Obj.Total = Total;
            Obj.Detalles = Detalles;
            return Datos.Insertar(Obj);
        }

        public string Anular(int Id)
        {
            CVenta Datos = new CVenta();
            return Datos.Anular(Id);
        }
    }
}
