using Bacana.Datos.Dao.Implementación;
using Bacana.Negocio.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bacana.Negocio.Servicios
{
    class InsumosTipoService
    {
        private InsumosTipoDao oInsumosTipoDao;

        public InsumosTipoService()
        {
            oInsumosTipoDao = new InsumosTipoDao();
        }

        public IList<InsumosTipo> GetTipoInsumo()
        {
            return oInsumosTipoDao.GetAll();
        }
        public IList<InsumosTipo> GetOneInsumo(int param)
        {
            return oInsumosTipoDao.GetOne(param);
        }

        internal void cargaInsumoTipo(string nombreInsumo)
        {
            oInsumosTipoDao.cargaInsumo(nombreInsumo);
        }


        internal bool actualizarInsumoTipo(InsumosTipo oInsumoTipoSeleccionado)
        {
            return oInsumosTipoDao.Actualizar(oInsumoTipoSeleccionado);
        }

        internal bool borrarInsumoTipo(int id)
        {
            return oInsumosTipoDao.delete(id);
        }

        internal bool crearInsumoTipo(InsumosTipo oInsumoTipo)
        {
            return oInsumosTipoDao.Create(oInsumoTipo);
        }
    }
}
