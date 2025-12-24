using Microsoft.AspNetCore.Mvc;

namespace CarWebsite.Models
{
    public class statistics 
    {
        public int TotalCars { get; set; }
        public int AvailableCars { get; set; }
        public int RentedCars { get; set; }
        public int PendingRequests { get; set; }
        public int TotalCustomers { get; set; }
    }
}
