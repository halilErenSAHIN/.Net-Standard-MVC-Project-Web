using Core.Abstracts.Bases;
using Core.Concrates.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Core.Concrates.Entities.Data
{
    [Table("tbl_articles")]
    public class ArticleEntity : PublishBaseEntity
    {
        public ArticleTypes ArticleType { get; set; }
        [Required]
        public string ContentId { get; set; }
        public string FeatureMedia { get; set; }
        public string AuthorId { get; set; }
        public virtual AuthorEntity Author { get; set; }


    }
}
