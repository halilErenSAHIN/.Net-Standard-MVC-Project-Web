using Core.Abstracts.Bases;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Concrates.Entities.Game
{
    [Table("tbl_developers")]
    public class DeveloperEntity : Base
    {
        public virtual ICollection<GameEntity> Games { get; set; }



    }
}
