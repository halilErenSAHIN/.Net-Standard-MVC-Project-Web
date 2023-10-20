using Core.Abstracts.Bases;
using Core.Concrates.Enums;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Core.Concrates.Entities.Game
{
    [Table("tbl_games")]
    public class GameEntity : PublishBaseEntity
    {
        [Required]
        public string FeatureMedia { get; set; }
        public string Logo { get; set; }

        [ForeignKey(nameof(Developer))]
        public string DeveloperId { get; set; }
        public virtual DeveloperEntity Developer { get; set; }

        [ForeignKey(nameof(Publisher))]
        public string PublisherId { get; set; }
        public virtual PublisherEntity Publisher { get; set; }

        public virtual ICollection<GamePlatformEntity> Platforms { get; set; }
        public Ratings Rating { get; set; }
        public Status Status { get; set; }

        public virtual ICollection<PlayerEntity> Players { get; set; }
        public virtual ICollection<GenreEntity> Genres { get; set; }
    }
}
