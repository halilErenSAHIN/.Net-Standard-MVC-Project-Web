using Core.Abstracts.Bases;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Core.Concrates.Entities.Data
{
    [Table("tbl_authors")]
    public class AuthorEntity: Base
    {
        [Required]
        public string UserId { get; set; }
        public virtual ICollection<ArticleEntity> Articles { get; set; }


    }
}
