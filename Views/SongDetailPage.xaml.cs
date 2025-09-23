using MusicalAlbum.Models;

namespace MusicalAlbum.Views;

public partial class SongDetailPage : ContentPage
{
	public SongDetailPage(Album album)
	{
		BindingContext = album;
		InitializeComponent();
        // Can also set BindingContext in XAML ?
        //var AlbumName = album.Title;
        //var AlbumYear = album.Year;
        var Songs = album.Songs;
		// Bind Songs to collectionsView

    }
}