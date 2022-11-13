using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace PM2_P2Tarea2_2.Models
{
    public class Firmas
    {
        [PrimaryKey, AutoIncrement]
        public int id { get; set; }
        public String nombre { get; set; }

        public String descripcion { get; set; }

        public Byte[] firmaa { get; set; }
    }
}
