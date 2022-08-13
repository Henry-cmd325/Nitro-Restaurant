using AppEscritorio.Models.Response;
using AppEscritorio.Tools;
using AppEscritorio.UI.UserControls;
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
    /// Lógica de interacción para Orders.xaml
    /// </summary>
    public partial class Orders : Page
    {
        public Orders()
        {
            InitializeComponent();

            var app = Application.Current as App;

            app.service.OnNewOrder(() =>
            {
                ItemBaseOrder_Loaded(new object(), new RoutedEventArgs());
            });
        }

        private async void ItemBaseOrder_Loaded(object sender, RoutedEventArgs e)
        {
            var result = await Api.Get<ServerResponse<OrderResponse[]>>("http://manuwolf-001-site1.atempurl.com/api/Pedido");
            List<RowDefinition> rows = new();
            List<Item> itemsList = new();
            for (int i = 0; i < result.Data.Length; i++)
            {
                var definition = new RowDefinition();
                rows.Add(definition);
                GridOrdersList.RowDefinitions.Add(definition);

            }
            int row = 0;
            foreach (var item in result.Data)
            {
                if (item.Terminado == null)
                {
                    Item itemOrder = new();
                    itemOrder.Title = "Mesa " + item.NumeroMesa.ToString();
                    itemOrder.Desc = "No. Pedido: " + item.IdPedido.ToString();
                    itemOrder.Icon = ItemBaseOrder.Icon;

                    itemOrder.MouseDoubleClick += ItemBaseOrder_MouseDoubleClick;
                      

                    row++;
                    Grid.SetRow(itemOrder, row);
                    itemOrder.Visibility = Visibility.Visible;
                    GridOrdersList.Children.Add(itemOrder);
                }
            }
        }

        private void ItemBaseOrder_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {

        }
    }
}
