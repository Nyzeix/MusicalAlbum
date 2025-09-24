using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using MusicalAlbum.Models;
namespace MusicalAlbum.ViewModel
{
    public  class ArtistDetailViewModel
    {
        public Artist Artist { get; set; }

        public ArtistDetailViewModel(Artist artist)
        {
            Artist = artist;
        }
    }
}
