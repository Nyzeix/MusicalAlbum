using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace MusicalAlbum.Models
{
    internal class Artist
    {
        public required UniqueId Id { get; set; }
        public required string Name { get; set; }
        public required string Genre { get; set; }
        public required string Photo { get; set; }
        public required List<Album> Albums { get; set; }


    }
}
