using BlazorWasmClient.Shared.Enums;
using System.ComponentModel.DataAnnotations;

namespace BlazorWasmClient.Shared.DTOs
{
    public class TruckDto
    {
        [Required]
        [RegularExpression(@"^[0-9]{2}[A-Z]{2}[0-9]{4}$", ErrorMessage = "Invalid plate format. Example: 34AB1234")]
        public string LicensePlate { get; set; }

        [Required]
        public int ClaimedRawMaterialWeight { get; set; }

        [Required]
        [Range(0, double.MaxValue, ErrorMessage = "Weight must be a positive number")]
        public RawMaterialType RawMaterial { get; set; }

        public TruckState State { get; set; }
    }
}
