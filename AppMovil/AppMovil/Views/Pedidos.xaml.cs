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

            for (int i = 1; i < 20; i++)
            {
                var stack = new StackLayout()
                {
                    Orientation = StackOrientation.Horizontal
                };
               
                var labelNombre = new Label()
                {
                    FontSize = 16,
                    VerticalOptions = LayoutOptions.Center,
                    Text = "Coctél de camarón con xirumi y aplicacion de luz"
                };

                var stepper = new Stepper()
                {
                    Minimum = 1,
                    HorizontalOptions = LayoutOptions.EndAndExpand
                };

                var labelCantidad = new Label()
                {
                    Margin = new Thickness(10, 0, 10, 0),
                    FontSize = 18,
                    VerticalOptions = LayoutOptions.Center,
                    Text = "1"
                };

                stack.Children.Add(labelNombre);
                stack.Children.Add(stepper);
                stack.Children.Add(labelCantidad);

                productos.Add(new DetalleViewModel(stack, labelNombre, stepper, labelCantidad));

                ListItems.Children.Add(stack);
            }
            

            
        }
    }
}