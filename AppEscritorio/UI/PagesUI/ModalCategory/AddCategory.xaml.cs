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
    /// Lógica de interacción para AddCategory.xaml
    /// </summary>
    public partial class AddCategory : Window
    {
        public AddCategory()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private async void Button_Click_1(object sender, RoutedEventArgs e)
        {
            
            if (txtNameCategory.Text.Trim() == "")
            {
                MessageBox.Show("Debe escribir un nombre para la categoría", "Campo Vacío",   MessageBoxButton.OK, MessageBoxImage.Warning);
            }
            else
            {
                var result = await Api.Post<CategoryRequest, ServerResponse<CategoriaResponse>>("http://nitrorestaurant-001-site1.ctempurl.com/api/Categoria", new CategoryRequest
                { Nombre = txtNameCategory.Text });

                if (result != null)
                {
                    if(result.Success)
                    {
                        MessageBox.Show("La categoría fue agregada con éxito", "Success", MessageBoxButton.OK);
                        Close();
                    }
                    else 
                    {
                        MessageBox.Show(result.Error);
                    }
                }
            }
        }
    }
}
