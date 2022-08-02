using AppMovil.Models.Response;
using AppMovil.Tools;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AppMovil.Views.Modals
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SelectProduct : ContentPage
    {
        public List<CategoriaResponse> categorias = new List<CategoriaResponse>();

        public List<ProductoResponse> Sproductos = new List<ProductoResponse>();

        private Pedidos Padre = Application.Current.MainPage as Pedidos;

        public SelectProduct()
        {
            InitializeComponent();
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();

            try
            {
                var response = await Api.Get<ServerResponse<CategoriaResponse[]>>("http://manuwolf-001-site1.atempurl.com/api/categoria");

                if (response != null)
                {
                    if (response.Success)
                    {
                        foreach (var category in response.Data)
                        {
                            var btn = new Button()
                            {
                                Text = category.Nombre,
                                CornerRadius = 3,
                                Margin = new Thickness(0, 5, 0, 0),
                                FontSize = 13,
                                HorizontalOptions = LayoutOptions.Center,
                                HeightRequest = 50,
                                WidthRequest = 300,
                                TextColor = Color.Black
                            };

                            btn.Clicked += BtnCategory_Clicked;

                            if (category == response.Data[0]) btn.Margin = new Thickness(0, 20, 0, 0);

                            CategoryList.Children.Add(btn);
                            categorias.Add(category);
                        }
                    }
                    else
                    {
                        await DisplayAlert("Ha ocurrido un error", response.Error, "Ok");
                    }
                }
            }
            catch (Exception ex)
            {
                await DisplayAlert("Ha ocurrido un errror", ex.Message, "Ok");
            }

        }

        private async void BtnCancel_Clicked(object sender, EventArgs e)
        {
            await Navigation.PopModalAsync();
        }

        private async void BtnCategory_Clicked(object sender, EventArgs e)
        {
            int idCategoria = 0;

            var btnSender = sender as Button;

            for (int i = 0; i < categorias.Count; i++)
            {
                if (btnSender.Text == categorias[i].Nombre) idCategoria = categorias[i].IdCategoria;
            }

            ProductList.Children.Clear();
            Sproductos.Clear();

            try
            {
                var response = await Api.Get<ServerResponse<ProductoResponse[]>>("http://manuwolf-001-site1.atempurl.com/api/Producto");


                if (response != null && response.Success)
                {
                    foreach (var producto in response.Data)
                    {
                        if (producto.IdCategoria == idCategoria)
                        {
                            var btn = new Button()
                            {
                                Text = producto.Nombre,
                                CornerRadius = 3,
                                Margin = new Thickness(0, 5, 0, 0),
                                FontSize = 13,
                                HorizontalOptions = LayoutOptions.Center,
                                HeightRequest = 50,
                                WidthRequest = 300,
                                TextColor = Color.Black
                            };

                            if (producto == response.Data[0]) btn.Margin = new Thickness(0, 20, 0, 0);

                            btn.Clicked += BtnProduct_Clicked;

                            bool hasProduct = false;

                            foreach (var p in Padre.Productos)
                            {
                                if (p.IdProducto == producto.IdProducto) hasProduct = true;
                            }

                            if (!hasProduct)
                            {
                                ProductList.Children.Add(btn);
                                Sproductos.Add(producto);
                            }
                        }
                    }

                    if (ProductList.Children.Count == 0) ProductList.Children.Add(new Label()
                    {
                        VerticalOptions = LayoutOptions.Center,
                        HorizontalOptions= LayoutOptions.Center,
                        Text = "La categoria elegida aún no tiene ningun producto"
                    });
                }
                else
                    await DisplayAlert("Ha ocurrido un error", "Ha habido un error de conexión", "Ok");

            }
            catch (Exception ex)
            {
                await DisplayAlert("Ha ocurrio un error", ex.Message, "Ok");
            }
        }
        
        private async void BtnProduct_Clicked(object sender, EventArgs e)
        {
            var btn = sender as Button;

            foreach(var producto in Sproductos)
            {
                if (btn.Text == producto.Nombre)
                {
                    Padre.AddProduct(producto);
                    await Navigation.PopModalAsync();
                    break;
                }
            }
        }
    }
}