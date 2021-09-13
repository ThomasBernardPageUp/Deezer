using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace Deezer.Models.DTO.Down
{
    public class SearchDownDTO
    {
        [JsonProperty("data")]
        public List<TrackDownDTO> Data { get; set; }

        [JsonProperty("total")]
        public int Total { get; set; }

        [JsonProperty("next")]
        public string Next { get; set; }
    }
}
