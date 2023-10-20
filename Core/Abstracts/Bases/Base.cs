using System;
using System.ComponentModel.DataAnnotations;

namespace Core.Abstracts.Bases
{
    public abstract class Base
    {
        [Key]
        public string Id { get; set; } = Guid.NewGuid().ToString("N");

        [Required, MaxLength(150)]
        public string Title { get; set; }

        public DateTime CreateTime { get; set; } = DateTime.Now;

        public Nullable<DateTime> UpdateTime { get; set; }

        public Nullable<DateTime> DeleteTime { get; set; }

        public bool Active { get; set; } = true;

        public bool Deleted { get; set; } = false;


    }
}
