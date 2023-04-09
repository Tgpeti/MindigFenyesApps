using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MindigFenyesDB.Data;
using MindigFenyesDB.Models;

namespace MindigFenyesBusinessLogic
{
    public class DbQuerryMaker
    {
        private readonly MindigFenyesContext _context;
        public DbQuerryMaker()
        {
            _context = new MindigFenyesContext();
        }
        public List<Ticket> OpenTicketsFromZIPCode(int zipcode)
        {
            var openTicketsWithAddress = _context.Tickets.Where(t => t.IsFinished ==false).Include(t=> t.Address).ToList();
            List<Ticket> results = openTicketsWithAddress.Where(t => t.Address.ZipCode == zipcode).OrderBy(t => t.StartDate).ToList();
            return results;
        }
        public List<Ticket> OpenTicketsFromDistrict(int zipFirst3)
        {
            var openTicketsWithAddress = _context.Tickets.Where(t => t.IsFinished == false).Include(t => t.Address).ToList();
            List<Ticket> results = openTicketsWithAddress.Where(t => t.Address.ZipCode >= zipFirst3 * 10 && t.Address.ZipCode < (zipFirst3 + 10) * 10).OrderBy(t => t.StartDate).ToList();
            return results;
        }
        public List<Ticket> OpenTicketsOlderThan(int days)
        {
            var openTicketsWithAddress = _context.Tickets.Where(t => t.IsFinished == false).Include(t => t.Address).ToList();
            List<Ticket> results = openTicketsWithAddress.Where(t => t.StartDate < DateTime.Now.AddDays(days * -1)).OrderBy(t => t.StartDate).ToList();
            return results;
        }
    }
}
