using Microsoft.AspNetCore.Mvc;

namespace CarWebsite.Models
{
    public class Cars
    {
        public int Id { get; set; }
        public string Brand { get; set; }
        public string Model { get; set; }
        public int Year { get; set; }
        public string Type { get; set; }
        public string Description { get; set; }
        public string ExteriorColor { get; set; }
        public string InteriorColor { get; set; }
        public decimal PricePerDay { get; set; }
        public string Image_Url { get; set; }
        public string PlateNumber { get; set; }
        

        public DateTime Created_At { get; set; } 
    }
}
