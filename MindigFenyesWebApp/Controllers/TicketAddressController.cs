using Microsoft.AspNetCore.Mvc;
using MindigFenyesWebApp.Models;

namespace MindigFenyesWebApp.Controllers
{
	public class TicketAddressController : Controller
	{
		
		public IActionResult Add()
		{
			return View();
		}
		public IActionResult Submit( TicketAddressViewModel ticketAddressRequest) 
		{

			return View();
		}

	}
}
