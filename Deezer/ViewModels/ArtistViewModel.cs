using System;
using System.Threading.Tasks;
using Deezer.Commons;
using Deezer.Models.DTO.Down;
using Deezer.Services;
using Prism.Commands;
using Prism.Navigation;
using Xamarin.Forms.PlatformConfiguration;
using Xamarin.Forms.PlatformConfiguration.iOSSpecific;

namespace Deezer.ViewModels
{
    public class ArtistViewModel:BaseViewModel
    {
       public DelegateCommand<object> CmdAlbum { get; set; }

        public ArtistViewModel(INavigationService navigationService, IRequestService requestService) : base(navigationService, requestService)
        {
            this.CmdAlbum = new DelegateCommand<object>(AlbumPage);

        }

        protected override async Task OnNavigatedToAsync(INavigationParameters parameters)
        {
            await base.OnNavigatedToAsync(parameters);
            long artistId = parameters.GetValue<long>("artistId");

            this.Artist = await RequestService.GetArtistAsync(artistId);
        }


        public async void AlbumPage(object albumId)
        {
            var parameter = new NavigationParameters { { "albumId", albumId } };
            await NavigationService.NavigateAsync(Constants.AlbumPage, parameter);
        }


        private ArtistDownDTO _artist;
        public ArtistDownDTO Artist
        {
            get { return _artist; }
            set { SetProperty(ref _artist, value); }
        }

    }
}
