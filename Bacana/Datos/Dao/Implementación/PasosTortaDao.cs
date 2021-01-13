using Bacana.Negocio.Entidades;
using System;
using System.Collections.Generic;
using System.Data;

namespace Bacana.Datos.Dao.Implementación
{
    class PasosTortaDao
    {
        internal IList<PasosTorta> getPasosPorNombreTorta(string nombres)
        {
            List<PasosTorta> Tortas = new List<PasosTorta>();

            String strSql = "SELECT * from recetas where paso like '%'+ '" + nombres + "' +'%';";
            DataTable t = DataManager.GetInstance().ConsultaSQL(strSql);

            foreach (DataRow row in t.Rows)
            {
                Tortas.Add(ObjectMapping(row));
            }
            return Tortas;
        }

        internal void crearPaso(PasosTorta oPasosTorta)
        {
            throw new NotImplementedException();
        }

        internal bool actualizarPaso(int numero, int id_torta, List<PasosTorta> pasos)
        {
            DataManager dm = new DataManager();
            try
            {
                dm.Open();
                dm.BeginTransaction();

                string strSql = "DELETE from [DB_bacana].[dbo].[recetas] where id_torta = @param1";
                var param = new Dictionary<string, object>();
                param.Add("param1", id_torta);
                dm.EjecutarSQL2(strSql, param);

                foreach (var obj in pasos)
                {
                    string sql = "INSERT INTO [DB_bacana].[dbo].[recetas] (posicion,id_torta,paso,estado) VALUES(@param1, @param2, @param3, @param4)";
                    var parametros = new Dictionary<string, object>();
                    parametros.Add("param1", obj.posicion);
                    parametros.Add("param2", id_torta);
                    parametros.Add("param3", obj.Paso);
                    parametros.Add("param4", 0);

                    dm.EjecutarSQL2(sql, parametros);
                }
                dm.Commit();
            }
            catch (Exception ex)
            {
                dm.Rollback();
                throw ex;
            }
            finally
            {
                dm.Close();
            }
            return true;
            
        }

        internal IList<PasosTorta> getPasosPorIdTorta(int id_torta)
        {
            List<PasosTorta> pasosTortas = new List<PasosTorta>();
            string strSql = "Select * from recetas where id_torta =" + id_torta + "order by posicion";
            DataTable t = DataManager.GetInstance().ConsultaSQL(strSql);

            foreach (DataRow row in t.Rows)
            {
                pasosTortas.Add(ObjectMapping(row));
            }
            return pasosTortas;
        }

        private PasosTorta ObjectMapping(DataRow row)
        {
            PasosTorta oPasosTorta = new PasosTorta
            {
                posicion = int.Parse(row["posicion"].ToString()),
                Paso = row["paso"].ToString(),
                torta = new Torta()
                {
                    id_torta = int.Parse(row["id_torta"].ToString()),
                }
            };
            return oPasosTorta;
        }
    }
}
