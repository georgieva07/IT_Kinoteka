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
		public List<Show> shows { get; set; }
		
		public Genre()
		{
			shows = new List<Show>();
		}
	}
}