using System.ComponentModel.DataAnnotations;

namespace PcComponentsShop.Domain.Core.Basic_Models
{
    public class PowerSupply : Good
    {
        [Required]
        public string FormFactor { get; set; } = "no information";
        [Required]
        [Range(minimum: 1, maximum: int.MaxValue)]
        public int Power { get; set; }= 1;
        [Required]
        public string Certification { get; set; }= "no information";
        [Required]
        public string Cooling { get; set; }= "no information";
        [Required]
        public string Features { get; set; }= "no information";
    }
}
