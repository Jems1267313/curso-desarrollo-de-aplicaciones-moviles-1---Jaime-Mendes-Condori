using LoginApp.Controllers;
using LoginApp.Models;
using System.Collections.Generic;
using System.Threading.Tasks;
using LoginApp.Services;

namespace LoginApp.Views
{
    public partial class CompraListPage : ContentPage
    {
        private Database _database; // Agregar esta l�nea
        private CompraController _compraController;
        private ProductoController _productoController;

        public CompraListPage()
        {
            InitializeComponent();
            _database = new Database(App.DatabasePath); // Inicializar la base de datos
            _compraController = new CompraController(_database); // Pasar _database al controlador
            _productoController = new ProductoController(App.DatabasePath); // Crear la instancia de ProductoController
            LoadCompras();
            LoadProductos(); // Aseg�rate de llamar a este m�todo tambi�n
        }

        private async void LoadCompras()
        {
            List<Compra> compras = await _compraController.GetAllCompras();
            ComprasListView.ItemsSource = compras;
        }
        private async void LoadProductos()
        {
            List<Producto> productos = await _productoController.GetAllProductosConCategoria();
            ProductosListView.ItemsSource = productos;
        }
        private async void OnAddCompraClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new CompraEditPage(_database)); // Usar _database aqu�
        }

        private async void OnEditCompraClicked(object sender, EventArgs e)
        {
            var menuItem = (MenuItem)sender;
            var compra = (Compra)menuItem.CommandParameter; // Obtiene el objeto Compra
            await Navigation.PushAsync(new CompraEditPage(_database, compra)); // Usar _database aqu�
        }

        private async void OnDeleteCompraClicked(object sender, EventArgs e)
        {
            var compra = (Compra)((MenuItem)sender).CommandParameter;
            bool confirm = await DisplayAlert("Eliminar Compra", $"�Est�s seguro de eliminar la compra de tipo {compra.TipoEntrega}?", "S�", "No");
            if (confirm)
            {
                await _compraController.DeleteCompra(compra.Id); // Implementa el m�todo DeleteCompra en el controlador
                LoadCompras(); // Recargar la lista de compras
            }
        }

        private async void OnCompraTapped(object sender, ItemTappedEventArgs e)
        {
            if (e.Item != null)
            {
                var compra = (Compra)e.Item;
                await Navigation.PushAsync(new CompraEditPage(_database, compra)); // Usar _database aqu�
            }
        }
        private async void OnProductTapped(object sender, ItemTappedEventArgs e)
        {
            if (e.Item != null)
            {
                var producto = (Producto)e.Item;
                // Aqu� deber�as navegar a la p�gina de edici�n del producto (ajusta el nombre de la clase seg�n sea necesario)
                await Navigation.PushAsync(new ProductoEditPage(producto));
            }
        }
    }
}
