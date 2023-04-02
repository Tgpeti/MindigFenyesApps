using Microsoft.EntityFrameworkCore;
using MindigFenyesDB.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MindigFenyesDB.Data
{
	public class MindigFenyesContext :DbContext
	{
		public MindigFenyesContext(DbContextOptions options) : base(options)
		{
		}
		public DbSet<Ticket> Tickets { get; set; }
		public DbSet<Address> Addresses { get; set; }
		public DbSet<Worker> Workers { get; set; }
		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) 
		{
			optionsBuilder.UseSqlServer("Server = localhost; Database=master; Initial Catalog = MindigFenyesDB; Trusted_Connection=True;");
		}
	}
}
