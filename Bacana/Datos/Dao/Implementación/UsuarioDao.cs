using Bacana.Negocio.Entidades;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
//using Bacana.Datos.Helper;

namespace Bacana.Datos.Dao.Implementación
{
    public class UsuarioDao
    {
        public Usuario GetUser(string nombreUsuario)
        {
            string strSql = string.Concat("SELECT id_usuario, usuario, email, password FROM [DB_bacana].[dbo].[usuario] WHERE usuario = @usuario;");
            var parametros = new Dictionary<string, object>();
            parametros.Add("usuario", nombreUsuario);

            var resultado = DataManager.GetInstance().ConsultaSQL(strSql, parametros);

            if (resultado.Rows.Count >0)
            {
                return ObjectMapping(resultado.Rows[0]);
            }
            return null;



        }

        private Usuario ObjectMapping(DataRow row)
        {
            Usuario oUsuario = new Usuario
            {
                IdUsuario = Convert.ToInt32(row["id_usuario"].ToString()),
                User = row["usuario"].ToString(),
                Email = row["email"].ToString(),
                Password = row.Table.Columns.Contains("password") ? row["password"].ToString() : null,
                
            };
            return oUsuario;
        }

        internal void CargarUsuario(string nombre, string apellido, string contraseña, string usuario, string email)
        {
            String strSql = "INSERT into usuario(usuario,password,nombre,apellido,email) Values ('" + usuario + "','" + contraseña + "','" + nombre + "','" + apellido + "','" + email + "')";
            DataManager.GetInstance().EjecutarSQL(strSql);
        }

        internal bool ActualizarUsuario(int idUsuario, string user, string email)
        {
            String strSql = "UPDATE usuario set usuario = '"+user+ "', email ='" + email+"' WHERE id_usuario ="+idUsuario;
            DataManager.GetInstance().EjecutarSQL(strSql);

            return true;
        }

        internal bool UsuarioExisteByUsuario(string usr)
        {
            String strSql = "Select * from usuario where usuario = '" + usr+"'";
            List<Usuario> usuarios = new List<Usuario>();
            DataTable t = DataManager.GetInstance().ConsultaSQL(strSql);

            foreach (DataRow row in t.Rows)
            {
                int id = int.Parse(row["id_usuario"].ToString());
                string usuario = row["usuario"].ToString();
                string pass = row["password"].ToString();
                string nombre = row["nombre"].ToString();
                string apellido = row["apellido"].ToString();
                string email = row["email"].ToString();
                Usuario obj = new Usuario(id, usuario, pass, nombre, apellido, email);
                usuarios.Add(obj);
            }
            if (t.Rows.Count == 0)
            {
                return false;
            }
            return true;


        }

        internal bool UsuarioExisteByEmail(string eml)
        {
            String strSql = "Select * from usuario where email =" + eml;
            List<Usuario> usuarios = new List<Usuario>();
            DataTable t = DataManager.GetInstance().ConsultaSQL(strSql);

            foreach (DataRow row in t.Rows)
            {
                int id = int.Parse(row["id_usuario"].ToString());
                string usuario = row["usuario"].ToString();
                string pass = row["password"].ToString();
                string nombre = row["nombre"].ToString();
                string apellido = row["apellido"].ToString();
                string email = row["email"].ToString();
                Usuario obj = new Usuario(id, usuario, pass, nombre, apellido, email);
                usuarios.Add(obj);
            }
            if (t.Rows.Count == 0)
            {
                return false;
            }
            return true;
        }

        internal IList<Usuario> GetAll()
        {
            List<Usuario> usuarios = new List<Usuario>();

            String strSql = "SELECT * from dbo.usuario where estado <> 1;";
            DataTable t = DataManager.GetInstance().ConsultaSQL(strSql);

            foreach (DataRow row in t.Rows)
            {
                int id = int.Parse(row["id_usuario"].ToString());
                string usuario = row["usuario"].ToString();
                string pass = row["password"].ToString();
                string nombre = row["nombre"].ToString();
                string apellido = row["apellido"].ToString();
                string email = row["email"].ToString();
                Usuario obj = new Usuario(id,usuario,pass,nombre,apellido,email);
                usuarios.Add(obj);
            }
            return usuarios;
        }

        

        public IList<Usuario> GetByFilters(Dictionary<string, object> parametros)
        {
            List<Usuario> lst = new List<Usuario>();
            string strSql = string.Concat("SELECT id_usuario, usuario, email, password FROM [DB_bacana].[dbo].[usuario] WHERE usuario = @usuario;");
                      


            if (parametros.ContainsKey("usuario"))
                strSql += " AND (u.usuario LIKE '%' + @usuario + '%') ";

            var resultado = DataManager.GetInstance().ConsultaSQL(strSql, parametros);

            foreach (DataRow row in resultado.Rows)
                lst.Add(ObjectMapping(row));

            return lst;
        }
    }
}
