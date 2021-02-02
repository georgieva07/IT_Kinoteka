using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kinoteka.Models
{
	public class ShowCast
	{
		public int showId { get; set; }
		public int actorId { get; set; }
		public Show show { get; set; }
		public List<Actor> cast { get; set; }

		public ShowCast()
		{
			cast = new List<Actor>();
		}
	}
}
