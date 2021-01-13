using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bacana
{
    public class Insumo
    {
        public int CodigoInsumo { get; set; }
        public String NombreInsumo { get; set; }
        public float PrecioInsumo { get; set; }
        public String ProveedorInsumo { get; set; }
        public int TipoInsumo { get; set; }

        public Insumo(int codigoInsumo, string nombreInsumo, float precioInsumo, string proveedorInsumo, int tipoInsumo)
        {
            CodigoInsumo = codigoInsumo;
            NombreInsumo = nombreInsumo;
            PrecioInsumo = precioInsumo;
            ProveedorInsumo = proveedorInsumo;
            TipoInsumo = tipoInsumo;
        }

        public Insumo()
        { }
    }
}
