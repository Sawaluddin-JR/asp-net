namespace Vehicles.Models
{
    public class PriceList
    {
        public int Id { get; set; }
        public string Code { get; set; }
        public int Price { get; set; }
        public int YearId { get; set; }
        public VehicleYear Year { get; set; }
        public int ModelId { get; set; }
        public VehicleModel Model { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public DateTime? DeletedAt { get; set; }
    }
}
