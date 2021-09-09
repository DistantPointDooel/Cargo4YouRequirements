using System.ComponentModel.DataAnnotations;

namespace Cargo4You.Services
{
    public class CreateParcelChecksDto
    {
        [Required]
        public int Width { get; set; }

        [Required]
        public int Height { get; set; }

        [Required]
        public int Depth { get; set; }

        [Required]
        public int Weight { get; set; }
    }
}
