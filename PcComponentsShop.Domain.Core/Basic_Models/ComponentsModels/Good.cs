using System;
using System.ComponentModel.DataAnnotations;

namespace PcComponentsShop.Domain.Core.Basic_Models
{
    public class Good
    {
        [Key]
        public virtual int ID { get; set; }
        [Required]
        public virtual string FullName { get; set; } = "no information";
        [Required]
        [Range(minimum: 0, maximum: int.MaxValue)]
        public virtual int Price { get; set; } = 0;
        [Required]
        public virtual string Brand { get; set; } = "no information";
        [Required]
        public virtual string Category { get; set; }
        [Required]
        public virtual string ImgSrc { get; set; } = "no information";
        [Required]
        public virtual DateTime ProducedAt { get; set; } = DateTime.Now;
        [Required]
        public virtual string Model { get; set; } = "no information";
    }
}
