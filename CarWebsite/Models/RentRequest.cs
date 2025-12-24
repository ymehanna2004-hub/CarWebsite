public class RentRequest
{
    public int Id { get; set; }
    public string FullName { get; set; }
    public string PhoneNumber { get; set; }
    public DateTime Birthdate { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }

    public int Car_Id { get; set; } //foreign-key
}