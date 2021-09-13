using System;
using System.Net.Http;
using System.Threading.Tasks;
using Deezer.Commons;
using Deezer.Helpers.Interface;
using Deezer.Models.DTO.Down;
using Prism.Commands;
using Prism.Navigation;
using Xamarin.Forms;

namespace Deezer.ViewModels
{
    public class HomeViewModel:BaseViewModel
    {
        public Command CmdSearch { get; set; }
        public string ArtistName { get; set; }

        public HomeViewModel(INavigationService navigationService) :base(navigationService)
        {
            this.CmdSearch = new Command(SearchArtist);
        }

        protected override async Task OnNavigatedToAsync(INavigationParameters parameters)
        {
            await base.OnNavigatedToAsync(parameters);

        }


        public async void SearchArtist()
        {
            App.search = this.ArtistName;
            await NavigationService.NavigateAsync(Constants.ResultPage);
        }
    }
}
