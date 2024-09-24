using LoginApp.Models;
using LoginApp.Controllers;

namespace LoginApp.Views;

public partial class ProductoEditPage : ContentPage
{
    private Producto _producto;
    private CategoriaController _categoriaController;
    private ProductoController _productoController; // Agrega una referencia al ProductoController

    public ProductoEditPage(Producto producto = null)
    {
        InitializeComponent();
        _producto = producto ?? new Producto();
        _categoriaController = new CategoriaController();

        // Asumiendo que necesitas la ruta a la base de datos
        var dbPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "productos.db3");
        _productoController = new ProductoController(dbPath); // Pasa el dbPath al constructor

        LoadCategorias();
        if (_producto.Id != 0)
        {
            NombreEntry.Text = _producto.Nombre;
            PrecioEntry.Text = _producto.Precio.ToString();
            CategoriaPicker.SelectedIndex = _producto.CategoriaId - 1;
        }
    }

    private async void LoadCategorias()
    {
        var categorias = await _categoriaController.GetAllCategorias();
        CategoriaPicker.ItemsSource = categorias;
        CategoriaPicker.ItemDisplayBinding = new Binding("Nombre");
    }

    private async void OnSaveClicked(object sender, EventArgs e)
    {
        _producto.Nombre = NombreEntry.Text;
        _producto.Precio = decimal.Parse(PrecioEntry.Text);
        _producto.CategoriaId = ((Categoria)CategoriaPicker.SelectedItem).Id;

        // Usa la instancia de ProductoController creada en el constructor
        if (_producto.Id == 0)
            await _productoController.AddProducto(_producto);
        else
            await _productoController.UpdateProducto(_producto);

        await Navigation.PopAsync();
    }
}
