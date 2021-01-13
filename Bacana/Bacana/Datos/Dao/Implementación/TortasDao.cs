//using Bacana.Datos.Helper;
using Bacana.Negocio.Entidades;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bacana.Datos.Dao.Implementación
{
    class TortasDao
    {
        internal bool cargaTorta(Torta oTorta)
        {
            String strSql = "insert into tortas(nombre,porcentaje,borrado,estado)" +
                " VALUES('" + oTorta.nombre + "',"+oTorta.porcentaje+",0,'N')";
            return DataManager.GetInstance().EjecutarSQL(strSql) > 0;
        }

        internal bool delete(int id)
        {
            String strSql = "delete tortas WHERE id_torta =" + id;
            return DataManager.GetInstance().EjecutarSQL(strSql) != 0;
        }

        internal IList<Torta> GetAll(string nombres)
        {
            List<Torta> Tortas = new List<Torta>();

            String strSql = "SELECT * from tortas where nombre like '%'+ '"+ nombres + "' +'%' and borrado <> 1 ORDER BY nombre;";
            DataTable t = DataManager.GetInstance().ConsultaSQL(strSql);

            foreach (DataRow row in t.Rows)
            {
                int id = int.Parse(row["id_torta"].ToString());
                string nombre = row["nombre"].ToString();
                bool borrado = bool.Parse(row["borrado"].ToString());
                int porcentaje = int.Parse(row["porcentaje"].ToString());
                Torta obj = new Torta(id, nombre,borrado,porcentaje);
                Tortas.Add(obj);
            }
            return Tortas;
        }

        internal IList<Torta> GetAll2(string nombres)
        {
            List<Torta> Tortas = new List<Torta>();

            String strSql = "SELECT * from tortas where nombre like '%'+ '" + nombres + "' +'%' and borrado <> 1;";
            DataTable t = DataManager.GetInstance().ConsultaSQL(strSql);

            foreach (DataRow row in t.Rows)
            {
                int id = int.Parse(row["id_torta"].ToString());
                string nombre = row["nombre"].ToString();
                bool borrado = bool.Parse(row["borrado"].ToString());
                int porcentaje = int.Parse(row["porcentaje"].ToString());
                Torta obj = new Torta(id, nombre, borrado, porcentaje);
                Tortas.Add(obj);
            }
            return Tortas;
        }

        internal bool actualizar(Torta oTorta,int id)
        {
            String strSql = "UPDATE tortas set porcentaje = @param1 where id_torta = "+id;
            var parametros = new Dictionary<string, object>();
            parametros.Add("param1", oTorta.porcentaje);
            return (DataManager.GetInstance().EjecutarSQL(strSql, parametros) == 1);
        }

        internal IList<Torta> GetById(int id_torta)
        {
            List<Torta> Tortas = new List<Torta>();

            String strSql = "SELECT * from tortas where id_torta = "+id_torta;
            DataTable t = DataManager.GetInstance().ConsultaSQL(strSql);

            foreach (DataRow row in t.Rows)
            {
                int id = int.Parse(row["id_torta"].ToString());
                string nombre = row["nombre"].ToString();
                bool borrado = bool.Parse(row["borrado"].ToString());
                int porcentaje = int.Parse(row["porcentaje"].ToString());
                Torta obj = new Torta(id, nombre, borrado,porcentaje);
                Tortas.Add(obj);
            }
            return Tortas;
        }
    }
}
