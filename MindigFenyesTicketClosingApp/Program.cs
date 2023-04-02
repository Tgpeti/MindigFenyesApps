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
            while (!int.TryParse(Console.ReadLine(), out workerId) && workers.SingleOrDefault(m => m.Id == workerId,null) is null)
            {
                Console.WriteLine("Rossz azonosítót adtál meg, kérlek próbáld újra!");
            }
            var worker = context.Workers.SingleOrDefault(m => m.Id == workerId);
            Console.WriteLine($"Kedves {worker!.Name}, add meg az általad elvégzett javítás sorszámát!");
            int ticketId = -1;
            while (ticketId != 0)
            {
                List<Ticket> unfinishedTickets = context.Tickets.Where(t => t.IsFinished ==false).ToList();
                while (!int.TryParse(Console.ReadLine(), out ticketId) && unfinishedTickets.SingleOrDefault(m => m.Id == ticketId, null) is null)
                {
                    Console.WriteLine("Rossz sorszámot adtál meg, kérlek próbáld újra!");
                }
                Console.WriteLine("kérlek add meg a meghibásodás okát! (izzó, foglalat, vezeték, egyéb)");
                //while(Console.ReadLine() )
            }

        }
    }
}