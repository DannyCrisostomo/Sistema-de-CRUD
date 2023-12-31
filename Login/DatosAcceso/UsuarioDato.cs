using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using CapaTranversal.Cache;


namespace DatosAcceso
{
    public class UsuarioDato:ConexionSQL
    {
        public bool Login(string user,string pass)
        {
            
            using (var connection = GetConnection())
            {
                connection.Open();
                using (var command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = "select * from usuarios where LoginName=@usuario and Password=@Contraseña";
                    command.Parameters.AddWithValue("@Usuario", user);
                    command.Parameters.AddWithValue("@Contraseña", pass);
                    command.CommandType = CommandType.Text;
                    SqlDataReader reader = command.ExecuteReader();
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            UsuarioCacheLogin.UsuarioID = reader.GetInt32(0);
                            UsuarioCacheLogin.FirsName = reader.GetString(3);
                            UsuarioCacheLogin.LastName = reader.GetString(4);
                            UsuarioCacheLogin.Position = reader.GetString(5);
                            UsuarioCacheLogin.Email = reader.GetString(6);
                        }
                        return true;
                    }
                    else
                        return false;          
                }
            }
        }
    }
}
