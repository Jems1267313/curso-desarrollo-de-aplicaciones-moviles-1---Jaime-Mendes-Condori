using LoginApp.Models;
using LoginApp.Controllers;

namespace LoginApp.Views
{
    public partial class CategoriaEditPage : ContentPage
    {
        private Categoria _categoria;
        private CategoriaController _categoriaController;

        public CategoriaEditPage(Categoria categoria = null)
        {
            InitializeComponent();
            _categoria = categoria ?? new Categoria();
            _categoriaController = new CategoriaController();

            // Si la categoría ya existe, cargamos sus datos
            if (_categoria.Id != 0)
            {
                NombreEntry.Text = _categoria.Nombre;
            }
        }

        private async void OnSaveClicked(object sender, EventArgs e)
        {
            _categoria.Nombre = NombreEntry.Text;

            if (string.IsNullOrWhiteSpace(_categoria.Nombre))
            {
                await DisplayAlert("Error", "El nombre de la categoría no puede estar vacío.", "OK");
                return;
            }

            if (_categoria.Id == 0)
                await _categoriaController.AddCategoria(_categoria);
            else
                await _categoriaController.UpdateCategoria(_categoria);

            await Navigation.PopAsync();
        }
    }
}
