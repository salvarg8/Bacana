using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bacana.Negocio.Entidades
{
    class PasosTorta
    {
        public int id { get; set; }
        public int posicion { get; set; }
        public Torta torta { get; set; }
        public string Paso { get; set; }

        public PasosTorta(int posicion, string paso)
        {
            this.posicion = posicion;
            Paso = paso;
        }

        public PasosTorta(int id, int posicion, Torta torta, string paso)
        {
            this.id = id;
            this.posicion = posicion;
            this.torta = torta;
            Paso = paso;
        }


        public PasosTorta()
        {
        }
    }

}
