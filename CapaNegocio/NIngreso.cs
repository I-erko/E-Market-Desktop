using CapaConexion;
using CapaDTO;
using System;
using System.Data;

namespace CapaNegocio
{
    public class NIngreso
    {
        public DataSet Listar()
        {
            CIngreso Datos = new CIngreso();
            return Datos.Listar();
        }

        public DataSet Buscar(string Valor)
        {
            CIngreso Datos = new CIngreso();
            return Datos.Buscar(Valor);
        }

        public DataSet ConsultaFechas(DateTime FechaInicio, DateTime FechaFin)
        {
            CIngreso Datos = new CIngreso();
            return Datos.ConsultaFechas(FechaInicio, FechaFin);
        }

        public DataSet ListarDetalle(int Id)
        {
            CIngreso Datos = new CIngreso();
            return Datos.ListarDetalle(Id);
        }

        public string Insertar(int IdProveedor, int IdUsuario, string TipoComprobante, string SerieComprobante,
                                      string NumComprobante, decimal Impuesto, decimal Total, DataTable Detalles)
        {
            CIngreso Datos = new CIngreso();
            Ingreso Obj = new Ingreso();

            Obj.IdProveedor = IdProveedor;
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
            CIngreso Datos = new CIngreso();
            return Datos.Anular(Id);
        }
    }
}
