using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bacana.Negocio.Entidades
{
    class Factura
    {
        public int IdFactura { get; set; }
        public DateTime Fecha { get; set; }
        public Cliente Cliente { get; set; }
        public IList<FacturaDetalle> FacturaDetalle { get; set; }
        public double ImporteTotal { get; set; }
        public bool Anulado { get; set; }

        public Factura()
        { }
        public Factura(int idFactura, DateTime fecha, Cliente cliente, double importeTotal, bool anulado)
        {
            IdFactura = idFactura;
            Fecha = fecha;
            Cliente = cliente;
            ImporteTotal = importeTotal;
            Anulado = anulado;
        }
    }
}
