﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Abstracts.Bases
{
    public class PublishBaseEntity : Base
    {
        public string Description { get; set; }
        public Nullable<DateTime> PublishDate { get; set; }
        public bool Draft { get; set; }
        [MaxLength(500)]
        public string SubTitle { get; set; }

    }
}
