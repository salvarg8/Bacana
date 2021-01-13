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
    class PercancesDao
    {
        public IList<Percances> GetAll()
        {
            List<Percances> Percance = new List<Percances>();

            String strSql = "SELECT * from dbo.percances where estado <> 1;";
            DataTable t = DataManager.GetInstance().ConsultaSQL(strSql);

            foreach (DataRow row in t.Rows)
            {
                int id = int.Parse(row["id_percance"].ToString());
                string nombre = row["producto"].ToString();
                DateTime fecha = DateTime.Parse(row["fecha"].ToString());
                float costo = float.Parse(row["costo"].ToString());
                string descripcion = row["descripcion"].ToString();
                Percances obj = new Percances(id, nombre,fecha,costo,descripcion);
                Percance.Add(obj);
            }
            return Percance;
        }

        internal bool Actualizar(Percances oPercancesSeleccionado)
        {
            String strSql = "UPDATE percances set producto = @param1, fecha = @param2, costo = @param3, descripcion = @param4 where id_percance = @param5";
            var parametros = new Dictionary<string, object>();
            parametros.Add("param1", oPercancesSeleccionado.Producto);
            parametros.Add("param2", oPercancesSeleccionado.Fecha);
            parametros.Add("param3", oPercancesSeleccionado.Costo);
            parametros.Add("param4", oPercancesSeleccionado.Descripcion);
            parametros.Add("param5", oPercancesSeleccionado.Id);
            return (DataManager.GetInstance().EjecutarSQL(strSql, parametros) == 1);
        }

        internal IList<Percances> getOne(int cod)
        {

            List<Percances> Percance = new List<Percances>();

            String strSql = "SELECT * from dbo.percances where id_percance = " + cod + " and estado <> 1;";
            DataTable t = DataManager.GetInstance().ConsultaSQL(strSql);

            foreach (DataRow row in t.Rows)
            {
                int id = int.Parse(row["id_percance"].ToString());
                string nombre = row["producto"].ToString();
                DateTime fecha = DateTime.Parse(row["fecha"].ToString());
                float costo = float.Parse(row["costo"].ToString());
                string descripcion = row["descripcion"].ToString();
                Percances obj = new Percances(id, nombre, fecha, costo, descripcion);
                Percance.Add(obj);
            }
            return Percance;
        }

        internal bool Create(Percances oPercance)
        {
            String strSql = "insert into percances(producto,fecha,costo,descripcion,estado)" +
                " VALUES(@producto,@fecha,@costo,@descripcion,0)";

            var parametros = new Dictionary<string, object>();
            parametros.Add("producto", oPercance.Producto);
            parametros.Add("fecha", oPercance.Fecha);
            parametros.Add("costo", oPercance.Costo);
            parametros.Add("descripcion", oPercance.Descripcion);

            return (DataManager.GetInstance().EjecutarSQL(strSql, parametros) == 1);
        }

        public bool delete(int id)
        {
            String strSql = "UPDATE percances set estado = 1 WHERE id_percance =" + id;
            return DataManager.GetInstance().EjecutarSQL(strSql) != 0;
        }

        internal bool cargaPercance(string producto, DateTime fecha, float costo, string descripcion)
        {
            String strSql = "insert into percances(producto,fecha,costo,descripcion,estado) VALUES('" + producto + "'," + fecha + "," + costo + ",'" + descripcion + "',0)";
            return DataManager.GetInstance().EjecutarSQL(strSql) > 0;
        }
    }
}
