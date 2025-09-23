using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace MusicalAlbum.Models
{
    public class Album
    {
        public required UniqueId Id { get; set; }
        public required string Title { get; set; }
        public required List<Song> Songs { get; set; }
        public required string Cover { get; set; } // URL or file path to the album cover image
        public required int Year { get; set; }
        public required string Genre { get; set; }
    }
}
