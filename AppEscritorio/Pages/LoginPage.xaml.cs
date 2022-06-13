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
using XamlAnimatedGif;

namespace AppEscritorio
{
    /// <summary>
    /// Lógica de interacción para LoginPage.xaml
    /// </summary>
    public partial class LoginPage : Page
    {
        public LoginPage()
        {
            InitializeComponent();
            ITheme theme = paletteHelper.GetTheme();
            if (IsDarkTheme = theme.GetBaseTheme() == BaseTheme.Dark)
            {

                IsDarkTheme = true;
                theme.SetBaseTheme(Theme.Dark);

                Logo.Source =new BitmapImage(new Uri(@"/Recursos/Logo Dark 2.gif", UriKind.Relative));



            }
        }

        public bool IsDarkTheme { get; set; }
        private readonly PaletteHelper paletteHelper = new();
        private void toggleTheme(object sender, RoutedEventArgs e)
        {


            ITheme theme = paletteHelper.GetTheme();

            if (IsDarkTheme = theme.GetBaseTheme() == BaseTheme.Dark)
            {
                IsDarkTheme = false;
                theme.SetBaseTheme(Theme.Light);
                Logo.Source = new BitmapImage(new Uri(@"/Recursos/Logo Light 2.gif", UriKind.Relative));
            }

            else
            {
                IsDarkTheme = true;
                theme.SetBaseTheme(Theme.Dark);

                Logo.Source = new BitmapImage(new Uri(@"/Recursos/Logo Dark 2.gif", UriKind.Relative));

                

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

        private void loginBtn_Click(object sender, RoutedEventArgs e)
        {
            string usuario = txtUsername.Text;
            string password = txtPassword.Password;

            try
            {
                Control ctrl = new Control();
                string respuesta = ctrl.ctrlLogin(usuario, password);
                if (respuesta.Length > 0)
                {
                    Label error = new Label();
                    error.Margin = new Thickness(55, 4, 55, 0);
                    error.Content = respuesta;


                }
                else
                {
                    Application.Current.MainWindow.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void signupBtn_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new SignUp());

        }

        private void MediaElement_ManipulationCompleted(object sender, ManipulationCompletedEventArgs e)
        {

        }
    }
}
