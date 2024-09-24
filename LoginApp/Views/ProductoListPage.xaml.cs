using System.IO; //incluir esta línea para usar Path
using LoginApp.Controllers;
using LoginApp.Models;

namespace LoginApp.Views;

public partial class ProductoListPage : ContentPage
{
    private ProductoController _controller;

    public ProductoListPage()
    {
        InitializeComponent();

        // Obtén la ruta de la base de datos
        var dbPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "productos.db3");

        // Pasa la ruta de la base de datos al constructor
        _controller = new ProductoController(dbPath);

        LoadProductos();
    }

    private async void LoadProductos()
    {
        ProductosListView.ItemsSource = await _controller.GetAllProductos();
    }

    private async void OnProductTapped(object sender, ItemTappedEventArgs e)
    {
        var producto = (Producto)e.Item;
        await Navigation.PushAsync(new ProductoEditPage(producto));
    }

    private async void OnAddProductClicked(object sender, EventArgs e)
    {
        // Redirige a la vista para agregar un nuevo producto
        await Navigation.PushAsync(new ProductoEditPage());
    }
}
