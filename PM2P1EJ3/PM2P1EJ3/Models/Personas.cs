using System;
using System.Collections.Generic;
using System.Text;
using SQLite;

namespace PM2P1EJ3.Models
{
    public class Personas
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }

        [MaxLength(100)]
        public String Nombre { get; set; }

        [MaxLength(100)]
        public String Apellido { get; set; }

        public Int32 Edad { get; set; }

        [MaxLength(100)]
        public String Correo { get; set; }

        [MaxLength(100)]
        public String Direccion { get; set; }
    }
}
