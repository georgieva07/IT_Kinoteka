using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kinoteka.Models
{
	public class ShowGenre
	{
		public int showId { get; set; }
		public int genreId { get; set; }
		public Show show { get; set; }
		public List<Genre> genres { get; set; }

		public ShowGenre()
		{
			genres = new List<Genre>();
		}
	}
}
