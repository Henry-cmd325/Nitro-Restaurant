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
        List<Item> items = new();
        List<RowDefinition> rows = new();
        List<CategoriaResponse> Categories = new();
        private async void ComboBox_Loaded(object sender, RoutedEventArgs e)
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
                        ComboBoxItem itemCategory = new ComboBoxItem();
                        itemCategory.Content = category.Nombre;
                        itemCategory.Tag = category.IdCategoria;
                        itemCategory.Selected += CategorySelected_Selected;
                        ComboCategory.Items.Add(itemCategory);
                        


                        count++;
                        
                    }
                    
                    CountCategory.Desc = count.ToString() + " categories added";
                    
                        
                }
            }
          
        }

      

        private void Button_Click_AddCategory(object sender, RoutedEventArgs e)
        {
            AddCategory cate = new();
            if (cate.ShowDialog() == false)
            {
                NavigationService.Navigate(new Products());
            }

           
        }

        private void Button_Click_AddProduct(object sender, RoutedEventArgs e)
        {
            AddProduct prod = new();
            if (prod.ShowDialog() == false)
            {
                NavigationService.Navigate(new Products());
            }
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
                    
                    int count = 0;

                    for (int i = 1; i <= Math.Ceiling(result.Data.Count() / 2.0); i++)
                    {
                        var definition = new RowDefinition();
                        rows.Add(definition);
                        GridProducts.RowDefinitions.Add(definition);
                    }

                    for (int i = 0; i <= Math.Ceiling(result.Data.Count() / 2.0)-1; i++)
                    {
                        for (int j = 0; j <= 1; j++)
                        {Item itemProduct = new Item();
                            
                            
                            var product = result.Data[count];
                            itemProduct.Title = product.Nombre;
                            itemProduct.Visibility = Visibility.Visible;
                            itemProduct.Height = 70;
                            itemProduct.Icon = FontAwesome.Sharp.IconChar.Utensils;
                            itemProduct.Tag = result.Data[count].IdCategoria;
                            items.Add(itemProduct);
                            Grid.SetRow(itemProduct, i);
                            Grid.SetColumn(itemProduct, j);

                            GridProducts.Children.Add(itemProduct);
                            if (count == result.Data.Count() - 1) break;
                            count++;
                        }
                    }

                    CountProduct.Desc = (count + 1).ToString() + " products added";


                }
            }

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }

        private void CountCategory_Loaded(object sender, RoutedEventArgs e)
        {

        }

        private async void CategorySelected_Selected(object sender, RoutedEventArgs e)
        {
            var result = await Api.Get<ServerResponse<ProductResponse[]>>("http://manuwolf-001-site1.atempurl.com/api/Producto");

           
               
                
            for(int i = 0; i < items.Count; i++)
            {
                GridProducts.Children.Remove(items[i]);
            }

            for (int i = 0; i < rows.Count; i++)
            {
                GridProducts.RowDefinitions.Remove(rows[i]);
            }

            items.Clear();
            rows.Clear();

            for (int i = 1; i <= Math.Ceiling(result.Data.Count() / 2.0); i++)
            {
                var definition = new RowDefinition();
                rows.Add(definition);
                GridProducts.RowDefinitions.Add(definition);
            }
            int row = 0;
            int column = 0;
            for (int i = 0; i < result.Data.Count(); i++)
            {

                
                    if (Convert.ToInt32((sender as ComboBoxItem).Tag) == Convert.ToInt32(result.Data[i].IdCategoria))
                    {


                        Item itemProduct = new Item();


                        var product = result.Data[i];
                        itemProduct.Title = product.Nombre;
                        itemProduct.Visibility = Visibility.Visible;
                        itemProduct.Height = 70;
                        itemProduct.Icon = FontAwesome.Sharp.IconChar.Utensils;
                        itemProduct.Tag = result.Data[i].IdCategoria;
                        items.Add(itemProduct);
                        Grid.SetRow(itemProduct, row);
                        Grid.SetColumn(itemProduct, column);
                        GridProducts.Children.Add(itemProduct);
                        column++;
                        if (column == 2)
                        {
                            column = 0;
                            row++;
                        }
                        
                    }
                
               
                    
            }
                
            



        }
    }
}
