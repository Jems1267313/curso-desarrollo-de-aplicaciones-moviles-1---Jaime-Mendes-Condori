using LoginApp.Models;
using LoginApp.Services;
using LoginApp.Controllers;
using System.Collections.Generic;

namespace LoginApp.Views
{
    public partial class CompraProductoPage : ContentPage
    {
        private readonly int _compraId;
        private readonly Database _database;

        public CompraProductoPage(int compraId, Database database)
        {
            InitializeComponent();
            _compraId = compraId;
            _database = database;

            LoadProductos();
            LoadCompraProductos();
        }

        private async void LoadProductos()
        {
            // Cargar productos para el picker
            var productos = await _database.GetAllProductosAsync();
            ProductoPicker.ItemsSource = productos; // Assuming you have a ToString override for Producto
        }

        private async void LoadCompraProductos()
        {
            // Cargar productos de la compra
            var compraProductos = await _database.GetCompraProductosAsync(_compraId);
            CompraProductoListView.ItemsSource = compraProductos;
        }

        private async void OnAddProductoClicked(object sender, EventArgs e)
        {
            var compraProducto = new CompraProducto
            {
                CompraId = _compraId,
                ProductoId = int.Parse(ProductoPicker.SelectedItem.ToString()), // Assuming this is an ID
                Cantidad = int.Parse(CantidadEntry.Text),
                PrecioUnitario = decimal.Parse(PrecioUnitarioEntry.Text)
            };

            await _database.SaveCompraProductoAsync(compraProducto);
            LoadCompraProductos();
        }
    }
}
