using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoginApp.Models
{
    public class Producto
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }

        public int CategoriaId { get; set; }  // Campo para la relación

        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public string Detalle { get; set; }
        public string Imagen { get; set; }
        public decimal Precio { get; set; }
        public int Stock { get; set; }

        // Propiedad para la categoría
        [Ignore]
        public Categoria Categoria { get; set; }

    }

}
