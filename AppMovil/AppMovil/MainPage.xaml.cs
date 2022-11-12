using AppMovil.Models.Request;
using AppMovil.Models.Response;
using AppMovil.Services;
using AppMovil.Tools;
using AppMovil.Views;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Timers;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace AppMovil
{
    public partial class MainPage : ContentPage
    {
        private readonly Api Api = DependencyService.Get<Api>();

        public MainPage()
        {
            InitializeComponent();
            AnimateCarousel();
        }

        Timer timer;

        private void AnimateCarousel()
        {
            timer = new Timer(5000) { AutoReset = true, Enabled = true };

            timer.Elapsed += (s, e) =>
            {
                if (cvOnBoarding.Position == 2)
                {
                    cvOnBoarding.Position = 0;
                    return;
                }
                Device.BeginInvokeOnMainThread(() =>
                {
                    cvOnBoarding.Position += 1;
                });
            };
        }

        private void BtnLogin_Clicked(object sender, EventArgs e)
        {
            Application.Current.MainPage = new login();
        }

        private void BtnSingin_Clicked(object sender, EventArgs e)
        {
            Application.Current.MainPage = new Signin();
        }
    }
}
