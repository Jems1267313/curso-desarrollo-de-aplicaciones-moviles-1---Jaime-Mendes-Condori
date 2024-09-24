using LoginApp.Services;
using LoginApp.Models;

namespace LoginApp.Controllers
{
    public class CompraController
    {
        private readonly Database _database;

        public CompraController(Database database)
        {
            _database = database;
        }

        public Task<int> AddCompra(Compra compra) => _database.SaveCompraAsync(compra);
        public Task<int> UpdateCompra(Compra compra) => _database.SaveCompraAsync(compra);
        public Task<List<Compra>> GetAllCompras() => _database.GetAllComprasAsync();

        public async Task DeleteCompra(int id)
        {
            await _database.DeleteCompraAsync(id);
        }
    }
}
