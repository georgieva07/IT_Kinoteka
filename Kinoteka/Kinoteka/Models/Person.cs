using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Kinoteka.Models
{
    public class Person
    {
        [Key]
        public int id { get; set; }
		[Required]
		[Display(Name = "Name")]
		public String name { get; set; }
        public String image { get; set; }
		[Required]
		[Display(Name = "Role")]
		public String role { get; set; } //actor, host
		public virtual ICollection<Show> shows { get; set; }

		public Person()
		{
			this.shows = new List<Show>();
		}


	}
}