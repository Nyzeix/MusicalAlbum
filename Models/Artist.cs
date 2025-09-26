namespace MusicalAlbum.Models
{
    public class Artist
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Genre { get; set; }
        public string Photo { get; set; }
        public List<Album> Albums { get; set; }
        public string Bio { get; set; }

        public bool IsFavorite { get; set; }

    }
}
