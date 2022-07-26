using CapaConexion;
using CapaDTO;
using System.Data;

namespace CapaNegocio
{
    public class NCategoria
    {
        public DataSet Listar()
        {
            CCategoria Datos = new CCategoria();
            return Datos.Listar();
        }

        public DataSet Buscar(string Valor)
        {
            CCategoria Datos = new CCategoria();
            return Datos.Buscar(Valor);
        }

        public DataSet Seleccionar()
        {
            CCategoria Datos = new CCategoria();
            return Datos.Seleccionar();
        }

        public string Insertar(string Nombre, string Descripcion)
        {
            CCategoria Datos = new CCategoria();

            string Existe = Datos.Existe(Nombre);

            if (Existe.Equals("1"))
            {
                return "La categoría ya existe";
            }
            else
            {
                Categoria Obj = new Categoria();
                Obj.Nombre = Nombre;
                Obj.Descripcion = Descripcion;
                return Datos.Insertar(Obj);
            }


        }

        public string Actualizar(int Id, string NombreAnt, string Nombre, string Descripcion)
        {

            CCategoria Datos = new CCategoria();
            Categoria Obj = new Categoria();

            if (NombreAnt.Equals(Nombre))
            {
                Obj.IdCategoria = Id;
                Obj.Nombre = Nombre;
                Obj.Descripcion = Descripcion;
                return Datos.Actualizar(Obj);
            }
            else
            {
                string Existe = Datos.Existe(Nombre);
                if (Existe.Equals("1"))
                {
                    return "La categoría ya existe";
                }
                else
                {
                    Obj.IdCategoria = Id;
                    Obj.Nombre = Nombre;
                    Obj.Descripcion = Descripcion;
                    return Datos.Actualizar(Obj);
                }
            }
        }

        public string Eliminar(int Id)
        {
            CCategoria Datos = new CCategoria();
            return Datos.Eliminar(Id);
        }

        public string Activar(int Id)
        {
            CCategoria Datos = new CCategoria();
            return Datos.Activar(Id);
        }

        public string Desactivar(int Id)
        {
            CCategoria Datos = new CCategoria();
            return Datos.Desactivar(Id);
        }
    }
}
