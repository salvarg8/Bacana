//using Bacana.Datos.Helper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bacana.Datos.Dao.Implementación
{
    public class InsumosDao
    {
        public IList<Insumo> GetAll(string producto)
        {
            List<Insumo> Insumos = new List<Insumo>();

            String strSql = "SELECT * from dbo.insumos where producto like '%"+producto+"%' and estado <> 1;";
            DataTable t = DataManager.GetInstance().ConsultaSQL(strSql);

            foreach (DataRow row in t.Rows)
            {
                int id = int.Parse(row["id_insumo"].ToString());
                int tipo = int.Parse(row["tipo"].ToString());
                float precio = float.Parse(row["precio"].ToString());
                Insumo obj = new Insumo(id, row["producto"].ToString(),precio, row["proveedor"].ToString(),tipo);
                Insumos.Add(obj);
            }
            return Insumos;
        }

        internal bool Actualizar(Insumo oInsumoSeleccionado)
        {
            String strSql = "UPDATE insumos set producto = @param1, precio = @param2, proveedor = @param3, tipo = @param4 where id_insumo = @param5";
            var parametros = new Dictionary<string, object>();
            parametros.Add("param1", oInsumoSeleccionado.NombreInsumo);
            parametros.Add("param2", oInsumoSeleccionado.PrecioInsumo);
            parametros.Add("param3", oInsumoSeleccionado.ProveedorInsumo);
            parametros.Add("param4", oInsumoSeleccionado.TipoInsumo);
            parametros.Add("param5", oInsumoSeleccionado.CodigoInsumo);
            return (DataManager.GetInstance().EjecutarSQL(strSql, parametros) == 1);
        }

        internal string obtenerTipoInsumoPorId(int codigoInsumo)
        {
            String strSql = "select tipo_insumos.tipo_Insumo from tipo_insumos, insumos where(insumos.id_insumo = "+codigoInsumo+" and insumos.tipo = tipo_insumos.id_tipo) group by tipo_insumos.tipo_Insumo";
            DataTable t = DataManager.GetInstance().ConsultaSQL(strSql);

            foreach (DataRow row in t.Rows)
            {
                return row["tipo_insumo"].ToString();
            }
            return "f";
        }

        internal int obtenerIdPorTipoNombre(int tipo, string nombre)
        {
            String strSql = "Select id_insumo from dbo.insumos where tipo = " + tipo + " and producto ='" + nombre + "';";
            DataTable t = DataManager.GetInstance().ConsultaSQL(strSql);

            foreach (DataRow row in t.Rows)
            {
                int id = Convert.ToInt32(row["id_insumo"].ToString());
                return id;
            }
            return 0;
        }

        internal string obtenerInsumo(int codigoInsumo)
        {
            String strSql = "Select producto from dbo.insumos where id_insumo = " + codigoInsumo + "and estado <> 1;";
            DataTable t = DataManager.GetInstance().ConsultaSQL(strSql);

            foreach (DataRow row in t.Rows)
            {
                return row["producto"].ToString();
            }
            return "F";
        }

        internal IList<Insumo> getOne(int cod)
        {

            List<Insumo> Insumos = new List<Insumo>();

            String strSql = "SELECT * from dbo.insumos where id_insumo = "+cod+" and estado <> 1;";
            DataTable t = DataManager.GetInstance().ConsultaSQL(strSql);

            foreach (DataRow row in t.Rows)
            {
                int id = int.Parse(row["id_insumo"].ToString());
                int tipo = int.Parse(row["tipo"].ToString());
                float precio = float.Parse(row["precio"].ToString());
                Insumo obj = new Insumo(id, row["producto"].ToString(), precio, row["proveedor"].ToString(), tipo);
                Insumos.Add(obj);
            }
            return Insumos;
        }

        internal bool Create(Insumo oInsumo)
        {
            String strSql = "insert into insumos(producto,precio,proveedor,tipo,estado)" +
                " VALUES(@nombre,@precio,@proveedor,@tipo,0)";

            var parametros = new Dictionary<string, object>();
            parametros.Add("nombre", oInsumo.NombreInsumo);
            parametros.Add("precio", oInsumo.PrecioInsumo);
            parametros.Add("proveedor", oInsumo.ProveedorInsumo);
            parametros.Add("tipo", oInsumo.TipoInsumo);

            return (DataManager.GetInstance().EjecutarSQL(strSql, parametros) == 1);
        }

        public bool delete(int id)
        {
            String strSql = "UPDATE insumos set estado = 1 WHERE id_insumo =" + id;
            return DataManager.GetInstance().EjecutarSQL(strSql) != 0;

        }

        internal bool cargaInsumo(string nombreInsumo, float PrecioInsumo, string proveedorInsumo, int tipoInsumo)
        {
            String strSql = "insert into insumos(producto,precio,proveedor,tipo,estado) VALUES('"+nombreInsumo+"',"+PrecioInsumo+",'"+proveedorInsumo+"',"+tipoInsumo+",0)";
            return DataManager.GetInstance().EjecutarSQL(strSql) > 0;

        }
    }
}
