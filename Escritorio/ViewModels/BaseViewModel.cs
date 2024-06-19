using CommunityToolkit.Mvvm.ComponentModel;
using EscritorioNitroRestaurant.Api;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EscritorioNitroRestaurant.ViewModels
{
   public abstract class BaseViewModel : ObservableObject
    {
        protected readonly IApiService _apiService;
        public BaseViewModel(IApiService apiService) 
        {
            _apiService = apiService;
        }
    }
}
