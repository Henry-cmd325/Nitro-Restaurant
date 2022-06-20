using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text;
using System.Text.Json;
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
using AppEscritorio.Models.Response;
using AppEscritorio.Tools;
using AppEscritorio.UI;
using MaterialDesignThemes.Wpf;
using XamlAnimatedGif;

namespace AppEscritorio
{
    /// <summary>
    /// Lógica de interacción para LoginPage.xaml
    /// </summary>
    public partial class LoginPage : Page
    {
        private readonly PaletteHelper paletteHelper = new();
        MainWindow w = (MainWindow)Application.Current.MainWindow;
        public LoginPage()
        {
            InitializeComponent();
            ITheme theme = paletteHelper.GetTheme();

            if (w.IsDarkTheme = theme.GetBaseTheme() == BaseTheme.Dark)
            {
                Logo.Source =new BitmapImage(new Uri(@"/Recursos/Logo Dark 3.gif", UriKind.Relative));  
            }
            else
            {
                Logo.Source = new BitmapImage(new Uri(@"/Recursos/Logo Light 3.gif", UriKind.Relative));
            }
        }
        
        private void toggleTheme(object sender, RoutedEventArgs e)
        {
            ITheme theme = paletteHelper.GetTheme();

            if (w.IsDarkTheme = theme.GetBaseTheme() == BaseTheme.Dark)
            {
                w.IsDarkTheme = false;
                theme.SetBaseTheme(Theme.Light);
                Logo.Source = new BitmapImage(new Uri(@"/Recursos/Logo Light 3.gif", UriKind.Relative));
            }

            else
            {
                w.IsDarkTheme = true;
                theme.SetBaseTheme(Theme.Dark);
                Logo.Source = new BitmapImage(new Uri(@"/Recursos/Logo Dark 3.gif", UriKind.Relative));
            }

            paletteHelper.SetTheme(theme);

        }

        private void exitApp(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        protected override void OnMouseLeftButtonDown(MouseButtonEventArgs e)
        {
            base.OnMouseLeftButtonDown(e);
           
        }

        private async void loginBtn_Click(object sender, RoutedEventArgs e)
        {

            var cuenta = new AccountRequest { Username = txtUsername.Text, Password = txtPassword.Password};

            var result = await Api.Post<AccountRequest, AccountResponse>("https://localhost:7214/api/Cuenta/login", cuenta);

            if(result != null)
            {
                if (result.username == txtUsername.Text)
                {
                    MessageBox.Show(result.username);
                }
                else
                {
                    MessageBox.Show("La constraseña es incorrecta");
                }

            }
            else
            {
                MessageBox.Show("Ha ocurrido un error");
            }
        }

        private void signupBtn_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new SignUp());

        }

    }
}
