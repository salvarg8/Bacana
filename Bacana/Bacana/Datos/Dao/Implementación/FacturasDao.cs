//using Bacana.Datos.Helper;
using Bacana.Negocio.Entidades;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Bacana.Datos.Dao.Implementación
{
    public class FacturasDao
    {
        private ClientesDao oClienteDao;
        public FacturasDao()
        {
            oClienteDao = new ClientesDao();
        }
        internal int getNumeroFactura()
        {
            string strSql = "SELECT max(id_factura) FROM [DB_bacana].[dbo].[facturas]";
            var a = DataManager.GetInstance().ConsultaSQLScalar(strSql);
            if (a is DBNull)
            {
                return 1;
            }
            else
                return Convert.ToInt32(a) + 1;
        }

        internal object Create(Factura factura)
        {
            DataManager dm = new DataManager();
            try
            {
                dm.Open();
                dm.BeginTransaction();

                string sql = string.Concat("   INSERT INTO [DB_bacana].[dbo].[facturas] ",
                                            "           ([id_factura]   ",
                                            "           ,[id_cliente]   ",
                                            "           ,[fecha]         ",
                                            "           ,[importe]    ",
                                            "           ,[estado]    ",
                                            "           ,[anulado])      ",
                                            "     VALUES                 ",
                                            "           (@factura        ",
                                            "           ,@cliente          ",
                                            "           ,@fecha          ",
                                            "           ,@total     ",
                                            "           ,@estado     ",
                                            "           ,@anulado)       ");


                var parametros = new Dictionary<string, object>();
                parametros.Add("factura", factura.IdFactura);
                parametros.Add("cliente", factura.Cliente.Id);
                parametros.Add("fecha", factura.Fecha);
                parametros.Add("total", factura.ImporteTotal);
                parametros.Add("estado", 0);
                parametros.Add("anulado", false);
                dm.EjecutarSQL2(sql, parametros);


                foreach (var itemFactura in factura.FacturaDetalle)
                {
                    string sqlDetalle = string.Concat(" INSERT INTO [DB_bacana].[dbo].[detalle_factura] ",
                                                        "           ([id_factura]           ",
                                                        "           ,[id_articulo]          ",
                                                        "           ,[cantidad]             ",
                                                        "           ,[unitario])             ",

                                                        "     VALUES                        ",
                                                        "           (@id_factura            ",
                                                        "           ,@id_producto           ",
                                                        "           ,@cantidad              ",
                                                        "           ,@precio_unitario)      ");


                    var paramDetalle = new Dictionary<string, object>();
                    paramDetalle.Add("id_factura", itemFactura.IdFactura);
                    paramDetalle.Add("id_producto", itemFactura.IdProducto);
                    paramDetalle.Add("cantidad", itemFactura.Cantidad);
                    paramDetalle.Add("precio_unitario", itemFactura.PrecioUnitario);

                    dm.EjecutarSQL2(sqlDetalle, paramDetalle);
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
                // Cierra la conexión 
                dm.Close();
            }
            return true;
        }

        internal IList<Factura> getByFilterAndId(string text, string desde, string hasta, int Id)
        {
            List<Factura> facturas = new List<Factura>();
            String strSql = "select * from [DB_bacana].[dbo].[facturas] where id_factura like '%" + text + "%'  and fecha <= '" + hasta + "' and fecha >= '" + desde + "' and id_cliente = "+Id;
            DataTable t = DataManager.GetInstance().ConsultaSQL(strSql);

            foreach (DataRow row in t.Rows)
            {
                int id = int.Parse(row["id_factura"].ToString());
                int idCliente = int.Parse(row["id_cliente"].ToString());
                IList<Cliente> lst = oClienteDao.getOne(idCliente);
                Cliente selected = new Cliente(lst[0].Id, lst[0].Nombre, lst[0].Apellido, lst[0].Telefono, lst[0].Domicilio);
                DateTime fecha = DateTime.Parse(row["fecha"].ToString());
                float importe = float.Parse(row["importe"].ToString());
                bool estado = bool.Parse(row["anulado"].ToString());
                Factura obj = new Factura(id, fecha, selected, importe, estado);
                facturas.Add(obj);
            }
            return facturas;
        }

        internal IList<Factura> getById(object Id)
        {
            List<Factura> facturas = new List<Factura>();
            String strSql = "SELECT * from [DB_bacana].[dbo].[facturas] where id_cliente = "+Id;
            DataTable t = DataManager.GetInstance().ConsultaSQL(strSql);

            foreach (DataRow row in t.Rows)
            {
                int id = int.Parse(row["id_factura"].ToString());
                int idCliente = int.Parse(row["id_cliente"].ToString());
                IList<Cliente> lst = oClienteDao.getOne(idCliente);
                Cliente selected = new Cliente(lst[0].Id, lst[0].Nombre, lst[0].Apellido, lst[0].Telefono, lst[0].Domicilio);
                DateTime fecha = DateTime.Parse(row["fecha"].ToString());
                float importe = float.Parse(row["importe"].ToString());
                bool estado = bool.Parse(row["anulado"].ToString());
                Factura obj = new Factura(id, fecha, selected, importe, estado);
                facturas.Add(obj);
            }
            return facturas;
        }

        internal bool anularFactura(int id)
        {
            String strSql = "UPDATE [DB_bacana].[dbo].[facturas] set anulado = 1 WHERE id_factura =" + id;
            return DataManager.GetInstance().EjecutarSQL(strSql) != 0;

        }

        internal IList<Factura> getByFilter(string Factura, string Desde, string Hasta)
        {

            List<Factura> facturas = new List<Factura>();
            String strSql = "select * from [DB_bacana].[dbo].[facturas] where id_factura like '%"+Factura+"%'  and fecha <= '"+ Hasta+"' and fecha >= '"+Desde+"'";
            DataTable t = DataManager.GetInstance().ConsultaSQL(strSql);

            foreach (DataRow row in t.Rows)
            {
                int id = int.Parse(row["id_factura"].ToString());
                int idCliente = int.Parse(row["id_cliente"].ToString());
                IList<Cliente> lst = oClienteDao.getOne(idCliente);
                Cliente selected = new Cliente(lst[0].Id, lst[0].Nombre, lst[0].Apellido, lst[0].Telefono, lst[0].Domicilio);
                DateTime fecha = DateTime.Parse(row["fecha"].ToString());
                float importe = float.Parse(row["importe"].ToString());
                bool estado = bool.Parse(row["anulado"].ToString());
                Factura obj = new Factura(id, fecha, selected, importe, estado);
                facturas.Add(obj);
            }
            return facturas;
        }

        internal IList<Factura> getAll()
        {
            List<Factura> facturas = new List<Factura>();
            String strSql = "SELECT * from [DB_bacana].[dbo].[facturas];";
            DataTable t = DataManager.GetInstance().ConsultaSQL(strSql);

            foreach (DataRow row in t.Rows)
            {
                int id = int.Parse(row["id_factura"].ToString());
                int idCliente = int.Parse(row["id_cliente"].ToString());
                IList<Cliente> lst = oClienteDao.getOne(idCliente);
                Cliente selected = new Cliente(lst[0].Id, lst[0].Nombre, lst[0].Apellido, lst[0].Telefono, lst[0].Domicilio);
                DateTime fecha = DateTime.Parse(row["fecha"].ToString());
                float importe= float.Parse(row["importe"].ToString());
                bool estado = bool.Parse(row["anulado"].ToString());
                Factura obj = new Factura(id,fecha,selected,importe,estado);
                facturas.Add(obj);
            }
            return facturas;
        }
    }
}


