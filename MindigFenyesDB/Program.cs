using MindigFenyesDB.Data;
using MindigFenyesDB.Models;

namespace MindigFenyesDB
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //AddWorker("Alma Aladár");
            //AddWorker("Banán Bála");
            //AddWorker("Citrom Cecil");
            //AddWorker("Dió Dániel");
            //AddWorker("Eper Elemér");

            void AddWorker(string name)
            {
                using (var context = new MindigFenyesContext())
                {
                    var worker = new Worker { Name = name };
                    context.Add(worker);
                    context.SaveChanges();
                }
            }
        }
    }
}