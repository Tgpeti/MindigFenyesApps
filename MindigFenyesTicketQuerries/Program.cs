using MindigFenyesDB.Data;
using MindigFenyesDB.Models;
using System.Security.Cryptography.X509Certificates;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using MindigFenyesBusinessLogic;

namespace MindigFenyesTicketQuerries
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var context = new MindigFenyesContext();
            var ticketList = context.Tickets.Where(t => t.IsFinished == false).Include(t => t.Address).ToList();

            //var ticketsFromZip = OpenTicketsFromDistrict(111);
            //foreach (var item in ticketsFromZip)
            //{
            //    Console.WriteLine($"{item.Id} - {item.Address.ZipCode}, {item.Address.StreetName} {item.Address.HouseNumber}");
            //}
            var ticketsOlder = OpenTicketsOlderThan(1);
            foreach (var item in ticketsOlder)
            {
                Console.WriteLine(item.GetIdAndAddress());
            }

            List<Ticket> OpenTicketsFromZIPCode(int zipcode)
            {

                List<Ticket> results = ticketList.Where(t => t.Address.ZipCode == zipcode).OrderBy(t => t.StartDate).ToList();
                return results;

            }
            List<Ticket> OpenTicketsFromDistrict(int zipFirst3)
            {

                List<Ticket> results = ticketList.Where(t => t.Address.ZipCode >= zipFirst3 * 10 && t.Address.ZipCode < (zipFirst3 + 10) * 10).OrderBy(t => t.StartDate).ToList();
                return results;

            }

            List<Ticket> OpenTicketsOlderThan(int days) 
            {
                List<Ticket> results = ticketList.Where(t => t.StartDate < DateTime.Now.AddDays(days * -1)).OrderBy(t=> t.StartDate).ToList();
                return results;
            }
            




        }
    }
}