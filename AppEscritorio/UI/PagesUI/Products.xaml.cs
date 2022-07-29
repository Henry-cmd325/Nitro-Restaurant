using AppEscritorio.Models.Response;
using AppEscritorio.Tools;
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

namespace AppEscritorio.UI.PagesUI
{
    /// <summary>
    /// Lógica de interacción para Products.xaml
    /// </summary>
    public partial class Products : Page
    {
        public Products()
        {
            InitializeComponent();
        }

        private async void  Item_Loaded(object sender, RoutedEventArgs e)
        {
            var result = await Api.Get<ServerResponse<List<CategoriaResponse>>>("http://manuwolf-001-site1.atempurl.com/api/Categoria");
            
                if (result.Data == null)
                {
                    addCategory.Visibility = Visibility.Collapsed;
                }
                else
                {
                   // addCategory.Visibility = Visibility.Collapsed;
                }
          
        }
    }
}
