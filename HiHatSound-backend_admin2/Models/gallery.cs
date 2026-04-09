using System.ComponentModel.DataAnnotations;

namespace Gallery.Models
{
    public class GalleryModel
    {
        public int Id { get; set; }


        [Required]
        public string? ImageUrl { get; set; }
    }
}