using AppEscritorio.Models.Response;
using AppEscritorio.Tools;
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
    /// Lógica de interacción para Orders.xaml
    /// </summary>
    public partial class Settings : Page
    {
        public Settings()
        {
            InitializeComponent();
            var app = Application.Current as App;

            EnlaceCode.Text += " " + app.idPc;
        }
    }
}
