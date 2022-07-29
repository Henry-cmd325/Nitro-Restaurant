using AppMovil.Models.Request;
using AppMovil.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AppMovil.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Pedidos : ContentPage
    {
        public List<DetalleViewModel> productos = new List<DetalleViewModel>();
        public Pedidos()
        {
            InitializeComponent();

            for (int i = 0; i < 20; i++)
            {
                productos.Add(new DetalleViewModel()
                {
                    NombreProducto = "Producto 1",
                    Cantidad = 1
                });
            }

            Lista.ItemsSource = productos;
        }
    }
}