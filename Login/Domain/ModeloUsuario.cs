using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DatosAcceso;
using CapaTranversal.Cache;
namespace Domain
{
    public class ModeloUsuario
    {
        UsuarioDato UsuarioDato = new UsuarioDato();
        public bool LoginUser(string user, string pass)
        {
            return UsuarioDato.Login(user, pass);
        }

        //Seguridad y permisos
        public void AnyMethod()
        {
            if (UsuarioCacheLogin.Position == Positions.Administrador)
            {

            }
            if (UsuarioCacheLogin.Position == Positions.Gerente || UsuarioCacheLogin.Position == Positions.Gerente)
            {
            }
        }
    }
}
