using AppMovil.Models.Response;
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
                var response = await Api.Get<ServerResponse<List<OrderResponse>>>("");

                if (response != null)
                {
                    if (response.Success)
                    {
                        foreach (var element in response.Data)
                        {
                            if (element.Terminado == null || element.Terminado == false)
                            {
                                orders.Add(element);

                               /* var 

                                <StackLayout Orientation="Horizontal" BackgroundColor="#e4e6eb" HeightRequest="80" WidthRequest="480">
                        <Label FontSize="16" Text="Numero orden: 1" VerticalOptions="Center" Margin="50,10,0,5" ></Label>
                                    <Button FontSize="12" Text="Editar" BackgroundColor="#00cc41" TextColor="White" HeightRequest="35" CornerRadius="5" VerticalOptions="Center" Margin="0,10,15,0"
                                HorizontalOptions="EndAndExpand"></Button>
                                    <Button FontSize="12" Text="Eliminar" BackgroundColor="red" TextColor="White" HeightRequest="35" CornerRadius="5" VerticalOptions="Center" Margin="0,10,15,0"></Button>
                                </StackLayout>*/
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
    }
}