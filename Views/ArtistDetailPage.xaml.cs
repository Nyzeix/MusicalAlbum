using MusicalAlbum.Models;

namespace MusicalAlbum.Views;

public partial class ArtistDetailPage : ContentPage
{
	

    internal ArtistDetailPage(Artist artist)
    {
        BindingContext = artist;
        InitializeComponent();
    }
}