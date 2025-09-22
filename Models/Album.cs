using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace MusicalAlbum.Models
{
    internal class Album
    {
        public required UniqueId Id { get; set; }
        public required string Title { get; set; }
        public required List<Song> Songs { get; set; }
    }
}
