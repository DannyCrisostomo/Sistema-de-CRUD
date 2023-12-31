using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
namespace DatosAcceso
{
    public abstract class Conexion
    {
        public static SqlConnection Conectar()
        {
            SqlConnection conexionBD = new SqlConnection("Server=DESKTOP-6235S17\\SQLEXPRESS;Database= Estudiante; integrated security=true");
            conexionBD.Open();
            return conexionBD;
        }
    }
}
