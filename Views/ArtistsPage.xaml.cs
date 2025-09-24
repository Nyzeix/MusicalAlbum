using MusicalAlbum.ViewModel;
using MusicalAlbum.Models;

namespace MusicalAlbum.Views;

public partial class ArtistsPage : ContentPage
{
    public ArtistsPage()
    {
        InitializeComponent();
        BindingContext = new ArtistViewModel();
    }

    private void OnArtistSelected(object sender, SelectionChangedEventArgs e)
    {
        if (e.CurrentSelection.FirstOrDefault() is Artist selectedArtist)
        {
            Navigation.PushAsync(new ArtistDetailPage(selectedArtist));
        }
    }
}
