using Core.Enums;

namespace Core.Entities
{
    public class Truck
    {
        public int Id { get; set; }
        public string LicensePlate { get; set; }
        public decimal ClaimedRawMaterialWeight { get; set; }
        public RawMaterialType RawMaterial { get; set; }
        public decimal FirstWeighing { get; set; }
        public decimal SecondWeighing { get; set; }
        public TruckState State { get; set; }
        public bool IsVisibleOnList { get; set; }
    }
}
