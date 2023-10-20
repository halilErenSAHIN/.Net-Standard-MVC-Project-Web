using Core.Abstracts.Bases;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Concrates.Entities.Game
{
    [Table("tbl_publishers")]
    public class PublisherEntity : Base
    {
        public string FeatureMedia { get; set; }
        public string Logo { get; set; }
        public string Description { get; set; }

        public virtual ICollection<GameEntity> Games { get; set; }
    }
}
