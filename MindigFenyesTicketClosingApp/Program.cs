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

            Console.WriteLine("kérlek add meg az azonosítószámod");
            int workerId = 0;
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
                if (ticketId ==0)
                {
                    break;
                }
                Console.WriteLine("kérlek add meg a meghibásodás okát:");
                Console.WriteLine("0  ---  Izzó");
                Console.WriteLine("1  ---  Foglalat");
                Console.WriteLine("2  ---  Vezetékek");
                Console.WriteLine("3  ---  Egyéb");
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
                Console.WriteLine("további hibajegy lezárásához adja meg a sorszámát, vagy kilépés 0 megadásával:");
            }

        }
    }
}