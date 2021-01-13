using Bacana.Datos.Dao.Implementación;
using Bacana.Datos.Dao;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bacana.Negocio.Entidades;

namespace Bacana.Negocio.Servicios
{
    class PercancesService
    {
        private PercancesDao oPercancesDao;

        public PercancesService()
        {
            oPercancesDao = new PercancesDao();
        }

        public IList<Percances> GetPercances()
        {
            return oPercancesDao.GetAll();
        }

        internal void cargaPercance(string nombre, DateTime fecha, float costo, string descrip)
        {
            oPercancesDao.cargaPercance(nombre, fecha, costo, descrip);
        }


        internal bool actualizarPercance(Percances oPercanceSeleccionado)
        {
            return oPercancesDao.Actualizar(oPercanceSeleccionado);
        }

        internal bool borrarPercance(int id)
        {
            return oPercancesDao.delete(id);
        }

        internal bool crearPercance(Percances oPercance)
        {
            return oPercancesDao.Create(oPercance);
        }
        
        internal IList<Percances> GetPercanceId(int id)
        {
            return oPercancesDao.getOne(id);
        }
    }
}
