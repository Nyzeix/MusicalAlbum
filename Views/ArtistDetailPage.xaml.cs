using MusicalAlbum.Models;
using MusicalAlbum.ViewModel;

namespace MusicalAlbum.Views;

public partial class ArtistDetailPage : ContentPage
{
    public ArtistDetailPage(Artist artist)
    {
        InitializeComponent();
        BindingContext = new ArtistDetailViewModel(artist);
    }

    private void OnAlbumSelected(object sender, SelectionChangedEventArgs e)
    {
        if (e.CurrentSelection.FirstOrDefault() is Album selectedAlbum)
        {
            // Navigation vers la page de d�tail album
            Navigation.PushAsync(new AlbumDetailPage(selectedAlbum));
        }
    }
}
