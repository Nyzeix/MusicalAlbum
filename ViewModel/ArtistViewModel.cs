using MusicalAlbum.Models;
using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics.Metrics;
using System.Runtime.CompilerServices;

namespace MusicalAlbum.ViewModel
{
    public class ArtistViewModel : INotifyPropertyChanged // Permet de notifier la vue en cas de changement de données
    {
        public event PropertyChangedEventHandler PropertyChanged;


        private string searchText;
        private string selectedGenre = "All";
        private string selectedYear = "All";

        // Variable "Artist" utilisé pour le view
        public ObservableCollection<Artist> Artists { get; set; } = new();
        public List<Artist> AllArtists { get; set; } = new();  // Tout les artistes
        public List<string> YearList { get; set; } = new(); // Liste des années pour le filtre
        public List<string> GenreList { get; set; } = new(); // Liste des genres pour le filtre

        //ChatGPT a la rescousse 
        //Permet que, lorsque le "SearchText" change (lorsque l'on écrit dans la barre de recherche):
        //la valeur est modifiée (1)
        //la vue est notifiée du changement (2)
        //puis les filtres sont appliqués à la recherche (3)

        public string SearchText
        {
            get => searchText;
            set
            {
                if (searchText != value)
                {
                    searchText = value; //1
                    OnPropertyChanged(); //2
                    ApplyFilters(); //3
                }
            }
        }


        // On répète l'opération pour les autres filtres existants
        public string SelectedGenre
        {
            get => selectedGenre;
            set
            {
                if (selectedGenre != value)
                {
                    selectedGenre = value;
                    OnPropertyChanged();
                    ApplyFilters();
                }
            }
        }

        public string SelectedYear
        {
            get => selectedYear;
            set
            {
                if (selectedYear != value)
                {
                    selectedYear = value;
                    OnPropertyChanged();
                    ApplyFilters();
                }
            }
        }


        public ArtistViewModel()
        {
            // Liste de chansons bidons 
            List<Song> songs = new List<Song>
            {
                new Song { Id = 1, Title = "Song 1", Link = "youtube_link", Duration = 183, Genre = "Pop", TrackNumber = 1 },
                new Song { Id = 2, Title = "Song 2", Link = "youtube_link", Duration = 183, Genre = "Pop", TrackNumber = 2 },
                new Song { Id = 3, Title = "Song 3", Link = "youtube_link", Duration = 183, Genre = "Pop", TrackNumber = 3 },
            };

            // Liste des artistes
            AllArtists = new List<Artist>
            {
                new Artist
                {
                    Id=1, Name = "Céline Dion", Genre = "Pop",
                    Photo = ImageSource.FromFile("celine_dion_icon.jpg"),
                    Albums = new List<Album>
                    {
                        new Album { Id = 1, Title = "Album Céline", Cover = "cover1.jpg", Year = 1996, Genre = "Pop", Songs = songs }
                    }
                },
                new Artist
                {
                    Id=2, Name = "Stromae", Genre = "Pop",
                    Photo = ImageSource.FromFile("stromae_icon.jpeg"),
                    Albums = new List<Album>
                    {
                        new Album { Id = 2, Title = "Album Stromae", Cover = "cover2.jpg", Year = 2013, Genre = "Pop", Songs = songs }
                    }
                },
                new Artist
                {
                    Id=3, Name = "Nekfeu", Genre = "Rap",
                    Photo = ImageSource.FromFile("nekfeu_icon.jpg"),
                    Albums = new List<Album>
                    {
                        new Album { Id = 3, Title = "Album Nekfeu", Cover = "cover3.jpg", Year = 2015, Genre = "Rap", Songs = songs }
                    }
                }
            };

            // Liste des genres
            GenreList = new List<string>
            {
                "All",
                "Rap",
                "Rock",
                "Pop",
                "Jazz",
                "Classical",
                "Hip-Hop",
                "Country",
                "Electronic",
                "Reggae",
                "Blues",
                "Metal",
                "Folk",
                "Punk",
                "Soul",
                "RB",
                "Indie",
                "Alternative",
                "Disco",
                "Funk",
                "Ska",
            };
            GenreList.Sort();
            
            // Liste des années
            YearList.Add("All"); // Réinitialise le filtre
            for (int i = 1950; i <= DateTime.Today.Year; i++)
            {
                YearList.Add(i.ToString());
            }
            ApplyFilters();

        }

        private void ApplyFilters()
        {
            var filtered = AllArtists.AsEnumerable();

            // Filtre par recherche
            if (!string.IsNullOrWhiteSpace(SearchText))
                filtered = filtered.Where(artist => artist.Name.Contains(SearchText, StringComparison.OrdinalIgnoreCase));

            // Filtre par genre
            if (!string.IsNullOrWhiteSpace(SelectedGenre) && SelectedGenre != "All")
                filtered = filtered.Where(artist => artist.Genre == SelectedGenre);

            // Filtre par année
            /*if (!string.IsNullOrWhiteSpace(SelectedYear) && SelectedYear != "All")
            {
                // TODO (Année d'album ? d'artiste ?)
                filtered = filtered;
            }*/

            // Mettre à jour la collection observable
            Artists.Clear();
            foreach (var artist in filtered)
                Artists.Add(artist);
        }

        // Appelle la vue si une propriété évolue
        private void OnPropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
