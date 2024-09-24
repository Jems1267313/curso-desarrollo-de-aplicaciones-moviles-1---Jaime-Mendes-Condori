using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LoginApp.Models;
using LoginApp.Services;

namespace LoginApp.Controllers
{
    public class ProductoController
    {
        private readonly ProductoService _productoService;
        private readonly CategoriaService _categoriaService;

        // Modificar el constructor para aceptar un argumento dbPath
        public ProductoController(string dbPath)
        {
            _productoService = new ProductoService(dbPath);
            _categoriaService = new CategoriaService(dbPath);
        }

        public Task<List<Producto>> GetAllProductos() => _productoService.GetAll();

        public async Task<List<Producto>> GetAllProductosConCategoria()
        {
            var productos = await _productoService.GetAll();
            var categorias = await _categoriaService.GetAll();

            foreach (var producto in productos)
            {
                producto.Categoria = categorias.FirstOrDefault(c => c.Id == producto.CategoriaId);
            }

            return productos;
        }

        public Task AddProducto(Producto producto) => _productoService.Add(producto);
        public Task UpdateProducto(Producto producto) => _productoService.Update(producto);
        public Task DeleteProducto(int id) => _productoService.Delete(id);
    }
}
