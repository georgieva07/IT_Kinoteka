using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Kinoteka.Models
{
    public class Genre
    {
        [Key]
        public int id { get; set; }
		[Required]
		[Display(Name = "Genre")]
		public String name { get; set; }
		[Display(Name = "Shows")]
		public virtual ICollection<Show> shows { get; set; }

		public Genre()
		{
			this.shows = new List<Show>();
		}
	}
}