using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Deezer.Models.DTO.Down;
using Deezer.Models.Entities;

namespace Deezer.Services
{
    public interface IRequestService
    {
        Task<AlbumDownDTO> GetAlbumAsync(long albumId);
        Task<ArtistDownDTO> GetArtistAsync(long artistId);
        Task<List<ArtistDownDTO>> GetArtistAsync(string name);
        Task<List<AlbumDownDTO>> GetAlbumsAsync(string name);
        Task<List<TrackDownDTO>> GetTracksAsync(string name);
    }
}
