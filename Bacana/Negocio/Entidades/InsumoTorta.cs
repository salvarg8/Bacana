using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bacana.Negocio.Entidades
{
    class InsumoTorta
    {
        public Insumo insumo { get; set; }
        public float cantidad { get; set; }
        public Torta torta { get; set; }

        public InsumoTorta(Insumo insumo, float cantidad, Torta torta)
        {
            this.insumo = insumo;
            this.cantidad = cantidad;
            this.torta = torta;
        }

        public InsumoTorta()
        {
        }
    }
}
