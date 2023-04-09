using Microsoft.AspNetCore.Mvc;
using MindigFenyesDB.Data;
using MindigFenyesDB.Models;
using MindigFenyesWebApp.Models;

namespace MindigFenyesWebApp.Controllers
{
    public class TicketAddressController : Controller
    {
        private readonly MindigFenyesContext mfcontext;

        public TicketAddressController(MindigFenyesContext mfcontext)
        {
            this.mfcontext = mfcontext;
        }

        public IActionResult Add()
        {
            return View();
        }
        public IActionResult Submit(TicketAddressViewModel ticketAddressRequest)
        {
            Address? address = mfcontext.Addresses.SingleOrDefault(t => t.ZipCode == ticketAddressRequest.ZipCode && t.StreetName.Equals(ticketAddressRequest.StreetName) && t.HouseNumber == ticketAddressRequest.HouseNumber);

            Ticket ticket = new Ticket
            {
                Address = address??= new Address
                {
                    ZipCode = ticketAddressRequest.ZipCode,
                    StreetName = ticketAddressRequest.StreetName,
                    HouseNumber = ticketAddressRequest.HouseNumber
                },
                StartDate = DateTime.Now,
                IsFinished = false,
            }; 

            mfcontext.Tickets.Add(ticket);
            mfcontext.SaveChanges();

            return View();
        }

    }
}
