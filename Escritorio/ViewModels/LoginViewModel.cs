using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using EscritorioNitroRestaurant.Api;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EscritorioNitroRestaurant.ViewModels
{
    public partial class LoginViewModel : BaseViewModel
    {
        [ObservableProperty]
        private string email = string.Empty;

        [ObservableProperty]
        private string password = string.Empty;

        public LoginViewModel(IApiService apiService) : base(apiService)
        {}

        [RelayCommand]
        private async Task Login()
        {
            await _apiService.Login(Email, Password);
        }
    }
}
