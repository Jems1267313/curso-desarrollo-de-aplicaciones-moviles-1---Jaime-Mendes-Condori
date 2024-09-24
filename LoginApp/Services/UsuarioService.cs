using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LoginApp.Repositories;
using LoginApp.Models;

namespace LoginApp.Services
{
    public class UsuarioService : IUsuarioService

    {

        private readonly IUsuarioRepository _usuarioRepository;

        private readonly IPasswordHasher _passwordHasher;



        public UsuarioService(IUsuarioRepository usuarioRepository, IPasswordHasher passwordHasher)

        {

            _usuarioRepository = usuarioRepository;

            _passwordHasher = passwordHasher;

        }



        public async Task<Usuario> GetUsuarioAsync(string nombreUsuario)

        {

            return await _usuarioRepository.GetUsuarioAsync(nombreUsuario);

        }



        public async Task<bool> RegistrarUsuarioAsync(string nombreUsuario, string contrasena)

        {

            if (await _usuarioRepository.GetUsuarioAsync(nombreUsuario) != null)

            {

                return false; // Usuario ya existe

            }



            var hashedPassword = _passwordHasher.HashPassword(contrasena);

            var usuario = new Usuario { NombreUsuario = nombreUsuario, Contrasena = hashedPassword };

            return await _usuarioRepository.AddUsuarioAsync(usuario) > 0;

        }



        public async Task<bool> AutenticarUsuarioAsync(string nombreUsuario, string contrasena)

        {

            var usuario = await _usuarioRepository.GetUsuarioAsync(nombreUsuario);

            return usuario != null && _passwordHasher.VerifyPassword(contrasena, usuario.Contrasena);

        }



        Task<Usuario> IUsuarioService.GetUsuarioAsync(string nombreUsuario)

        {

            throw new NotImplementedException();

        }

    }
}
