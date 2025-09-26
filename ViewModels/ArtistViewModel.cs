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

        // Variables de filtre
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
            // Sample songs for demonstration
            List<Song> songs = new List<Song>
            {
                new Song { Id = 1, Title = "Sample Song 1", Link = "", Duration = 210, TrackNumber = 1, Genre = "Pop" },
                new Song { Id = 2, Title = "Sample Song 2", Link = "", Duration = 180, TrackNumber = 2, Genre = "Rap" },
                new Song { Id = 3, Title = "Sample Song 3", Link = "", Duration = 240, TrackNumber = 3, Genre = "Hi-Hop" },
                new Song { Id = 4, Title = "Sample Song 4", Link = "", Duration = 200, TrackNumber = 4, Genre = "Blues" },
                new Song { Id = 5, Title = "Sample Song 5", Link = "", Duration = 230, TrackNumber = 5, Genre = "Rock" }
            };


            // Chansons de Céline Dion
            List<Song> Celine_Dion_Songs_Falling_Into_You = new List<Song>
            {
                new Song { Id = 501, Title = "It's All Coming Back to Me Now", Link = "", Duration = 448, TrackNumber = 1, Genre = "Pop" },
                new Song { Id = 502, Title = "Because You Loved Me", Link = "", Duration = 274, TrackNumber = 2, Genre = "Pop" },
                new Song { Id = 503, Title = "Falling into You", Link = "", Duration = 263, TrackNumber = 3, Genre = "Pop" },
                new Song { Id = 504, Title = "Make You Happy", Link = "", Duration = 292, TrackNumber = 4, Genre = "Pop" },
                new Song { Id = 505, Title = "Seduces Me", Link = "", Duration = 228, TrackNumber = 5, Genre = "Pop" },
                new Song { Id = 506, Title = "All by Myself", Link = "", Duration = 331, TrackNumber = 6, Genre = "Pop" },
                new Song { Id = 507, Title = "Declaration of Love", Link = "", Duration = 282, TrackNumber = 7, Genre = "Pop" },
                new Song { Id = 508, Title = "Dreamin' of You", Link = "", Duration = 303, TrackNumber = 8, Genre = "Pop" },
                new Song { Id = 509, Title = "I Love You", Link = "", Duration = 306, TrackNumber = 9, Genre = "Pop" },
                new Song { Id = 510, Title = "If That's What It Takes", Link = "", Duration = 265, TrackNumber = 10, Genre = "Pop" },
                new Song { Id = 511, Title = "I Don't Know", Link = "", Duration = 312, TrackNumber = 11, Genre = "Pop" },
                new Song { Id = 512, Title = "River Deep, Mountain High", Link = "", Duration = 244, TrackNumber = 12, Genre = "Pop" },
                new Song { Id = 513, Title = "Call the Man", Link = "", Duration = 370, TrackNumber = 13, Genre = "Pop" },
                new Song { Id = 514, Title = "Fly", Link = "", Duration = 156, TrackNumber = 14, Genre = "Pop" }
            };

            // Liste des artistes
            AllArtists = new List<Artist>
            {
                // Celine Dion template data
                new Artist
                {
                    Id=1, Name = "Céline Dion", Genre = "Pop",
                    Photo = "celine_dion_icon.jpg",
                    Bio = "Céline Dion (née le 30 mars 1968 à Charlemagne, au Québec) est une chanteuse canadienne. Dernière d'une famille de quatorze enfants, elle connaît un succès presque immédiat dans sa province d'origine, le Québec, dès 1981 avec la chanson Ce n'était qu'un rêve. Une série d'albums francophones, dans les années 1980, consolide sa popularité, alors que le titre D'amour ou d'amitié (1983) lui vaut une première exposition en France. Elle étend sa renommée en gagnant le Concours Eurovision de la chanson en 1988 durant lequel elle représente la Suisse avec la chanson Ne partez pas sans moi. Elle apprend ensuite l'anglais, change de style vestimentaire et signe un contrat chez Epic Records aux États-Unis. Son album anglophone, Unison, sort en 1990 et l'établit comme une artiste pop importante sur les marchés nord-américains et anglo-saxons.",
                    Albums = new List<Album>
                    {
                        new Album { Id = 1, Title = "Unison",            Cover = "unison.jpg",            Year = 1990, Genre = "Pop", Songs = songs },
                        new Album { Id = 2, Title = "Celine Dion",       Cover = "celine_dion_1992.jpg",  Year = 1992, Genre = "Pop", Songs = songs },
                        new Album { Id = 3, Title = "The Colour of My Love", Cover = "colour_of_my_love.jpg", Year = 1993, Genre = "Pop", Songs = songs },
                        new Album { Id = 4, Title = "D’eux",             Cover = "deux.jpg",              Year = 1995, Genre = "Pop", Songs = songs },
                        new Album { Id = 5, Title = "Falling Into You",  Cover = "falling_into_you.jpg",  Year = 1996, Genre = "Pop", Songs = Celine_Dion_Songs_Falling_Into_You },
                        new Album { Id = 6, Title = "Let’s Talk About Love", Cover = "lets_talk_about_love.jpg", Year = 1997, Genre = "Pop", Songs = songs },
                        new Album { Id = 7, Title = "A New Day Has Come", Cover = "a_new_day.jpg",        Year = 2002, Genre = "Pop", Songs = songs },
                        new Album { Id = 8, Title = "One Heart",         Cover = "one_heart.jpg",         Year = 2003, Genre = "Pop", Songs = songs },
                        new Album { Id = 9, Title = "Miracle",           Cover = "miracle.jpg",           Year = 2004, Genre = "Pop", Songs = songs },
                        new Album { Id = 10, Title = "Taking Chances",   Cover = "taking_chances.jpg",    Year = 2007, Genre = "Pop", Songs = songs },
                        new Album { Id = 11, Title = "Loved Me Back to Life", Cover = "loved_me_back.jpg", Year = 2013, Genre = "Pop", Songs = songs },
                        new Album { Id = 12, Title = "Courage",          Cover = "courage.jpg",           Year = 2019, Genre = "Pop", Songs = songs }
                    }
                },

                // Stromae template data
                new Artist
                {
                    Id=2, Name = "Stromae", Genre = "Pop",
                    Photo = "stromae_icon.jpeg",
                    Bio = "Stromae (nom de scène de Paul Van Haver, né le 12 mars 1985 à Etterbeek, Bruxelles-Capitale), est un chanteur, rappeur, auteur-compositeur-interprète et producteur belge d'origine rwandaise. Stromae se fait connaître en 2009 avec la chanson Alors on danse extraite de l'album Cheese. En parallèle, il crée le label Mosaert, afin d'assurer la production de ce premier album. Il se fera ensuite remarquer par un style mêlant thèmes mélancoliques et musiques dansantes. En 2013, son deuxième album Racine carrée est un succès critique et commercial majeur, avec des tubes comme Papaoutai, Formidable et Tous les mêmes. La tournée qui suit le fait connaître mondialement, avec plus de deux cents dates dans une vingtaine de pays, regroupant 1,6 million de spectateurs. À la suite d'un burn-out et d'importants problèmes de santé consécutifs à sa tournée, Stromae se fait discret sur la scène musicale et médiatique. De 2015 à 2021, il se consacre avant tout à son activité de producteur et travaille en parallèle sur les projets de son label Mosaert, dont une ligne prêt-à-porter unisexe. Il fait cependant plusieurs apparitions remarquées, notamment avec des featurings pour un single d'Orelsan, La Pluie, ou de Coldplay, Arabesque. Il fait son retour musical avec Santé en octobre 2021, puis L'Enfer, chanté en direct au 20 heures de TF1 en janvier 2022. Il sort son troisième album, Multitude, le 4 mars 2022. En août 2023, avec le clip de Papaoutai, il devient le deuxième artiste, après Dernière Danse de Indila, à dépasser le milliard de vues avec une chanson en langue française.",
                    Albums = new List<Album>
                    {
                        new Album
                        {
                            Id = 201,
                            Title = "Cheese",
                            Cover = "stromae_cheese_cover.jpg",
                            Year = 2010,
                            Genre = "Electronic / Hip-Hop",
                            Songs = new List<Song>
                            {
                                new Song { Id = 20101, Title = "Bienvenue chez moi", Link = "", Duration = 227, TrackNumber = 1, Genre = "Hip-Hop" },
                                new Song { Id = 20102, Title = "Te quiero", Link = "", Duration = 220, TrackNumber = 2, Genre = "Electronic" },
                                new Song { Id = 20103, Title = "Peace or Violence", Link = "", Duration = 215, TrackNumber = 3, Genre = "Hip-Hop" },
                                new Song { Id = 20104, Title = "Rail de musique", Link = "", Duration = 234, TrackNumber = 4, Genre = "Electronic" },
                                new Song { Id = 20105, Title = "Alors on danse", Link = "", Duration = 210, TrackNumber = 5, Genre = "Electronic" },
                                new Song { Id = 20106, Title = "Summertime", Link = "", Duration = 263, TrackNumber = 6, Genre = "Electronic" },
                                new Song { Id = 20107, Title = "Silence", Link = "", Duration = 207, TrackNumber = 7, Genre = "Hip-Hop" },
                                new Song { Id = 20108, Title = "Ave Cesaria", Link = "", Duration = 235, TrackNumber = 8, Genre = "World" },
                                new Song { Id = 20109, Title = "Je cours", Link = "", Duration = 240, TrackNumber = 9, Genre = "Hip-Hop" },
                                new Song { Id = 20110, Title = "House'llelujah", Link = "", Duration = 312, TrackNumber = 10, Genre = "Electronic" },
                                new Song { Id = 20111, Title = "Tous les mêmes", Link = "", Duration = 237, TrackNumber = 11, Genre = "Pop" }
                            }.OrderBy(s => s.TrackNumber).ToList()
                        },

                        new Album
                        {
                            Id = 202,
                            Title = "Racine Carrée",
                            Cover = "stromae_racine_carree_cover.jpg",
                            Year = 2013,
                            Genre = "Electronic / Hip-Hop",
                            Songs = new List<Song>
                            {
                                new Song { Id = 20201, Title = "Ta fête", Link = "", Duration = 178, TrackNumber = 1, Genre = "Electronic" },
                                new Song { Id = 20202, Title = "Papaoutai", Link = "", Duration = 219, TrackNumber = 2, Genre = "Pop" },
                                new Song { Id = 20203, Title = "Bâtard", Link = "", Duration = 200, TrackNumber = 3, Genre = "Hip-Hop" },
                                new Song { Id = 20204, Title = "Ave Cesaria", Link = "", Duration = 246, TrackNumber = 4, Genre = "World" },
                                new Song { Id = 20205, Title = "Tous les mêmes", Link = "", Duration = 229, TrackNumber = 5, Genre = "Pop" },
                                new Song { Id = 20206, Title = "Formidable", Link = "", Duration = 208, TrackNumber = 6, Genre = "Chanson française" },
                                new Song { Id = 20207, Title = "Moules frites", Link = "", Duration = 205, TrackNumber = 7, Genre = "Electronic" },
                                new Song { Id = 20208, Title = "Carmen", Link = "", Duration = 186, TrackNumber = 8, Genre = "Electronic" },
                                new Song { Id = 20209, Title = "Humain à l’eau", Link = "", Duration = 203, TrackNumber = 9, Genre = "Hip-Hop" },
                                new Song { Id = 20210, Title = "Quand c’est ?", Link = "", Duration = 200, TrackNumber = 10, Genre = "Pop" },
                                new Song { Id = 20211, Title = "Sommeil", Link = "", Duration = 232, TrackNumber = 11, Genre = "Hip-Hop" },
                                new Song { Id = 20212, Title = "Merci", Link = "", Duration = 207, TrackNumber = 12, Genre = "Hip-Hop" }
                            }.OrderBy(s => s.TrackNumber).ToList()
                        },

                        new Album
                        {
                            Id = 203,
                            Title = "Multitude",
                            Cover = "stromae_multitude_cover.jpg",
                            Year = 2022,
                            Genre = "Electronic / World / Pop",
                            Songs = new List<Song>
                            {
                                new Song { Id = 20301, Title = "Invaincu", Link = "", Duration = 161, TrackNumber = 1, Genre = "Pop" },
                                new Song { Id = 20302, Title = "Santé", Link = "", Duration = 186, TrackNumber = 2, Genre = "Pop" },
                                new Song { Id = 20303, Title = "La solassitude", Link = "", Duration = 197, TrackNumber = 3, Genre = "Electronic" },
                                new Song { Id = 20304, Title = "Fils de joie", Link = "", Duration = 216, TrackNumber = 4, Genre = "Pop" },
                                new Song { Id = 20305, Title = "L’enfer", Link = "", Duration = 212, TrackNumber = 5, Genre = "Chanson française" },
                                new Song { Id = 20306, Title = "C’est que du bonheur", Link = "", Duration = 208, TrackNumber = 6, Genre = "Pop" },
                                new Song { Id = 20307, Title = "Pas vraiment", Link = "", Duration = 182, TrackNumber = 7, Genre = "Electronic" },
                                new Song { Id = 20308, Title = "Riez", Link = "", Duration = 188, TrackNumber = 8, Genre = "Pop" },
                                new Song { Id = 20309, Title = "Mon amour", Link = "", Duration = 166, TrackNumber = 9, Genre = "Pop" },
                                new Song { Id = 20310, Title = "Déclaration", Link = "", Duration = 195, TrackNumber = 10, Genre = "Pop" },
                                new Song { Id = 20311, Title = "Bonne journée", Link = "", Duration = 181, TrackNumber = 11, Genre = "Pop" },
                                new Song { Id = 20312, Title = "Mauvaise journée", Link = "", Duration = 193, TrackNumber = 12, Genre = "Pop" }
                            }.OrderBy(s => s.TrackNumber).ToList()
                        }
                    }
                },

                // Nekfeu template data
                new Artist
                {
                    Id=3, Name = "Nekfeu", Genre = "Rap",
                    Photo = "nekfeu_icon.jpg",
                    Bio = "Nekfeu, de son vrai nom Ken Samaras, né le 3 avril 1990 à La Trinité (Alpes-Maritimes), est un rappeur (auteur-interprète), chanteur et acteur français d'origine grecque. Il est aussi, dans une moindre mesure, réalisateur et directeur de la photographie. Membre du groupe S-Crew, il appartient au collectif L'Entourage et a également fait partie du collectif 5 Majeur et du groupe 1995. Sorti en 2015, son premier album studio en solo, Feu, bénéficie d'une couverture médiatique importante ; pour cet album, il remporte en 2016 la Victoire de l'album de musiques urbaines. Son deuxième album, intitulé Cyborg, sort en 2016, et son troisième, Les Étoiles vagabondes, en 2019. Au cours de sa carrière, il a vendu plus de 2 millions d'albums et détient deux disques de diamant et un double disque de diamant pour ses trois albums studios. Il est considéré comme un des rappeurs les plus marquants du rap français, grâce au succès de ses albums, ses tubes, son aisance technique, et son influence sur toute une génération de rappeurs[1],[2].",
                    Albums = new List<Album>
                    {
                        new Album
                        {
                            Id = 301,
                            Title = "Feu",
                            Cover = "nekfeu_feu.jpg",
                            Year = 2015,
                            Genre = "Rap",
                            Songs = new List<Song>
                            {
                                new Song { Id = 30101, Title = "Égérie", Duration = 251, TrackNumber = 1, Genre = "Rap", Link = "https://youtu.be/B6WAlAzuJb4?si=O1nDZphBuesB5VCx" },
                                new Song { Id = 30102, Title = "On verra", Duration = 204, TrackNumber = 2, Genre = "Rap", Link = "https://youtu.be/GuDIenJQCgg?si=-VTVEhapL8YIO3tU" },
                                new Song { Id = 30103, Title = "Nique les clones, Pt. II", Duration = 230, TrackNumber = 3, Genre = "Rap", Link = "https://youtu.be/exMdGgqomYk?si=mAU5_Z7UrrERYM7u" },
                                new Song { Id = 30104, Title = "Tempête", Duration = 236, TrackNumber = 4, Genre = "Rap", Link = "https://youtu.be/gXRGuWsmTKc?si=pgZoMUeFXnGbnSp4" },
                                new Song { Id = 30105, Title = "Reuf", Duration = 287, TrackNumber = 5, Genre = "Rap", Link = "https://youtu.be/fWvmh2SpeyY?si=eGaRLJ2dOxTLz7c8" },
                                new Song { Id = 30106, Title = "Princesse", Duration = 250, TrackNumber = 6, Genre = "Rap", Link = "https://youtu.be/fUElA8dYbto?si=POZf6R4NfRTN5Kju" },
                                new Song { Id = 30107, Title = "Ma dope", Duration = 232, TrackNumber = 7, Genre = "Rap", Link = "https://youtu.be/kjuOUwPV2gY?si=uSPJXsnNrhv2TFab" },
                                new Song { Id = 30109, Title = "Risibles amours", Duration = 279, TrackNumber = 8, Genre = "Rap", Link = "https://youtu.be/RmS3oyRVG8k?si=OaVCpUg0-fEiv7pP" },
                                new Song { Id = 30110, Title = "Martin Eden", Duration = 327, TrackNumber = 9, Genre = "Rap", Link = "https://youtu.be/XeqImzpPk1k?si=-6hEOtDqpljhabi7" },
                                new Song { Id = 30111, Title = "Laisse aller", Duration = 292, TrackNumber = 10, Genre = "Rap", Link = "https://youtu.be/m8asYfMbzs4?si=hUIs_gcMp1yLLKJK" },
                                new Song { Id = 30112, Title = "Plume", Duration = 320, TrackNumber = 11, Genre = "Rap", Link = "https://youtu.be/cKr5Qy-iopw?si=7kAKZomb5SsUCNNK" },
                                new Song { Id = 30113, Title = "Rêve d’avoir des rêves", Duration = 248, TrackNumber = 12, Genre = "Rap", Link = "https://youtu.be/phIQMLzNnjw?si=3ZMXMaCx6CPEj16G" },
                                new Song { Id = 30115, Title = "2, 3", Duration = 241, TrackNumber = 13, Genre = "Rap", Link = "https://youtu.be/cKr5Qy-iopw?si=7kAKZomb5SsUCNNK" }
                            }.OrderBy(s => s.TrackNumber).ToList()
                        },

                        new Album
                        {
                            Id = 302,
                            Title = "Cyborg",
                            Cover = "nekfeu_cyborg.jpg",
                            Year = 2016,
                            Genre = "Rap",
                            Songs = new List<Song>
                            {
                                new Song { Id = 30201, Title = "Humanoïde", Duration = 270, TrackNumber = 1, Genre = "Rap", Link = "https://youtu.be/MiyIg__WNOw?si=awXRJu2Gk-4QG19v" },
                                new Song { Id = 30202, Title = "Mauvaise graine", Duration = 256, TrackNumber = 2, Genre = "Rap", Link = "https://youtu.be/F4c0ETM969k?si=7vejPx5WwtQUbEeO" },
                                new Song { Id = 30203, Title = "Squa", Duration = 278, TrackNumber = 3, Genre = "Rap", Link = "https://youtu.be/KJoLCREghZ0?si=Un7ZVr3W6DCwvHU5" },
                                new Song { Id = 30204, Title = "Réalité augmentée", Duration = 251, TrackNumber = 4, Genre = "Rap", Link = "https://youtu.be/WCDZvKDDb2I?si=ng0Hksw7c7KFixTJ" },
                                new Song { Id = 30205, Title = "Avant tu riais", Duration = 301, TrackNumber = 5, Genre = "Rap", Link = "https://youtu.be/t1c9hRfCu1w?si=J4FkmDDPegICdbuw" },
                                new Song { Id = 30206, Title = "Esquimaux", Duration = 258, TrackNumber = 6, Genre = "Rap", Link = "https://youtu.be/j3S34_kfujo?si=yU6d5rhH8HbRsr1U" },
                                new Song { Id = 30207, Title = "O.D", Duration = 260, TrackNumber = 7, Genre = "Rap", Link = "https://youtu.be/zZlCVlM-ewQ?si=-6u2UCu3DSaBUGkL" },
                                new Song { Id = 30208, Title = "Vinyle", Duration = 243, TrackNumber = 8, Genre = "Rap", Link = "https://youtu.be/ixQtCf-x630?si=I-q5pXf7_OqYyiFq" },
                                new Song { Id = 30209, Title = "Saturne", Duration = 295, TrackNumber = 9, Genre = "Rap", Link = "https://youtu.be/xqiVtwT4LcE?si=QislTRGu4K_7vmY8" },
                                new Song { Id = 30210, Title = "Galatée", Duration = 283, TrackNumber = 10, Genre = "Rap", Link = "https://youtu.be/ViCL1jMZNHc?si=dy-jizaiTZKFfiCn" },
                                new Song { Id = 30211, Title = "Le regard des gens", Duration = 262, TrackNumber = 11, Genre = "Rap", Link = "https://youtu.be/V_S-bDdY1lA?si=RPj0u2TjWqZCmpcM" },
                                new Song { Id = 30212, Title = "Programmé", Duration = 217, TrackNumber = 12, Genre = "Rap", Link = "https://youtu.be/2GTtx0UOLII?si=6wKVFels8ypT8Djx" },
                                new Song { Id = 30213, Title = "Besoin de sens", Duration = 242, TrackNumber = 13, Genre = "Rap", Link = "https://youtu.be/fBEL__z-WwM?si=Q7AFBtGB7h8lk9xd" },
                                new Song { Id = 30214, Title = "Nekketsu", Duration = 247, TrackNumber = 14, Genre = "Rap", Link = "https://youtu.be/J4CKkE3EBm8?si=DWNJL4W1ShTQQPTM" },
                            }.OrderBy(s => s.TrackNumber).ToList()
                        },

                        new Album
                        {
                            Id = 303,
                            Title = "Les Étoiles Vagabondes",
                            Cover = "nekfeu_les_etoiles_vagabondes.jpg",
                            Year = 2019,
                            Genre = "Rap",
                            Songs = new List<Song>
                            {
                                new Song { Id = 30301, Title = "Les étoiles vagabondes", Duration = 249, TrackNumber = 1, Genre = "Rap", Link = "" },
                                new Song { Id = 30302, Title = "Tricheur (feat. Damso)", Duration = 236, TrackNumber = 2, Genre = "Rap", Link = "" },
                                new Song { Id = 30303, Title = "Dans l’univers (feat. Vanessa Paradis)", Duration = 229, TrackNumber = 3, Genre = "Rap", Link = "" },
                                new Song { Id = 30304, Title = "Alunissons", Duration = 243, TrackNumber = 4, Genre = "Rap", Link = "" },
                                new Song { Id = 30305, Title = "Takotsubo", Duration = 255, TrackNumber = 5, Genre = "Rap", Link = "" },
                                new Song { Id = 30306, Title = "Voyager léger", Duration = 246, TrackNumber = 6, Genre = "Rap", Link = "" },
                                new Song { Id = 30307, Title = "Ciel noir", Duration = 241, TrackNumber = 7, Genre = "Rap", Link = "" },
                                new Song { Id = 30308, Title = "Chanson d’amour", Duration = 258, TrackNumber = 8, Genre = "Rap", Link = "" },
                                new Song { Id = 30309, Title = "De mon mieux", Duration = 244, TrackNumber = 9, Genre = "Rap", Link = "" },
                                new Song { Id = 30310, Title = "Élévation", Duration = 250, TrackNumber = 10, Genre = "Rap", Link = "" },
                                new Song { Id = 30311, Title = "Sous les nuages", Duration = 242, TrackNumber = 11, Genre = "Rap", Link = "" },
                                new Song { Id = 30312, Title = "Le bruit qui court", Duration = 236, TrackNumber = 12, Genre = "Rap", Link = "" },
                                new Song { Id = 30313, Title = "Menteur", Duration = 233, TrackNumber = 13, Genre = "Rap", Link = "" },
                                new Song { Id = 30314, Title = "L’autre blanc", Duration = 238, TrackNumber = 14, Genre = "Rap", Link = "" },
                                new Song { Id = 30315, Title = "Amour plastique", Duration = 240, TrackNumber = 15, Genre = "Rap", Link = "" },
                                new Song { Id = 30316, Title = "On verra bien", Duration = 254, TrackNumber = 16, Genre = "Rap", Link = "" }
                            }.OrderBy(s => s.TrackNumber).ToList()
                        }
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
