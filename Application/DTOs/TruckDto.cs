using Core.Enums;

namespace Application.DTOs
{
    public class TruckDto
    {
        public string LicensePlate { get; set; }
        public int ClaimedRawMaterialWeight { get; set; }
        public RawMaterialType RawMaterial { get; set; }
        public TruckState State { get; set; }
    }
}
