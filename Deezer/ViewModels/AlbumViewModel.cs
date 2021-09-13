using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Threading.Tasks;
using Deezer.Commons;
using Deezer.Models.DTO.Down;
using Deezer.Models.Entities;
using Deezer.Services;
using MediaManager;
using Prism.Commands;
using Prism.Navigation;
using Prism.Navigation.Xaml;
using Xamarin.Forms;
using NavigationParameters = Prism.Navigation.NavigationParameters;

namespace Deezer.ViewModels
{
    public class AlbumViewModel:BaseViewModel
    {
        public DelegateCommand<TrackDownDTO> CmdPlayTrack { get; set; }
        public Command CmdPlayAlbum { get; set; }
        public DelegateCommand<object> CmdArtist { get; set; }

        public AlbumViewModel(INavigationService navigationService, IRequestService requestService) : base(navigationService, requestService)
        {
            this.CmdPlayTrack = new DelegateCommand<TrackDownDTO>(PlayAsync);
            this.CmdArtist = new DelegateCommand<object>(ArtistPage);
            this.CmdPlayAlbum = new Command(PlayAsync);
        }

        protected override async Task OnNavigatedToAsync(INavigationParameters parameters)
        {
            await base.OnNavigatedToAsync(parameters);
            long albumId = parameters.GetValue<long>("albumId");

            Album = await RequestService.GetAlbumAsync(albumId);
        }

        protected override async Task OnNavigatedFromAsync(INavigationParameters parameters)
        {
            parameters.Add("artistId", Album.Artist.Id);
            await base.OnNavigatedFromAsync(parameters);
        }

        public async void PlayAsync()
        {
            var parameter = new NavigationParameters { { "tracks", Album.TracksInfo.Tracks } };
            await NavigationService.NavigateAsync(Constants.TrackPage, parameter, useModalNavigation: true);
        }

        public async void PlayAsync(TrackDownDTO track)
        {
            List<TrackDownDTO> par = new List<TrackDownDTO>();
            par.Add(track);
            var parameter = new NavigationParameters { { "tracks", par } };

            await NavigationService.NavigateAsync(Constants.TrackPage, parameter, useModalNavigation:true);
        }

        public async void ArtistPage(object artistId)
        {
            var parameter = new NavigationParameters { { "artistId", artistId } };
            await NavigationService.NavigateAsync(Constants.ArtistPage, parameter);
        }



        private AlbumDownDTO _album;
        public AlbumDownDTO Album
        {
            get { return _album; }
            set { SetProperty(ref _album, value); }
        }
    }
}
