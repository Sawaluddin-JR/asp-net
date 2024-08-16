namespace Vehicles.Models
{
    public class VehicleType
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int BrandId { get; set; }
        public VehicleBrand Brand { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public DateTime? DeletedAt { get; set; }
    }
}
