using Microsoft.EntityFrameworkCore.Migrations.Operations;
using MindigFenyesDB.Data;
using MindigFenyesDB.Models;
using System.Security.Claims;

namespace MindigFenyesTicketClosingApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var context = new MindigFenyesContext();

            Console.WriteLine("Kérlek add meg az azonosítószámod!");
            int workerId;
            List<Worker> workers =context.Workers.ToList();
            while (!int.TryParse(Console.ReadLine(), out workerId) || workers.SingleOrDefault(m => m.Id == workerId) is null)
            {
                Console.WriteLine("Rossz azonosítót adtál meg, kérlek próbáld újra!");
            }
            var worker = context.Workers.SingleOrDefault(m => m.Id == workerId);
            Console.WriteLine($"Kedves {worker!.Name}, add meg az általad elvégzett javítás sorszámát!");
            int ticketId;
            while (true)
            {
                List<Ticket> unfinishedTickets = context.Tickets.Where(t => t.IsFinished == false).ToList();
                while (!int.TryParse(Console.ReadLine(), out ticketId) || unfinishedTickets.SingleOrDefault(m => m.Id == ticketId) is null && ticketId != 0)
                {
                    Console.WriteLine("Rossz sorszámot adtál meg, kérlek próbáld újra!");
                }
                if (ticketId ==0) //kilépés
                {
                    break;
                }
                Console.WriteLine("kérlek add meg a meghibásodás okát:");
                foreach (var value in Enum.GetValues(typeof(Issue)))
                {
                    Console.WriteLine($"[{(int)value}] --- {value}");
                }

                int issueId;
                
                while (!int.TryParse(Console.ReadLine(), out issueId) || issueId <0 || issueId >3)
                {
                    Console.WriteLine("Nem létező okot adtál meg!");
                }
                var ticketToClose = unfinishedTickets.Find(t => t.Id == ticketId);
                ticketToClose!.IsFinished = true;
                ticketToClose!.FinishDate = DateTime.Now;
                ticketToClose!.WorkerId = workerId;
                ticketToClose!.Issue = (Issue)issueId;
                context.SaveChanges();
                Console.WriteLine($"A {ticketId} sorszámú hibajegy lezárásra került!");
                Console.WriteLine("további hibajegy lezárásához add meg a sorszámát, vagy kilépés 0 megadásával:");
            }

        }
    }
}