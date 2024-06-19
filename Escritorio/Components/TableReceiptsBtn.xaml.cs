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

namespace EscritorioNitroRestaurant.Components
{
    /// <summary>
    /// Lógica de interacción para TableReceiptsBtn.xaml
    /// </summary>
    public partial class TableReceiptsBtn : UserControl
    {
        public string[] icons = { "Money", "CreditCard" };

        public static readonly DependencyProperty ValueProperty =
            DependencyProperty.Register("Total", typeof(string), typeof(TableReceiptsBtn), new PropertyMetadata(string.Empty));

        public string Total
        {
            get { return (string)GetValue(ValueProperty); }
            set { SetValue(ValueProperty, value); }
        }
        public TableReceiptsBtn()
        {
            InitializeComponent();
            DataContext = this;
        }

    }
}
