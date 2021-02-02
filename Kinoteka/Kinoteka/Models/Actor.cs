using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kinoteka.Models
{
	public class Actor
	{
		[Key]
		public int id { get; set; }
		[Required]
		[Display(Name = "Name")]
		public String name { get; set; }
		public String image { get; set; }
		public virtual ICollection<Show> shows { get; set; }

		public Actor()
		{
			this.shows = new List<Show>();
		}
	}
}
