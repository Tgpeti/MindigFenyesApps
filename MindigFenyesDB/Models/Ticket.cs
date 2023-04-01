using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MindigFenyesDB.Models
{
    public class Ticket
	{
		public int Id { get; set; }
		public int AddressId { get; set; }
		public virtual Address Address { get; set; } = null!;
		public DateTime StartDate { get; set; }
		public bool IsFinished { get; set; }
		public int WorkerId { get; set; }
		public  virtual Worker? Worker { get; set; }
		public DateTime FinishDate { get; set; }
		public Issue Issue { get; set; }


	}
}
