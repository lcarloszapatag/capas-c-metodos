using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using Conexion;





namespace Negocio
{
    public class MetodoDatos
    {

        //Este método nos servirá para crear un comando sql standard
        //como un select el cual será regresado por su método return

        public static SqlCommand crear_comando()
        {
    
            string _cadenaConexion = ConexionBD.getConexion;

            SqlConnection _conexion = new SqlConnection();
            _conexion.ConnectionString = _cadenaConexion;
            SqlCommand _comando = new SqlCommand();
            _comando = _conexion.CreateCommand();
            _comando.CommandType = CommandType.Text;

                return _comando;

        }

//Este método al igual que el anterior nos crea un comando SQL, pero con la diferencia que este método nos creara nuestro comando, de manera que pueda ejecutar nuestro procedimiento 
  //          almacenado que establecimos anteriormente llamado InsDatos.

        public static SqlCommand CrearComandoProc()
        {
            string _cadenaConexion = ConexionBD.getConexion;
            SqlConnection _conexion = new SqlConnection(_cadenaConexion);
            SqlCommand _comando = new SqlCommand("InsDatos", _conexion);
            _comando.CommandType = CommandType.StoredProcedure;
            return _comando;
        }


        //Este metodo obtiene como parametro un comando SQL que proviene del método anterior CrearComandoProc, este método ejecuta el procedimiento almacenado que se le ha asignado al comando. En la siguiente clase que agregaremos
        //veremos como se le asigna el procedimiento almacenado a este comando.

        public static int EjecutarComandoInsert(SqlCommand comando)
        {
            try
            {
                comando.Connection.Open();
                return comando.ExecuteNonQuery();
            }
            catch { throw; }
            finally
            {
                comando.Connection.Dispose();
                comando.Connection.Close();
            }
        }
        //Este método ejecutara un comando select el cual nos regresara un datatable con todos los registros que se encuentren en alguna tabla dada, 
        //  toma como párametro el comando que contiene la sentencia SQL select.

        public static DataTable EjecutarComandoSelect(SqlCommand comando)
        {
            DataTable _tabla = new DataTable();
            try
            {
                comando.Connection.Open();
                SqlDataAdapter adaptador = new SqlDataAdapter();
                adaptador.SelectCommand = comando;
                adaptador.Fill(_tabla);
            }
            catch (Exception ex)
            { throw ex; }
            finally
            { comando.Connection.Close(); }
            return _tabla;


        }



        }
}
