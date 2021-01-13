using Bacana.Datos.Dao.Implementación;
using Bacana.Negocio.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Bacana.Negocio.Servicios
{
    public class FacturaService
    {
        private FacturasDao oFacturasDao;

        public FacturaService()
        {
            oFacturasDao = new FacturasDao();
        }
        internal int getNumeroFactura()
        {
            return oFacturasDao.getNumeroFactura();
        }

        internal object Crear(Factura factura)
        {
            return oFacturasDao.Create(factura);
        }

        internal IList<Factura> getAll()
        {
            return oFacturasDao.getAll();
        }

        internal IList<Factura> getByFilter(string txtFactura, string dtpDesde, string dtpHasta)
        {
            return oFacturasDao.getByFilter(txtFactura, dtpDesde, dtpHasta);
        }

        internal bool anularFactura(int id)
        {
            return oFacturasDao.anularFactura(id);
        }

        internal IList<Factura> getbyCliente(object id)
        {
            return oFacturasDao.getById(id);
        }

        internal IList<Factura> getByFilterAndId(string text, string desde, string hasta, int id)
        {
            return oFacturasDao.getByFilterAndId(text, desde, hasta, id);
        }
    }
}
