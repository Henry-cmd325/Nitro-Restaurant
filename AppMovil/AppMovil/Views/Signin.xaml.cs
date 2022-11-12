using AppMovil.Models.Request;
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
    public partial class Signin : ContentPage
    {
        private readonly Api Api = DependencyService.Get<Api>();
        public Signin()
        {
            InitializeComponent();
        }

        private void BtnSingin_Clicked(object sender, EventArgs e)
        {
            Application.Current.MainPage = new MainPage();
        }

        private async void BtnSignin_Clicked(object sender, EventArgs e)
        {
            BtnSignin.IsEnabled = false;

            try
            {
                var empleado = new EmpleadoSignInRequest()
                {
                    Materno = EMaterno.Text,
                    Paterno = EPaterno.Text,
                    Nombre = ENombre.Text,
                    Telefono = ETelefono.Text
                };

                Validations.ValidarSignin(empleado);

                var response = await Api.Post<EmpleadoSignInRequest, ServerResponse<EmpleadoResponse>>
                                             ("http://nitrorestaurant-001-site1.ctempurl.com/api/Empleado/signin", empleado);

                if (response != null)
                {
                    if (response.Success)
                    {
                        await DisplayAlert("Operación exitosa", "La cuenta ha sido registrada correctamente", "Ok");

                        var app = Application.Current as App;



                        app.MainPage = new Signin();
                    }
                    else
                        await DisplayAlert("Error", response.Error, "Ok");
                }
                else
                    await DisplayAlert("Error de conexión", "Compruebe que este conectado a internet", "Ok");
            }
            catch (NullReferenceException ex)
            {
                await DisplayAlert("Error", "Debe de llenar todos los campos", "Ok");
            }
            catch (Exception ex)
            {
                await DisplayAlert("Error", ex.Message, "Ok");
            }

            BtnSignin.IsEnabled = true;
        }
    }
}