using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoginApp.Models
{
    public class Tienda
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public string NombreTienda { get; set; }
        public string Ubicacion { get; set; }
        public string Ubicacion1 { get; set; }
        public string Ubicacion2 { get; set; }
        public string Titulo { get; set; }
    }
}

