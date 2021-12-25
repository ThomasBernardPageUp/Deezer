using System;
using System.Collections.Generic;

namespace Deezer.Models.Entities
{
    public class AlbumEntity
    {
        public long Id { get; set; }
        public string Title { get; set; }
        public string Cover { get; set; }
        public int Duration { get; set; }
        public DateTime ReleaseDate { get; set; }
        public ArtistEntity Artist { get; set; }
        public List<TrackEntity> Tracks { get; set; }

        public AlbumEntity()
        {
        }

        public AlbumEntity(long id, string title, string cover, int duration, DateTime releaseDate, ArtistEntity artist, List<TrackEntity> tracks):this()
        {
            Id = id;
            Title = title;
            Cover = cover;
            Duration = duration;
            ReleaseDate = releaseDate;
            Artist = artist;
            Tracks = tracks;
        }

                
    }
}
    