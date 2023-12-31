using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
namespace DatosAcceso
{
    public abstract class ConexionSQL
    {
        private readonly string connectionstring;
        public ConexionSQL()
        {
            connectionstring = "Server=DESKTOP-6235S17\\SQLEXPRESS;Database= Colegio; integrated security=true";
        }
        protected SqlConnection GetConnection()
        {
            return new SqlConnection(connectionstring);
        }
    }
}
