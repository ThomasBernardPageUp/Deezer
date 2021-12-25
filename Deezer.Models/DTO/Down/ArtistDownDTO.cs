using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace Deezer.Models.DTO.Down
{
    public class ArtistDownDTO
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("picture")]
        public string Picture { get; set; }

        [JsonProperty("tracklist")]
        public string Tracklist { get; set; }

        public RootAlbum RootAlbum { get; set; }
    }

    public class RootArtist
    {
        [JsonProperty("data")]
        public List<ArtistDownDTO> Artists { get; set; }

        [JsonProperty("total")]
        public int Total { get; set; }

        [JsonProperty("next")]
        public string Next { get; set; }
    }
}
