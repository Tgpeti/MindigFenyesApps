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
            DbQuerryMaker dbqm = new DbQuerryMaker();
            int numberForQuerry;
            List<Ticket> result = new List<Ticket>();

            Console.WriteLine("Lekérdezések típusai:");
            Console.WriteLine("- lekérdezés irányítószámra 4 jegyű szám megadásával");
            Console.WriteLine("- lekérdezés kerületre 3 jegyű szám megadásával");
            Console.WriteLine("- lekérdezés x napnál régebbi hibajegyekre 100-nál kisebb szám megadásával");
            Console.WriteLine("- kilépés 0 megadásával");
            Console.WriteLine();
            Console.WriteLine("Add meg a számot a lekérdezéshez!");

            while (true)
            {
                while (!int.TryParse(Console.ReadLine(), out numberForQuerry))
                {
                    Console.WriteLine("Add meg a számot a lekérdezéshez!");
                }
                if (numberForQuerry == 0)
                {
                    break;
                }
                else if (numberForQuerry <100)
                {
                   result = dbqm.OpenTicketsOlderThan(numberForQuerry);
                }
                else if (numberForQuerry >100 && numberForQuerry < 1000)
                {
                    result = dbqm.OpenTicketsFromDistrict(numberForQuerry);
                }
                else if (numberForQuerry >=1000 && numberForQuerry < 10000)
                {
                    result = dbqm.OpenTicketsFromZIPCode(numberForQuerry);
                }
                if (result.Count > 0)
                {
                    foreach (var ticket in result)
                    {
                        Console.WriteLine(ticket.GetIdAndAddress());
                    }
                }
                else
                {
                    Console.WriteLine("Sajnos nem találtunk a lekérdezésnek megfelelő elemet!");
                }
                
            }


        }
    }
}