using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Deezer.Helpers.Interface;
using Deezer.Models.Business;
using Deezer.Models.DTO.Down;
using Deezer.Models.Entities;

namespace Deezer.Services
{
    public class RequestService : IRequestService
    {
        private IDataTransferHelper _dataTransferHelper;

        public RequestService(IDataTransferHelper dataTransferHelper)
        {
            _dataTransferHelper = dataTransferHelper;
        }

        public async Task<AlbumDownDTO> GetAlbumAsync(long albumId)
        {
            string url = "https://api.deezer.com/album/" + albumId;
            var result = await _dataTransferHelper.SendClientAsync<AlbumDownDTO>(url, HttpMethod.Get);
            AlbumDownDTO Album = result.Result;

            foreach (TrackDownDTO track in Album.TracksInfo.Tracks)
            {
                track.Album = Album;
            }


            return Album;
        }


        public async Task<ArtistDownDTO> GetArtistAsync(long artistId)
        {

            // We get all artist infos
            string url = "https://api.deezer.com/artist/" + artistId;
            var resArtist = await _dataTransferHelper.SendClientAsync<ArtistDownDTO>(url, HttpMethod.Get);
            ArtistDownDTO artist = resArtist.Result;


            // We get the list of all albums
            url = "https://api.deezer.com/artist/" + artistId + "/albums";
            var resAlbums = await _dataTransferHelper.SendClientAsync<RootAlbum>(url, HttpMethod.Get);
            artist.RootAlbum = resAlbums.Result;

            return artist;
        }

        public async Task<List<ArtistDownDTO>> GetArtistAsync(string name)
        {
            string url = "https://api.deezer.com/search/artist?q=" + name + "&limit=5";
            var resArtists = await _dataTransferHelper.SendClientAsync<RootArtist>(url, HttpMethod.Get);

            List<ArtistDownDTO> artists = new List<ArtistDownDTO>();
            artists = resArtists.Result.Artists;

            return artists;
        }

        public async Task<List<AlbumDownDTO>> GetAlbumsAsync(string name)
        {
            string url = "https://api.deezer.com/search/album?q=" + name + "&limit=5";
            var resAlbums = await _dataTransferHelper.SendClientAsync<RootAlbum>(url, HttpMethod.Get);

            List<AlbumDownDTO> albums = new List<AlbumDownDTO>();
            albums = resAlbums.Result.Albums;

            return albums;
        }

        public async Task<List<TrackDownDTO>> GetTracksAsync(string name)
        {
            string url = "https://api.deezer.com/search/track?q=" + name + "&limit=5";
            var resTracks = await _dataTransferHelper.SendClientAsync<RootTrack>(url, HttpMethod.Get);

            List<TrackDownDTO> tracks = new List<TrackDownDTO>();
            tracks = resTracks.Result.Tracks;

            return tracks;
        }
    }
}
