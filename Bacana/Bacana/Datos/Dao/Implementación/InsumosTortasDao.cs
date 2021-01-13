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
    class InsumosTortasDao
    {


        

        internal bool delete(int id_torta, int id_insumo)
        {
            String strSql = "DELETE from insumos_torta WHERE id_torta =" + id_torta+ "and id_insumo ="+id_insumo;
            return DataManager.GetInstance().EjecutarSQL(strSql) != 0;
        }

        internal bool Create(int torta, float cantidad, int insumo)
        {
            String strSql = "insert into [DB_bacana].[dbo].[insumos_torta] (id_insumo,cantidad,id_torta) VALUES(@insumo,@cant,@torta);";

            var parametros = new Dictionary<string, object>();
            parametros.Add("insumo", insumo);
            parametros.Add("cant", cantidad);
            parametros.Add("torta", torta);
            return (DataManager.GetInstance().EjecutarSQL(strSql, parametros) == 1);
        }

        internal IList<InsumoTorta> getByName(string name)
        {
            List<InsumoTorta> Tortas = new List<InsumoTorta>();
            String strSql = "select id_insumo,cantidad,insumos_torta.id_torta from insumos_torta, tortas where (tortas.id_torta = insumos_torta.id_torta and tortas.nombre = '"+name+"')";
            DataTable t = DataManager.GetInstance().ConsultaSQL(strSql);

            foreach (DataRow row in t.Rows)
            {
                Tortas.Add(ObjectMapping(row));
            }
            return Tortas;
        }

        internal void modificarInsumoTorta(int torta, float v, int insumo)
        {
            String strSql = "update insumos_torta set cantidad = " +v+" where (id_torta =" + torta +"and id_insumo = "+insumo+") ";
            DataManager.GetInstance().EjecutarSQL(strSql);
            
        }

        internal IList<InsumoTorta> getInsumoTorta(int torta, int insumo)
        {
            List<InsumoTorta> insumoTorta = new List<InsumoTorta>();
            String strSql = "Select * from insumos_torta where id_torta =" + torta + "and id_insumo =" + insumo;
            DataTable t = DataManager.GetInstance().ConsultaSQL(strSql);
            foreach (DataRow row in t.Rows)
            {
                insumoTorta.Add(ObjectMapping(row));
            }
            return insumoTorta;

        }

        internal bool existe(int torta, int insumo)
        {
            List<InsumoTorta> insumoTorta = new List<InsumoTorta>();
            String strSql = "Select * from insumos_torta where id_torta =" + torta + "and id_insumo =" + insumo;
            DataTable t = DataManager.GetInstance().ConsultaSQL(strSql);
            if (t.Rows.Count != 0)
                return true;
            else
                return false;

        }

        internal IList<InsumoTorta> getByInsumo(int id)
        {
            List<InsumoTorta> Tortas = new List<InsumoTorta>();

            String strSql = "SELECT * from insumos_torta where id_insumo = " + id;
            DataTable t = DataManager.GetInstance().ConsultaSQL(strSql);

            foreach (DataRow row in t.Rows)
            {
                Tortas.Add(ObjectMapping(row));
            }
            return Tortas;
        }

        internal IList<InsumoTorta> getById(object id)
        {
            List<InsumoTorta> Tortas = new List<InsumoTorta>();

            String strSql = "SELECT * from insumos_torta where id_torta = " + id;
            DataTable t = DataManager.GetInstance().ConsultaSQL(strSql);

            foreach (DataRow row in t.Rows)
            {
                Tortas.Add(ObjectMapping(row));
            }
            return Tortas;
        }



        private InsumoTorta ObjectMapping(DataRow row)
        {
            InsumoTorta oInsumoTorta = new InsumoTorta
            {
                insumo = new Insumo()
                {
                    CodigoInsumo = Convert.ToInt32(row["id_insumo"].ToString()),
                },
                cantidad = Convert.ToSingle(row["cantidad"].ToString()),
                torta = new Torta()
                {
                    id_torta = int.Parse(row["id_torta"].ToString()),
                }
            };
            return oInsumoTorta;
        }
    }
}

