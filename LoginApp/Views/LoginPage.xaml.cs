using LoginApp.Controllers;

namespace LoginApp.Views;

public partial class LoginPage : ContentPage

{

    private readonly LoginController _loginController;



    public LoginPage(LoginController loginController)

    {

        InitializeComponent();

        _loginController = loginController;

    }



    private async void OnLoginButtonClicked(object sender, EventArgs e)

    {

        var nombreUsuario = NombreUsuarioEntry.Text;

        var contrasena = ContrasenaEntry.Text;



        // Validación de campos vacíos

        if (string.IsNullOrWhiteSpace(nombreUsuario) || string.IsNullOrWhiteSpace(contrasena))

        {

            MensajeLabel.Text = "Por favor, complete todos los campos.";

            MensajeLabel.IsVisible = true;

            return;

        }



        // Intentar autenticación

        if (await _loginController.Autenticar(nombreUsuario, contrasena))

        {

            await DisplayAlert("Éxito", "¡Inicio de sesión exitoso!", "OK");

            // Aquí puedes redirigir a otra página si es necesario

            // Redirigir a la página principal u otra página relevante

            await Navigation.PushAsync(new MainMenuPage()); // Asegúrate de tener una MainPage

        }

        else

        {

            MensajeLabel.Text = "Nombre de usuario o contraseña incorrectos.";

            MensajeLabel.IsVisible = true;

        }

    }

    private async void OnCreateAccountButtonClicked(object sender, EventArgs e)

    {

        // Navegar a la página de registro

        await Navigation.PushAsync(new RegisterPage(_loginController));

    }
}