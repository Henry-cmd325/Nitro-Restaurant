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

        private async void BtnLogin_Clicked(object sender, EventArgs e)
        {
            BtnLogin.IsEnabled = false;

            try
            {
                var empleado = new EmpleadoAuthRequest()
                {
                    Telefono = ETelefono.Text
                };

                Validations.ValidarLogin(empleado, ECodigo.Text);

                var response = await Api.Post<EmpleadoAuthRequest, ServerResponse<EmpleadoResponse>>
                                             ("http://nitrorestaurant-001-site1.ctempurl.com/api/Empleado/login", empleado);

                if (response != null)
                {
                    if (response.Success)
                    {
                        var app = Application.Current as App;

                        app.IdEmpleado = response.Data.IdEmpleado;
                        app.IdPc = ECodigo.Text.Trim();

                        var connection = DependencyService.Get<SignalRService>();

                        connection.OnWithinGroup(() => { 
                            app.MainPage = new PaginaPrincipal();
                        });

                        connection.OnError(async () =>
                        {
                            await DisplayAlert("Error", "El codigo introducido es incorrecto", "Ok");
                        });

                        await connection.Connect(ECodigo.Text.Trim());
                    }
                    else
                        await DisplayAlert("Ha ocurrido un error de servidor", response.Error, "Ok");
                }
                else
                    await DisplayAlert("Error de conexión", "Compruebe que este conectado a internet", "Ok");
            }
            catch (NullReferenceException ex)
            {
                await DisplayAlert("Ha ocurrido un error", "Debe de rellenar todos los campos", "Ok");
            }
            catch (Exception ex)
            {
                
                await DisplayAlert("Ha ocurrido un error de aplicacion", ex.Message, "Ok");
            }
            

            BtnLogin.IsEnabled = true;
        }
    }
}