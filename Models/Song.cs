using SQLite;
using System;
namespace MusicalAlbum.Models
{
    public class Song
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public int? Duration { get; set; }
        public string? Genre { get; set; }
        public int? TrackNumber { get; set; }
        public string? Link { get; set; }
    }
}
