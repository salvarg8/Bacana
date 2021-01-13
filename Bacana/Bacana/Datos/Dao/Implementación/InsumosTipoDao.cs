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
    public class InsumosTipoDao
    {
        public IList<InsumosTipo> GetAll()
        {
            List<InsumosTipo> insumosTipo = new List<InsumosTipo>();

            String strSql = "SELECT * from dbo.tipo_insumos where estado <> 1;";
            DataTable t = DataManager.GetInstance().ConsultaSQL(strSql);

            foreach (DataRow row in t.Rows)
            {
                int id = int.Parse(row["id_tipo"].ToString());
                string tipo = row["tipo_Insumo"].ToString();
                InsumosTipo obj = new InsumosTipo(id, row["producto"].ToString());
                insumosTipo.Add(obj);
            }
            return insumosTipo;
        }

        internal bool cargaInsumo(string nombreTipoInsumo)
        {
            String strSql = "insert into tipo_insumos(tipo_Insumo,estado) VALUES('" + nombreTipoInsumo + "',0)";
            return DataManager.GetInstance().EjecutarSQL(strSql) > 0;
        }

        public bool delete(int id)
        {
            String strSql = "UPDATE tipo_insumos set estado = 1 WHERE id_tipo =" + id;
            return DataManager.GetInstance().EjecutarSQL(strSql) != 0;
        }

        internal bool Actualizar(InsumosTipo oTipoInsumoSeleccionado)
        {
            String strSql = "UPDATE insumos set tipo_Insumo = @param1 where id_tipo = @param2";
            var parametros = new Dictionary<string, object>();
            parametros.Add("param1", oTipoInsumoSeleccionado.NombreTipoInsumo);
            parametros.Add("param2", oTipoInsumoSeleccionado.IdInsumo);
            return (DataManager.GetInstance().EjecutarSQL(strSql, parametros) == 1);
        }
        internal bool Create(InsumosTipo oInsumotipo)
        {
            String strSql = "insert into tipo_Insumo(tipo_Insumo,estado)" +
                " VALUES(@nombre,0)";

            var parametros = new Dictionary<string, object>();
            parametros.Add("nombre", oInsumotipo.NombreTipoInsumo);
            return (DataManager.GetInstance().EjecutarSQL(strSql, parametros) == 1);
        }

        public IList<InsumosTipo> GetOne(int param)
        {
            List<InsumosTipo> insumosTipo = new List<InsumosTipo>();

            String strSql = "SELECT * from dbo.tipo_insumos where id_tipo = " + param;
            DataTable t = DataManager.GetInstance().ConsultaSQL(strSql);

            foreach (DataRow row in t.Rows)
            {
                int id = int.Parse(row["id_tipo"].ToString());
                string tipo = row["tipo_Insumo"].ToString();
                InsumosTipo obj = new InsumosTipo(id, row["tipo_Insumo"].ToString());
                insumosTipo.Add(obj);
            }
            return insumosTipo;
        }
    }
}
