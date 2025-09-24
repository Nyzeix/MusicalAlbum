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
                new Song { Id = 2, Title = "Song 2", Link = "youtube_link", Duration = 250, Genre = "Rap", TrackNumber = 2 },
                new Song { Id = 3, Title = "Song 3", Link = "youtube_link", Duration = 343, Genre = "Pop", TrackNumber = 3 },
            };

            // Liste des artistes
            AllArtists = new List<Artist>
            {
                new Artist
                {
                    Id=1, Name = "Céline Dion", Genre = "Pop",
                    Photo = ImageSource.FromFile("celine_dion_icon.jpg"),
                    Bio = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Sed non risus. Suspendisse lectus tortor, dignissim sit amet, adipiscing nec, ultricies sed, dolor. Cras elementum ultrices diam. Maecenas ligula massa, varius a, semper congue, euismod non, mi. Proin porttitor, orci nec nonummy molestie, enim est eleifend mi, non fermentum diam nisl sit amet erat. Duis semper. Duis arcu massa, scelerisque vitae, consequat in, pretium a, enim. Pellentesque congue. Ut in risus volutpat libero pharetra tempor. Cras vestibulum bibendum augue. Praesent egestas leo in pede. Praesent blandit odio eu enim. Pellentesque sed dui ut augue blandit sodales. Vestibulum ante ipsum primis in faucibus orci luctus et ultrices posuere cubilia Curae; Aliquam nibh. Mauris ac mauris sed pede pellentesque fermentum. Maecenas adipiscing ante non diam sodales hendrerit.\r\nUt velit mauris, egestas sed, gravida nec, ornare ut, mi. Aenean ut orci vel massa suscipit pulvinar. Nulla sollicitudin. Fusce varius, ligula non tempus aliquam, nunc turpis ullamcorper nibh, in tempus sapien eros vitae ligula. Pellentesque rhoncus nunc et augue. Integer id felis. Curabitur aliquet pellentesque diam. Integer quis metus vitae elit lobortis egestas. Lorem ipsum dolor sit amet, consectetuer adipiscing elit. Morbi vel erat non mauris convallis vehicula. Nulla et sapien. Integer tortor tellus, aliquam faucibus, convallis id, congue eu, quam. Mauris ullamcorper felis vitae erat. Proin feugiat, augue non elementum posuere, metus purus iaculis lectus, et tristique ligula justo vitae magna.\r\n\r\nAliquam convallis sollicitudin purus. Praesent aliquam, enim at fermentum mollis, ligula massa adipiscing nisl, ac euismod nibh nisl eu lectus. Fusce vulputate sem at sapien. Vivamus leo. Aliquam euismod libero eu enim. Nulla nec felis sed leo placerat imperdiet. Aenean suscipit nulla in justo. Suspendisse cursus rutrum augue. Nulla tincidunt tincidunt mi. Curabitur iaculis, lorem vel rhoncus faucibus, felis magna fermentum augue, et ultricies lacus lorem varius purus. Curabitur eu amet.",
                    Albums = new List<Album>
                    {
                        new Album { Id = 5, Title = "Falling Into You", Cover = "cover1.jpg", Year = 1996, Genre = "Pop", Songs = songs }
                    }
                },
                new Artist
                {
                    Id=2, Name = "Stromae", Genre = "Pop",
                    Photo = ImageSource.FromFile("stromae_icon.jpeg"),
                    Bio = "Biographie de Stromae...",
                    Albums = new List<Album>
                    {
                        new Album { Id = 4, Title = "Racine Carré", Cover = "cover2.jpg", Year = 2013, Genre = "Pop", Songs = songs }
                    }
                },
                new Artist
                {
                    Id=3, Name = "Nekfeu", Genre = "Rap",
                    Photo = ImageSource.FromFile("nekfeu_icon.jpg"),
                    Bio = "Biographie de Nekfeu...",
                    Albums = new List<Album>
                    {
                        new Album { Id = 1, Title = "Feu", Cover = "nekfeu_feu.jpg", Year = 2015, Genre = "Rap", Songs = songs },
                        new Album { Id = 2, Title = "Cyborg", Cover = "nekfeu_cyborg.jpg", Year = 2016, Genre = "Rap", Songs = songs },
                        new Album { Id = 3, Title = "Les Étoiles Vagabondes", Cover = "nekfeu_les_etoiles_vagabondes.jpg", Year = 2019, Genre = "Rap", Songs = songs }
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
