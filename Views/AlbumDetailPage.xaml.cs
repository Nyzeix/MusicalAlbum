using MusicalAlbum.Models;
using MusicalAlbum.ViewModel;

namespace MusicalAlbum.Views;

public partial class AlbumDetailPage : ContentPage
{
    private Artist Artist;
    private Album Album;
    public AlbumDetailPage(Album selectedAlbum, Artist artist)
    {
		InitializeComponent();
        Album = selectedAlbum;
        Artist = artist; // Get artist in case I want to show more information about the artist in this album page
        BindingContext = new AlbumViewModel(Album);
    }

    // Fonction de conversion du temps en secondes vers mm:ss

}