using Core.Abstracts.Bases;
using Core.Concrates.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Concrates.Entities.Data
{
    [Table("tbl_galleries")]
    public class GalleryEntity : Base
    {
        public GalleryTypes GalleryType { get; set; }
        public string ContentId { get; set; }


    }
}
