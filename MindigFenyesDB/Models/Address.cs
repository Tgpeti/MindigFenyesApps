using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MindigFenyesDB.Models
{
	public class Address
	{
		public int Id { get; set; }
		public int ZipCode { get; set; }
		public string StreetName { get; set; } = null!;
		public int HouseNumber { get; set; }

	}
}
