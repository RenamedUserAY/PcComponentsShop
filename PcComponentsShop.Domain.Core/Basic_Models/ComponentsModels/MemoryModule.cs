using System.ComponentModel.DataAnnotations;

namespace PcComponentsShop.Domain.Core.Basic_Models
{
    public class MemoryModule : Good
    {
        [Required]
        [Range(minimum: 1, maximum: int.MaxValue)]
        public int MemoryCapacity { get; set; } = 1;
        [Required]
        public string MemoryType { get; set; } = "no information";
        [Required]
        [Range(minimum: 1, maximum: int.MaxValue)]
        public int OperatingFrequency { get; set; } = 1;
        [Required]
        [Range(minimum: 0.01f, maximum: float.MaxValue)]
        public float OperatingVoltage { get; set; } = 0.01f;
        [Required]
        public string Timings { get; set; } = "no information";
    }
}
