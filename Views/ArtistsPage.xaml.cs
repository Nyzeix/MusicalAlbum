

using MusicalAlbum.Models;

namespace MusicalAlbum.Views;

public partial class ArtistsPage : ContentPage
{
	public ArtistsPage()
	{
		InitializeComponent();

		var YearList = new List<string>();
        //this.BindingContext = new ViewModels.ArtistsViewModel();
        for (int i = 1950; i<=DateTime.Today.Year ; i++) YearList.Add(i.ToString());

        artistYear.ItemsSource = YearList;

        // Get from viewModel all artists, bind to CollectionView
        /*Example
         * 
		private void OnAddTaskClicked(object? sender, EventArgs e)
        {
            // Is string null or empty
            if (!string.IsNullOrWhiteSpace(taskEntry.Text))
            {
                _todoItems.Add(new TodoItem
                    {
                        title = taskEntry.Text,
                        isCompleted = false
                    }
                    );
                taskEntry.Text = string.Empty; // Clear the entry after adding
            }

        }
		 */
    }
    private void OnArtistSelected(object sender, SelectionChangedEventArgs e)
	{
		if (e.CurrentSelection.FirstOrDefault() is Artist selectedArtist)
		{
			// Navigate to the ArtistDetailPage and pass the selected artist
			Navigation.PushAsync(new ArtistDetailPage(selectedArtist));
		}
    }

	private void OnSearchTextChanged(object sender, TextChangedEventArgs e)
	{
        //TODO: Implement search functionality with viewModel
    }
}