using Core.Abstracts.Bases;
using Core.Concrates.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Core.Concrates.Entities.Data
{
    [Table("tbl_medias")]
    public class MediaEntity : Base
    {
        public MediaTypes MediaType { get; set; }
        public string Path { get; set; }
        [Required]
        public string UserId { get; set; }
        public string GalleryId { get; set; }

    }
}
