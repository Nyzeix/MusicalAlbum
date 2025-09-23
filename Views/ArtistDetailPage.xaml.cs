using MusicalAlbum.Models;

namespace MusicalAlbum.Views;

public partial class ArtistDetailPage : ContentPage
{
	

    internal ArtistDetailPage(Artist artist)
    {
        BindingContext = artist;
        InitializeComponent();

        var ArtistName = artist.Name;

        // Get albums for the artist and bind to CollectionView

        // 
    }
}