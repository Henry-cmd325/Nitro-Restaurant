using AppMovil.Models.Response;
using AppMovil.Services;
using AppMovil.Tools;
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
    public partial class PaginaPrincipal : ContentPage
    {
        private readonly Api Api = DependencyService.Get<Api>();

        private List<OrderResponse> orders = new List<OrderResponse>();
        public PaginaPrincipal()
        {
            InitializeComponent();
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();

            try
            {
                var response = await Api.Get<ServerResponse<List<OrderResponse>>>("http://manuwolf-001-site1.atempurl.com/api/Pedido");

                if (response != null)
                {
                    if (response.Success)
                    {
                        App app = Application.Current as App;

                        foreach (var element in response.Data)
                        {
                            if (element.IdEmpleado == app.IdEmpleado && (element.Terminado == null || element.Terminado == false))
                            {
                                orders.Add(element);

                                var stack = new StackLayout()
                                {
                                    Orientation = StackOrientation.Horizontal,
                                    BackgroundColor = Color.FromHex("#e4e6eb"),
                                    HeightRequest = 80,
                                    WidthRequest = 480
                                };

                                var label = new Label()
                                {
                                    FontSize = 16,
                                    Text = "Número mesa: " + element.NumeroMesa,
                                    VerticalOptions = LayoutOptions.Center,
                                    Margin = new Thickness(50, 10, 0, 5),
                                };

                                var btnEditar = new Button()
                                {
                                    FontSize = 12,
                                    Text = "Editar",
                                    BackgroundColor = Color.FromHex("#00cc41"),
                                    TextColor = Color.White,
                                    HeightRequest = 35,
                                    CornerRadius = 5,
                                    VerticalOptions = LayoutOptions.Center,
                                    Margin = new Thickness(0, 10, 15, 0),
                                    HorizontalOptions = LayoutOptions.EndAndExpand
                                };

                                btnEditar.Clicked += (obj, e) =>
                                {
                                    BtnEditar_Clicked(orders.IndexOf(element));
                                };

                                var btnEliminar = new Button()
                                {
                                    FontSize = 12,
                                    Text = "Eliminar",
                                    BackgroundColor = Color.Red,
                                    TextColor = Color.White,
                                    HeightRequest = 35,
                                    CornerRadius = 5,
                                    VerticalOptions = LayoutOptions.Center,
                                    Margin = new Thickness(0, 10, 15, 0),
                                };

                                btnEliminar.Clicked += (obj, e) =>
                                {
                                    BtnEliminar_Clicked(orders.IndexOf(element));
                                };

                                stack.Children.Add(label);
                                stack.Children.Add(btnEditar);
                                stack.Children.Add(btnEliminar);

                                Container.Children.Add(stack);
                            }
                        }
                    }
                    else
                    {
                        await DisplayAlert("Ha ocurrido un error", response.Error, "Ok");
                    }
                }
                else
                {
                    await DisplayAlert("Ha ocurrido un error de conexión", "Comprueba tu conexión a internet", "Ok");
                }
            }
            catch(Exception ex)
            {
                await DisplayAlert("Ha ocurrido un error", ex.Message, "Ok");
            }
        }

        private void BtnSalir_Clicked(object sender, EventArgs e)
        {
            System.Environment.Exit(0);
        }

        private async void BtnEditar_Clicked(int index)
        {
            var order = orders[index];
            bool error = false;
            var listDetalles = new List<ProductoResponse>();

            try
            {
                foreach (var detalle in order.DetallesPedidos)
                {
                    var response = await Api.Get<ServerResponse<ProductoResponse>>("http://manuwolf-001-site1.atempurl.com/api/Producto/" + detalle.IdProducto);

                    if (response != null)
                    {
                        if (!response.Success)
                        {
                            await DisplayAlert("Ha ocurrido un error", response.Error, "Ok");
                            error = true;
                            break;
                        }
                        else
                        {
                            listDetalles.Add(response.Data);
                        }
                    }
                    else
                    {
                        await DisplayAlert("Ha ocurrido un error", response.Error, "Ok");
                        error = true;
                        break;
                    }
                }

            }
            catch (Exception ex)
            {
                await DisplayAlert("Ha ocurrido un error", ex.Message, "Ok");
                error = true;
            }

            if (!error) 
                Application.Current.MainPage = new Pedidos(order, listDetalles);
            
        }

        private async void BtnEliminar_Clicked(int index)
        {
            bool eliminar = await DisplayAlert("Confirmación", "Estás seguro de eliminar el pedido", "Si", "No");
            var order = orders[index];

            if (eliminar)
            {
                try
                {
                    bool eliminated = await Api.Delete("http://manuwolf-001-site1.atempurl.com/api/Pedido/" + order.IdPedido);

                    if (eliminated)
                        Application.Current.MainPage = new PaginaPrincipal();
                    else
                        await DisplayAlert("Ha ocurrido un error", "No se pudo eliminar el pedido", "Ok");
                }
                catch(Exception ex)
                {
                    await DisplayAlert("Ha ocurrido un error", ex.Message, "Ok");
                }
            }
            
        }

        private void BtnNuevo_Clicked(object sender, EventArgs e)
        {
            Application.Current.MainPage = new Pedidos();
        }
    }
}