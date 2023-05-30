using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using XamlAnimatedGif;
using AppEscritorio.Models.Response;
using AppEscritorio.Tools;
using AppEscritorio.UI;
using MaterialDesignThemes.Wpf;
using AppEscritorio.Models.Request;

namespace AppEscritorio.Pages
{
    /// <summary>
    /// Lógica de interacción para SignUp2.xaml
    /// </summary>
    public partial class SignUp : Window
    {
        public bool IsDarkTheme { set; get; }
        private readonly PaletteHelper paletteHelper = new();
        public SignUp()
        { 
            InitializeComponent();

            ITheme theme = paletteHelper.GetTheme();
            if (IsDarkTheme = theme.GetBaseTheme() == BaseTheme.Dark)
            {
                Logo2.Source = new BitmapImage(new Uri(@"/Recursos/Logo Dark 3.gif", UriKind.Relative));
                AnimationBehavior.SetSourceUri(Logo2, new Uri(@"/Recursos/Logo Dark 3.gif", UriKind.Relative));
            }
            else
            {
                Logo2.Source = new BitmapImage(new Uri(@"/Recursos/Logo Light 3.gif", UriKind.Relative));
                AnimationBehavior.SetSourceUri(Logo2, new Uri(@"/Recursos/Logo Light 3.gif", UriKind.Relative));
            }
        }

        private void toggleTheme(object sender, RoutedEventArgs e)
        {
            ITheme theme = paletteHelper.GetTheme();

            if (IsDarkTheme = theme.GetBaseTheme() == BaseTheme.Dark)
            {
                IsDarkTheme = false;
                theme.SetBaseTheme(Theme.Light);
                Logo2.Source = new BitmapImage(new Uri(@"/Recursos/Logo Light 3.gif", UriKind.Relative));
                AnimationBehavior.SetSourceUri(Logo2, new Uri(@"/Recursos/Logo Light 3.gif", UriKind.Relative));
            }
            else
            {
                IsDarkTheme = true;
                theme.SetBaseTheme(Theme.Dark);
                Logo2.Source = new BitmapImage(new Uri(@"/Recursos/Logo Dark 3.gif", UriKind.Relative));
                AnimationBehavior.SetSourceUri(Logo2, new Uri(@"/Recursos/Logo Dark 3.gif", UriKind.Relative));
            }

            paletteHelper.SetTheme(theme);
        }

        private void exitApp(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private async void signUpBtn_Click(object sender, RoutedEventArgs e)
        {
            signUpBtn.IsEnabled = false;

            if (txtPassword.Password != txtConPassword.Password )
            {
                MessageBox.Show("Las contraseñas no coinciden", "Aviso", MessageBoxButton.OK);
            }
            else
            {
                var cuenta = new EmpleadoAuthRequest
                {
                    Username = txtUsername.Text,
                    Password = txtPassword.Password
                };

                var usuario = new EmpleadoRequest
                {
                    Nombre = txtName.Text,
                    Paterno = txtFLastName.Text,
                    Materno = txtSLastName.Text,
                    Telefono = txtPhone.Text,
                    IdTipoEmpleado = 2,
                    Activo = true,
                    Usuario = txtUsername.Text,
                    Contrasenia = txtPassword.Password,
                    IdSucursal= 1
                };

                ServerResponse<EmpleadoResponse> result = null;

                try
                {
                    Validations.ValidarSignUp(usuario);

                    result = await Api.Post<EmpleadoRequest, ServerResponse<EmpleadoResponse>>("https://localhost:7214/api/Empleado/signin", usuario);

                    if (result == null) throw new Exception("Ha ocurrido un error");
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }

                if (result != null)
                {
                    if (!result.Success)
                        MessageBox.Show(result.Error);
                    else
                    {
                        MessageBox.Show("¡Registro Exitoso!", "El usuario se registró correctamente", MessageBoxButton.OK);
                        MainWindow main = new MainWindow();
                        main.Show();
                        this.Close();
                    }

                }
            }

            signUpBtn.IsEnabled = true;
        }

        private void loginBtn_Click(object sender, RoutedEventArgs e)
        {
            MainWindow main = new MainWindow();
            this.Close();
            main.Show();
        }
    }
}
