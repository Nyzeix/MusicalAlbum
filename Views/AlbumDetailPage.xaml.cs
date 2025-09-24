using MusicalAlbum.Models;
using MusicalAlbum.ViewModel;
using System.Globalization;

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

    // Lance Youtube quand la tuile de chanson est cliquée
    private async void OnSongTapped(object sender, TappedEventArgs e)
    {
        if ((sender as Grid)?.BindingContext is Song song && !string.IsNullOrEmpty(song.Link))
        {
            try
            {
                // Ouvre l'application YouTube ou le navigateur
                await Launcher.OpenAsync(song.Link);
            }
            catch (Exception ex)
            {
                await DisplayAlert("Erreur", $"Impossible d'ouvrir YouTube : {ex.Message}", "OK");
            }
        }
    }
}