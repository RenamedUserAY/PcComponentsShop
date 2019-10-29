using System.ComponentModel.DataAnnotations;

namespace PcComponentsShop.Domain.Core.Basic_Models
{
    public class VideoCard : Good
    {
        [Required]
        public string Interface { get; set; } = "no information";
        [Required]
        [Range(minimum: 1, maximum: int.MaxValue)]
        public int CoreFrequency { get; set; } = 1;
        [Required]
        [Range(minimum: 1, maximum: int.MaxValue)]
        public int CoreFrequencyBoost { get; set; } = 1;
        [Required]
        [Range(minimum: 1, maximum: int.MaxValue)]
        public int MemoryFrequency { get; set; } = 1;
        [Required]
        public string Connectors { get; set; } = "no information";
    }
}
