using MusicalAlbum.Models;
using MusicalAlbum.ViewModel;

namespace MusicalAlbum.Views;

public partial class ArtistDetailPage : ContentPage
{
    private Artist Artist;

    private bool _isExpanded = false;

    public ArtistDetailPage(Artist artist)
    {
        InitializeComponent();
        Artist = artist;
        BindingContext = new ArtistDetailViewModel(artist);
    }

    private void OnAlbumSelected(object sender, SelectionChangedEventArgs e)
    {
        if (e.CurrentSelection.FirstOrDefault() is Album selectedAlbum)
        {
            // Navigation vers la page de détail album
            Navigation.PushAsync(new AlbumDetailPage(selectedAlbum, Artist));
        }
    }

    private void OnSeeMoreClicked(object sender, EventArgs e)
    {
        if (_isExpanded)
        {
            BioLabel.MaxLines = 3;
            SeeMoreButton.Text = "Voir plus";
        }
        else
        {
            BioLabel.MaxLines = int.MaxValue;
            SeeMoreButton.Text = "Voir moins";
        }
        _isExpanded = !_isExpanded;
    }
}
