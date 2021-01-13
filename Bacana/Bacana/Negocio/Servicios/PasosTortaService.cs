using Bacana.Datos.Dao.Implementación;
using Bacana.Negocio.Entidades;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bacana.Negocio.Servicios
{
    class PasosTortaService
    {
        private PasosTortaDao oPasosTortaDao;

        public PasosTortaService()
        {
            oPasosTortaDao = new PasosTortaDao();
        }

        internal IList<PasosTorta> getPasosPorNombreTorta(string text)
        {
            return oPasosTortaDao.getPasosPorNombreTorta(text);
        }

        internal void crearPaso(PasosTorta oPasosTorta)
        {
            oPasosTortaDao.crearPaso(oPasosTorta);
        }

        internal bool actualizar(int numero, int id_torta, List<PasosTorta> pasos)
        {
            return oPasosTortaDao.actualizarPaso(numero, id_torta, pasos);
        }

        internal IList<PasosTorta> getPasosPorIdTorta(int id_torta)
        {
            return oPasosTortaDao.getPasosPorIdTorta(id_torta);
        }
    }
}
