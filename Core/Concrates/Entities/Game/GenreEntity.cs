using Core.Abstracts.Bases;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Core.Concrates.Entities.Game
{
    [Table("tbl_genres")]
    public class GenreEntity : Base
    {
        public string Description { get; set; }
        public string Icon { get; set; }
        public virtual ICollection<GameEntity> Games { get; set; }
    }
}
