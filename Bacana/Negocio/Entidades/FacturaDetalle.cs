using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bacana.Negocio.Entidades
{
    class FacturaDetalle
    {
        public int IdFactura { get; set; }
        public Torta Torta { get; set; }
        public Double PrecioUnitario { get; set; }
        public int Cantidad { get; set; }

        public FacturaDetalle(int idFactura,Torta torta, double precioUnitario, int cantidad)
        {
            IdFactura = idFactura;
            Torta = torta;
            PrecioUnitario = precioUnitario;
            Cantidad = cantidad;
        }

        public int IdProducto
        {
            get
            {
                return Torta.id_torta;
            }
        }
        public string ProductoDescripcion
        {
            get
            {
                return Torta.nombre;
            }
        }

        public Double Importe
        {
            get
            {
                return Cantidad * PrecioUnitario;
            }
        }
    }
}
