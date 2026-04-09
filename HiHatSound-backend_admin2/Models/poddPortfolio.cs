using System.ComponentModel.DataAnnotations;

namespace HiHatSound_backend_admin2.Models
{

    public class PoddPortfolioModel
    {
        //attribut
        public int Id { get; set; }

        [Required]
        public string? Title { get; set; }

        [Required]
        [Url]
        public string? SpotifyLink { get; set; }

        [Required]
        public string? RssFeed { get; set; }

        [Required]
        public string? ImageUrl { get; set; }

    }
}