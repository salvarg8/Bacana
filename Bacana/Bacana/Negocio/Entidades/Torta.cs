using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bacana.Negocio.Entidades
{
    public class Torta
    {
        public int id_torta { get; set; }
        public string nombre { get; set; }
        public bool borrado { get; set; }
        public int porcentaje { get; set; }
        public Torta()
        {
        }
        public Torta(int id_torta, string nombre, bool borrado, int porcentaje)
        {
            this.id_torta = id_torta;
            this.nombre = nombre;
            this.borrado = borrado;
            this.porcentaje = porcentaje;
        }

        
    }

}
