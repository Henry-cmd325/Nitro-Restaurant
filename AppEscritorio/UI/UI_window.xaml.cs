using AppEscritorio.UI.PagesUI;
using System.Windows;
using System.Windows.Input;



namespace AppEscritorio.UI
{
    /// <summary>
    /// Lógica de interacción para UI_window.xaml
    /// </summary>
    public partial class UI_window : Window
    {
        public UI_window()
        {
            InitializeComponent();
        }

        private void Border_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ChangedButton == MouseButton.Left)
            {
                this.DragMove();
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {

        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            Products product = new Products();
            FrameUI.NavigationService.Navigate(product);
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }
    }
}
