using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Core.Abstracts.Bases;

namespace Core.Concrates.Entities.Game
{
    [Table("tbl_players")]
    public class PlayerEntity : Base
    {
        [Required]
        public string UserId { get; set; }
        public virtual ICollection<GameEntity> Games { get; set; }
    }
}
