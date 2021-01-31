using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Kinoteka.Models
{
    public class Show
    {
        [Key]
        public int id { get; set; }
		[Required]
		[Display(Name = "Title")]
		public String title { get; set; }
		[Display(Name = "Synopsis")]
		public String description { get; set; }
		public String image { get; set; }
		[Display(Name = "Release date")]
		public String released_date { get; set; }
		[Required]
		[Display(Name = "Rating")]
		public decimal rating { get; set; }
		[Required]
		[Display(Name = "Type of show")]
		public String type { get; set; } //movie, series, tv show
		[Required]
		[Display(Name = "Play")]
		public String play_link { get; set; }

		public virtual ICollection<Person> directors { get; set; }
		public virtual ICollection<Person> cast { get; set; }
		public virtual ICollection<Genre> genres { get; set; }

		public Show()
		{
			this.directors = new List<Person>();
			this.cast = new List<Person>();
			this.genres = new List<Genre>();
		}

    }
}