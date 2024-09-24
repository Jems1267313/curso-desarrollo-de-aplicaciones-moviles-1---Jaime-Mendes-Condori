using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace LoginApp.Services
{
    public class PasswordHasher : IPasswordHasher

    {

        private const int SaltSize = 16; // Tamaño del salt en bytes

        private const int HashSize = 20; // Tamaño del hash en bytes

        private const int Iterations = 10000; // Número de iteraciones



        public string HashPassword(string password)

        {

            // Generar un salt aleatorio

            using var rng = new RNGCryptoServiceProvider();

            var salt = new byte[SaltSize];

            rng.GetBytes(salt);



            // Crear el hash

            var pbkdf2 = new Rfc2898DeriveBytes(password, salt, Iterations);

            var hash = pbkdf2.GetBytes(HashSize);



            // Combinar salt y hash en un solo string

            var saltedHash = new byte[SaltSize + HashSize];

            Array.Copy(salt, 0, saltedHash, 0, SaltSize);

            Array.Copy(hash, 0, saltedHash, SaltSize, HashSize);



            // Convertir a Base64 para almacenamiento

            return Convert.ToBase64String(saltedHash);

        }



        public bool VerifyPassword(string password, string hashedPassword)

        {

            // Convertir el string Base64 a bytes

            var saltedHash = Convert.FromBase64String(hashedPassword);



            // Extraer el salt y el hash

            var salt = new byte[SaltSize];

            var hash = new byte[HashSize];

            Array.Copy(saltedHash, 0, salt, 0, SaltSize);

            Array.Copy(saltedHash, SaltSize, hash, 0, HashSize);



            // Crear el hash para la contraseña proporcionada

            var pbkdf2 = new Rfc2898DeriveBytes(password, salt, Iterations);

            var newHash = pbkdf2.GetBytes(HashSize);



            // Comparar el hash generado con el hash almacenado

            for (var i = 0; i < HashSize; i++)

            {

                if (hash[i] != newHash[i])

                {

                    return false;

                }

            }

            return true;

        }

    }
}
