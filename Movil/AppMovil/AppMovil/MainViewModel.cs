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
using System.Threading.Tasks;
using Xamarin.Forms;

namespace AppMovil
{
    public class MainViewModel
    {
        public MainViewModel()
        {
            Onboardings = GetOnboarding();
        }

        public List<Onboarding> Onboardings { get; set; }

        private List<Onboarding> GetOnboarding()
        {
            return new List<Onboarding>
            {
                new Onboarding { Heading = "Attention to the moment", Caption = "Generates happy customers, attends at the moment"},
                new Onboarding { Heading = "Speedy customer service", Caption = "Create an enviroment of good customer service" },
                new Onboarding { Heading = "Streamline your processes", Caption = "streamline your process from the tables to the kitchen" }
            };
        }
    }

    public class Onboarding
    {
        public string Heading { get; set; }
        public string Caption { get; set; }
    }
}
