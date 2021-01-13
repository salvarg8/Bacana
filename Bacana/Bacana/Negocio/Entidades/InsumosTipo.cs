using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bacana.Negocio.Entidades
{
    public class InsumosTipo
    {
        public int IdInsumo { get; set; }
        public String NombreTipoInsumo { get; set; }
    

        public InsumosTipo(int id, string nombre)
        {
            IdInsumo = id;
            NombreTipoInsumo = nombre;
        }
    }
}
