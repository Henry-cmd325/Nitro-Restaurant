using AppEscritorio.Services;
using AppEscritorio.UI.PagesUI;
using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;



namespace AppEscritorio.UI
{
    /// <summary>
    /// Lógica de interacción para UI_window.xaml
    /// </summary>
    public partial class UI_window : Window
    {
        public Window window = new();
        public App app = Application.Current as App;
        public Frame Framesito = new();

        public UI_window()
        {
            InitializeComponent();

            Framesito.Height = 667;
            Framesito.NavigationUIVisibility = System.Windows.Navigation.NavigationUIVisibility.Hidden;
            Framesito.Source = new Uri(@"/UI/PagesUI/Orders.xaml", UriKind.Relative);
            StackPanelFrame.Children.Add(Framesito);

            app.page = this;
        }

        private void Border_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ChangedButton == MouseButton.Left)
                this.DragMove();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            var settings = new Settings();
            var app = (App)Application.Current;
            var windowPadre = app.page as UI_window;

            windowPadre.Framesito.NavigationService.Navigate(settings);
        }

        public void Button_Click_2(object sender, RoutedEventArgs e)
        {
            var product = new Products();
            var app = (App)Application.Current;
            var windowPadre = app.page as UI_window;

            windowPadre.Framesito.NavigationService.Navigate(product);
        }

        


        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            MainWindow main = new MainWindow();
            this.Close();
            main.Show();
        }

        private void Button_Click_Orders(object sender, RoutedEventArgs e)
        {
            var orders = new Orders();
            var app = (App)Application.Current;
            var windowPadre = app.page as UI_window;
            windowPadre.Framesito.NavigationService.Navigate(orders);
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var finishedOrders = new FinishedOrders();
            var app = (App)Application.Current;
            var windowPadre = app.page as UI_window;
            windowPadre.Framesito.NavigationService.Navigate(finishedOrders);
        }
    }
}
