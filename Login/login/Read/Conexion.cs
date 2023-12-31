using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;


namespace Read
{
    class Conexion
    {
        public static SqlConnection Conectar()
        {
            SqlConnection cn = new SqlConnection("Server=DESKTOP-3RH2L63\\SQLEXPRESS;Database= Registro; integrated security=true");
            cn.Open();
            return cn;
        }
    }
}
