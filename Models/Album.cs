namespace MusicalAlbum.Models
{
    public class Album
    {
        public int Id { get; set; }
        public string Title { get; set; }

        public List<Song> Songs { get; set; }
        public string Cover { get; set; } // URL or file path to the album cover image
        public int Year { get; set; }
        public string Genre { get; set; }
    }
}
