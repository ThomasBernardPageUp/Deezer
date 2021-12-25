using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Deezer.Commons;
using Deezer.Helpers.Interface;
using Deezer.Models.DTO.Down;
using Deezer.Models.Entities;
using Deezer.Services;
using Prism.Commands;
using Prism.Navigation;

namespace Deezer.ViewModels
{
    public class ResultViewModel : BaseViewModel
    {
        public DelegateCommand<object> CmdArtist { get; set; }
        public DelegateCommand<object> CmdAlbum { get; set; }
        public DelegateCommand<object> CmdTrack { get; set; }


        public ResultViewModel(INavigationService navigationService, IRequestService requestService) : base(navigationService, requestService)
        {
            this.CmdArtist = new DelegateCommand<object>(ArtistPage);
            this.CmdAlbum = new DelegateCommand<object>(AlbumPage);
            this.CmdTrack = new DelegateCommand<object>(TrackPage);

        }

        protected override async Task OnNavigatedToAsync(INavigationParameters parameters)
        {
            await base.OnNavigatedToAsync(parameters);

            Artists = await RequestService.GetArtistAsync(App.search);
            Albums = await RequestService.GetAlbumsAsync(App.search);
            Tracks = await RequestService.GetTracksAsync(App.search);

        }

        public async void ArtistPage(object artistId)
        {
            var parameter = new NavigationParameters { { "artistId", artistId } };
            await NavigationService.NavigateAsync(Constants.ArtistPage, parameter);
        }

        public async void AlbumPage(object albumId)
        {
            var parameter = new NavigationParameters { { "albumId", albumId } };
            await NavigationService.NavigateAsync(Constants.AlbumPage, parameter);
        }

        public async void TrackPage(object track)
        {
            List<TrackDownDTO> tracks = new List<TrackDownDTO>();
            tracks.Add((TrackDownDTO)track);
            var parameter = new NavigationParameters { { "tracks", tracks } };
            await NavigationService.NavigateAsync(Constants.TrackPage, parameter, useModalNavigation: true);
        }


        
        private List<TrackDownDTO> _tracks;
        public List<TrackDownDTO> Tracks
        {
            get { return _tracks; }
            set { SetProperty(ref _tracks, value); }
        }


        private List<AlbumDownDTO> _albums;
        public List<AlbumDownDTO> Albums
        {
            get { return _albums; }
            set { SetProperty(ref _albums, value); }
        }

        private List<ArtistDownDTO> _artists;
        public List<ArtistDownDTO> Artists
        {
            get { return _artists; }
            set { SetProperty(ref _artists, value); }
        }
    }
}
