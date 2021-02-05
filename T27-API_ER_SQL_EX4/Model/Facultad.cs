using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace T27_API_ER_SQL_EX4.Model
{
    public class Facultad
    {
        //ATRIBUTOS, GETTERS Y SETTERS
        public int Codigo { get; set; }
        public string Nombre { get; set; }

        public ICollection<Equipo> Equipos { get; set; }
        public ICollection<Investigador> Investigadores { get; set; }

        // CONSTRUCTOR
        public Facultad()
        {
            Equipos = new HashSet<Equipo>();
            Investigadores = new HashSet<Investigador>();
        }
    }
}
