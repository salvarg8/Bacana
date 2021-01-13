using Bacana.Datos.Dao.Implementación;
using Bacana.Datos.Dao;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bacana.Negocio.Servicios
{
    public class InsumosService
    {
        private InsumosDao oInsumosDao;

        public InsumosService()
        {
            oInsumosDao = new InsumosDao();
        }

        public IList<Insumo> GetInsumos(string producto)
        {
            return oInsumosDao.GetAll(producto);
        }
        
        internal void cargaInsumo(string nombreInsumo, float precioInsumo, string proveedorInsumo, int tipoInsumo)
        {
            oInsumosDao.cargaInsumo(nombreInsumo,precioInsumo,proveedorInsumo,tipoInsumo);
        }
        

        internal bool actualizarInsumo(Insumo oInsumoSeleccionado)
        {
            return oInsumosDao.Actualizar(oInsumoSeleccionado);
        }

        internal bool borrarInsumo(int id)
        {
            return oInsumosDao.delete(id);
        }

        internal bool crearInsumo(Insumo oInsumo)
        {
            return oInsumosDao.Create(oInsumo);
        }

        internal IList<Insumo> GetInsumosId(int id)
        {
            return oInsumosDao.getOne(id);
        }

        internal string buscarInsumoPorId(int codigoInsumo)
        {
            return oInsumosDao.obtenerInsumo(codigoInsumo);
        }

        internal int BuscarInsumoPorTipoYnombre(int tipo, string nombre)
        {
            return oInsumosDao.obtenerIdPorTipoNombre(tipo, nombre);
        }

        internal string buscarTipoPorId(int codigoInsumo)
        {
            return oInsumosDao.obtenerTipoInsumoPorId(codigoInsumo);
        }
    }
}
