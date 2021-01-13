using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bacana.Negocio.Entidades
{
    public class Usuario
    {
        public int IdUsuario { get; set; }
        public string User { get; set; }
        public string Password { get; set; }
        public string nombre { get; set; }
        public string apellido { get; set; }
        public string Email { get; set; }

        public Usuario(int idUsuario, string user, string password, string nombre, string apellido, string email)
        {
            IdUsuario = idUsuario;
            User = user;
            Password = password;
            this.nombre = nombre;
            this.apellido = apellido;
            Email = email;
        }
        public Usuario() { }

        public override string ToString()
        {
            return User;
        }

    }

}
