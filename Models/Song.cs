using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace MusicalAlbum.Models
{
    public class Song
    {
        public required int Id { get; set; }
        public required string Title { get; set; }
        public int? Duration { get; set; }
        public string? Genre { get; set; }
        public int? TrackNumber { get; set; }
        public required string? Link { get; set; }
    }
}
