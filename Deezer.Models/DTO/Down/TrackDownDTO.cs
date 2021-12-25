using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace Deezer.Models.DTO.Down
{
    public class TrackDownDTO
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("title")]
        public string Title { get; set; }

        [JsonProperty("duration")]
        public int Duration { get; set; }

        [JsonProperty("track_position")]
        public int TrackPosition { get; set; }

        [JsonProperty("release_date")]
        public string ReleaseDate { get; set; }

        [JsonProperty("preview")]
        public string Preview { get; set; }

        [JsonProperty("album")]
        public AlbumDownDTO Album { get; set; }
    }

    public class RootTrack
    {
        [JsonProperty("data")]
        public List<TrackDownDTO> Tracks { get; set; }

        [JsonProperty("total")]
        public int Total { get; set; }

        [JsonProperty("next")]
        public string Next { get; set; }
    }
}
