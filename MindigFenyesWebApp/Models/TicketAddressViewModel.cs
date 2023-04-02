namespace MindigFenyesWebApp.Models
{
    public class TicketAddressViewModel
    {
        public int ZipCode { get; set; }
        public string StreetName { get; set; } = null!;
        public int HouseNumber { get; set; }
    }
}
