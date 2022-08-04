using AppMovil.Models.Request;
using AppMovil.Models.Response;
using AppMovil.Services;
using AppMovil.Tools;
using AppMovil.Views;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace AppMovil
{
    public partial class MainPage : ContentPage
    {
        private readonly Api Api = DependencyService.Get<Api>();

        public MainPage()
        {
            InitializeComponent();
        }

        private void BtnLogin_Clicked(object sender, EventArgs e)
        {
            Application.Current.MainPage = new Signin();
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
                
                var response = await Api.Post<EmpleadoSignInRequest ,ServerResponse<EmpleadoResponse>>
                                             ("http://manuwolf-001-site1.atempurl.com/api/Empleado/signin", empleado);

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
