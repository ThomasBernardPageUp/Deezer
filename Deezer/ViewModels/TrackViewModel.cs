using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Deezer.Models.DTO.Down;
using Deezer.Services;
using Deezer.Services.Interface;
using MediaManager;
using Prism.Navigation;
using Xamarin.Forms;
using Xamarin.Forms.PlatformConfiguration;
using Xamarin.Forms.PlatformConfiguration.iOSSpecific;

namespace Deezer.ViewModels
{
    public class TrackViewModel : BaseViewModel
    {

        public Command CmdPreview { get; set; }
        public Command CmdPause { get; set; }
        public Command CmdNext { get; set; }
        public Command CmdNextTrack { get; set; }
        public Command CmdPreviousTrack { get; set; }

        public int Index { get; set; }


        public TrackViewModel(INavigationService navigationService, IRequestService requestService) : base(navigationService, requestService)
        {
            this.CmdPreview = new Command(() => { CrossMediaManager.Current.StepBackward(); });
            this.CmdPause = new Command(PlayPause);
            this.CmdNext = new Command(() => { CrossMediaManager.Current.StepForward(); });
            this.CmdNextTrack = new Command(() => { Index++; Play(); });
            this.CmdPreviousTrack = new Command(() => { Index--; Play(); });
        }

        protected override async Task OnNavigatedToAsync(INavigationParameters parameters)
        {
            await base.OnNavigatedToAsync(parameters);
            CrossMediaManager.Current.Init();

            Tracks = parameters.GetValue<List<TrackDownDTO>>("tracks");
            Track = Tracks[Index];

            await CrossMediaManager.Current.Play(Track.Preview);

            CrossMediaManager.Current.MediaItemFinished += (sender, e) =>
            {
                Index++;
                Play();
            };

            // For the progressBar
            CrossMediaManager.Current.PositionChanged += (sender, e) =>
            {
                CurrentDuration = (int)CrossMediaManager.Current.Position.TotalSeconds;
            };
        }

        // Cut the music when we leave the page
        protected override Task OnNavigatedFromAsync(INavigationParameters parameters)
        {
            CrossMediaManager.Current.Stop();
            return base.OnNavigatedFromAsync(parameters);
        }

        public async void Play()
        {
            if(Index > Tracks.Count - 1)
            {
                Index = Tracks.Count - 1;
            }
            else
            {
                if (Index < 0)
                {
                    Index = 0;
                }
            }

            Track = Tracks[Index];
            await CrossMediaManager.Current.Play(Track.Preview);
        }


        public async void PlayPause()
        {
            if (CrossMediaManager.Current.State == MediaManager.Player.MediaPlayerState.Stopped)
            {
                await CrossMediaManager.Current.Play(Track.Preview);
            }
            else
            {
               await CrossMediaManager.Current.PlayPause();
            }
        }
       

        private int _currentDuration;
        public int CurrentDuration
        {
            get { return _currentDuration; }
            set { SetProperty(ref _currentDuration, value); }
        }

        private TrackDownDTO _track;
        public TrackDownDTO Track
        {
            get { return _track; }
            set { SetProperty(ref _track, value); }
        }
        
        private List<TrackDownDTO> _tracks;
        public List<TrackDownDTO> Tracks
        {
            get { return _tracks; }
            set { SetProperty(ref _tracks, value); }
        }
    }
}
