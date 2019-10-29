using System.ComponentModel.DataAnnotations;

namespace PcComponentsShop.Domain.Core.Basic_Models
{
    public class SSDDrive : Good
    {
        [Required]
        public string CellMemoryType { get; set; } = "no information";
        [Required]
        public string Capacity { get; set; } = "no information";
        [Required]
        public string FormFactor { get; set; }= "no information";
        [Required]
        public string ConnectionInterface { get; set; }= "no information";
        [Required]
        public string ReadingSpeed { get; set; }= "no information";
    }
}
