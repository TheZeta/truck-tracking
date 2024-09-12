using BlazorWasmClient.Shared.Enums;
using System.ComponentModel.DataAnnotations;

namespace BlazorWasmClient.Shared.DTOs
{
    public class TruckDto
    {
        [Required]
        [RegularExpression(@"^[0-9]{2}[A-Z]{2}[0-9]{4}$", ErrorMessage = "Invalid plate format. Example: 34AB1234")]
        public string Plate { get; set; }

        [Required]
        [Range(0, int.MaxValue, ErrorMessage = "Weight must be a positive number")]
        public int Weight { get; set; }

        [Required]
        public RawMaterialType RawMaterial { get; set; }

        public TruckState State { get; set; }
    }
}
