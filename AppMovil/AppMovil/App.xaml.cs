using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Xamarin.Essentials;
using AppMovil.Views;

namespace AppMovil
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = new Pedidos();
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
