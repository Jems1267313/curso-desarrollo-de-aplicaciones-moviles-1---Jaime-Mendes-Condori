using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LoginApp.Services;

namespace LoginApp.Controllers
{
    public class LoginController
    {
        private readonly IUsuarioService _usuarioService;
        public LoginController(IUsuarioService usuarioService)
        {
            _usuarioService = usuarioService;
        }
        public async Task<bool> Autenticar(string nombreUsuario, string contrasena)

        {

            return await _usuarioService.AutenticarUsuarioAsync(nombreUsuario, contrasena);

        }



        public async Task<bool> Registrar(string nombreUsuario, string contrasena)

        {

            return await _usuarioService.RegistrarUsuarioAsync(nombreUsuario, contrasena);

        }

    }
}
