using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LoginApp.Models;

namespace LoginApp.Services
{
    public class Database
    {
        private SQLiteAsyncConnection _database;

        public Database(string dbPath)
        {
            _database = new SQLiteAsyncConnection(dbPath);
            // Crear todas las tablas al inicio
            _database.CreateTableAsync<Usuario>().Wait();
            _database.CreateTableAsync<Producto>().Wait();
            _database.CreateTableAsync<Categoria>().Wait();
            _database.CreateTableAsync<Compra>().Wait();
            _database.CreateTableAsync<CompraProducto>().Wait();
            _database.CreateTableAsync<Tienda>().Wait();

        }

        public Task<Usuario> ObtenerUsuarioAsync(string nombreUsuario, string contrasena)
        {
            return _database.Table<Usuario>()
                  .FirstOrDefaultAsync(u => u.NombreUsuario == nombreUsuario && u.Contrasena == contrasena);
        }

        public Task<int> GuardarUsuarioAsync(Usuario usuario)
        {
            return _database.InsertAsync(usuario);
        }

        public Task<List<Usuario>> ObtenerUsuariosAsync()
        {
            return _database.Table<Usuario>().ToListAsync();
        }

        // Métodos para manejar productos
        public Task<List<Producto>> GetAllProductosAsync() => _database.Table<Producto>().ToListAsync();
        public Task<int> SaveProductoAsync(Producto producto) => _database.InsertAsync(producto);
        public Task<int> UpdateProductoAsync(Producto producto) => _database.UpdateAsync(producto);
        public Task<int> DeleteProductoAsync(int id) => _database.DeleteAsync<Producto>(id);

        // Métodos para categorías
        public Task<List<Categoria>> GetAllCategoriasAsync() => _database.Table<Categoria>().ToListAsync();
        public Task<int> SaveCategoriaAsync(Categoria categoria) => _database.InsertAsync(categoria);
        public Task<int> UpdateCategoriaAsync(Categoria categoria) => _database.UpdateAsync(categoria);
        public Task<int> DeleteCategoriaAsync(int id) => _database.DeleteAsync<Categoria>(id);

        // Métodos para compras
        public Task<List<Compra>> GetAllComprasAsync() => _database.Table<Compra>().ToListAsync();
        public Task<Compra> GetCompraAsync(int id) => _database.Table<Compra>().FirstOrDefaultAsync(c => c.Id == id);
        public Task<int> SaveCompraAsync(Compra compra) => compra.Id != 0 ? _database.UpdateAsync(compra) : _database.InsertAsync(compra);
        public Task<int> DeleteCompraAsync(int id) => _database.DeleteAsync<Compra>(id);


        // Métodos para productos en compras
        public Task<List<CompraProducto>> GetCompraProductosAsync(int compraId)
            => _database.Table<CompraProducto>().Where(cp => cp.CompraId == compraId).ToListAsync();

        public Task<int> SaveCompraProductoAsync(CompraProducto compraProducto)
            => _database.InsertAsync(compraProducto);

        public Task<int> DeleteCompraProductoAsync(int compraId, int productoId)
            => _database.DeleteAsync<CompraProducto>(new CompraProducto { CompraId = compraId, ProductoId = productoId });

        // Métodos para tiendas
        public Task<List<Tienda>> GetAllTiendasAsync() => _database.Table<Tienda>().ToListAsync();
        public Task<Tienda> GetTiendaAsync(int id) => _database.Table<Tienda>().FirstOrDefaultAsync(t => t.Id == id);
        public Task<int> SaveTiendaAsync(Tienda tienda) => tienda.Id != 0 ? _database.UpdateAsync(tienda) : _database.InsertAsync(tienda);
        public Task<int> DeleteTiendaAsync(int id) => _database.DeleteAsync<Tienda>(id);




    }

}
