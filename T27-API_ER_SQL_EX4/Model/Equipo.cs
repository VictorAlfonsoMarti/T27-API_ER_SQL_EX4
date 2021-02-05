using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace T27_API_ER_SQL_EX4.Model
{
    public class Equipo
    {
        // ATRIBUTOS, GETTERS Y SETTERS
        public string NumSerie { get; set; }
        public string Nombre { get; set; }
        public int Facultad { get; set; }

        public ICollection<Reserva> Reservas { get; set; }
        public Facultad Facultades { get; set; }

        // CONSTRUCTORES
        public Equipo()
        {
            Reservas = new HashSet<Reserva>();
        }
    }
}
