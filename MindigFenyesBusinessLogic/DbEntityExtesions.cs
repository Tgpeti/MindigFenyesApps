using MindigFenyesDB.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace MindigFenyesBusinessLogic
{
    public static class DbEntityExtesions
    {
        public static string GetIdAndAddress(this Ticket t)
        {
            return $"[{t.Id,-4}] - {t.Address.ZipCode}, {t.Address.StreetName} {t.Address.HouseNumber} ({t.StartDate.ToShortDateString()})";
        }
        public static string GetAllTicketInfo(this Ticket t)
        {
            return $"{t.Id} - - {t.Address.ZipCode}, {t.Address.StreetName} {t.Address.HouseNumber} - {t.Worker.Name} - {t.Issue}";
        }
    }
}
