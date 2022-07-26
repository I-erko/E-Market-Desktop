using CapaConexion;
using CapaDTO;
using System.Data;

namespace CapaNegocio
{
    public class NUsuario
    {
        public DataSet Listar()
        {
            CUsuario Datos = new CUsuario();
            return Datos.Listar();
        }

        public DataSet Buscar(string Valor)
        {
            CUsuario Datos = new CUsuario();
            return Datos.Buscar(Valor);
        }

        public string Insertar(int IdRol, string Nombre, string TipoDocumento, string NumDocumento,
                                        string Direccion, string Telefono, string Email, string Clave)
        {
            CUsuario Datos = new CUsuario();

            string Existe = Datos.Existe(Email);

            if (Existe.Equals("1"))
            {
                return "El usuario con ese email ya existe";
            }
            else
            {
                Usuario Obj = new Usuario();
                Obj.IdRol = IdRol;
                Obj.Nombre = Nombre;
                Obj.TipoDocumento = TipoDocumento;
                Obj.NumDocumento = NumDocumento;
                Obj.Direccion = Direccion;
                Obj.Telefono = Telefono;
                Obj.Email = Email;
                Obj.Clave = Clave;
                return Datos.Insertar(Obj);
            }
        }

        public string Actualizar(int Id, int IdRol, string Nombre, string TipoDocumento, string NumDocumento,
                                        string Direccion, string Telefono, string EmailAnt, string Email, string Clave)
        {

            CUsuario Datos = new CUsuario();
            Usuario Obj = new Usuario();

            if (EmailAnt.Equals(Email))
            {
                Obj.IdUsuario = Id;
                Obj.IdRol = IdRol;
                Obj.Nombre = Nombre;
                Obj.TipoDocumento = TipoDocumento;
                Obj.NumDocumento = NumDocumento;
                Obj.Direccion = Direccion;
                Obj.Telefono = Telefono;
                Obj.Email = Email;
                Obj.Clave = Clave;
                return Datos.Actualizar(Obj);
            }
            else
            {
                string Existe = Datos.Existe(Email);
                if (Existe.Equals("1"))
                {
                    return "El usuario con ese email ya existe";
                }
                else
                {
                    Obj.IdUsuario = Id;
                    Obj.IdRol = IdRol;
                    Obj.Nombre = Nombre;
                    Obj.TipoDocumento = TipoDocumento;
                    Obj.NumDocumento = NumDocumento;
                    Obj.Direccion = Direccion;
                    Obj.Telefono = Telefono;
                    Obj.Email = Email;
                    Obj.Clave = Clave;
                    return Datos.Actualizar(Obj);
                }
            }
        }

        public string Eliminar(int Id)
        {
            CUsuario Datos = new CUsuario();
            return Datos.Eliminar(Id);
        }

        public string Activar(int Id)
        {
            CUsuario Datos = new CUsuario();
            return Datos.Activar(Id);
        }

        public string Desactivar(int Id)
        {
            CUsuario Datos = new CUsuario();
            return Datos.Desactivar(Id);
        }

        public DataSet Login(string Email, string Clave)
        {
            CUsuario Datos = new CUsuario();
            return Datos.Login(Email, Clave);
        }
    }
}
