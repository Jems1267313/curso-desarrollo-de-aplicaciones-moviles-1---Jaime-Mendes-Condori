using LoginApp.Controllers;
using LoginApp.Models;
using System.Collections.Generic;
using System.Threading.Tasks;
using LoginApp.Services;

namespace LoginApp.Views
{
    public partial class TiendaListPage : ContentPage
    {
        private TiendaController _tiendaController;

        public TiendaListPage()
        {
            InitializeComponent();
            _tiendaController = new TiendaController(new Database(App.DatabasePath));
            LoadTiendas();
        }

        private async void LoadTiendas()
        {
            List<Tienda> tiendas = await _tiendaController.GetAllTiendas();
            TiendasListView.ItemsSource = tiendas;
        }
        private async void OnTiendaTapped(object sender, ItemTappedEventArgs e)
        {
            if (e.Item != null && e.Item is Tienda tienda)
            {
                await Navigation.PushAsync(new TiendaEditPage(tienda)); // Navegar a la página de edición
            }
        }

        private async void OnAddTiendaClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new TiendaEditPage());
        }

        private async void OnEditClicked(object sender, EventArgs e)
        {
            var tienda = (Tienda)((MenuItem)sender).CommandParameter;
            await Navigation.PushAsync(new TiendaEditPage(tienda));
        }

        private async void OnDeleteClicked(object sender, EventArgs e)
        {
            var tienda = (Tienda)((MenuItem)sender).CommandParameter;
            bool confirm = await DisplayAlert("Eliminar Tienda", $"¿Estás seguro de eliminar {tienda.NombreTienda}?", "Sí", "No");
            if (confirm)
            {
                await _tiendaController.DeleteTienda(tienda.Id);
                LoadTiendas(); // Recargar la lista de tiendas
            }
        }
    }
}
