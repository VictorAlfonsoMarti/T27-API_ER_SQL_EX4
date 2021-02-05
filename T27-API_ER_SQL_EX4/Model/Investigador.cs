using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace T27_API_ER_SQL_EX4.Model
{
    public class Investigador
    {
        // ATRIBUTOS, GETTERS Y SETTERS
        public string Dni { get; set; }
        public string NomApels { get; set; }
        public int Facultad { get; set; }
        public Facultad Facultades { get; set; }
        public ICollection<Reserva> Reservas { get; set; }
        
        // CONSTRUCTOR
        public Investigador()
        {
            Reservas = new HashSet<Reserva>();
        }

    }
}
