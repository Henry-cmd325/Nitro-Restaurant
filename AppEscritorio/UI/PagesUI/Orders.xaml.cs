using AppEscritorio.Models.Request;
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
        public List<Item> itemsList = new();
        
        private async void ItemBaseOrder_Loaded(object sender, RoutedEventArgs e)
        {
            var result = await Api.Get<ServerResponse<OrderResponse[]>>("https://localhost:7214/api/Pedido");
            List<RowDefinition> rows = new();

            while (itemsList.Count > 0)
            {
                GridOrdersList.Children.Remove(itemsList[itemsList.Count - 1]);
                itemsList.RemoveAt(itemsList.Count - 1);
            }
            while (rows.Count > 0)
            {
                GridOrdersList.RowDefinitions.Remove(rows[rows.Count - 1]);
                rows.RemoveAt(rows.Count - 1);
            }



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
                    itemOrder.Title = "Table #" + item.Mesa;
                    itemOrder.Desc = "No. Order: " + item.IdPedido.ToString();
                    itemOrder.Icon = ItemBaseOrder.Icon;
                    itemsList.Add(itemOrder);
                    itemOrder.Tag = item.IdPedido;
                    itemOrder.Desc2 = item.Empleado;
                    itemOrder.MouseDoubleClick += ItemBaseOrder_MouseDoubleClick;
                      

                    row++;
                    Grid.SetRow(itemOrder, row);
                    itemOrder.Visibility = Visibility.Visible;
                    GridOrdersList.Children.Add(itemOrder);
                }
            }
        }
        public List<RowDefinition> rows = new();
        public List<Item> itemsProduct = new();
        private async void ItemBaseOrder_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            MesaggeNotClick.Visibility = Visibility.Collapsed;
            ButtonStart.Visibility = Visibility.Visible;
            ButtonStart.Tag = (sender as Item).Tag;
            ButtonFinish.Visibility = Visibility.Visible;
            ButtonFinish.Tag = (sender as Item).Tag;

            while (itemsProduct.Count > 0)
            {
                GridProducts.Children.Remove(itemsProduct[itemsProduct.Count-1]);
                itemsProduct.RemoveAt(itemsProduct.Count - 1);
            }
            while(rows.Count > 0)
            {
                GridProducts.RowDefinitions.Remove(rows[rows.Count - 1]);
                rows.RemoveAt(rows.Count - 1);
            }

            var result = await Api.Get<ServerResponse<OrderResponse>>("https://localhost:7214/api/Pedido/" + (sender as Item).Tag);
            var result2 = await Api.Get<ServerResponse<EmpleadoResponse>>("https://localhost:7214/api/Empleado/" + (sender as Item).Desc2);
           
            var order = Convert.ToInt32((sender as Item).Tag);
            OrderDescription.Text = "Order " + order.ToString();
            OrderDescription.Visibility = Visibility.Visible;
            OrderNoMesa.Text = "Table #" + result.Data.Mesa;
            OrderNoMesa.Visibility = Visibility.Visible;
            OrderNameWaiter.Text = "Waiter: " + result2.Data.Nombre;
            OrderNameWaiter.Visibility = Visibility.Visible;
            Scroll.Visibility = Visibility.Visible;
            
             for (int i = 0; i <= Math.Ceiling(result.Data.DetallesPedidos.Count / 2.0) ; i++)
             {
                 var definition = new RowDefinition();
                 rows.Add(definition);
                 GridProducts.RowDefinitions.Add(definition);
             }
            int row = 0;
            int column = 0;
            foreach (var item in result.Data.DetallesPedidos)
            {
                var result3 = await Api.Get<ServerResponse<ProductResponse>>("https://localhost:7214/api/Producto/" + item.IdProducto);

                Item product = new();
                product.Title = result3.Data.Nombre;
                product.Desc = item.Cantidad.ToString();
                product.Icon = FontAwesome.Sharp.IconChar.Utensils;
                itemsProduct.Add(product);
                Grid.SetRow(product, row);
                Grid.SetColumn(product, column);
                
                if (column == 0) { column++; }
                else if (column > 0){ column = 0; row++; }

                GridProducts.Children.Add(product);   
            }
        }

        private async void ButtonStart_Click(object sender, RoutedEventArgs e)
        {
            var result = await Api.Put<OrderStateRequest>("https://localhost:7214/api/Pedido/state/" + (sender as Button).Tag, new OrderStateRequest
            {
                Terminado = false
            }) ;

          


        }
        private async void ButtonFinish_Click(object sender, RoutedEventArgs e)
        {
            var result = await Api.Put<OrderStateRequest>("https://localhost:7214/api/Pedido/state/" + (sender as Button).Tag, new OrderStateRequest
            {
                Terminado = true
            });
            ItemBaseOrder_Loaded(sender, e);
        }
    }
}
