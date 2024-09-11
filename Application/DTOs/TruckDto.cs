using Core.Enums;

namespace Application.DTOs
{
    public class TruckDto
    {
        public string LicensePlate { get; set; }
        public decimal ClaimedRawMaterialWeight { get; set; }
        public RawMaterialType RawMaterial { get; set; }
    }
}
