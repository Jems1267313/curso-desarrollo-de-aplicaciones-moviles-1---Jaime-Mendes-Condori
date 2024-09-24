using LoginApp.Controllers;
using LoginApp.Models;
using LoginApp.Services;

namespace LoginApp.Views
{
    public partial class TiendaEditPage : ContentPage
    {
        private TiendaController _tiendaController;
        private Tienda _tienda;

        public TiendaEditPage(Tienda tienda = null)
        {
            InitializeComponent();
            _tiendaController = new TiendaController(new Database(App.DatabasePath));

            if (tienda != null)
            {
                _tienda = tienda;
                NombreTiendaEntry.Text = _tienda.NombreTienda;
                UbicacionEntry.Text = _tienda.Ubicacion;
                Ubicacion1Entry.Text = _tienda.Ubicacion1;
                Ubicacion2Entry.Text = _tienda.Ubicacion2;
                TituloEntry.Text = _tienda.Titulo;
            }
        }

        private async void OnSaveClicked(object sender, EventArgs e)
        {
            if (_tienda == null)
            {
                // Crear una nueva tienda
                _tienda = new Tienda
                {
                    NombreTienda = NombreTiendaEntry.Text,
                    Ubicacion = UbicacionEntry.Text,
                    Ubicacion1 = Ubicacion1Entry.Text,
                    Ubicacion2 = Ubicacion2Entry.Text,
                    Titulo = TituloEntry.Text
                };
                await _tiendaController.AddTienda(_tienda);
            }
            else
            {
                // Actualizar la tienda existente
                _tienda.NombreTienda = NombreTiendaEntry.Text;
                _tienda.Ubicacion = UbicacionEntry.Text;
                _tienda.Ubicacion1 = Ubicacion1Entry.Text;
                _tienda.Ubicacion2 = Ubicacion2Entry.Text;
                _tienda.Titulo = TituloEntry.Text;
                await _tiendaController.UpdateTienda(_tienda);
            }

            await Navigation.PopAsync(); // Regresar a la lista de tiendas
        }
    }
}
