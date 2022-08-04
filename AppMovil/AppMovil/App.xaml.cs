using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Xamarin.Essentials;
using AppMovil.Views;
using AppMovil.Views.Modals;
using AppMovil.Services;
using AppMovil.Tools;

namespace AppMovil
{
    public partial class App : Application
    {
        
        public int IdEmpleado;
        public string IdPc;
        public App()
        {
            InitializeComponent();

            MainPage = new MainPage();
        }

        protected override void OnStart()
        {
            DependencyService.RegisterSingleton(new SignalRService());
            DependencyService.RegisterSingleton(new Api());
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
