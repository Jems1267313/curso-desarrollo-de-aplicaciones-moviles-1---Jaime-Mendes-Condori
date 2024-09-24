using LoginApp.Controllers;

namespace LoginApp.Views;

public partial class RegisterPage : ContentPage

{

    private readonly LoginController _loginController;



    public RegisterPage(LoginController loginController)

    {

        InitializeComponent();

        _loginController = loginController;

    }



    private async void OnRegisterButtonClicked(object sender, EventArgs e)

    {

        var nombreUsuario = NombreUsuarioEntry.Text;

        var contrasena = ContrasenaEntry.Text;



        if (string.IsNullOrWhiteSpace(nombreUsuario) || string.IsNullOrWhiteSpace(contrasena))

        {

            MensajeLabel.Text = "Todos los campos son obligatorios.";

            MensajeLabel.IsVisible = true;

            return;

        }



        var resultado = await _loginController.Registrar(nombreUsuario, contrasena);



        if (resultado)

        {

            await DisplayAlert("Éxito", "¡Registro exitoso!", "OK");

            // Navegar a la página de inicio de sesión o alguna otra página

            await Navigation.PushAsync(new LoginPage(_loginController));

        }

        else

        {

            MensajeLabel.Text = "El nombre de usuario ya existe.";

            MensajeLabel.IsVisible = true;

        }

    }

}