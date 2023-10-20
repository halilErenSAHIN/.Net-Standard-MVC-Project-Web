using Core.Abstracts.Bases;
using Core.Concrates.Enums;
using System.ComponentModel.DataAnnotations.Schema;

namespace Core.Concrates.Entities.Game
{
    [Table("tbl_gameplatforms")]
    public class GamePlatformEntity : Base
    {
        [ForeignKey(nameof(Game))]
        public string GameId { get; set; }
        public virtual GameEntity Game { get; set; }
        public Platforms PlatformName { get; set; }
    }
}
