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
        public PaginaPrincipal()
        {
            InitializeComponent();
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();

            try
            {
                var response = await Api.Get<ServerResponse<OrderResponse>>("");

                if (response != null)
                {

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