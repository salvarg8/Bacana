using Bacana.Datos.Dao.Implementación;
using Bacana.Negocio.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bacana.Negocio.Servicios
{
    class TortasService
    {
        private TortasDao oTortasDao;

        public TortasService()
        {
            oTortasDao = new TortasDao();
        }


        internal void crearTorta(Torta oTorta)
        {
            oTortasDao.cargaTorta(oTorta);
        }

        internal bool borrarTorta(int id)
        {
            return oTortasDao.delete(id);
        }

        internal IList<Torta> getTorta(string nombre)
        {
            return oTortasDao.GetAll(nombre);

        }

        internal IList<Torta> getTortaId(int id_torta)
        {
            return oTortasDao.GetById(id_torta);
        }

        internal bool actualizar(Torta oTorta,int id)
        {
            return oTortasDao.actualizar(oTorta, id);
        }

        internal IList<Torta> getTorta2(string nombre)
        {
            return oTortasDao.GetAll2(nombre);
        }
    }
}
