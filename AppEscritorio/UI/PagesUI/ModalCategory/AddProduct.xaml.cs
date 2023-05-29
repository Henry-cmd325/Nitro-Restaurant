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
            float inversion, precio = 0;

            try
            {
                Validations.ValidarAñadirProduct(txtNameProduct.Text, ComboCategory.SelectedIndex, txtInvestment.Text, txtPrice.Text);
                Titulo.Text = ComboCategory.Items[ComboCategory.SelectedIndex].ToString().Substring(38);
                inversion = float.Parse(txtInvestment.Text);
                precio = float.Parse(txtPrice.Text);

                var result = await Api.Post<ProductRequest, ServerResponse<ProductResponse>>("http://nitrorestaurant-001-site1.ctempurl.com/api/Producto", new ProductRequest
                {
                    Nombre = txtNameProduct.Text,
                    IdSucursal = 1,
                    IdCategoria = ComboCategory.SelectedIndex,
                    Inversion = decimal.Parse(txtInvestment.Text),
                    Contable = true,
                    Cantidad = 0,
                    Precio = decimal.Parse(txtPrice.Text),
                    ImgUrl = null,
                    IdUm = 1
                }
                  );


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
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            
            
        }

        private async void ComboBox_Loaded(object sender, RoutedEventArgs e)
        {
            var result = await Api.Get<ServerResponse<CategoryResponse[]>>("http://nitrorestaurant-001-site1.ctempurl.com/api/Categoria");

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

        private void ComboCategory_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void txtNameProduct_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void txtPrice_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void txtInvestment_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (System.Text.RegularExpressions.Regex.IsMatch(txtInvestment.Text, " ^ [0-9]"))
                txtInvestment.Text = "";
        }
    }
}
