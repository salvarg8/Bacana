using Bacana.Datos.Dao.Implementación;
using System;
using System.Collections.Generic;

namespace Bacana.Negocio.Servicios
{
    public class ClientesService
    {
        private ClientesDao oCLientesDao;

        public ClientesService()
        {
            oCLientesDao = new ClientesDao();
        }

        public IList<Cliente> GetClientes()
        {
            return oCLientesDao.GetAll();
        }

        internal void cargaCliente(string nombre, string apellido, double telefono, string direccion)
        {
            oCLientesDao.cargaCliente(nombre, apellido, telefono, direccion);
        }


        internal bool actualizarCliente(Cliente oInsumoSeleccionado)
        {
            return oCLientesDao.Actualizar(oInsumoSeleccionado);
        }

        internal bool borrarCliente(int id)
        {
            return oCLientesDao.delete(id);
        }

        internal bool crearCliente(Cliente oCliente)
        {
            return oCLientesDao.Create(oCliente);
        }

        internal IList<Cliente> GetClientesId(int id)
        {
            return oCLientesDao.getOne(id);
        }

        

        internal IList<Cliente> GetClientesNombreApellido(string nom, string ape)
        {
            return oCLientesDao.GetByNombreApellido(nom, ape);
        }
        internal IList<Cliente> GetClientesApellido(string ape)
        {
            return oCLientesDao.getByApellido(ape);
        }

        internal int getIdNuevoCliente()
        {
            return oCLientesDao.getIdNuevoCliete();
        }
    }
}
