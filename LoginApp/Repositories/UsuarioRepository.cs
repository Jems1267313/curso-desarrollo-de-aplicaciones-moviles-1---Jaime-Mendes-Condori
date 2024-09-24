using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LoginApp.Models;

namespace LoginApp.Repositories
{
    public class UsuarioRepository : IUsuarioRepository

    {

        private readonly SQLiteConnection _connection;



        public UsuarioRepository(SQLiteConnection connection)

        {

            _connection = connection;

            _connection.CreateTable<Usuario>(); // Asegurarse de que la tabla existe

        }



        public Task<Usuario> GetUsuarioAsync(string nombreUsuario)

        {

            return Task.FromResult(_connection.Table<Usuario>().FirstOrDefault(u => u.NombreUsuario == nombreUsuario));

        }



        public Task<IEnumerable<Usuario>> GetAllUsuariosAsync()

        {

            return Task.FromResult(_connection.Table<Usuario>().AsEnumerable());

        }



        public Task<int> AddUsuarioAsync(Usuario usuario)

        {

            return Task.FromResult(_connection.Insert(usuario));

        }



        public Task<int> UpdateUsuarioAsync(Usuario usuario)

        {

            return Task.FromResult(_connection.Update(usuario));

        }



        public Task<int> DeleteUsuarioAsync(string nombreUsuario)

        {

            var usuario = _connection.Table<Usuario>().FirstOrDefault(u => u.NombreUsuario == nombreUsuario);

            if (usuario != null)

            {

                return Task.FromResult(_connection.Delete(usuario));

            }

            return Task.FromResult(0);

        }

    }
}
