using System.ComponentModel.DataAnnotations;

namespace PcComponentsShop.Domain.Core.Basic_Models
{
    public class ComputerCase:Good
    {
        [Required]
        public string CaseType { get; set; } = "no information";
        [Required]
        public string FormFactor { get; set; } = "no information";
        [Required]
        public string PowerSupply { get; set; } = "no information";
        [Required]
        public string Features { get; set; } = "no information";
        [Required]
        [Range(minimum: 1, maximum: int.MaxValue)]
        public int MaxCpuCoolerHeight { get; set; } = 1;
        [Required]
        [Range(minimum: 1, maximum: int.MaxValue)]
        public int MaxVideoCardLength { get; set; } = 1;
    }
}
