using AppMovil.Models.Request;
using AppMovil.Models.Response;
using AppMovil.Tools;
using AppMovil.ViewModel;
using AppMovil.Views.Modals;
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
        public List<ProductoResponse> Productos = new List<ProductoResponse>();
        public List<DetalleViewModel> ViewProducts = new List<DetalleViewModel>();

        public Pedidos()
        {
            InitializeComponent();
        }

        public Pedidos(OrderResponse order, List<ProductoResponse> responses)
        {
            InitializeComponent();

            for (int i = 0; i < responses.Count; i++)
            {
                AddProduct(responses[i], order.DetallesPedidos[i].Cantidad);
            }
        }

        public Pedidos(OrderRequest order, List<ProductoResponse> responses)
        {
            InitializeComponent();

            for (int i = 0; i < responses.Count; i++)
            {
                AddProduct(responses[i], order.DetallesPedidos[i].Cantidad);
            }
        }

        public void AddProduct(ProductoResponse producto, int cantidad = 1)
        {
            ZeroProducts.IsVisible = false;
            ListItems.VerticalOptions = LayoutOptions.Start;
            ListItems.HorizontalOptions = LayoutOptions.FillAndExpand;

            Productos.Add(producto);

            var deleteItem = new SwipeItem()
            {
                Text = "Delete",
                BackgroundColor = Color.LightPink,
                IconImageSource = "Delete.png"
            };

            deleteItem.Invoked += (obj, e) =>
            {
                Eliminar_Clicked(producto.IdProducto);
            };

            List<SwipeItem> swipeItems = new List<SwipeItem>();
            swipeItems.Add(deleteItem);

            var stack = new StackLayout()
            {
                Orientation = StackOrientation.Horizontal
            };

            var labelNombre = new Label()
            {
                FontSize = 16,
                VerticalOptions = LayoutOptions.Center,
                Text = producto.Nombre,
                Margin = new Thickness(5,0,0,0)
            };

            var stepper = new Stepper()
            {
                Minimum = 1,
                HorizontalOptions = LayoutOptions.EndAndExpand,
                Maximum = 50,
                Value = cantidad 
            };

            var labelCantidad = new Label()
            {
                Margin = new Thickness(10, 0, 10, 0),
                FontSize = 18,
                VerticalOptions = LayoutOptions.Center,
                Text = "" + cantidad
            };

            stack.Children.Add(labelNombre);
            stack.Children.Add(stepper);
            stack.Children.Add(labelCantidad);

            var swipeView = new SwipeView()
            {
                LeftItems = new SwipeItems(swipeItems),
                Content = stack
            };   

            ViewProducts.Add(new DetalleViewModel(stack, labelNombre, stepper, labelCantidad));

            ListItems.Children.Add(swipeView);
        }

        private async void Eliminar_Clicked(int id)
        {
            bool eliminar = await DisplayAlert("Confirmar", "¿Estas seguro de que quieres eliminar el producto del pedido?", "Si", "No");

            if (eliminar)
            {
                foreach (var product in Productos)
                {
                    if (product.IdProducto == id)
                    {
                        Productos.Remove(product);

                        var listDetalle = new List<DetalleRequest>();

                        for (int i = 0; i < Productos.Count; i++)
                        {
                            listDetalle.Add(new DetalleRequest()
                            {
                                IdProducto = Productos[i].IdProducto,
                                Cantidad = Convert.ToInt32(ViewProducts[i].Cantidad.Text)
                            });
                        }

                        var dateTime = DateTime.Now;

                        var app = Application.Current as App;

                        var order = new OrderRequest()
                        {
                            IdEmpleado = app.IdEmpleado,
                            DetallesPedidos = listDetalle,
                            Anio = dateTime.Year,
                            Mes = dateTime.Month,
                            Dia = dateTime.Day,
                            Hora = dateTime.Hour,
                            Minuto = dateTime.Minute,
                            Segundo = dateTime.Second,
                            NumeroMesa = ENumeroMesa.Text
                        };

                        app.MainPage = new Pedidos(order, Productos);

                        break;
                    }
                }
            }
        }

        private async void BtnAgregar_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushModalAsync(new SelectProduct());
        }

        private async void BtnSubir_Clicked(object sender, EventArgs e)
        {
            var listDetalle = new List<DetalleRequest>();

            for (int i = 0; i < Productos.Count; i++)
            {
                listDetalle.Add(new DetalleRequest()
                {
                    IdProducto = Productos[i].IdProducto,
                    Cantidad = Convert.ToInt32(ViewProducts[i].Cantidad.Text)
                });
            }

            var dateTime = DateTime.Now;

            var app = Application.Current as App;

            var order = new OrderRequest()
            {
                IdEmpleado = app.IdEmpleado,
                DetallesPedidos = listDetalle,
                Anio = dateTime.Year,
                Mes = dateTime.Month,
                Dia = dateTime.Day,
                Hora = dateTime.Hour,
                Minuto = dateTime.Minute,
                Segundo = dateTime.Second,
                NumeroMesa = ENumeroMesa.Text
            };

            try
            {
                if (listDetalle.Count == 0) throw new Exception("No has agregado ningun producto");

                Validations.ValidarCrearPedido(order);

                var response = await Api.Post<OrderRequest, ServerResponse<OrderResponse>>("http://manuwolf-001-site1.atempurl.com/api/Pedido", order);

                if(response != null)
                {
                    if (response.Success)
                    {
                        
                        await DisplayAlert("Operación exitosa", "La orden ha sido creada exitosamente", "Ok");
                        app.MainPage = new PaginaPrincipal();
                    }
                    else
                    {
                        await DisplayAlert("Ha ocurrido un error", response.Error, "Ok");
                    }
                }
                else
                {
                    await DisplayAlert("Ha ocurrido un error", "Comprueba tu conexión a internet", "Ok");
                }
            }
            catch (NullReferenceException ex)
            {
                await DisplayAlert("Ha ocurrido un error", "Debe de rellenar el campo número mesa", "Ok");
            }
            catch(Exception ex)
            {
                await DisplayAlert("Ha ocurrido un error", ex.Message, "Ok");
            }
        }

        private void BtnSalir_Clicked(object sender, EventArgs e)
        {
            Application.Current.MainPage = new PaginaPrincipal();
        }
    }
}