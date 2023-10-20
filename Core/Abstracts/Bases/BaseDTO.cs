using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Abstracts.Bases
{
    public abstract class BaseDTO
    {
        [Display(Name = "Identity")]
        public string Id { get; set; }

        [Display(Name = "Title")]
        [Required]
        [MaxLength(150)]
        [MinLength(3)]
        [RegularExpression(@"[\w\s,.?!]+")]

        public string Title { get; set; }



    }
}
