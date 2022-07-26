using System;
using System.Data;
using System.Data.SqlClient;

namespace CapaConexion
{
    public class CRol
    {
        public DataSet Listar()
        {
            //SqlDataReader Resultado;
            DataSet Tabla = new DataSet();
            SqlConnection SqlCon = new SqlConnection();
            try
            {
                SqlCon = Conexion.getInstancia().CrearConexion();
                SqlCommand Comando = new SqlCommand("rol_listar", SqlCon);
                SqlDataAdapter adap = new SqlDataAdapter();
                Comando.CommandType = CommandType.StoredProcedure;
                SqlCon.Open();
                adap.SelectCommand = Comando;
                adap.Fill(Tabla);
                //Resultado = Comando.ExecuteReader();
                //Tabla.Load(Resultado);
                return Tabla;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (SqlCon.State == ConnectionState.Open) SqlCon.Close();
            }
        }
    }
}
