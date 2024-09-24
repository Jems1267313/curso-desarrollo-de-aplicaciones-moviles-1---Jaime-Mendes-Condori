using LoginApp.Models;
using LoginApp.Controllers;
using LoginApp.Services;

namespace LoginApp.Views
{
    public partial class CompraEditPage : ContentPage
    {
        private Compra _compra;
        private Database _database; // Agregar una variable para la base de datos
        private CompraController _compraController; // Variable para el controller

        public CompraEditPage(Database database, Compra compra = null)
        {
            InitializeComponent();
            _database = database; // Inicializar la base de datos
            _compra = compra ?? new Compra();
            BindingContext = _compra;

            // Llenar los campos si la compra ya existe
            if (_compra.Id != 0)
            {
                TipoEntregaEntry.Text = _compra.TipoEntrega;
                FechaCompraPicker.Date = _compra.FechaCompra;
                PrecioTotalEntry.Text = _compra.PrecioTotal.ToString();
            }

            // Inicializar el controller con la base de datos
            _compraController = new CompraController(_database);
        }

        private async void OnSaveClicked(object sender, EventArgs e)
        {
            _compra.TipoEntrega = TipoEntregaEntry.Text;
            _compra.FechaCompra = FechaCompraPicker.Date;
            _compra.PrecioTotal = decimal.Parse(PrecioTotalEntry.Text);

            // Usar el controller para agregar o actualizar la compra
            if (_compra.Id == 0)
                await _compraController.AddCompra(_compra);
            else
                await _compraController.UpdateCompra(_compra);

            await Navigation.PopAsync();
        }

        private async void OnManageProductsClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new CompraProductoPage(_compra.Id, _database));
        }
    }
}
