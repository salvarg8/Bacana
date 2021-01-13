using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bacana
{
    public class Cliente
    {
        public int Id { get; set; }
        public String Nombre { get; set; }
        public String Apellido { get; set; }
        public double Telefono { get; set; }
        public String Domicilio  { get; set; }
        
        public Cliente() { }

        public Cliente(int id, string nombre, string apellido, double telefono, string domicilio)
        {
            Id = id;
            Nombre = nombre;
            Apellido = apellido;
            Telefono = telefono;
            Domicilio = domicilio;
        }
        
    }
}
