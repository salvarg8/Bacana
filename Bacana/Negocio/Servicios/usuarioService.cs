using Bacana.Datos.Dao.Implementación;
using Bacana.Negocio.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;


namespace Bacana.Negocio.Servicios
{
    public class UsuarioService
    {
        private UsuarioDao oUsuarioDao;
        public UsuarioService()
        {
            oUsuarioDao = new UsuarioDao();
        }

        public Usuario ValidarUsuario(string usuario, string password)
        {
            var usr = oUsuarioDao.GetUser(usuario);
            if (usr != null)
            {
                if (usr.Password != null && usr.Password.Equals(password))
                {

                    return usr;
                }
                return null;
            }
            else
                {
                    return null;
            }
        }
        public IList<Usuario> GetUsuarios()
        {
            return oUsuarioDao.GetAll();
        }

        internal IList<Usuario> ConsultarConFiltro(Dictionary<string, object> filtros)
        {
            return oUsuarioDao.GetByFilters(filtros);
        }

        internal void cargaUsuario(string nombre, string apellido, string contraseña, string usuario, string email)
        {
            oUsuarioDao.CargarUsuario(nombre, apellido, contraseña, usuario, email);
        }

        internal bool UsuarioExisteByUsuario(string usuario)
        {
            return oUsuarioDao.UsuarioExisteByUsuario(usuario);
        }

        internal bool actualizarUsuario(int idUsuario, string user, string email)
        {
           return oUsuarioDao.ActualizarUsuario(idUsuario, user, email);
        }

        internal bool UsuarioExisteByEmail(string email)
        {
            return oUsuarioDao.UsuarioExisteByEmail(email);
        }
    }
}
