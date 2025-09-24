using MusicalAlbum.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicalAlbum.ViewModel
{
    public class AlbumViewModel
    {
        public Album Album { get; set; }

        public AlbumViewModel(Album album)
        {
            Album = album;
        }
    }
}
