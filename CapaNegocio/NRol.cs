using CapaConexion;
using System.Data;

namespace CapaNegocio
{
    public class NRol
    {
        public DataSet Listar()
        {
            CRol Datos = new CRol();
            return Datos.Listar();
        }
    }
}
