using Bacana.Datos.Dao.Implementación;
using Bacana.Negocio.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bacana.Negocio.Servicios
{
    class InsumosTortasService
    {

        private InsumosTortasDao oInsumosTortasDao;

        public InsumosTortasService()
        {
            oInsumosTortasDao = new InsumosTortasDao();
        }


        internal bool borrarInsumoTorta(int id_torta, int id_insumo)
        {
            return oInsumosTortasDao.delete(id_torta, id_insumo);
        }

        internal IList<InsumoTorta> getInsumos(object id)
        {
            return oInsumosTortasDao.getById(id);
        }

        internal bool agregarInsumo(int torta, float cantidad, int insumo)
        {
           return oInsumosTortasDao.Create(torta,cantidad,insumo);
        }

        internal IList<InsumoTorta> getInsumosPorNombreTorta(string name)
        {
            return oInsumosTortasDao.getByName(name);
        }

        internal IList<InsumoTorta> insumoUtilizado(int id)
        {
            return oInsumosTortasDao.getByInsumo(id);
        }

        internal bool existe(int torta, int insumo)
        {
            return oInsumosTortasDao.existe(torta, insumo);
        }

        internal IList<InsumoTorta> getInsumos(int torta, int insumo)
        {
            return oInsumosTortasDao.getInsumoTorta(torta, insumo);
        }

        internal void modificarInsumoTorta(int torta, float v, int insumo)
        {
            oInsumosTortasDao.modificarInsumoTorta(torta, v, insumo);
        }
    }
}
