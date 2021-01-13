using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bacana.Datos.Dao.Implementación
{
    public class ClientesDao
    {
        public IList<Cliente> GetAll()
        {
            List<Cliente> Clientes = new List<Cliente>();

            String strSql = "SELECT * from dbo.clientes where estado <> 1;";
            DataTable t = DataManager.GetInstance().ConsultaSQL(strSql);
            foreach (DataRow row in t.Rows)
            {
                int id = int.Parse(row["id_cliente"].ToString());
                string nombre = row["nombre"].ToString();
                string apellido = row["apellido"].ToString();
                double telefono = double.Parse(row["telefono"].ToString());
                string direccion = row["direccion"].ToString();
                Cliente obj = new Cliente(id, nombre, apellido, telefono, direccion);
                Clientes.Add(obj);
            }
            return Clientes;
        }

        internal bool Actualizar(Cliente oClienteSeleccionado)
        {
            String strSql = "UPDATE clientes set nombre = @param1, apellido = @param2, telefono = @param3, direccion = @param4 where id_cliente = @param5";
            var parametros = new Dictionary<string, object>();
            parametros.Add("param1", oClienteSeleccionado.Nombre);
            parametros.Add("param2", oClienteSeleccionado.Apellido);
            parametros.Add("param3", oClienteSeleccionado.Telefono);
            parametros.Add("param4", oClienteSeleccionado.Domicilio);
            parametros.Add("param5", oClienteSeleccionado.Id);
            return (DataManager.GetInstance().EjecutarSQL(strSql, parametros) == 1);
        }

        internal int getIdNuevoCliete()
        {
        
            
            string strSql = "SELECT max(id_cliente) FROM [DB_bacana].[dbo].[clientes]";
            var a = DataManager.GetInstance().ConsultaSQLScalar(strSql);
            if (a is DBNull)
            {
                return 1;
            }
            else
                return Convert.ToInt32(a) + 1;
            
        }

        internal IList<Cliente> getOne(int cod)
        {

            List<Cliente> Clientes = new List<Cliente>();

            String strSql = "SELECT * from dbo.clientes where id_cliente = " + cod + " and estado <> 1;";
            DataTable t = DataManager.GetInstance().ConsultaSQL(strSql);

            //DataTable t = DBHelper.getDBHelper().ConsultaSQL(strSql);
            foreach (DataRow row in t.Rows)
            {
                int id = int.Parse(row["id_cliente"].ToString());
                string nombre = row["nombre"].ToString();
                string apellido = row["apellido"].ToString();
                double telefono = double.Parse(row["telefono"].ToString());
                string direccion = row["direccion"].ToString();
                Cliente obj = new Cliente(id, nombre, apellido, telefono, direccion);
                Clientes.Add(obj);
            }
            return Clientes;
        }

        internal bool Create(Cliente oCliente)
        {
            String strSql = "insert into DB_bacana.dbo.clientes (id_cliente,nombre,apellido,telefono,direccion,estado) Values (@param1,@param2,@param3,@param4,@param5,0);";

            var parametros = new Dictionary<string, object>();
            parametros.Add("param1", oCliente.Id);
            parametros.Add("param2", oCliente.Nombre);
            parametros.Add("param3", oCliente.Apellido);
            parametros.Add("param4", oCliente.Telefono);
            parametros.Add("param5", oCliente.Domicilio);

            return (DataManager.GetInstance().EjecutarSQL(strSql, parametros) == 1);
        }

        public bool delete(int id)
        {
            String strSql = "UPDATE clientes set estado = 1 WHERE id_cliente =" + id;
            return DataManager.GetInstance().EjecutarSQL(strSql) != 0;
        }

        internal bool cargaCliente(string nombre, string apellido, double telefono, string direccion)
        {
            String strSql = "insert into insumos(producto,precio,proveedor,tipo,estado)+" +
                " VALUES(id_cliente+1000'" + nombre + "','" + apellido + "'," + telefono + ",'" + direccion + "',0)";
            return DataManager.GetInstance().EjecutarSQL(strSql) > 0;
        }

        internal IList<Cliente> GetByNombreApellido(string nom, string ape)
        {

            List<Cliente> Clientes = new List<Cliente>();

            String strSql = "SELECT * from dbo.clientes where nombre like '%"+nom+ "%' and apellido like '%" + ape + "%' and estado <> 1;";
            DataTable t = DataManager.GetInstance().ConsultaSQL(strSql);

            foreach (DataRow row in t.Rows)
            {
                int id = int.Parse(row["id_cliente"].ToString());
                string nombre = row["nombre"].ToString();
                string apellido = row["apellido"].ToString();
                double telefono = double.Parse(row["telefono"].ToString());
                string direccion = row["direccion"].ToString();
                Cliente obj = new Cliente(id, nombre, apellido, telefono, direccion);
                Clientes.Add(obj);
            }
            return Clientes;

        }
        internal IList<Cliente> getByApellido(string ape)
        {

            List<Cliente> Clientes = new List<Cliente>();

            String strSql = "SELECT * from dbo.clientes where apellido like '%"+ape+"%' and estado <> 1;";
            DataTable t = DataManager.GetInstance().ConsultaSQL(strSql);

            foreach (DataRow row in t.Rows)
            {
                int id = int.Parse(row["id_cliente"].ToString());
                string nombre = row["nombre"].ToString();
                string apellido = row["apellido"].ToString();
                double telefono = double.Parse(row["telefono"].ToString());
                string direccion = row["direccion"].ToString();
                Cliente obj = new Cliente(id, nombre, apellido, telefono, direccion);
                Clientes.Add(obj);
            }
            return Clientes;
        }
    }
}
