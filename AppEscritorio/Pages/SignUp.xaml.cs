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
using System.Windows.Navigation;
using System.Windows.Shapes;
using MaterialDesignThemes.Wpf;
using AppEscritorio;
using XamlAnimatedGif;
using AppEscritorio.Models.Response;
using AppEscritorio.Tools;
using AppEscritorio.UI;

namespace AppEscritorio
{
    /// <summary>
    /// Lógica de interacción para SignUp.xaml
    /// </summary>
    public partial class SignUp : Page
    {
        private readonly PaletteHelper paletteHelper = new();
        MainWindow w = (MainWindow)Application.Current.MainWindow;
        public SignUp()
        {
            w.WindowStartupLocation = WindowStartupLocation.CenterScreen;
            w.Top = 10;
            w.Left = 70;
            w.Height = 800;
            w.Width = 1400;

            InitializeComponent();


            ITheme theme = paletteHelper.GetTheme();
            if (w.IsDarkTheme = theme.GetBaseTheme() == BaseTheme.Dark)
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

            if (w.IsDarkTheme = theme.GetBaseTheme() == BaseTheme.Dark)
            {
                w.IsDarkTheme = false;
                theme.SetBaseTheme(Theme.Light);
                Logo2.Source = new BitmapImage(new Uri(@"/Recursos/Logo Light 3.gif", UriKind.Relative));
                AnimationBehavior.SetSourceUri(Logo2, new Uri(@"/Recursos/Logo Light 3.gif", UriKind.Relative));
            }

            else
            {
                w.IsDarkTheme = true;
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
            var cuenta = new AccountRequest
            {
                Username = txtUsername.Text,
                Password = txtPassword.Password
            };

            var usuario = new Usuarios
            {
                Nombre = txtName.Text,
                Paterno = txtFLastName.Text,
                Materno = txtSLastName.Text,
                Telefono = txtPhone.Text,
                TipoEmpleado = new TipoEmpleadoRequest { Nombre = "User" },
                Cuenta = cuenta
            };

            ServerResponse<UsuarioResponse> result = null;

            try
            {
                Validations.ValidarSignUp(usuario);

                result = await Api.Post<Usuarios, ServerResponse<UsuarioResponse>>("https://localhost:7214/api/Cuenta/signin", usuario);

                if (result == null) throw new Exception("Ha ocurrido un error");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            if(result != null)
            {
                if(!result.Success)
                    MessageBox.Show(result.Error);
                else
                    NavigationService.Navigate(new LoginPage());
            }      
        }

        private void loginBtn_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new LoginPage());

        }


    }
}
