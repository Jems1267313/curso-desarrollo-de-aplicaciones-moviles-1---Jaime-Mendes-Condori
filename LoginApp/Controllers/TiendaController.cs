using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LoginApp.Models;
using LoginApp.Services;

namespace LoginApp.Controllers
{
    public class TiendaController
    {
        private readonly Database _database;

        public TiendaController(Database database)
        {
            _database = database;
        }

        public Task<int> AddTienda(Tienda tienda) => _database.SaveTiendaAsync(tienda);
        public Task<int> UpdateTienda(Tienda tienda) => _database.SaveTiendaAsync(tienda);
        public Task<List<Tienda>> GetAllTiendas() => _database.GetAllTiendasAsync();
        public Task<int> DeleteTienda(int id) => _database.DeleteTiendaAsync(id);
        public Task<Tienda> GetTienda(int id) => _database.GetTiendaAsync(id);
    }
}

