using SQLite;
using LoginApp.Controllers;
using LoginApp.Views;
using LoginApp.Repositories;
using LoginApp.Services;

namespace LoginApp
{

  public partial class App : Application

    {

        public App()

        {

            InitializeComponent();
            // Configurar la inyección de dependencias y asignar la página principal

            var services = ConfigureServices();

            var loginController = services.GetRequiredService<LoginController>();

            //Crear una NavigationPage con la página de inicio de sesión

            //MainPage = new LoginPage(loginController);

            MainPage = new NavigationPage(new LoginPage(loginController));

        }

        public static string DatabasePath => Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "productos.db3");

        private IServiceProvider ConfigureServices()

        {

            var services = new ServiceCollection();



            // Configurar SQLite

            services.AddSingleton<SQLiteConnection>(provider =>

              new SQLiteConnection(Path.Combine(FileSystem.AppDataDirectory, "mi_app.db3")));



            // Registrar repositorios

            services.AddTransient<IUsuarioRepository, UsuarioRepository>();



            // Registrar servicios

            services.AddTransient<IPasswordHasher, PasswordHasher>();

            services.AddTransient<IUsuarioService, UsuarioService>();



            // Registrar controladores

            services.AddTransient<LoginController>();



            return services.BuildServiceProvider();

        }

    }

}

