using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace Deezer.Models.DTO.Down
{
    public class AlbumDownDTO
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("title")]
        public string Title { get; set; }

        [JsonProperty("cover_xl")]
        public string Cover { get; set; }

        [JsonProperty("duration")]
        public int Duration { get; set; }

        [JsonProperty("artist")]
        public ArtistDownDTO Artist { get; set; }

        [JsonProperty("tracks")]
        public RootTrack TracksInfo { get; set; }
    }

    public class RootAlbum
    {
        [JsonProperty("data")]
        public List<AlbumDownDTO> Albums { get; set; }

        [JsonProperty("total")]
        public int Total { get; set; }

        [JsonProperty("next")]
        public string Next { get; set; }
    }
}
