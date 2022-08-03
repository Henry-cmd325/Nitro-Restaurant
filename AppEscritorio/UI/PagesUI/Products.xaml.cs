using AppEscritorio.Models.Response;
using AppEscritorio.Tools;
using AppEscritorio.UI.PagesUI.ModalCategory;
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
    /// Lógica de interacción para Products.xaml
    /// </summary>
    public partial class Products : Page
    {
        public Products()
        {
            InitializeComponent();
        }

        List<CategoriaResponse> Categories = new();
        private async void  Item_Loaded(object sender, RoutedEventArgs e)
        {
            var result = await Api.Get<ServerResponse<CategoriaResponse[]>>("http://manuwolf-001-site1.atempurl.com/api/Categoria");

            if (result != null)
            {
                if (result.Data.Length == 0)
                {
                    addCategory.Visibility = Visibility.Visible;
                }
                else
                {
                    int count = 0;
                    
                    foreach(var category in result.Data)
                    {
                        MenuItem item = new MenuItem();
                        item.Header = category.Nombre;
                        item.Style = SelectCategory.Style;
                        item.Foreground = SelectCategory.Foreground;
                        SelectCategory.Items.Add(item);
                        
                        count++;
                        
                    }
                    
                    CountCategory.Desc = count.ToString() + " categories added";
                    
                        
                }
            }
          
        }

      

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            AddCategory cate = new();
            cate.ShowDialog();
        }

        private void Button_Click_AddProduct(object sender, RoutedEventArgs e)
        {
            AddProduct prod = new();
            prod.ShowDialog();
        }

        private async void Item_Loaded_1(object sender, RoutedEventArgs e)
        {
            var result = await Api.Get<ServerResponse<ProductResponse[]>>("http://manuwolf-001-site1.atempurl.com/api/Producto");

            if (result != null)
            {
                if (result.Data.Length == 0)
                {
                    addProduct.Visibility = Visibility.Visible;
                }
                else
                {
                    int column = 0;
                    int count = 0;

                    for (int i = 1; i <= Math.Ceiling(result.Data.Count() / 2.0); i++)
                    {
                        var definition = new RowDefinition();

                        GridProducts.RowDefinitions.Add(definition);
                    }

                    for (int i = 0; i <= Math.Ceiling(result.Data.Count() / 2.0)-1; i++)
                    {
                        for (int j = 0; j <= 1; j++)
                        {
                            var product = result.Data[count];
                            Item item = new Item();
                            item.Title = product.Nombre;
                            item.Visibility = Visibility.Visible;
                            item.Height = 70;
                            
                            Grid.SetRow(item, i);
                            Grid.SetColumn(item, j);

                            GridProducts.Children.Add(item);

                            count++;
                        }
                    }

                    CountProduct.Desc = count.ToString() + " products added";


                }
            }

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
