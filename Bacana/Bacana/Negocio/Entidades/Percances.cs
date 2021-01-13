using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bacana.Negocio.Entidades
{
    public class Percances
    {
        // producto,fecha,costo,descripcion
        public int Id { get; set; }
        public string Producto { get; set; }
        public DateTime Fecha { get; set; }
        public float Costo { get; set; }
        public string Descripcion { get; set; }

        public Percances(int id, string producto, DateTime fecha, float costo, string descrip )
        {
            Id = id;
            Producto = producto;
            Fecha = fecha;
            Costo = costo;
            Descripcion = descrip;
        }
        public Percances() { }

    }

}
