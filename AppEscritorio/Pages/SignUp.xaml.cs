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

namespace AppEscritorio
{
    /// <summary>
    /// Lógica de interacción para SignUp.xaml
    /// </summary>
    public partial class SignUp : Page
    {
        public bool IsDarkTheme { get; set; }
        public SignUp()
        {
            InitializeComponent();
            
            ITheme theme = paletteHelper.GetTheme();
            if (IsDarkTheme = theme.GetBaseTheme() == BaseTheme.Dark)
            {

                IsDarkTheme = true;
                theme.SetBaseTheme(Theme.Dark);

                Logo2.Source = new BitmapImage(new Uri(@"/Recursos/Logo Dark 2.gif", UriKind.Relative));



            }

        }

        
        
        private readonly PaletteHelper paletteHelper = new();
        private void toggleTheme(object sender, RoutedEventArgs e)
        {


            ITheme theme = paletteHelper.GetTheme();

            if (IsDarkTheme = theme.GetBaseTheme() == BaseTheme.Dark)
            {
                IsDarkTheme = false;
                theme.SetBaseTheme(Theme.Light);
                Logo2.Source = new BitmapImage(new Uri(@"/Recursos/Logo Light 2.gif", UriKind.Relative));
                
            }

            else
            {
                IsDarkTheme = true;
                theme.SetBaseTheme(Theme.Dark);

                Logo2.Source = new BitmapImage(new Uri(@"/Recursos/Logo Dark 2.gif", UriKind.Relative));
               


            }

            paletteHelper.SetTheme(theme);

        }

        private void exitApp(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void signUpBtn_Click(object sender, RoutedEventArgs e)
        {

        }

        private void loginBtn_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new LoginPage());
           
        }
    }
}
