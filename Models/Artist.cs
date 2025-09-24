using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace MusicalAlbum.Models
{
    public class Artist
    {
        internal bool IsFavorite;

        public required int Id { get; set; }
        public required string Name { get; set; }
        public required string Genre { get; set; }
        public required ImageSource Photo { get; set; }
        public required List<Album> Albums { get; set; }
        public string Bio { get; set; }

    }
}
