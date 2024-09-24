namespace LoginApp.Views
{
    public partial class MainMenuPage : ContentPage
    {
        public MainMenuPage()
        {
            InitializeComponent();
        }

        private async void OnProductosClicked(object sender, EventArgs e)
        {
            // Navegar a la página de productos
            await Navigation.PushAsync(new ProductoListPage());
        }

        private async void OnCategoriasClicked(object sender, EventArgs e)
        {
            // Navegar a la página de categorías
            await Navigation.PushAsync(new CategoriaListPage());
        }

        private async void OnComprasClicked(object sender, EventArgs e)
        {
            // Navegar a la página de compras
            await Navigation.PushAsync(new CompraListPage());
        }

        private async void OnEditarProductosClicked(object sender, EventArgs e)
        {
            // Navegar a la página de edición de productos
            await Navigation.PushAsync(new ProductoEditPage());
        }

        private async void OnEditarCategoriasClicked(object sender, EventArgs e)
        {
            // Navegar a la página de edición de categorías
            await Navigation.PushAsync(new CategoriaEditPage());
        }

        private async void OnTiendasClicked(object sender, EventArgs e)
        {
            // Navegar a la página de tiendas
            await Navigation.PushAsync(new TiendaListPage());
        }

    }
}
