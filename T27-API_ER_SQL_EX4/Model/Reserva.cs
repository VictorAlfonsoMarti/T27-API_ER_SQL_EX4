using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace T27_API_ER_SQL_EX4.Model
{
    public class Reserva
    {
        // ATRIBUTOS, GETTERS Y SETTERS
        public string Dni { get; set; }
        public string NumSerie { get; set; }
        public DateTime? Comienzo { get; set; }
        public DateTime? Fin { get; set; }

        public Investigador Investigadores { get; set; }
        public Equipo Equipos { get; set; }
    }
}
