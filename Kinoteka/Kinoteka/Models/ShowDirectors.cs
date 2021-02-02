using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kinoteka.Models
{
	public class ShowDirectors
	{
		public int showId { get; set; }
		public int directorId { get; set; }
		public Show show { get; set; }
		public List<Director> directors { get; set; }

		public ShowDirectors()
		{
			directors = new List<Director>();
		}
	}
}
