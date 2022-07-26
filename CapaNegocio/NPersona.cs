using CapaConexion;
using CapaDTO;
using System.Data;

namespace CapaNegocio
{
    public class NPersona
    {
        public DataSet Listar()
        {
            CPersona Datos = new CPersona();
            return Datos.Listar();
        }

        public DataSet ListarProveedores()
        {
            CPersona Datos = new CPersona();
            return Datos.ListarProveedores();
        }

        public DataSet ListarClientes()
        {
            CPersona Datos = new CPersona();
            return Datos.ListarClientes();
        }

        public DataSet Buscar(string Valor)
        {
            CPersona Datos = new CPersona();
            return Datos.Buscar(Valor);
        }

        public DataSet BuscarProveedores(string Valor)
        {
            CPersona Datos = new CPersona();
            return Datos.BuscarProveedores(Valor);
        }

        public DataSet BuscarClientes(string Valor)
        {
            CPersona Datos = new CPersona();
            return Datos.BuscarClientes(Valor);
        }

        public string Insertar(string TipoPersona, string Nombre, string TipoDocumento,
                                      string NumDocumento, string Direccion, string Telefono, string Email)
        {
            CPersona Datos = new CPersona();

            string Existe = Datos.Existe(Nombre);

            if (Existe.Equals("1"))
            {
                return "La persona ya se encuentra registrada";
            }
            else
            {
                Persona Obj = new Persona();
                Obj.TipoPersona = TipoPersona;
                Obj.Nombre = Nombre;
                Obj.TipoDocumento = TipoDocumento;
                Obj.NumDocumento = NumDocumento;
                Obj.Direccion = Direccion;
                Obj.Telefono = Telefono;
                Obj.Email = Email;
                return Datos.Insertar(Obj);
            }


        }

        public string Actualizar(int Id, string TipoPersona, string NombreAnt, string Nombre, string TipoDocumento,
                                        string NumDocumento, string Direccion, string Telefono, string Email)
        {

            CPersona Datos = new CPersona();
            Persona Obj = new Persona();

            if (NombreAnt.Equals(Nombre))
            {
                Obj.IdPersona = Id;
                Obj.TipoPersona = TipoPersona;
                Obj.Nombre = Nombre;
                Obj.TipoDocumento = TipoDocumento;
                Obj.NumDocumento = NumDocumento;
                Obj.Direccion = Direccion;
                Obj.Telefono = Telefono;
                Obj.Email = Email;
                return Datos.Actualizar(Obj);
            }
            else
            {
                string Existe = Datos.Existe(Nombre);
                if (Existe.Equals("1"))
                {
                    return "Ya existe una persona con ese nombre";
                }
                else
                {
                    Obj.IdPersona = Id;
                    Obj.TipoPersona = TipoPersona;
                    Obj.Nombre = Nombre;
                    Obj.TipoDocumento = TipoDocumento;
                    Obj.NumDocumento = NumDocumento;
                    Obj.Direccion = Direccion;
                    Obj.Telefono = Telefono;
                    Obj.Email = Email;
                    return Datos.Actualizar(Obj);
                }
            }
        }

        public string Eliminar(int Id)
        {
            CPersona Datos = new CPersona();
            return Datos.Eliminar(Id);
        }
    }
}
