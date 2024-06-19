using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using EscritorioNitroRestaurant.Api;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace EscritorioNitroRestaurant.ViewModels
{
    public partial class MainViewModel : BaseViewModel
    {
        [ObservableProperty]
        private string btnOrdersColor = "#312E80";
        [ObservableProperty]
        private string btnOrdersThickness = "2";

        [ObservableProperty]
        private string btnReceiptColor = "#D9D9D9";
        [ObservableProperty]
        private string btnReceiptThickness = "1";

        [ObservableProperty]
        private string btnSalesColor = "#D9D9D9";
        [ObservableProperty]
        private string btnSalesThickness = "1";

        [ObservableProperty]
        private string total = "$25.00";

        public MainViewModel(IApiService apiService) : base(apiService)
        {}

        [RelayCommand]
        private void OrdersClicked()
        {
            if (BtnOrdersThickness == "2") return;

            BtnOrdersColor = "#312E80";
            BtnOrdersThickness = "2";

            BtnReceiptColor = "#D9D9D9";
            BtnReceiptThickness = "1";

            BtnSalesColor = "#D9D9D9";
            BtnSalesThickness = "1";
        }

        [RelayCommand]
        private void ReceiptClicked()
        {
            if (BtnReceiptThickness == "2") return;

            BtnOrdersColor = "#D9D9D9";
            BtnOrdersThickness = "1";

            BtnReceiptColor = "#312E80";
            BtnReceiptThickness = "2";

            BtnSalesColor = "#D9D9D9";
            BtnSalesThickness = "1";
        }

        [RelayCommand]
        private void SalesClicked()
        {
            if (BtnSalesThickness == "2") return;

            BtnOrdersColor = "#D9D9D9";
            BtnOrdersThickness = "1";

            BtnReceiptColor = "#D9D9D9";
            BtnReceiptThickness = "1";

            BtnSalesColor = "#312E80";
            BtnSalesThickness = "2";
        }
    }
}
