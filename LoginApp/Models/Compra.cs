using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoginApp.Models
{
    public class Compra
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public string TipoEntrega { get; set; }
        public DateTime FechaCompra { get; set; }
        public decimal PrecioTotal { get; set; }
    }
}
