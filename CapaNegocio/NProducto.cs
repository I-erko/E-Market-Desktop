using CapaConexion;
using CapaDTO;
using System.Data;

namespace CapaNegocio
{
    public class NProducto
    {
        public DataSet Listar()
        {
            CProducto Datos = new CProducto();
            return Datos.Listar();
        }

        public DataSet Buscar(string Valor)
        {
            CProducto Datos = new CProducto();
            return Datos.Buscar(Valor);
        }

        public DataSet BuscarVenta(string Valor)
        {
            CProducto Datos = new CProducto();
            return Datos.BuscarVenta(Valor);
        }

        public DataSet BuscarCodigo(string Valor)
        {
            CProducto Datos = new CProducto();
            return Datos.BuscarCodigo(Valor);
        }

        public DataSet BuscarCodigoVenta(string Valor)
        {
            CProducto Datos = new CProducto();
            return Datos.BuscarCodigoVenta(Valor);
        }

        public string Insertar(int IdCategoria, string Codigo, string Nombre, decimal PrecioVenta, int Stock, string Descripcion, string Imagen)
        {
            CProducto Datos = new CProducto();

            string Existe = Datos.Existe(Nombre);

            if (Existe.Equals("1"))
            {
                return "El producto ya existe";
            }
            else
            {
                Producto Obj = new Producto();
                Obj.IdCategoria = IdCategoria;
                Obj.Codigo = Codigo;
                Obj.Nombre = Nombre;
                Obj.PrecioVenta = PrecioVenta;
                Obj.Stock = Stock;
                Obj.Descripcion = Descripcion;
                Obj.Imagen = Imagen;
                return Datos.Insertar(Obj);
            }
        }

        public string Actualizar(int Id, int IdCategoria, string Codigo, string NombreAnt, string Nombre, decimal PrecioVenta, int Stock, string Descripcion, string Imagen)
        {

            CProducto Datos = new CProducto();
            Producto Obj = new Producto();

            if (NombreAnt.Equals(Nombre))
            {
                Obj.IdProducto = Id;
                Obj.IdCategoria = IdCategoria;
                Obj.Codigo = Codigo;
                Obj.Nombre = Nombre;
                Obj.PrecioVenta = PrecioVenta;
                Obj.Stock = Stock;
                Obj.Descripcion = Descripcion;
                Obj.Imagen = Imagen;
                return Datos.Actualizar(Obj);
            }
            else
            {
                string Existe = Datos.Existe(Nombre);
                if (Existe.Equals("1"))
                {
                    return "El producto ya existe";
                }
                else
                {
                    Obj.IdProducto = Id;
                    Obj.IdCategoria = IdCategoria;
                    Obj.Codigo = Codigo;
                    Obj.Nombre = Nombre;
                    Obj.PrecioVenta = PrecioVenta;
                    Obj.Stock = Stock;
                    Obj.Descripcion = Descripcion;
                    Obj.Imagen = Imagen;
                    return Datos.Actualizar(Obj);
                }
            }
        }

        public string Eliminar(int Id)
        {
            CProducto Datos = new CProducto();
            return Datos.Eliminar(Id);
        }

        public string Activar(int Id)
        {
            CProducto Datos = new CProducto();
            return Datos.Activar(Id);
        }

        public string Desactivar(int Id)
        {
            CProducto Datos = new CProducto();

            return Datos.Desactivar(Id);
        }
    }
}
