using AppEscritorio.Models.Request;
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
using System.Windows.Shapes;

namespace AppEscritorio.UI.PagesUI.ModalCategory
{
    /// <summary>
    /// Lógica de interacción para AddProduct.xaml
    /// </summary>
    public partial class AddProduct : Window
    {
        public AddProduct()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private async void Button_Click_1(object sender, RoutedEventArgs e)
        {
            if (txtNameProduct.Text.Trim() == "")
            {
                MessageBox.Show("Debe escribir un nombre para el producto", "Campo Vacío", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
            else
            {
                var result = await Api.Post<ProductRequest, ServerResponse<ProductResponse>>("http://manuwolf-001-site1.atempurl.com/api/Producto", new ProductRequest
                { Nombre = txtNameProduct.Text,
                  Categoria = ComboCategory.SelectedItem.ToString() }) ;

                if (result != null)
                {
                    if (result.Success)
                    {
                        MessageBox.Show("El producto fue agregado con éxito", "Success", MessageBoxButton.OK);
                        Close();
                    }
                    else
                    {
                        MessageBox.Show(result.Error);
                    }
                }
            }
        }

        private async void ComboBox_Loaded(object sender, RoutedEventArgs e)
        {
            var result = await Api.Get<ServerResponse<CategoriaResponse[]>>("http://manuwolf-001-site1.atempurl.com/api/Categoria");

            if (result != null)
            {
                
                    

                    foreach (var categ in result.Data)
                    {
                        ComboBoxItem item = new ComboBoxItem();
                        item.Content = categ.Nombre;
                        ComboCategory.Items.Add(item);
                        


                        

                    }

                    


                
            }
        }
    }
}
