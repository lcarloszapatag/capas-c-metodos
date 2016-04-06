
using System.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;




namespace Conexion
{
   public class ConexionBD
    {

        static string cn = "Data Source=localhost;Initial Catalog=_siscomercial;User Id=sa Integrated Security=True";

        public static string getConexion
    {
       
        
            //cn.Open();
              get { return cn; }
        

        
        
    }
}


}






