using System;
using System.Collections.Generic;
using System.Linq;
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
using AppEscritorio.Pages;
using AppEscritorio.Tools;
using AppEscritorio.UI;
using MaterialDesignThemes.Wpf;
using XamlAnimatedGif;

namespace AppEscritorio
{
    public partial class MainWindow : Window
    {
        private readonly PaletteHelper paletteHelper = new();
        public bool IsDarkTheme { get; set; }
        public MainWindow()
        {
            InitializeComponent();
            ITheme theme = paletteHelper.GetTheme();

            if (IsDarkTheme = theme.GetBaseTheme() == BaseTheme.Dark)
            {
                Logo.Source = new BitmapImage(new Uri(@"/Recursos/Logo Dark 3.gif", UriKind.Relative));
                AnimationBehavior.SetSourceUri(Logo, new Uri(@"/Recursos/Logo Dark 3.gif", UriKind.Relative));
            }
            else
            {
                Logo.Source = new BitmapImage(new Uri(@"/Recursos/Logo Light 3.gif", UriKind.Relative));
                AnimationBehavior.SetSourceUri(Logo, new Uri(@"/Recursos/Logo Light 3.gif", UriKind.Relative));
            }
        }

        private void toggleTheme(object sender, RoutedEventArgs e)
        {
            ITheme theme = paletteHelper.GetTheme();

            if (IsDarkTheme = theme.GetBaseTheme() == BaseTheme.Dark)
            {
                IsDarkTheme = false;
                theme.SetBaseTheme(Theme.Light);
                Logo.Source = new BitmapImage(new Uri(@"/Recursos/Logo Light 3.gif", UriKind.Relative));
                AnimationBehavior.SetSourceUri(Logo, new Uri(@"/Recursos/Logo Light 3.gif", UriKind.Relative));
            }
            else
            {
                IsDarkTheme = true;
                theme.SetBaseTheme(Theme.Dark);
                Logo.Source = new BitmapImage(new Uri(@"/Recursos/Logo Dark 3.gif", UriKind.Relative));
                AnimationBehavior.SetSourceUri(Logo, new Uri(@"/Recursos/Logo Dark 3.gif", UriKind.Relative));
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
            loginBtn.IsEnabled = false;
            try
            {
                var cuenta = new AccountRequest { Username = txtUsername.Text, Password = txtPassword.Password };

                var result = await Api.Post<AccountRequest, ServerResponse<AccountResponse>>("https://localhost:7214/api/Empleado/login", cuenta);

                if (result != null && result.Success)
                {
                    if (result.Data == null)
                    {
                        MessageBox.Show(JsonSerializer.Serialize(result));
                    }
                    else if (result.Data.Username == txtUsername.Text)
                    {
                        UI_window ui = new UI_window();
                        var app = Application.Current as App;

                        app.service.OnReceiveKey((id) =>
                        {
                            app.idPc = id;
                        });
                        await app.service.Connect();

                        ui.Show();
                        this.Close();
                    }
                    else
                    {
                        string error = "";

                        if (result.Error != null) error = result.Error;

                        MessageBox.Show("Ha ocurrido un error: " + error);
                    }
                }
                else
                {
                    MessageBox.Show("Ha ocurrido un error");
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show("Comprueba tu conexión a internet");
            }
            
           loginBtn.IsEnabled = true; 
        }

        private void signupBtn_Click(object sender, RoutedEventArgs e)
        {
            SignUp signWindow = new SignUp();
            this.Close();

            signWindow.Show();
        }
    }
}
